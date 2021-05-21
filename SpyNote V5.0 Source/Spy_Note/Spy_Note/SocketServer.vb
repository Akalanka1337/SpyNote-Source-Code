Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class SocketServer
    Public ListenerTCP As New List(Of TcpListener), Clients() As Socket, RemotesAddress() As String, Online As New List(Of Integer)
    Private MaxClients% = 0, i% = -1, Infinity% = -1, Buffer% = Integer.MaxValue
    Public Syn$ = "c2x2824x828200x0c"
    Public Split_Packets$ = "b4x7004x700x4b"
    Public SplitData$ = "fxf0x4x4x0fxf"
    Public split_Ary$ = "c0c1c3a2c0c1c"
    Public split_Line$ = "9xf89fff9xf89"
    Public split_paths$ = "e1x1114x61114e"
    Public Event log_S(ByVal NClient%, ByVal Data_0$, ByVal errors_0$)
    Public Event Data(ByVal NClient%, ByVal Data_0$, ByVal id_0$, ByVal NAClient_0$)
    Public Event DisConnected(ByVal NClient%)
    Public Event Connected(ByVal NClient%)
    Public Event title(ByVal Online_L$, ByVal getAlPorts$, ByVal refP$)
    Public Event wiatLst(ByVal ls As Boolean)
    Public TcpState As Boolean = True
    Public BytesSent As Long = 0
    Public BytesReceived As Long = 0
    '    Long Kb = 1 * 1024
    '    Long Mb = Kb * 1024
    '    Long Gb = Mb * 1024  '1073741824 '  gb
    '    Long Tb = Gb * 1024
    '    Long Pb = Tb * 1024
    '    Long Eb = Pb * 1024
    Function Start(ByVal Port As String) As Boolean
        Try
            ListenerTCP.Clear()
            TcpState = True : i = -1
            MaxClients = My.Settings.Maximum_Clients
            ReDim Clients(MaxClients) : ReDim RemotesAddress(MaxClients)
            Dim OFP As System.Threading.Thread = New Threading.Thread(AddressOf store_0.Open_firewall_port)
            OFP.IsBackground = True
            OFP.Start(Port)
            Dim ary$() = Port.Trim.Split(",")
            For Each prt In ary
                If IsNumeric(prt) Then
                    Try
                        If TcpState = False Then GoTo nex
                        Dim MyTcpListener = New TcpListener(Net.IPAddress.Any, CInt(prt))
                        ListenerTCP.Add(MyTcpListener)
                        ListenerTCP(ListenerTCP.Count - 1).Server.SendTimeout = Infinity
                        ListenerTCP(ListenerTCP.Count - 1).Server.ReceiveTimeout = Infinity
                        ListenerTCP(ListenerTCP.Count - 1).Server.ReceiveBufferSize = Buffer
                        ListenerTCP(ListenerTCP.Count - 1).Server.SendBufferSize = Buffer
                        ListenerTCP(ListenerTCP.Count - 1).Start()
                        RaiseEvent log_S(-1, "Listener", "Active " + CStr(prt))
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical, store_0.name_prog + " [" + CStr(prt) + "]<Port")
                        RaiseEvent log_S(-1, "Listener", "Not Active " + CStr(prt) + Space(1) + ex.Message)
                        CloseAllServers()
                        GoTo nex
                    End Try
                Else
                    CloseAllServers()
                    GoTo nex
                End If
            Next
            Dim a As System.Threading.Thread = New Threading.Thread(AddressOf accept)
            a.IsBackground = True
            a.Start()
            Form1.Icon = store_0.icons_0("window")
            RaiseEvent title(CStr(Online.Count.ToString), GetPortsAllServers, "x-x")
            Return True
        Catch ex As Exception
            'MsgBox(ex.ToString)
            CloseAllServers()
        End Try
nex:
        Return False
    End Function
    Public Sub CloseAllServers()
        Try
            If ListenerTCP.ToArray.Length > 0 Then
                For a% = 0 To ListenerTCP.Count - 1
                    Dim strPort$ = CStr(CType(ListenerTCP(a).Server.LocalEndPoint, IPEndPoint).Port.ToString())
                    ListenerTCP(a).Server.Close()

                    RaiseEvent log_S(-1, "Listener", "This Port is closed  >" + strPort)
                Next
                ListenerTCP.Clear()
                RaiseEvent wiatLst(False)
                RaiseEvent title(CStr(Online.Count.ToString), GetPortsAllServers, "x-x")
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function GetPortsAllServers()
        Try
            If TcpState Then
                Dim b As New StringBuilder
                For Each lste In ListenerTCP
                    b.Append((CType(lste.LocalEndpoint, IPEndPoint).Port.ToString() + ","))
                Next
                If Not b.ToString.Length <= 0 Then
                    Return b.ToString.Remove(b.ToString.Length - 1).ToString
                Else
                    Return "-1"
                End If
            Else
                Return "-1"
            End If
        Catch ex As Exception
            Return "-1"
        End Try
    End Function
    Sub Send(ByVal i%, ByVal str$)
        If TcpState Then
            Send_0(i, store_0.Encoding_0.GetBytes(Space(1) + Syn + str + Syn))
        End If
    End Sub
    Sub Send_0(ByVal i%, ByVal byte_0 As Byte())
        Dim thread As New Thread(Sub()
                                     If TcpState Then
                                         Try
                                             Dim myNetworkStream As New NetworkStream(Clients(i))
                                             If myNetworkStream.CanWrite Then
                                                 Dim numberOfBytesWrite As Integer = byte_0.Length
                                                 BytesSent += numberOfBytesWrite
                                                 myNetworkStream.Write(byte_0, 0, byte_0.Length)
                                                 myNetworkStream.Flush()
                                             End If

                                         Catch ex As Exception
                                             'MsgBox(ex.ToString)
                                         End Try
                                     End If
                                 End Sub)
        thread.Start()
    End Sub
    Private Function new_Client() As Integer
        While (TcpState) : Threading.Thread.Sleep(store_0.CPU)
            If Not TcpState = False Then
                If i + 1 >= Clients.Length - 1 Then i = -1
                i += 1
                SyncLock Online
                    If Online.Contains(i) = False Then
                        Online.Add(i)
                        Threading.Thread.Sleep(store_0.CPU)
                        RaiseEvent title(CStr(Online.Count.ToString), GetPortsAllServers, "x-x")
                        Return CInt(i.ToString.Clone)
                    End If
                End SyncLock
                If Online.Count >= Clients.Length - 1 Then
                    Exit While
                End If
            Else
                Exit While
            End If
        End While
        Return -1
    End Function
    Private Sub accept()
        While (TcpState) : Threading.Thread.Sleep(store_0.CPU)
            If TcpState Then
                Try
                    Dim i_0%
                    For Each lste In ListenerTCP
                        If lste.Pending Then
                            If Not Online.Count - 1 >= Clients.Length - 1 Then
                                i_0 = new_Client()
                                If TcpState = False Then GoTo nx
                                Clients(i_0) = lste.AcceptSocket
                                Dim Asy As System.Threading.Thread = New Threading.Thread(AddressOf Pending)
                                Asy.IsBackground = True
                                Asy.Start(i_0)
                            End If
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
            End If
        End While
nx:
        Exit Sub
    End Sub
    Private Sub Pending(i%)
        Try
            If TcpState Then
                If Not Online.Count - 1 >= Clients.Length - 1 Then
                    If TcpState = False Then GoTo nx

                    Clients(i).ReceiveBufferSize = Buffer
                    Clients(i).SendBufferSize = Buffer
                    Clients(i).ReceiveTimeout = Infinity
                    Clients(i).SendTimeout = Infinity

                    If TcpState = False Then GoTo nx
                    Dim RecI As System.Threading.Thread = New Threading.Thread(AddressOf Receive)
                    RecI.IsBackground = True
                    RecI.Start(i)
                    If TcpState = False Then GoTo nx
                    RaiseEvent log_S(i, "Connected", Nothing)
                    Threading.Thread.Sleep(2 * 1000)
                    If TcpState = False Then GoTo nx
                    RaiseEvent Connected(i)
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
nx:
        Exit Sub
    End Sub
    Dim dis_0 As Object = New Object
    Public Sub Disconnect(ByVal i%, ByVal Erro$)

        SyncLock dis_0

            Try
                If Online.Contains(i) = True Then
                    RaiseEvent log_S(i, "DisConnected", Erro)
                    Online.Remove(i)
                    RaiseEvent title(CStr(Online.Count.ToString), GetPortsAllServers, "x-x")
                    Try
                        Clients(i).Disconnect(False)
                        Clients(i).Close()
                        Clients(i).Dispose()
                        Clients(i) = Nothing
                        RaiseEvent DisConnected(i)
                    Catch ex As Exception

                    End Try


                End If
            Catch ex As Exception
            End Try
        End SyncLock
    End Sub
    Private Sub yPing(ByVal i%)
        Do
            Thread.Sleep(30 * 1000)
            Send(i, "ping")
        Loop While (TcpState)
    End Sub
    Private Sub Receive(ByVal i%)
        Dim setping As System.Threading.Thread = New Threading.Thread(AddressOf yPing)
        setping.IsBackground = True
        setping.Start(i)
        Dim Erro$ = Nothing
        If TcpState = False Then GoTo nx
        Dim myNetworkStream As New NetworkStream(Clients(i))
        While (TcpState) : Threading.Thread.Sleep(store_0.CPU)
            Try
                If TcpState = False Then GoTo nx
                If Clients(i) IsNot Nothing Then
                    If TcpState = False Then GoTo nx
                    If Clients(i).Connected Then
                        If myNetworkStream.CanRead Then
                            Dim myCompleteMessage As StringBuilder = New StringBuilder()
                            Dim numberOfBytesRead As Integer = 0
                            While (TcpState) : Threading.Thread.Sleep(store_0.CPU)
                                If TcpState = False Then GoTo nx
                                Dim intNumRxBytes As Integer = Clients(i).Available
                                Dim myReadBuffer(intNumRxBytes - 1) As Byte
                                '|>> STOP here

                                numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length)
                                myCompleteMessage.AppendFormat("{0}", store_0.Encoding_0.GetString(myReadBuffer, 0, numberOfBytesRead))
                                BytesReceived += numberOfBytesRead


                                If myCompleteMessage.ToString().Contains(Syn) Then

                                    If myCompleteMessage.ToString().StartsWith(Syn) Then

                                        If myCompleteMessage.ToString().EndsWith(Syn) Then

                                            Dim Synspl() As String = {Syn}
                                            Dim Array1() As String = (myCompleteMessage.ToString()).Split(Synspl, StringSplitOptions.None)
                                            For Each spld In Array1
                                                If (spld.ToString()).Contains(Split_Packets) Then
                                                    Dim split_data() As String = {Split_Packets}
                                                    Dim Array() As String = (spld.ToString()).Split(split_data, StringSplitOptions.None)
                                                    If Array.Length = 3 Then

                                                        RaiseEvent Data(i, Array(0), Array(1), Array(2))
                                                    End If
                                                End If
                                            Next
                                            Exit While
                                        End If
                                    End If
                                End If
                            End While
                        Else
                            Erro = "Sorry.  You cannot read from this NetworkStream." + " (55)"
                            Exit While
                        End If
                        myNetworkStream.Flush()
                    Else
                        Erro = "Not Connected" + " (56)"
                        Exit While
                    End If
                Else
                    Erro = "Empty" + " (57)"
                    Exit While
                End If
            Catch ex As Exception
                Erro = ex.Message + " (53)"
                Exit While
            End Try
        End While
nx:

        Try

            Disconnect(i, Erro)
        Catch ex As Exception
        End Try
    End Sub
    Public Function getRemote_Address(ByRef i%, ByRef s_o%) As String
        If TcpState Then
            Try
                Select Case s_o
                    Case 0
                        RemotesAddress(i) = Clients(i).RemoteEndPoint.ToString().Split(":")(0)
                        Return RemotesAddress(i)
                    Case 1
                        RemotesAddress(i) = Clients(i).RemoteEndPoint.ToString().Split(":")(0) + " & " + CType(Clients(i).LocalEndPoint, IPEndPoint).Port.ToString()
                        Return RemotesAddress(i)
                    Case Else
                        Return "0.0.0.0:0"
                End Select
            Catch ex As Exception
                Return "0.0.0.0:0"
            End Try
        Else
            Return "0.0.0.0:0"
        End If
    End Function
    Public Sub endserver(z%)
        RaiseEvent log_S(-1, "DisConnected", "Disconnect all clients, waiting for the port to close")
        TcpState = False
        For a% = 0 To Online.Count
            If Online.Contains(a) = True Then
                Disconnect(a, Nothing)
            End If
        Next
        Online.Clear()
        i = -1
        CloseAllServers()
        If z = 0 Then
            Try
                End
            Catch : Finally
                End
            End Try
        End If
    End Sub
End Class