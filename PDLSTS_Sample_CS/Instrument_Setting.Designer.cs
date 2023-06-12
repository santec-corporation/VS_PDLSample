namespace PDLSTS_Sample
{
    partial class Instrument_Setting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instrument_Setting));
            this.btnconnect = new System.Windows.Forms.Button();
            this.cmbpcu_usbresource = new System.Windows.Forms.ComboBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.txtmpm_gpibadd1 = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtpcu_lanport = new System.Windows.Forms.TextBox();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.rdopcu_usb = new System.Windows.Forms.RadioButton();
            this.rdopcu_lan = new System.Windows.Forms.RadioButton();
            this.rdopcu_gpib = new System.Windows.Forms.RadioButton();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.txtpcu_ipadd = new System.Windows.Forms.TextBox();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.rdopcu100 = new System.Windows.Forms.RadioButton();
            this.rdopcu110 = new System.Windows.Forms.RadioButton();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtmpm_lanport1 = new System.Windows.Forms.TextBox();
            this.txtmpm_ipadd1 = new System.Windows.Forms.TextBox();
            this.txtpcu_gpibadd = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.grp_mpmdev1 = new System.Windows.Forms.GroupBox();
            this.grp_pcu = new System.Windows.Forms.GroupBox();
            this.cmbpcu_dev = new System.Windows.Forms.ComboBox();
            this.rdo_mpmtcpip = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cmbtsl_usb = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txttsl_lanport = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.rdo_tslusb = new System.Windows.Forms.RadioButton();
            this.rdo_tsltcpip = new System.Windows.Forms.RadioButton();
            this.rdotsl_gpib = new System.Windows.Forms.RadioButton();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.rdo570 = new System.Windows.Forms.RadioButton();
            this.rdo550 = new System.Windows.Forms.RadioButton();
            this.Label2 = new System.Windows.Forms.Label();
            this.txttsl_ipadd = new System.Windows.Forms.TextBox();
            this.txttsl_gpibadd = new System.Windows.Forms.TextBox();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.rdo_mpmgpib = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.grp_mpmdev2 = new System.Windows.Forms.GroupBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtmpm_lanport2 = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtmpm_ipadd2 = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.txtmpm_gpibadd2 = new System.Windows.Forms.TextBox();
            this.chkmulti_dev = new System.Windows.Forms.CheckBox();
            this.GroupBox9.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.grp_mpmdev1.SuspendLayout();
            this.grp_pcu.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.grp_mpmdev2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(35, 543);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(198, 38);
            this.btnconnect.TabIndex = 7;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // cmbpcu_usbresource
            // 
            this.cmbpcu_usbresource.Enabled = false;
            this.cmbpcu_usbresource.FormattingEnabled = true;
            this.cmbpcu_usbresource.Location = new System.Drawing.Point(312, 107);
            this.cmbpcu_usbresource.Name = "cmbpcu_usbresource";
            this.cmbpcu_usbresource.Size = new System.Drawing.Size(172, 21);
            this.cmbpcu_usbresource.TabIndex = 16;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(488, 23);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(50, 13);
            this.Label13.TabIndex = 15;
            this.Label13.Text = "LAN Port";
            // 
            // txtmpm_gpibadd1
            // 
            this.txtmpm_gpibadd1.Location = new System.Drawing.Point(17, 40);
            this.txtmpm_gpibadd1.Name = "txtmpm_gpibadd1";
            this.txtmpm_gpibadd1.Size = new System.Drawing.Size(75, 20);
            this.txtmpm_gpibadd1.TabIndex = 5;
            this.txtmpm_gpibadd1.Text = "16";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(310, 88);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(78, 13);
            this.Label16.TabIndex = 17;
            this.Label16.Text = "USB Resource";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(15, 24);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(73, 13);
            this.Label6.TabIndex = 6;
            this.Label6.Text = "GPIB Address";
            // 
            // txtpcu_lanport
            // 
            this.txtpcu_lanport.Enabled = false;
            this.txtpcu_lanport.Location = new System.Drawing.Point(490, 39);
            this.txtpcu_lanport.Name = "txtpcu_lanport";
            this.txtpcu_lanport.Size = new System.Drawing.Size(50, 20);
            this.txtpcu_lanport.TabIndex = 14;
            this.txtpcu_lanport.Text = "5000";
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.rdopcu_usb);
            this.GroupBox9.Controls.Add(this.rdopcu_lan);
            this.GroupBox9.Controls.Add(this.rdopcu_gpib);
            this.GroupBox9.Location = new System.Drawing.Point(159, 20);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(144, 63);
            this.GroupBox9.TabIndex = 7;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Communication";
            // 
            // rdopcu_usb
            // 
            this.rdopcu_usb.AutoSize = true;
            this.rdopcu_usb.Location = new System.Drawing.Point(84, 39);
            this.rdopcu_usb.Name = "rdopcu_usb";
            this.rdopcu_usb.Size = new System.Drawing.Size(47, 17);
            this.rdopcu_usb.TabIndex = 3;
            this.rdopcu_usb.Text = "USB";
            this.rdopcu_usb.UseVisualStyleBackColor = true;
            this.rdopcu_usb.CheckedChanged += new System.EventHandler(this.rdopcu_usb_CheckedChanged);
            // 
            // rdopcu_lan
            // 
            this.rdopcu_lan.AutoSize = true;
            this.rdopcu_lan.Location = new System.Drawing.Point(15, 39);
            this.rdopcu_lan.Name = "rdopcu_lan";
            this.rdopcu_lan.Size = new System.Drawing.Size(61, 17);
            this.rdopcu_lan.TabIndex = 2;
            this.rdopcu_lan.Text = "TCP/IP";
            this.rdopcu_lan.UseVisualStyleBackColor = true;
            this.rdopcu_lan.CheckedChanged += new System.EventHandler(this.rdopcu_lan_CheckedChanged);
            // 
            // rdopcu_gpib
            // 
            this.rdopcu_gpib.AutoSize = true;
            this.rdopcu_gpib.Checked = true;
            this.rdopcu_gpib.Location = new System.Drawing.Point(15, 16);
            this.rdopcu_gpib.Name = "rdopcu_gpib";
            this.rdopcu_gpib.Size = new System.Drawing.Size(50, 17);
            this.rdopcu_gpib.TabIndex = 1;
            this.rdopcu_gpib.TabStop = true;
            this.rdopcu_gpib.Text = "GPIB";
            this.rdopcu_gpib.UseVisualStyleBackColor = true;
            this.rdopcu_gpib.CheckedChanged += new System.EventHandler(this.rdopcu_gpib_CheckedChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(15, 72);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(58, 13);
            this.Label8.TabIndex = 11;
            this.Label8.Text = "IP Address";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(396, 23);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(58, 13);
            this.Label14.TabIndex = 13;
            this.Label14.Text = "IP Address";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(310, 23);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(73, 13);
            this.Label15.TabIndex = 12;
            this.Label15.Text = "GPIB Address";
            // 
            // txtpcu_ipadd
            // 
            this.txtpcu_ipadd.Enabled = false;
            this.txtpcu_ipadd.Location = new System.Drawing.Point(398, 39);
            this.txtpcu_ipadd.Name = "txtpcu_ipadd";
            this.txtpcu_ipadd.Size = new System.Drawing.Size(86, 20);
            this.txtpcu_ipadd.TabIndex = 11;
            this.txtpcu_ipadd.Text = "192.168.1.100";
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.rdopcu100);
            this.GroupBox7.Controls.Add(this.rdopcu110);
            this.GroupBox7.Location = new System.Drawing.Point(23, 20);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(130, 63);
            this.GroupBox7.TabIndex = 6;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Product";
            // 
            // rdopcu100
            // 
            this.rdopcu100.AutoSize = true;
            this.rdopcu100.Checked = true;
            this.rdopcu100.Location = new System.Drawing.Point(21, 20);
            this.rdopcu100.Name = "rdopcu100";
            this.rdopcu100.Size = new System.Drawing.Size(68, 17);
            this.rdopcu100.TabIndex = 0;
            this.rdopcu100.TabStop = true;
            this.rdopcu100.Text = "PCU-100";
            this.rdopcu100.UseVisualStyleBackColor = true;
            this.rdopcu100.CheckedChanged += new System.EventHandler(this.rdopcu100_CheckedChanged);
            // 
            // rdopcu110
            // 
            this.rdopcu110.AutoSize = true;
            this.rdopcu110.Location = new System.Drawing.Point(21, 39);
            this.rdopcu110.Name = "rdopcu110";
            this.rdopcu110.Size = new System.Drawing.Size(68, 17);
            this.rdopcu110.TabIndex = 1;
            this.rdopcu110.Text = "PCU-110";
            this.rdopcu110.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(118, 72);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(50, 13);
            this.Label7.TabIndex = 13;
            this.Label7.Text = "LAN Port";
            // 
            // txtmpm_lanport1
            // 
            this.txtmpm_lanport1.Enabled = false;
            this.txtmpm_lanport1.Location = new System.Drawing.Point(120, 88);
            this.txtmpm_lanport1.Name = "txtmpm_lanport1";
            this.txtmpm_lanport1.Size = new System.Drawing.Size(50, 20);
            this.txtmpm_lanport1.TabIndex = 12;
            this.txtmpm_lanport1.Text = "5000";
            // 
            // txtmpm_ipadd1
            // 
            this.txtmpm_ipadd1.Enabled = false;
            this.txtmpm_ipadd1.Location = new System.Drawing.Point(17, 88);
            this.txtmpm_ipadd1.Name = "txtmpm_ipadd1";
            this.txtmpm_ipadd1.Size = new System.Drawing.Size(86, 20);
            this.txtmpm_ipadd1.TabIndex = 10;
            this.txtmpm_ipadd1.Text = "192.168.1.161";
            // 
            // txtpcu_gpibadd
            // 
            this.txtpcu_gpibadd.Location = new System.Drawing.Point(312, 39);
            this.txtpcu_gpibadd.Name = "txtpcu_gpibadd";
            this.txtpcu_gpibadd.Size = new System.Drawing.Size(75, 20);
            this.txtpcu_gpibadd.TabIndex = 10;
            this.txtpcu_gpibadd.Text = "5";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(29, 91);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(29, 13);
            this.Label12.TabIndex = 1;
            this.Label12.Text = "SPU";
            // 
            // grp_mpmdev1
            // 
            this.grp_mpmdev1.Controls.Add(this.Label7);
            this.grp_mpmdev1.Controls.Add(this.txtmpm_lanport1);
            this.grp_mpmdev1.Controls.Add(this.Label8);
            this.grp_mpmdev1.Controls.Add(this.txtmpm_ipadd1);
            this.grp_mpmdev1.Controls.Add(this.Label6);
            this.grp_mpmdev1.Controls.Add(this.txtmpm_gpibadd1);
            this.grp_mpmdev1.Location = new System.Drawing.Point(145, 20);
            this.grp_mpmdev1.Name = "grp_mpmdev1";
            this.grp_mpmdev1.Size = new System.Drawing.Size(184, 141);
            this.grp_mpmdev1.TabIndex = 0;
            this.grp_mpmdev1.TabStop = false;
            this.grp_mpmdev1.Text = "Device1";
            // 
            // grp_pcu
            // 
            this.grp_pcu.Controls.Add(this.Label16);
            this.grp_pcu.Controls.Add(this.cmbpcu_usbresource);
            this.grp_pcu.Controls.Add(this.Label13);
            this.grp_pcu.Controls.Add(this.txtpcu_lanport);
            this.grp_pcu.Controls.Add(this.Label14);
            this.grp_pcu.Controls.Add(this.Label15);
            this.grp_pcu.Controls.Add(this.txtpcu_ipadd);
            this.grp_pcu.Controls.Add(this.txtpcu_gpibadd);
            this.grp_pcu.Controls.Add(this.GroupBox9);
            this.grp_pcu.Controls.Add(this.GroupBox7);
            this.grp_pcu.Controls.Add(this.Label12);
            this.grp_pcu.Controls.Add(this.cmbpcu_dev);
            this.grp_pcu.Location = new System.Drawing.Point(25, 376);
            this.grp_pcu.Name = "grp_pcu";
            this.grp_pcu.Size = new System.Drawing.Size(546, 146);
            this.grp_pcu.TabIndex = 8;
            this.grp_pcu.TabStop = false;
            this.grp_pcu.Text = "PCU";
            // 
            // cmbpcu_dev
            // 
            this.cmbpcu_dev.FormattingEnabled = true;
            this.cmbpcu_dev.Location = new System.Drawing.Point(31, 107);
            this.cmbpcu_dev.Name = "cmbpcu_dev";
            this.cmbpcu_dev.Size = new System.Drawing.Size(113, 21);
            this.cmbpcu_dev.TabIndex = 0;
            // 
            // rdo_mpmtcpip
            // 
            this.rdo_mpmtcpip.AutoSize = true;
            this.rdo_mpmtcpip.Location = new System.Drawing.Point(24, 43);
            this.rdo_mpmtcpip.Name = "rdo_mpmtcpip";
            this.rdo_mpmtcpip.Size = new System.Drawing.Size(61, 17);
            this.rdo_mpmtcpip.TabIndex = 3;
            this.rdo_mpmtcpip.Text = "TCP/IP";
            this.rdo_mpmtcpip.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.cmbtsl_usb);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txttsl_lanport);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.GroupBox5);
            this.GroupBox1.Controls.Add(this.GroupBox4);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txttsl_ipadd);
            this.GroupBox1.Controls.Add(this.txttsl_gpibadd);
            this.GroupBox1.Location = new System.Drawing.Point(25, 24);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(546, 159);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "TSL ";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(292, 82);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 13);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "USB Resource";
            // 
            // cmbtsl_usb
            // 
            this.cmbtsl_usb.Enabled = false;
            this.cmbtsl_usb.FormattingEnabled = true;
            this.cmbtsl_usb.Location = new System.Drawing.Point(294, 102);
            this.cmbtsl_usb.Name = "cmbtsl_usb";
            this.cmbtsl_usb.Size = new System.Drawing.Size(172, 21);
            this.cmbtsl_usb.TabIndex = 10;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(481, 24);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(50, 13);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "LAN Port";
            // 
            // txttsl_lanport
            // 
            this.txttsl_lanport.Enabled = false;
            this.txttsl_lanport.Location = new System.Drawing.Point(483, 40);
            this.txttsl_lanport.Name = "txttsl_lanport";
            this.txttsl_lanport.Size = new System.Drawing.Size(50, 20);
            this.txttsl_lanport.TabIndex = 8;
            this.txttsl_lanport.Text = "5000";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(378, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(58, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "IP Address";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.rdo_tslusb);
            this.GroupBox5.Controls.Add(this.rdo_tsltcpip);
            this.GroupBox5.Controls.Add(this.rdotsl_gpib);
            this.GroupBox5.Location = new System.Drawing.Point(145, 24);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(132, 115);
            this.GroupBox5.TabIndex = 6;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Communication";
            // 
            // rdo_tslusb
            // 
            this.rdo_tslusb.AutoSize = true;
            this.rdo_tslusb.Location = new System.Drawing.Point(17, 82);
            this.rdo_tslusb.Name = "rdo_tslusb";
            this.rdo_tslusb.Size = new System.Drawing.Size(47, 17);
            this.rdo_tslusb.TabIndex = 3;
            this.rdo_tslusb.Text = "USB";
            this.rdo_tslusb.UseVisualStyleBackColor = true;
            this.rdo_tslusb.CheckedChanged += new System.EventHandler(this.rdo_tslusb_CheckedChanged);
            // 
            // rdo_tsltcpip
            // 
            this.rdo_tsltcpip.AutoSize = true;
            this.rdo_tsltcpip.Location = new System.Drawing.Point(17, 54);
            this.rdo_tsltcpip.Name = "rdo_tsltcpip";
            this.rdo_tsltcpip.Size = new System.Drawing.Size(61, 17);
            this.rdo_tsltcpip.TabIndex = 2;
            this.rdo_tsltcpip.Text = "TCP/IP";
            this.rdo_tsltcpip.UseVisualStyleBackColor = true;
            this.rdo_tsltcpip.CheckedChanged += new System.EventHandler(this.rdo_tsltcpip_CheckedChanged);
            // 
            // rdotsl_gpib
            // 
            this.rdotsl_gpib.AutoSize = true;
            this.rdotsl_gpib.Checked = true;
            this.rdotsl_gpib.Location = new System.Drawing.Point(17, 20);
            this.rdotsl_gpib.Name = "rdotsl_gpib";
            this.rdotsl_gpib.Size = new System.Drawing.Size(50, 17);
            this.rdotsl_gpib.TabIndex = 1;
            this.rdotsl_gpib.TabStop = true;
            this.rdotsl_gpib.Text = "GPIB";
            this.rdotsl_gpib.UseVisualStyleBackColor = true;
            this.rdotsl_gpib.CheckedChanged += new System.EventHandler(this.rdotsl_gpib_CheckedChanged);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.rdo570);
            this.GroupBox4.Controls.Add(this.rdo550);
            this.GroupBox4.Location = new System.Drawing.Point(16, 24);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(123, 115);
            this.GroupBox4.TabIndex = 5;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Product";
            // 
            // rdo570
            // 
            this.rdo570.AutoSize = true;
            this.rdo570.Checked = true;
            this.rdo570.Location = new System.Drawing.Point(15, 33);
            this.rdo570.Name = "rdo570";
            this.rdo570.Size = new System.Drawing.Size(89, 17);
            this.rdo570.TabIndex = 0;
            this.rdo570.TabStop = true;
            this.rdo570.Text = "TSL-570/770";
            this.rdo570.UseVisualStyleBackColor = true;
            this.rdo570.CheckedChanged += new System.EventHandler(this.rdo570_CheckedChanged);
            // 
            // rdo550
            // 
            this.rdo550.AutoSize = true;
            this.rdo550.Location = new System.Drawing.Point(15, 67);
            this.rdo550.Name = "rdo550";
            this.rdo550.Size = new System.Drawing.Size(89, 17);
            this.rdo550.TabIndex = 1;
            this.rdo550.Text = "TSL-550/710";
            this.rdo550.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(292, 24);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(73, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "GPIB Address";
            // 
            // txttsl_ipadd
            // 
            this.txttsl_ipadd.Enabled = false;
            this.txttsl_ipadd.Location = new System.Drawing.Point(380, 40);
            this.txttsl_ipadd.Name = "txttsl_ipadd";
            this.txttsl_ipadd.Size = new System.Drawing.Size(86, 20);
            this.txttsl_ipadd.TabIndex = 3;
            this.txttsl_ipadd.Text = "192.168.1.100";
            // 
            // txttsl_gpibadd
            // 
            this.txttsl_gpibadd.Location = new System.Drawing.Point(294, 40);
            this.txttsl_gpibadd.Name = "txttsl_gpibadd";
            this.txttsl_gpibadd.Size = new System.Drawing.Size(75, 20);
            this.txttsl_gpibadd.TabIndex = 2;
            this.txttsl_gpibadd.Text = "1";
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.rdo_mpmtcpip);
            this.GroupBox8.Controls.Add(this.rdo_mpmgpib);
            this.GroupBox8.Location = new System.Drawing.Point(16, 20);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(123, 69);
            this.GroupBox8.TabIndex = 4;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Communication";
            // 
            // rdo_mpmgpib
            // 
            this.rdo_mpmgpib.AutoSize = true;
            this.rdo_mpmgpib.Checked = true;
            this.rdo_mpmgpib.Location = new System.Drawing.Point(24, 20);
            this.rdo_mpmgpib.Name = "rdo_mpmgpib";
            this.rdo_mpmgpib.Size = new System.Drawing.Size(50, 17);
            this.rdo_mpmgpib.TabIndex = 2;
            this.rdo_mpmgpib.TabStop = true;
            this.rdo_mpmgpib.Text = "GPIB";
            this.rdo_mpmgpib.UseVisualStyleBackColor = true;
            this.rdo_mpmgpib.CheckedChanged += new System.EventHandler(this.rdo_mpmgpib_CheckedChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.grp_mpmdev2);
            this.GroupBox2.Controls.Add(this.chkmulti_dev);
            this.GroupBox2.Controls.Add(this.GroupBox8);
            this.GroupBox2.Controls.Add(this.grp_mpmdev1);
            this.GroupBox2.Location = new System.Drawing.Point(25, 190);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(546, 180);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "MPM";
            // 
            // grp_mpmdev2
            // 
            this.grp_mpmdev2.Controls.Add(this.Label9);
            this.grp_mpmdev2.Controls.Add(this.txtmpm_lanport2);
            this.grp_mpmdev2.Controls.Add(this.Label10);
            this.grp_mpmdev2.Controls.Add(this.txtmpm_ipadd2);
            this.grp_mpmdev2.Controls.Add(this.Label11);
            this.grp_mpmdev2.Controls.Add(this.txtmpm_gpibadd2);
            this.grp_mpmdev2.Enabled = false;
            this.grp_mpmdev2.Location = new System.Drawing.Point(335, 20);
            this.grp_mpmdev2.Name = "grp_mpmdev2";
            this.grp_mpmdev2.Size = new System.Drawing.Size(184, 141);
            this.grp_mpmdev2.TabIndex = 6;
            this.grp_mpmdev2.TabStop = false;
            this.grp_mpmdev2.Text = "Device1";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(118, 72);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(50, 13);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "LAN Port";
            // 
            // txtmpm_lanport2
            // 
            this.txtmpm_lanport2.Enabled = false;
            this.txtmpm_lanport2.Location = new System.Drawing.Point(120, 88);
            this.txtmpm_lanport2.Name = "txtmpm_lanport2";
            this.txtmpm_lanport2.Size = new System.Drawing.Size(50, 20);
            this.txtmpm_lanport2.TabIndex = 12;
            this.txtmpm_lanport2.Text = "5000";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(15, 72);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(58, 13);
            this.Label10.TabIndex = 11;
            this.Label10.Text = "IP Address";
            // 
            // txtmpm_ipadd2
            // 
            this.txtmpm_ipadd2.Enabled = false;
            this.txtmpm_ipadd2.Location = new System.Drawing.Point(17, 88);
            this.txtmpm_ipadd2.Name = "txtmpm_ipadd2";
            this.txtmpm_ipadd2.Size = new System.Drawing.Size(86, 20);
            this.txtmpm_ipadd2.TabIndex = 10;
            this.txtmpm_ipadd2.Text = "192.168.1.161";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(15, 24);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(73, 13);
            this.Label11.TabIndex = 6;
            this.Label11.Text = "GPIB Address";
            // 
            // txtmpm_gpibadd2
            // 
            this.txtmpm_gpibadd2.Location = new System.Drawing.Point(17, 40);
            this.txtmpm_gpibadd2.Name = "txtmpm_gpibadd2";
            this.txtmpm_gpibadd2.Size = new System.Drawing.Size(75, 20);
            this.txtmpm_gpibadd2.TabIndex = 5;
            this.txtmpm_gpibadd2.Text = "15";
            // 
            // chkmulti_dev
            // 
            this.chkmulti_dev.AutoSize = true;
            this.chkmulti_dev.Location = new System.Drawing.Point(16, 107);
            this.chkmulti_dev.Name = "chkmulti_dev";
            this.chkmulti_dev.Size = new System.Drawing.Size(85, 17);
            this.chkmulti_dev.TabIndex = 5;
            this.chkmulti_dev.Text = "Multi Device";
            this.chkmulti_dev.UseVisualStyleBackColor = true;
            this.chkmulti_dev.CheckedChanged += new System.EventHandler(this.chkmulti_dev_CheckedChanged);
            // 
            // Instrument_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 605);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.grp_pcu);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Instrument_Setting";
            this.Text = "Instrument_Setting";
            this.Load += new System.EventHandler(this.Instrument_Setting_Load);
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.grp_mpmdev1.ResumeLayout(false);
            this.grp_mpmdev1.PerformLayout();
            this.grp_pcu.ResumeLayout(false);
            this.grp_pcu.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.grp_mpmdev2.ResumeLayout(false);
            this.grp_mpmdev2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnconnect;
        internal System.Windows.Forms.ComboBox cmbpcu_usbresource;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox txtmpm_gpibadd1;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtpcu_lanport;
        internal System.Windows.Forms.GroupBox GroupBox9;
        internal System.Windows.Forms.RadioButton rdopcu_usb;
        internal System.Windows.Forms.RadioButton rdopcu_lan;
        internal System.Windows.Forms.RadioButton rdopcu_gpib;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox txtpcu_ipadd;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.RadioButton rdopcu100;
        internal System.Windows.Forms.RadioButton rdopcu110;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox txtmpm_lanport1;
        internal System.Windows.Forms.TextBox txtmpm_ipadd1;
        internal System.Windows.Forms.TextBox txtpcu_gpibadd;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.GroupBox grp_mpmdev1;
        internal System.Windows.Forms.GroupBox grp_pcu;
        internal System.Windows.Forms.ComboBox cmbpcu_dev;
        internal System.Windows.Forms.RadioButton rdo_mpmtcpip;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cmbtsl_usb;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txttsl_lanport;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.RadioButton rdo_tslusb;
        internal System.Windows.Forms.RadioButton rdo_tsltcpip;
        internal System.Windows.Forms.RadioButton rdotsl_gpib;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.RadioButton rdo570;
        internal System.Windows.Forms.RadioButton rdo550;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txttsl_ipadd;
        internal System.Windows.Forms.TextBox txttsl_gpibadd;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.RadioButton rdo_mpmgpib;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.GroupBox grp_mpmdev2;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtmpm_lanport2;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtmpm_ipadd2;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox txtmpm_gpibadd2;
        internal System.Windows.Forms.CheckBox chkmulti_dev;
    }
}

