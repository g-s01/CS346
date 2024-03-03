<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginPage
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
        Me.Student = New System.Windows.Forms.Button()
        Me.Faculty = New System.Windows.Forms.Button()
        Me.Username = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.Loginbtn = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Register = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Student
        '
        Me.Student.BackColor = System.Drawing.Color.Transparent
        Me.Student.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Student.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Student.FlatAppearance.BorderSize = 0
        Me.Student.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Student.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Student.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Student.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Student.Location = New System.Drawing.Point(410, 269)
        Me.Student.Name = "Student"
        Me.Student.Size = New System.Drawing.Size(188, 36)
        Me.Student.TabIndex = 0
        Me.Student.Text = "Student"
        Me.Student.UseVisualStyleBackColor = False
        '
        'Faculty
        '
        Me.Faculty.BackColor = System.Drawing.Color.Transparent
        Me.Faculty.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Faculty.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Faculty.FlatAppearance.BorderSize = 0
        Me.Faculty.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Faculty.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Faculty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Faculty.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Faculty.Location = New System.Drawing.Point(604, 269)
        Me.Faculty.Name = "Faculty"
        Me.Faculty.Size = New System.Drawing.Size(170, 36)
        Me.Faculty.TabIndex = 1
        Me.Faculty.Text = "Faculty"
        Me.Faculty.UseVisualStyleBackColor = False
        '
        'Username
        '
        Me.Username.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Username.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Username.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username.ForeColor = System.Drawing.Color.Gray
        Me.Username.Location = New System.Drawing.Point(457, 386)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(264, 23)
        Me.Username.TabIndex = 2
        Me.Username.Text = "Username"
        '
        'Password
        '
        Me.Password.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Password.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password.ForeColor = System.Drawing.Color.Gray
        Me.Password.Location = New System.Drawing.Point(457, 447)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(264, 23)
        Me.Password.TabIndex = 3
        Me.Password.Text = "Password"
        '
        'Loginbtn
        '
        Me.Loginbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Loginbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Loginbtn.FlatAppearance.BorderSize = 0
        Me.Loginbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Loginbtn.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Loginbtn.Location = New System.Drawing.Point(444, 505)
        Me.Loginbtn.Name = "Loginbtn"
        Me.Loginbtn.Size = New System.Drawing.Size(296, 40)
        Me.Loginbtn.TabIndex = 4
        Me.Loginbtn.Text = "Login"
        Me.Loginbtn.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.ActiveLinkColor = System.Drawing.Color.Purple
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel1.Location = New System.Drawing.Point(534, 563)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(115, 20)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Login as admin"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.Black
        '
        'Register
        '
        Me.Register.ActiveLinkColor = System.Drawing.Color.Purple
        Me.Register.AutoSize = True
        Me.Register.BackColor = System.Drawing.Color.Transparent
        Me.Register.DisabledLinkColor = System.Drawing.Color.Black
        Me.Register.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Register.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.Register.LinkColor = System.Drawing.Color.Black
        Me.Register.Location = New System.Drawing.Point(994, 41)
        Me.Register.Name = "Register"
        Me.Register.Size = New System.Drawing.Size(90, 28)
        Me.Register.TabIndex = 6
        Me.Register.TabStop = True
        Me.Register.Text = "Register"
        Me.Register.VisitedLinkColor = System.Drawing.Color.Black
        '
        'loginPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Library_Management_System.My.Resources.Resources.loginBg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1182, 703)
        Me.Controls.Add(Me.Register)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Loginbtn)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.Faculty)
        Me.Controls.Add(Me.Student)
        Me.DoubleBuffered = True
        Me.MaximumSize = New System.Drawing.Size(1200, 750)
        Me.MinimumSize = New System.Drawing.Size(1200, 750)
        Me.Name = "loginPage"
        Me.Text = "loginPage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Student As System.Windows.Forms.Button
    Friend WithEvents Faculty As System.Windows.Forms.Button
    Friend WithEvents Username As System.Windows.Forms.TextBox
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents Loginbtn As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Register As System.Windows.Forms.LinkLabel

End Class
