Public Class facultyPage

    ' Define a global array to store borrowedBooks
    Dim borrowedBooks As New List(Of Entry)
    Dim overdueBooks As New List(Of Entry)
    Dim allBooks As New List(Of Entry)

    ' Define a structure to hold book details
    Structure Entry
        Public BookID As Integer
        Public Author As String
        Public Title As String
        Public DueDate As String
        Public RadioButton As RadioButton ' Added RadioButton field
    End Structure

    Private Sub facultyPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Add some sample data to the array (you can load from a database or file)
        borrowedBooks.Add(New Entry With {.BookID = 1, .Author = "Author1", .Title = "Title1", .DueDate = "31/12/2024", .RadioButton = New RadioButton()})
        borrowedBooks.Add(New Entry With {.BookID = 2, .Author = "Author2", .Title = "Title2", .DueDate = "31/12/2024", .RadioButton = New RadioButton()})
        borrowedBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024", .RadioButton = New RadioButton()})
        borrowedBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024", .RadioButton = New RadioButton()})
        borrowedBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024", .RadioButton = New RadioButton()})
        borrowedBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024", .RadioButton = New RadioButton()})
        borrowedBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024", .RadioButton = New RadioButton()})

        overdueBooks.Add(New Entry With {.BookID = 1, .Author = "Author1", .Title = "Title1", .DueDate = "31/12/2024"})
        overdueBooks.Add(New Entry With {.BookID = 2, .Author = "Author2", .Title = "Title2", .DueDate = "31/12/2024"})
        overdueBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024"})
        overdueBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024"})
        overdueBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024"})
        overdueBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024"})
        overdueBooks.Add(New Entry With {.BookID = 3, .Author = "Author3", .Title = "Title3", .DueDate = "31/12/2024"})

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

        ' Add borrowedBooks to the table
        For rowIndex As Integer = 0 To borrowedBooks.Count - 1
            Dim entry As Entry = borrowedBooks(rowIndex)

            ' Add book details
            Dim bookIdLabel As New Label()
            bookIdLabel.Text = entry.BookID.ToString()
            borrowedBooksTablePanel.Controls.Add(bookIdLabel, 0, rowIndex + 1)
            bookIdLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            bookIdLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim authorLabel As New Label()
            authorLabel.Text = entry.Author
            borrowedBooksTablePanel.Controls.Add(authorLabel, 1, rowIndex + 1)
            authorLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            authorLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim titleLabel As New Label()
            titleLabel.Text = entry.Title
            borrowedBooksTablePanel.Controls.Add(titleLabel, 2, rowIndex + 1)
            titleLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            titleLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim dueDateLabel As New Label()
            dueDateLabel.Text = entry.DueDate
            borrowedBooksTablePanel.Controls.Add(dueDateLabel, 3, rowIndex + 1)
            dueDateLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            dueDateLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            ' Add radio button for options
            borrowedBooksTablePanel.Controls.Add(entry.RadioButton, 4, rowIndex + 1)
            entry.RadioButton.TextAlign = ContentAlignment.MiddleCenter ' Center the radio button
            entry.RadioButton.Anchor = AnchorStyles.None ' Set Anchor to None
            entry.RadioButton.Size = New Size(16, 16) ' Set the size of the radio button

        Next

        Dim adjustLabel As New Label()
        adjustLabel.Text = ""
        borrowedBooksTablePanel.Controls.Add(adjustLabel, 1, borrowedBooks.Count + 1)



        ' Add overdueBooks to the table
        For rowIndex As Integer = 0 To overdueBooks.Count - 1
            Dim entry As Entry = overdueBooks(rowIndex)

            ' Add book details
            Dim bookIdLabel As New Label()
            bookIdLabel.Text = entry.BookID.ToString()
            overdueBooksTablePanel.Controls.Add(bookIdLabel, 0, rowIndex + 1)
            bookIdLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            bookIdLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim authorLabel As New Label()
            authorLabel.Text = entry.Author
            overdueBooksTablePanel.Controls.Add(authorLabel, 1, rowIndex + 1)
            authorLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            authorLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim titleLabel As New Label()
            titleLabel.Text = entry.Title
            overdueBooksTablePanel.Controls.Add(titleLabel, 2, rowIndex + 1)
            titleLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            titleLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim dueDateLabel As New Label()
            dueDateLabel.Text = entry.DueDate
            overdueBooksTablePanel.Controls.Add(dueDateLabel, 3, rowIndex + 1)
            dueDateLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            dueDateLabel.Anchor = AnchorStyles.None ' Set Anchor to None

        Next

        Dim adjustLabel2 As New Label()
        adjustLabel2.Text = ""
        overdueBooksTablePanel.Controls.Add(adjustLabel2, 1, overdueBooks.Count + 1)



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

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenewButton.Click
        For Each entry As Entry In borrowedBooks
            If entry.RadioButton.Checked Then
                MessageBox.Show(entry.BookID.ToString() + " has been renewed.")
                Exit Sub
            End If
        Next

        MessageBox.Show("No book selected.")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
        For Each entry As Entry In borrowedBooks
            If entry.RadioButton.Checked Then
                MessageBox.Show(entry.BookID.ToString() + " has been returned.")
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
        Me.Hide()
    End Sub
End Class