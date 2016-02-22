'=========================================
'
'   Copyright (c) Sanwakeiden Co.,Ltd.
'
'   form name       :frmMain.vb
'   Description     :三和計電システム  メニュー画面
'   Written         :2016.01.20
'   Author          :yamamoto hideki
'   Update          :Ver.0.0:新規作成
'   Update          :Ver.0.0
'   Update          :Ver.0.0
'   Update          :Ver.0.0
'   Update          :Ver.0.0
'   Update          :Ver.0.0
'   Reason          :
'
'=========================================
Imports System.Data.SqlClient

Public Class frmMain

    '------------------------------------
    '   フォームロード
    '------------------------------------
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ログイン画面表示
        frmLogIn.StartPosition = FormStartPosition.CenterScreen
        frmLogIn.ShowDialog()
        frmLogIn.Dispose()

        If g_sID = "" And g_sName = "" Then
            'ログインがキャンセルの場合
            Me.Dispose()
        End If

        '初期表示位置
        Me.StartPosition = FormStartPosition.Manual
        Me.DesktopLocation = New Point(100, 0)

        Me.Text = "三和計電(" & g_sName & ")"

    End Sub

    '------------------------------------
    '   ヒヤリハットボタン押下
    '------------------------------------
    Private Sub btnHiyari_Click(sender As Object, e As EventArgs) Handles btnHiyari.Click

        frmHiyari.StartPosition = FormStartPosition.CenterScreen
        frmHiyari.ShowDialog()
        frmHiyari.Dispose()

    End Sub

    '------------------------------------
    '   個人設定ボタン押下
    '------------------------------------
    Private Sub btnKojin_Click(sender As Object, e As EventArgs) Handles btnKojin.Click

        frmKojin.StartPosition = FormStartPosition.CenterScreen
        frmKojin.ShowDialog()
        frmKojin.Dispose()

    End Sub

    '------------------------------------
    '   閉じるボタン押下
    '------------------------------------
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub


End Class
