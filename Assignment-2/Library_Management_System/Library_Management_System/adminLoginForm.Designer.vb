<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adminLoginForm
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
        Me.SubminButton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SubminButton
        '
        Me.SubminButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SubminButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.SubminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SubminButton.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubminButton.Location = New System.Drawing.Point(170, 136)
        Me.SubminButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.SubminButton.Name = "SubminButton"
        Me.SubminButton.Size = New System.Drawing.Size(75, 38)
        Me.SubminButton.TabIndex = 0
        Me.SubminButton.Text = "Submit"
        Me.SubminButton.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Location = New System.Drawing.Point(68, 63)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(279, 43)
        Me.Panel1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.TextBox1.Location = New System.Drawing.Point(5, 11)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(5, 2, 2, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(262, 19)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "Enter admin password here"
        '
        'adminLoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(438, 212)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SubminButton)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximumSize = New System.Drawing.Size(454, 251)
        Me.MinimumSize = New System.Drawing.Size(454, 251)
        Me.Name = "adminLoginForm"
        Me.Text = "adminLoginForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SubminButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
