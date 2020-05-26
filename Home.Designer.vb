<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnUninstall = New System.Windows.Forms.Button()
        Me.boxSearch = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReload
        '
        Me.btnReload.BackColor = System.Drawing.SystemColors.Control
        Me.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReload.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnReload.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReload.Location = New System.Drawing.Point(254, 483)
        Me.btnReload.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(85, 28)
        Me.btnReload.TabIndex = 0
        Me.btnReload.Text = "刷新"
        Me.btnReload.UseVisualStyleBackColor = False
        '
        'btnUninstall
        '
        Me.btnUninstall.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnUninstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUninstall.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnUninstall.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUninstall.Location = New System.Drawing.Point(346, 483)
        Me.btnUninstall.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(85, 28)
        Me.btnUninstall.TabIndex = 4
        Me.btnUninstall.Text = "解除安裝"
        Me.btnUninstall.UseVisualStyleBackColor = False
        '
        'boxSearch
        '
        Me.boxSearch.BackColor = System.Drawing.SystemColors.Window
        Me.boxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxSearch.ForeColor = System.Drawing.SystemColors.InfoText
        Me.boxSearch.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.boxSearch.Location = New System.Drawing.Point(13, 446)
        Me.boxSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.boxSearch.Name = "boxSearch"
        Me.boxSearch.Size = New System.Drawing.Size(341, 28)
        Me.boxSearch.TabIndex = 1
        Me.boxSearch.TabStop = False
        Me.boxSearch.Text = "搜尋..."
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 8.765218!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 520)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "注意:請不要移除系統必要軟體以免造成手機無法正常運作"
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Window
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(13, 46)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(418, 342)
        Me.ListBox1.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnReload)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnUninstall)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(442, 540)
        Me.Panel1.TabIndex = 13
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(13, 482)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 23)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "移除程式資料"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(364, 445)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "GO"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 407)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 35)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "執行操作"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 35)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "選擇應用程式"
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(442, 540)
        Me.Controls.Add(Me.boxSearch)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "Home"
        Me.Text = "解除原廠軟體免ROOT"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnReload As Button
    Friend WithEvents ListAppList As ListBox
    Friend WithEvents boxSearch As TextBox
    Friend WithEvents btnUninstall As Button
    Public WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox1 As CheckBox
End Class
