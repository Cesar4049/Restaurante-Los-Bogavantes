Imports ClassLibrary1
Public Class RegistroEmpleados

    Dim obj As New Class1
    Private Sub RegistroEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = obj.ListarEmpleados

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        lblCodigo.Text = DataGridView1.Item(0, e.RowIndex).Value
        txtTurno.Text = DataGridView1.Item(1, e.RowIndex).Value
        txtDepartamento.Text = DataGridView1.Item(2, e.RowIndex).Value
        txtNombre.Text = DataGridView1.Item(3, e.RowIndex).Value
        txtCorreo.Text = DataGridView1.Item(4, e.RowIndex).Value
        txtTelefono.Text = DataGridView1.Item(5, e.RowIndex).Value

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            obj.Insertar(txtNombre.Text, txtCorreo.Text, txtTelefono.Text, txtTurno.Text, txtDepartamento.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se registro el usuario" + txtNombre.Text)

            lblCodigo.Text = "-"
            txtTurno.Text = ""
            txtDepartamento.Text = ""
            txtNombre.Text = ""
            txtCorreo.Text = ""
            txtTelefono.Text = ""

        Catch ex As Exception
            MsgBox("Error 404 al registrar")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            obj.Modificar(lblCodigo.Text, txtNombre.Text, txtCorreo.Text, txtTelefono.Text, txtTurno.Text, txtDepartamento.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se modifico el usuario con codigo" + lblCodigo.Text)

            lblCodigo.Text = "-"
            txtTurno.Text = ""
            txtDepartamento.Text = ""
            txtNombre.Text = ""
            txtCorreo.Text = ""
            txtTelefono.Text = ""

        Catch ex As Exception
            MsgBox("Error 404 al modificar")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            obj.Eliminar(lblCodigo.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se elimino el usuario con codigo" + lblCodigo.Text)

            lblCodigo.Text = "-"
            txtTurno.Text = ""
            txtDepartamento.Text = ""
            txtNombre.Text = ""
            txtCorreo.Text = ""
            txtTelefono.Text = ""

        Catch ex As Exception
            MsgBox("Error 404 al eliminar")
        End Try
    End Sub
End Class