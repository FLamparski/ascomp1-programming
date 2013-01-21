Imports System.Net.Sockets
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Public Class SocketCommunicator
    Dim m_tcpClient As TcpClient
    Dim m_udpClient As UdpClient
    Dim tcpWriter As StreamWriter
    Dim tcpReader As StreamReader
    Dim udpWriter As StreamWriter
    Dim udpReader As StreamReader


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
        m_tcpClient = New TcpClient(AddressFamily.InterNetwork)
        m_udpClient = New UdpClient(AddressFamily.InterNetwork)
    End Sub

    ''' <summary>
    ''' Registers the pump on the console
    ''' </summary>
    ''' <param name="host">Address or hostname for connection</param>
    ''' <remarks></remarks>
    Public Sub Connect(ByVal host As String, ByVal pumpid As String)
        m_tcpClient.Connect(host, 15000)
        tcpReader = New StreamReader(m_tcpClient.GetStream())
        tcpWriter = New StreamWriter(m_tcpClient.GetStream())

        tcpWriter.AutoFlush = True
        tcpWriter.WriteLine("PUMP REGISTER" + vbTab + pumpid)

        Dim ack = False
        Dim counter = 0
        While Not ack
            If tcpReader.ReadLine() = ("REGISTERED" + vbTab + pumpid) Then
                ack = True
            Else
                counter += 1
            End If
            If counter = 100 Then
                m_tcpClient.Close()
                Throw New TooManyTriesException("Cannot register the pump right now. Is the server busy?")
            End If
        End While
    End Sub

    ''' <summary>
    ''' Gets a new message from the server and process it.
    ''' </summary>
    ''' <remarks>NO error checking; bad messages are simply ignored.</remarks>
    Public Sub PollServer()
        
    End Sub

    Public Sub StartPumping()

    End Sub

    Public Sub StopPumping()

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
        
    End Sub
End Class

Public Class TooManyTriesException
    Inherits Exception
    Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class