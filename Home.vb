Imports System.IO
Imports System.Threading

Public Class Home
    Dim nOldWndLeft, nOldWndTop, nClickX, nClickY As Integer
    Dim logadd As String = ""
    Private Sub TitleBar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        '紀錄滑鼠點選時的視窗位置與滑鼠點選位置
        nOldWndLeft = Me.Left
        nOldWndTop = Me.Top
        nClickX = e.X
        nClickY = e.Y
    End Sub

    Dim listthr As Thread '宣告多線程

    Dim reloadthr As Thread
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("注意:部分中國手機無法支援!!" + vbCrLf + "請不要嘗試解除安裝你沒把握的應用程式" + vbCrLf + "解除安裝系統必要程式會造成Android系統的損壞" + vbCrLf + "GitTorch Studio 並不會為您的誤操作負責" + vbCrLf + "當您按下確定之後即同意以上條款", vbExclamation, "免責聲明")

        Dim checkFile As Thread
        checkFile = New Thread(AddressOf Me.checkFile)
        reloadthr = New Thread(AddressOf Me.reload)
        checkFile.Start()
        Timer1.Enabled = True
        Timer1.Start()

    End Sub
    Public Sub checkFile()
        If Not Directory.Exists(Application.LocalUserAppDataPath + "platform-tools") Then
            logadd += "遺失主資料夾...正在生成資料夾"
            Directory.CreateDirectory(Application.LocalUserAppDataPath + "platform-tools")
        End If
        If Not File.Exists(Application.LocalUserAppDataPath + "platform-tools\adb.exe") Then
            logadd += "遺失主核心...正在生成adb.exe"
            File.WriteAllBytes(Application.LocalUserAppDataPath + "platform-tools\adb.exe", My.Resources.adb)
        End If
        If Not File.Exists(Application.LocalUserAppDataPath + "platform-tools\AdbWinApi.dll") Then
            logadd += "遺失主核心...正在生成AdbWinApi.dll"
            File.WriteAllBytes(Application.LocalUserAppDataPath + "platform-tools\AdbWinApi.dll", My.Resources.AdbWinApi)
        End If
        If Not File.Exists(Application.LocalUserAppDataPath + "platform-tools\AdbWinUsbApi.dll") Then
            logadd += "遺失主核心...正在生成AdbWinUsbApi.dll"
            File.WriteAllBytes(Application.LocalUserAppDataPath + "platform-tools\AdbWinUsbApi.dll", My.Resources.AdbWinUsbApi)
        End If
        If Not File.Exists(Application.LocalUserAppDataPath + "platform-tools\fastboot.exe") Then
            logadd += "遺失主核心...正在生成fastboot.exe"
            File.WriteAllBytes(Application.LocalUserAppDataPath + "platform-tools\fastboot.exe", My.Resources.fastboot)
        End If
        logadd += "處理完畢..."
        reloadthr.Start()

    End Sub


    Function adb(Arguments As String) As String
        Try

            Dim My_Process As New Process()
            Dim My_Process_Info As New ProcessStartInfo()

            My_Process_Info.FileName = "cmd.exe" ' Process filename
            My_Process_Info.Arguments = Arguments ' Process arguments
            My_Process_Info.WorkingDirectory = Application.LocalUserAppDataPath + "platform-tools" 'this directory can be different in your case.
            My_Process_Info.CreateNoWindow = True  ' Show or hide the process Window
            My_Process_Info.UseShellExecute = False ' Don't use system shell to execute the process
            My_Process_Info.RedirectStandardOutput = True  '  Redirect (1) Output
            My_Process_Info.RedirectStandardError = True  ' Redirect non (1) Output

            My_Process.EnableRaisingEvents = True ' Raise events
            My_Process.StartInfo = My_Process_Info
            My_Process.Start() ' Run the process NOW

            Dim Process_ErrorOutput As String = My_Process.StandardOutput.ReadToEnd() ' Stores the Error Output (If any)
            Dim Process_StandardOutput As String = My_Process.StandardOutput.ReadToEnd() ' Stores the Standard Output (If any)

            ' Return output by priority
            If Process_ErrorOutput IsNot Nothing Then Return Process_ErrorOutput ' Returns the ErrorOutput (if any)
            If Process_StandardOutput IsNot Nothing Then Return Process_StandardOutput ' Returns the StandardOutput (if any)

        Catch ex As Exception
            Return ex.Message
        End Try

        Return "OK"
    End Function
    '刷新
    Dim clear As Boolean = False
    Dim device As Boolean = False
    Dim 授權 As Boolean = False
    Function reload()
        '獲取已連線之裝置
        Dim devicesStr As String = adb("/c adb devices") : Dim checkdevice As Array = devicesStr.Split(" ")
        logadd = devicesStr
        '判斷有沒有連上裝置
        Try
            If checkdevice(3)(10) = vbCr Then
                logadd += "尚未連結裝置" + vbCrLf
                MsgBox("請連接上您的手機", 48)
                device = False
                授權 = False
            ElseIf checkdevice(3).Split(vbTab)(1).Split(vbCrLf)(0) = "unauthorized" Then
                logadd += "請授權電腦" + vbCrLf
                MsgBox("請授權電腦", 48)
                device = True
                授權 = False
            Else
                logadd += "授權成功" + vbCrLf
                device = True
                clear = True
                授權 = True
                '取得應用程式列表
                listthr = New Thread(AddressOf Me.getList)
                listthr.Start()
            End If
        Catch ex As Exception
            logadd += ex.Message
        End Try
        reloadthr = Nothing
        Return 0
    End Function
    Dim APPLISTPUBLIC As Queue = New Queue()
    Public Sub getList()
        logadd += "開始搜尋程式列表" + vbCrLf
        Dim StrAppList = adb("/c adb shell pm list packages")
        Dim ArrayAppListTemp = StrAppList.Split(vbCr)
        Dim ArrayAppList(ArrayAppListTemp.Length) As String
        For index As Integer = 0 To ArrayAppListTemp.Length - 2
            ArrayAppList(index) = ArrayAppListTemp(index).Split(":")(1) '取得package:後方的字packagename
            APPLISTPUBLIC.Enqueue(ArrayAppList(index))
        Next
        logadd += "應用程式清單初步載入成功" + vbCrLf
        listthr = Nothing
    End Sub
    Dim appex As Boolean
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        appex = False
        If boxSearch.Text = "搜尋..." Then
            scr = ""
        End If
        'boxLog.Text = logadd
        Dim a As Integer = 0
        If clear Then
            APPLISTPUBLIC.Clear()
            ListBox1.Items.Clear() '清除listview
            clear = False
        End If
        While APPLISTPUBLIC.Count <> 0 And a < 10
            Dim w As String = APPLISTPUBLIC.Dequeue()
            '判斷輸入框內容
            If scr = "" Then
                ListBox1.Items.Add(w)
                a += 1
                appex = True
            ElseIf w.IndexOf(scr) <> -1 Then
                ListBox1.Items.Add(w)
                a += 1
                appex = True
            End If
        End While
    End Sub
    Dim checkk As Boolean = True
    Dim alertcheck As String = ""
    Private Sub Uninstall(uninstallappname As String, sender As Object, e As EventArgs)
        If CheckBox1.Checked = True Then '要移除
            alertcheck = " 並移除程式資料"
        Else
            alertcheck = " 並保留程式資料"
        End If
        Try
            Dim ans As Integer = MsgBox("確定解除安裝" + uninstallappname + alertcheck + " ?" + vbCrLf + "注意:請不要移除系統必要軟體以免手機無法正常運作", 4 + 48, "請再次確認")
            If ans = 6 Then
                Try
                    If CheckBox1.Checked Then
                        logadd += adb("/c adb shell pm uninstall --user 0 " + uninstallappname.ToString)
                    Else
                        logadd += adb("/c adb shell pm uninstall --user 0 -k " + uninstallappname.ToString)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf ans = 7 Then
                MsgBox("已取消", vbOKOnly + vbInformation, "已取消")
            End If
            'MsgBox("解除安裝結束，再次檢查應用程式列表")
            Label2.Text += "...更新中"
            btnReload_Click(sender, e)
            boxSearch.Text = "搜尋..."
            Label2.Text = "選擇應用程式"
        Catch

        End Try

    End Sub
    Private Sub BoxSearch_MouseClick(sender As Object, e As EventArgs) Handles boxSearch.MouseClick
        If boxSearch.Text = "搜尋..." Then
            boxSearch.Text = ""
        End If
    End Sub
    Private Sub BoxSearch_LostFocus(sender As Object, e As EventArgs) Handles boxSearch.LostFocus
        If boxSearch.Text = "" Then
            boxSearch.Text = "搜尋..."
        End If
    End Sub
    Dim scr As String = ""
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If boxSearch.Text <> "搜尋..." Then
            scr = boxSearch.Text
        Else
            scr = ""
        End If
        reloadthr = New Thread(AddressOf Me.reload)
        reloadthr.Start()
    End Sub

    Private Sub BoxSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles boxSearch.KeyDown
        If e.KeyCode = "13" Then
            Button2_Click(sender, e)
        End If
    End Sub
    Function btnReload_Click(sender As System.Object, e As System.EventArgs) Handles btnReload.Click
        reloadthr = New Thread(AddressOf Me.reload)
        reloadthr.Start()
        Return 0
    End Function

    Private Sub Label1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover, Label1.MouseEnter
        Label1.ForeColor = Color.Red
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = DefaultForeColor
    End Sub


    Private Sub BoxSearch_Leave(sender As Object, e As EventArgs) Handles boxSearch.Leave
        boxSearch.Text = "搜尋..."
    End Sub

    Dim uninstallthr As Thread

    Private Sub btnUninstall_Click(sender As Object, e As EventArgs) Handles btnUninstall.Click
        Try
            Dim uninstallappname As String
            If device = False Then
                MsgBox("請連接手機", vbExclamation)
            ElseIf 授權 = False Then
                MsgBox("請授權電腦" + vbCrLf + "已授權請先刷新", vbExclamation)
            ElseIf ListBox1.SelectedItems.Count = 0 Then
                MsgBox("請選擇應用程式", vbExclamation)
            End If
            logadd += ListBox1.SelectedItem.ToString
            uninstallappname = ListBox1.SelectedItem.ToString
            Uninstall(uninstallappname, sender, e)
        Catch

        End Try
        'uninstallthr = New Thread(AddressOf Me.Uninstall)
    End Sub
End Class


