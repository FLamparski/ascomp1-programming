Public Class Form1
    Dim baseDatetime As Date
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        baseDatetime = Date.Now
        lbl_TimeTest.Text = String.Format("{0}:{1}:{2}", baseDatetime.Hour, baseDatetime.Minute, baseDatetime.Second)
    End Sub

    Private Sub clockTick_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clockTick.Tick
        baseDatetime = Date.Now
        lbl_TimeTest.Text = String.Format("{0}:{1}:{2}", baseDatetime.Hour, baseDatetime.Minute, baseDatetime.Second)
    End Sub
End Class
