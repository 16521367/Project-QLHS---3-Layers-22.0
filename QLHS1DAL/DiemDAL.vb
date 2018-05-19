Imports System.Configuration
Imports System.Data.SqlClient
Imports QLHS1DTO
Imports Utility

Public Class DiemDAL
    Private connectionString As String

    Public Sub New()
        ' Read ConnectionString value from App.config file
        connectionString = ConfigurationManager.AppSettings("ConnectionString")
    End Sub
    Public Sub New(ConnectionString As String)
        Me.connectionString = ConnectionString
    End Sub

    Public Function insert(diem As DiemDTO) As Result

        Dim query As String = String.Empty
        query &= "INSERT INTO [tbldiem] ([mahocsinh], [mamonhoc], [maloaidiem], [mahocky], [diem])"
        query &= "VALUES (@mahocsinh,@mamonhoc,@maloaidiem,@mahocky,@diem)"

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocsinh", diem.MSHS)
                    .Parameters.AddWithValue("@mamonhoc", diem.MaMonHoc)
                    .Parameters.AddWithValue("@maloaidiem", diem.MaLoaiDiem)
                    .Parameters.AddWithValue("@mahocky", diem.MaHocKy)
                    .Parameters.AddWithValue("@diem", diem.Diem)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Thêm điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function update(diem As DiemDTO) As Result

        Dim query As String = String.Empty
        query &= " UPDATE [tbldiem] SET"
        query &= " [diem] = @diem "
        query &= "WHERE "
        query &= " [mahocsinh] = @mahocsinh "
        query &= " [mamonhoc] = @mamonhoc "
        query &= " [maloaidiem] = @maloaidiem "
        query &= " [mahocky] = @mahocky "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocsinh", diem.MSHS)
                    .Parameters.AddWithValue("@mamonhoc", diem.MaMonHoc)
                    .Parameters.AddWithValue("@maloaidiem", diem.MaLoaiDiem)
                    .Parameters.AddWithValue("@mahocky", diem.MaHocKy)
                    .Parameters.AddWithValue("@diem", diem.Diem)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Cập nhật điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function

    Public Function delete(diem As DiemDTO) As Result

        Dim query As String = String.Empty
        query &= " DELETE FROM [tbldiem] "
        query &= "WHERE "
        query &= " [mahocsinh] = @mahocsinh "
        query &= " [mamonhoc] = @mamonhoc "
        query &= " [maloaidiem] = @maloaidiem "
        query &= " [mahocky] = @mahocky "

        Using conn As New SqlConnection(connectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@mahocsinh", diem.MSHS)
                    .Parameters.AddWithValue("@mamonhoc", diem.MaMonHoc)
                    .Parameters.AddWithValue("@maloaidiem", diem.MaLoaiDiem)
                    .Parameters.AddWithValue("@mahocky", diem.MaHocKy)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                    conn.Close()
                    ' them that bai!!!
                    Return New Result(False, "Xóa điểm không thành công", ex.StackTrace)
                End Try
            End Using
        End Using
        Return New Result(True) ' thanh cong
    End Function
End Class
