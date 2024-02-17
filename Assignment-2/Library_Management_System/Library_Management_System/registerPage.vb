Public Class registerPage

    Dim isStudent As Boolean = True

    Private Sub Student_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Student.Click
        Student.Font = New Font(Student.Font, FontStyle.Bold)
        Faculty.Font = New Font(Faculty.Font, FontStyle.Regular)
        isStudent = True
    End Sub

    Private Sub Faculty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Faculty.Click
        Student.Font = New Font(Student.Font, FontStyle.Regular)
        Faculty.Font = New Font(Faculty.Font, FontStyle.Bold)
        isStudent = False
    End Sub

    Private Sub Uname_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Uname.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If Uname.Text = "Name" Then
            Uname.Text = ""
            Uname.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub Uname_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Uname.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If Uname.Text = "" Then
            Uname.Text = "Name"
            Uname.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Private Sub Username_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Username.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If Username.Text = "Username" Then
            Username.Text = ""
            Username.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub Username_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Username.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If Username.Text = "" Then
            Username.Text = "Username"
            Username.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Private Sub Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Password.TextChanged
        If Password.Text <> "Password" Then
            Password.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Password_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Password.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If Password.Text = "Password" Then
            Password.Text = ""
            Password.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub Password_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Password.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If Password.Text = "" Then
            Password.Text = "Password"
            Password.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Private Sub CPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CPassword.TextChanged
        If CPassword.Text <> "Confirm Password" Then
            CPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub CPassword_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles CPassword.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If CPassword.Text = "Confirm Password" Then
            CPassword.Text = ""
            CPassword.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub CPassword_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles CPassword.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If CPassword.Text = "" Then
            CPassword.Text = "Confirm Password"
            CPassword.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Private Sub Login_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Login.LinkClicked
        Dim newForm As New loginPage()
        newForm.Show()
        Me.Hide()
    End Sub

    Private Sub Registerbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Registerbtn.Click
        If isStudent = True Then
            Dim newForm As New studentPage()
            newForm.Show()
            Me.Hide()
        Else
            Dim newForm As New facultyPage()
            newForm.Show()
            Me.Hide()
        End If
    End Sub
End Class
