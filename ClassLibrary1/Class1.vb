Imports System.Data.SqlClient
Public Class Class1
    Dim cnx As New SqlConnection("server=DESKTOP-KOT8F65;integrated security=true;Database=Restaurante")

    Public Function ListarEmpleados() As DataTable
        Dim da As New SqlDataAdapter("ListaEmpleados", cnx)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function Insertar(tur As Integer, dep As Integer, nom As String, corr As String, tel As String)
        Dim da As New SqlCommand("NuevoEmpleado", cnx)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@Turno", tur)
        da.Parameters.AddWithValue("@Departamento", dep)
        da.Parameters.AddWithValue("@Nombre", nom)
        da.Parameters.AddWithValue("@Correo", corr)
        da.Parameters.AddWithValue("@Telefono", tel)
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

    Public Function Eliminar(idempleado As String)
        Dim elim As New SqlCommand("EliminarEmpleado", cnx)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@idempleado", idempleado)
        cnx.Open()
        Dim elim1 As String = elim.ExecuteNonQuery
        cnx.Close()
        Return elim1
    End Function

    Public Function Modificar(idempleado As String, tur As Integer, dep As Integer, nombre As String, correo As String, tel As String) As Integer
        Dim act As New SqlCommand("ModificarEmpleado", cnx)
        act.CommandType = CommandType.StoredProcedure
        act.Parameters.AddWithValue("@codigo2", idempleado)
        act.Parameters.AddWithValue("@Turno", tur)
        act.Parameters.AddWithValue("@Departamento", dep)
        act.Parameters.AddWithValue("@Nombre", nombre)
        act.Parameters.AddWithValue("@Correo", correo)
        act.Parameters.AddWithValue("@Telefono", tel)
        cnx.Open()
        Dim actu1 As String = act.ExecuteNonQuery
        cnx.Close()
        Return actu1
    End Function

End Class
