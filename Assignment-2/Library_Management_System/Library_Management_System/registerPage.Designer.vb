<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registerPage
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
        Me.Registerbtn = New System.Windows.Forms.Button()
        Me.Uname = New System.Windows.Forms.TextBox()
        Me.CPassword = New System.Windows.Forms.TextBox()
        Me.Login = New System.Windows.Forms.LinkLabel()
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
        Me.Student.Location = New System.Drawing.Point(409, 244)
        Me.Student.Name = "Student"
        Me.Student.Size = New System.Drawing.Size(188, 36)
        Me.Student.TabIndex = 1
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
        Me.Faculty.Location = New System.Drawing.Point(603, 244)
        Me.Faculty.Name = "Faculty"
        Me.Faculty.Size = New System.Drawing.Size(170, 36)
        Me.Faculty.TabIndex = 2
        Me.Faculty.Text = "Faculty"
        Me.Faculty.UseVisualStyleBackColor = False
        '
        'Username
        '
        Me.Username.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Username.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Username.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username.ForeColor = System.Drawing.Color.Gray
        Me.Username.Location = New System.Drawing.Point(455, 389)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(264, 23)
        Me.Username.TabIndex = 3
        Me.Username.Text = "Username"
        '
        'Password
        '
        Me.Password.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Password.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password.ForeColor = System.Drawing.Color.Gray
        Me.Password.Location = New System.Drawing.Point(455, 449)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(264, 23)
        Me.Password.TabIndex = 4
        Me.Password.Text = "Password"
        '
        'Registerbtn
        '
        Me.Registerbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Registerbtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Registerbtn.FlatAppearance.BorderSize = 0
        Me.Registerbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Registerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Registerbtn.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Registerbtn.Location = New System.Drawing.Point(442, 565)
        Me.Registerbtn.Name = "Registerbtn"
        Me.Registerbtn.Size = New System.Drawing.Size(298, 40)
        Me.Registerbtn.TabIndex = 5
        Me.Registerbtn.Text = "Register"
        Me.Registerbtn.UseVisualStyleBackColor = False
        '
        'Uname
        '
        Me.Uname.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Uname.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Uname.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uname.ForeColor = System.Drawing.Color.Gray
        Me.Uname.Location = New System.Drawing.Point(455, 328)
        Me.Uname.Name = "Uname"
        Me.Uname.Size = New System.Drawing.Size(264, 23)
        Me.Uname.TabIndex = 6
        Me.Uname.Text = "Name"
        '
        'CPassword
        '
        Me.CPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CPassword.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CPassword.ForeColor = System.Drawing.Color.Gray
        Me.CPassword.Location = New System.Drawing.Point(455, 511)
        Me.CPassword.Name = "CPassword"
        Me.CPassword.Size = New System.Drawing.Size(264, 23)
        Me.CPassword.TabIndex = 7
        Me.CPassword.Text = "Confirm Password"
        '
        'Login
        '
        Me.Login.ActiveLinkColor = System.Drawing.Color.Purple
        Me.Login.AutoSize = True
        Me.Login.BackColor = System.Drawing.Color.Transparent
        Me.Login.DisabledLinkColor = System.Drawing.Color.Black
        Me.Login.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.Login.LinkColor = System.Drawing.Color.Black
        Me.Login.Location = New System.Drawing.Point(1024, 40)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(64, 28)
        Me.Login.TabIndex = 8
        Me.Login.TabStop = True
        Me.Login.Text = "Login"
        Me.Login.VisitedLinkColor = System.Drawing.Color.Black
        '
        'registerPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Library_Management_System.My.Resources.Resources.registerBg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1182, 703)
        Me.Controls.Add(Me.Login)
        Me.Controls.Add(Me.CPassword)
        Me.Controls.Add(Me.Uname)
        Me.Controls.Add(Me.Registerbtn)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.Faculty)
        Me.Controls.Add(Me.Student)
        Me.DoubleBuffered = True
        Me.MaximumSize = New System.Drawing.Size(1200, 750)
        Me.MinimumSize = New System.Drawing.Size(1200, 750)
        Me.Name = "registerPage"
        Me.Text = "registerPage"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Student As System.Windows.Forms.Button
    Friend WithEvents Faculty As System.Windows.Forms.Button
    Friend WithEvents Username As System.Windows.Forms.TextBox
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents Registerbtn As System.Windows.Forms.Button
    Friend WithEvents Uname As System.Windows.Forms.TextBox
    Friend WithEvents CPassword As System.Windows.Forms.TextBox
    Friend WithEvents Login As System.Windows.Forms.LinkLabel

End Class
