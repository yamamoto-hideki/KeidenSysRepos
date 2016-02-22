'=========================================
'
'   Copyright (c) Sanwakeiden Co.,Ltd.
'
'   form name       :frmLogIn.vb
'   Description     :ログイン画面
'   Written         :2016.01.20
'   Author          :yamamoto hideki
'   Update          :
'   Reason          :
'
'=========================================
Option Explicit On
Imports System.Data.SqlClient


Public Class frmLogIn

    '------------------------------------
    '   フォームロード
    '------------------------------------
    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        Me.txtID.Focus()

    End Sub

    '------------------------------------
    '   ログインボタン押下
    '------------------------------------
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        login()

    End Sub

    '------------------------------------
    '   ログイン処理
    '------------------------------------
    Private Sub login()

        Dim sID As String = ""

        sID = Trim(Me.txtID.Text)

        g_sID = ""
        g_sName = ""
        g_sAuthority = ""

        If sID = "" Then
            g_disp_mess_ok_warning("IDを入力してください。")
            Me.txtID.Select()
            Exit Sub
        End If

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim sSQL As String

        Dim i As Integer = 0

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                'ログインユーザー取得
                sSQL = "select ID,NAME,AUTHORITY,MAIL_ADDRESS,MAIL_ACCOUNT,MAIL_PASS from M_USER where ID = '" & sID & "'"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then

                    If IsDBNull(sdr.Item("ID")) Or IsDBNull(sdr.Item("NAME")) Or IsDBNull(sdr.Item("AUTHORITY")) Then
                        sdr.Close()
                        g_disp_mess_ok_warning("このIDは登録されていません。")
                    Else
                        g_sID = sdr.Item("ID")
                        g_sName = sdr.Item("NAME")
                        g_sAuthority = sdr.Item("AUTHORITY")
                    End If

                Else
                    sdr.Close()
                    g_disp_mess_ok_warning("このIDは登録されていません。")
                    Me.txtID.Select()
                End If

                sdr.Close()
                sqlCmd.Dispose()

                '管理者メールアドレス取得
                sSQL = "select MAIL_ADDRESS from M_USER where AUTHORITY = '1'"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then
                    g_sMailAddressM = g_NullConvert(sdr.Item("MAIL_ADDRESS"))
                End If

                sdr.Close()
                sqlCmd.Dispose()

                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

        End Using

        If g_sID <> "" Then
            'ログイン成功
            Me.Close()
        Else
            '再度ID入力を促す
            Me.txtID.Text = ""
        End If

    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtID.KeyDown

        If e.KeyCode = Keys.Enter Then
            login()
        End If

    End Sub


    '------------------------------------
    '   キャンセルボタン押下
    '------------------------------------
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        g_sID = ""
        g_sName = ""
        Me.Close()

    End Sub

End Class