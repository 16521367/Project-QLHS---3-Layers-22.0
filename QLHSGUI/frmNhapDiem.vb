Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmNhapDiem

    Private namhocBus As NamHocBus
    Private hockyBus As HocKyBus
    Private khoiBus As KhoiBus
    Private lopBus As LopBus
    Private hsBus As HocSinhBUS
    Private lophocsinhBus As LopHocSinhBus

    Private Sub frmNhapDiem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        namhocBus = New NamHocBus()
        hockyBus = New HocKyBus()
        khoiBus = New KhoiBus()
        lopBus = New LopBus()
        hsBus = New HocSinhBUS()
        lophocsinhBus = New LopHocSinhBus()

        ' Load Khoi list
        Dim listKhoi = New List(Of KhoiDTO)
        Dim result = khoiBus.selectAll(listKhoi)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Khối không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbKhoi.DataSource = New BindingSource(listKhoi, String.Empty)
        cbKhoi.DisplayMember = "Khoi"
        cbKhoi.ValueMember = "MaKhoi"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbKhoi.DataSource)
        myCurrencyManager.Refresh()
        If (listKhoi.Count > 0) Then
            cbKhoi.SELECTedIndex = 0
        End If
    End Sub

    Private Sub cbKhoi_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbKhoi.SELECTedIndexChanged
        dgvListHS.DataSource = Nothing

        ' Load Nam Hoc list
        Dim listNamHoc = New List(Of NamHocDTO)
        Dim result As Result
        result = namhocBus.selectAll(listNamHoc)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If

        cbNamHoc.DataSource = New BindingSource(listNamHoc, String.Empty)
        cbNamHoc.DisplayMember = "NamHoc"
        cbNamHoc.ValueMember = "MaNamHoc"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbNamHoc.DataSource)
        myCurrencyManager.Refresh()
        cbNamHoc.SELECTedIndex = 0
        If (listNamHoc.Count > 0) Then
            cbNamHoc.SELECTedIndex = 0
        End If
    End Sub

    Private Sub cbNamHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbNamHoc.SELECTedIndexChanged
        Try
            dgvListHS.DataSource = Nothing
            Dim namhoc = CType(cbNamHoc.SELECTedItem, NamHocDTO)
            Dim listHocKy = New List(Of HocKyDTO)
            Dim Result = hockyBus.selectALL_ByMaNamHoc(namhoc.MaNamHoc, listHocKy)
            If (Result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Học Kỳ theo Năm Học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(Result.SystemMessage)
                Return
            End If

            cbHocKy.DataSource = New BindingSource(listHocKy, String.Empty)
            cbHocKy.DisplayMember = "HocKy"
            cbHocKy.ValueMember = "MaHocKy"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbHocKy.DataSource)
            myCurrencyManager.Refresh()
            If (listHocKy.Count > 0) Then
                cbHocKy.SELECTedIndex = 0
            End If
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub cbHocKy_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbHocKy.SELECTedIndexChanged
        Try
            dgvListHS.DataSource = Nothing
            Dim listLop = New List(Of LopDTO)
            Dim khoi = CType(cbKhoi.SELECTedItem, KhoiDTO)
            Dim hocky = CType(cbHocKy.SELECTedItem, HocKyDTO)
            Dim result = lopBus.selectALL_ByMaKhoiAndMyHocKy(khoi.MaKhoi, hocky.MaHocKy, listLop)
            If (result.FlagResult = False) Then
                MessageBox.Show("Lấy danh sách Lớp không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                System.Console.WriteLine(result.SystemMessage)
                Me.Close()
                Return
            End If

            ' Load Lop list
            cbLop.DataSource = New BindingSource(listLop, String.Empty)
            cbLop.DisplayMember = "TenLop"
            cbLop.ValueMember = "MaLop"
            Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbLop.DataSource)
            myCurrencyManager.Refresh()
            If (listLop.Count > 0) Then
                cbLop.SELECTedIndex = 0
            End If

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub
    Private Sub loadListHocSinhFROM(maHocKy As Integer)

        Dim listHS = New List(Of HocSinhDTO)
        Dim result As Result
        result = hsBus.selectALL_ByMaLop(maHocKy, listHS)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách học sinh theo loại không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
        dgvListHS.Columns.Clear()
        dgvListHS.DataSource = Nothing

        dgvListHS.AutoGenerateColumns = False
        dgvListHS.AllowUserToAddRows = False
        dgvListHS.DataSource = listHS

        Dim clMa = New DataGridViewTextBoxColumn()
        clMa.Name = "MSHS"
        clMa.HeaderText = "Mã Học Sinh"
        clMa.DataPropertyName = "MSHS"
        dgvListHS.Columns.Add(clMa)

        Dim clLoaiHS = New DataGridView()
        'clLoaiHS.Name = "LoaiHS"
        'clLoaiHS.HeaderText = "Tên Loại"
        'clLoaiHS.DataPropertyName = "LoaiHS"
        'dgvListHS.Columns.Add(clLoaiHS)

        Dim clHoTen = New DataGridViewTextBoxColumn()
        clHoTen.Name = "HoTen"
        clHoTen.HeaderText = "Họ Tên"
        clHoTen.DataPropertyName = "HoTen"
        dgvListHS.Columns.Add(clHoTen)

        'Dim clDiaChi = New DataGridViewTextBoxColumn()
        'clDiaChi.Name = "DiaChi"
        'clDiaChi.HeaderText = "Địa Chỉ"
        'clDiaChi.DataPropertyName = "DiaChi"
        'dgvListHS.Columns.Add(clDiaChi)

        Dim clNgaySinh = New DataGridViewTextBoxColumn()
        clNgaySinh.Name = "NgaySinh"
        clNgaySinh.HeaderText = "Ngày Sinh"
        clNgaySinh.DataPropertyName = "NgaySinh"
        dgvListHS.Columns.Add(clNgaySinh)

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvListHS.DataSource)
        myCurrencyManager.Refresh()
    End Sub
    Private Sub cbLop_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbLop.SELECTedIndexChanged
        Try
            Dim lop = CType(cbLop.SELECTedItem, LopDTO)
            loadListHocSinhFROM(lop.MaLop)
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
            Return
        End Try
    End Sub

    Private Sub cbMonHoc_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbMonHoc.SELECTedIndexChanged

    End Sub

    Private Sub cbLoaiDiem_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbLoaiDiem.SELECTedIndexChanged

    End Sub

    Private Sub btnNhapDiem_Click(sender As Object, e As EventArgs) Handles btnNhapDiem.Click

    End Sub
End Class