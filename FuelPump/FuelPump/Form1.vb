Imports System.Threading

Public Class Form1
    Dim pump_is_pumping As Boolean
    Dim connected As Boolean
    Dim connect_set As Boolean
    Dim comm_thread_running As Boolean

    Dim sockcomm As SocketCommunicator

    Dim totalpriceSevenSegManager As SevenSegManager
    Dim litreSevenSegManager As SevenSegManager
    Dim priceSevenSegManager As SevenSegManager

    Dim servergoodbye As String

    Dim _fuelPrice As Decimal
    Dim _litres As Decimal
    Dim _totalPrice As Decimal

    ''' <summary>
    ''' Sets the fuel price, both on the display and internally, or gets the fuel price.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property FuelPrice As Decimal
        Get
            Return _fuelPrice
        End Get
        Set(ByVal value As Decimal)
            Dim _1 = Math.Round(value, 1) ' Shouldn't need it, but rounding errors happen.
            Dim _2 = _1.ToString() ' You'll see why...
            Dim _3 = _2.Replace(".", "")
            Dim _processed = Integer.Parse(_3) ' Because of this:
            priceSevenSegManager.SetNumber(_processed) ' SevenSegManagers can only display integers. It's up to us to place a decimal dot on the display.
            _fuelPrice = value ' Finally set the value.
        End Set
    End Property
    ''' <summary>
    ''' Sets the amounts of litres pumped both on the display and internally, or gets that amount.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property Litres As Decimal
        Get
            Return _litres
        End Get
        Set(ByVal value As Decimal)
            Dim _1 = Math.Round(value, 2) ' Get a fixed number of decimal digits.
            Dim _2 = _1.ToString()
            Dim _3 = _2.Replace(".", "")
            Dim _processed = Integer.Parse(_3)
            litreSevenSegManager.SetNumber(_processed)
            _litres = value
        End Set
    End Property
    ''' <summary>
    ''' Sets the total price, both on the display and internally, or gets the total price.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property TotalPrice As Decimal
        Get
            Return _totalPrice
        End Get
        Set(ByVal value As Decimal)
            Dim _1 = Math.Round(value, 2) ' Get a fixed number of decimal digits.
            Dim _2 = _1.ToString()
            Dim _3 = _2.Replace(".", "")
            Dim _processed = Integer.Parse(_3)
            totalpriceSevenSegManager.SetNumber(_processed)
            _totalPrice = value
        End Set
    End Property

    ''' <summary>
    ''' Callback for the thread-safe status label set method
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Delegate Sub SetStatusLabelCallback(ByVal [text] As String)
    ''' <summary>
    ''' Callback for the thread-safe message box
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Delegate Sub ConnectionLoopErrorCallback(ByVal [message] As String)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        totalpriceSevenSegManager = New SevenSegManager()
        litreSevenSegManager = New SevenSegManager()
        priceSevenSegManager = New SevenSegManager()

        'Add digits to totalprice
        totalpriceSevenSegManager.AddDigit(ss_totalprice_hundreds)
        totalpriceSevenSegManager.AddDigit(ss_totalprice_tens)
        totalpriceSevenSegManager.AddDigit(ss_totalprice_ones)
        ' decimal point is here
        totalpriceSevenSegManager.AddDigit(ss_totalprice_decimal)
        totalpriceSevenSegManager.AddDigit(ss_totalprice_hundredth)

        'Add digits to fuel pumped
        litreSevenSegManager.AddDigit(ss_pumped_hundreds)
        litreSevenSegManager.AddDigit(ss_pumped_tens)
        litreSevenSegManager.AddDigit(ss_pumped_ones)
        ' decimal point is here
        litreSevenSegManager.AddDigit(ss_pumped_decimal)
        litreSevenSegManager.AddDigit(ss_pumped_hundredth)

        'Add digits to price
        priceSevenSegManager.AddDigit(ss_price_hundreds)
        priceSevenSegManager.AddDigit(ss_price_tens)
        priceSevenSegManager.AddDigit(ss_price_ones)
        ' decimal point is here
        priceSevenSegManager.AddDigit(ss_price_decimal)

        'Set up the comm thread
        pump_is_pumping = False
        connected = False
        connect_set = False
        comm_thread_running = True
        Dim cloop = New Thread(AddressOf ConnectionLoop)
        cloop.Start() 'Run the comm thread.
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Space Then
            pump_is_pumping = True
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Space Then
            pump_is_pumping = False
        End If
    End Sub

    Private Sub btn_Pump_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_Pump.MouseDown
        pump_is_pumping = True
    End Sub

    Private Sub btn_Pump_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btn_Pump.MouseUp
        pump_is_pumping = False
    End Sub

    ''' <summary>
    ''' A thread-safe way of telling the user there's been an error.
    ''' </summary>
    ''' <param name="message"></param>
    ''' <remarks></remarks>
    Private Sub connectionloop_Error(ByVal [message] As String)
        If Me.lbl_Status.InvokeRequired Then
            Dim d As New ConnectionLoopErrorCallback(AddressOf connectionloop_Error)
            Me.Invoke(d, New Object() {[message]})
        Else
            MessageBox.Show([message], "Communication error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbl_Status.Text = "Not connected."
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        lbl_Status.Text = "Disconnecting / Please Wait"
        connected = False
        Thread.Sleep(100)
        comm_thread_running = False 'Quit the comm thread
    End Sub

    ''' <summary>
    ''' A thread-safe way of setting the status label from the worker thread.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Private Sub SetStatusLabel(ByVal [text] As String)
        If Me.lbl_Status.InvokeRequired Then
            Dim d As New SetStatusLabelCallback(AddressOf SetStatusLabel)
            Me.Invoke(d, New Object() {[text]})
        Else
            lbl_Status.Text = [text]
        End If
    End Sub

    Private Sub ConnectionLoop(ByVal to_where As String) ' Very important. Handles the protocol. So important it runs in a separate thread.
        While comm_thread_running ' So, while the thread is running...
            While connect_set ' And user wants to connect...
                SetStatusLabel("Connecting...")
                sockcomm = New SocketCommunicator()
                Try
                    sockcomm.Connect(en_ConsoleHost.Text) ' Try to connect to specified host.
                Catch ex As Exception
                    connect_set = False
                    connectionloop_Error(ex.Message)
                    Continue While ' If that fails, display error message.
                End Try
                If sockcomm.FlagError Then
                    connect_set = False
                    connectionloop_Error(sockcomm.ErrorValue)
                    Continue While ' If there are problems on the line, display error message.
                End If
                If sockcomm.FlagPriceCheck Then ' Get the price from the server.
                    FuelPrice = sockcomm.PriceCheckValue
                Else
                    connect_set = False
                    connectionloop_Error("Price check should be here by now.")
                    sockcomm.Disconnect()
                    Continue While ' (...)
                End If
                connected = True
                SetStatusLabel("Connected.") ' Success!
                While connected ' So while we're connected...
                    Dim realpumping = False
                    While pump_is_pumping ' And pumping...
                        sockcomm.StartPumping() ' Inform the server we're pumping
                        realpumping = True
                        While realpumping ' Simulates pumping
                            sockcomm.SendUnit()
                            Litres += My.Settings.LITRES_PER_SECOND
                            TotalPrice = Litres * FuelPrice
                            Thread.Sleep(Integer.Parse(My.Settings.LITRES_PER_SECOND * 1000))
                            If Not pump_is_pumping Then
                                realpumping = False ' Stop pumping? Oh.
                            End If
                        End While
                        sockcomm.StopPumping() ' We've stopped pumping; tell the server.
                    End While
                End While
                sockcomm.Disconnect() '... And we're closing the connection.
                servergoodbye = sockcomm.ServerGoodbyeData
                SetStatusLabel("Not connected.")
                connect_set = False
            End While
        End While
    End Sub

    Private Sub btn_Connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Connect.Click
        connect_set = True
    End Sub
End Class
