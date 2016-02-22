<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKojin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKojin))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lbName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMailAccount = New System.Windows.Forms.TextBox()
        Me.txtMailPass = New System.Windows.Forms.TextBox()
        Me.btnReg = New System.Windows.Forms.Button()
        Me.txtMailAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(251, 106)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(89, 27)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "戻る"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbName.Location = New System.Drawing.Point(12, 9)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(43, 14)
        Me.lbName.TabIndex = 31
        Me.lbName.Text = "個人名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "メールアカウント名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "メールパスワード"
        '
        'txtMailAccount
        '
        Me.txtMailAccount.Location = New System.Drawing.Point(105, 56)
        Me.txtMailAccount.Name = "txtMailAccount"
        Me.txtMailAccount.Size = New System.Drawing.Size(235, 19)
        Me.txtMailAccount.TabIndex = 2
        '
        'txtMailPass
        '
        Me.txtMailPass.Location = New System.Drawing.Point(105, 81)
        Me.txtMailPass.Name = "txtMailPass"
        Me.txtMailPass.Size = New System.Drawing.Size(235, 19)
        Me.txtMailPass.TabIndex = 3
        '
        'btnReg
        '
        Me.btnReg.Location = New System.Drawing.Point(156, 106)
        Me.btnReg.Name = "btnReg"
        Me.btnReg.Size = New System.Drawing.Size(89, 27)
        Me.btnReg.TabIndex = 4
        Me.btnReg.Text = "登録"
        Me.btnReg.UseVisualStyleBackColor = True
        '
        'txtMailAddress
        '
        Me.txtMailAddress.Location = New System.Drawing.Point(105, 31)
        Me.txtMailAddress.Name = "txtMailAddress"
        Me.txtMailAddress.Size = New System.Drawing.Size(235, 19)
        Me.txtMailAddress.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 12)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "メールアドレス"
        '
        'frmKojin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 147)
        Me.Controls.Add(Me.txtMailAddress)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnReg)
        Me.Controls.Add(Me.txtMailPass)
        Me.Controls.Add(Me.txtMailAccount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmKojin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "個人設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMailAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtMailPass As System.Windows.Forms.TextBox
    Friend WithEvents btnReg As System.Windows.Forms.Button
    Friend WithEvents txtMailAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
