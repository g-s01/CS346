Public Class landingPage

    Private Sub Loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Loginbtn.Click
        Dim newForm As New loginPage()
        newForm.Show()
        Me.BackgroundImage.Dispose()
        Me.Hide()
    End Sub

    Private Sub Register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Register.Click
        Dim newForm As New registerPage()
        newForm.Show()
        Me.BackgroundImage.Dispose()
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim newForm As New adminLoginForm()
        newForm.Show()
        Me.BackgroundImage.Dispose()
        Me.Hide()
    End Sub

    Private Sub landingPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
