<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ButtonSubnets = New System.Windows.Forms.Button()
        Me.ListViewSubnets = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripSubnets = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearSubnetFiltersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListViewClients = New System.Windows.Forms.ListView()
        Me.ColumnHeaderIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderExpiry = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderMac = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderComment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripLookup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LookupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.ButtonSearch = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxSearchMode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelClients = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonClearFilters = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListViewServers = New System.Windows.Forms.ListView()
        Me.ColumnHeaderServer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderIPAddr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ContextMenuStripServers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ContextMenuStripSubnets.SuspendLayout()
        Me.ContextMenuStripLookup.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripServers.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonSubnets
        '
        Me.ButtonSubnets.Location = New System.Drawing.Point(265, 25)
        Me.ButtonSubnets.Name = "ButtonSubnets"
        Me.ButtonSubnets.Size = New System.Drawing.Size(76, 23)
        Me.ButtonSubnets.TabIndex = 2
        Me.ButtonSubnets.Text = "&List Subnets"
        Me.ButtonSubnets.UseVisualStyleBackColor = True
        '
        'ListViewSubnets
        '
        Me.ListViewSubnets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewSubnets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListViewSubnets.ContextMenuStrip = Me.ContextMenuStripSubnets
        Me.ListViewSubnets.FullRowSelect = True
        Me.ListViewSubnets.GridLines = True
        Me.ListViewSubnets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewSubnets.HideSelection = False
        Me.ListViewSubnets.Location = New System.Drawing.Point(9, 106)
        Me.ListViewSubnets.Name = "ListViewSubnets"
        Me.ListViewSubnets.Size = New System.Drawing.Size(113, 398)
        Me.ListViewSubnets.TabIndex = 10
        Me.ListViewSubnets.UseCompatibleStateImageBehavior = False
        Me.ListViewSubnets.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Subnet"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.Width = 0
        '
        'ContextMenuStripSubnets
        '
        Me.ContextMenuStripSubnets.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearSubnetFiltersToolStripMenuItem})
        Me.ContextMenuStripSubnets.Name = "ContextMenuStripSubnets"
        Me.ContextMenuStripSubnets.ShowImageMargin = False
        Me.ContextMenuStripSubnets.Size = New System.Drawing.Size(151, 26)
        '
        'ClearSubnetFiltersToolStripMenuItem
        '
        Me.ClearSubnetFiltersToolStripMenuItem.Name = "ClearSubnetFiltersToolStripMenuItem"
        Me.ClearSubnetFiltersToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ClearSubnetFiltersToolStripMenuItem.Text = "&Clear Subnet Filters"
        '
        'ListViewClients
        '
        Me.ListViewClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewClients.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderIP, Me.ColumnHeaderName, Me.ColumnHeaderExpiry, Me.ColumnHeaderMac, Me.ColumnHeaderComment})
        Me.ListViewClients.ContextMenuStrip = Me.ContextMenuStripLookup
        Me.ListViewClients.FullRowSelect = True
        Me.ListViewClients.GridLines = True
        Me.ListViewClients.Location = New System.Drawing.Point(128, 106)
        Me.ListViewClients.Name = "ListViewClients"
        Me.ListViewClients.Size = New System.Drawing.Size(692, 398)
        Me.ListViewClients.TabIndex = 12
        Me.ListViewClients.UseCompatibleStateImageBehavior = False
        Me.ListViewClients.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderIP
        '
        Me.ColumnHeaderIP.Tag = "IP"
        Me.ColumnHeaderIP.Text = "Client IP Address"
        Me.ColumnHeaderIP.Width = 120
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Tag = "String"
        Me.ColumnHeaderName.Text = "Name"
        Me.ColumnHeaderName.Width = 141
        '
        'ColumnHeaderExpiry
        '
        Me.ColumnHeaderExpiry.Tag = "Date"
        Me.ColumnHeaderExpiry.Text = "Lease Expiration"
        Me.ColumnHeaderExpiry.Width = 139
        '
        'ColumnHeaderMac
        '
        Me.ColumnHeaderMac.Tag = "String"
        Me.ColumnHeaderMac.Text = "MAC Address"
        Me.ColumnHeaderMac.Width = 120
        '
        'ColumnHeaderComment
        '
        Me.ColumnHeaderComment.Tag = "String"
        Me.ColumnHeaderComment.Text = "Comment"
        Me.ColumnHeaderComment.Width = 193
        '
        'ContextMenuStripLookup
        '
        Me.ContextMenuStripLookup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LookupToolStripMenuItem})
        Me.ContextMenuStripLookup.Name = "ContextMenuStripLookup"
        Me.ContextMenuStripLookup.ShowImageMargin = False
        Me.ContextMenuStripLookup.Size = New System.Drawing.Size(99, 26)
        '
        'LookupToolStripMenuItem
        '
        Me.LookupToolStripMenuItem.Name = "LookupToolStripMenuItem"
        Me.LookupToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.LookupToolStripMenuItem.Text = "&Lookup..."
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Location = New System.Drawing.Point(359, 25)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(161, 20)
        Me.TextBoxSearch.TabIndex = 4
        '
        'ButtonSearch
        '
        Me.ButtonSearch.Location = New System.Drawing.Point(629, 23)
        Me.ButtonSearch.Name = "ButtonSearch"
        Me.ButtonSearch.Size = New System.Drawing.Size(76, 23)
        Me.ButtonSearch.TabIndex = 7
        Me.ButtonSearch.Text = "&Search"
        Me.ButtonSearch.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Search &Filter:"
        '
        'ComboBoxSearchMode
        '
        Me.ComboBoxSearchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSearchMode.FormattingEnabled = True
        Me.ComboBoxSearchMode.Items.AddRange(New Object() {"Name", "IP Address", "MAC Address", "Comment"})
        Me.ComboBoxSearchMode.Location = New System.Drawing.Point(526, 24)
        Me.ComboBoxSearchMode.Name = "ComboBoxSearchMode"
        Me.ComboBoxSearchMode.Size = New System.Drawing.Size(95, 21)
        Me.ComboBoxSearchMode.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "S&ubnet Filter:"
        '
        'LabelClients
        '
        Me.LabelClients.AutoSize = True
        Me.LabelClients.Location = New System.Drawing.Point(125, 90)
        Me.LabelClients.Name = "LabelClients"
        Me.LabelClients.Size = New System.Drawing.Size(41, 13)
        Me.LabelClients.TabIndex = 11
        Me.LabelClients.Text = "Clie&nts:"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(83, 26)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(82, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'ButtonClearFilters
        '
        Me.ButtonClearFilters.Location = New System.Drawing.Point(711, 23)
        Me.ButtonClearFilters.Name = "ButtonClearFilters"
        Me.ButtonClearFilters.Size = New System.Drawing.Size(76, 23)
        Me.ButtonClearFilters.TabIndex = 8
        Me.ButtonClearFilters.Text = "&Clear Filters"
        Me.ButtonClearFilters.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(523, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Search &Type:"
        '
        'ListViewServers
        '
        Me.ListViewServers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderServer, Me.ColumnHeaderIPAddr})
        Me.ListViewServers.ContextMenuStrip = Me.ContextMenuStripServers
        Me.ListViewServers.FullRowSelect = True
        Me.ListViewServers.GridLines = True
        Me.ListViewServers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewServers.HideSelection = False
        Me.ListViewServers.Location = New System.Drawing.Point(9, 25)
        Me.ListViewServers.MultiSelect = False
        Me.ListViewServers.Name = "ListViewServers"
        Me.ListViewServers.Size = New System.Drawing.Size(250, 52)
        Me.ListViewServers.TabIndex = 1
        Me.ListViewServers.UseCompatibleStateImageBehavior = False
        Me.ListViewServers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderServer
        '
        Me.ColumnHeaderServer.Text = "Server"
        Me.ColumnHeaderServer.Width = 132
        '
        'ColumnHeaderIPAddr
        '
        Me.ColumnHeaderIPAddr.Text = "IP Address"
        Me.ColumnHeaderIPAddr.Width = 95
        '
        'ContextMenuStripServers
        '
        Me.ContextMenuStripServers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddServerToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.ReloadListToolStripMenuItem})
        Me.ContextMenuStripServers.Name = "ContextMenuStrip2"
        Me.ContextMenuStripServers.ShowImageMargin = False
        Me.ContextMenuStripServers.Size = New System.Drawing.Size(107, 70)
        '
        'AddServerToolStripMenuItem
        '
        Me.AddServerToolStripMenuItem.Name = "AddServerToolStripMenuItem"
        Me.AddServerToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.AddServerToolStripMenuItem.Text = "&Add Server"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.RemoveToolStripMenuItem.Text = "R&emove"
        '
        'ReloadListToolStripMenuItem
        '
        Me.ReloadListToolStripMenuItem.Name = "ReloadListToolStripMenuItem"
        Me.ReloadListToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.ReloadListToolStripMenuItem.Text = "&Reload List"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "S&erver:"
        '
        'Form1
        '
        Me.AcceptButton = Me.ButtonSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 516)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.ListViewServers)
        Me.Controls.Add(Me.LabelClients)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonClearFilters)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBoxSearchMode)
        Me.Controls.Add(Me.ListViewClients)
        Me.Controls.Add(Me.ListViewSubnets)
        Me.Controls.Add(Me.ButtonSearch)
        Me.Controls.Add(Me.TextBoxSearch)
        Me.Controls.Add(Me.ButtonSubnets)
        Me.MinimumSize = New System.Drawing.Size(840, 550)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStripSubnets.ResumeLayout(False)
        Me.ContextMenuStripLookup.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripServers.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonSubnets As System.Windows.Forms.Button
    Friend WithEvents ListViewSubnets As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListViewClients As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderIP As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSearch As System.Windows.Forms.Button
    Friend WithEvents ColumnHeaderExpiry As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderMac As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderComment As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSearchMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelClients As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonClearFilters As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ListViewServers As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderServer As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderIPAddr As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStripLookup As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LookupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripServers As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripSubnets As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ClearSubnetFiltersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
