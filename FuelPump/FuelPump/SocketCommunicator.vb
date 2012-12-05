Imports System.Net.Sockets
Imports System.Net
Imports System.IO

Public Class SocketCommunicator
    Private msocket As Socket
    Private mstream As Stream
    Private mstreamr As StreamReader
    Private mstreamw As StreamWriter

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

    Public Sub StartPumping()
        mstreamw.WriteLine("CL_STARTPUMP")
    End Sub

    Public Sub StopPumping()
        mstreamw.WriteLine("CL_STOPPUMP")
    End Sub

    Public Sub SendUnit()
        mstreamw.WriteLine(My.Settings.UnitChar)
    End Sub

    Public Sub Disconnect()
        mstreamw.WriteLine("CL_BYE")
        Dim byerd = mstreamr.ReadLine()
        srv_goodbye_data = byerd
        msocket.Close()
    End Sub
End Class
