

Public Class ExComboBox

    Private m_id As String = ""
    Private m_name As String = ""

    'コンストラクタ
    Public Sub New(ByVal id As String, ByVal name As String)
        m_id = id
        m_name = name
    End Sub

    '値(非表示)
    Public ReadOnly Property Id() As String
        Get
            Return m_id
        End Get
    End Property

    '表示項目
    Public ReadOnly Property Name() As String
        Get
            Return m_name
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return m_name
    End Function

End Class
