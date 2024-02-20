Public Class InputPromptForm

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
        ' When the textbox gains focus, clear the placeholder text if it's present
        If TextBox1.Text = "0" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        ' When the textbox loses focus and it's empty, display the placeholder text
        If TextBox1.Text = "" Then
            TextBox1.Text = "0"
            TextBox1.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Public ReadOnly Property InputValue As String
        Get
            Return TextBox1.Text
        End Get
    End Property

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click, Button1.Click
        ' Close the form when OK button is clicked
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class