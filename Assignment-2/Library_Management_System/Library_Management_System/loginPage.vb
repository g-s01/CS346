Imports MySql.Data.MySqlClient

Public Class loginPage
    ' Publicly shared variables between forms
    Public Shared ID As String
    Public Shared studentOrFaculty As String
    Dim MySQLConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim isStudent As Boolean = True ' Initializing with True

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
        If Password.Text <> "" Then
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

    Private Sub Loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Loginbtn.Click
        MySQLConn = New MySqlConnection
        MySQLConn.ConnectionString = "server=127.0.0.1;userid=root;database=LMS;pwd=;"
        Dim READER As MySqlDataReader

        Try
            'connection.Open()
            MySQLConn.Open()
            Dim Query As String
            If isStudent = True Then

                Query = "SELECT * FROM students where ID='" & Username.Text & "' and Password= '" & Password.Text & "'"
                COMMAND = New MySqlCommand(Query, MySQLConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer
                count = 0
                While READER.Read
                    count = count + 1
                End While
                If count = 1 Then
                    ID = Username.Text
                    studentOrFaculty = "students"
                    Dim newForm As New studentPage()
                    newForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Username and Password are incorrect")
                    Return
                End If

            Else
                Query = "SELECT * FROM faculty where ID='" & Username.Text & "' and Password= '" & Password.Text & "'"
                COMMAND = New MySqlCommand(Query, MySQLConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer
                count = 0
                While READER.Read
                    count = count + 1
                End While
                If count = 1 Then
                    ID = Username.Text
                    studentOrFaculty = "faculty"
                    Dim newForm As New facultyPage()
                    newForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Username and Password are incorrect")
                    Return
                End If
            End If

            MySQLConn.Close()

            Console.WriteLine("Connection successful!")
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            Console.WriteLine("Connection failed: " & ex.Message)
        Finally
            MySQLConn.Dispose()

        End Try
    End Sub

    Private Sub Register_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Register.LinkClicked
        Dim newForm As New registerPage()
        newForm.Show()
        Me.BackgroundImage.Dispose()
        Me.Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim newForm As New adminLoginForm()
        newForm.Show()
        Me.BackgroundImage.Dispose()
        Me.Dispose()
    End Sub
End Class
