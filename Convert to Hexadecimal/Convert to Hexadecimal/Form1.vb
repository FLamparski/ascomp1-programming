Public Class Form1

    Dim binP1(3) As Integer 'Array for first part of binary number
    Dim binP2(3) As Integer 'Array for second part of binary number
    Dim convHash As Collections.Hashtable 'Hashtable for quick hex lookup

    Public Function Switch01(ByVal btext As Integer) As Integer 'Function to switch the value of the text on the button
        If btext = 0 Then 'If the text is 0
            Return 1 'Change to 1
        Else
            Return 0 'Change to 0
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Text = Switch01(Button1.Text) 'Call Function to switch the button text around
        binP1(0) = Button1.Text 'Store current text in relevant position in array
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.Text = Switch01(Button2.Text)
        binP1(1) = Button2.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button3.Text = Switch01(Button3.Text)
        binP1(2) = Button3.Text
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button4.Text = Switch01(Button4.Text)
        binP1(3) = Button4.Text
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Button5.Text = Switch01(Button5.Text)
        binP2(0) = Button5.Text
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Button6.Text = Switch01(Button6.Text)
        binP2(1) = Button6.Text
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Button7.Text = Switch01(Button7.Text)
        binP2(2) = Button7.Text
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Button8.Text = Switch01(Button8.Text)
        binP2(3) = Button8.Text
    End Sub

    'Create subroutine/function here:
    Public Function Convert(ByVal binP() As Integer) As String
        Dim innum As New System.Text.StringBuilder()

        For Each bin As Integer In binP
            innum.Append(bin.ToString()) 'Convert the binary part to string format
        Next

        Return convHash(innum.ToString()) 'Look up the binary number's hex format
    End Function

    'Button to convert to Hexadecimal
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Remove comment below to enable program to work with subroutine/function
        Label1.Text = Convert(binP1) & Convert(binP2)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        convHash = New Collections.Hashtable
        convHash.Add("0000", "0") 'Populate the hex lookup hashtable
        convHash.Add("0001", "1")
        convHash.Add("0010", "2")
        convHash.Add("0011", "3")
        convHash.Add("0100", "4")
        convHash.Add("0101", "5")
        convHash.Add("0110", "6")
        convHash.Add("0111", "7")
        convHash.Add("1000", "8")
        convHash.Add("1001", "9")
        convHash.Add("1010", "A")
        convHash.Add("1011", "B")
        convHash.Add("1100", "C")
        convHash.Add("1101", "D")
        convHash.Add("1110", "E")
        convHash.Add("1111", "F")
    End Sub
End Class
