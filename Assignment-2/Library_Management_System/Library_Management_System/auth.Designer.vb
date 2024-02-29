<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class auth
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnAddBalance2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter OTP sent to mail"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(95, 101)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 1
        '
        'btnAddBalance2
        '
        Me.btnAddBalance2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAddBalance2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAddBalance2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddBalance2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddBalance2.Location = New System.Drawing.Point(84, 149)
        Me.btnAddBalance2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAddBalance2.Name = "btnAddBalance2"
        Me.btnAddBalance2.Size = New System.Drawing.Size(111, 32)
        Me.btnAddBalance2.TabIndex = 6
        Me.btnAddBalance2.Text = "Validate!"
        Me.btnAddBalance2.UseVisualStyleBackColor = False
        '
        'auth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnAddBalance2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "auth"
        Me.Text = "auth"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnAddBalance2 As System.Windows.Forms.Button
End Class
