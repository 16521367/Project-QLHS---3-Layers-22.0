Imports QLHS1BUS
Imports QLHS1DTO
Imports Utility

Public Class frmQuanLyChuongTrinh

    Private lopBus As LopBus
    Private hsBus As HocSinhBUS
    Private monhocBus As MonHocBus
    Private loaidiemBus As LoaiDiemBus
    Private ctBus As ChuongTrinhBus
    Private listMonHoc As List(Of MonHocDTO)
    Private listMonHocOnDB As List(Of MonHocDTO)
    Private listMonHocChuongTrinh As List(Of ChiTietChuongTrinhDTO)
    Private listHTDG As List(Of HinhThucDanhGiaDTO)

    Private listCT As List(Of ChuongTrinhDTO)

    Private Sub frmQuanLyChuongTrinh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lopBus = New LopBus()
        hsBus = New HocSinhBUS()
        monhocBus = New MonHocBus()
        loaidiemBus = New LoaiDiemBus()
        ctBus = New ChuongTrinhBus()

        listCT = New List(Of ChuongTrinhDTO)
        listMonHocOnDB = New List(Of MonHocDTO)
        listMonHoc = New List(Of MonHocDTO)


        loadListMonHoc()
        loadChuongTrinh()
        loadLoaiDiem()

    End Sub

    Private Sub cbChuongTrinh_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbChuongTrinh.SELECTedIndexChanged
        Try
            Dim ct = CType(cbChuongTrinh.SELECTedItem, ChuongTrinhDTO)
            txtTenCT.Text = ct.TenCT
            dtpNgayTao.Value = ct.NgayTao
            Me.listMonHocChuongTrinh = ct.ListCTTT
            buildDGVMonHocChuongTrinh()
            If (Me.listMonHocChuongTrinh.Count < 1) Then
                Me.listHTDG.Clear()
                buildDGVHTDG()
            End If

            Me.listMonHoc.Clear()
            For Each mh In listMonHocOnDB
                Dim f = True
                For Each ctct In Me.listMonHocChuongTrinh
                    If (mh.MaMonHoc = ctct.MaMonHoc) Then
                        f = False
                        Exit For
                    End If
                Next
                If (f = True) Then
                    Me.listMonHoc.Add(mh)
                End If
            Next
            buildDGVMonHoc()

        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFROMTo_Click(sender As Object, e As EventArgs) Handles btnFROMTo.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHoc.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHoc.RowCount) Then
            Try
                Dim monhoc = CType(dgvMonHoc.Rows(currentRowIndex).DataBoundItem, MonHocDTO)
                listMonHoc.Remove(monhoc)
                listMonHocChuongTrinh.Add(New ChiTietChuongTrinhDTO(monhoc.MaMonHoc, monhoc.MonHoc, 1, -1, -1, New List(Of HinhThucDanhGiaDTO)))
                listHTDG = listMonHocChuongTrinh(listMonHocChuongTrinh.Count - 1).ListHTDG
                buildDGVMonHoc()
                buildDGVMonHocChuongTrinh()
                buildDGVHTDG()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub btnToFROM_Click(sender As Object, e As EventArgs) Handles btnToFROM.Click
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHocChuongTrinh.RowCount) Then
            Try
                Dim ctct = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex).DataBoundItem, ChiTietChuongTrinhDTO)
                listMonHocChuongTrinh.Remove(ctct)
                listMonHoc.Add(New MonHocDTO(ctct.MaMonHoc, ctct.TenMonHoc))
                listHTDG = New List(Of HinhThucDanhGiaDTO)
                buildDGVMonHoc()
                buildDGVMonHocChuongTrinh()
                buildDGVHTDG()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub dgvMonHocChuongTrinh_SELECTionChanged(sender As Object, e As EventArgs) Handles dgvMonHocChuongTrinh.SELECTionChanged
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHocChuongTrinh.RowCount) Then
            Try
                Dim ctct = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex).DataBoundItem, ChiTietChuongTrinhDTO)
                listHTDG = ctct.ListHTDG
                buildDGVHTDG()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub dgvMonHocChuongTrinh_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMonHocChuongTrinh.DataError
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvMonHocChuongTrinh.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvMonHocChuongTrinh.RowCount) Then
            Try
                'Dim hs = CType(dgvMonHocChuongTrinh.Rows(currentRowIndex).DataBoundItem, ChiTietChuongTrinhDTO)

                MessageBox.Show("Hệ Số Môn không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvMonHocChuongTrinh.CancelEdit()
                'storeValue = hs.NgaySinh
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub dgvHTDG_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvHTDG.DataError
        ' Get the current cell location.
        Dim currentRowIndex As Integer = dgvHTDG.CurrentCellAddress.Y 'current row selected
        'Dim x As Integer = dgvListHS.CurrentCellAddress.X 'curent column selected

        ' Write coordinates to console for debugging
        'Console.WriteLine(y.ToString + " " + x.ToString)

        'Verify that indexing OK
        If (-1 < currentRowIndex And currentRowIndex < dgvHTDG.RowCount) Then
            Try
                'Dim hs = CType(dgvHTDG.Rows(currentRowIndex).DataBoundItem, HocSinhDTO)

                MessageBox.Show("Hệ Số Điểm không đúng.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dgvHTDG.CancelEdit()
                'storeValue = hs.NgaySinh
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub dgvHTDG_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvHTDG.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            ' Get the current cell location.
            Dim currentRowIndex As Integer = dgvHTDG.CurrentCellAddress.Y 'current row selected
            'Verify that indexing OK
            If (-1 < currentRowIndex And currentRowIndex < dgvHTDG.RowCount) Then
                Try
                    Dim htdg = CType(dgvHTDG.Rows(currentRowIndex).DataBoundItem, HinhThucDanhGiaDTO)
                    listHTDG.Remove(htdg)
                    buildDGVHTDG()
                Catch ex As Exception
                    Console.WriteLine(ex.StackTrace)
                End Try
            End If
        End If
    End Sub

    Private Sub cbLoaiDiem_SELECTedIndexChanged(sender As Object, e As EventArgs) Handles cbLoaiDiem.SELECTedIndexChanged


    End Sub
    Private Sub loadChuongTrinh()
        'Load Chuong Trinh list to combobox

        Dim result = ctBus.selectALL(Me.listCT)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Chương Trình không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbChuongTrinh.DataSource = New BindingSource(listCT, String.Empty)
        cbChuongTrinh.DisplayMember = "TenCT"
        cbChuongTrinh.ValueMember = "MaCT"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbChuongTrinh.DataSource)
        myCurrencyManager.Refresh()
        If (listCT.Count > 0) Then
            cbChuongTrinh.SELECTedIndex = 0
        End If

    End Sub

    Private Sub loadLoaiDiem()
        'Load Loai Diem list to combobox
        Dim listLoaiDiem = New List(Of LoaiDiemDTO)
        Dim result = loaidiemBus.selectAll(listLoaiDiem)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Loại Điểm không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Me.Close()
            Return
        End If
        cbLoaiDiem.DataSource = New BindingSource(listLoaiDiem, String.Empty)
        cbLoaiDiem.DisplayMember = "LoaiDiem"
        cbLoaiDiem.ValueMember = "MaLoaiDiem"
        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(cbLoaiDiem.DataSource)
        myCurrencyManager.Refresh()
        If (listLoaiDiem.Count > 0) Then
            cbLoaiDiem.SELECTedIndex = 0
        End If

    End Sub
    Private Sub loadListMonHoc()

        ' Load LoaiHocSinh list
        Dim result As Result
        result = monhocBus.selectAll(Me.listMonHocOnDB)
        If (result.FlagResult = False) Then
            MessageBox.Show("Lấy danh sách Môn học không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
            Return
        End If
    End Sub

    Private Sub buildDGVMonHoc()
        dgvMonHoc.DataSource = Nothing
        dgvMonHoc.Columns.Clear()

        dgvMonHoc.AutoGenerateColumns = False
        dgvMonHoc.AllowUserToAddRows = False
        dgvMonHoc.DataSource = listMonHoc

        Dim clMaMon = New DataGridViewTextBoxColumn()
        clMaMon.Name = "MaMonHoc"
        clMaMon.HeaderText = "Mã Môn Học"
        clMaMon.DataPropertyName = "MaMonHoc"
        dgvMonHoc.Columns.Add(clMaMon)

        Dim clTenMon = New DataGridViewTextBoxColumn()
        clTenMon.Name = "MonHoc"
        clTenMon.HeaderText = "Tên Môn Học"
        clTenMon.DataPropertyName = "MonHoc"
        dgvMonHoc.Columns.Add(clTenMon)
        'clTenMon.ReadOnly = True

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvMonHoc.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub buildDGVMonHocChuongTrinh()
        dgvMonHocChuongTrinh.DataSource = Nothing
        dgvMonHocChuongTrinh.Columns.Clear()

        dgvMonHocChuongTrinh.AutoGenerateColumns = False
        dgvMonHocChuongTrinh.AllowUserToAddRows = False
        dgvMonHocChuongTrinh.DataSource = listMonHocChuongTrinh

        Dim clMaMon = New DataGridViewTextBoxColumn()
        clMaMon.Name = "MaMonHoc"
        clMaMon.HeaderText = "Mã Môn Học"
        clMaMon.DataPropertyName = "MaMonHoc"
        dgvMonHocChuongTrinh.Columns.Add(clMaMon)
        clMaMon.ReadOnly = True

        Dim clTenMon = New DataGridViewTextBoxColumn()
        clTenMon.Name = "TenMonHoc"
        clTenMon.HeaderText = "Tên Môn Học"
        clTenMon.DataPropertyName = "TenMonHoc"
        dgvMonHocChuongTrinh.Columns.Add(clTenMon)
        clTenMon.ReadOnly = True

        Dim clHeSoMon = New DataGridViewTextBoxColumn()
        clHeSoMon.Name = "HeSoMon"
        clHeSoMon.HeaderText = "Hệ Số Môn"
        clHeSoMon.DataPropertyName = "HeSoMon"
        dgvMonHocChuongTrinh.Columns.Add(clHeSoMon)
        clHeSoMon.ReadOnly = False

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvMonHocChuongTrinh.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub buildDGVHTDG()
        dgvHTDG.DataSource = Nothing
        dgvHTDG.Columns.Clear()

        dgvHTDG.AutoGenerateColumns = False
        dgvHTDG.AllowUserToAddRows = False
        dgvHTDG.DataSource = listHTDG

        Dim clMaLoaiDiem = New DataGridViewTextBoxColumn()
        clMaLoaiDiem.Name = "TenLoaiDiem"
        clMaLoaiDiem.HeaderText = "Tên Loại Điểm"
        clMaLoaiDiem.DataPropertyName = "TenLoaiDiem"
        dgvHTDG.Columns.Add(clMaLoaiDiem)
        clMaLoaiDiem.ReadOnly = True

        Dim clHeSoDiem = New DataGridViewTextBoxColumn()
        clHeSoDiem.Name = "HeSoDiem"
        clHeSoDiem.HeaderText = "Hệ Số Điểm"
        clHeSoDiem.DataPropertyName = "HeSoDiem"
        dgvHTDG.Columns.Add(clHeSoDiem)
        clHeSoDiem.ReadOnly = False

        Dim myCurrencyManager As CurrencyManager = Me.BindingContext(dgvHTDG.DataSource)
        myCurrencyManager.Refresh()
    End Sub

    Private Sub btnThemLoaiDiem_Click(sender As Object, e As EventArgs) Handles btnThemLoaiDiem.Click
        Try
            Dim loaidiem = CType(cbLoaiDiem.SELECTedItem, LoaiDiemDTO)
            Dim htdg = New HinhThucDanhGiaDTO(1, 1, loaidiem.MaLoaiDiem, loaidiem.HeSoMacDinh, loaidiem.LoaiDiem)
            listHTDG.Add(htdg)
            buildDGVHTDG()
        Catch ex As Exception
            System.Console.WriteLine(ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
        Dim ctUpdated = New ChuongTrinhDTO()
        Dim ct = CType(cbChuongTrinh.SELECTedItem, ChuongTrinhDTO)
        '1. Mapping data from GUI control
        ctUpdated.TenCT = txtTenCT.Text
        ctUpdated.NgayTao = dtpNgayTao.Value
        ctUpdated.MaCT = ct.MaCT
        ctUpdated.ListCTTT = Me.listMonHocChuongTrinh
        '2. Business .....
        If (ctBus.isValidName(ctUpdated) = False) Then
            MessageBox.Show("Tên Chương Trình không đúng. Vui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTenCT.Focus()
            Return
        End If
        '3. Insert to DB
        Dim result As Result
        result = ctBus.updateCT_Cascade(ctUpdated)
        If (result.FlagResult = True) Then
            MessageBox.Show("Cập Nhật Chương Trình thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            loadChuongTrinh()

        Else
            MessageBox.Show("Cập Nhật Chương Trình không thành công.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            System.Console.WriteLine(result.SystemMessage)
        End If
    End Sub
End Class