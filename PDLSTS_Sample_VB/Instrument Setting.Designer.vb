<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Instrument_Setting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Instrument_Setting))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbtsl_usb = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txttsl_lanport = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdo_tslusb = New System.Windows.Forms.RadioButton()
        Me.rdo_tsltcpip = New System.Windows.Forms.RadioButton()
        Me.rdotsl_gpib = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdo570 = New System.Windows.Forms.RadioButton()
        Me.rdo550 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txttsl_ipadd = New System.Windows.Forms.TextBox()
        Me.txttsl_gpibadd = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grp_mpmdev2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtmpm_lanport2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtmpm_ipadd2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtmpm_gpibadd2 = New System.Windows.Forms.TextBox()
        Me.chkmulti_dev = New System.Windows.Forms.CheckBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.rdo_mpmtcpip = New System.Windows.Forms.RadioButton()
        Me.rdo_mpmgpib = New System.Windows.Forms.RadioButton()
        Me.grp_mpmdev1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtmpm_lanport1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtmpm_ipadd1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtmpm_gpibadd1 = New System.Windows.Forms.TextBox()
        Me.btnconnect = New System.Windows.Forms.Button()
        Me.grp_pcu = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbpcu_usbresource = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtpcu_lanport = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtpcu_ipadd = New System.Windows.Forms.TextBox()
        Me.txtpcu_gpibadd = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rdopcu_usb = New System.Windows.Forms.RadioButton()
        Me.rdopcu_lan = New System.Windows.Forms.RadioButton()
        Me.rdopcu_gpib = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rdopcu100 = New System.Windows.Forms.RadioButton()
        Me.rdopcu110 = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbpcu_dev = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grp_mpmdev2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.grp_mpmdev1.SuspendLayout()
        Me.grp_pcu.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbtsl_usb)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txttsl_lanport)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txttsl_ipadd)
        Me.GroupBox1.Controls.Add(Me.txttsl_gpibadd)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(546, 159)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TSL "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(292, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "USB Resource"
        '
        'cmbtsl_usb
        '
        Me.cmbtsl_usb.Enabled = False
        Me.cmbtsl_usb.FormattingEnabled = True
        Me.cmbtsl_usb.Location = New System.Drawing.Point(294, 102)
        Me.cmbtsl_usb.Name = "cmbtsl_usb"
        Me.cmbtsl_usb.Size = New System.Drawing.Size(172, 21)
        Me.cmbtsl_usb.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(481, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "LAN Port"
        '
        'txttsl_lanport
        '
        Me.txttsl_lanport.Enabled = False
        Me.txttsl_lanport.Location = New System.Drawing.Point(483, 40)
        Me.txttsl_lanport.Name = "txttsl_lanport"
        Me.txttsl_lanport.Size = New System.Drawing.Size(50, 20)
        Me.txttsl_lanport.TabIndex = 8
        Me.txttsl_lanport.Text = "5000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(378, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "IP Address"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdo_tslusb)
        Me.GroupBox5.Controls.Add(Me.rdo_tsltcpip)
        Me.GroupBox5.Controls.Add(Me.rdotsl_gpib)
        Me.GroupBox5.Location = New System.Drawing.Point(145, 24)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(132, 115)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Communication"
        '
        'rdo_tslusb
        '
        Me.rdo_tslusb.AutoSize = True
        Me.rdo_tslusb.Location = New System.Drawing.Point(17, 82)
        Me.rdo_tslusb.Name = "rdo_tslusb"
        Me.rdo_tslusb.Size = New System.Drawing.Size(47, 17)
        Me.rdo_tslusb.TabIndex = 3
        Me.rdo_tslusb.Text = "USB"
        Me.rdo_tslusb.UseVisualStyleBackColor = True
        '
        'rdo_tsltcpip
        '
        Me.rdo_tsltcpip.AutoSize = True
        Me.rdo_tsltcpip.Location = New System.Drawing.Point(17, 54)
        Me.rdo_tsltcpip.Name = "rdo_tsltcpip"
        Me.rdo_tsltcpip.Size = New System.Drawing.Size(61, 17)
        Me.rdo_tsltcpip.TabIndex = 2
        Me.rdo_tsltcpip.Text = "TCP/IP"
        Me.rdo_tsltcpip.UseVisualStyleBackColor = True
        '
        'rdotsl_gpib
        '
        Me.rdotsl_gpib.AutoSize = True
        Me.rdotsl_gpib.Checked = True
        Me.rdotsl_gpib.Location = New System.Drawing.Point(17, 20)
        Me.rdotsl_gpib.Name = "rdotsl_gpib"
        Me.rdotsl_gpib.Size = New System.Drawing.Size(50, 17)
        Me.rdotsl_gpib.TabIndex = 1
        Me.rdotsl_gpib.TabStop = True
        Me.rdotsl_gpib.Text = "GPIB"
        Me.rdotsl_gpib.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdo570)
        Me.GroupBox4.Controls.Add(Me.rdo550)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 24)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(123, 115)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Product"
        '
        'rdo570
        '
        Me.rdo570.AutoSize = True
        Me.rdo570.Checked = True
        Me.rdo570.Location = New System.Drawing.Point(15, 33)
        Me.rdo570.Name = "rdo570"
        Me.rdo570.Size = New System.Drawing.Size(89, 17)
        Me.rdo570.TabIndex = 0
        Me.rdo570.TabStop = True
        Me.rdo570.Text = "TSL-570/770"
        Me.rdo570.UseVisualStyleBackColor = True
        '
        'rdo550
        '
        Me.rdo550.AutoSize = True
        Me.rdo550.Location = New System.Drawing.Point(15, 67)
        Me.rdo550.Name = "rdo550"
        Me.rdo550.Size = New System.Drawing.Size(89, 17)
        Me.rdo550.TabIndex = 1
        Me.rdo550.Text = "TSL-550/710"
        Me.rdo550.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(292, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "GPIB Address"
        '
        'txttsl_ipadd
        '
        Me.txttsl_ipadd.Enabled = False
        Me.txttsl_ipadd.Location = New System.Drawing.Point(380, 40)
        Me.txttsl_ipadd.Name = "txttsl_ipadd"
        Me.txttsl_ipadd.Size = New System.Drawing.Size(86, 20)
        Me.txttsl_ipadd.TabIndex = 3
        Me.txttsl_ipadd.Text = "192.168.1.100"
        '
        'txttsl_gpibadd
        '
        Me.txttsl_gpibadd.Location = New System.Drawing.Point(294, 40)
        Me.txttsl_gpibadd.Name = "txttsl_gpibadd"
        Me.txttsl_gpibadd.Size = New System.Drawing.Size(75, 20)
        Me.txttsl_gpibadd.TabIndex = 2
        Me.txttsl_gpibadd.Text = "1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grp_mpmdev2)
        Me.GroupBox2.Controls.Add(Me.chkmulti_dev)
        Me.GroupBox2.Controls.Add(Me.GroupBox8)
        Me.GroupBox2.Controls.Add(Me.grp_mpmdev1)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(546, 180)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MPM"
        '
        'grp_mpmdev2
        '
        Me.grp_mpmdev2.Controls.Add(Me.Label9)
        Me.grp_mpmdev2.Controls.Add(Me.txtmpm_lanport2)
        Me.grp_mpmdev2.Controls.Add(Me.Label10)
        Me.grp_mpmdev2.Controls.Add(Me.txtmpm_ipadd2)
        Me.grp_mpmdev2.Controls.Add(Me.Label11)
        Me.grp_mpmdev2.Controls.Add(Me.txtmpm_gpibadd2)
        Me.grp_mpmdev2.Enabled = False
        Me.grp_mpmdev2.Location = New System.Drawing.Point(335, 20)
        Me.grp_mpmdev2.Name = "grp_mpmdev2"
        Me.grp_mpmdev2.Size = New System.Drawing.Size(184, 141)
        Me.grp_mpmdev2.TabIndex = 6
        Me.grp_mpmdev2.TabStop = False
        Me.grp_mpmdev2.Text = "Device2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(118, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "LAN Port"
        '
        'txtmpm_lanport2
        '
        Me.txtmpm_lanport2.Enabled = False
        Me.txtmpm_lanport2.Location = New System.Drawing.Point(120, 88)
        Me.txtmpm_lanport2.Name = "txtmpm_lanport2"
        Me.txtmpm_lanport2.Size = New System.Drawing.Size(50, 20)
        Me.txtmpm_lanport2.TabIndex = 12
        Me.txtmpm_lanport2.Text = "5000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "IP Address"
        '
        'txtmpm_ipadd2
        '
        Me.txtmpm_ipadd2.Enabled = False
        Me.txtmpm_ipadd2.Location = New System.Drawing.Point(17, 88)
        Me.txtmpm_ipadd2.Name = "txtmpm_ipadd2"
        Me.txtmpm_ipadd2.Size = New System.Drawing.Size(86, 20)
        Me.txtmpm_ipadd2.TabIndex = 10
        Me.txtmpm_ipadd2.Text = "192.168.1.161"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "GPIB Address"
        '
        'txtmpm_gpibadd2
        '
        Me.txtmpm_gpibadd2.Location = New System.Drawing.Point(17, 40)
        Me.txtmpm_gpibadd2.Name = "txtmpm_gpibadd2"
        Me.txtmpm_gpibadd2.Size = New System.Drawing.Size(75, 20)
        Me.txtmpm_gpibadd2.TabIndex = 5
        Me.txtmpm_gpibadd2.Text = "15"
        '
        'chkmulti_dev
        '
        Me.chkmulti_dev.AutoSize = True
        Me.chkmulti_dev.Location = New System.Drawing.Point(16, 107)
        Me.chkmulti_dev.Name = "chkmulti_dev"
        Me.chkmulti_dev.Size = New System.Drawing.Size(85, 17)
        Me.chkmulti_dev.TabIndex = 5
        Me.chkmulti_dev.Text = "Multi Device"
        Me.chkmulti_dev.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rdo_mpmtcpip)
        Me.GroupBox8.Controls.Add(Me.rdo_mpmgpib)
        Me.GroupBox8.Location = New System.Drawing.Point(16, 20)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(123, 69)
        Me.GroupBox8.TabIndex = 4
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Communication"
        '
        'rdo_mpmtcpip
        '
        Me.rdo_mpmtcpip.AutoSize = True
        Me.rdo_mpmtcpip.Location = New System.Drawing.Point(24, 43)
        Me.rdo_mpmtcpip.Name = "rdo_mpmtcpip"
        Me.rdo_mpmtcpip.Size = New System.Drawing.Size(61, 17)
        Me.rdo_mpmtcpip.TabIndex = 3
        Me.rdo_mpmtcpip.Text = "TCP/IP"
        Me.rdo_mpmtcpip.UseVisualStyleBackColor = True
        '
        'rdo_mpmgpib
        '
        Me.rdo_mpmgpib.AutoSize = True
        Me.rdo_mpmgpib.Checked = True
        Me.rdo_mpmgpib.Location = New System.Drawing.Point(24, 20)
        Me.rdo_mpmgpib.Name = "rdo_mpmgpib"
        Me.rdo_mpmgpib.Size = New System.Drawing.Size(50, 17)
        Me.rdo_mpmgpib.TabIndex = 2
        Me.rdo_mpmgpib.TabStop = True
        Me.rdo_mpmgpib.Text = "GPIB"
        Me.rdo_mpmgpib.UseVisualStyleBackColor = True
        '
        'grp_mpmdev1
        '
        Me.grp_mpmdev1.Controls.Add(Me.Label7)
        Me.grp_mpmdev1.Controls.Add(Me.txtmpm_lanport1)
        Me.grp_mpmdev1.Controls.Add(Me.Label8)
        Me.grp_mpmdev1.Controls.Add(Me.txtmpm_ipadd1)
        Me.grp_mpmdev1.Controls.Add(Me.Label6)
        Me.grp_mpmdev1.Controls.Add(Me.txtmpm_gpibadd1)
        Me.grp_mpmdev1.Location = New System.Drawing.Point(145, 20)
        Me.grp_mpmdev1.Name = "grp_mpmdev1"
        Me.grp_mpmdev1.Size = New System.Drawing.Size(184, 141)
        Me.grp_mpmdev1.TabIndex = 0
        Me.grp_mpmdev1.TabStop = False
        Me.grp_mpmdev1.Text = "Device1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(118, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "LAN Port"
        '
        'txtmpm_lanport1
        '
        Me.txtmpm_lanport1.Enabled = False
        Me.txtmpm_lanport1.Location = New System.Drawing.Point(120, 88)
        Me.txtmpm_lanport1.Name = "txtmpm_lanport1"
        Me.txtmpm_lanport1.Size = New System.Drawing.Size(50, 20)
        Me.txtmpm_lanport1.TabIndex = 12
        Me.txtmpm_lanport1.Text = "5000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "IP Address"
        '
        'txtmpm_ipadd1
        '
        Me.txtmpm_ipadd1.Enabled = False
        Me.txtmpm_ipadd1.Location = New System.Drawing.Point(17, 88)
        Me.txtmpm_ipadd1.Name = "txtmpm_ipadd1"
        Me.txtmpm_ipadd1.Size = New System.Drawing.Size(86, 20)
        Me.txtmpm_ipadd1.TabIndex = 10
        Me.txtmpm_ipadd1.Text = "192.168.1.161"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "GPIB Address"
        '
        'txtmpm_gpibadd1
        '
        Me.txtmpm_gpibadd1.Location = New System.Drawing.Point(17, 40)
        Me.txtmpm_gpibadd1.Name = "txtmpm_gpibadd1"
        Me.txtmpm_gpibadd1.Size = New System.Drawing.Size(75, 20)
        Me.txtmpm_gpibadd1.TabIndex = 5
        Me.txtmpm_gpibadd1.Text = "16"
        '
        'btnconnect
        '
        Me.btnconnect.Location = New System.Drawing.Point(37, 548)
        Me.btnconnect.Name = "btnconnect"
        Me.btnconnect.Size = New System.Drawing.Size(198, 38)
        Me.btnconnect.TabIndex = 3
        Me.btnconnect.Text = "Connect"
        Me.btnconnect.UseVisualStyleBackColor = True
        '
        'grp_pcu
        '
        Me.grp_pcu.Controls.Add(Me.Label16)
        Me.grp_pcu.Controls.Add(Me.cmbpcu_usbresource)
        Me.grp_pcu.Controls.Add(Me.Label13)
        Me.grp_pcu.Controls.Add(Me.txtpcu_lanport)
        Me.grp_pcu.Controls.Add(Me.Label14)
        Me.grp_pcu.Controls.Add(Me.Label15)
        Me.grp_pcu.Controls.Add(Me.txtpcu_ipadd)
        Me.grp_pcu.Controls.Add(Me.txtpcu_gpibadd)
        Me.grp_pcu.Controls.Add(Me.GroupBox9)
        Me.grp_pcu.Controls.Add(Me.GroupBox7)
        Me.grp_pcu.Controls.Add(Me.Label12)
        Me.grp_pcu.Controls.Add(Me.cmbpcu_dev)
        Me.grp_pcu.Location = New System.Drawing.Point(27, 381)
        Me.grp_pcu.Name = "grp_pcu"
        Me.grp_pcu.Size = New System.Drawing.Size(546, 146)
        Me.grp_pcu.TabIndex = 4
        Me.grp_pcu.TabStop = False
        Me.grp_pcu.Text = "PCU"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(310, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "USB Resource"
        '
        'cmbpcu_usbresource
        '
        Me.cmbpcu_usbresource.Enabled = False
        Me.cmbpcu_usbresource.FormattingEnabled = True
        Me.cmbpcu_usbresource.Location = New System.Drawing.Point(312, 107)
        Me.cmbpcu_usbresource.Name = "cmbpcu_usbresource"
        Me.cmbpcu_usbresource.Size = New System.Drawing.Size(172, 21)
        Me.cmbpcu_usbresource.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(488, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "LAN Port"
        '
        'txtpcu_lanport
        '
        Me.txtpcu_lanport.Enabled = False
        Me.txtpcu_lanport.Location = New System.Drawing.Point(490, 39)
        Me.txtpcu_lanport.Name = "txtpcu_lanport"
        Me.txtpcu_lanport.Size = New System.Drawing.Size(50, 20)
        Me.txtpcu_lanport.TabIndex = 14
        Me.txtpcu_lanport.Text = "5000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(396, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "IP Address"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(310, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "GPIB Address"
        '
        'txtpcu_ipadd
        '
        Me.txtpcu_ipadd.Enabled = False
        Me.txtpcu_ipadd.Location = New System.Drawing.Point(398, 39)
        Me.txtpcu_ipadd.Name = "txtpcu_ipadd"
        Me.txtpcu_ipadd.Size = New System.Drawing.Size(86, 20)
        Me.txtpcu_ipadd.TabIndex = 11
        Me.txtpcu_ipadd.Text = "192.168.1.100"
        '
        'txtpcu_gpibadd
        '
        Me.txtpcu_gpibadd.Location = New System.Drawing.Point(312, 39)
        Me.txtpcu_gpibadd.Name = "txtpcu_gpibadd"
        Me.txtpcu_gpibadd.Size = New System.Drawing.Size(75, 20)
        Me.txtpcu_gpibadd.TabIndex = 10
        Me.txtpcu_gpibadd.Text = "5"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rdopcu_usb)
        Me.GroupBox9.Controls.Add(Me.rdopcu_lan)
        Me.GroupBox9.Controls.Add(Me.rdopcu_gpib)
        Me.GroupBox9.Location = New System.Drawing.Point(159, 20)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(144, 63)
        Me.GroupBox9.TabIndex = 7
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Communication"
        '
        'rdopcu_usb
        '
        Me.rdopcu_usb.AutoSize = True
        Me.rdopcu_usb.Location = New System.Drawing.Point(84, 39)
        Me.rdopcu_usb.Name = "rdopcu_usb"
        Me.rdopcu_usb.Size = New System.Drawing.Size(47, 17)
        Me.rdopcu_usb.TabIndex = 3
        Me.rdopcu_usb.Text = "USB"
        Me.rdopcu_usb.UseVisualStyleBackColor = True
        '
        'rdopcu_lan
        '
        Me.rdopcu_lan.AutoSize = True
        Me.rdopcu_lan.Location = New System.Drawing.Point(15, 39)
        Me.rdopcu_lan.Name = "rdopcu_lan"
        Me.rdopcu_lan.Size = New System.Drawing.Size(61, 17)
        Me.rdopcu_lan.TabIndex = 2
        Me.rdopcu_lan.Text = "TCP/IP"
        Me.rdopcu_lan.UseVisualStyleBackColor = True
        '
        'rdopcu_gpib
        '
        Me.rdopcu_gpib.AutoSize = True
        Me.rdopcu_gpib.Checked = True
        Me.rdopcu_gpib.Location = New System.Drawing.Point(15, 16)
        Me.rdopcu_gpib.Name = "rdopcu_gpib"
        Me.rdopcu_gpib.Size = New System.Drawing.Size(50, 17)
        Me.rdopcu_gpib.TabIndex = 1
        Me.rdopcu_gpib.TabStop = True
        Me.rdopcu_gpib.Text = "GPIB"
        Me.rdopcu_gpib.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rdopcu100)
        Me.GroupBox7.Controls.Add(Me.rdopcu110)
        Me.GroupBox7.Location = New System.Drawing.Point(23, 20)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(130, 63)
        Me.GroupBox7.TabIndex = 6
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Product"
        '
        'rdopcu100
        '
        Me.rdopcu100.AutoSize = True
        Me.rdopcu100.Checked = True
        Me.rdopcu100.Location = New System.Drawing.Point(21, 20)
        Me.rdopcu100.Name = "rdopcu100"
        Me.rdopcu100.Size = New System.Drawing.Size(68, 17)
        Me.rdopcu100.TabIndex = 0
        Me.rdopcu100.TabStop = True
        Me.rdopcu100.Text = "PCU-100"
        Me.rdopcu100.UseVisualStyleBackColor = True
        '
        'rdopcu110
        '
        Me.rdopcu110.AutoSize = True
        Me.rdopcu110.Location = New System.Drawing.Point(21, 39)
        Me.rdopcu110.Name = "rdopcu110"
        Me.rdopcu110.Size = New System.Drawing.Size(68, 17)
        Me.rdopcu110.TabIndex = 1
        Me.rdopcu110.Text = "PCU-110"
        Me.rdopcu110.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(29, 91)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "SPU"
        '
        'cmbpcu_dev
        '
        Me.cmbpcu_dev.FormattingEnabled = True
        Me.cmbpcu_dev.Location = New System.Drawing.Point(31, 107)
        Me.cmbpcu_dev.Name = "cmbpcu_dev"
        Me.cmbpcu_dev.Size = New System.Drawing.Size(113, 21)
        Me.cmbpcu_dev.TabIndex = 0
        '
        'Instrument_Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 605)
        Me.Controls.Add(Me.grp_pcu)
        Me.Controls.Add(Me.btnconnect)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Instrument_Setting"
        Me.Text = "Instrument_Setting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grp_mpmdev2.ResumeLayout(False)
        Me.grp_mpmdev2.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.grp_mpmdev1.ResumeLayout(False)
        Me.grp_mpmdev1.PerformLayout()
        Me.grp_pcu.ResumeLayout(False)
        Me.grp_pcu.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txttsl_ipadd As TextBox
    Friend WithEvents txttsl_gpibadd As TextBox
    Friend WithEvents rdo550 As RadioButton
    Friend WithEvents rdo570 As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbtsl_usb As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txttsl_lanport As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents rdo_tslusb As RadioButton
    Friend WithEvents rdo_tsltcpip As RadioButton
    Friend WithEvents rdotsl_gpib As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents grp_mpmdev2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtmpm_lanport2 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtmpm_ipadd2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtmpm_gpibadd2 As TextBox
    Friend WithEvents chkmulti_dev As CheckBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents rdo_mpmtcpip As RadioButton
    Friend WithEvents rdo_mpmgpib As RadioButton
    Friend WithEvents grp_mpmdev1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtmpm_lanport1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtmpm_ipadd1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtmpm_gpibadd1 As TextBox
    Friend WithEvents btnconnect As Button
    Friend WithEvents grp_pcu As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents rdopcu100 As RadioButton
    Friend WithEvents rdopcu110 As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbpcu_dev As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbpcu_usbresource As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtpcu_lanport As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtpcu_ipadd As TextBox
    Friend WithEvents txtpcu_gpibadd As TextBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents rdopcu_usb As RadioButton
    Friend WithEvents rdopcu_lan As RadioButton
    Friend WithEvents rdopcu_gpib As RadioButton
End Class
