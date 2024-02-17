<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class landingPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Loginbtn = New System.Windows.Forms.Button()
        Me.Register = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Loginbtn
        '
        Me.Loginbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Loginbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Loginbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Loginbtn.FlatAppearance.BorderSize = 0
        Me.Loginbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Loginbtn.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Loginbtn.ForeColor = System.Drawing.Color.Black
        Me.Loginbtn.Location = New System.Drawing.Point(522, 405)
        Me.Loginbtn.Name = "Loginbtn"
        Me.Loginbtn.Size = New System.Drawing.Size(139, 33)
        Me.Loginbtn.TabIndex = 0
        Me.Loginbtn.Text = "Login"
        Me.Loginbtn.UseVisualStyleBackColor = False
        '
        'Register
        '
        Me.Register.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Register.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Register.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Register.FlatAppearance.BorderSize = 0
        Me.Register.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Register.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Register.ForeColor = System.Drawing.Color.Black
        Me.Register.Location = New System.Drawing.Point(522, 462)
        Me.Register.Name = "Register"
        Me.Register.Size = New System.Drawing.Size(139, 33)
        Me.Register.TabIndex = 1
        Me.Register.Text = "Register"
        Me.Register.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Black
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(534, 528)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(115, 20)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Login as admin"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.Black
        '
        'landingPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Library_Management_System.My.Resources.Resources.landingBg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1182, 703)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Register)
        Me.Controls.Add(Me.Loginbtn)
        Me.DoubleBuffered = True
        Me.MaximumSize = New System.Drawing.Size(1200, 750)
        Me.MinimumSize = New System.Drawing.Size(1200, 750)
        Me.Name = "landingPage"
        Me.Text = "landingPage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Loginbtn As System.Windows.Forms.Button
    Friend WithEvents Register As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

End Class
