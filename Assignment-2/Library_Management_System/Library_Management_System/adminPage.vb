Public Class adminPage

    Dim allBooks As New List(Of Entry)

    ' Define a structure to hold book details
    Structure Entry
        Public BookID As Integer
        Public Author As String
        Public Title As String
    End Structure

    Private Sub Dashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dashboard.Click
        Subdashboard_panel.Visible = True
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
        Subdashboard_panel.Visible = False
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
        Subdashboard_panel.Visible = False
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
        Subdashboard_panel.Visible = False
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
        Me.Hide()
    End Sub


    Private Sub Current_date_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Current_date.TextChanged
        Dim thisDate As Date
        thisDate = Today
        Current_date.Text() = thisDate
    End Sub

    Private Sub Add_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_button.Click
        If BookID_tb.Text = "" Or BookName_tb.Text = "" Or ISBN_tb.Text = "" Or Author_tb.Text = "" Or Publisher_tb.Text = "" Then
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
            ISBN_tb.Text = ""
            Author_tb.Text = ""
            Publisher_tb.Text = ""
            Reserved_tb.Text = ""


        End If
    End Sub


    Private Sub Update_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_button.Click
        If BookID_tb.Text = "" Or BookName_tb.Text = "" Or ISBN_tb.Text = "" Or Author_tb.Text = "" Or Publisher_tb.Text = "" Then
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
            ISBN_tb.Text = ""
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
        If StudentID_tb.Text = "" Or BookID_tb2.Text = "" Or BookName_tb2.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Issue the Book....to particular student....
            '
            '

            ' After issueing the book, clear the inputs and show the msg box that it is issued....
            MsgBox("Book Issued Successfully")
            BookID_tb2.Text = ""
            BookName_tb2.Text = ""
            StudentID_tb.Text = ""
            Fine_tb.Text = ""

        End If
    End Sub

    Private Sub Return_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Return_button.Click
        If StudentID_tb.Text = "" Or BookID_tb2.Text = "" Or BookName_tb2.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Implement the return function.....
            '
            'Return only if fine is 0....
            If Fine_tb.Text = "0" Then
                ' After returning the book, clear the inputs and show the msg box that it is Returned....
                MsgBox("Book Returned Successfully")
                BookID_tb2.Text = ""
                BookName_tb2.Text = ""
                StudentID_tb.Text = ""
                Fine_tb.Text = ""
            Else
                MsgBox("Pay the fine first to return!")
            End If



        End If
    End Sub

    Private Sub Pay_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pay_button.Click

        Fine_tb.Text = "0"
        If Not Fine_tb.Text = "" Then
            '
            '
            'Implement Pay option which makes fine 0.....
            '
            '
            Fine_tb.Text = "0"


        End If

    End Sub

    Private Sub Renew_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Renew_button.Click
        If StudentID_tb.Text = "" Or BookID_tb2.Text = "" Or BookName_tb2.Text = "" Then
            MsgBox("Missing Information", 0 + 0, "Error")
        Else
            '
            '
            ' Implement the renew function.....
            'Fine_tb.Text = "20" ' just for checking the working of pay button.....
            '
            'Renew only if fine is 0....
            If Fine_tb.Text = "0" Then
                ' After renewing the book, clear the inputs and show the msg box that it is Renewed....
                MsgBox("Book Renewed Successfully")
                BookID_tb2.Text = ""
                BookName_tb2.Text = ""
                StudentID_tb.Text = ""
                Fine_tb.Text = ""
            Else
                MsgBox("Pay the fine first to return!")
            End If

        End If
    End Sub

    Private Sub adminPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Subdashboard_panel.Visible = True
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
            allBooksTablePanel.Controls.Add(bookIdLabel, 0, rowIndex + 1)
            bookIdLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            bookIdLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim authorLabel As New Label()
            authorLabel.Text = entry.Author
            allBooksTablePanel.Controls.Add(authorLabel, 1, rowIndex + 1)
            authorLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            authorLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim titleLabel As New Label()
            titleLabel.Text = entry.Title
            allBooksTablePanel.Controls.Add(titleLabel, 2, rowIndex + 1)
            titleLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            titleLabel.Anchor = AnchorStyles.None ' Set Anchor to None

        Next

        Dim adjustLabel3 As New Label()
        adjustLabel3.Text = ""
        allBooksTablePanel.Controls.Add(adjustLabel3, 1, allBooks.Count + 1)

    End Sub
End Class