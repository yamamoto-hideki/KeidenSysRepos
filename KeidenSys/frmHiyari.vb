'=========================================
'
'   Copyright (c) Sanwakeiden Co.,Ltd.
'
'   form name       :frmHiyari.vb
'   Description     :ヒヤリハット画面
'   Written         :2016.01.20
'   Author          :yamamoto hideki
'   Update          :
'   Reason          :
'
'=========================================
Option Explicit On
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmHiyari

    '新規登録 : 0
    '閲覧・変更 : 1
    Private iMode As Integer = 0
    Dim iRowINDEX2 As Integer = -1

    Private sPhoto As String = ""

    '------------------------------------
    '   フォームロード
    '------------------------------------
    Private Sub frmHiyari_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ログイン名
        'Me.lbLogin.Text = g_sName
        '発行者
        Me.lbName.Text = ""

        '画像選択
        Me.btnSelPhoto.Text = "無"

        If g_sAuthority = "0" Then
            '担当者
            Me.txtConf.Enabled = False
            Me.btnM.Enabled = False
            Me.btnUnM.Enabled = False
            Me.btnGM.Enabled = False
            Me.btnUnGM.Enabled = False
            Me.btnReg.Enabled = True
            Me.btnDel.Enabled = True
        End If
        If g_sAuthority = "1" Then
            '管責
            Me.txtConf.Enabled = True
            Me.btnM.Enabled = True
            Me.btnUnM.Enabled = True
            Me.btnGM.Enabled = False
            Me.btnUnGM.Enabled = False
            Me.btnReg.Enabled = True
            Me.btnDel.Enabled = True
        End If
        If g_sAuthority = "2" Then
            '経責
            Me.txtConf.Enabled = False
            Me.btnM.Enabled = False
            Me.btnUnM.Enabled = False
            Me.btnGM.Enabled = True
            Me.btnUnGM.Enabled = True
            Me.btnReg.Enabled = False
            Me.btnDel.Enabled = False
        End If

        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy年MM月dd日"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy年MM月dd日"
        DateTimePicker3.Format = DateTimePickerFormat.Custom
        DateTimePicker3.CustomFormat = "H:mm"

        DateTimePicker1.Text = DateTime.Now
        DateTimePicker2.Text = DateTime.Now
        DateTimePicker3.Text = DateTime.Now

        Me.lv1.FullRowSelect = True
        Me.lv1.GridLines = True
        Me.lv1.View = View.Details
        Me.lv1.HideSelection = False
        Me.lv1.MultiSelect = False

        Me.lv1.Columns.Add("作成日", 0, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("発生日", 72, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("発行者", 68, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("作業件名", 151, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("評", 25, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("改", 25, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("M", 25, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("GM", 30, HorizontalAlignment.Left)
        Me.lv1.Columns.Add("RowIndex", 0, HorizontalAlignment.Left)
        '2016/02/08 add k.sato 項目の追加
        Me.lv1.Columns.Add("CATEGORY", 0, HorizontalAlignment.Left)
        '20160222 yamamoto add
        Me.lv1.Columns.Add("画像", 25, HorizontalAlignment.Left)

        'コンボボックス
        Dim iNendo As Integer = g_get_nendo()
        Me.cmbNendo.Items.Clear()
        Me.cmbNendo.BeginUpdate()
        Me.cmbNendo.Items.Add(iNendo)
        Me.cmbNendo.Items.Add(iNendo - 1)
        Me.cmbNendo.Items.Add(iNendo - 2)
        Me.cmbNendo.Items.Add(iNendo - 3)
        Me.cmbNendo.Items.Add(iNendo - 4)
        Me.cmbNendo.EndUpdate()
        Me.cmbNendo.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbNendo.SelectedIndex = 0

        Me.cmbKind.Items.Clear()
        Me.cmbKind.BeginUpdate()
        Me.cmbKind.Items.Add("累計")
        Me.cmbKind.Items.Add("月別")
        Me.cmbKind.EndUpdate()
        Me.cmbKind.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbKind.SelectedIndex = 0

        '発行者コンボボックス値セット
        set_combo_cond1()
        Me.ch1.Checked = False
        Me.cmbCond1.Enabled = False

        Me.rb1.Checked = True '重大
        Me.rb4.Checked = True '可能
        Me.rb6.Checked = True '有

        Me.rb8.Checked = True '新規登録

        '2016/02/08 add k.sato
        '変更ボタンを押せない
        '項目の追加　安全・品質
        Me.rb9.Enabled = False '変更不可
        Me.rb10.Checked = True

        '新規登録
        iMode = 0

        'リスト表示
        disp_lv()

        'グラフタイトル
        Chart1.Titles.Add("ヒヤリハット発生数")

        'グラフ表示
        disp_chart()

        clear_box()

    End Sub

    '------------------------------------
    '   発行者コンボボックス値セット
    '------------------------------------
    Private Sub set_combo_cond1()

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim sSQL As String

        lv1.Items.Clear()

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                '経責以外
                sSQL = "select ID,NAME from M_USER where AUTHORITY != 2 order by ID"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                Me.cmbCond1.Items.Clear()
                Me.cmbCond1.BeginUpdate()

                While sdr.Read
                    Dim item As ExComboBox
                    item = New ExComboBox(sdr.Item("ID"), sdr.Item("NAME"))
                    cmbCond1.Items.Add(item)
                End While

                Me.cmbCond1.EndUpdate()
                Me.cmbCond1.DropDownStyle = ComboBoxStyle.DropDownList
                Me.cmbCond1.SelectedIndex = 0

                sdr.Close()
                sqlCmd.Dispose()
                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

    End Sub

    '------------------------------------
    '   リストビュー表示更新
    '------------------------------------
    Private Sub disp_lv()

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim sSQL As String

        lv1.Items.Clear()

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                sSQL = "select T1.RowINDEX,T1.M_YEAR,T1.M_MONTH,T1.M_DAY," &
                            "T1.H_YEAR,T1.H_MONTH,T1.H_DAY,T1.H_HOUR,T1.H_MINUTE," &
                            "T1.PLACE,T1.JOB,T1.CONT,T1.DO,T1.CONF," &
                            "T1.JUDGE,T1.FORECAST,T1.IMPROVEMENT," &
                            "T1.M,T1.GM,T1.CATEGORY," &
                            "T1.USER_ID,M1.NAME,M1.AUTHORITY," &
                            "case when PHOTO IS NULL then 0 else 1 end PHOTO " &
                        "from T_HIYARIHATT AS T1 LEFT JOIN M_USER AS M1 ON T1.USER_ID = M1.ID " &
                        "order by H_YEAR desc,convert(int,H_MONTH) desc,convert(int,H_DAY) desc,USER_ID"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                While sdr.Read

                    Dim itemx As New ListViewItem
                    '作成日
                    itemx.Text = g_NullConvert(sdr.Item("M_YEAR")) & "/" & g_NullConvert(sdr.Item("M_MONTH")) & "/" & g_NullConvert(sdr.Item("M_DAY"))
                    '発生日
                    itemx.SubItems.Add(g_NullConvert(sdr.Item("H_YEAR")) & "/" & g_NullConvert(sdr.Item("H_MONTH")) & "/" & g_NullConvert(sdr.Item("H_DAY")))
                    '発行者
                    itemx.SubItems.Add(g_NullConvert(sdr.Item("NAME")))
                    '作業件名
                    itemx.SubItems.Add(g_NullConvert(sdr.Item("JOB")))
                    '評価
                    itemx.SubItems.Add(g_get_JUDGE(g_NullConvert(sdr.Item("JUDGE"))))
                    '改善
                    itemx.SubItems.Add(g_get_IMPROVE(g_NullConvert(sdr.Item("IMPROVEMENT"))))
                    'M
                    itemx.SubItems.Add(g_get_stamp(g_NullConvert(sdr.Item("M"))))
                    'GM
                    itemx.SubItems.Add(g_get_stamp(g_NullConvert(sdr.Item("GM"))))
                    'RowINDEX
                    itemx.SubItems.Add(g_NullConvert(sdr.Item("RowINDEX")))

                    '2016/02/08 add k.sato 安全・品質項目追加
                    itemx.SubItems.Add(g_NullConvert(sdr.Item("CATEGORY")))

                    '20160222 yamamoto add start
                    If sdr.Item("PHOTO") = 0 Then
                        itemx.SubItems.Add("")
                    ElseIf sdr.Item("PHOTO") = 1 Then
                        '画像がある場合
                        itemx.SubItems.Add("●")
                    End If
                    '20160222 yamamoto add end

                    '2016/02/08 add k.sato 安全・品質の色づけ
                    If sdr.Item("CATEGORY") = 0 Then
                        itemx.BackColor = Color.LightGreen
                    ElseIf sdr.Item("CATEGORY") = 1 Then
                        itemx.BackColor = Color.YellowGreen
                    End If

                    lv1.Items.Add(itemx)

                End While

                sdr.Close()
                sqlCmd.Dispose()
                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

    End Sub

    '------------------------------------
    '   登録・変更ボタン押下
    '------------------------------------
    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer

        Dim iRowINDEX As Integer = 0
        Dim sUserID As String = "" '社員番号
        Dim sPlace As String = "" '場所
        Dim sJOB As String = "" '作業件名
        Dim sCont As String = "" 'ヒヤリ内容
        Dim sDo As String = "" '実施した対策
        Dim sConf As String = "" '効果の確認
        Dim iJudge As Integer = 0 'ヒヤリの評価
        Dim iForecast As Integer = 0 'ヒヤリの予想
        Dim iImprovement As Integer = 0 '改善の必要

        '2016/02/08 add k.sato 項目追加
        Dim iCategory As Integer = 0 '安全・品質
        Dim bPhoto As Byte()

        Dim iSelected As Integer = 0 '選択行

        If iMode = 1 Then
            iSelected = Me.lv1.SelectedItems(0).Index
        End If

        If iMode = 1 And iRowINDEX2 < 0 Then
            g_disp_mess_ok_error("変更するヒヤリを選択してください。")
            Exit Sub
        End If
        If iMode = 1 And iRowINDEX2 > 0 And g_sAuthority = "0" Then
            '管責、経責は変更できる
            If Me.lv1.Items(iSelected).SubItems(2).Text <> g_sName Then
                g_disp_mess_ok_error("発行者以外は変更できません。")
                Exit Sub
            End If
            If g_sAuthority = "0" And Me.lv1.Items(iSelected).SubItems(6).Text = "承" Then
                g_disp_mess_ok_error("承認済みのヒヤリは変更できません。")
                Exit Sub
            End If
        End If

        sUserID = Trim(g_sID)
        sPlace = Trim(Me.txtPlace.Text)

        If sPlace = "" Then
            g_disp_mess_ok_error("場所を入力してください。")
            Me.txtPlace.Focus()
            Exit Sub
        End If

        sJOB = Trim(Me.txtJOB.Text)

        If sJOB = "" Then
            g_disp_mess_ok_error("作業件名を入力してください。")
            Me.txtJOB.Focus()
            Exit Sub
        End If

        sCont = Trim(Me.txtCont.Text)

        If sCont = "" Then
            g_disp_mess_ok_error("ヒヤリハット内容を入力してください。")
            Me.txtCont.Focus()
            Exit Sub
        End If

        If g_disp_mess_okno_info("新規登録もしくは変更をしますか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        sDo = Trim(Me.txtDone.Text)

        '2016/02/08 add k.sato 安全・品質ヒヤリ追加
        If Me.rb10.Checked Then
            iCategory = 0 '安全
        Else
            iCategory = 1 '品質
        End If

        If iMode = 0 Then
            '新規作成
            sConf = ""
        Else
            '変更
            sConf = Trim(Me.txtConf.Text)
        End If

        If Me.rb1.Checked Then
            iJudge = 0 '重大
        ElseIf Me.rb2.Checked Then
            iJudge = 1 '軽微
        Else
            iJudge = 2 '経過観察が必要
        End If

        If Me.rb4.Checked Then
            iForecast = 0 '可能
        Else
            iForecast = 1 '不可能
        End If

        If Me.rb6.Checked Then
            iImprovement = 0 '有
        Else
            iImprovement = 1 '無
        End If

        iRowINDEX = get_rowindex()

        cn = New System.Data.SqlClient.SqlConnection()
        cn.ConnectionString = DB_STRING
        cn.Open()

        Tran = cn.BeginTransaction

        Using cn

            Try

                sqlCmd = New SqlCommand()
                sqlCmd.Connection = cn
                sqlCmd.Transaction = Tran

                If iMode = 0 Then
                    '新規登録
                    sSQL = "insert into T_HIYARIHATT " &
                               "(RowINDEX,M_YEAR,M_MONTH,M_DAY," &
                               "H_YEAR,H_MONTH,H_DAY,H_HOUR,H_MINUTE," &
                               "USER_ID,PLACE,JOB,CONT,DO,CONF," &
                               "JUDGE,FORECAST,IMPROVEMENT,CATEGORY,M,GM) " &
                           "values " &
                               "(" & iRowINDEX + 1 & ",'" & Me.DateTimePicker1.Value.Year & "','" & Me.DateTimePicker1.Value.Month & "','" & Me.DateTimePicker1.Value.Day & "'," &
                               "'" & Me.DateTimePicker2.Value.Year & "','" & Me.DateTimePicker2.Value.Month & "','" & Me.DateTimePicker2.Value.Day & "','" & Me.DateTimePicker3.Value.Hour & "','" & Me.DateTimePicker3.Value.Minute & "'," &
                               "'" & sUserID & "','" & sPlace & "','" & sJOB & "','" & sCont & "','" & sDo & "','" & sConf & "'," &
                               iJudge & "," & iForecast & "," & iImprovement & "," & iCategory & ",0,0)"

                Else
                    '変更 
                    sSQL = "update T_HIYARIHATT " &
                            "set M_YEAR = '" & Me.DateTimePicker1.Value.Year & "'," &
                                "M_MONTH = '" & Me.DateTimePicker1.Value.Month & "'," &
                                "M_DAY = '" & Me.DateTimePicker1.Value.Day & "'," &
                                "H_YEAR = '" & Me.DateTimePicker2.Value.Year & "'," &
                                "H_MONTH = '" & Me.DateTimePicker2.Value.Month & "'," &
                                "H_DAY = '" & Me.DateTimePicker2.Value.Day & "'," &
                                "H_HOUR = '" & Me.DateTimePicker3.Value.Hour & "'," &
                                "H_MINUTE = '" & Me.DateTimePicker3.Value.Minute & "'," &
                                "PLACE = '" & sPlace & "'," &
                                "JOB = '" & sJOB & "'," &
                                "CONT = '" & sCont & "'," &
                                "DO = '" & sDo & "'," &
                                "CONF = '" & sConf & "'," &
                                "JUDGE = " & iJudge & "," &
                                "FORECAST = " & iForecast & "," &
                                "IMPROVEMENT = " & iImprovement & " ," &
                                "CATEGORY = " & iCategory & " " &
                            "where RowINDEX = " & iRowINDEX2

                End If

                sqlCmd.CommandText = sSQL
                iResult = sqlCmd.ExecuteNonQuery()

                If iResult < 1 Then
                    Tran.Rollback()
                    g_disp_mess_ok_error("データベースの更新に失敗しました。")
                    Exit Sub
                End If

                '画像登録
                If sPhoto <> "" Then

                    bPhoto = g_getPhoto(sPhoto)

                    If iMode = 0 Then
                        sSQL = "update T_HIYARIHATT set PHOTO = @pic " &
                                "where RowINDEX = " & iRowINDEX + 1
                    Else
                        sSQL = "update T_HIYARIHATT set PHOTO = @pic " &
                                "where RowINDEX = " & iRowINDEX2
                    End If

                    sqlCmd.Parameters.Add("@pic", SqlDbType.Binary, bPhoto.Length).Value = bPhoto

                    sqlCmd.CommandText = sSQL
                    iResult = sqlCmd.ExecuteNonQuery()

                    sPhoto = ""

                    If iResult < 1 Then
                        Tran.Rollback()
                        g_disp_mess_ok_error("データベースの更新に失敗しました。")
                        Exit Sub
                    End If

                End If

                sqlCmd.Dispose()
                Tran.Commit()
                cn.Close()

            Catch ex As Exception
                Tran.Rollback()
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        Tran.Dispose()

        disp_lv()
        disp_chart()
        clear_box()

        If iMode = 1 Then
            '変更された行を再選択
            Me.lv1.Items(iSelected).Selected = True
        Else
            send_mail()
        End If

    End Sub

    '------------------------------------
    '   削除ボタン押下
    '------------------------------------
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer

        Dim iRowINDEX As Integer = 0

        If Me.lv1.SelectedItems.Count < 1 Then
            g_disp_mess_ok_error("削除するヒヤリハットを選択してください。")
            Exit Sub
        End If

        iRowINDEX = Me.lv1.Items(Me.lv1.SelectedItems(0).Index).SubItems(8).Text

        If iRowINDEX < 1 Then
            g_disp_mess_ok_error("削除するヒヤリハットを選択してください。")
            Exit Sub
        End If

        If g_sAuthority = "0" And Me.lv1.Items(Me.lv1.SelectedItems(0).Index).SubItems(6).Text = "承" Then
            g_disp_mess_ok_error("承認済みのヒヤリは削除できません。")
            Exit Sub
        End If
        If Me.lv1.Items(Me.lv1.SelectedItems(0).Index).SubItems(2).Text <> g_sName And g_sAuthority = "0" Then
            '管責、経責は削除できる
            g_disp_mess_ok_error("発行者以外は削除できません。")
            Exit Sub
        End If

        If g_disp_mess_okno_info("ヒヤリを削除しますか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        cn = New System.Data.SqlClient.SqlConnection()
        cn.ConnectionString = DB_STRING
        cn.Open()

        Tran = cn.BeginTransaction

        Using cn

            Try

                sqlCmd = New SqlCommand()
                sqlCmd.Connection = cn
                sqlCmd.Transaction = Tran

                sSQL = "delete from T_HIYARIHATT where RowINDEX = " & iRowINDEX

                sqlCmd.CommandText = sSQL
                iResult = sqlCmd.ExecuteNonQuery()

                If iResult < 1 Then
                    Tran.Rollback()
                    g_disp_mess_ok_error("データベースの更新に失敗しました。")
                    Exit Sub
                End If

                sqlCmd.Dispose()

                Tran.Commit()

                cn.Close()

            Catch ex As Exception
                Tran.Rollback()
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        disp_lv()
        disp_chart()
        clear_box()

    End Sub

    '------------------------------------
    '   GMボタン押下
    '------------------------------------
    Private Sub btnGM_Click(sender As Object, e As EventArgs) Handles btnGM.Click

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer
        Dim iSelected As Integer = -1

        If iRowINDEX2 < 0 Then
            g_disp_mess_ok_error("承認するヒヤリを選択してください。")
            Exit Sub
        End If

        iSelected = Me.lv1.SelectedItems(0).Index

        If Me.lv1.Items(iSelected).SubItems(6).Text <> "承" Then
            g_disp_mess_ok_error("管責が承認するまで、経責が承認することはできません。")
            Exit Sub
        End If

        cn = New System.Data.SqlClient.SqlConnection()
        cn.ConnectionString = DB_STRING
        cn.Open()

        Tran = cn.BeginTransaction

        Using cn

            Try

                sqlCmd = New SqlCommand()
                sqlCmd.Connection = cn
                sqlCmd.Transaction = Tran

                sSQL = "update T_HIYARIHATT set GM = 1 " &
                        "where RowINDEX = " & iRowINDEX2

                sqlCmd.CommandText = sSQL
                iResult = sqlCmd.ExecuteNonQuery()

                If iResult < 1 Then
                    Tran.Rollback()
                    g_disp_mess_ok_error("データベースの更新に失敗しました。")
                    Exit Sub
                End If

                sqlCmd.Dispose()
                Tran.Commit()
                cn.Close()

            Catch ex As Exception
                Tran.Rollback()
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        disp_lv()
        disp_chart()
        clear_box()

        Me.lv1.Items(iSelected).Selected = True

    End Sub

    '------------------------------------
    '   Mボタン押下
    '------------------------------------
    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer
        Dim iSelected As Integer = -1

        If iRowINDEX2 < 0 Then
            g_disp_mess_ok_error("承認するヒヤリを選択してください。")
            Exit Sub
        End If

        iSelected = Me.lv1.SelectedItems(0).Index

        cn = New System.Data.SqlClient.SqlConnection()
        cn.ConnectionString = DB_STRING
        cn.Open()

        Tran = cn.BeginTransaction

        Using cn

            Try

                sqlCmd = New SqlCommand()
                sqlCmd.Connection = cn
                sqlCmd.Transaction = Tran

                sSQL = "update T_HIYARIHATT set M = 1 " &
                        "where RowINDEX = " & iRowINDEX2

                sqlCmd.CommandText = sSQL
                iResult = sqlCmd.ExecuteNonQuery()

                If iResult < 1 Then
                    Tran.Rollback()
                    g_disp_mess_ok_error("データベースの更新に失敗しました。")
                    Exit Sub
                End If

                sqlCmd.Dispose()
                Tran.Commit()
                cn.Close()

            Catch ex As Exception
                Tran.Rollback()
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        disp_lv()
        disp_chart()
        clear_box()

        Me.lv1.Items(iSelected).Selected = True

    End Sub

    '------------------------------------
    '   GM承認解除ボタン押下
    '------------------------------------
    Private Sub btnUnGM_Click(sender As Object, e As EventArgs) Handles btnUnGM.Click

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer
        Dim iSelected As Integer = -1

        If iRowINDEX2 < 0 Then
            g_disp_mess_ok_error("承認解除するヒヤリを選択してください。")
            Exit Sub
        End If

        iSelected = Me.lv1.SelectedItems(0).Index

        cn = New System.Data.SqlClient.SqlConnection()
        cn.ConnectionString = DB_STRING
        cn.Open()

        Tran = cn.BeginTransaction

        Using cn

            Try

                sqlCmd = New SqlCommand()
                sqlCmd.Connection = cn
                sqlCmd.Transaction = Tran

                sSQL = "update T_HIYARIHATT set GM = 0 " &
                        "where RowINDEX = " & iRowINDEX2

                sqlCmd.CommandText = sSQL
                iResult = sqlCmd.ExecuteNonQuery()

                If iResult < 1 Then
                    Tran.Rollback()
                    g_disp_mess_ok_error("データベースの更新に失敗しました。")
                    Exit Sub
                End If

                sqlCmd.Dispose()
                Tran.Commit()
                cn.Close()

            Catch ex As Exception
                Tran.Rollback()
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        disp_lv()
        disp_chart()
        clear_box()

        Me.lv1.Items(iSelected).Selected = True

    End Sub

    '------------------------------------
    '   M承認解除ボタン押下
    '------------------------------------
    Private Sub btnUnM_Click(sender As Object, e As EventArgs) Handles btnUnM.Click

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer
        Dim iSelected As Integer = -1

        If iRowINDEX2 < 0 Then
            g_disp_mess_ok_error("承認解除するヒヤリを選択してください。")
            Exit Sub
        End If

        iSelected = Me.lv1.SelectedItems(0).Index

        If Me.lv1.Items(iSelected).SubItems(7).Text = "承" Then
            g_disp_mess_ok_error("管責が承認を解除するまで、経責が解除することはできません。")
            Exit Sub
        End If

        cn = New System.Data.SqlClient.SqlConnection()
        cn.ConnectionString = DB_STRING
        cn.Open()

        Tran = cn.BeginTransaction

        Using cn

            Try

                sqlCmd = New SqlCommand()
                sqlCmd.Connection = cn
                sqlCmd.Transaction = Tran

                sSQL = "update T_HIYARIHATT set M = 0 " &
                        "where RowINDEX = " & iRowINDEX2

                sqlCmd.CommandText = sSQL
                iResult = sqlCmd.ExecuteNonQuery()

                If iResult < 1 Then
                    Tran.Rollback()
                    g_disp_mess_ok_error("データベースの更新に失敗しました。")
                    Exit Sub
                End If

                sqlCmd.Dispose()
                Tran.Commit()
                cn.Close()

            Catch ex As Exception
                Tran.Rollback()
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        disp_lv()
        disp_chart()
        clear_box()

        Me.lv1.Items(iSelected).Selected = True

    End Sub

    '------------------------------------
    '   印刷ボタン押下
    '------------------------------------
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim pd As New System.Drawing.Printing.PrintDocument
        AddHandler pd.PrintPage, AddressOf pd_PrintPage

        Dim pdlg As New PrintDialog
        pdlg.Document = pd

        If pdlg.ShowDialog() = DialogResult.OK Then
            pd.Print()
        End If

    End Sub

    '------------------------------------
    '   プレビューボタン押下
    '------------------------------------
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        Dim pd As New System.Drawing.Printing.PrintDocument
        AddHandler pd.PrintPage, AddressOf pd_PrintPage
        Dim ppd As New PrintPreviewDialog

        ppd.Height = 600
        ppd.Width = 400

        ppd.Document = pd
        ppd.ShowDialog()

    End Sub

    '-------------------------------------
    '選択解除ボタン押下
    '-------------------------------------
    Private Sub btnUnSelect_Click(sender As Object, e As EventArgs) Handles btnUnSelect.Click
        For i As Integer = 0 To lv1.Items.Count - 1
            lv1.Items(i).Selected = False
        Next
    End Sub

    '------------------------------------
    '   印刷イベント
    '------------------------------------
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        '印刷初期位置
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim iWidth As Integer = 720
        Dim iHeight As Integer = 1050
        Dim irowHeight As Integer = 25 '行高さ
        Dim ixPos As Integer = 0
        Dim iyPos As Integer = 0

        Dim ih1 As Integer = 10
        Dim ih2 As Integer = 30
        Dim ih3 As Integer = 10

        Dim F As Font
        Dim Fm As Font
        Dim Fl As Font
        Dim Fl2 As Font

        F = New Font("ＭＳ ゴシック", 20)
        Fm = New Font("ＭＳ ゴシック", 12)
        Fl = New Font("ＭＳ ゴシック", 10)
        Fl2 = New Font("ＭＳ ゴシック", 8)

        '--- 表題 ---
        ixPos = x + 200
        iyPos = y + ih1
        e.Graphics.DrawString("ヒ ヤ リ ハッ ト 提 案 書", F, Brushes.Black, ixPos, iyPos)
        'アンダーライン
        iyPos = iyPos + ih2
        e.Graphics.DrawLine(New Pen(Color.Black), ixPos, iyPos, ixPos + 365, iyPos)

        '--- 罫線 ---
        iyPos = iyPos + ih3

        '太線枠
        e.Graphics.DrawRectangle(New Pen(Color.Black, 3), New Rectangle(x + 1, iyPos + 1, iWidth - 2, irowHeight * 34 - 2))

        '罫線(縦)
        ixPos = x + 100
        e.Graphics.DrawLine(New Pen(Color.Black), ixPos, iyPos, ixPos, iyPos + irowHeight * 34)

        ixPos = x + 300
        e.Graphics.DrawLine(New Pen(Color.Black), ixPos, iyPos, ixPos, iyPos + irowHeight * 3)
        ixPos = x + 400
        e.Graphics.DrawLine(New Pen(Color.Black), ixPos, iyPos, ixPos, iyPos + irowHeight * 3)

        '罫線(横)
        ixPos = x
        iyPos = iyPos

        For i = 0 To 32
            iyPos = iyPos + irowHeight
            If i = 0 Or i = 1 Or i = 2 Or i = 4 Or i = 15 Or i = 24 Then
                If i = 1 Then
                    e.Graphics.DrawLine(New Pen(Color.Black), ixPos, iyPos, ixPos + 300, iyPos)
                Else
                    e.Graphics.DrawLine(New Pen(Color.Black), ixPos, iyPos, ixPos + iWidth, iyPos)
                End If
            ElseIf i <> 3 Then
                If i = 30 Or i = 31 Or i = 32 Then
                    e.Graphics.DrawLine(New Pen(Color.Black), ixPos + 100, iyPos, ixPos + iWidth - 120, iyPos)
                Else
                    e.Graphics.DrawLine(New Pen(Color.Black), ixPos + 100, iyPos, ixPos + iWidth, iyPos)
                End If
            End If
        Next

        '押印欄(管責)
        e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(x + iWidth - 120, y + ih1 + ih2 + ih3 + irowHeight * 30, 120, irowHeight * 4))
        e.Graphics.DrawLine(New Pen(Color.Black), x + iWidth - 100, y + ih1 + ih2 + ih3 + irowHeight * 30, x + iWidth - 100, y + ih1 + ih2 + ih3 + irowHeight * 34)
        e.Graphics.DrawString("管" & vbCrLf & "理" & vbCrLf & "責" & vbCrLf & "任" & vbCrLf & "者", Fl, Brushes.Black, x + iWidth - 120, y + ih1 + ih2 + ih3 + irowHeight * 30 + 15)
        '押印欄(担当者)
        e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(x + iWidth - 100, y + ih1 + ih2 + ih3 + irowHeight * 34, 100, 120))
        e.Graphics.DrawString("担当者", Fm, Brushes.Black, x + iWidth - 100 + 22, y + ih1 + ih2 + ih3 + irowHeight * 34 + 2)
        '押印欄(M)
        e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(x + iWidth - 200, y + ih1 + ih2 + ih3 + irowHeight * 34, 100, 120))
        e.Graphics.DrawString("M", Fm, Brushes.Black, x + iWidth - 200 + 42, y + ih1 + ih2 + ih3 + irowHeight * 34 + 2)
        '押印欄(GM)
        e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(x + iWidth - 300, y + ih1 + ih2 + ih3 + irowHeight * 34, 100, 120))
        e.Graphics.DrawString("GM", Fm, Brushes.Black, x + iWidth - 300 + 40, y + ih1 + ih2 + ih3 + irowHeight * 34 + 2)

        e.Graphics.DrawLine(New Pen(Color.Black), x + iWidth - 300, y + ih1 + ih2 + ih3 + irowHeight * 34 + 20, x + iWidth, y + ih1 + ih2 + ih3 + irowHeight * 34 + 20)

        e.Graphics.DrawString("三和計電株式会社", Fm, Brushes.Black, ixPos + iWidth - 150, y + ih1 + ih2 + ih3 + irowHeight * 34 + 120 + 10)

        '---文字印字---
        '作成日
        e.Graphics.DrawString("作成日", Fl, Brushes.Black, x + 30, y + ih1 + ih2 + ih3 + 7)
        e.Graphics.DrawString(Me.DateTimePicker1.Text, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + 7)

        '場所
        e.Graphics.DrawString("場所", Fl, Brushes.Black, x + 100 + 200 + 35, y + ih1 + ih2 + ih3 + 7)
        e.Graphics.DrawString(Me.txtPlace.Text, Fl, Brushes.Black, x + 100 + 200 + 100 + 2, y + ih1 + ih2 + ih3 + 7)

        '発生日時
        e.Graphics.DrawString("発生日時", Fl, Brushes.Black, x + 20, y + ih1 + ih2 + ih3 + irowHeight + 7)
        e.Graphics.DrawString(Me.DateTimePicker2.Text, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight + 7)

        '発行者
        e.Graphics.DrawString("発行者", Fl, Brushes.Black, x + 30, y + ih1 + ih2 + ih3 + irowHeight * 2 + 7)
        e.Graphics.DrawString(Me.lbName.Text, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * 2 + 7)

        '作業件名
        e.Graphics.DrawString("作業件名", Fl, Brushes.Black, x + 100 + 200 + 20, y + ih1 + ih2 + ih3 + irowHeight + irowHeight / 2 + 7)
        e.Graphics.DrawString(Me.txtJOB.Text, Fl, Brushes.Black, x + 100 + 200 + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight + 7)

        Dim sTemp1 As String = "□"
        Dim sTemp2 As String = "□"
        Dim sTemp3 As String = "□"
        'ヒヤリハットの評価
        If Me.rb1.Checked Then
            sTemp1 = "■"
            sTemp2 = "□"
            sTemp3 = "□"
        ElseIf Me.rb2.Checked Then
            sTemp1 = "□"
            sTemp2 = "■"
            sTemp3 = "□"
        Else
            sTemp1 = "□"
            sTemp2 = "□"
            sTemp3 = "■"
        End If
        e.Graphics.DrawString("１．ヒヤリハットの評価", Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * 3 + 2)
        e.Graphics.DrawString(sTemp1 & " 重大   " & sTemp2 & " 軽微   " & sTemp3 & " 経過観察が必要", Fl, Brushes.Black, x + 100 + 170 + 10, y + ih1 + ih2 + ih3 + irowHeight * 3 + 2)
        'ヒヤリハットの予想
        If Me.rb4.Checked Then
            sTemp1 = "■"
            sTemp2 = "□"
        Else
            sTemp1 = "□"
            sTemp2 = "■"
        End If
        e.Graphics.DrawString("２．ヒヤリハットの予想", Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * 3 + irowHeight * 2 / 3 + 2)
        e.Graphics.DrawString(sTemp1 & " 可能   " & sTemp2 & " 不可能", Fl, Brushes.Black, x + 100 + 170 + 10, y + ih1 + ih2 + ih3 + irowHeight * 3 + irowHeight * 2 / 3 + 2)
        '改善の必要
        If Me.rb6.Checked Then
            sTemp1 = "■"
            sTemp2 = "□"
        Else
            sTemp1 = "□"
            sTemp2 = "■"
        End If
        e.Graphics.DrawString("３．改善の必要", Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * 3 + irowHeight * 4 / 3 + 2)
        e.Graphics.DrawString(sTemp1 & " 有     " & sTemp2 & " 無", Fl, Brushes.Black, x + 100 + 170 + 10, y + ih1 + ih2 + ih3 + irowHeight * 3 + irowHeight * 4 / 3 + 2)

        Dim sTemp As String = ""
        Dim j As Integer = 0
        'ヒヤリハット内容
        e.Graphics.DrawString("ヒヤリハット" & vbCrLf & "    内容", Fl, Brushes.Black, x + 7, y + ih1 + ih2 + ih3 + irowHeight * 10)
        For i = 0 To Me.txtCont.Text.Length - 1
            If j > 10 Then
                Exit For
            End If
            If Me.txtCont.Text.Substring(i, 1) <> vbCr And Me.txtCont.Text.Substring(i, 1) <> vbLf Then
                sTemp = sTemp & Me.txtCont.Text.Substring(i, 1)
            ElseIf Me.txtCont.Text.Substring(i, 1) <> vbCr Then
                e.Graphics.DrawString(sTemp, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * (5 + j) + 7)
                sTemp = ""
                j = j + 1
            End If
            If i = Me.txtCont.Text.Length - 1 Then
                '最後の行
                e.Graphics.DrawString(sTemp, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * (5 + j) + 7)
            End If
        Next
        '実施した対策内容
        e.Graphics.DrawString("実施した対策" & vbCrLf & "    内容", Fl, Brushes.Black, x + 7, y + ih1 + ih2 + ih3 + irowHeight * 20)
        sTemp = ""
        j = 0
        For i = 0 To Me.txtDone.Text.Length - 1
            If j > 8 Then
                Exit For
            End If
            If Me.txtDone.Text.Substring(i, 1) <> vbCr And Me.txtDone.Text.Substring(i, 1) <> vbLf Then
                sTemp = sTemp & Me.txtDone.Text.Substring(i, 1)
            ElseIf Me.txtDone.Text.Substring(i, 1) <> vbCr Then
                e.Graphics.DrawString(sTemp, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * (16 + j) + 7)
                sTemp = ""
                j = j + 1
            End If
            If i = Me.txtDone.Text.Length - 1 Then
                '最後の行
                e.Graphics.DrawString(sTemp, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * (16 + j) + 7)
            End If
        Next
        '効果の確認
        e.Graphics.DrawString("効果の確認", Fl, Brushes.Black, x + 13, y + ih1 + ih2 + ih3 + irowHeight * 29)
        e.Graphics.DrawString("(管理責任者記入)", Fl2, Brushes.Black, x + 5, y + ih1 + ih2 + ih3 + irowHeight * 29 + 15)
        sTemp = ""
        j = 0
        For i = 0 To Me.txtConf.Text.Length - 1
            If j > 8 Then
                Exit For
            End If
            If Me.txtConf.Text.Substring(i, 1) <> vbCr And Me.txtConf.Text.Substring(i, 1) <> vbLf Then
                sTemp = sTemp & Me.txtConf.Text.Substring(i, 1)
            ElseIf Me.txtConf.Text.Substring(i, 1) <> vbCr Then
                e.Graphics.DrawString(sTemp, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * (25 + j) + 7)
                sTemp = ""
                j = j + 1
            End If
            If i = Me.txtConf.Text.Length - 1 Then
                '最後の行
                e.Graphics.DrawString(sTemp, Fl, Brushes.Black, x + 100 + 2, y + ih1 + ih2 + ih3 + irowHeight * (25 + j) + 7)
            End If
        Next

        e.HasMorePages = False

    End Sub

    '------------------------------------
    '   リストビュー選択変更イベント
    '------------------------------------
    Private Sub lv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv1.SelectedIndexChanged

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim sSQL As String

        If lv1.SelectedItems.Count = 0 Then
            clear_box()
            iRowINDEX2 = -1
            Me.rb8.Checked = True
            rb9.Enabled = False

            Exit Sub
        Else
            rb9.Enabled = True
            rb9.Checked = True
        End If

        Dim itemx As New ListViewItem

        itemx = lv1.SelectedItems(0)

        iRowINDEX2 = itemx.SubItems(8).Text

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                '2016/02/08 add k.sato CATEGORY追加
                sSQL = "select T1.RowINDEX,T1.M_YEAR,T1.M_MONTH,T1.M_DAY," &
                            "T1.H_YEAR,T1.H_MONTH,T1.H_DAY,T1.H_HOUR,T1.H_MINUTE," &
                            "T1.PLACE,T1.JOB,T1.CONT,T1.DO,T1.CONF," &
                            "T1.JUDGE,T1.FORECAST,T1.IMPROVEMENT," &
                            "T1.CATEGORY," &
                            "T1.M,T1.GM," &
                            "T1.USER_ID,M1.NAME,M1.AUTHORITY," &
                            "PHOTO " &
                        "from T_HIYARIHATT AS T1 LEFT JOIN M_USER AS M1 ON T1.USER_ID = M1.ID " &
                        "where RowINDEX = " & iRowINDEX2

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then

                    '作成日
                    DateTimePicker1.Text = g_NullConvert(sdr.Item("M_YEAR")) & "/" & g_NullConvert(sdr.Item("M_MONTH")) & "/" & g_NullConvert(sdr.Item("M_DAY"))
                    '発生日
                    DateTimePicker2.Text = g_NullConvert(sdr.Item("H_YEAR")) & "/" & g_NullConvert(sdr.Item("H_MONTH")) & "/" & g_NullConvert(sdr.Item("H_DAY"))
                    '発生時刻
                    DateTimePicker3.Text = g_NullConvert(sdr.Item("H_HOUR")) & ":" & g_NullConvert(sdr.Item("H_MINUTE"))
                    '発行者
                    lbName.Text = g_NullConvert(sdr.Item("NAME"))
                    '場所
                    Me.txtPlace.Text = g_NullConvert(sdr.Item("PLACE"))
                    '作業件名
                    Me.txtJOB.Text = g_NullConvert(sdr.Item("JOB"))
                    '内容
                    Me.txtCont.Text = g_NullConvert(sdr.Item("CONT"))
                    '対策
                    Me.txtDone.Text = g_NullConvert(sdr.Item("DO"))
                    '確認
                    Me.txtConf.Text = g_NullConvert(sdr.Item("CONF"))
                    '評価
                    If g_NullConvert(sdr.Item("JUDGE")) = 0 Then
                        Me.rb1.Checked = True
                    ElseIf g_NullConvert(sdr.Item("JUDGE")) = 1 Then
                        Me.rb2.Checked = True
                    Else
                        Me.rb3.Checked = True
                    End If
                    '予想
                    If g_NullConvert(sdr.Item("FORECAST")) = 0 Then
                        Me.rb4.Checked = True
                    Else
                        Me.rb5.Checked = True
                    End If
                    '改善
                    If g_NullConvert(sdr.Item("IMPROVEMENT")) = 0 Then
                        Me.rb6.Checked = True
                    Else
                        Me.rb7.Checked = True
                    End If

                    '2016/02/08 add k.sato 安全・品質項目追加
                    If g_NullConvert(sdr.Item("CATEGORY")) = 0 Then
                        Me.rb10.Checked = True
                    Else
                        Me.rb11.Checked = True
                    End If

                    '20160222 yamamoto add start
                    If IsDBNull(sdr.Item("PHOTO")) Then

                        Me.btnSelPhoto.Text = "無"
                        Me.btnDispPhoto.Enabled = False

                        Me.PictureBox1.Image = Nothing

                    Else

                        Me.btnSelPhoto.Text = "有"
                        Me.btnDispPhoto.Enabled = True

                        Dim imgconv As New ImageConverter()
                        Dim img As Image = CType(imgconv.ConvertFrom(sdr.Item("PHOTO")), Image)
                        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                        Me.PictureBox1.Image = img

                    End If
                    '20160222 yamamoto add end

                    sdr.Close()

                End If

                sqlCmd.Dispose()
                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

    End Sub

    '------------------------------------
    '   入力領域初期化
    '------------------------------------
    Private Sub clear_box()

        DateTimePicker1.Text = DateTime.Now
        DateTimePicker2.Text = DateTime.Now
        DateTimePicker3.Text = DateTime.Now
        Me.txtPlace.Text = ""
        Me.txtJOB.Text = ""
        Me.txtCont.Text = ""
        Me.txtDone.Text = ""
        Me.txtConf.Text = ""

        Me.rb1.Checked = True
        Me.rb4.Checked = True
        Me.rb6.Checked = True

        Me.lbName.Text = ""

        Me.btnSelPhoto.Text = "無"
        Me.btnDispPhoto.Enabled = False
        Me.PictureBox1.Image = Nothing

    End Sub

    '------------------------------------
    '   新規登録モード
    '------------------------------------
    Private Sub rb8_CheckedChanged(sender As Object, e As EventArgs) Handles rb8.CheckedChanged

        If Me.rb8.Checked Then
            iMode = 0
            Me.btnReg.Text = "新規登録"
            Me.lbMode.Text = "新規登録"
        Else
            iMode = 1
            Me.btnReg.Text = "変更"
            Me.lbMode.Text = "閲覧・変更"
        End If

    End Sub

    '------------------------------------
    '   閲覧・変更モード
    '------------------------------------
    Private Sub rb9_CheckedChanged(sender As Object, e As EventArgs) Handles rb9.CheckedChanged

        If Me.rb9.Checked Then
            iMode = 1
            Me.btnReg.Text = "変更"
            Me.lbMode.Text = "変更"
        Else
            iMode = 0
            Me.btnReg.Text = "新規登録"
            Me.lbMode.Text = "新規登録"
        End If

    End Sub

    '------------------------------------
    '   グラフを表示
    '------------------------------------
    Private Sub disp_chart()

        Chart1.Series.Clear()

        Dim ds As New DataSet
        Dim dt As New DataTable

        '表示用のデータを作成
        GetChartData(ds, dt)

        Chart1.DataSource = ds

        For i As Integer = 1 To ds.Tables(0).Columns.Count - 1

            Dim columnName As String = ds.Tables(0).Columns(i).ColumnName


            Chart1.Series.Add(columnName)
            Chart1.Series(columnName).ChartType = SeriesChartType.Line
            Chart1.Series(columnName).MarkerStyle = MarkerStyle.Circle
            Chart1.Series(columnName).MarkerColor = Color.Orange

            Chart1.Series(columnName).XValueMember = ds.Tables(0).Columns(0).ColumnName.ToString
            Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
            Chart1.Series(columnName).YValueMembers = columnName

            Chart1.ChartAreas(0).AxisX.Minimum = 1
            Chart1.ChartAreas(0).AxisX.Maximum = 12
            Chart1.ChartAreas(0).AxisX.Interval = 1

        Next

        Chart1.ChartAreas(0).AxisX.Title = "月"
        Chart1.DataBind()

    End Sub

    '------------------------------------
    '   グラフ表示用に月別集計データを取得する
    '------------------------------------
    Private Sub GetChartData(ByRef ds As DataSet, ByRef dt As DataTable)

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim sSQL As String = ""

        Dim dtRow As DataRow
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim iKisyu As Integer = g_get_kisyu()
        Dim iNendo As Integer = Me.cmbNendo.Text
        Dim iCNT As Integer = 0
        Dim sID As String = ""

        dt.Columns.Add("月", Type.GetType("System.String"))
        dt.Columns.Add(Me.cmbKind.Text, Type.GetType("System.Int32"))
        ds.Tables.Add(dt)

        If Me.ch1.Checked Then
            '絞り込み時
            Dim item As ExComboBox
            item = DirectCast(cmbCond1.SelectedItem, ExComboBox)
            sID = "and USER_ID = '" & item.Id & "' "
        End If

        '期首の月から12か月分のdatatableを用意
        For i = iKisyu To iKisyu + 11

            dtRow = ds.Tables(0).NewRow
            If i > 12 Then
                dtRow(0) = i - 12
            Else
                dtRow(0) = i
            End If
            'dtRow(1) = 0
            ds.Tables(0).Rows.Add(dtRow)

        Next

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                For j = 0 To ds.Tables(0).Rows.Count - 1

                    If ds.Tables(0).Rows(j).Item(0) < iKisyu Then

                        sSQL = "select COUNT(*) as CNT from T_HIYARIHATT " &
                                "where H_YEAR = '" & (iNendo + 1).ToString & "' and " &
                                        "H_MONTH = '" & ds.Tables(0).Rows(j).Item(0).ToString & "' " & sID &
                                "group by H_YEAR,H_MONTH"

                    Else

                        sSQL = "select COUNT(*) as CNT from T_HIYARIHATT " &
                                "where H_YEAR = '" & iNendo.ToString & "' and " &
                                        "H_MONTH = '" & ds.Tables(0).Rows(j).Item(0).ToString & "' " & sID &
                                "group by H_YEAR,H_MONTH"

                    End If

                    sqlCmd = New SqlCommand(sSQL, cn)
                    sdr = sqlCmd.ExecuteReader

                    If sdr.Read Then
                        If Me.cmbKind.Text = "累計" Then
                            '累計
                            iCNT = iCNT + sdr.Item("CNT")
                            ds.Tables(0).Rows(j).Item(1) = iCNT
                        Else
                            '月別
                            ds.Tables(0).Rows(j).Item(1) = sdr.Item("CNT")
                        End If
                    Else
                        ds.Tables(0).Rows(j).Item(1) = 0
                    End If

                    sdr.Close()
                    sqlCmd.Dispose()

                Next

                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

    End Sub

    '------------------------------------
    '   年度選択変更イベント
    '------------------------------------
    Private Sub cmbNendo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNendo.SelectedIndexChanged
        disp_chart()
    End Sub

    '------------------------------------
    '   累計/月別 選択変更イベント
    '------------------------------------
    Private Sub cmbKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKind.SelectedIndexChanged
        disp_chart()
    End Sub

    '------------------------------------
    '   絞り込みチェックボックス
    '------------------------------------
    Private Sub ch1_CheckedChanged(sender As Object, e As EventArgs) Handles ch1.CheckedChanged

        If Me.ch1.Checked Then
            Me.cmbCond1.Enabled = True
        Else
            Me.cmbCond1.Enabled = False
        End If

        disp_chart()

    End Sub

    '------------------------------------
    '   絞り込み条件変更
    '------------------------------------
    Private Sub cmbCond1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCond1.SelectedIndexChanged

        disp_chart()

    End Sub

    '------------------------------------
    '   画像選択ボタン押下
    '------------------------------------
    Private Sub btnSelPhoto_Click(sender As Object, e As EventArgs) Handles btnSelPhoto.Click

        Dim ofd As New OpenFileDialog()

        sPhoto = ""
        Me.btnSelPhoto.Text = "無"

        ofd.Filter = "画像ファイル(*.jpg;*.jpeg;*.bmp;*.png;*.gif)|*.jpg;*.jpeg;*.bmp;*.png;*.gif"
        ofd.FilterIndex = 2
        ofd.Title = "開くファイルを選択してください"
        ofd.RestoreDirectory = True
        ofd.CheckPathExists = True

        If ofd.ShowDialog() = DialogResult.OK Then

            If System.IO.File.Exists(ofd.FileName) = False Then
                g_disp_mess_ok_error("不正なファイル名です。")
                Exit Sub
            End If

            If ofd.FileName.Length > 0 Then

                sPhoto = ofd.FileName
                Me.btnSelPhoto.Text = "有"

                Me.PictureBox1.ImageLocation = sPhoto

            End If

        End If

    End Sub

    '------------------------------------
    '   画像削除ボタン押下
    '------------------------------------
    Private Sub btnDelPhoto_Click(sender As Object, e As EventArgs) Handles btnDelPhoto.Click

        If iMode <> 1 Then
            g_disp_mess_ok_error("変更モードではありません。")
            Exit Sub
        End If

        If Me.lv1.SelectedItems.Count < 1 Then
            g_disp_mess_ok_error("変更するヒヤリを選択してください。")
            Exit Sub
        End If

        If iRowINDEX2 > 0 And g_sAuthority = "0" Then
            '管責、経責は変更できる
            If Me.lv1.SelectedItems(0).SubItems(2).Text <> g_sName Then
                g_disp_mess_ok_error("発行者以外は変更できません。")
                Exit Sub
            End If
            If Me.lv1.SelectedItems(0).SubItems(6).Text = "承" Then
                g_disp_mess_ok_error("承認済みのヒヤリは変更できません。")
                Exit Sub
            End If
        End If

        If Me.lv1.SelectedItems(0).SubItems(10).Text <> "●" Then
            g_disp_mess_ok_error("画像が登録されていません。")
            Exit Sub
        End If

        If g_disp_mess_okno_info("画像を削除しますか？") = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        sPhoto = ""

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer

        cn = New System.Data.SqlClient.SqlConnection()
        cn.ConnectionString = DB_STRING
        cn.Open()

        Tran = cn.BeginTransaction

        Using cn

            Try

                sqlCmd = New SqlCommand()
                sqlCmd.Connection = cn
                sqlCmd.Transaction = Tran

                sSQL = "update T_HIYARIHATT " &
                        "set PHOTO = NULL " &
                        "where RowINDEX = " & iRowINDEX2

                sqlCmd.CommandText = sSQL
                iResult = sqlCmd.ExecuteNonQuery()

                If iResult < 1 Then
                    Tran.Rollback()
                    g_disp_mess_ok_error("データベースの更新に失敗しました。")
                    Exit Sub
                End If

                sqlCmd.Dispose()
                Tran.Commit()
                cn.Close()

            Catch ex As Exception
                Tran.Rollback()
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        disp_lv()
        disp_chart()
        clear_box()

    End Sub

    '------------------------------------
    '   画像表示ボタン押下
    '------------------------------------
    Private Sub btnDispPhoto_Click(sender As Object, e As EventArgs) Handles btnDispPhoto.Click

        If Me.lv1.SelectedItems.Count < 1 Then
            g_disp_mess_ok_error("画像を表示するヒヤリを選択してください。")
            Exit Sub
        End If

        If Me.lv1.SelectedItems(0).SubItems(10).Text <> "●" Then
            g_disp_mess_ok_error("画像の登録されているヒヤリを選択してください。")
            Exit Sub
        End If

        Dim f As New frmPhoto

        f.iRowINDEX = iRowINDEX2

        f.StartPosition = FormStartPosition.CenterScreen
        f.Show(Me)

    End Sub

    '------------------------------------
    '   戻るボタン押下
    '------------------------------------
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

End Class