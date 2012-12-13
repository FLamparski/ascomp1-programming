Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class Form1
    Dim uivar_server_running As Boolean
    Dim uivar_thread_names() As String = {"Obama", "Bush", "Clinton", "Eisenhower", "Washington", "Edison", "Tesla", "Einstein", "Rammstein"}
    Dim uivar_price As Decimal
    Dim listener_thread As Thread
    Dim listener_obj As TcpListener ' Bridge object between the UI thread and the listener thread
    Dim listener_controller As DispatcherController
    Dim worker_threads As Collections.Hashtable
    Dim worker_controllers As Collections.Hashtable
    Private Sub tb_ShowLogWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_ShowLogWindow.Click
        textview_Messages.Visible = Not textview_Messages.Visible
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text += Dns.GetHostName()
        ten_HostnameDisplay.Text = Dns.GetHostName()
        uivar_server_running = False
        listener_obj = New TcpListener(IPAddress.Any, 15000)
        listener_controller = New DispatcherController("Putin", textview_Messages, listener_obj)
        'listener_thread = New Thread(AddressOf ConnectionDispatcher)
        worker_controllers = New Hashtable()
        worker_threads = New Hashtable()
        textview_Messages.Text = "Welcome to the station console. Current version is 0.1. Ready to work."
    End Sub

    Private Sub tb_ServerStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_ServerStartStop.Click
        If uivar_server_running Then
            textview_Messages.Text += vbNewLine + "GUI: Stopping server..."
            listener_controller.IsThreadRunning = False
            listener_thread.Join(1000)
            If listener_thread.IsAlive Then
                listener_thread.Abort()
                textview_Messages.Text += vbNewLine + "GUI: Server was forcefully stopped. Reason: took too long to stop."
                listener_controller.MyTcpListener.Stop()
                For Each tc As DictionaryEntry In worker_controllers ' If this takes more than one second, the listener thread will be aborted.
                    listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + "GUI" + ": Ending sub-thread " & tc.Key)
                    tc.Value.IsThreadRunning = False
                    tc.Value.MySocket.Close()
                    worker_threads(tc.Key).Join(500)
                    If worker_threads(tc.Key).IsAlive = True Then worker_threads(tc.Key).Abort()
                Next
            End If
            textview_Messages.Text += vbNewLine + "GUI: Server stopped."

            tb_ServerStartStop.Image = My.Resources.glyphicons_173_play
            tb_ServerStartStop.Text = "Start server"
            uivar_server_running = False
        Else
            textview_Messages.Text += vbNewLine + "GUI: Starting server..."
            listener_controller.IsThreadRunning = True
            listener_thread = New Thread(AddressOf ConnectionDispatcher)
            listener_thread.Start("Putin")
            textview_Messages.Text += vbNewLine + "GUI: Server started."


            tb_ServerStartStop.Image = My.Resources.glyphicons_175_stop
            tb_ServerStartStop.Text = "Stop server"
            uivar_server_running = True
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim dlg As New PriceSetterDlg
        dlg.FuelPrice = uivar_price
        If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            uivar_price = dlg.FuelPrice
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        listener_controller.IsThreadRunning = False
        listener_thread.Join(1000)
        If listener_thread.IsAlive Then
            listener_thread.Abort()
            textview_Messages.Text += vbNewLine + "GUI: Server was forcefully stopped. Reason: took too long to stop."
            listener_controller.MyTcpListener.Stop()
            For Each tc As DictionaryEntry In worker_controllers ' If this takes more than one second, the listener thread will be aborted.
                listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + "GUI" + ": Ending sub-thread " & tc.Key)
                tc.Value.IsThreadRunning = False
                tc.Value.MySocket.Close()
                worker_threads(tc.Key).Join(500)
                If worker_threads(tc.Key).IsAlive = True Then worker_threads(tc.Key).Abort()
            Next
        End If
    End Sub

    ''' <summary>
    ''' Produce a new PumpForm attached to this window for worker threads to use.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPumpSubform() As PumpForm
        Dim f As New PumpForm
        f.MdiParent = Me
        Return f
    End Function

    Private Sub ConnectionDispatcher(ByVal name As String)
        listener_controller.MyTcpListener.Start(5)
        listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Server started. Listening on port 15000.")

        While listener_controller.IsThreadRunning
            If worker_threads.Count < uivar_thread_names.Length Then
                Dim accepted_connection As Socket = listener_controller.MyTcpListener.AcceptSocket()
                listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Connection from " & accepted_connection.RemoteEndPoint.ToString() & " accepted. Starting the handler thread...")
                Dim pumpform As Form = Me.Invoke(Function() Me.GetPumpSubform())
                Dim controller As New CommunicatorController(uivar_thread_names(worker_threads.Count), accepted_connection, pumpform, textview_Messages)
                Dim server_thread As New Thread(AddressOf ConnectionHandler)
                worker_threads.Add(uivar_thread_names(worker_threads.Count), server_thread)
                worker_controllers.Add(uivar_thread_names(worker_threads.Count), controller)
                server_thread.Start(uivar_thread_names(worker_threads.Count))
                listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Handler thread for " & accepted_connection.RemoteEndPoint.ToString() & " started.")
            Else
                listener_controller.MessageWindow.Invoke(Sub(connection) MessageBox.Show("Too many connections. Closing incoming", "Server at capacity", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Server at capacity: incoming connections are refused.")
            End If
        End While
        listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Server stopping...")
        listener_controller.MyTcpListener.Stop()
        'For Each tc As AmericanController In worker_controllers ' If this takes more than one second, the listener thread will be aborted.
        '    listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Ending sub-thread " & tc.ThreadName)
        '    tc.IsThreadRunning = False
        '    tc.MySocket.Close()
        'Next
        listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Server stopped.")
    End Sub

    Private Sub ConnectionHandler(ByVal th_name As String)
        Dim myController As CommunicatorController = worker_controllers(th_name)
        Dim stream As Stream = New NetworkStream(myController.MySocket)
        Dim streamr As New StreamReader(stream)
        Dim streamw As New StreamWriter(stream)
        streamw.AutoFlush = True
        myController.MessageWindow.Invoke(Sub() myController.MessageWindow.Text += vbNewLine + th_name + ": Connection established with " & myController.MySocket.RemoteEndPoint.ToString())
        While (myController.IsThreadRunning)
            Try
                Dim inConnectionLoop As Boolean = True
                Dim pumpingLoop As Boolean = False

                ' Handshake
                Trace.WriteLine("<< To " & myController.MySocket.RemoteEndPoint.ToString() & "; Message: HELLO")
                streamw.WriteLine("HELLO")
                Trace.WriteLine("Awaiting message from " & myController.MySocket.RemoteEndPoint.ToString() & ".")
                Dim readin As String = streamr.ReadLine()
                Trace.WriteLine(">> From " & myController.MySocket.RemoteEndPoint.ToString() & "; Message: " & readin)
                If Not readin = "HOWDY" Then
                    myController.MySocket.Close()
                    myController.MessageWindow.Invoke(Sub() myController.MessageWindow.Text += vbNewLine + th_name + ": Error: Pump at " & myController.MySocket.RemoteEndPoint.ToString() & " failed handshake, expected HOWDY, got " & readin)
                    myController.MessageWindow.Invoke(Sub() myController.MessageWindow.Text += vbNewLine + th_name + ": Closed connection with " & myController.MySocket.RemoteEndPoint.ToString())
                End If

                ' Send initial price check
                streamw.WriteLine(uivar_price.ToString())

                While inConnectionLoop
                    readin = streamr.ReadLine()
                    If readin = "?" Then
                        ' Send updates as we've been polled
                    End If

                    If readin = "CL_STARTPUMP" Then
                        pumpingLoop = True
                    End If

                    While pumpingLoop
                        readin = streamr.ReadLine()
                        Dim pumpExpression As New Regex("^(<pumped>\d{1,10}\.\d)\t(<sale>\d{1,10}\.\d)\t(<price>\d{1,3}\.\d)$")
                        If readin = "CL_STOPPUMP" Then
                            pumpingLoop = False
                            Continue While
                        ElseIf pumpExpression.IsMatch(readin) Then
                            Dim match = pumpExpression.Match(readin)
                            myController.AssociatedForm.Invoke(Sub() myController.AssociatedForm.SetValues(match.Groups("pumped").Value, match.Groups("sale").Value, match.Groups("price").Value))
                        Else

                        End If
                    End While
                End While
            Catch ex As IOException
                myController.MessageWindow.Invoke(Sub() MessageBox.Show("Error: Client dropped (" & myController.MySocket.RemoteEndPoint.ToString() & "); Exception: " & ex.Message, "Client error", MessageBoxButtons.OK, MessageBoxIcon.Error))
                myController.MessageWindow.Invoke(Sub() myController.MessageWindow.Text += vbNewLine + th_name + ": Closed connection with " & myController.MySocket.RemoteEndPoint.ToString() & " due to an error.")
                myController.MySocket.Dispose()
                myController.IsThreadRunning = False ' Connection closed? End thread.
            End Try
        End While
        ' Since the main loop finished, connection is closed (normally or abnormally). Clean up and terminate thread.
        worker_controllers.Remove(th_name) ' Clean up references to this thread's controller
        worker_threads.Remove(th_name) ' Clean up references to this thread
        Return ' Return sub = end thread
    End Sub
End Class

''' <summary>
''' A simple object which acts as an interface between the GUI thread and the connection dispatcher thread.
''' </summary>
''' <remarks></remarks>
Public Class DispatcherController

    Private msg_win As Control

    ''' <summary>
    ''' Text control which acts as a log window within the GUI.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MessageWindow() As Control
        Get
            Return msg_win
        End Get
        Set(ByVal value As Control)
            msg_win = value
        End Set
    End Property


    Private thread_name As String

    ''' <summary>
    ''' Name of the dispatcher thread
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThreadName() As String
        Get
            Return thread_name
        End Get
        Set(ByVal value As String)
            thread_name = value
        End Set
    End Property


    Private tcp_listener As TcpListener

    ''' <summary>
    ''' TcpListener which the thread uses to dispatch connections
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MyTcpListener() As TcpListener
        Get
            Return tcp_listener
        End Get
        Set(ByVal value As TcpListener)
            tcp_listener = value
        End Set
    End Property


    Private thread_running As Boolean

    ''' <summary>
    ''' Control variable; stops the dispatcher when set to False
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsThreadRunning() As Boolean
        Get
            Return thread_running
        End Get
        Set(ByVal value As Boolean)
            thread_running = value
        End Set
    End Property


    ''' <summary>
    ''' Creates a new DispatcherController object
    ''' </summary>
    ''' <param name="name">Name for the dispatcher thread</param>
    ''' <param name="log">Log window control</param>
    ''' <param name="listener">Listener object</param>
    ''' <remarks></remarks>
    Sub New(ByVal name As String, ByRef log As Control, ByRef listener As TcpListener)
        thread_name = name
        msg_win = log
        tcp_listener = listener
        thread_running = True
    End Sub

End Class

''' <summary>
''' A simple object which allows a worker thread to communicate with the GUI thread.
''' </summary>
''' <remarks></remarks>
Public Class CommunicatorController

    Private thread_name As String
    Public Property ThreadName() As String
        Get
            Return thread_name
        End Get
        Set(ByVal value As String)
            thread_name = value
        End Set
    End Property

    Private window_object As PumpForm
    Public Property AssociatedForm() As PumpForm
        Get
            Return window_object
        End Get
        Set(ByVal value As PumpForm)
            window_object = value
        End Set
    End Property


    Private connector As Socket
    Public Property MySocket() As Socket
        Get
            Return connector
        End Get
        Set(ByVal value As Socket)
            connector = value
        End Set
    End Property

    Private thread_running As Boolean
    Public Property IsThreadRunning() As Boolean
        Get
            Return thread_running
        End Get
        Set(ByVal value As Boolean)
            thread_running = value
        End Set
    End Property


    Private msg_win As Control
    Public Property MessageWindow() As Control
        Get
            Return msg_win
        End Get
        Set(ByVal value As Control)
            msg_win = value
        End Set
    End Property


    Private fprice As Decimal
    Public Property FuelPrice() As Decimal
        Get
            Return fprice
        End Get
        Set(ByVal value As Decimal)
            fprice = value
            RaiseEvent FuelPriceChanged(value)
        End Set
    End Property


    Private flitres As Decimal
    Public Property FuelLitresPumped() As Decimal
        Get
            Return flitres
        End Get
        Set(ByVal value As Decimal)
            flitres = value
            RaiseEvent LitresPumpedChanged(value)
        End Set
    End Property


    Private fsale As Decimal
    Public Property FuelTotalSale() As Decimal
        Get
            Return fsale
        End Get
        Set(ByVal value As Decimal)
            fsale = value
            RaiseEvent TotalSaleChanged(value)
        End Set
    End Property



    Sub New(ByVal name As String, ByRef sock As Socket, ByRef win As PumpForm, ByRef msg_log As Control)
        thread_name = name
        connector = sock
        window_object = win
        msg_win = msg_log
        thread_running = True
    End Sub

    Public Event FuelPriceChanged(ByVal new_price As Decimal)
    Public Event TotalSaleChanged(ByVal new_ts As Decimal)
    Public Event LitresPumpedChanged(ByVal new_lp As Decimal)
    Public Event PumpStarted()
    Public Event PumpStopped() ' Will log transaction
    Public Event PumpReset()
End Class