' Filip Wieland

Public Class Form1

    Private Function Rot13(ByVal intext As String) As String
        intext = intext.ToUpper() ' Read in the user's input
        Dim _rot13 As New System.Text.StringBuilder() ' StringBuilder allows me to build strings like ArrayLists
        For charloop As Integer = 0 To intext.Length - 1 ' Iterate over the string
            Dim currentchar As Char = intext(charloop) ' Get current character
            Dim charcode As Integer = Microsoft.VisualBasic.Asc(currentchar) ' Convert to ASCII code
            If charcode > 64 And charcode < 91 Then ' Uppercase letters have char codes 64 < char < 91
                If (charcode + 13) <= 90 Then ' Shift the char code by 13.
                    _rot13.Append(Microsoft.VisualBasic.Chr(charcode + 13).ToString()) ' If by moving it by 13 we won't go over the uppercase range, add 13 to charcode, convert it to a char and append it to the string builder.
                Else
                    _rot13.Append(Microsoft.VisualBasic.Chr(charcode - 13).ToString()) ' If by moving it by 13 we WILL go over the uppercase range, subtract 13 from charcode instead. Then convert, append to string builder.
                End If
            Else
                _rot13.Append(currentchar.ToString()) ' Don't decode/encode symbols
            End If
        Next
        Return _rot13.ToString() ' Write out
    End Function

    Private Sub btn_Cipher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cipher.Click
        en_textOut.Text = Rot13(en_textIn.Text) ' Call Rot13
    End Sub

    Private Sub en_textIn_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles en_textIn.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then ' Enter key pressed
            en_textOut.Text = Rot13(en_textIn.Text) ' Call Rot13
        End If
    End Sub
End Class
