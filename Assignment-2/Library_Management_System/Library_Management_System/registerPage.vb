Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System

Public Class registerPage

    ' Variables whose scope is within the form only
    Dim MySQLConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim READER As MySqlDataReader
    Dim isStudent As Boolean = True
    Dim code As Integer
    Dim isConfirmed As Boolean = False

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
        ' Check if the text of the Password TextBox is not equal to "Password"
        If Password.Text <> "Password" Then
            ' Set UseSystemPasswordChar property to true to hide the password characters
            Password.UseSystemPasswordChar = True
        End If

        ' Get the password from the Password TextBox
        Dim passwordText As String = Password.Text

        ' Check the password strength
        CheckPasswordStrength(passwordText)
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
        MySQLConn.ConnectionString = "server=127.0.0.1;userid=root;database=LMS;pwd=hello;"
        ' This query is to see if the user has already registered into the system or not
        Dim selectQuery As String
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
                Dim pattern As String = "^[a-zA-Z0-9._%+-]+@iitg\.ac\.in$"
                If Not Regex.IsMatch(Username.Text, pattern) Then
                    MessageBox.Show("Enter a valid email ending with @iitg.ac.in for successful registration!")
                    Return
                End If
                Dim random As New Random()
                Dim randomNumber As Integer = random.Next(100000, 999999)
                code = randomNumber
                sendEmail(randomNumber)
                MessageBox.Show("Check your inbox, enter OTP on the right hand textbox for confirmation")
            End If
            MySQLConn.Close()
        Else
            MySQLConn.Open()
            selectQuery = "SELECT * FROM faculty WHERE EXISTS (SELECT * FROM faculty WHERE ID = '" & Username.Text & "')"
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
                Dim pattern As String = "^[a-zA-Z0-9._%+-]+@iitg\.ac\.in$"
                If Not Regex.IsMatch(Username.Text, pattern) Then
                    MessageBox.Show("Enter a valid email ending with @iitg.ac.in for successful registration!")
                    Return
                End If
                Dim random As New Random()
                Dim randomNumber As Integer = random.Next(100000, 999999)
                code = randomNumber
                sendEmail(randomNumber)
                MessageBox.Show("Check your inbox, enter OTP on the right hand textbox for confirmation")
            End If
            MySQLConn.Close()
        End If
    End Sub

    Private Sub sendEmail(randomNumber As Integer)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("lms-cs346@outlook.com", Username.Text)
        message.Subject = "Registration confirmation"
        message.Body = "Welcome to the LMS-CS346! Your OTP is " + randomNumber.ToString

        Dim smtpClient As New SmtpClient(smtpServer)
        smtpClient.Port = port
        smtpClient.Credentials = New System.Net.NetworkCredential("lms-cs346@outlook.com", "SaviourSarvesh")
        smtpClient.EnableSsl = True

        Try
            smtpClient.Send(message)
        Catch ex As SmtpException
            ' Handle specific SMTP exceptions
            MessageBox.Show("SMTP error: " & ex.Message)
        Catch ex As Exception
            ' Handle other exceptions
            MessageBox.Show("Error sending email: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim insertQuery As String
        Dim db As String
        If isStudent = True Then
            db = "students"
        Else
            db = "faculty"
        End If
        If code.ToString = TextBox1.Text Then
            isConfirmed = True
            MessageBox.Show("Confirmation Successful")
            MySQLConn = New MySqlConnection
            MySQLConn.ConnectionString = "server=127.0.0.1;userid=root;database=LMS;pwd=;"
            MySQLConn.Open()
            insertQuery = "INSERT INTO " + db + " (ID, Password, Name, Fine, Balance, Code) VALUES ('" & Username.Text & "', '" & Password.Text & "', '" & Uname.Text & "', '0', '0', '')"
            COMMAND = New MySqlCommand(insertQuery, MySQLConn)
            READER = COMMAND.ExecuteReader
            MessageBox.Show("Data Saved with:" + vbCrLf +
                            "ID: ('" & Username.Text & "')" + vbCrLf +
                            "Name: ('" & Uname.Text & "')" + vbCrLf +
                            "Password: ('" & Password.Text & "')" + vbCrLf +
                            "Fine: Rs. 0" + vbCrLf +
                            "Balance: Rs. 0")
            MySQLConn.Close()
            Dim newForm As New loginPage()
            newForm.Show()
            Me.BackgroundImage.Dispose()
            Me.Dispose()
        Else
            MessageBox.Show("Incorrect OTP")
        End If
    End Sub

    ' Function to check password strength
    Private Sub CheckPasswordStrength(ByVal password As String)

        'Dim password As String = password.Text
        Dim score As Integer

        score = CalculateScore(password)

        ' Convert password to lowercase for case-insensitive matching
        'password = password.ToLower()

        ' Check for common sequences using the CheckCommonSequences function
        If CheckCommonSequences(password) Then
            score -= 2

        End If

        

        'Ensure the score is within the range [0, 10]
        score = Math.Min(10, Math.Max(0, score))

        Dim strength As String = CategorizeStrength(score)

        

        ' Display the password strength
        Label1.Text = "Password Strength: " & strength


    End Sub

    ' Function to check if the password is present in the Common-Password File
    Private Function CheckCommonSequences(ByVal password As String) As Boolean

        Dim commonPasswordsFilePath As String = "D:\College\Sem 6\Cs-346 SWE Lab\Assign2\CS346\Assignment-2\Library_Management_System\Library_Management_System\Common-Password.txt"
        'Dim commonPasswordsFilePath As String = "Common-Password.txt"

        Try
            Using commonPasswordsFile As New StreamReader(commonPasswordsFilePath)
                'Dim commonPassword As String
                Dim commonPassword As String = String.Empty
                While (InlineAssignHelper(commonPassword, commonPasswordsFile.ReadLine())) IsNot Nothing
                    If password = commonPassword Then
                        ' Password matches exactly with a common password
                        Return True
                    End If
                End While
            End Using
        Catch ex As IOException
            ' Handle file IO exception
            Console.WriteLine("Error: Common Password File cannot be read.")
        End Try

        ' Password does not match any common password
        Return False

    End Function

    ' Helper function to simulate C++ inline assignment
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    ' Function to categorize the password based on score
    Private Function CategorizeStrength(ByVal score As Integer) As String
        If score <= 2 Then
            Return "Very weak"
        ElseIf score <= 4 Then
            Return "Weak"
        ElseIf score <= 6 Then
            Return "Moderate"
        ElseIf score <= 8 Then
            Return "Strong"
        Else
            Return "Very strong"
        End If
    End Function


    'Function to calculate score of the password
    Private Function CalculateScore(ByVal password As String) As Integer
        Dim score As Integer = 0
        Dim uniqueChars As New HashSet(Of Char)()
        Dim has_upper As Integer = 0
        Dim has_specialchar As Integer = 0
        Dim has_num As Integer = 0

        ' Check length
        Dim length As Integer = password.Length
        score += (length - 1) \ 3

        ' Check for special characters, capital letters, numeric digits
        For Each ch As Char In password
            If Char.IsPunctuation(ch) AndAlso Not uniqueChars.Contains(ch) Then
                has_specialchar += 1
                uniqueChars.Add(ch)
            ElseIf Char.IsUpper(ch) AndAlso Not uniqueChars.Contains(ch) Then
                has_upper += 1
                uniqueChars.Add(ch)
            ElseIf Char.IsDigit(ch) AndAlso Not uniqueChars.Contains(ch) Then
                has_num += 1
                uniqueChars.Add(ch)
            End If
        Next

        ' Additional scoring based on the count of special characters, capital letters, and numeric digits
        score += Math.Min(3, has_specialchar)
        score += Math.Min(3, has_num)
        score += Math.Min(3, has_upper)

        Return score
    End Function

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class
