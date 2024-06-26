﻿Imports MySql.Data.MySqlClient
Imports System.Net.Mail

Public Class studentPage
    Dim connectionString As String = "server=localhost;user=root;database=LMS;pwd=;convert zero datetime=True"
    Dim connection As MySqlConnection
    ' Define a global array to store borrowedBooks
    Dim borrowedBooks As New List(Of Entry)
    ' Define a global array to store overdueBooks
    Dim overdueBooks As New List(Of Entry)
    ' Define a global array to store all unborrowed books
    Dim allBooks As New List(Of Entry)
    ' Define a global identifiers of the user
    Dim ID As String = loginPage.ID
    Dim studentOrFaculty = loginPage.studentOrFaculty
    ' to see through which mode does the user wants to search books
    Dim selectedSearchMode As String = "Empty"
    ' maximum number of books a student can issue
    Dim maxIssue = 7
    ' Define a structure to hold book details
    Structure Entry
        Public BookID As Integer
        Public Author As String
        Public Title As String
        Public DueDate As String
        Public RadioButton As RadioButton ' Added RadioButton field
    End Structure

    Private Sub studentPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dashboard_panel.Visible = True
        Search_panel.Visible = False
        BookManagement_panel.Visible = False
        Label12.Text = "Hello, " & ID
        ' function to load the borrowed books of a user
        LoadBorrowedBooks()
        ' function to load all the overdue books of a user
        LoadOverdueBooks()
        ' function to load all the un-borrowed books
        LoadAllBooks()
        ' Populate the table with the borrowedBooks
        PopulateTable()
        Panel6.Visible = False
        Panel7.Visible = False
        LinkLabel1.Visible = False
        Label15.Visible = False
        Label16.Visible = False
        Label14.Visible = False
        TextBox2.Visible = False
        Button3.Visible = False
    End Sub

    Private Sub PopulateTable()
        UpdateFine()
        UpdateBalance()
        borrowedBooksTablePanel.Controls.Clear()
        overdueBooksTablePanel.Controls.Clear()
        allBooksTablePanel.Controls.Clear()


        ' Add borrowedBooks to the table
        For rowIndex As Integer = 0 To borrowedBooks.Count - 1
            Dim entry As Entry = borrowedBooks(rowIndex)
            ' Add book details
            Dim bookIdLabel As New Label()
            bookIdLabel.Text = entry.BookID.ToString()
            borrowedBooksTablePanel.Controls.Add(bookIdLabel, 0, rowIndex)
            bookIdLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            bookIdLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim authorLabel As New Label()
            authorLabel.Text = entry.Author
            borrowedBooksTablePanel.Controls.Add(authorLabel, 1, rowIndex)
            authorLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            authorLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim titleLabel As New Label()
            titleLabel.Text = entry.Title
            titleLabel.AutoSize = True
            borrowedBooksTablePanel.Controls.Add(titleLabel, 2, rowIndex)
            titleLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            titleLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim dueDateLabel As New Label()
            dueDateLabel.Text = entry.DueDate
            borrowedBooksTablePanel.Controls.Add(dueDateLabel, 3, rowIndex)
            dueDateLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            dueDateLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            ' Add radio button for options
            borrowedBooksTablePanel.Controls.Add(entry.RadioButton, 4, rowIndex)
            entry.RadioButton.TextAlign = ContentAlignment.MiddleCenter ' Center the radio button
            entry.RadioButton.Anchor = AnchorStyles.None ' Set Anchor to None
            entry.RadioButton.Size = New Size(16, 16) ' Set the size of the radio button

        Next

        Dim adjustLabel As New Label()
        adjustLabel.Text = ""
        borrowedBooksTablePanel.Controls.Add(adjustLabel, 1, borrowedBooks.Count)



        ' Add overdueBooks to the table
        For rowIndex As Integer = 0 To overdueBooks.Count - 1
            Dim entry As Entry = overdueBooks(rowIndex)

            ' Add book details
            Dim bookIdLabel As New Label()
            bookIdLabel.Text = entry.BookID.ToString()
            overdueBooksTablePanel.Controls.Add(bookIdLabel, 0, rowIndex)
            bookIdLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            bookIdLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim authorLabel As New Label()
            authorLabel.Text = entry.Author
            overdueBooksTablePanel.Controls.Add(authorLabel, 1, rowIndex)
            authorLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            authorLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim titleLabel As New Label()
            titleLabel.Text = entry.Title
            overdueBooksTablePanel.Controls.Add(titleLabel, 2, rowIndex)
            titleLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            titleLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim dueDateLabel As New Label()
            dueDateLabel.Text = entry.DueDate
            overdueBooksTablePanel.Controls.Add(dueDateLabel, 3, rowIndex)
            dueDateLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            dueDateLabel.Anchor = AnchorStyles.None ' Set Anchor to None

        Next

        Dim adjustLabel2 As New Label()
        adjustLabel2.Text = ""
        overdueBooksTablePanel.Controls.Add(adjustLabel2, 1, overdueBooks.Count)



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

            ' Add radio button for options
            allBooksTablePanel.Controls.Add(allBooks(rowIndex).RadioButton, 3, rowIndex)
            entry.RadioButton.TextAlign = ContentAlignment.MiddleCenter ' center the radio button
            entry.RadioButton.Anchor = AnchorStyles.None ' set anchor to none
            entry.RadioButton.Size = New Size(16, 16) ' set the size of the radio button

        Next

        Dim adjustLabel3 As New Label()
        adjustLabel3.Text = ""
        allBooksTablePanel.Controls.Add(adjustLabel3, 1, allBooks.Count + 1)

    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If TextBox1.Text = "Enter book ID here" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If TextBox1.Text = "" Then
            TextBox1.Text = "Enter book ID here"
            TextBox1.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    ' button to renew books
    ' author: g-s01 & sarg19
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenewButton.Click
        For Each entry As Entry In borrowedBooks
            If entry.RadioButton.Checked Then
                Dim query = "SELECT * FROM borrowed_books WHERE (BookID = '" & entry.BookID & "')"
                Using connection As New MySqlConnection(connectionString)
                    Using command As New MySqlCommand(query, connection)
                        Try
                            connection.Open()
                            Dim reader As MySqlDataReader = command.ExecuteReader()
                            Dim currentDate As DateTime = DateTime.Now.Date
                            Dim futureDate As DateTime = DateAdd("d", 14, currentDate)
                            While reader.Read()
                                If reader("dueDate") < currentDate Then
                                    MessageBox.Show("Book can't be renewed as it is past it's due date. Please pay fine and re-issue.")
                                    Return
                                Else
                                    Dim updateQueryInBooks = "UPDATE books SET dueDate = '" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & entry.BookID & "'"
                                    Dim updateQueryInBorrowed_Books = "UPDATE borrowed_books SET dueDate = '" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE BookID = '" & entry.BookID & "'"
                                    Dim authForm As New auth()
                                    Dim random As New Random()
                                    Dim randomNumber As Integer = random.Next(100000, 999999)
                                    Dim code As Integer
                                    sendEmail(randomNumber, "OTP for Book Renewal", "It seems you are trying to renew a book with book ID " + entry.BookID.ToString)
                                    If authForm.ShowDialog() = DialogResult.OK Then
                                        If Integer.TryParse(authForm.InputValue, code) Then
                                            If code = randomNumber Then
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
                                                Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & ID & " renewed the book with book ID " & entry.BookID & " till " & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "')"
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
                                                MessageBox.Show("You have successfully renewed the book with book ID " + entry.BookID.ToString + " till " & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss"))
                                            Else
                                                MessageBox.Show("Wrong OTP")
                                            End If
                                        Else
                                            MessageBox.Show("Please enter valid OTP")
                                        End If
                                    End If
                                End If
                            End While
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Using
                End Using
                ' function to load the borrowed books of a user
                LoadBorrowedBooks()
                ' function to load all the overdue books of a user
                LoadOverdueBooks()
                ' function to load all the un-borrowed books
                LoadAllBooks()
                ' Populate the table with the borrowedBooks
                PopulateTable()
                Return
            End If
        Next
        MessageBox.Show("No book selected.")
    End Sub

    ' function to return book
    ' author: g-s01 & sarg19
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
        For Each entry As Entry In borrowedBooks
            If entry.RadioButton.Checked Then
                Dim query = "SELECT * FROM borrowed_books WHERE (BookID = '" & entry.BookID & "')"
                Using connection As New MySqlConnection(connectionString)
                    Using command As New MySqlCommand(query, connection)
                        Try
                            connection.Open()
                            Dim reader As MySqlDataReader = command.ExecuteReader()
                            Dim currentDate As DateTime = DateTime.Now.Date
                            While reader.Read()
                                Dim updateQueryInBooks = "UPDATE books SET isIssued = 0, issuedTo = '', dueDate = '0000-00-00 00:00:00' WHERE ID = '" & entry.BookID & "'"
                                Dim updateQueryInBorrowed_Books = "DELETE FROM borrowed_books WHERE BookID = '" & entry.BookID & "'"
                                Using newConnection As New MySqlConnection(connectionString)
                                    Using newCommand As New MySqlCommand(updateQueryInBooks, newConnection)
                                        Try
                                            newConnection.Open()
                                            newCommand.ExecuteNonQuery()
                                            If reader("dueDate") < currentDate Then
                                                Dim fine As Integer = DateDiff(DateInterval.Day, reader("dueDate"), currentDate)
                                                Dim fineUpdateQuery = "SELECT * FROM students WHERE ID = '" & ID.ToString & "'"
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
                                                fineUpdateQuery = "UPDATE students SET Fine = '" & fine & "' WHERE ID = '" & ID.ToString & "'"
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
                                                Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & ID & " returned the book with book ID " & entry.BookID & ", and incurred a fine of " & fine.ToString & "')"
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
                                                Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & ID & " returned the book with book ID " & entry.BookID & "')"
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
                                            MessageBox.Show("Your book with BookID: " + entry.BookID.ToString + " has been returned to the library.")
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
                ' function to load the borrowed books of a user
                LoadBorrowedBooks()
                ' function to load all the overdue books of a user
                LoadOverdueBooks()
                ' function to load all the un-borrowed books
                LoadAllBooks()
                ' Populate the table with the borrowedBooks
                PopulateTable()
                Return
                Exit Sub
            End If
        Next
        MessageBox.Show("No book selected.")
    End Sub

    Private Sub DashboardButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DashboardButton.Click
        Dashboard_panel.Visible = True
        Search_panel.Visible = False
        BookManagement_panel.Visible = False

        DashboardButton.Font = New Font(DashboardButton.Font, FontStyle.Bold)
        SearchButton.Font = New Font(SearchButton.Font, FontStyle.Regular)
        BookMgmtButton.Font = New Font(BookMgmtButton.Font, FontStyle.Regular)

    End Sub

    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Dashboard_panel.Visible = False
        Search_panel.Visible = True
        BookManagement_panel.Visible = False

        DashboardButton.Font = New Font(DashboardButton.Font, FontStyle.Regular)
        SearchButton.Font = New Font(SearchButton.Font, FontStyle.Bold)
        BookMgmtButton.Font = New Font(BookMgmtButton.Font, FontStyle.Regular)
    End Sub

    Private Sub BookMgmtButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookMgmtButton.Click
        Dashboard_panel.Visible = False
        Search_panel.Visible = False
        BookManagement_panel.Visible = True

        DashboardButton.Font = New Font(DashboardButton.Font, FontStyle.Regular)
        SearchButton.Font = New Font(SearchButton.Font, FontStyle.Regular)
        BookMgmtButton.Font = New Font(BookMgmtButton.Font, FontStyle.Bold)
    End Sub

    Private Sub LogoutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutButton.Click
        Dim newForm As New landingPage()
        newForm.Show()
        Me.BackgroundImage.Dispose()
        Me.Dispose()
    End Sub

    ' Backend function for loading the borrowed books of a user
    ' Author: g-s01
    Private Sub LoadBorrowedBooks()
        borrowedBooks.Clear()
        Dim query As String = "SELECT * FROM borrowed_books WHERE (issuedToID = '" & ID & "')"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim bookQuery = "SELECT * FROM books WHERE ID = '" & reader("BookID").ToString() & "'"
                        Using newConnection As New MySqlConnection(connectionString)
                            Using newCommand As New MySqlCommand(bookQuery, newConnection)
                                Try
                                    newConnection.Open()
                                    Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                                    While newReader.Read()
                                        borrowedBooks.Add(New Entry With {.BookID = reader("BookID").ToString(), .Author = newReader("authorName").ToString, .Title = newReader("Title").ToString, .DueDate = reader("dueDate").ToString(), .RadioButton = New RadioButton()})
                                    End While
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
    End Sub

    ' Backend function for loading the overdue books of a user
    ' Author: g-s01
    Private Sub LoadOverdueBooks()
        overdueBooks.Clear()
        Dim query As String = "SELECT *, DATEDIFF(CURRENT_DATE, dueDate) AS daysPassed FROM borrowed_books WHERE (issuedToID = '" & ID & "' AND dueDate < CURRENT_DATE)"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim bookQuery = "SELECT * FROM books WHERE ID = '" & reader("BookID").ToString() & "'"
                        Using newConnection As New MySqlConnection(connectionString)
                            Using newCommand As New MySqlCommand(bookQuery, newConnection)
                                Try
                                    newConnection.Open()
                                    Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                                    While newReader.Read()
                                        overdueBooks.Add(New Entry With {.BookID = reader("BookID").ToString(), .Author = newReader("authorName").ToString, .Title = newReader("Title").ToString, .DueDate = reader("dueDate").ToString(), .RadioButton = New RadioButton()})
                                    End While
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
    End Sub

    ' Backend function for loading the all un-borrowed books in the system 
    ' Author: g-s01
    Private Sub LoadAllBooks()
        allBooks.Clear()
        Dim bookQuery = "SELECT * FROM books WHERE (NOT isIssued AND NOT isReserved)"
        Using newConnection As New MySqlConnection(connectionString)
            Using newCommand As New MySqlCommand(bookQuery, newConnection)
                Try
                    newConnection.Open()
                    Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                    While newReader.Read()
                        allBooks.Add(New Entry With {.BookID = newReader("ID").ToString(), .Author = newReader("authorName").ToString, .Title = newReader("Title").ToString, .RadioButton = New RadioButton()})
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    ' Backend function for showing the updated fine
    ' Author: g-s01
    Private Sub UpdateFine()
        Dim fineUpdateQuery = "SELECT * FROM students WHERE ID = '" & ID & "'"
        Using newConnection As New MySqlConnection(connectionString)
            Using newCommand As New MySqlCommand(fineUpdateQuery, newConnection)
                Try
                    newConnection.Open()
                    Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                    While newReader.Read()
                        Label9.Text = "Rs. " + newReader("Fine").ToString
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub


    ' Backend function for showing the updated balance
    ' Author: g-s01
    Private Sub UpdateBalance()
        Dim balanceUpdateQuery = "SELECT * FROM students WHERE ID = '" & ID & "'"
        Using newConnection As New MySqlConnection(connectionString)
            Using newCommand As New MySqlCommand(balanceUpdateQuery, newConnection)
                Try
                    newConnection.Open()
                    Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                    While newReader.Read()
                        Label13.Text = "Rs. " + newReader("Balance").ToString
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    ' Backend function for paying fine
    ' Author: g-s01
    Dim otp As Integer
    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
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

        Dim fineCollected As Integer
        Dim fineQuery = "SELECT * FROM admin WHERE username = 'admin'"

        Using newConnection As New MySqlConnection(connectionString)
            Using newCommand As New MySqlCommand(fineQuery, newConnection)
                Try
                    newConnection.Open()
                    Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                    While newReader.Read()
                        fineCollected = newReader("fineCollected")
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Dim searchQuery = "SELECT * FROM students WHERE ID = '" & ID & "'"
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
                        fineCollected = fineCollected + iFine
                        successful = True
                    End If
                    

                    Dim fineUpdateQuery = "UPDATE students SET Fine = '" & fine & "' WHERE ID = '" & ID & "'"
                    Dim balanceUpdateQuery = "UPDATE students SET Balance = '" & balance & "' WHERE ID = '" & ID & "'"
                    Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & ID & " has paid a fine of Rs. " & iFine.ToString & "')"
                    Dim updateFineCollected = "UPDATE admin SET fineCollected = '" & fineCollected & "' WHERE username = 'admin'"
                    
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

                    Using updateFineCollectedCommand As New MySqlCommand(updateFineCollected, newConnection)
                        updateFineCollectedCommand.ExecuteNonQuery()
                    End Using
                    
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(100000, 999999)
        otp = randomNumber
        sendOTPEmail(otp)
        Panel6.Visible = True
        Panel7.Visible = True
        LinkLabel1.Visible = True
        Label15.Visible = True
        Label16.Visible = True
        TextBox2.Visible = True
        Button3.Visible = True

        'If successful Then
        '    MessageBox.Show("Fine payment of Rs." + iFine.ToString + " successful!")
        'End If
    End Sub

    Private Sub sendOTPEmail(ByVal randomNumber As Integer)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("lms-cs346@outlook.com", ID)
        message.Subject = "Fine Payment confirmation"
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
    ' Backend function for selecting the search mode
    ' Author: g-s01
    Private Sub srchSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles srchSelect.SelectedIndexChanged
        selectedSearchMode = srchSelect.SelectedItem.ToString()
    End Sub

    ' Backend function for searching for a book
    ' Author: g-s01
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If selectedSearchMode = "Empty" Then
            MessageBox.Show("Select a search mode first")
            Return
        ElseIf selectedSearchMode = "Book ID" Then
            Dim bookQuery = "SELECT * FROM books WHERE (NOT isIssued AND NOT isReserved AND ID like '%" & queryBook.Text & "%')"
            Using newConnection As New MySqlConnection(connectionString)
                Using newCommand As New MySqlCommand(bookQuery, newConnection)
                    Try
                        newConnection.Open()
                        Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                        allBooks = New List(Of Entry)
                        While newReader.Read()
                            allBooks.Add(New Entry With {.BookID = newReader("ID").ToString(), .Author = newReader("authorName").ToString, .Title = newReader("Title").ToString, .RadioButton = New RadioButton()})
                        End While
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        ElseIf selectedSearchMode = "Author" Then
            'Dim bookQuery = "SELECT * FROM books WHERE (NOT isIssued AND NOT isReserved AND authorName = '" & queryBook.Text & "')"
            Dim bookQuery = "SELECT * FROM books WHERE (NOT isIssued AND NOT isReserved AND authorName like '%" & queryBook.Text & "%')"
            Using newConnection As New MySqlConnection(connectionString)
                Using newCommand As New MySqlCommand(bookQuery, newConnection)
                    Try
                        newConnection.Open()
                        Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                        allBooks = New List(Of Entry)
                        While newReader.Read()
                            allBooks.Add(New Entry With {.BookID = newReader("ID").ToString(), .Author = newReader("authorName").ToString, .Title = newReader("Title").ToString, .RadioButton = New RadioButton()})
                        End While
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        ElseIf selectedSearchMode = "Title" Then
            Dim bookQuery = "SELECT * FROM books WHERE (NOT isIssued AND NOT isReserved AND Title like '%" & queryBook.Text & "%')"
            Using newConnection As New MySqlConnection(connectionString)
                Using newCommand As New MySqlCommand(bookQuery, newConnection)
                    Try
                        newConnection.Open()
                        Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                        allBooks = New List(Of Entry)
                        While newReader.Read()
                            allBooks.Add(New Entry With {.BookID = newReader("ID").ToString(), .Author = newReader("authorName").ToString, .Title = newReader("Title").ToString, .RadioButton = New RadioButton()})
                        End While
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        ElseIf selectedSearchMode = "Category" Then
            Dim bookQuery = "SELECT * FROM books WHERE (NOT isIssued AND NOT isReserved AND Subject like '%" & queryBook.Text & "%')"
            Using newConnection As New MySqlConnection(connectionString)
                Using newCommand As New MySqlCommand(bookQuery, newConnection)
                    Try
                        newConnection.Open()
                        Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                        allBooks = New List(Of Entry)
                        While newReader.Read()
                            allBooks.Add(New Entry With {.BookID = newReader("ID").ToString(), .Author = newReader("authorName").ToString, .Title = newReader("Title").ToString, .RadioButton = New RadioButton()})
                        End While
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
        PopulateTable()
    End Sub

    ' backend function to issue a book
    ' author: g-s01
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each entry As Entry In allBooks
            If entry.RadioButton.Checked Then
                Dim quotaExceed As Integer = 0
                Dim userQuery = "SELECT * FROM borrowed_books WHERE issuedToID = '" & ID & "'"
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
                    Dim currentDate As DateTime = DateTime.Now.Date
                    Dim futureDate As DateTime = DateAdd("d", 7, currentDate)
                    Dim updateQueryInBooks = "UPDATE books SET isIssued = '1', dueDate = '" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "', issuedTo = '" & ID & "' WHERE ID = '" & entry.BookID & "'"
                    Dim updateQueryInBorrowed_Books = "INSERT INTO borrowed_books (BookID, issuedToID, issueDate, dueDate) VALUES ('" & entry.BookID & "', '" & ID & "', '" & currentDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "','" & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                    Using newConnection As New MySqlConnection(connectionString)
                        Using newCommand As New MySqlCommand(updateQueryInBooks, newConnection)
                            Try
                                newConnection.Open()
                                newCommand.ExecuteNonQuery()
                                MessageBox.Show("Your book with BookID: " + entry.BookID.ToString + " has been issued till: " + futureDate.Date.ToString)
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
                    Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & ID & " has issued the book with book ID " & entry.BookID & ", till " & futureDate.Date.ToString("yyyy-MM-dd HH:mm:ss") & "')"
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
                    ' function to load the borrowed books of a user
                    LoadBorrowedBooks()
                    ' function to load all the overdue books of a user
                    LoadOverdueBooks()
                    ' function to load all the un-borrowed books
                    LoadAllBooks()
                    ' Populate the table with the borrowedBooks
                    PopulateTable()
                End If
                Exit Sub
            End If
        Next
    End Sub

    Private Sub btnAddBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBalance.Click
        Dim addBlc As Integer
        Dim successful As Boolean
        successful = False
        ' Create and show the input prompt form
        Dim addBlcForm As New AddBalanceForm()
        If addBlcForm.ShowDialog() = DialogResult.OK Then
            ' Retrieve the input value
            If Integer.TryParse(addBlcForm.InputValue, addBlc) Then
                ' Input value is valid
                Dim searchQuery = "SELECT * FROM students WHERE ID = '" & ID & "'"
                Using newConnection As New MySqlConnection(connectionString)
                    Using newCommand As New MySqlCommand(searchQuery, newConnection)
                        Try
                            newConnection.Open()
                            Dim newReader As MySqlDataReader = newCommand.ExecuteReader
                            Dim balance As Integer
                            While newReader.Read()
                                balance = newReader("Balance")
                            End While
                            ' Close the DataReader before executing UPDATE queries
                            newReader.Close()
                            If addBlc <= 0 Then
                                MessageBox.Show("Enter a positive integer!")
                            ElseIf balance + addBlc > 1000 Then
                                MessageBox.Show("You can't have more than Rs. 1000 in your account.")
                            Else
                                balance = balance + addBlc
                                successful = True
                            End If

                            Dim balanceUpdateQuery = "UPDATE students SET Balance = '" & balance & "' WHERE ID = '" & ID & "'"
                            Dim addTransactionToAdmin = "INSERT INTO transactions (transaction) VALUES (' " & ID & " has updated is balance to Rs. " & balance.ToString & "')"

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
                    MessageBox.Show(addBlc.ToString + " successfully added to your balance!")
                End If
                UpdateBalance()
            Else
                ' Input value is not a valid integer
                MessageBox.Show("Invalid input. Please enter a valid integer.")
            End If
        End If
    End Sub

    Private Sub sendEmail(randomNumber As Integer, subject As String, body As String)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("lms-cs346@outlook.com", ID)
        message.Subject = subject
        message.Body = body & vbCrLf & "Your OTP is " + randomNumber.ToString

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox2.Text = otp.ToString Then
            Panel6.Visible = False
            Panel7.Visible = False
            LinkLabel1.Visible = False
            Label15.Visible = False
            Label16.Visible = False
            Label14.Visible = False
            TextBox2.Visible = False
            Button3.Visible = False
            MessageBox.Show("Fine payment successful!")
            UpdateBalance()
            UpdateFine()
        Else
            Label14.Visible = True
        End If
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox2.GotFocus
        ' When the textbox gains focus, clear the placeholder text if it's present
        If TextBox2.Text = "Enter your OTP" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox2.LostFocus
        ' When the textbox loses focus and it's empty, display the placeholder text
        If TextBox2.Text = "" Then
            TextBox2.Text = "Enter your OTP"
            TextBox2.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub
End Class