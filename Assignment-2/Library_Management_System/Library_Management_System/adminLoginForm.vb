Public Class adminLoginForm

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If TextBox1.Text = "Enter admin password here" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If TextBox1.Text = "" Then
            TextBox1.Text = "Enter admin password here"
            TextBox1.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Private Sub SubminButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubminButton.Click
        Dim newForm As New adminPage()
        newForm.Show()
        Me.Dispose()
    End Sub
End Class