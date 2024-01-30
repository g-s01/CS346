Imports System.Windows.Forms.DataVisualization.Charting

Public Class qesolver

    Private Sub btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn.Click
        ' The coefficients of the equation ax^2 + bx + c
        Dim a, b, c As Integer

        ' Try to parse coefficients from textboxes
        If Not Integer.TryParse(txtA.Text, a) Then
            MessageBox.Show("Invalid input for coefficient 'a'. Note that 'a' can ONLY be an integer from -1000 to 1000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(txtB.Text, b) Then
            MessageBox.Show("Invalid input for coefficient 'b'. Note that 'b' can ONLY be an integer from -1000 to 1000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Integer.TryParse(txtC.Text, c) Then
            MessageBox.Show("Invalid input for coefficient 'c'. Note that 'c' can ONLY be an integer from -1000 to 1000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if 'a' is zero
        If a = 0 Then
            MessageBox.Show("Coefficient 'a' cannot be zero.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if coefficients are within the specified range
        If Not (a >= -1000 AndAlso a <= 1000) Then
            MessageBox.Show("Coefficient 'a' must be in the range of -1000 to 1000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not (b >= -1000 AndAlso b <= 1000) Then
            MessageBox.Show("Coefficient 'b' must be in the range of -1000 to 1000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not (c >= -1000 AndAlso c <= 1000) Then
            MessageBox.Show("Coefficient 'c' must be in the range of -1000 to 1000.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Calculate discriminant
        Dim discriminant As Double = b * b - 4 * a * c

        ' Check discriminant for real solutions
        If discriminant >= 0 Then
            ' Calculate solutions
            Dim x1 As Double = (-b + Math.Sqrt(discriminant)) / (2 * a)
            Dim x2 As Double = (-b - Math.Sqrt(discriminant)) / (2 * a)

            ' Format solutions with exactly 3 decimal places
            Dim formattedX1 As String = x1.ToString("F3")
            Dim formattedX2 As String = x2.ToString("F3")

            ' Display solutions
            MessageBox.Show("Solution 1: " & formattedX1 & vbCrLf & "Solution 2: " & formattedX2, "Quadratic Solver")
        Else
            ' No real solutions
            MessageBox.Show("No real roots exist for the given equation.", "Quadratic Solver")
        End If

        ' Display steps for "complete the square" method
        Dim h As Double = -b / (2 * a)
        Dim k As Double = ((b * b) / (4 * a)) - c

        ' Format h and k with brackets and 3 decimal places
        Dim formattedH As String = "(" + String.Format("{0:F3}", h) + ")"
        Dim formattedK As String = "(" + String.Format("{0:F3}", k) + ")"

        MessageBox.Show("Complete the square steps:" + vbCrLf +
                        "1. Rewrite the quadratic equation as: " + a.ToString() + " * (x - " + formattedH + ")^2 = " + formattedK + vbCrLf +
                        "2. Solve for x by taking the square root of both sides." + vbCrLf +
                        "3. x - " + formattedH + " = ±√" + formattedK + vbCrLf +
                        "4. Solve for x:" + vbCrLf +
                        "   a. x = " + formattedH + " + √" + formattedK + vbCrLf +
                        "   b. x = " + formattedH + " - √" + formattedK, "Complete the Square")

        If discriminant < 0 Then
            MessageBox.Show("Since, ±√" + formattedK + " is not real, the roots of the equation " + a.ToString + "x^2 + " + b.ToString + "x + " + c.ToString + " = 0 does not have real solutions", "No real solutions!")
        End If

        ' Visualize the quadratic equation
        graph.Series.Clear()
        Dim series As New Series("Quadratic Equation")
        series.ChartType = SeriesChartType.Line ' Set chart type to Line

        ' Add points to create a line representing the quadratic equation
        For i As Double = -10 To 10 Step 0.1
            Dim y As Double = a * i * i + b * i + c
            series.Points.AddXY(i, y)
        Next

        graph.Series.Add(series)

        ' Set chart area properties to display a coordinate system
        graph.ChartAreas(0).AxisX.Crossing = 0
        graph.ChartAreas(0).AxisY.Crossing = 0
        graph.ChartAreas(0).AxisX.Minimum = -20
        graph.ChartAreas(0).AxisX.Maximum = 50
        graph.ChartAreas(0).AxisY.Minimum = -20
        graph.ChartAreas(0).AxisY.Maximum = 20

        ' Enable zooming and scrolling
        graph.ChartAreas(0).CursorX.IsUserEnabled = True
        graph.ChartAreas(0).CursorX.IsUserSelectionEnabled = True
        graph.ChartAreas(0).CursorY.IsUserEnabled = True
        graph.ChartAreas(0).CursorY.IsUserSelectionEnabled = True

        ' Enable auto-scrolling after zooming
        graph.ChartAreas(0).AxisX.ScaleView.Zoomable = True
        graph.ChartAreas(0).AxisY.ScaleView.Zoomable = True
        graph.ChartAreas(0).AxisX.ScrollBar.IsPositionedInside = True
        graph.ChartAreas(0).AxisY.ScrollBar.IsPositionedInside = True
    End Sub
End Class