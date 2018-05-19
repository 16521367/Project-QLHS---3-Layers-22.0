Imports QLHS1DAL
Imports QLHS1DTO
Imports Utility

Public Class DiemBus
    Private diemDAL As DiemDAL
    Public Sub New()
        diemDAL = New DiemDAL()
    End Sub
    Public Sub New(connectionString As String)
        diemDAL = New DiemDAL(connectionString)
    End Sub

    Public Function insert(diemDTO As DiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return diemDAL.insert(diemDTO)
    End Function
    Public Function update(diemDTO As DiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return diemDAL.update(diemDTO)
    End Function
    Public Function delete(diemDTO As DiemDTO) As Result
        '1. verify data here!!

        '2. insert to DB
        Return diemDAL.delete(diemDTO)
    End Function

End Class
