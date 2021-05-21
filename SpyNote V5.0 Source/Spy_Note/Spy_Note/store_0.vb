Imports System.Text

Public Module store_0
    Public name_prog$ = "SpyNote", name_folder_app_resource$ = "App_Resources"
    Public CPU% = 1
    Public Sub myProcessPreference()
        Try
            Dim myProcess As Process = Process.GetCurrentProcess()
            Select Case CInt(My.Settings.Process_Priority)
                Case 0
                    myProcess.PriorityClass = ProcessPriorityClass.RealTime
                Case 1
                    myProcess.PriorityClass = ProcessPriorityClass.High
                Case 2
                    myProcess.PriorityClass = ProcessPriorityClass.AboveNormal
                Case 3
                    myProcess.PriorityClass = ProcessPriorityClass.Normal
                Case 4
                    myProcess.PriorityClass = ProcessPriorityClass.BelowNormal
                Case 5
                    myProcess.PriorityClass = ProcessPriorityClass.Idle
                Case Else
                    myProcess.PriorityClass = ProcessPriorityClass.Normal
            End Select

        Catch : End Try

    End Sub

    Public CountryName As String() = {"N/A", "Asia/Pacific Region", "Europe", "Andorra", "United Arab Emirates", "Afghanistan", "Antigua and Barbuda", "Anguilla", "Albania", "Armenia", "Netherlands Antilles", "Angola", "Antarctica", "Argentina", "American Samoa", "Austria", "Australia", "Aruba", "Azerbaijan", "Bosnia and Herzegovina", "Barbados", "Bangladesh", "Belgium", "Burkina Faso", "Bulgaria", "Bahrain", "Burundi", "Benin", "Bermuda", "Brunei Darussalam", "Bolivia", "Brazil", "Bahamas", "Bhutan", "Bouvet Island", "Botswana", "Belarus", "Belize", "Canada", "Cocos (Keeling) Islands", "Congo, The Democratic Republic of the", "Central African Republic", "Congo", "Switzerland", "Cote D'Ivoire", "Cook Islands", "Chile", "Cameroon", "China", "Colombia", "Costa Rica", "Cuba", "Cape Verde", "Christmas Island", "Cyprus", "Czech Republic", "Germany", "Djibouti", "Denmark", "Dominica", "Dominican Republic", "Algeria", "Ecuador", "Estonia", "Egypt", "Western Sahara", "Eritrea", "Spain", "Ethiopia", "Finland", "Fiji", "Falkland Islands (Malvinas)", "Micronesia, Federated States of", "Faroe Islands", "France", "France, Metropolitan", "Gabon", "United Kingdom", "Grenada", "Georgia", "French Guiana", "Ghana", "Gibraltar", "Greenland", "Gambia", "Guinea", "Guadeloupe", "Equatorial Guinea", "Greece", "South Georgia and the South Sandwich Islands", "Guatemala", "Guam", "Guinea-Bissau", "Guyana", "Hong Kong", "Heard Island and McDonald Islands", "Honduras", "Croatia", "Haiti", "Hungary", "Indonesia", "Ireland", "Israel", "India", "British Indian Ocean Territory", "Iraq", "Iran, Islamic Republic of", "Iceland", "Italy", "Jamaica", "Jordan", "Japan", "Kenya", "Kyrgyzstan", "Cambodia", "Kiribati", "Comoros", "Saint Kitts and Nevis", "Korea, Democratic People's Republic of", "Korea, Republic of", "Kuwait", "Cayman Islands", "Kazakstan", "Lao People's Democratic Republic", "Lebanon", "Saint Lucia", "Liechtenstein", "Sri Lanka", "Liberia", "Lesotho", "Lithuania", "Luxembourg", "Latvia", "Libyan Arab Jamahiriya", "Morocco", "Monaco", "Moldova, Republic of", "Madagascar", "Marshall Islands", "Macedonia, the Former Yugoslav Republic of", "Mali", "Myanmar", "Mongolia", "Macao", "Northern Mariana Islands", "Martinique", "Mauritania", "Montserrat", "Malta", "Mauritius", "Maldives", "Malawi", "Mexico", "Malaysia", "Mozambique", "Namibia", "New Caledonia", "Niger", "Norfolk Island", "Nigeria", "Nicaragua", "Netherlands", "Norway", "Nepal", "Nauru", "Niue", "New Zealand", "Oman", "Panama", "Peru", "French Polynesia", "Papua New Guinea", "Philippines", "Pakistan", "Poland", "Saint Pierre and Miquelon", "Pitcairn", "Puerto Rico", "Palestinian Territory, Occupied", "Portugal", "Palau", "Paraguay", "Qatar", "Reunion", "Romania", "Russian Federation", "Rwanda", "Saudi Arabia", "Solomon Islands", "Seychelles", "Sudan", "Sweden", "Singapore", "Saint Helena", "Slovenia", "Svalbard and Jan Mayen", "Slovakia", "Sierra Leone", "San Marino", "Senegal", "Somalia", "Suriname", "Sao Tome and Principe", "El Salvador", "Syrian Arab Republic", "Swaziland", "Turks and Caicos Islands", "Chad", "French Southern Territories", "Togo", "Thailand", "Tajikistan", "Tokelau", "Turkmenistan", "Tunisia", "Tonga", "Timor-Leste", "Turkey", "Trinidad and Tobago", "Tuvalu", "Taiwan, Province of China", "Tanzania, United Republic of", "Ukraine", "Uganda", "United States Minor Outlying Islands", "United States", "Uruguay", "Uzbekistan", "Holy See (Vatican City State)", "Saint Vincent and the Grenadines", "Venezuela", "Virgin Islands, British", "Virgin Islands, U.S.", "Vietnam", "Vanuatu", "Wallis and Futuna", "Samoa", "Yemen", "Mayotte", "Yugoslavia", "South Africa", "Zambia", "Montenegro", "Zimbabwe", "Anonymous Proxy", "Satellite Provider", "Other", "Aland Islands", "Guernsey", "Isle of Man", "Jersey", "Saint Barthelemy", "Saint Martin"}
    Public CountryCode As String() = {"N/A", "AP", "EU", "AD", "AE", "AF", "AG", "AI", "AL", "AM", "AN", "AO", "AQ", "AR", "AS", "AT", "AU", "AW", "AZ", "BA", "BB", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BM", "BN", "BO", "BR", "BS", "BT", "BV", "BW", "BY", "BZ", "CA", "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM", "CN", "CO", "CR", "CU", "CV", "CX", "CY", "CZ", "DE", "DJ", "DK", "DM", "DO", "DZ", "EC", "EE", "EG", "EH", "ER", "ES", "ET", "FI", "FJ", "FK", "FM", "FO", "FR", "FX", "GA", "GB", "GD", "GE", "GF", "GH", "GI", "GL", "GM", "GN", "GP", "GQ", "GR", "GS", "GT", "GU", "GW", "GY", "HK", "HM", "HN", "HR", "HT", "HU", "ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT", "JM", "JO", "JP", "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ", "LA", "LB", "LC", "LI", "LK", "LR", "LS", "LT", "LU", "LV", "LY", "MA", "MC", "MD", "MG", "MH", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", "NA", "NC", "NE", "NF", "NG", "NI", "NL", "NO", "NP", "NR", "NU", "NZ", "OM", "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", "PN", "PR", "PS", "PT", "PW", "PY", "QA", "RE", "RO", "RU", "RW", "SA", "SB", "SC", "SD", "SE", "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SR", "ST", "SV", "SY", "SZ", "TC", "TD", "TF", "TG", "TH", "TJ", "TK", "TM", "TN", "TO", "TL", "TR", "TT", "TV", "TW", "TZ", "UA", "UG", "UM", "US", "UY", "UZ", "VA", "VC", "VE", "VG", "VI", "VN", "VU", "WF", "WS", "YE", "YT", "SAU", "RS", "ZA", "ZM", "ME", "ZW", "A1", "A2", "O1", "AX", "GG", "IM", "JE", "BL", "MF"}
    Public CountryNump As String() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "122", "123", "124", "125", "126", "127", "128", "129", "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "140", "141", "142", "143", "144", "145", "146", "147", "148", "149", "150", "151", "152", "153", "154", "155", "156", "157", "158", "159", "160", "161", "162", "163", "164", "165", "166", "167", "168", "169", "170", "171", "172", "173", "174", "175", "176", "177", "178", "179", "180", "181", "182", "183", "184", "185", "186", "187", "188", "189", "190", "191", "192", "193", "194", "195", "196", "197", "198", "199", "200", "201", "202", "203", "204", "205", "206", "207", "208", "209", "210", "211", "212", "213", "214", "215", "216", "217", "218", "219", "220", "221", "222", "223", "224", "225", "226", "227", "228", "229", "230", "231", "232", "233", "234", "235", "236", "237", "238", "239", "240", "241", "242", "243", "244", "245", "246", "247", "248", "249", "250", "251", "252", "253", "254"}
    Function Encoding_0() As Encoding
        Select Case My.Settings.Data_encoding
            Case 0


                Return System.Text.Encoding.Default
            Case 1
                Return System.Text.Encoding.UTF7
            Case 2
                Return System.Text.Encoding.UTF8
            Case 3
                Return System.Text.Encoding.UTF32
            Case 4
                Return System.Text.Encoding.Unicode
            Case 5
                Return System.Text.Encoding.ASCII
            Case 6
                Return System.Text.Encoding.BigEndianUnicode
            Case Else
                Return System.Text.Encoding.Default
        End Select

    End Function

    Public Function IF_Admin()
        Try
            If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
                Return True
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function
    Public Sub Open_firewall_port(port_01 As String)
        Try



            If IF_Admin() Then
                Dim b As New StringBuilder
                Dim ary$() = port_01.Trim.Split(",")
                For Each prt In ary
                    If IsNumeric(prt) Then
                        b.Append(prt + ",")
                    Else
                        GoTo nx
                    End If
                Next
                b.ToString.Remove(b.ToString.Length - 1)

                Dim cmd_0 As ProcessStartInfo = New ProcessStartInfo("cmd.exe")
                Dim Process_0 As Process
                cmd_0.CreateNoWindow = True
                cmd_0.UseShellExecute = False
                cmd_0.RedirectStandardInput = True
                cmd_0.RedirectStandardOutput = True
                Process_0 = Process.Start(cmd_0)

                'delete
                Process_0.StandardInput.WriteLine("netsh advfirewall firewall delete rule name=" + "" + name_prog + "")
                If My.Settings.Protocol_tcp = 1 Then
                    'in -tcp
                    Process_0.StandardInput.WriteLine("netsh advfirewall firewall add rule name=" + "" + name_prog + "" + " dir=in action=allow protocol=TCP localport=" + b.ToString)
                    'out -tcp
                    Process_0.StandardInput.WriteLine("netsh advfirewall firewall add rule name=" + "" + name_prog + "" + " dir=out action=allow protocol=TCP localport=" + b.ToString)
                End If
                If My.Settings.Protocol_udp = 1 Then
                    'in -udp
                    Process_0.StandardInput.WriteLine("netsh advfirewall firewall add rule name=" + "" + name_prog + "" + " dir=in action=allow protocol=UDP localport=" + b.ToString)
                    'out -udp
                    Process_0.StandardInput.WriteLine("netsh advfirewall firewall add rule name=" + "" + name_prog + "" + " dir=out action=allow protocol=UDP localport=" + b.ToString)
                End If

                Process_0.StandardInput.Close()
            End If
        Catch ex As Exception
        End Try

nx:
        Exit Sub

    End Sub
    Public WithEvents ContextMenu1 As ContextMenuStrip
    Public WithEvents Cut_0, Copy_0, Paste_0, select_all_0, Undo_0 As ToolStripMenuItem
    Public Sub Menu_Items()
        Cut_0 = New ToolStripMenuItem
        Copy_0 = New ToolStripMenuItem
        Paste_0 = New ToolStripMenuItem
        select_all_0 = New ToolStripMenuItem
        Undo_0 = New ToolStripMenuItem


        Cut_0.ImageScaling = ToolStripItemImageScaling.None
        Copy_0.ImageScaling = ToolStripItemImageScaling.None
        Paste_0.ImageScaling = ToolStripItemImageScaling.None
        select_all_0.ImageScaling = ToolStripItemImageScaling.None
        Undo_0.ImageScaling = ToolStripItemImageScaling.None

        Cut_0.Image = store_0.Bitmap_0("ctx_cut")

        Copy_0.Image = store_0.Bitmap_0("ctx_copy")

        Paste_0.Image = store_0.Bitmap_0("ctx_paste")


        Cut_0.Text = "Cut"
        Copy_0.Text = "Copy"
        Paste_0.Text = "Paste"
        select_all_0.Text = "Select All"
        Undo_0.Text = "Undo"
        ContextMenu1 = New ContextMenuStrip
        ContextMenu1.Items.Add(Cut_0)
        ContextMenu1.Items.Add(Copy_0)
        ContextMenu1.Items.Add(Paste_0)
        ContextMenu1.Items.Add(select_all_0)
        ContextMenu1.Items.Add(Undo_0)
        ContextMenu1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        ContextMenu1.Renderer = New Theme_0
    End Sub
    Private Sub Cut_0_Click(sender As Object, e As System.EventArgs) Handles Cut_0.Click
        Dim curContextMenu As ContextMenuStrip = DirectCast(DirectCast(sender, ToolStripItem).Owner, ContextMenuStrip)
        Dim curRTB As RichTextBox = DirectCast(curContextMenu.SourceControl, RichTextBox)
        curRTB.Cut()
    End Sub
    Private Sub Copy_0_Click(sender As Object, e As System.EventArgs) Handles Copy_0.Click
        Dim curContextMenu As ContextMenuStrip = DirectCast(DirectCast(sender, ToolStripItem).Owner, ContextMenuStrip)
        Dim curRTB As RichTextBox = DirectCast(curContextMenu.SourceControl, RichTextBox)
        curRTB.Copy()
    End Sub
    Private Sub Paste_0_Click(sender As Object, e As System.EventArgs) Handles Paste_0.Click
        Dim curContextMenu As ContextMenuStrip = DirectCast(DirectCast(sender, ToolStripItem).Owner, ContextMenuStrip)
        Dim curRTB As RichTextBox = DirectCast(curContextMenu.SourceControl, RichTextBox)
        curRTB.Paste()
    End Sub
    Private Sub select_all_0_Click(sender As Object, e As System.EventArgs) Handles select_all_0.Click
        Dim curContextMenu As ContextMenuStrip = DirectCast(DirectCast(sender, ToolStripItem).Owner, ContextMenuStrip)
        Dim curRTB As RichTextBox = DirectCast(curContextMenu.SourceControl, RichTextBox)
        curRTB.SelectAll()
    End Sub
    Private Sub Undo_0_Click(sender As Object, e As System.EventArgs) Handles Undo_0.Click
        Dim curContextMenu As ContextMenuStrip = DirectCast(DirectCast(sender, ToolStripItem).Owner, ContextMenuStrip)
        Dim curRTB As RichTextBox = DirectCast(curContextMenu.SourceControl, RichTextBox)
        curRTB.Undo()
    End Sub
    Public Function icons_0(cas As String) As Icon
        Try
            Select Case cas
                Case "window"
                    Dim wn As New Icon(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_window\ic_Server.ico")
                    Return wn
                Case "window_error"
                    Dim wn As New Icon(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_window\ic_ServerErr.ico")
                    Return wn
                Case "errors"
                    Dim wn As New Icon(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\errors.ico")
                    Return wn
            End Select
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Public Function Bitmap_0(cas As String) As Bitmap
        Try
            Select Case cas
                Case "img_0"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\about\img_0.psd")
                    Return wn
                Case "chevron_right"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\chevron_right.png")
                    Return wn
                Case "chevron_left"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\chevron-left.png")
                    Return wn
                Case "icon_default"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\icon_default.png")
                    Return wn
                    '\\\
                Case "bluetooth"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\bluetooth.png")
                    Return wn
                Case "gps"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\gps.png")
                    Return wn
                Case "mobile_data"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\mobile_data.png")
                    Return wn
                Case "normal"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\normal.png")
                    Return wn
                Case "silent"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\silent.png")
                    Return wn
                Case "vibrate"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\vibrate.png")
                    Return wn
                Case "wifi_connected"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\wifi_connected.png")
                    Return wn
                Case "wifi_disconnected"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_bar\wifi_disconnected.png")
                    Return wn
                Case "Key&ScreenOn"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_lock\Key&ScreenOn.png")
                    Return wn
                Case "Key&ScreenOff"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_lock\Key&ScreenOff.png")
                    Return wn
                Case "ScreenOn"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_lock\ScreenOn.png")
                    Return wn
                Case "ScreenOff"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_lock\ScreenOff.png")
                    Return wn
                Case "null"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\phone_lock\null.png")
                    Return wn

                Case "Rotate180"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\Rotate180.png")
                    Return wn


                Case "wp"
                    Dim wn As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\wp\null.png")
                    Return wn

                Case "ri_arr"
                    Dim arr As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\ri_arr.png")
                    Return arr
                Case "li_arr"
                    Dim arr As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\li_arr.png")
                    Return arr


                Case "dow_xxx"
                    Dim arr As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\dow.png")
                    Return arr
                Case "up_xxx"
                    Dim arr As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\icon_diverse\up.png")
                    Return arr


                Case "ctx_file_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\f.png")
                    Return ctx
                Case "ctx_sms_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\s.png")
                    Return ctx
                Case "ctx_calls_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\c.png")
                    Return ctx
                Case "ctx_contacts_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\b.png")
                    Return ctx
                Case "ctx_location_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\loc.png")
                    Return ctx
                Case "ctx_account_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\acc.png")
                    Return ctx
                Case "ctx_camera_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\ca.png")
                    Return ctx
                Case "ctx_shell_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\t.png")
                    Return ctx
                Case "ctx_record_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\mc.png")
                    Return ctx
                Case "ctx_applications_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\prg.png")
                    Return ctx
                Case "ctx_keylogger_manager"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\k.png")
                    Return ctx
                Case "ctx_settings"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\set.png")
                    Return ctx
                Case "ctx_phone"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\ph.png")
                    Return ctx
                Case "ctx_chat"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\ch.png")
                    Return ctx
                Case "ctx_open_folder"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\oppf.png")
                    Return ctx
                Case "ctx_refresh"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\re.png")
                    Return ctx
                Case "ctx_upload_file"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\u.png")
                    Return ctx
                Case "ctx_download_file"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\d.png")
                    Return ctx
                Case "ctx_cut"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\cat.png")
                    Return ctx
                Case "ctx_copy"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\cp.png")
                    Return ctx
                Case "ctx_paste"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\pas.png")
                    Return ctx
                Case "ctx_edit"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\ed.png")
                    Return ctx
                Case "ctx_delete"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\del.png")
                    Return ctx
                Case "ctx_add"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\ad.png")
                    Return ctx
                Case "ctx_wallpaper"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\setw.png")
                    Return ctx
                Case "ctx_open_app"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\op_app.png")
                    Return ctx

                Case "ctx_info"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\inf.png")
                    Return ctx
                Case "ctx_play"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\play.png")
                    Return ctx
                Case "ctx_close"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\clo.png")
                    Return ctx
                Case "ctx_rename"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\ren.png")
                    Return ctx
                Case "ctx_lstnPlay"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\play_s.png")
                    Return ctx
                Case "ctx_lstnStop"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\stop_s.png")
                    Return ctx
                Case "ctx_flash"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\flash.png")
                    Return ctx
                Case "ctx_foces"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\foc.png")
                    Return ctx
                Case "ctx_effects"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\eff.png")
                    Return ctx
                Case "ctx_scene"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\sce.png")
                    Return ctx
                Case "ctx_maps"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\ma.png")
                    Return ctx
                Case "ctx_dns"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\dn.png")
                    Return ctx
                Case "ctx_packg"
                    Dim ctx As New Bitmap(Application.StartupPath & "\" & name_folder_app_resource & "\icons\ctx_menu\pack.png")
                    Return ctx
            End Select
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function FormatFileSize(ByVal FileSizeBytes&) As String
        Dim sizeTypes() As String = {"b", "Kb", "Mb", "Gb"}
        Dim Len@ = FileSizeBytes
        Dim sizeType% = 0
        Do While Len > 1024
            Len = Decimal.Round(Len / 1024, 2)
            sizeType += 1
            If sizeType >= sizeTypes.Length - 1 Then Exit Do
        Loop
        Dim Resp$ = Len.ToString & " " & sizeTypes(sizeType)
        Return Resp
    End Function
    Public Function Duration(Time As Integer) As String
        Dim Hrs, Min, Sec As Integer
        Sec = Time Mod 60
        Min = ((Time - Sec) / 60) Mod 60
        Hrs = ((Time - (Sec + (Min * 60))) / 3600) Mod 60
        Return Format(Hrs, "00") & ":" & Format(Min, "00") & ":" & Format(Sec, "00").ToString
    End Function
    Public Function BytesConverter(ByVal bytes As Long) As String
        Dim KB As Long = 1024
        Dim MB As Long = KB * KB
        Dim GB As Long = KB * KB * KB
        Dim TB As Long = KB * KB * KB * KB
        Dim returnVal As String = "0 Bytes"

        Select Case bytes
            Case Is <= KB
                returnVal = bytes & " Bytes"
            Case Is > TB
                returnVal = (bytes / KB / KB / KB / KB).ToString("0.00") & " TB"
            Case Is > GB
                returnVal = (bytes / KB / KB / KB).ToString("0.00") & " GB"
            Case Is > MB
                returnVal = (bytes / KB / KB).ToString("0.00") & " MB"
            Case Is > KB
                returnVal = (bytes / KB).ToString("0.00") & " KB"
        End Select

        Return returnVal.ToString
    End Function


    Public Sub Save_0(cliPath$, dat$)
        Dim thread As New Threading.Thread(Sub()

                                               Try
                                                   Dim f As String = Application.StartupPath & "\" & store_0.name_folder_app_resource & "\Folder_Clients\" & cliPath
                                                   If Not My.Computer.FileSystem.DirectoryExists(f) Then My.Computer.FileSystem.CreateDirectory(f)
                                                   Dim Dat_2 As String = DateTime.Now.ToString("yyyy-MM-dd-HH.mm.ss")
                                                   Dim NAM_2 As String = String.Format("{0:1}", Dat_2, Nothing)

                                                   Dim FF_0 As System.IO.StreamWriter
                                                   FF_0 = My.Computer.FileSystem.OpenTextFileWriter(f + "\" + NAM_2 + ".txt", True)
                                                   FF_0.WriteLine(dat.ToString)
                                                   FF_0.Close()




                                               Catch ex As Exception
                                               End Try
                                           End Sub)
        thread.Start()
    End Sub
End Module
