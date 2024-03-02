Imports MySql.Data.MySqlClient
Imports System.Net.Mail

Public Class adminPage

    Dim connectionString As String = "server=localhost;user=root;database=LMS;pwd=;convert zero datetime=True"
    Dim MySQLConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Dim allBooks As New List(Of Entry)

    ' Define a structure to hold book details
    Structure Entry
        Public BookID As Integer
        Public Author As String
        Public Title As String
    End Structure

    Private Sub Dashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dashboard.Click
        Dashboard_panel.Visible = True
        Search_panel.Visible = False
        BookManagement_panel.Visible = False
        ManualTransactions_panel.Visible = False

        Dashboard.Font = New Font(Dashboard.Font, FontStyle.Bold)
        Search.Font = New Font(Search.Font, FontStyle.Regular)
        Book_management.Font = New Font(Book_management.Font, FontStyle.Regular)
        Manual_transactions.Font = New Font(Manual_transactions.Font, FontStyle.Regular)

    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        Dashboard_panel.Visible = False
        Search_panel.Visible = True
        BookManagement_panel.Visible = False
        ManualTransactions_panel.Visible = False

        Dashboard.Font = New Font(Dashboard.Font, FontStyle.Regular)
        Search.Font = New Font(Search.Font, FontStyle.Bold)
        Book_management.Font = New Font(Book_management.Font, FontStyle.Regular)
        Manual_transactions.Font = New Font(Manual_transactions.Font, FontStyle.Regular)
    End Sub

    Private Sub Book_management_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Book_management.Click
        Dashboard_panel.Visible = False
        Search_panel.Visible = False
        BookManagement_panel.Visible = True
        ManualTransactions_panel.Visible = False

        Dashboard.Font = New Font(Dashboard.Font, FontStyle.Regular)
        Search.Font = New Font(Search.Font, FontStyle.Regular)
        Book_management.Font = New Font(Book_management.Font, FontStyle.Bold)
        Manual_transactions.Font = New Font(Manual_transactions.Font, FontStyle.Regular)
    End Sub

    Private Sub Manual_transactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manual_transactions.Click
        Dashboard_panel.Visible = False
        Search_panel.Visible = False
        BookManagement_panel.Visible = False
        ManualTransactions_panel.Visible = True

        Dashboard.Font = New Font(Dashboard.Font, FontStyle.Regular)
        Search.Font = New Font(Search.Font, FontStyle.Regular)
        Book_management.Font = New Font(Book_management.Font, FontStyle.Regular)
        Manual_transactions.Font = New Font(Manual_transactions.Font, FontStyle.Bold)
    End Sub

    Private Sub Logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logout.Click
        Dim newForm As New landingPage()
        newForm.Show()
        Me.BackgroundImage.Dispose()
        Me.Dispose()
    End Sub


    Private Sub Current_date_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Current_date.TextChanged
        Dim thisDate As Date
        thisDate = Today
        Current_date.Text() = thisDate
    End Sub

    Private Sub Add_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_button.Click
        If BookID_tb.Text = "" Or BookName_tb.Text = "" Or Author_tb.Text = "" Or Publisher_tb.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Insert values in table
            '
            '

            ' After adding into tables, clear the inputs and show the msg box that it is saved...
            MsgBox("Book Added Successfully")
            BookID_tb.Text = ""
            BookName_tb.Text = ""
            Author_tb.Text = ""
            Publisher_tb.Text = ""
            Reserved_tb.Text = ""


        End If
    End Sub


    Private Sub Update_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_button.Click
        If BookID_tb.Text = "" Or BookName_tb.Text = "" Or Author_tb.Text = "" Or Publisher_tb.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Insert new values in table
            '
            '

            ' After adding new values into tables, clear the inputs and show the msg box that it is saved...
            MsgBox("Book Updated Successfully")
            BookID_tb.Text = ""
            BookName_tb.Text = ""
            Author_tb.Text = ""
            Publisher_tb.Text = ""
            Reserved_tb.Text = ""


        End If
    End Sub

    Private Sub Update_load_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_load_button.Click

        If Update_BookID_tb.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            ' Load the book info into the book_details label
            '
            ' after loading the data , clear the bookid input in update details label....
            Update_BookID_tb.Text = ""

        End If
    End Sub

    Private Sub Remove_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove_button.Click

        If Remove_BookID_tb.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Implement the remove logic using the input from the bookID input..
            '
            '
            '
            'After removing in from the database , clear the BookID input and also show the msgbox popup.
            Remove_BookID_tb.Text = ""
            MsgBox("Book Removed Successfully")
        End If



    End Sub




    Private Sub Issue_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Issue_button.Click
        If StudentID_tb.Text = "" Or BookID_tb2.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Issue the Book....to particular user....
            '
            '

            Dim isStudent As Boolean = False
            Dim isFaculty As Boolean = False
            Dim isReserved As Boolean = False

            ' Check whether user ID is valid
            Dim userQuery = "SELECT * FROM students where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isStudent = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            userQuery = "SELECT * FROM faculty where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isFaculty = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If isStudent = False And isFaculty = False Then
                MessageBox.Show("User with given id does not exist.")
                Return
            End If

            ' Check whether book ID is valid
            userQuery = "SELECT * FROM books where BINARY ID='" & BookID_tb2.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count = 0 Then
                            MessageBox.Show("Book with given ID does not exist.")
                            Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If isStudent = True Then
                userQuery = "SELECT * FROM books where (BINARY ID='" & BookID_tb2.Text & "' AND NOT isReserved)"
                Using connection As New MySqlConnection(connectionString)
                    Using command As New MySqlCommand(userQuery, connection)
                        Try
                            connection.Open()
                            Dim reader As MySqlDataReader = command.ExecuteReader()
                            Dim count As Integer
                            count = 0
                            While reader.Read
                                count = count + 1
                            End While
                            If count = 0 Then
                                MessageBox.Show("Book with given ID is reserved for faculty.")
                                Return
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
            End If

            ' Check whether book is already issued
            userQuery = "SELECT * FROM books where (BINARY ID='" & BookID_tb2.Text & "' AND NOT isIssued)"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count = 0 Then
                            MessageBox.Show("Book with given ID is already issued.")
                            Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using

            ' Issuing the book
            Dim quotaExceed As Integer = 0

            ' Check if issuing the book crosses issue limit
            userQuery = "SELECT * FROM borrowed_books WHERE issuedToID = '" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer = 0
                        While reader.Read()
                            count = count + 1
                        End While
                        If count = 7 Then
                            quotaExceed = 1
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If quotaExceed = 1 Then
                MessageBox.Show("Your quota to issue books is exhausted, return some books to issue new books.")
                Return
            Else
                'Dim currentDate As DateTime = DateTime.Now.Date
                Dim currentDate As DateTime = DateTimePicker3.Value
                Dim futureDate As DateTime = DateAdd("d", 7, currentDate)
                Dim updateQueryInBooks = "UPDATE books SET isIssued = '1', dueDate = '" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "', issuedTo = '" & StudentID_tb.Text & "', lastIssue = '" & currentDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & BookID_tb2.Text & "'"
                Dim updateQueryInBorrowed_Books = "INSERT INTO borrowed_books (BookID, issuedToID, issueDate, dueDate) VALUES ('" & BookID_tb2.Text & "', '" & StudentID_tb.Text & "', '" & currentDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "','" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                Using newConnection As New MySqlConnection(connectionString)
                    Using newCommand As New MySqlCommand(updateQueryInBooks, newConnection)
                        Try
                            newConnection.Open()
                            newCommand.ExecuteNonQuery()
                            MessageBox.Show("Your book with BookID: " + BookID_tb2.Text.ToString + " has been issued to " + StudentID_tb.Text + "till: " + futureDate.Date.ToString)
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
                Using newConnection As New MySqlConnection(connectionString)
                    Using newCommand As New MySqlCommand(updateQueryInBorrowed_Books, newConnection)
                        Try
                            newConnection.Open()
                            newCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
                Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & StudentID_tb.Text & " as issued the book with book ID " & BookID_tb2.Text & ", till " & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                Using newNewConnection As New MySqlConnection(connectionString)
                    Using newNewCommand As New MySqlCommand(addTransactionToAdmin, newNewConnection)
                        Try
                            newNewConnection.Open()
                            newNewCommand.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
                ' Populate the table with the borrowedBooks
                PopulateTable()
                MsgBox("Book Issued Successfully")
            End If

            ' After issuing the book, clear the inputs and show the msg box that it is issued....
            BookID_tb2.Text = ""
            addBalance_tb.Text = ""
            StudentID_tb.Text = ""
            Fine_tb.Text = ""

        End If
    End Sub

    Private Sub Return_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Return_button.Click
        If StudentID_tb.Text = "" Or BookID_tb2.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Implement the return function.....
            '
            '

            Dim isStudent As Boolean = False
            Dim isFaculty As Boolean = False

            ' Check whether user ID is valid
            Dim userQuery = "SELECT * FROM students where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isStudent = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            userQuery = "SELECT * FROM faculty where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isFaculty = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If isStudent = False And isFaculty = False Then
                MessageBox.Show("User with given id does not exist.")
                Return
            End If

            'Check whether the book is issued to the user
            userQuery = "SELECT * FROM borrowed_books WHERE (BookID = '" & BookID_tb2.Text & "' AND issuedToID = '" & StudentID_tb.Text & "')"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count = 0 Then
                            MessageBox.Show("This book is not issued to the user.")
                            Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using

            Dim query = "SELECT * FROM borrowed_books WHERE (BookID = '" & BookID_tb2.Text & "')"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim currentDate As DateTime = DateTimePicker1.Value
                        While reader.Read()
                            Dim updateQueryInBooks = "UPDATE books SET isIssued = 0, issuedTo = '', dueDate = '0000-00-00 00:00:00' WHERE ID = '" & BookID_tb2.Text & "'"
                            Dim updateQueryInBorrowed_Books = "DELETE FROM borrowed_books WHERE BookID = '" & BookID_tb2.Text & "'"
                            Using newConnection As New MySqlConnection(connectionString)
                                Using newCommand As New MySqlCommand(updateQueryInBooks, newConnection)
                                    Try
                                        newConnection.Open()
                                        newCommand.ExecuteNonQuery()
                                        If reader("dueDate") < currentDate Then
                                            Dim fine As Integer = DateDiff(DateInterval.Day, reader("dueDate"), currentDate)
                                            Dim fineUpdateQuery As String
                                            If isStudent Then
                                                fineUpdateQuery = "SELECT * FROM students WHERE ID = '" & StudentID_tb.Text & "'"
                                            Else
                                                fineUpdateQuery = "SELECT * FROM faculty WHERE ID = '" & StudentID_tb.Text & "'"
                                            End If
                                            Using newNewConnection As New MySqlConnection(connectionString)
                                                Using newNewCommand As New MySqlCommand(fineUpdateQuery, newNewConnection)
                                                    Try
                                                        newNewConnection.Open()
                                                        Dim newNewReader As MySqlDataReader = newNewCommand.ExecuteReader
                                                        While newNewReader.Read()
                                                            Dim value As Integer
                                                            Integer.TryParse(newNewReader("Fine").ToString, value)
                                                            fine = fine + value
                                                        End While
                                                    Catch ex As Exception
                                                        MessageBox.Show("Error: " & ex.Message)
                                                    End Try
                                                End Using
                                            End Using
                                            If isStudent Then
                                                fineUpdateQuery = "UPDATE students SET Fine = '" & fine & "' WHERE ID = '" & StudentID_tb.Text & "'"
                                            Else
                                                fineUpdateQuery = "UPDATE faculty SET Fine = '" & fine & "' WHERE ID = '" & StudentID_tb.Text & "'"
                                            End If
                                            Using newNewConnection As New MySqlConnection(connectionString)
                                                Using newNewCommand As New MySqlCommand(fineUpdateQuery, newNewConnection)
                                                    Try
                                                        newNewConnection.Open()
                                                        newNewCommand.ExecuteNonQuery()
                                                        'MessageBox.Show("Fine updated to " + fine.ToString)
                                                    Catch ex As Exception
                                                        MessageBox.Show("Error: " & ex.Message)
                                                    End Try
                                                End Using
                                            End Using
                                            Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & StudentID_tb.Text & " returned the book with book ID " & addBalance_tb.Text & ", and incurred a fine of " & fine.ToString & "')"
                                            Using newNewConnection As New MySqlConnection(connectionString)
                                                Using newNewCommand As New MySqlCommand(addTransactionToAdmin, newNewConnection)
                                                    Try
                                                        newNewConnection.Open()
                                                        newNewCommand.ExecuteNonQuery()
                                                    Catch ex As Exception
                                                        MessageBox.Show("Error: " & ex.Message)
                                                    End Try
                                                End Using
                                            End Using
                                            MessageBox.Show("Since you are returning the book late, some fine has been added to your account. New fine is " + fine.ToString)
                                        Else
                                            Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & StudentID_tb.Text & " returned the book with book ID " & BookID_tb2.Text & "')"
                                            Using newNewConnection As New MySqlConnection(connectionString)
                                                Using newNewCommand As New MySqlCommand(addTransactionToAdmin, newNewConnection)
                                                    Try
                                                        newNewConnection.Open()
                                                        newNewCommand.ExecuteNonQuery()
                                                    Catch ex As Exception
                                                        MessageBox.Show("Error: " & ex.Message)
                                                    End Try
                                                End Using
                                            End Using
                                        End If
                                        MessageBox.Show("Your book with BookID: " + BookID_tb2.Text.ToString + " has been returned to the library.")
                                    Catch ex As Exception
                                        MessageBox.Show("Error: " & ex.Message)
                                    End Try
                                End Using
                            End Using
                            Using newConnection As New MySqlConnection(connectionString)
                                Using newCommand As New MySqlCommand(updateQueryInBorrowed_Books, newConnection)
                                    Try
                                        newConnection.Open()
                                        newCommand.ExecuteNonQuery()
                                    Catch ex As Exception
                                        MessageBox.Show("Error: " & ex.Message)
                                    End Try
                                End Using
                            End Using
                        End While
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            ' Populate the table with the borrowedBooks
            PopulateTable()

            ' After returning the book, clear the inputs and show the msg box that it is Returned....
            MsgBox("Book Returned Successfully")
            BookID_tb2.Text = ""
            addBalance_tb.Text = ""
            StudentID_tb.Text = ""
            Fine_tb.Text = ""
        End If
    End Sub

    Private Sub Pay_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pay_button.Click
        If StudentID_tb.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            Dim isStudent As Boolean = False
            Dim isFaculty As Boolean = False

            ' Check whether user ID is valid
            Dim userQuery = "SELECT * FROM students where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isStudent = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            userQuery = "SELECT * FROM faculty where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isFaculty = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If isStudent = False And isFaculty = False Then
                MessageBox.Show("User with given id does not exist.")
                Return
            End If

            Dim iFine As Integer
            Dim successful As Boolean
            successful = False

            ' Create and show the input prompt form
            Dim inputPromptForm As New InputPromptForm()
            If inputPromptForm.ShowDialog() = DialogResult.OK Then
                ' Retrieve the input value
                If Integer.TryParse(inputPromptForm.InputValue, iFine) Then
                    ' Input value is valid
                Else
                    ' Input value is not a valid integer
                    MessageBox.Show("Invalid input. Please enter a valid integer.")
                End If
            End If

            Dim searchQuery As String
            If isStudent = True Then
                searchQuery = "SELECT * FROM students WHERE ID = '" & StudentID_tb.Text & "'"
            Else
                searchQuery = "SELECT * FROM faculty WHERE ID = '" & StudentID_tb.Text & "'"
            End If
            Using newConnection As New MySqlConnection(connectionString)
                Using newCommand As New MySqlCommand(searchQuery, newConnection)
                    Try
                        newConnection.Open()
                        Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                        Dim fine As Integer
                        Dim balance As Integer
                        While newReader.Read()
                            fine = newReader("Fine")
                            balance = newReader("Balance")
                        End While

                        ' Close the DataReader before executing UPDATE queries
                        newReader.Close()
                        If iFine <= 0 Then
                            MessageBox.Show("Enter a positive integer!")
                        ElseIf iFine > fine Then
                            MessageBox.Show("Don't pay more than the fine!.")
                        ElseIf iFine > balance Then
                            MessageBox.Show("Insufficient Balance!.")
                        Else
                            fine = fine - iFine
                            balance = balance - iFine
                            successful = True
                        End If

                        Dim fineUpdateQuery As String
                        Dim balanceUpdateQuery As String
                        If isStudent = True Then
                            fineUpdateQuery = "UPDATE students SET Fine = '" & fine & "' WHERE ID = '" & StudentID_tb.Text & "'"
                            balanceUpdateQuery = "UPDATE students SET Balance = '" & balance & "' WHERE ID = '" & StudentID_tb.Text & "'"
                        Else
                            fineUpdateQuery = "UPDATE faculty SET Fine = '" & fine & "' WHERE ID = '" & StudentID_tb.Text & "'"
                            balanceUpdateQuery = "UPDATE faculty SET Balance = '" & balance & "' WHERE ID = '" & StudentID_tb.Text & "'"
                        End If

                        Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & StudentID_tb.Text & " as paid a fine of Rs. " & iFine.ToString & "')"

                        ' Execute the UPDATE queries
                        Using fineUpdateCommand As New MySqlCommand(fineUpdateQuery, newConnection)
                            fineUpdateCommand.ExecuteNonQuery()
                        End Using

                        Using balanceUpdateCommand As New MySqlCommand(balanceUpdateQuery, newConnection)
                            balanceUpdateCommand.ExecuteNonQuery()
                        End Using

                        Using addTransactionToAdminCommand As New MySqlCommand(addTransactionToAdmin, newConnection)
                            addTransactionToAdminCommand.ExecuteNonQuery()
                        End Using


                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If successful Then
                MessageBox.Show("Fine payment of Rs." + iFine.ToString + " successful!")
            End If

            ' After paying the fine, clear the inputs and show the msg box that it is Returned....
            BookID_tb2.Text = ""
            addBalance_tb.Text = ""
            StudentID_tb.Text = ""
            Fine_tb.Text = ""
        End If

    End Sub

    Private Sub Renew_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Renew_button.Click
        If StudentID_tb.Text = "" Or BookID_tb2.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Implement the renew function.....
            'Fine_tb.Text = "20" ' just for checking the working of pay button.....
            '

            'Check whether the book is issued to the user
            Dim userQuery = "SELECT * FROM borrowed_books WHERE (BookID = '" & BookID_tb2.Text & "' AND issuedToID = '" & StudentID_tb.Text & "')"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count = 0 Then
                            MessageBox.Show("This book is not issued to the user.")
                            Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using

            Dim query = "SELECT * FROM borrowed_books WHERE (BookID = '" & BookID_tb2.Text & "')"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(query, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim currentDate As DateTime = DateTimePicker2.Value
                        Dim futureDate As DateTime = DateAdd("d", 14, currentDate)
                        While reader.Read()
                            If reader("dueDate") < currentDate Then
                                MessageBox.Show("Book can't be renewed as it is past it's due date. Please pay fine and re-issue.")
                                Return
                            Else
                                Dim updateQueryInBooks = "UPDATE books SET dueDate = '" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & BookID_tb2.Text & "'"
                                Dim updateQueryInBorrowed_Books = "UPDATE borrowed_books SET dueDate = '" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE BookID = '" & BookID_tb2.Text & "'"

                                Using newConnection As New MySqlConnection(connectionString)
                                    Using newCommand As New MySqlCommand(updateQueryInBooks, newConnection)
                                        Try
                                            newConnection.Open()
                                            newCommand.ExecuteNonQuery()
                                        Catch ex As Exception
                                            MessageBox.Show("Error: " & ex.Message)
                                        End Try
                                    End Using
                                End Using
                                Using newConnection As New MySqlConnection(connectionString)
                                    Using newCommand As New MySqlCommand(updateQueryInBorrowed_Books, newConnection)
                                        Try
                                            newConnection.Open()
                                            newCommand.ExecuteNonQuery()
                                        Catch ex As Exception
                                            MessageBox.Show("Error: " & ex.Message)
                                        End Try
                                    End Using
                                End Using
                                Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & StudentID_tb.Text & " renewed the book with book ID " & BookID_tb2.Text & " till " & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                                Using newConnection As New MySqlConnection(connectionString)
                                    Using newCommand As New MySqlCommand(addTransactionToAdmin, newConnection)
                                        Try
                                            newConnection.Open()
                                            newCommand.ExecuteNonQuery()
                                        Catch ex As Exception
                                            MessageBox.Show("Error: " & ex.Message)
                                        End Try
                                    End Using
                                End Using
                                MessageBox.Show("You have successfully renewed the book with book ID " + BookID_tb2.Text.ToString + " till " & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss"))

                            End If
                        End While
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            ' Populate the table with the borrowedBooks
            PopulateTable()


            ' After renewing the book, clear the inputs and show the msg box that it is Renewed....
            MsgBox("Book Renewed Successfully")
            BookID_tb2.Text = ""
            addBalance_tb.Text = ""
            StudentID_tb.Text = ""
            Fine_tb.Text = ""

        End If
    End Sub

    Private Sub adminPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dashboard_panel.Visible = True
        Dashboard_panel.Visible = True
        Search_panel.Visible = False
        BookManagement_panel.Visible = False
        ManualTransactions_panel.Visible = False

        allBooks.Add(New Entry With {.BookID = 1, .Author = "Author1", .Title = "Title1"})
        allBooks.Add(New Entry With {.BookID = 2, .Author = "Author2", .Title = "Title2"})
        allBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3"})
        allBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3"})
        allBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3"})
        allBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3"})
        allBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3"})

        ' Populate the table with the borrowedBooks
        PopulateTable()
    End Sub

    Private Sub PopulateTable()

        ' Add allBooks to the table
        For rowIndex As Integer = 0 To allBooks.Count - 1
            Dim entry As Entry = allBooks(rowIndex)

            ' Add book details
            Dim bookIdLabel As New Label()
            bookIdLabel.Text = entry.BookID.ToString()
            allBooksTablePanel.Controls.Add(bookIdLabel, 0, rowIndex)
            bookIdLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            bookIdLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim authorLabel As New Label()
            authorLabel.Text = entry.Author
            allBooksTablePanel.Controls.Add(authorLabel, 1, rowIndex)
            authorLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            authorLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim titleLabel As New Label()
            titleLabel.Text = entry.Title
            allBooksTablePanel.Controls.Add(titleLabel, 2, rowIndex)
            titleLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            titleLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim issueStatusLabel As New Label()
            issueStatusLabel.Text = entry.Title
            allBooksTablePanel.Controls.Add(issueStatusLabel, 3, rowIndex)
            issueStatusLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            issueStatusLabel.Anchor = AnchorStyles.None ' Set Anchor to None

        Next

        Dim adjustLabel3 As New Label()
        adjustLabel3.Text = ""
        allBooksTablePanel.Controls.Add(adjustLabel3, 1, allBooks.Count)

    End Sub

    Private Sub loadFineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadFineButton.Click
        If StudentID_tb.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            Dim isStudent As Boolean = False
            Dim isFaculty As Boolean = False

            ' Check whether user ID is valid
            Dim userQuery = "SELECT * FROM students where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isStudent = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            userQuery = "SELECT * FROM faculty where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isFaculty = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If isStudent = False And isFaculty = False Then
                MessageBox.Show("User with given id does not exist.")
                Return
            End If

            Dim searchQuery As String
            If isStudent = True Then
                searchQuery = "SELECT * FROM students WHERE ID = '" & StudentID_tb.Text & "'"
            Else
                searchQuery = "SELECT * FROM faculty WHERE ID = '" & StudentID_tb.Text & "'"
            End If
            Using newConnection As New MySqlConnection(connectionString)
                Using newCommand As New MySqlCommand(searchQuery, newConnection)
                    Try
                        newConnection.Open()
                        Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                        Dim fine As Integer
                        While newReader.Read()
                            fine = newReader("Fine")
                        End While

                        Fine_tb.Text = fine

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub addBalanceButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addBalanceButton.Click
        If StudentID_tb.Text = "" Or addBalance_tb.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            Dim isStudent As Boolean = False
            Dim isFaculty As Boolean = False

            ' Check whether user ID is valid
            Dim userQuery = "SELECT * FROM students where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isStudent = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            userQuery = "SELECT * FROM faculty where BINARY ID='" & StudentID_tb.Text & "'"
            Using connection As New MySqlConnection(connectionString)
                Using command As New MySqlCommand(userQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer
                        count = 0
                        While reader.Read
                            count = count + 1
                        End While
                        If count > 0 Then
                            isFaculty = True
                            'MessageBox.Show("student with given id does not exist.")
                            'Return
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If isStudent = False And isFaculty = False Then
                MessageBox.Show("User with given id does not exist.")
                Return
            End If

            Dim searchQuery As String
            Dim successful As Boolean
            successful = False
            If isStudent = True Then
                searchQuery = "SELECT * FROM students WHERE ID = '" & StudentID_tb.Text & "'"
            Else
                searchQuery = "SELECT * FROM faculty WHERE ID = '" & StudentID_tb.Text & "'"
            End If
            Using newConnection As New MySqlConnection(connectionString)
                Using newCommand As New MySqlCommand(searchQuery, newConnection)
                    Try
                        newConnection.Open()
                        Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                        Dim balance As Integer
                        While newReader.Read()
                            balance = newReader("Balance")
                        End While

                        newReader.Close()

                        If Convert.ToInt32(addBalance_tb.Text) <= 0 Then
                            MessageBox.Show("Add positive amount.")
                            Return
                        ElseIf balance + Convert.ToInt32(addBalance_tb.Text) > 1000 Then
                            MessageBox.Show("You can't have more than Rs. 1000 in your account.")
                            Return
                        Else
                            balance = balance + Convert.ToInt32(addBalance_tb.Text)
                            successful = True
                        End If

                        Dim balanceUpdateQuery As String
                        If isStudent = True Then
                            balanceUpdateQuery = "UPDATE students SET Balance = '" & balance & "' WHERE ID = '" & StudentID_tb.Text & "'"
                        Else
                            balanceUpdateQuery = "UPDATE faculty SET Balance = '" & balance & "' WHERE ID = '" & StudentID_tb.Text & "'"
                        End If

                        Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & StudentID_tb.Text & " as updated is balance to Rs. " & balance.ToString & "')"

                        Using balanceUpdateCommand As New MySqlCommand(balanceUpdateQuery, newConnection)
                            balanceUpdateCommand.ExecuteNonQuery()
                        End Using

                        Using addTransactionToAdminCommand As New MySqlCommand(addTransactionToAdmin, newConnection)
                            addTransactionToAdminCommand.ExecuteNonQuery()
                        End Using
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
            If successful Then
                MessageBox.Show(addBalance_tb.Text + " successfully added to balance!")
            End If
        End If
        addBalance_tb.Text = ""
    End Sub
End Class