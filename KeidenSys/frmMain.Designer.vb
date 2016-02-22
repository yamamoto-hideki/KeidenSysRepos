<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnHiyari = New System.Windows.Forms.Button()
        Me.btnKojin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(363, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(89, 27)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "終了"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHiyari
        '
        Me.btnHiyari.Location = New System.Drawing.Point(12, 11)
        Me.btnHiyari.Name = "btnHiyari"
        Me.btnHiyari.Size = New System.Drawing.Size(89, 27)
        Me.btnHiyari.TabIndex = 1
        Me.btnHiyari.Text = "ヒヤリハット"
        Me.btnHiyari.UseVisualStyleBackColor = True
        '
        'btnKojin
        '
        Me.btnKojin.Location = New System.Drawing.Point(268, 12)
        Me.btnKojin.Name = "btnKojin"
        Me.btnKojin.Size = New System.Drawing.Size(89, 27)
        Me.btnKojin.TabIndex = 2
        Me.btnKojin.Text = "個人設定"
        Me.btnKojin.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 50)
        Me.Controls.Add(Me.btnKojin)
        Me.Controls.Add(Me.btnHiyari)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "三和計電"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnHiyari As System.Windows.Forms.Button
    Friend WithEvents btnKojin As System.Windows.Forms.Button

End Class
