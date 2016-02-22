'=========================================
'
'   Copyright (c) Sanwakeiden Co.,Ltd.
'
'   form name       :frmPhoto.vb
'   Description     :画像表示用画面
'   Written         :2016.02.22
'   Author          :yamamoto hideki
'   Update          :
'   Reason          :
'
'=========================================
Option Explicit On
Imports System.Data.SqlClient


Public Class frmPhoto

    Public iRowINDEX As Integer

    '------------------------------------
    '   フォームロード
    '------------------------------------
    Private Sub frmPhoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        disp_photo()

    End Sub

    '------------------------------------
    '   画像表示処理
    '------------------------------------
    Private Sub disp_photo()

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection

        Dim sSQL As String

        Me.PictureBox1.Image = Nothing

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                sSQL = "select PHOTO from T_HIYARIHATT where RowINDEX = " & iRowINDEX

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then

                    If IsDBNull(sdr.Item("PHOTO")) = False Then

                        Dim imgconv As New ImageConverter()
                        Dim img As Image = CType(imgconv.ConvertFrom(sdr.Item("PHOTO")), Image)

                        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                        Me.PictureBox1.Image = img

                    End If

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
    '   フォームリサイズイベント
    '------------------------------------
    Private Sub frmPhoto_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        Me.PictureBox1.Width = Me.Width - 20
        Me.PictureBox1.Height = Me.Height - 40

    End Sub


End Class