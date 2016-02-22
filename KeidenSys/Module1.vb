'=========================================
'
'   Copyright (c) SANWAKEIDEN Co.,Ltd.
'
'   form name       :module1
'   Description     :標準モジュール1
'   Written         :2016.01.20
'   Author          :yamamoto hideki
'   Update          :
'   Update          :
'   Update          :
'   Reason          :
'
'=========================================
Option Explicit On
Imports System.Data.SqlClient
Imports System.IO

Module Module1

    'sanwa
    Public Const DB_STRING = "Server=192.168.251.84;database=SANWAKEIDEN_DB;uid=SYAIN;pwd=S_a_n_0440"

    Public g_sID As String '社員番号
    Public g_sName As String '社員名

    '権限
    '0:社員
    '1:M
    '2:GM
    Public g_sAuthority As String '権限

    Public g_sMailAddressM As String '管理者メールアドレス

    '------------------------------------
    '   ok/noメッセージ表示関数
    '   返り値:DialogResult.Yes
    '         DialogResult.No
    '------------------------------------
    Public Function g_disp_mess_okno_info(ByVal sMessage As String) As DialogResult

        Dim result As DialogResult = MessageBox.Show(sMessage,
                                             "問い合わせ",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2)

        Return result

    End Function

    '------------------------------------
    '   エラーメッセージ表示関数
    '------------------------------------
    Public Sub g_disp_mess_ok_error(ByVal sMessage As String)

        MessageBox.Show(sMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    '------------------------------------
    '   警告メッセージ表示関数
    '------------------------------------
    Public Sub g_disp_mess_ok_warning(ByVal sMessage As String)

        MessageBox.Show(sMessage, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    '------------------------------------
    '   情報メッセージ表示関数
    '------------------------------------
    Public Sub g_disp_mess_ok_info(ByVal sMessage As String)

        MessageBox.Show(sMessage, "報告", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    '------------------------------------
    '   画像ファイルをバイナリに変換
    '------------------------------------
    Public Function g_getPhoto(ByVal filePath As String) As Byte()

        Dim stream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim reader As BinaryReader = New BinaryReader(stream)
        Dim photo() As Byte = reader.ReadBytes(CType(stream.Length, Integer))

        Try
            reader.Close()
            stream.Close()
        Catch ex As Exception
            g_disp_mess_ok_error(ex.Message)
        End Try

        Return photo

    End Function

    '------------------------------------
    '   DBNULLの値を0byteStringに変換
    '------------------------------------
    Public Function g_NullConvert(ByVal value As Object) As String

        If TypeOf value Is DBNull Then
            Return ""
        End If

        Return value.ToString()

    End Function

    '------------------------------------
    '   評価を返す
    '------------------------------------
    Public Function g_get_JUDGE(ByVal temp As Integer) As String

        If temp = 0 Then
            '重大
            Return "重"
        ElseIf temp = 1 Then
            '軽微
            Return "軽"
        Else
            '経過観察が必要
            Return "経"
        End If

    End Function

    '------------------------------------
    '   改善を返す
    '------------------------------------
    Public Function g_get_IMPROVE(ByVal temp As Integer) As String

        If temp = 0 Then
            '有
            Return "有"
        Else
            '無
            Return "無"
        End If

    End Function

    '------------------------------------
    '   承認状態を返す
    '------------------------------------
    Public Function g_get_stamp(ByVal temp As Integer) As String

        If temp = 0 Then
            '未承認
            Return "未"
        Else
            '承認済み
            Return "承"
        End If

    End Function

    '------------------------------------
    '   期首を取得
    '------------------------------------
    Public Function g_get_kisyu() As Integer

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

                '期開始月を取得
                sSQL = "select ITEM1 from M_KANRI where ID = 1"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then

                    Return sdr.Item("ITEM1")

                Else

                    Return 4

                End If

                sdr.Close()
                sqlCmd.Dispose()
                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Return 0
            End Try

        End Using

    End Function

    '------------------------------------
    '   当月の年度を取得
    '------------------------------------
    Public Function g_get_nendo() As Integer

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

                '期開始月を取得
                sSQL = "select ITEM1 from M_KANRI where ID = 1"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then

                    If DateTime.Now.Month >= sdr.Item("ITEM1") And DateTime.Now.Month <= 12 Then
                        '期開始月から12月まで
                        Return DateTime.Now.Year
                    Else
                        '1月から期開始月前まで
                        Return DateTime.Now.Year - 1
                    End If

                Else

                    Return 4

                End If

                sdr.Close()
                sqlCmd.Dispose()
                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Return 0
            End Try

        End Using

    End Function

    '------------------------------------
    '   T_HIYARIHATTの最大RowINDEXを取得
    '------------------------------------
    Public Function get_rowindex() As Integer

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

                sSQL = "select max(RowINDEX) as mindex from T_HIYARIHATT"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then

                    If IsDBNull(sdr.Item("mindex")) Then
                        Return 0
                    End If

                    Return sdr.Item("mindex")

                Else

                    Return 0

                End If

                sdr.Close()
                sqlCmd.Dispose()
                cn.Close()

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Return 0
            End Try

        End Using

        Return 0

    End Function

    '------------------------------------
    '   管理者へメールを送信する
    '------------------------------------
    Public Sub send_mail()

        Dim sqlCmd As SqlCommand
        Dim sdr As SqlDataReader
        Dim cn As System.Data.SqlClient.SqlConnection

        Dim sSQL As String
        Dim sMailAddress As String = ""
        Dim sMailAccount As String = ""
        Dim sMailPass As String = ""

        cn = New System.Data.SqlClient.SqlConnection()

        Using cn

            Try

                cn.ConnectionString = DB_STRING
                cn.Open()

                sSQL = "select MAIL_ADDRESS,MAIL_ACCOUNT,MAIL_PASS from M_USER where ID = '" & g_sID & "'"

                sqlCmd = New SqlCommand(sSQL, cn)
                sdr = sqlCmd.ExecuteReader

                If sdr.Read Then
                    sMailAddress = g_NullConvert(sdr.Item("MAIL_ADDRESS"))
                    sMailAccount = g_NullConvert(sdr.Item("MAIL_ACCOUNT"))
                    sMailPass = g_NullConvert(sdr.Item("MAIL_PASS"))
                End If

                sdr.Close()
                sqlCmd.Dispose()
                cn.Close()

                If sMailAddress <> "" And sMailAccount <> "" And sMailPass <> "" Then

                    Dim senderMail As String = sMailAddress
                    Dim recipientMail As String = g_sMailAddressM '管理者メールアドレス
                    Dim subject As String = "【社内】ヒヤリハット登録通知"
                    Dim body As String = g_sName & "さんが" + vbCrLf + "ヒヤリハットを登録しました。"
                    Dim sc As New System.Net.Mail.SmtpClient()

                    sc.Host = "smtp.deskwing.net"
                    sc.Port = 587
                    sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
                    sc.Credentials = New System.Net.NetworkCredential(sMailAccount, sMailPass)
                    sc.EnableSsl = True

                    sc.Send(senderMail, recipientMail, subject, body)
                    sc.Dispose()

                End If

            Catch ex As Exception
                g_disp_mess_ok_error(ex.Message)
                Exit Sub
            End Try

            g_disp_mess_ok_info("管理者へメールを送信しました。")

        End Using

    End Sub

End Module
