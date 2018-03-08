Imports System.Runtime.InteropServices
Imports System.Net

Public Class Form1


#Region "DHCPSTUFF"

    'DHCP API reference:
    'http://msdn.microsoft.com/en-us/library/aa363379(v=VS.85).aspx


    Declare Unicode Function DhcpEnumSubnetClients Lib "Dhcpsapi" _
        (ByVal ServerIpAddress As String, _
         ByVal SubnetAddress As Integer, _
         ByRef ResumeHandle As Integer, _
         ByVal PreferredMaximum As Integer, _
         ByRef ClientInfo As IntPtr, _
         ByRef ClientsRead As Integer, _
         ByRef ClientsTotal As Integer) As Integer
    '    DWORD DHCP_API_FUNCTION DhcpEnumSubnetClients(
    '  __in     DHCP_CONST WCHAR *ServerIpAddress,
    '  __in     DHCP_IP_ADDRESS SubnetAddress,
    '  __inout  DHCP_RESUME_HANDLE *ResumeHandle,
    '  __in     DWORD PreferredMaximum,
    '  __out    LPDHCP_CLIENT_INFO_ARRAY *ClientInfo,
    '  __out    DWORD *ClientsRead,
    '  __out    DWORD *ClientsTotal
    ');

    Declare Unicode Function DhcpEnumServers Lib "Dhcpsapi" _
        (ByVal Flags As Integer, _
         ByVal IdInfo As IntPtr, _
         ByRef Servers As IntPtr, _
         ByVal CallbackFn As IntPtr, _
         ByVal CallbackData As IntPtr) As UInteger
    '    DWORD DhcpEnumServers(
    '  __in   DWORD Flags,
    '  __in   LPVOID IdInfo,
    '  __out  LPDHCP_SERVER_INFO_ARRAY *Servers,
    '  __in   LPVOID CallbackFn,
    '  __in   LPVOID CallbackData
    ');

    Declare Unicode Function DhcpEnumSubnets Lib "Dhcpsapi" _
        (ByVal ServerIpAddress As String, _
        ByRef ResumeHandle As Integer, _
        ByVal PreferredMaximum As Integer, _
        ByRef EnumInfo As IntPtr, _
        ByRef ElementsRead As Integer, _
        ByRef ElementsTotal As Integer) As Integer
    '    DWORD DHCP_API_FUNCTION DhcpEnumSubnets(
    '  __in     DHCP_CONST WCHAR *ServerIpAddress,
    '  __inout  DHCP_RESUME_HANDLE *ResumeHandle,
    '  __in     DWORD PreferredMaximum,
    '  __out    LPDHCP_IP_ARRAY *EnumInfo,
    '  __out    DWORD *ElementsRead,
    '  __out    DWORD *ElementsTotal
    ');


    <StructLayout(LayoutKind.Sequential)> _
    Private Structure DHCP_IP_ARRAY
        Dim NumElements As Integer
        Dim Elements As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure DHCP_IP_ADDRESS
        Dim IP As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
   Private Structure DHCP_CLIENT_INFO_ARRAY
        Dim NumElements As Integer
        Dim Clients As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure DHCPDS_SERVERS
        Dim Flags As Integer
        Dim NumElements As Integer
        Dim Servers As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure DHCPDS_SERVER
        Dim Version As UInteger
        Dim ServerName As String
        Dim ServerAddress As UInteger
        Dim Flags As UInteger
        Dim State As UInteger
        Dim DsLocation As String
        Dim DsLocType As UInteger
    End Structure


    <StructLayout(LayoutKind.Sequential)> _
    Private Structure DHCP_CLIENT_INFO

        Dim ClientIpAddress As Int32
        Dim SubnetMask As Int32
        Dim ClientHardwareAddress As DHCP_BINARY_DATA

        <MarshalAs(UnmanagedType.LPWStr)> _
            Dim ClientName As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Dim ClientComment As String

        Dim ClientLeaseExpires As Date_Time
        Dim OwnerHost As DHCP_HOST_INFO

    End Structure

    Public Structure CUSTOM_CLIENT_INFO
        Public ClientName As String
        Public IpAddress As String
        Public MacAddress As String
        Public Comment As String
        Public Expiry As String
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure DHCP_BINARY_DATA
        Dim DataLength As Integer
        Dim Data As IntPtr
    End Structure



    <StructLayout(LayoutKind.Sequential)> _
   Private Structure Date_Time

        <MarshalAs(UnmanagedType.U4)> _
        Dim dwLowDateTime As UInt32

        <MarshalAs(UnmanagedType.U4)> _
        Dim dwHighDateTime As UInt32

    End Structure

    <StructLayout(LayoutKind.Sequential)> _
Private Structure DHCP_HOST_INFO

        Dim IpAddress As Int32

        <MarshalAs(UnmanagedType.LPWStr)> _
        Dim NetBiosName As String

        <MarshalAs(UnmanagedType.LPWStr)> _
        Dim HostName As String

    End Structure

#End Region

    Public Sub ListServers()

        Dim dhcpServ As String = GetDhcpServer()

        Dim pt As IntPtr
        Dim retVal As UInteger

        ListViewServers.Items.Clear()

        Try
            DhcpEnumServers(0, Nothing, pt, Nothing, Nothing)
        Catch ex As Exception
            Throw New Exception("Unable to retrieve server list." & retVal.ToString, ex)
        End Try

        If retVal = 0 And pt <> IntPtr.Zero Then

            Dim Server_Array As DHCPDS_SERVERS =
                CType(Marshal.PtrToStructure(pt, GetType(DHCPDS_SERVERS)), DHCPDS_SERVERS)

            Dim Server_List(Server_Array.NumElements) As DHCPDS_SERVER

            Dim current As IntPtr = Server_Array.Servers

            If Server_Array.NumElements >= 1 Then
                For i = 0 To Server_Array.NumElements - 1
                    Server_List(i) = CType(Marshal.PtrToStructure(current, GetType(DHCPDS_SERVER)), DHCPDS_SERVER)

                    'Crashes on 64bit...
                    'Marshal.DestroyStructure(current, GetType(DHCPDS_SERVER))

                    current = IntPtr.op_Explicit(current.ToInt64() + Marshal.SizeOf(Server_List(i)))
                Next
            End If


            For Each server In Server_List
                If server.ServerName <> "" Then
                    Dim srv As String = server.ServerName
                    'Console.Write(srv & "...")
                    'Console.WriteLine(server.ServerAddress)

                    Dim ip As String = DecimalToIP(server.ServerAddress)
                    Dim lvi As ListViewItem
                    lvi = ListViewServers.Items.Add(srv)
                    lvi.SubItems.Add(ip)

                End If
            Next

            For Each lvi As ListViewItem In ListViewServers.Items
                If lvi.SubItems(1).Text = dhcpServ Then
                    lvi.Selected = True
                    Exit For
                End If
            Next

        Else
            MsgBox("Unable to retrieve server list.", MsgBoxStyle.Exclamation, Application.ProductName)
            Dim srv As String = GetDhcpServer()
            Dim lvi As ListViewItem
            lvi = ListViewServers.Items.Add(srv)
            lvi.SubItems.Add(srv)
        End If

        TextBoxSearch.Focus()
    End Sub



    Public Sub ListSubnets()

        Dim pt As IntPtr
        Dim retVal As UInteger
        Dim intRead As Integer
        Dim intTotal As Integer
        Dim DHCP_Server As String = ""

        Try
            DHCP_Server = ListViewServers.SelectedItems(0).SubItems(1).Text
        Catch ex As Exception
            Exit Sub
        End Try

        ListViewSubnets.Items.Clear()

        Try
            DhcpEnumSubnets(DHCP_Server, 0, 1000, pt, intRead, intTotal)
        Catch ex As Exception
            Throw New Exception("Unable to retrieve subnet list." & retVal.ToString, ex)
        End Try

        If retVal = 0 And pt <> IntPtr.Zero Then

            Dim Subnet_Array As DHCP_IP_ARRAY = _
                CType(Marshal.PtrToStructure(pt, GetType(DHCP_IP_ARRAY)), DHCP_IP_ARRAY)

            Dim Subnet_List(Subnet_Array.NumElements) As DHCP_IP_ADDRESS

            Dim current As IntPtr = Subnet_Array.Elements

            For i = 0 To Subnet_Array.NumElements - 1
                Subnet_List(i) = CType(Marshal.PtrToStructure(current, GetType(DHCP_IP_ADDRESS)), DHCP_IP_ADDRESS)
                Marshal.DestroyStructure(current, GetType(DHCP_IP_ADDRESS))
                current = IntPtr.op_Explicit(current.ToInt64() + Marshal.SizeOf(Subnet_List(i)))
            Next

            Dim lvi As ListViewItem
            For Each subnet In Subnet_List
                If subnet.IP > 0 Then
                    lvi = ListViewSubnets.Items.Add(DecimalToIP(subnet.IP))
                    lvi.SubItems.Add(subnet.IP)
                End If
            Next
        Else
            MsgBox("Unable to retrieve subnet list.", MsgBoxStyle.Exclamation, Application.ProductName)
        End If
    End Sub



    'Private Function DecimalToIP(ByVal myDecimal) As String
    '    DecimalToIP = ""
    '    Dim x As Integer
    '    For i = 3 To 0 Step -1
    '        x = Fix(myDecimal / (256 ^ (i)))
    '        myDecimal = myDecimal - (x * 256 ^ i)
    '        DecimalToIP = DecimalToIP & x
    '        If i > 0 Then DecimalToIP = DecimalToIP & "."
    '    Next
    'End Function

    Private Function DecimalToIP(ByVal intAddress As UInteger) As String
        'System.Net.IPAddress.HostToNetworkOrder ... not working well
        Dim ip As IPAddress = New IPAddress(intAddress)
        Dim sIp As String() = ip.ToString().Split(".")
        DecimalToIP = sIp(3) & "." & sIp(2) & "." & sIp(1) & "." & sIp(0)
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName
        ComboBoxSearchMode.SelectedIndex = 0
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        ListServers()
    End Sub

    Private Sub ButtonSubnets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubnets.Click
        Try
            Dim DHCP_Server As String = ListViewServers.SelectedItems(0).SubItems(1).Text
        Catch ex As Exception
            MsgBox("Please select a DHCP server.", MsgBoxStyle.Exclamation, Application.ProductName)
            Exit Sub
        End Try
        ListSubnets()
    End Sub



    Private Sub ComboBoxServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListSubnets()
    End Sub



    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        Try
            Dim DHCP_Server As String = ListViewServers.SelectedItems(0).SubItems(1).Text
        Catch ex As Exception
            MsgBox("Please select a DHCP server.", MsgBoxStyle.Exclamation, Application.ProductName)
            Exit Sub
        End Try
        DoSearch()
    End Sub
    Private Sub DoSearch()
        EnableControls(False)

        ListViewClients.Items.Clear()
        If ListViewSubnets.Items.Count = 0 Then
            ListSubnets()
        End If

        If ListViewSubnets.SelectedItems.Count = 0 Then
            For Each itm In ListViewSubnets.Items
                DhcpSearch(itm.SubItems(1).Text)
            Next
        Else
            For Each itm As ListViewItem In ListViewSubnets.SelectedItems
                DhcpSearch(itm.SubItems(1).Text)
            Next
        End If

        LabelClients.Text = "Clients:  " & ListViewClients.Items.Count

        EnableControls(True)
        TextBoxSearch.Focus()
    End Sub

    Private Sub EnableControls(ByVal boolEnable As Boolean)
        ButtonSubnets.Enabled = boolEnable
        ButtonSearch.Enabled = boolEnable
        ButtonClearFilters.Enabled = boolEnable
        ComboBoxSearchMode.Enabled = boolEnable
        ListViewServers.Enabled = boolEnable
        ListViewSubnets.Enabled = boolEnable
        ListViewClients.Enabled = boolEnable
        TextBoxSearch.Enabled = boolEnable
    End Sub


    Private Function FormatMAC(ByRef pt As IntPtr) As String

        FormatMAC = String.Format("{0:X2}-{1:X2}-{2:X2}-{3:X2}-{4:X2}-{5:X2}", _
            Marshal.ReadByte(pt), _
            Marshal.ReadByte(pt, 1), _
            Marshal.ReadByte(pt, 2), _
            Marshal.ReadByte(pt, 3), _
            Marshal.ReadByte(pt, 4), _
            Marshal.ReadByte(pt, 5))

    End Function

    Public Function ConvertTime(ByVal dwHighDateTime As Long, ByVal dwLowDateTime As Long) As String
        On Error Resume Next
        If dwHighDateTime = 0 AndAlso dwLowDateTime = 0 Then
            'Return DateTime.MinValue
            Return "Reservation (inactive)"
        End If
        If dwHighDateTime = Integer.MaxValue AndAlso dwLowDateTime = UInt32.MaxValue Then
            'Return DateTime.MaxValue
            Return "Reservation (active)"
        End If

        Return DateTime.FromFileTime((dwHighDateTime << 32) Or dwLowDateTime)

    End Function

    Private Sub ListViewSubnets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewSubnets.SelectedIndexChanged
        If ListViewSubnets.SelectedItems.Count < 1 Then Exit Sub
        DoSearch()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearFilters.Click
        TextBoxSearch.Text = ""
        ListViewSubnets.SelectedItems.Clear()
    End Sub

    Private Function GetDhcpServer() As String
        On Error Resume Next
        Dim objWbemLocator As Object
        Const aCall As Integer = 3
        Const iImpersonate As Integer = 3
        Dim objServices As Object
        Dim colAdapters As Object
        Dim strComputer As String = "."


        ' Create the Locator object
        objWbemLocator = CreateObject("WbemScripting.SWbemLocator")
        objServices = objWbemLocator.ConnectServer(strComputer, "Root\CIMV2")
        objServices.Security_.AuthenticationLevel = aCall
        objServices.Security_.ImpersonationLevel = iImpersonate

        colAdapters = objServices.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled=TRUE")
        For Each objItem In colAdapters
            GetDhcpServer = objItem.DHCPServer
        Next

    End Function

    Friend Sub SortMyListView(ByVal ListViewToSort As ListView, ByVal ColumnNumber As Integer, Optional ByVal Resort As Boolean = False, Optional ByVal ForceSort As Boolean = False)
        ' Sorts a list view column by string, number, or date.  The three types of sorts must be specified within the listview columns "tag" property unless the ForceSort option is enabled.
        ' ListViewToSort - The listview to sort
        ' ColumnNumber - The column number to sort by
        ' Resort - Resorts a listview in the same direction as the last sort
        ' ForceSort - Forces a sort even if no listview tag data exists and assumes a string sort.  If this is false (default) and no tag is specified the procedure will exit
        Dim SortOrder As SortOrder
        Static LastSortColumn As Integer = -1
        Static LastSortOrder As SortOrder = SortOrder.Ascending
        If Resort = True Then
            SortOrder = LastSortOrder
        Else
            If LastSortColumn = ColumnNumber Then
                If LastSortOrder = SortOrder.Ascending Then
                    SortOrder = SortOrder.Descending
                Else
                    SortOrder = SortOrder.Ascending
                End If
            Else
                SortOrder = SortOrder.Ascending
            End If
        End If

        ' In case a tag wasn't specified check if we should force a string sort
        If String.IsNullOrEmpty(CStr(ListViewToSort.Columns(ColumnNumber).Tag)) Then
            If ForceSort = True Then
                ListViewToSort.Columns(ColumnNumber).Tag = "String"
            Else
                ' don't sort since no tag was specified.
                Exit Sub
            End If
        End If

        Select Case ListViewToSort.Columns(ColumnNumber).Tag.ToString
            Case "Numeric"
                ListViewToSort.ListViewItemSorter = New ListViewNumericSort(ColumnNumber, SortOrder)
            Case "Date"
                ListViewToSort.ListViewItemSorter = New ListViewDateSort(ColumnNumber, SortOrder)
            Case "String"
                ListViewToSort.ListViewItemSorter = New ListViewStringSort(ColumnNumber, SortOrder)
            Case "IP"
                ListViewToSort.ListViewItemSorter = New ListViewIPSort(ColumnNumber, SortOrder)
        End Select
        LastSortColumn = ColumnNumber
        LastSortOrder = SortOrder
        ListViewToSort.ListViewItemSorter = Nothing
    End Sub

    Private Sub ListViewClients_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewClients.ColumnClick
        SortMyListView(sender, e.Column, , True)
    End Sub


    Private Sub ListViewServers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewServers.SelectedIndexChanged
        If MouseButtons = Windows.Forms.MouseButtons.Right Then Exit Sub
        ListViewClients.Items.Clear()
        ListSubnets()
    End Sub


    Private Sub ContextMenuStripLookup_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripLookup.Opening
        On Error Resume Next
        Dim strHost As String = ""

        strHost = ListViewClients.SelectedItems(0).SubItems(1).Text
        LookupToolStripMenuItem.Text = "&NSLookup " & strHost

        If strHost = "" Then e.Cancel = True

    End Sub


    Private Sub AddServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddServerToolStripMenuItem.Click
        Dim strServer As String = InputBox("Enter the server name or IP Address:", "Add Server")
        If strServer = "" Then Exit Sub
        Dim lvi As ListViewItem
        lvi = ListViewServers.Items.Add(strServer)
        lvi.SubItems.Add(strServer)
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        On Error Resume Next
        ListViewServers.SelectedItems(0).Remove()
    End Sub

    Private Sub LookupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookupToolStripMenuItem.Click
        Try
            Dim strHost As String = ListViewClients.SelectedItems(0).SubItems(1).Text
            Dim strName As String = Dns.GetHostEntry(strHost).HostName
            Dim arrIP As IPAddress() = Dns.GetHostEntry(strHost).AddressList
            Dim arrAliases() As String = Dns.GetHostEntry(strHost).Aliases

            Dim strHostInfo As String = "Host:" & vbCrLf & strHost & vbCrLf & vbCrLf & _
                "DNS Name:" & vbCrLf & strName & vbCrLf & vbCrLf & "DNS IP Addresses:"
            For Each ip In arrIP
                strHostInfo = strHostInfo & vbCrLf & ip.ToString
            Next

            If arrAliases.Length > 0 Then
                strHostInfo = strHostInfo & vbCrLf & vbCrLf & "Aliases:"
                For Each strAlias In arrAliases
                    strHostInfo = strHostInfo & vbCrLf & strAlias
                Next
            End If

            MsgBox(strHostInfo, MsgBoxStyle.Information, "NSLookup for " & strHost)
        Catch ex As Exception
            MsgBox("Unable to retrieve DNS information.", MsgBoxStyle.Exclamation, "NSLookup")
        End Try


    End Sub

    Private Sub ClearSubnetFiltersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearSubnetFiltersToolStripMenuItem.Click
        ListViewSubnets.SelectedItems.Clear()
    End Sub

    Private Sub ReloadListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadListToolStripMenuItem.Click
        ListServers()
    End Sub



    Private Sub DhcpSearch(ByVal DHCP_Subnet As String)

        Dim SearchString As String = TextBoxSearch.Text
        If InStr(SearchString, "*") Then SearchString = ""

        Dim pt As IntPtr

        Dim Read_Clients, Total_Clients As Integer
        Dim Error_Code As Integer
        Dim Rem_Handle As IntPtr
        Dim DHCP_Server As String


        Try
            DHCP_Server = ListViewServers.SelectedItems(0).SubItems(1).Text
        Catch ex As Exception
            Exit Sub
        End Try

        'Call dhcpsapi
        Error_Code = DhcpEnumSubnetClients(DHCP_Server, DHCP_Subnet, Rem_Handle, 65537, pt, Read_Clients, Total_Clients)

        Dim clients As DHCP_CLIENT_INFO_ARRAY = CType(Marshal.PtrToStructure(pt, GetType(DHCP_CLIENT_INFO_ARRAY)), DHCP_CLIENT_INFO_ARRAY)

        Dim size As Integer = CInt(clients.NumElements)

        If size >= 1 Then
            Dim ptr_array As IntPtr() = New IntPtr(size - 1) {}
            Dim current As IntPtr = clients.Clients


            'For i = 0 To Client_Array.NumElements - 1 
            For i As Integer = 0 To size - 1
                ptr_array(i) = Marshal.ReadIntPtr(current)
                'current = CType(CInt(current) + CInt(Marshal.SizeOf(GetType(IntPtr))), IntPtr)
                current = CType(CLng(current) + CLng(Marshal.SizeOf(GetType(IntPtr))), IntPtr)
            Next

            Dim clients_array As CUSTOM_CLIENT_INFO() = New CUSTOM_CLIENT_INFO(size - 1) {}
            For i As Integer = 0 To size - 1
                Dim curr_element As DHCP_CLIENT_INFO = CType(Marshal.PtrToStructure(ptr_array(i), GetType(DHCP_CLIENT_INFO)), DHCP_CLIENT_INFO)
                clients_array(i).IpAddress = DecimalToIP(curr_element.ClientIpAddress)
                clients_array(i).ClientName = curr_element.ClientName
                clients_array(i).MacAddress = FormatMAC(curr_element.ClientHardwareAddress.Data)
                clients_array(i).Comment = curr_element.ClientComment
                clients_array(i).Expiry = ConvertTime(curr_element.ClientLeaseExpires.dwHighDateTime, curr_element.ClientLeaseExpires.dwLowDateTime)

                'This section will throw an AccessViolationException
                'Marshal.DestroyStructure(current, GetType(DHCP_CLIENT_INFO))
                'current = DirectCast(CInt(current) + CInt(Marshal.SizeOf(curr_element)), IntPtr)
                'Replace with:
                'Marshal.DestroyStructure(ptr_array(i), GetType(DHCP_CLIENT_INFO))

            Next



            Dim lvi As ListViewItem
        Dim TotalClients As Integer = 0
        Dim AddIt As Boolean = False
        Dim SearchThis As String = ""

        For Each client In clients_array
            AddIt = False
            SearchThis = ""

            If SearchString = "" Then
                AddIt = True
            Else
                Select Case ComboBoxSearchMode.Text
                    Case "Name"
                        SearchThis = client.ClientName
                    Case "IP Address"
                        SearchThis = client.IpAddress
                    Case "MAC Address"
                        'make sure mac is in proper format
                        SearchString = Replace(SearchString, ":", "")
                        SearchString = Replace(SearchString, "-", "")

                        Dim newtext As String = ""
                        For n = 1 To Len(SearchString) Step 2
                            newtext = newtext & Mid(SearchString, n, 2) & "-"
                        Next
                        If newtext.EndsWith("-") Then newtext = Strings.Left(newtext, Len(newtext) - 1)
                        SearchString = newtext

                        SearchThis = client.MacAddress
                    Case "Comment"
                        SearchThis = client.Comment
                End Select

                If InStr(SearchThis, SearchString, CompareMethod.Text) Then
                    AddIt = True
                End If
            End If


            If AddIt = True Then
                lvi = ListViewClients.Items.Add(client.IpAddress)
                lvi.SubItems.Add(client.ClientName)
                lvi.SubItems.Add(client.Expiry)
                lvi.SubItems.Add(client.MacAddress)
                lvi.SubItems.Add(client.Comment)
            End If

        Next
        End If

    End Sub


End Class
