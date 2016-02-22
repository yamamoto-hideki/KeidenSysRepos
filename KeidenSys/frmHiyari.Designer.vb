<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHiyari
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHiyari))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPlace = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtJOB = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rb3 = New System.Windows.Forms.RadioButton()
        Me.rb2 = New System.Windows.Forms.RadioButton()
        Me.rb1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rb5 = New System.Windows.Forms.RadioButton()
        Me.rb4 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rb7 = New System.Windows.Forms.RadioButton()
        Me.rb6 = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCont = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDone = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtConf = New System.Windows.Forms.TextBox()
        Me.btnM = New System.Windows.Forms.Button()
        Me.btnGM = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lv1 = New System.Windows.Forms.ListView()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnReg = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbNendo = New System.Windows.Forms.ComboBox()
        Me.rb8 = New System.Windows.Forms.RadioButton()
        Me.rb9 = New System.Windows.Forms.RadioButton()
        Me.lbMode = New System.Windows.Forms.Label()
        Me.cmbKind = New System.Windows.Forms.ComboBox()
        Me.btnUnGM = New System.Windows.Forms.Button()
        Me.btnUnM = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ch1 = New System.Windows.Forms.CheckBox()
        Me.cmbCond1 = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.rb11 = New System.Windows.Forms.RadioButton()
        Me.rb10 = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnUnSelect = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnSelPhoto = New System.Windows.Forms.Button()
        Me.btnDispPhoto = New System.Windows.Forms.Button()
        Me.btnDelPhoto = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(914, 593)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 27)
        Me.btnClose.TabIndex = 37
        Me.btnClose.Text = "戻る"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(4, 54)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(109, 19)
        Me.DateTimePicker1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "作成日"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "発生日"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(117, 54)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(109, 19)
        Me.DateTimePicker2.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(228, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "発生時刻"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker3.Location = New System.Drawing.Point(230, 54)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.ShowUpDown = True
        Me.DateTimePicker3.Size = New System.Drawing.Size(55, 19)
        Me.DateTimePicker3.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "発行者"
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbName.Location = New System.Drawing.Point(50, 11)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(43, 14)
        Me.lbName.TabIndex = 9
        Me.lbName.Text = "発行者"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "場所"
        '
        'txtPlace
        '
        Me.txtPlace.Location = New System.Drawing.Point(4, 93)
        Me.txtPlace.Name = "txtPlace"
        Me.txtPlace.Size = New System.Drawing.Size(174, 19)
        Me.txtPlace.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "作業件名"
        '
        'txtJOB
        '
        Me.txtJOB.Location = New System.Drawing.Point(4, 133)
        Me.txtJOB.Name = "txtJOB"
        Me.txtJOB.Size = New System.Drawing.Size(281, 19)
        Me.txtJOB.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb3)
        Me.GroupBox1.Controls.Add(Me.rb2)
        Me.GroupBox1.Controls.Add(Me.rb1)
        Me.GroupBox1.Location = New System.Drawing.Point(291, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(244, 49)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ヒヤリハットの評価"
        '
        'rb3
        '
        Me.rb3.AutoSize = True
        Me.rb3.Location = New System.Drawing.Point(120, 21)
        Me.rb3.Name = "rb3"
        Me.rb3.Size = New System.Drawing.Size(105, 16)
        Me.rb3.TabIndex = 16
        Me.rb3.TabStop = True
        Me.rb3.Text = "経過観察が必要"
        Me.rb3.UseVisualStyleBackColor = True
        '
        'rb2
        '
        Me.rb2.AutoSize = True
        Me.rb2.Location = New System.Drawing.Point(63, 21)
        Me.rb2.Name = "rb2"
        Me.rb2.Size = New System.Drawing.Size(47, 16)
        Me.rb2.TabIndex = 15
        Me.rb2.TabStop = True
        Me.rb2.Text = "軽微"
        Me.rb2.UseVisualStyleBackColor = True
        '
        'rb1
        '
        Me.rb1.AutoSize = True
        Me.rb1.Location = New System.Drawing.Point(6, 21)
        Me.rb1.Name = "rb1"
        Me.rb1.Size = New System.Drawing.Size(47, 16)
        Me.rb1.TabIndex = 14
        Me.rb1.TabStop = True
        Me.rb1.Text = "重大"
        Me.rb1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rb5)
        Me.GroupBox2.Controls.Add(Me.rb4)
        Me.GroupBox2.Location = New System.Drawing.Point(291, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(127, 49)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ヒヤリハットの予想"
        '
        'rb5
        '
        Me.rb5.AutoSize = True
        Me.rb5.Location = New System.Drawing.Point(59, 21)
        Me.rb5.Name = "rb5"
        Me.rb5.Size = New System.Drawing.Size(59, 16)
        Me.rb5.TabIndex = 18
        Me.rb5.TabStop = True
        Me.rb5.Text = "不可能"
        Me.rb5.UseVisualStyleBackColor = True
        '
        'rb4
        '
        Me.rb4.AutoSize = True
        Me.rb4.Location = New System.Drawing.Point(9, 21)
        Me.rb4.Name = "rb4"
        Me.rb4.Size = New System.Drawing.Size(47, 16)
        Me.rb4.TabIndex = 17
        Me.rb4.TabStop = True
        Me.rb4.Text = "可能"
        Me.rb4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rb7)
        Me.GroupBox3.Controls.Add(Me.rb6)
        Me.GroupBox3.Location = New System.Drawing.Point(430, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(105, 49)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "改善の必要"
        '
        'rb7
        '
        Me.rb7.AutoSize = True
        Me.rb7.Location = New System.Drawing.Point(59, 21)
        Me.rb7.Name = "rb7"
        Me.rb7.Size = New System.Drawing.Size(35, 16)
        Me.rb7.TabIndex = 20
        Me.rb7.TabStop = True
        Me.rb7.Text = "無"
        Me.rb7.UseVisualStyleBackColor = True
        '
        'rb6
        '
        Me.rb6.AutoSize = True
        Me.rb6.Location = New System.Drawing.Point(9, 21)
        Me.rb6.Name = "rb6"
        Me.rb6.Size = New System.Drawing.Size(35, 16)
        Me.rb6.TabIndex = 19
        Me.rb6.TabStop = True
        Me.rb6.Text = "有"
        Me.rb6.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 12)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "ヒヤリハット内容"
        '
        'txtCont
        '
        Me.txtCont.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCont.Location = New System.Drawing.Point(4, 170)
        Me.txtCont.Multiline = True
        Me.txtCont.Name = "txtCont"
        Me.txtCont.Size = New System.Drawing.Size(531, 143)
        Me.txtCont.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 316)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 12)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "実施した対策内容"
        '
        'txtDone
        '
        Me.txtDone.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDone.Location = New System.Drawing.Point(4, 331)
        Me.txtDone.Multiline = True
        Me.txtDone.Name = "txtDone"
        Me.txtDone.Size = New System.Drawing.Size(531, 119)
        Me.txtDone.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 453)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 12)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "効果の確認(管理責任者記入)"
        '
        'txtConf
        '
        Me.txtConf.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtConf.Location = New System.Drawing.Point(4, 468)
        Me.txtConf.Multiline = True
        Me.txtConf.Name = "txtConf"
        Me.txtConf.Size = New System.Drawing.Size(531, 119)
        Me.txtConf.TabIndex = 13
        '
        'btnM
        '
        Me.btnM.Location = New System.Drawing.Point(808, 4)
        Me.btnM.Name = "btnM"
        Me.btnM.Size = New System.Drawing.Size(84, 27)
        Me.btnM.TabIndex = 30
        Me.btnM.Text = "M承認"
        Me.btnM.UseVisualStyleBackColor = True
        '
        'btnGM
        '
        Me.btnGM.Location = New System.Drawing.Point(628, 4)
        Me.btnGM.Name = "btnGM"
        Me.btnGM.Size = New System.Drawing.Size(84, 27)
        Me.btnGM.TabIndex = 28
        Me.btnGM.Text = "GM承認"
        Me.btnGM.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(541, 39)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 12)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "登録済み一覧"
        '
        'lv1
        '
        Me.lv1.Location = New System.Drawing.Point(541, 54)
        Me.lv1.Name = "lv1"
        Me.lv1.Size = New System.Drawing.Size(441, 259)
        Me.lv1.TabIndex = 32
        Me.lv1.UseCompatibleStateImageBehavior = False
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(543, 356)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(439, 231)
        Me.Chart1.TabIndex = 28
        Me.Chart1.TabStop = False
        Me.Chart1.Text = "Chart1"
        '
        'btnReg
        '
        Me.btnReg.Location = New System.Drawing.Point(4, 593)
        Me.btnReg.Name = "btnReg"
        Me.btnReg.Size = New System.Drawing.Size(68, 27)
        Me.btnReg.TabIndex = 21
        Me.btnReg.Text = "登録・変更"
        Me.btnReg.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(192, 593)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(68, 27)
        Me.btnDel.TabIndex = 23
        Me.btnDel.Text = "ヒヤリ削除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(539, 333)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "年度"
        '
        'cmbNendo
        '
        Me.cmbNendo.FormattingEnabled = True
        Me.cmbNendo.Location = New System.Drawing.Point(574, 329)
        Me.cmbNendo.Name = "cmbNendo"
        Me.cmbNendo.Size = New System.Drawing.Size(81, 20)
        Me.cmbNendo.TabIndex = 33
        '
        'rb8
        '
        Me.rb8.AutoSize = True
        Me.rb8.Location = New System.Drawing.Point(297, 9)
        Me.rb8.Name = "rb8"
        Me.rb8.Size = New System.Drawing.Size(71, 16)
        Me.rb8.TabIndex = 3
        Me.rb8.TabStop = True
        Me.rb8.Text = "新規登録"
        Me.rb8.UseVisualStyleBackColor = True
        '
        'rb9
        '
        Me.rb9.AutoSize = True
        Me.rb9.Location = New System.Drawing.Point(371, 9)
        Me.rb9.Name = "rb9"
        Me.rb9.Size = New System.Drawing.Size(47, 16)
        Me.rb9.TabIndex = 4
        Me.rb9.TabStop = True
        Me.rb9.Text = "変更"
        Me.rb9.UseVisualStyleBackColor = True
        '
        'lbMode
        '
        Me.lbMode.AutoSize = True
        Me.lbMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbMode.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lbMode.Location = New System.Drawing.Point(429, 5)
        Me.lbMode.Name = "lbMode"
        Me.lbMode.Size = New System.Drawing.Size(106, 24)
        Me.lbMode.TabIndex = 36
        Me.lbMode.Text = "新規登録"
        '
        'cmbKind
        '
        Me.cmbKind.FormattingEnabled = True
        Me.cmbKind.Location = New System.Drawing.Point(661, 329)
        Me.cmbKind.Name = "cmbKind"
        Me.cmbKind.Size = New System.Drawing.Size(81, 20)
        Me.cmbKind.TabIndex = 34
        '
        'btnUnGM
        '
        Me.btnUnGM.Location = New System.Drawing.Point(718, 4)
        Me.btnUnGM.Name = "btnUnGM"
        Me.btnUnGM.Size = New System.Drawing.Size(84, 27)
        Me.btnUnGM.TabIndex = 29
        Me.btnUnGM.Text = "GM承認解除"
        Me.btnUnGM.UseVisualStyleBackColor = True
        '
        'btnUnM
        '
        Me.btnUnM.Location = New System.Drawing.Point(898, 4)
        Me.btnUnM.Name = "btnUnM"
        Me.btnUnM.Size = New System.Drawing.Size(84, 27)
        Me.btnUnM.TabIndex = 31
        Me.btnUnM.Text = "M承認解除"
        Me.btnUnM.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(297, 593)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(68, 27)
        Me.btnPrint.TabIndex = 24
        Me.btnPrint.Text = "印刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(371, 593)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(68, 27)
        Me.btnPreview.TabIndex = 25
        Me.btnPreview.Text = "プレビュー"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(419, 530)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 55)
        Me.Label13.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(375, 156)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(160, 12)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "※ここに改行を入れてください。↓"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(375, 316)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(160, 12)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "※ここに改行を入れてください。↓"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(375, 453)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(160, 12)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "※ここに改行を入れてください。↓"
        '
        'ch1
        '
        Me.ch1.AutoSize = True
        Me.ch1.Location = New System.Drawing.Point(766, 331)
        Me.ch1.Name = "ch1"
        Me.ch1.Size = New System.Drawing.Size(67, 16)
        Me.ch1.TabIndex = 35
        Me.ch1.Text = "絞り込み"
        Me.ch1.UseVisualStyleBackColor = True
        '
        'cmbCond1
        '
        Me.cmbCond1.FormattingEnabled = True
        Me.cmbCond1.Location = New System.Drawing.Point(886, 329)
        Me.cmbCond1.Name = "cmbCond1"
        Me.cmbCond1.Size = New System.Drawing.Size(96, 20)
        Me.cmbCond1.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(839, 333)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 12)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "発行者"
        '
        'rb11
        '
        Me.rb11.AutoSize = True
        Me.rb11.Location = New System.Drawing.Point(74, 9)
        Me.rb11.Name = "rb11"
        Me.rb11.Size = New System.Drawing.Size(47, 16)
        Me.rb11.TabIndex = 2
        Me.rb11.Text = "品質"
        Me.rb11.UseVisualStyleBackColor = True
        '
        'rb10
        '
        Me.rb10.AutoSize = True
        Me.rb10.Location = New System.Drawing.Point(12, 9)
        Me.rb10.Name = "rb10"
        Me.rb10.Size = New System.Drawing.Size(47, 16)
        Me.rb10.TabIndex = 1
        Me.rb10.Text = "安全"
        Me.rb10.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rb11)
        Me.GroupBox4.Controls.Add(Me.rb10)
        Me.GroupBox4.Location = New System.Drawing.Point(139, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(136, 30)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'btnUnSelect
        '
        Me.btnUnSelect.Location = New System.Drawing.Point(541, 4)
        Me.btnUnSelect.Name = "btnUnSelect"
        Me.btnUnSelect.Size = New System.Drawing.Size(64, 27)
        Me.btnUnSelect.TabIndex = 27
        Me.btnUnSelect.Text = "選択解除"
        Me.btnUnSelect.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.YellowGreen
        Me.Label12.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label12.Location = New System.Drawing.Point(662, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 12)
        Me.Label12.TabIndex = 50
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.LightGreen
        Me.Label18.ForeColor = System.Drawing.Color.LightGreen
        Me.Label18.Location = New System.Drawing.Point(780, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 12)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Label8"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.YellowGreen
        Me.Label19.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label19.Location = New System.Drawing.Point(884, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 12)
        Me.Label19.TabIndex = 52
        Me.Label19.Text = "Label8"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(824, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 12)
        Me.Label20.TabIndex = 53
        Me.Label20.Text = "安全ヒヤリ"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(928, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 12)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "品質ヒヤリ"
        '
        'btnSelPhoto
        '
        Me.btnSelPhoto.Location = New System.Drawing.Point(184, 93)
        Me.btnSelPhoto.Name = "btnSelPhoto"
        Me.btnSelPhoto.Size = New System.Drawing.Size(53, 19)
        Me.btnSelPhoto.TabIndex = 9
        Me.btnSelPhoto.Text = "無"
        Me.btnSelPhoto.UseVisualStyleBackColor = True
        '
        'btnDispPhoto
        '
        Me.btnDispPhoto.Location = New System.Drawing.Point(467, 593)
        Me.btnDispPhoto.Name = "btnDispPhoto"
        Me.btnDispPhoto.Size = New System.Drawing.Size(68, 27)
        Me.btnDispPhoto.TabIndex = 26
        Me.btnDispPhoto.Text = "画像表示"
        Me.btnDispPhoto.UseVisualStyleBackColor = True
        '
        'btnDelPhoto
        '
        Me.btnDelPhoto.Location = New System.Drawing.Point(118, 593)
        Me.btnDelPhoto.Name = "btnDelPhoto"
        Me.btnDelPhoto.Size = New System.Drawing.Size(68, 27)
        Me.btnDelPhoto.TabIndex = 22
        Me.btnDelPhoto.Text = "画像削除"
        Me.btnDelPhoto.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(183, 78)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 12)
        Me.Label22.TabIndex = 58
        Me.Label22.Text = "画像選択"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(243, 79)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 33)
        Me.PictureBox1.TabIndex = 59
        Me.PictureBox1.TabStop = False
        '
        'frmHiyari
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 626)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btnDelPhoto)
        Me.Controls.Add(Me.btnDispPhoto)
        Me.Controls.Add(Me.btnSelPhoto)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnUnSelect)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cmbCond1)
        Me.Controls.Add(Me.ch1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnUnM)
        Me.Controls.Add(Me.btnUnGM)
        Me.Controls.Add(Me.cmbKind)
        Me.Controls.Add(Me.lbMode)
        Me.Controls.Add(Me.rb9)
        Me.Controls.Add(Me.rb8)
        Me.Controls.Add(Me.cmbNendo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnReg)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.lv1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnGM)
        Me.Controls.Add(Me.btnM)
        Me.Controls.Add(Me.txtConf)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDone)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCont)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtJOB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtPlace)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHiyari"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "ヒヤリハット"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPlace As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtJOB As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb3 As System.Windows.Forms.RadioButton
    Friend WithEvents rb2 As System.Windows.Forms.RadioButton
    Friend WithEvents rb1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rb5 As System.Windows.Forms.RadioButton
    Friend WithEvents rb4 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rb7 As System.Windows.Forms.RadioButton
    Friend WithEvents rb6 As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCont As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDone As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtConf As System.Windows.Forms.TextBox
    Friend WithEvents btnM As System.Windows.Forms.Button
    Friend WithEvents btnGM As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lv1 As System.Windows.Forms.ListView
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btnReg As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbNendo As System.Windows.Forms.ComboBox
    Friend WithEvents rb8 As System.Windows.Forms.RadioButton
    Friend WithEvents rb9 As System.Windows.Forms.RadioButton
    Friend WithEvents lbMode As System.Windows.Forms.Label
    Friend WithEvents cmbKind As System.Windows.Forms.ComboBox
    Friend WithEvents btnUnGM As System.Windows.Forms.Button
    Friend WithEvents btnUnM As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ch1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmbCond1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents rb11 As System.Windows.Forms.RadioButton
    Friend WithEvents rb10 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUnSelect As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnSelPhoto As System.Windows.Forms.Button
    Friend WithEvents btnDispPhoto As System.Windows.Forms.Button
    Friend WithEvents btnDelPhoto As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
