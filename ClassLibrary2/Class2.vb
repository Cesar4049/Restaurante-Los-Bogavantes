Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Class2
    Dim conexion As New SqlConnection("server=DESKTOP-KOT8F65;integrated security=true;Database=Restaurante")

    Public Function ListarOrden() As DataTable
        Dim da As New SqlDataAdapter("ListaOrden", conexion)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function ListarMenu() As DataTable
        Dim de As New SqlDataAdapter("ListaMenu", conexion)
        Dim tbl1 As New DataTable
        de.Fill(tbl1)
        Return tbl1
    End Function

    Public Function Ordenar(menu As Integer, restaurante As Integer, mesa As String, mesero As String, fecha As Date)
        Dim da As New SqlCommand("NuevaOrden", conexion)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@Menu", menu)
        da.Parameters.AddWithValue("@Restaurante", restaurante)
        da.Parameters.AddWithValue("@Mesa", mesa)
        da.Parameters.AddWithValue("@Mesero", mesero)
        da.Parameters.AddWithValue("@Fecha", fecha)
        conexion.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            conexion.Close()

        Catch ex As Exception
            MsgBox("Error al Ordenar")
        End Try
        Return resp
    End Function

    Public Function EliminarOrden(idorden As String)
        Dim elim As New SqlCommand("EliminarOrden", conexion)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@idorden", idorden)
        conexion.Open()
        Dim elim1 As String = elim.ExecuteNonQuery
        conexion.Close()
        Return elim1
    End Function

    Public Function ModificarOrden(idorden As String, menu As Integer, restaurante As Integer, mesa As String, mesero As String, fecha As Date) As Integer
        Dim act As New SqlCommand("Modificarrden", conexion)
        act.CommandType = CommandType.StoredProcedure
        act.Parameters.AddWithValue("@idorden", idorden)
        act.Parameters.AddWithValue("@Menu", menu)
        act.Parameters.AddWithValue("@Restaurante", restaurante)
        act.Parameters.AddWithValue("@Mesa", mesa)
        act.Parameters.AddWithValue("@Mesero", mesero)
        act.Parameters.AddWithValue("@Fecha", fecha)
        conexion.Open()
        Dim actu1 As String = act.ExecuteNonQuery
        conexion.Close()
        Return actu1
    End Function
End Class
