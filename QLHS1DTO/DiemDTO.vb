Public Class DiemDTO
    Private strMSHS As String
    Private iMaMonHoc As Integer
    Private iMaLoaiDiem As Integer
    Private iMaHocKy As Integer
    Private fDiem As Single

    Property MSHS() As String
        Get
            Return strMSHS
        End Get
        Set(ByVal Value As String)
            strMSHS = Value
        End Set
    End Property
    Public Property MaMonHoc As Integer
        Get
            Return iMaMonHoc
        End Get
        Set(value As Integer)
            iMaMonHoc = value
        End Set
    End Property
    Public Property MaLoaiDiem As Integer
        Get
            Return iMaLoaiDiem
        End Get
        Set(value As Integer)
            iMaLoaiDiem = value
        End Set
    End Property
    Public Property MaHocKy As Integer
        Get
            Return iMaHocKy
        End Get
        Set(value As Integer)
            iMaHocKy = value
        End Set
    End Property

    Public Property Diem As Single
        Get
            Return fDiem
        End Get
        Set(value As Single)
            fDiem = value
        End Set
    End Property
End Class
