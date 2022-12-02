Imports ClassLibrary2

Public Class Ticket
    Dim Objeto As New Class2
    Private Sub cmbProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProducto.SelectedIndexChanged
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)

    End Sub

    Private Sub Ticket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = Objeto.ListarOrden
    End Sub

    Private Sub btnVender_Click(sender As Object, e As EventArgs) Handles btnVender.Click
        If MsgBox("Desea Imprimir Ticket", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Imprimir") = MsgBoxResult.Yes Then
            If contardetalles() = False Then MsgBox("No hay datos a imprimir", MsgBoxStyle.Information, "Lista") : Exit Sub
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.ShowDialog()
        Else
            Exit Sub
        End If
    End Sub

    Function contardetalles() As Boolean
        Dim i As Integer
        i = DataGridView1.RowCount
        If i > 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PrintDocument1_PrintPage_1(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim letratit As New Font("Arial", 15, FontStyle.Underline)
        Dim letraenc As New Font("Arial", 10, FontStyle.Bold)
        Dim letragrid As New Font("Arial", 12, FontStyle.Regular)
        e.Graphics.DrawString("Ticket de Compra", letratit, Brushes.Black, 280, 100)
        e.Graphics.DrawString(txtCantidad.Text.ToString, letragrid, Brushes.Black, 50, 150)
        e.Graphics.DrawString("Cantidad", letratit, Brushes.Black, 50, 200)
        e.Graphics.DrawString("Descripcion", letratit, Brushes.Black, 120, 200)
        e.Graphics.DrawString("Parcial", letratit, Brushes.Black, 520, 200)
        e.Graphics.DrawString("Total", letratit, Brushes.Black, 650, 200)
        Dim FILA As Integer
        FILA = 20
        For I = 0 To DataGridView1.RowCount - 2
            e.Graphics.DrawString(DataGridView1.Item(0, I).Value, letragrid, Brushes.Black, 50, 200 + FILA)
            e.Graphics.DrawString(DataGridView1.Item(1, I).Value, letragrid, Brushes.Black, 200, 200 + FILA)
            e.Graphics.DrawString(DataGridView1.Item(2, I).Value, letragrid, Brushes.Black, 520, 200 + FILA)
            e.Graphics.DrawString(DataGridView1.Item(3, I).Value, letragrid, Brushes.Black, 650, 200 + FILA)
        Next
        e.Graphics.DrawString(txtCantidad.Text.ToString, letragrid, Brushes.Black, 600, 200 + FILA + 10)
    End Sub
End Class