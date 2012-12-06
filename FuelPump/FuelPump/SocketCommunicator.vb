Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Public Class SocketCommunicator
    Private msocket As Socket
    Private mstream As Stream
    Private mstreamr As StreamReader
    Private mstreamw As StreamWriter


    Private reset_flag As Boolean
    ''' <summary>
    ''' An obtuse way of telling the parent thread that a reset should happen.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FlagReset() As Boolean
        Get
            Dim _r_F = reset_flag
            reset_flag = False
            Return _r_F
        End Get
    End Property


    Private err_flag As Boolean
    Private err_value As String
    ''' <summary>
    ''' An obtuse way of letting the parent thread know that there's an error. Gets reset on read.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Gets reset on read.</remarks>
    Public ReadOnly Property FlagError As Boolean
        Get
            Dim _e_F = err_flag ' Copy the error flag value into a temporary variable
            err_flag = False ' Reset the error flag internally
            Return _e_F ' Return the original value
        End Get
    End Property
    ''' <summary>
    ''' An obtuse way of sending an error message to the parent thread. Gets reset on read.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Gets reset on read.</remarks>
    Public ReadOnly Property ErrorValue As String
        Get
            Dim _e_V = String.Copy(err_value)
            err_value = ""
            Return _e_V
        End Get
    End Property

    Private pricecheck_flag As Boolean
    Private pricecheck_value As String
    ''' <summary>
    ''' An obtuse way of letting the parent thread know the price is set.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FlagPriceCheck As Boolean
        Get
            Return pricecheck_flag
        End Get
    End Property
    ''' <summary>
    ''' An obtuse way of sending the price to the parent thread.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PriceCheckValue As Decimal
        Get
            Return pricecheck_value
        End Get
    End Property
    ''' <summary>
    ''' An obtuse way of letting the parent know the socket is open.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FlagSocketOpen As Boolean
        Get
            Return msocket.Connected
        End Get
    End Property

    Private srv_goodbye_data As String
    ''' <summary>
    ''' An obtuse way of sending server goodbye data to the parent thread.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ServerGoodbyeData As String
        Get
            Return srv_goodbye_data
        End Get
    End Property

    ''' <summary>
    ''' Creates a new interface to communicate with the pump console.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        msocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    End Sub

    ''' <summary>
    ''' Connects to the host
    ''' </summary>
    ''' <param name="host">Address or hostname for connection</param>
    ''' <remarks></remarks>
    Public Sub Connect(ByVal host As String)
        msocket.Connect(host, My.Settings.PORT)
        mstream = New NetworkStream(msocket)
        mstreamr = New StreamReader(mstream)
        mstreamw = New StreamWriter(mstream)
        Dim handshakerd = mstreamr.ReadLine()
        If handshakerd = My.Settings.ServerHello Then
            mstreamw.WriteLine(My.Settings.ClientHello)
        Else
            err_value = String.Format("Handshake error. Expected {0}, got {1} instead.", My.Settings.Item("ServerHello"), handshakerd)
            err_flag = True
            msocket.Close()
            Return
        End If
        Dim pricerd = mstreamr.ReadLine()
        Dim priced As Decimal
        If Decimal.TryParse(pricerd, priced) Then
            pricecheck_flag = True
            pricecheck_value = priced
        Else
            err_value = String.Format("Price check error. Could not convert {0} into a decimal value.", pricerd)
            err_flag = True
            msocket.Close()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Gets a new message from the server and process it.
    ''' </summary>
    ''' <remarks>NO error checking; bad messages are simply ignored.</remarks>
    Public Sub PollServer()
        Dim message_in As String = mstreamr.ReadLine()
        Dim pricecheck_regexpattern As String = "^PRICE\t(<price_val>\d\.\d{3})$"
        If message_in = "RESET" Then
            reset_flag = True
        End If
        Dim pricecheck_regex As New Regex(pricecheck_regexpattern)
        If pricecheck_regex.IsMatch(message_in) Then
            Dim newprice As Decimal
            Dim match = pricecheck_regex.Match(message_in)
            If Decimal.TryParse(match.Groups("price_val").Value, newprice) Then
                pricecheck_value = newprice
                pricecheck_flag = True
            End If
        End If
    End Sub

    Public Sub StartPumping()
        mstreamw.WriteLine("CL_STARTPUMP")
    End Sub

    Public Sub StopPumping()
        mstreamw.WriteLine("CL_STOPPUMP")
    End Sub

    ''' <summary>
    ''' Update the server with what the user has pumped
    ''' </summary>
    ''' <param name="total_pumped">Litres pumped</param>
    ''' <param name="total_sale">Sale, computed by the pump</param>
    ''' <param name="price">Price at which the pump is pumping (may differ as price is not updated while pumping)</param>
    ''' <remarks></remarks>
    Public Sub PumpUnit(ByVal total_pumped As Decimal, ByVal total_sale As Decimal, ByVal price As Decimal)
        Dim strsend As String = total_pumped.ToString() & vbTab & total_sale.ToString() & vbTab & price.ToString()
        mstreamw.WriteLine(strsend)
    End Sub

    Public Sub Disconnect()
        mstreamw.WriteLine("CL_BYE")
        Dim byerd = mstreamr.ReadLine()
        srv_goodbye_data = byerd
        msocket.Close()
    End Sub
End Class
