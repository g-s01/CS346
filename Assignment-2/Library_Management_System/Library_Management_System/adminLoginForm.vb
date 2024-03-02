Imports MySql.Data.MySqlClient

Public Class adminLoginForm
    ' Publicly shared variables between forms
    Public Shared ID As String
    Dim MySQLConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Password.Text <> "" Then
            Password.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Password_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Password.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If Password.Text = "Enter admin password here" Then
            Password.Text = ""
            Password.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub Password_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Password.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If Password.Text = "" Then
            Password.Text = "Enter admin password here"
            Password.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Private Sub SubminButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubminButton.Click
        'Dim newForm As New adminPage()
        'newForm.Show()
        'Me.Dispose()

        MySQLConn = New MySqlConnection
        MySQLConn.ConnectionString = "server=127.0.0.1;userid=root;database=LMS;pwd=;"
        Dim READER As MySqlDataReader

        Try
            'connection.Open()
            MySQLConn.Open()
            Dim Query As String
            Query = "SELECT * FROM admin where BINARY username='admin' and BINARY Password= '" & Password.Text & "'"
                COMMAND = New MySqlCommand(Query, MySQLConn)
                READER = COMMAND.ExecuteReader
                Dim count As Integer
                count = 0
                While READER.Read
                    count = count + 1
                End While
                If count = 1 Then
                Dim newForm As New adminPage()
                    newForm.Show()
                Me.Dispose()
                Else
                MessageBox.Show("Incorrect password!")
                    Return
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim newForm As New landingPage()
        newForm.Show()
        Me.Dispose()
    End Sub
End Class