Imports ClassLibrary1
Public Class Inventario

    Dim obj As New Class1

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = obj.ListarInventario

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        lblInv.Text = DataGridView1.Item(0, e.RowIndex).Value
        txtNombre.Text = DataGridView1.Item(1, e.RowIndex).Value
        txtCantidad.Text = DataGridView1.Item(2, e.RowIndex).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            obj.InsertarInv(txtNombre.Text, txtCantidad.Text)
            DataGridView1.DataSource = obj.ListarInventario
            MsgBox("Se registro el Producto" + txtNombre.Text)

            lblInv.Text = "-"
            txtNombre.Text = ""
            txtCantidad.Text = ""
        Catch ex As Exception
            MsgBox("Error 404 al registrar")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            obj.ModificarInv(lblInv.Text, txtNombre.Text, txtCantidad.Text)
            DataGridView1.DataSource = obj.ListarInventario
            MsgBox("Se modifico el producto con ID" + lblInv.Text)

            lblInv.Text = "-"
            txtNombre.Text = ""
            txtCantidad.Text = ""
        Catch ex As Exception
            MsgBox("Error 404 al modificar")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            obj.EliminarInv(lblInv.Text)
            DataGridView1.DataSource = obj.ListarInventario
            MsgBox("Se elimino el producto con ID" + lblInv.Text)

            lblInv.Text = "-"
            txtNombre.Text = ""
            txtCantidad.Text = ""
        Catch ex As Exception
            MsgBox("Error 404 al eliminar")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lblInv.Text = "-"
        txtNombre.Text = ""
        txtCantidad.Text = ""
    End Sub
End Class