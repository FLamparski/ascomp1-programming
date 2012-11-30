Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading

Public Class Form1
    Dim uivar_server_running As Boolean
    Dim uivar_thread_names() As String = {"Obama", "Bush", "Clinton", "Eisenhower", "Washington", "Edison", "Tesla", "Einstein", "Rammstein"}
    Dim uivar_price As Decimal
    Dim listener_thread As Thread
    Dim listener_obj As TcpListener ' Bridge object between the UI thread and the listener thread
    Dim listener_controller As PutinController
    Dim worker_threads As Collections.Hashtable
    Dim worker_controllers As Collections.Hashtable
    Private Sub tb_ShowLogWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_ShowLogWindow.Click
        textview_Messages.Visible = Not textview_Messages.Visible
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text += Dns.GetHostName()
        ten_HostnameDisplay.Text = Dns.GetHostName()
        uivar_server_running = False
        listener_obj = New TcpListener(15000) 'TODO: Use the new init method
        listener_controller = New PutinController("Putin", textview_Messages, listener_obj)
        listener_thread = New Thread(AddressOf ConnectionDispatcher)
    End Sub

    Private Sub tb_ServerStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_ServerStartStop.Click
        If uivar_server_running Then
            listener_controller.IsThreadRunning = False
            listener_thread.Join(1000)
            If listener_thread.IsAlive Then
                listener_thread.Abort()
            End If

            tb_ServerStartStop.Image = My.Resources.glyphicons_173_play
            tb_ServerStartStop.Text = "Start server"
        Else
            listener_controller.IsThreadRunning = True
            listener_thread.Start("Putin")


            tb_ServerStartStop.Image = My.Resources.glyphicons_175_stop
            tb_ServerStartStop.Text = "Stop server"
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' TODO: Close all running threads on exit
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
                Dim pumpform As Form = Me.Invoke(Function() Me.GetPumpSubform())
                Dim controller As New AmericanController(worker_threads.Count, accepted_connection, pumpform, textview_Messages)

            End If
        End While
        listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Server stopping...")
        listener_controller.MyTcpListener.Stop()
        For Each tc As AmericanController In worker_controllers ' If this takes more than one second, the listener thread will be aborted.
            tc.IsThreadRunning = False
            tc.MySocket.Close()
        Next
        listener_controller.MessageWindow.Invoke(Sub() listener_controller.MessageWindow.Text += vbNewLine + name + ": Server stopped.")
    End Sub
End Class

Public Class PutinController

    Private msg_win As Control
    Public Property MessageWindow() As Control
        Get
            Return msg_win
        End Get
        Set(ByVal value As Control)
            msg_win = value
        End Set
    End Property


    Private thread_name As String
    Public Property ThreadName() As String
        Get
            Return thread_name
        End Get
        Set(ByVal value As String)
            thread_name = value
        End Set
    End Property


    Private tcp_listener As TcpListener
    Public Property MyTcpListener() As TcpListener
        Get
            Return tcp_listener
        End Get
        Set(ByVal value As TcpListener)
            tcp_listener = value
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



    Sub New(ByVal name As String, ByRef log As Control, ByRef listener As TcpListener)
        thread_name = name
        msg_win = log
        tcp_listener = listener
        thread_running = True
    End Sub

End Class

Public Class AmericanController

    Private thread_name As String
    Public Property ThreadName() As String
        Get
            Return thread_name
        End Get
        Set(ByVal value As String)
            thread_name = value
        End Set
    End Property

    Private window_object As Form
    Public Property AssociatedForm() As Form
        Get
            Return window_object
        End Get
        Set(ByVal value As Form)
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


    Sub New(ByVal name As String, ByRef sock As Socket, ByRef win As Form, ByRef msg_log As Control)
        thread_name = name
        connector = sock
        window_object = win
        msg_win = msg_log
        thread_running = True
    End Sub

End Class