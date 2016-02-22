'=========================================
'
'   Copyright (c) Sanwakeiden Co.,Ltd.
'
'   form name       :frmKojin.vb
'   Description     :個人設定画面
'   Written         :2016.02.09
'   Author          :yamamoto hideki
'   Update          :
'   Reason          :
'
'=========================================
Option Explicit On
Imports System.Data.SqlClient


Public Class frmKojin

    '------------------------------------
    '   フォームロード
    '------------------------------------
    Private Sub frmKojin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.lbName.Text = g_sName

        Me.txtMailPass.PasswordChar = "●"

        disp_data()

        Me.txtMailAddress.Focus()

    End Sub

    '------------------------------------
    '   画面データ表示
    '------------------------------------
    Private Sub disp_data()

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim sSQL As String

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                sSQL = "select NAME,MAIL_ADDRESS,MAIL_ACCOUNT,MAIL_PASS " &
                        "from M_USER " &
                        "where ID = '" & g_sID & "'"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then

                    Me.txtMailAddress.Text = g_NullConvert(sdr.Item("MAIL_ADDRESS"))
                    Me.txtMailAccount.Text = g_NullConvert(sdr.Item("MAIL_ACCOUNT"))
                    Me.txtMailPass.Text = g_NullConvert(sdr.Item("MAIL_PASS"))

                End If

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
    '   登録ボタン押下
    '------------------------------------
    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click

        Dim sqlCmd As SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection
        Dim Tran As SqlClient.SqlTransaction

        Dim sSQL As String = ""
        Dim iResult As Integer

        Dim sAddress As String = Trim(Me.txtMailAddress.Text)
        Dim sAccount As String = Trim(Me.txtMailAccount.Text)
        Dim sPass As String = Trim(Me.txtMailPass.Text)

        If g_disp_mess_okno_info("登録しますか？") = Windows.Forms.DialogResult.No Then
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

                '変更 
                '2016/02/08 add k.sato カテゴリ項目追加
                sSQL = "update M_USER " &
                        "set MAIL_ACCOUNT = '" & sAccount & "'," &
                            "MAIL_PASS = '" & sPass & "'," &
                            "MAIL_ADDRESS = '" & sAddress & "' " &
                        "where ID = " & g_sID

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

        Tran.Dispose()

    End Sub

    '------------------------------------
    '   テキスト変更イベント
    '------------------------------------
    Private Sub txtMailAddress_TextChanged(sender As Object, e As EventArgs) Handles txtMailAddress.TextChanged

        If Len(Me.txtMailAddress.Text) > 0 AndAlso Me.txtMailAddress.Text.Substring(Len(Me.txtMailAddress.Text) - 1) = "@" Then
            '@が入力されたら自動補完
            Me.txtMailAddress.Text = Me.txtMailAddress.Text & "sanwakeiden.co.jp"
        End If

    End Sub

    '------------------------------------
    '   戻るボタン押下
    '------------------------------------
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class