Imports System.Data.SqlClient
Public Class Class1
    Dim cnx As New SqlConnection("server=DESKTOP-KOT8F65;integrated security=true;Database=Restaurante")

    Public Function ListarEmpleados() As DataTable
        Dim da As New SqlDataAdapter("pb_listar2", cnx)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function Insertar(nom As String, corr As String, tel As String, tur As Integer, dep As Integer)
        Dim da As New SqlCommand("pb_nuevo2", cnx)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@Nombre", nom)
        da.Parameters.AddWithValue("@Correo", corr)
        da.Parameters.AddWithValue("@Telefono", tel)
        da.Parameters.AddWithValue("@Turno", tur)
        da.Parameters.AddWithValue("@Departamento", dep)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            cnx.Close()

        Catch ex As Exception
            MsgBox("Error al registrar empleado")
        End Try
        Return resp
    End Function

    Public Function Eliminar(codigo As String)
        Dim elim As New SqlCommand("pb_eliminar2", cnx)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@codigo2", codigo)
        cnx.Open()
        Dim elim1 As String = elim.ExecuteNonQuery
        cnx.Close()
        Return elim1
    End Function

    Public Function Modificar(codigo As String, nombre As String, correo As String, tel As String, tur As Integer, dep As Integer) As Integer
        Dim act As New SqlCommand("pb_modificar2", cnx)
        act.CommandType = CommandType.StoredProcedure
        act.Parameters.AddWithValue("@codigo2", codigo)
        act.Parameters.AddWithValue("@Nombre", nombre)
        act.Parameters.AddWithValue("@Correo", correo)
        act.Parameters.AddWithValue("@Telefono", tel)
        act.Parameters.AddWithValue("@Turno", tur)
        act.Parameters.AddWithValue("@Departamento", dep)
        cnx.Open()
        Dim actu1 As String = act.ExecuteNonQuery
        cnx.Close()
        Return actu1
    End Function
End Class
