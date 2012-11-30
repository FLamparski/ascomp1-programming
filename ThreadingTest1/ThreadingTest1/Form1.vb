Public Class Form1
    Dim threadctls As Collections.Hashtable
    Dim threads As Collections.Hashtable
    Dim threadnames As Collections.Specialized.StringCollection
    Dim thcount As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        threadctls = New Collections.Hashtable()
        threadnames = New Collections.Specialized.StringCollection()
        threads = New Collections.Hashtable()
        threadnames.AddRange({"Alpha", "Beta", "Gamma", "Delta"})
    End Sub

    '
    '
    '
    '
    '
    '
    ''' <summary>
    ''' Thread worker
    ''' </summary>
    ''' <param name="thname">Name of the thread. Used for ID, control and resource sharing.</param>
    ''' <remarks></remarks>
    Private Sub ThreadWorker(ByVal thname As String)
        Dim ctl As ThreadControlObject = threadctls(thname)
        While ctl.running
            Try
                Dim pbar As ProgressBar = ctl.widget
                pbar.Invoke(Sub() pbar.Value = New Random().Next(0, 100)) ' Use an anonymous function to execute label change on the main thread
                Threading.Thread.Sleep(50)
            Catch ex As InvalidOperationException
                Trace.WriteLine("Thread " + thname + " quitting: Form is closing or was destroyed.")
                Return ' If the label is unavailable, it means the form has closed. Nothing to do here, exit thread.
            End Try
        End While
        Trace.WriteLine("Thread " + thname + " has been ordered to be removed.")
    End Sub
    '
    '
    '
    '
    '
    '
    '
    '
    '
    '
    '

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If thcount < threadnames.Count Then
            thcount += 1
            Dim l As New ProgressBar()
            Me.Panel1.Controls.Add(l)
            l.Location = New Point(0, (thcount - 1) * 32)
            Dim c As New ThreadControlObject(threadnames(thcount - 1), l)
            threadctls.Add(threadnames(thcount - 1), c)
            Dim t As New Threading.Thread(AddressOf ThreadWorker)
            threads.Add(threadnames(thcount - 1), t)
            t.Start(threadnames(thcount - 1))
            Trace.WriteLine("Thread " + t.ToString() + " (" + c.name + ") started.")
        Else
            MessageBox.Show("All four threads already running!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If thcount > 0 Then
            Dim tn As String = threadnames(thcount - 1)
            Dim tc As ThreadControlObject = threadctls(tn)
            Dim t As Threading.Thread = threads(tn)
            tc.running = False
            t.Join(500)
            If t.IsAlive Then
                t.Abort()
                Trace.WriteLine("Warning: Thread " + tn + " was taking too long to finish and was killed.")
            End If
            Me.Panel1.Controls.Remove(tc.widget)
            threadctls.Remove(tc.name)
            threads.Remove(tc.name)
            thcount -= 1
        Else
            MessageBox.Show("No threads to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Trace.WriteLine("Ending running threads...")
        While thcount < 0
            Dim tn As String = threadnames(thcount - 1)
            Dim tc As ThreadControlObject = threadctls(tn)
            Dim t As Threading.Thread = threads(tn)
            tc.running = False
            t.Join(500)
            If t.IsAlive Then
                t.Abort()
                Trace.WriteLine("Warning: Thread " + tn + " was taking too long to finish and was killed.")
            End If
            Me.Panel1.Controls.Remove(tc.widget)
            threadctls.Remove(tc.name)
            threads.Remove(tc.name)
            thcount -= 1
        End While
        Trace.WriteLine("All running threads finished. Closing.")
    End Sub
End Class

''' <summary>
''' This class stores information about a thread's state. It is shared between the GUI thread and the worker thread.
''' </summary>
''' <remarks></remarks>
Public Class ThreadControlObject
    Public name As String
    Public running As Boolean
    Public widget As Control

    Sub New(ByVal name As String, ByRef ctl As Control)
        Me.name = name
        Me.widget = ctl
        Me.running = True
    End Sub
End Class