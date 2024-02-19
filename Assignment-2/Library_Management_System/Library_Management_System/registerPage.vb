Imports MySql.Data.MySqlClient
Public Class registerPage
    
    ' Variables whose scope is within the form only
    Dim MySQLConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
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
        Me.BackgroundImage.Dispose()
        Me.Dispose()
    End Sub

    ' Backend function for registration
    ' Author: g-s01
    Private Sub Registerbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Registerbtn.Click
        ' Check whether any field is empty or not
        If Uname.Text = "Name" Then
            MessageBox.Show("Please write your name")
            Return
        End If
        If Username.Text = "Username" Then
            MessageBox.Show("Please write your username")
            Return
        End If
        If Password.Text = "Password" Then
            MessageBox.Show("Please write your password")
            Return
        End If
        ' Checking equality of `Password` and `CPassword`
        If Password.Text <> CPassword.Text Then
            MessageBox.Show("Confirm password doesn't match password")
            Return
        End If
        ' Creating a SQL connection
        MySQLConn = New MySqlConnection
        MySQLConn.ConnectionString = "server=127.0.0.1;userid=root;database=LMS;pwd=;"
        ' This query is to see if the user has already registered into the system or not
        Dim selectQuery As String
        ' This query is to insert the new user entry in the database
        Dim insertQuery As String
        If isStudent = True Then
            MySQLConn.Open()
            selectQuery = "SELECT * FROM students WHERE EXISTS (SELECT * FROM students WHERE ID = '" & Username.Text & "')"
            COMMAND = New MySqlCommand(selectQuery, MySQLConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            If count = 1 Then
                MessageBox.Show("You have already registered into the system!")
                READER.Close()
            Else
                READER.Close()
                insertQuery = "INSERT INTO " + "students" + " (ID, Password, Name, Fine) VALUES ('" & Username.Text & "', '" & Password.Text & "', '" & Uname.Text & "', '0')"
                COMMAND = New MySqlCommand(insertQuery, MySQLConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Saved with:" + vbCrLf +
                                "ID: ('" & Username.Text & "')" + vbCrLf +
                                "Name: ('" & Uname.Text & "')" + vbCrLf +
                                "Password: ('" & Password.Text & "')" + vbCrLf +
                                "Fine: Rs. 0")
                Dim newForm As New loginPage()
                newForm.Show()
                Me.BackgroundImage.Dispose()
                Me.Dispose()
            End If
            MySQLConn.Close()
        Else
            MySQLConn.Open()
            selectQuery = "SELECT * FROM faculty WHERE EXISTS (SELECT * FROM students WHERE ID = '" & Username.Text & "')"
            COMMAND = New MySqlCommand(selectQuery, MySQLConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            If count = 1 Then
                MessageBox.Show("You have already registered into the system!")
                READER.Close()
            Else
                READER.Close()
                insertQuery = "INSERT INTO " + "faculty" + " (ID, Password, Name, Fine) VALUES ('" & Username.Text & "', '" & Password.Text & "', '" & Uname.Text & "', '0')"
                COMMAND = New MySqlCommand(insertQuery, MySQLConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Saved with:" + vbCrLf +
                                "ID: ('" & Username.Text & "')" + vbCrLf +
                                "Name: ('" & Uname.Text & "')" + vbCrLf +
                                "Password: ('" & Password.Text & "')" + vbCrLf +
                                "Fine: Rs. 0")
                Dim newForm As New loginPage()
                newForm.Show()
                Me.BackgroundImage.Dispose()
                Me.Dispose()
            End If
            MySQLConn.Close()
        End If
    End Sub
End Class
