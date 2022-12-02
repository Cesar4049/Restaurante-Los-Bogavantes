Imports System.Data.SqlClient
Imports System.Security.Cryptography
Public Class Class3
    Dim conexion1 As New SqlConnection("server=DESKTOP-KOT8F65;integrated security=true;Database=Restaurante")

    Public Function ListardeInventario() As DataTable
        Dim da As New SqlDataAdapter("ListaEmpleados", conexion1)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function AgregarInv(restaurante As Integer, nompro As String, cantidad As String)
        Dim da As New SqlCommand("NuevoProducto", conexion1)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@Restaurante", restaurante)
        da.Parameters.AddWithValue("@Producto", nompro)
        da.Parameters.AddWithValue("@Cantidad", cantidad)

        conexion1.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            conexion1.Close()

        Catch ex As Exception
            MsgBox("Error al registrar Inventario")
        End Try
        Return resp
    End Function

    Public Function EliminarProducto(idproducto As String)
        Dim elim As New SqlCommand("EliminarOrden", conexion1)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@idproducto", idproducto)
        conexion1.Open()
        Dim elim1 As String = elim.ExecuteNonQuery
        conexion1.Close()
        Return elim1
    End Function

    Public Function ModificarProducto(idproducto As String, restaurante As Integer, nombre As String, cantidad As String) As Integer
        Dim act As New SqlCommand("ModificarProducto", conexion1)
        act.CommandType = CommandType.StoredProcedure
        act.Parameters.AddWithValue("@idproducto", idproducto)
        act.Parameters.AddWithValue("@Restaurante", restaurante)
        act.Parameters.AddWithValue("@Nombre", nombre)
        act.Parameters.AddWithValue("@Cantidad", cantidad)
        conexion1.Open()
        Dim actu1 As String = act.ExecuteNonQuery
        conexion1.Close()
        Return actu1
    End Function

End Class
