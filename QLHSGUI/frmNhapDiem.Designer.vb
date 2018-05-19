<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapDiem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbMonHoc = New System.Windows.Forms.ComboBox()
        Me.dgvDiemHS = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbLop = New System.Windows.Forms.ComboBox()
        Me.dgvListHS = New System.Windows.Forms.DataGridView()
        Me.btnNhapDiem = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbKhoi = New System.Windows.Forms.ComboBox()
        Me.cbHocKy = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbNamHoc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbLoaiDiem = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDiemSo = New System.Windows.Forms.TextBox()
        CType(Me.dgvDiemHS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListHS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(437, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "Môn Học:"
        '
        'cbMonHoc
        '
        Me.cbMonHoc.FormattingEnabled = True
        Me.cbMonHoc.Location = New System.Drawing.Point(494, 98)
        Me.cbMonHoc.Name = "cbMonHoc"
        Me.cbMonHoc.Size = New System.Drawing.Size(153, 21)
        Me.cbMonHoc.TabIndex = 88
        '
        'dgvDiemHS
        '
        Me.dgvDiemHS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDiemHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiemHS.Location = New System.Drawing.Point(433, 125)
        Me.dgvDiemHS.MultiSELECT = False
        Me.dgvDiemHS.Name = "dgvDiemHS"
        Me.dgvDiemHS.ReadOnly = True
        Me.dgvDiemHS.RowHeadersVisible = False
        Me.dgvDiemHS.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvDiemHS.Size = New System.Drawing.Size(357, 177)
        Me.dgvDiemHS.TabIndex = 87
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = "Lớp:"
        '
        'cbLop
        '
        Me.cbLop.FormattingEnabled = True
        Me.cbLop.Location = New System.Drawing.Point(73, 98)
        Me.cbLop.Name = "cbLop"
        Me.cbLop.Size = New System.Drawing.Size(153, 21)
        Me.cbLop.TabIndex = 85
        '
        'dgvListHS
        '
        Me.dgvListHS.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvListHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListHS.Location = New System.Drawing.Point(12, 125)
        Me.dgvListHS.MultiSELECT = False
        Me.dgvListHS.Name = "dgvListHS"
        Me.dgvListHS.ReadOnly = True
        Me.dgvListHS.RowHeadersVisible = False
        Me.dgvListHS.SELECTionMode = System.Windows.Forms.DataGridViewSELECTionMode.FullRowSELECT
        Me.dgvListHS.Size = New System.Drawing.Size(357, 325)
        Me.dgvListHS.TabIndex = 84
        '
        'btnNhapDiem
        '
        Me.btnNhapDiem.Location = New System.Drawing.Point(512, 409)
        Me.btnNhapDiem.Name = "btnNhapDiem"
        Me.btnNhapDiem.Size = New System.Drawing.Size(125, 23)
        Me.btnNhapDiem.TabIndex = 83
        Me.btnNhapDiem.Text = "Nhập Điểm"
        Me.btnNhapDiem.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(290, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Khối:"
        '
        'cbKhoi
        '
        Me.cbKhoi.FormattingEnabled = True
        Me.cbKhoi.Location = New System.Drawing.Point(339, 14)
        Me.cbKhoi.Name = "cbKhoi"
        Me.cbKhoi.Size = New System.Drawing.Size(125, 21)
        Me.cbKhoi.TabIndex = 77
        '
        'cbHocKy
        '
        Me.cbHocKy.FormattingEnabled = True
        Me.cbHocKy.Location = New System.Drawing.Point(443, 52)
        Me.cbHocKy.Name = "cbHocKy"
        Me.cbHocKy.Size = New System.Drawing.Size(153, 21)
        Me.cbHocKy.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(139, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Năm Học:"
        '
        'cbNamHoc
        '
        Me.cbNamHoc.FormattingEnabled = True
        Me.cbNamHoc.Location = New System.Drawing.Point(197, 52)
        Me.cbNamHoc.Name = "cbNamHoc"
        Me.cbNamHoc.Size = New System.Drawing.Size(153, 21)
        Me.cbNamHoc.TabIndex = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(392, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Học Kỳ:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(450, 331)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Loại Điểm:"
        '
        'cbLoaiDiem
        '
        Me.cbLoaiDiem.FormattingEnabled = True
        Me.cbLoaiDiem.Location = New System.Drawing.Point(512, 328)
        Me.cbLoaiDiem.Name = "cbLoaiDiem"
        Me.cbLoaiDiem.Size = New System.Drawing.Size(153, 21)
        Me.cbLoaiDiem.TabIndex = 91
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(451, 371)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Điểm Số:"
        '
        'txtDiemSo
        '
        Me.txtDiemSo.Location = New System.Drawing.Point(512, 368)
        Me.txtDiemSo.Name = "txtDiemSo"
        Me.txtDiemSo.Size = New System.Drawing.Size(100, 20)
        Me.txtDiemSo.TabIndex = 93
        '
        'frmNhapDiem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 519)
        Me.Controls.Add(Me.txtDiemSo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbLoaiDiem)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbMonHoc)
        Me.Controls.Add(Me.dgvDiemHS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbLop)
        Me.Controls.Add(Me.dgvListHS)
        Me.Controls.Add(Me.btnNhapDiem)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbKhoi)
        Me.Controls.Add(Me.cbHocKy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbNamHoc)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmNhapDiem"
        Me.Text = "Nhập Điểm"
        CType(Me.dgvDiemHS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListHS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents cbMonHoc As ComboBox
    Friend WithEvents dgvDiemHS As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents cbLop As ComboBox
    Friend WithEvents dgvListHS As DataGridView
    Friend WithEvents btnNhapDiem As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cbKhoi As ComboBox
    Friend WithEvents cbHocKy As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbNamHoc As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbLoaiDiem As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDiemSo As TextBox
End Class
