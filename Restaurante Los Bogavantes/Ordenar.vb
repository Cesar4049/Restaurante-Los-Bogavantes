Imports ClassLibrary2
Public Class Ordenar

    Dim Objeto As New Class2
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Ordenar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = Objeto.ListarOrden
        DataGridView2.DataSource = Objeto.ListarMenu
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        lblOrden.Text = DataGridView1.Item(0, e.RowIndex).Value
        txtMenu.Text = DataGridView1.Item(1, e.RowIndex).Value
        txtRestaurante.Text = DataGridView1.Item(2, e.RowIndex).Value
        txtMesa.Text = DataGridView1.Item(3, e.RowIndex).Value
        txtMesero.Text = DataGridView1.Item(4, e.RowIndex).Value
        DateTimePicker1.Text = DataGridView1.Item(5, e.RowIndex).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Objeto.Ordenar(txtMenu.Text, txtRestaurante.Text, txtMesa.Text, txtMesero.Text, (CDate(DateTimePicker1.Text)))
            DataGridView1.DataSource = Objeto.ListarOrden
            MsgBox("Se registro la orden" + txtMenu.Text)

            lblOrden.Text = "-"
            txtMenu.Text = ""
            txtRestaurante.Text = ""
            txtMesa.Text = ""
            txtMesero.Text = ""
            DateTimePicker1.Value = DateTime.Now
        Catch ex As Exception
            MsgBox("Error 404 al registrar")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Objeto.ModificarOrden(lblOrden.Text, txtMenu.Text, txtRestaurante.Text, txtMesa.Text, txtMesero.Text, DateTimePicker1.Text)
            DataGridView1.DataSource = Objeto.ListarOrden
            MsgBox("Se modifico la Orden" + lblOrden.Text)

            lblOrden.Text = "-"
            txtMenu.Text = ""
            txtRestaurante.Text = ""
            txtMesa.Text = ""
            txtMesero.Text = ""
            DateTimePicker1.Value = DateTime.Now
        Catch ex As Exception
            MsgBox("Error 404 al modificar")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Objeto.EliminarOrden(lblOrden.Text)
            DataGridView1.DataSource = Objeto.ListarOrden
            MsgBox("Se elimino la orden" + lblOrden.Text)

            lblOrden.Text = "-"
            txtMenu.Text = ""
            txtRestaurante.Text = ""
            txtMesa.Text = ""
            txtMesero.Text = ""
            DateTimePicker1.Value = DateTime.Now
        Catch ex As Exception
            MsgBox("Error 404 al eliminar")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lblOrden.Text = "-"
        txtMenu.Text = ""
        txtRestaurante.Text = ""
        txtMesa.Text = ""
        txtMesero.Text = ""
        DateTimePicker1.Value = DateTime.Now
    End Sub
End Class