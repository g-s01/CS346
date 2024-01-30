<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class qesolver
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.txtA = New System.Windows.Forms.TextBox()
        Me.txtB = New System.Windows.Forms.TextBox()
        Me.txtC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn = New System.Windows.Forms.Button()
        Me.graph = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.graph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtA
        '
        Me.txtA.Location = New System.Drawing.Point(123, 232)
        Me.txtA.Name = "txtA"
        Me.txtA.Size = New System.Drawing.Size(61, 20)
        Me.txtA.TabIndex = 0
        '
        'txtB
        '
        Me.txtB.Location = New System.Drawing.Point(123, 273)
        Me.txtB.Name = "txtB"
        Me.txtB.Size = New System.Drawing.Size(61, 20)
        Me.txtB.TabIndex = 1
        '
        'txtC
        '
        Me.txtC.Location = New System.Drawing.Point(124, 311)
        Me.txtC.Name = "txtC"
        Me.txtC.Size = New System.Drawing.Size(60, 20)
        Me.txtC.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enter a"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 276)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Enter b"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 314)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Enter c"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(233, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Quadractic Equation Solver!"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.quadratic_equation_solver.My.Resources.Resources.image1
        Me.PictureBox1.Location = New System.Drawing.Point(32, 113)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'btn
        '
        Me.btn.Location = New System.Drawing.Point(39, 355)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(122, 23)
        Me.btn.TabIndex = 9
        Me.btn.Text = "Calculate roots!"
        Me.btn.UseVisualStyleBackColor = True
        '
        'graph
        '
        ChartArea1.Name = "ChartArea1"
        Me.graph.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.graph.Legends.Add(Legend1)
        Me.graph.Location = New System.Drawing.Point(251, 23)
        Me.graph.Name = "graph"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.graph.Series.Add(Series1)
        Me.graph.Size = New System.Drawing.Size(726, 365)
        Me.graph.TabIndex = 6
        Me.graph.Text = "graph"
        '
        'qesolver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 409)
        Me.Controls.Add(Me.btn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.graph)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtC)
        Me.Controls.Add(Me.txtB)
        Me.Controls.Add(Me.txtA)
        Me.Name = "qesolver"
        Me.Text = "Quadratic Equation Solver"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.graph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtA As System.Windows.Forms.TextBox
    Friend WithEvents txtB As System.Windows.Forms.TextBox
    Friend WithEvents txtC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btn As System.Windows.Forms.Button
    Friend WithEvents graph As System.Windows.Forms.DataVisualization.Charting.Chart

End Class
