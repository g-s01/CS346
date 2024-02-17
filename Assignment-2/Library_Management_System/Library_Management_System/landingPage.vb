Public Class landingPage

    Private Sub Loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Loginbtn.Click
        Dim newForm As New loginPage()
        newForm.show()
        Me.Hide()
    End Sub

    Private Sub Register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Register.Click
        Dim newForm As New registerPage()
        newForm.show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim newForm As New adminPage()
        newForm.Show()
        Me.Hide()
    End Sub
End Class
