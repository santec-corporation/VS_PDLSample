namespace PDLSTS_Sample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Label8 = new System.Windows.Forms.Label();
            this.chksavemu = new System.Windows.Forms.CheckBox();
            this.chk2scan = new System.Windows.Forms.CheckBox();
            this.grp_pdlcal = new System.Windows.Forms.GroupBox();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Button1 = new System.Windows.Forms.Button();
            this.btnsaveRawdata = new System.Windows.Forms.Button();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnsaveref_rawdata = new System.Windows.Forms.Button();
            this.btnmeas = new System.Windows.Forms.Button();
            this.btnget_reference = new System.Windows.Forms.Button();
            this.btnset = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.chklst_range = new System.Windows.Forms.CheckedListBox();
            this.chklst_ch = new System.Windows.Forms.CheckedListBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtpower = new System.Windows.Forms.TextBox();
            this.cmbspeed = new System.Windows.Forms.ComboBox();
            this.txtstepwave = new System.Windows.Forms.TextBox();
            this.txtstartwave = new System.Windows.Forms.TextBox();
            this.txtsaverange = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtstopwave = new System.Windows.Forms.TextBox();
            this.btnsavecalil = new System.Windows.Forms.Button();
            this.chkeach_ch = new System.Windows.Forms.CheckBox();
            this.grp_pdlcal.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(277, 261);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(39, 13);
            this.Label8.TabIndex = 21;
            this.Label8.Text = "Range";
            // 
            // chksavemu
            // 
            this.chksavemu.AutoSize = true;
            this.chksavemu.Location = new System.Drawing.Point(18, 54);
            this.chksavemu.Name = "chksavemu";
            this.chksavemu.Size = new System.Drawing.Size(155, 17);
            this.chksavemu.TabIndex = 1;
            this.chksavemu.Text = "Save of mulluer parametere";
            this.chksavemu.UseVisualStyleBackColor = true;
            // 
            // chk2scan
            // 
            this.chk2scan.AutoSize = true;
            this.chk2scan.Location = new System.Drawing.Point(18, 21);
            this.chk2scan.Name = "chk2scan";
            this.chk2scan.Size = new System.Drawing.Size(150, 17);
            this.chk2scan.TabIndex = 0;
            this.chk2scan.Text = "2SOP for low power range";
            this.chk2scan.UseVisualStyleBackColor = true;
            // 
            // grp_pdlcal
            // 
            this.grp_pdlcal.Controls.Add(this.chksavemu);
            this.grp_pdlcal.Controls.Add(this.chk2scan);
            this.grp_pdlcal.Location = new System.Drawing.Point(394, 142);
            this.grp_pdlcal.Name = "grp_pdlcal";
            this.grp_pdlcal.Size = new System.Drawing.Size(343, 88);
            this.grp_pdlcal.TabIndex = 19;
            this.grp_pdlcal.TabStop = false;
            this.grp_pdlcal.Text = "PDL Calcurate";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(29, 308);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(125, 35);
            this.Button1.TabIndex = 18;
            this.Button1.Text = "Read Reference Data";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnsaveRawdata
            // 
            this.btnsaveRawdata.Location = new System.Drawing.Point(169, 263);
            this.btnsaveRawdata.Name = "btnsaveRawdata";
            this.btnsaveRawdata.Size = new System.Drawing.Size(104, 35);
            this.btnsaveRawdata.TabIndex = 17;
            this.btnsaveRawdata.Text = "Save Rawdata";
            this.btnsaveRawdata.UseVisualStyleBackColor = true;
            this.btnsaveRawdata.Click += new System.EventHandler(this.btnsaveRawdata_Click);
            // 
            // btnsaveref_rawdata
            // 
            this.btnsaveref_rawdata.Location = new System.Drawing.Point(29, 263);
            this.btnsaveref_rawdata.Name = "btnsaveref_rawdata";
            this.btnsaveref_rawdata.Size = new System.Drawing.Size(125, 35);
            this.btnsaveref_rawdata.TabIndex = 16;
            this.btnsaveref_rawdata.Text = "Save Reference Rawdata";
            this.btnsaveref_rawdata.UseVisualStyleBackColor = true;
            this.btnsaveref_rawdata.Click += new System.EventHandler(this.btnsaveref_rawdata_Click);
            // 
            // btnmeas
            // 
            this.btnmeas.Location = new System.Drawing.Point(621, 263);
            this.btnmeas.Name = "btnmeas";
            this.btnmeas.Size = new System.Drawing.Size(106, 35);
            this.btnmeas.TabIndex = 15;
            this.btnmeas.Text = "Measurement";
            this.btnmeas.UseVisualStyleBackColor = true;
            this.btnmeas.Click += new System.EventHandler(this.btnmeas_Click);
            // 
            // btnget_reference
            // 
            this.btnget_reference.Location = new System.Drawing.Point(501, 263);
            this.btnget_reference.Name = "btnget_reference";
            this.btnget_reference.Size = new System.Drawing.Size(102, 35);
            this.btnget_reference.TabIndex = 14;
            this.btnget_reference.Text = "Reference";
            this.btnget_reference.UseVisualStyleBackColor = true;
            this.btnget_reference.Click += new System.EventHandler(this.btnget_reference_Click);
            // 
            // btnset
            // 
            this.btnset.Location = new System.Drawing.Point(396, 263);
            this.btnset.Name = "btnset";
            this.btnset.Size = new System.Drawing.Size(83, 35);
            this.btnset.TabIndex = 13;
            this.btnset.Text = "SET";
            this.btnset.UseVisualStyleBackColor = true;
            this.btnset.Click += new System.EventHandler(this.btnset_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(176, 21);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(106, 13);
            this.Label7.TabIndex = 3;
            this.Label7.Text = "Measurement Range";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(10, 21);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(86, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Measurement ch";
            // 
            // chklst_range
            // 
            this.chklst_range.FormattingEnabled = true;
            this.chklst_range.Location = new System.Drawing.Point(177, 37);
            this.chklst_range.Name = "chklst_range";
            this.chklst_range.Size = new System.Drawing.Size(118, 34);
            this.chklst_range.TabIndex = 1;
            // 
            // chklst_ch
            // 
            this.chklst_ch.FormattingEnabled = true;
            this.chklst_ch.Location = new System.Drawing.Point(12, 37);
            this.chklst_ch.Name = "chklst_ch";
            this.chklst_ch.Size = new System.Drawing.Size(135, 34);
            this.chklst_ch.TabIndex = 0;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.chklst_range);
            this.GroupBox2.Controls.Add(this.chklst_ch);
            this.GroupBox2.Location = new System.Drawing.Point(29, 142);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(332, 89);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Measurement ch And Range";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(560, 37);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "TSL Power(dBm)";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(435, 37);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(113, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "SweepSpeed(nm/sec)";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(312, 38);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(107, 13);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "WavelengthStep(nm)";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(176, 38);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(107, 13);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "StopWavelength(nm)";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(25, 37);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(107, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "StartWavelength(nm)";
            // 
            // txtpower
            // 
            this.txtpower.Location = new System.Drawing.Point(562, 53);
            this.txtpower.Name = "txtpower";
            this.txtpower.Size = new System.Drawing.Size(117, 20);
            this.txtpower.TabIndex = 4;
            this.txtpower.Text = "10";
            // 
            // cmbspeed
            // 
            this.cmbspeed.FormattingEnabled = true;
            this.cmbspeed.Location = new System.Drawing.Point(437, 53);
            this.cmbspeed.Name = "cmbspeed";
            this.cmbspeed.Size = new System.Drawing.Size(102, 21);
            this.cmbspeed.TabIndex = 3;
            // 
            // txtstepwave
            // 
            this.txtstepwave.Location = new System.Drawing.Point(314, 54);
            this.txtstepwave.Name = "txtstepwave";
            this.txtstepwave.Size = new System.Drawing.Size(100, 20);
            this.txtstepwave.TabIndex = 2;
            this.txtstepwave.Text = "0.01";
            // 
            // txtstartwave
            // 
            this.txtstartwave.Location = new System.Drawing.Point(27, 54);
            this.txtstartwave.Name = "txtstartwave";
            this.txtstartwave.Size = new System.Drawing.Size(117, 20);
            this.txtstartwave.TabIndex = 0;
            this.txtstartwave.Text = "1500";
            // 
            // txtsaverange
            // 
            this.txtsaverange.Location = new System.Drawing.Point(279, 277);
            this.txtsaverange.Name = "txtsaverange";
            this.txtsaverange.Size = new System.Drawing.Size(57, 20);
            this.txtsaverange.TabIndex = 20;
            this.txtsaverange.Text = "1";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtpower);
            this.GroupBox1.Controls.Add(this.cmbspeed);
            this.GroupBox1.Controls.Add(this.txtstepwave);
            this.GroupBox1.Controls.Add(this.txtstopwave);
            this.GroupBox1.Controls.Add(this.txtstartwave);
            this.GroupBox1.Location = new System.Drawing.Point(29, 24);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(709, 101);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Sweep Setting";
            // 
            // txtstopwave
            // 
            this.txtstopwave.Location = new System.Drawing.Point(178, 54);
            this.txtstopwave.Name = "txtstopwave";
            this.txtstopwave.Size = new System.Drawing.Size(117, 20);
            this.txtstopwave.TabIndex = 1;
            this.txtstopwave.Text = "1600";
            // 
            // btnsavecalil
            // 
            this.btnsavecalil.Location = new System.Drawing.Point(169, 308);
            this.btnsavecalil.Name = "btnsavecalil";
            this.btnsavecalil.Size = new System.Drawing.Size(104, 35);
            this.btnsavecalil.TabIndex = 22;
            this.btnsavecalil.Text = "Save Calucrated IL";
            this.btnsavecalil.UseVisualStyleBackColor = true;
            this.btnsavecalil.Click += new System.EventHandler(this.btnsavecalil_Click);
            // 
            // chkeach_ch
            // 
            this.chkeach_ch.AutoSize = true;
            this.chkeach_ch.Location = new System.Drawing.Point(396, 308);
            this.chkeach_ch.Name = "chkeach_ch";
            this.chkeach_ch.Size = new System.Drawing.Size(145, 17);
            this.chkeach_ch.TabIndex = 23;
            this.chkeach_ch.Text = "each channel individually";
            this.chkeach_ch.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 357);
            this.Controls.Add(this.chkeach_ch);
            this.Controls.Add(this.btnsavecalil);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.grp_pdlcal);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.btnsaveRawdata);
            this.Controls.Add(this.btnsaveref_rawdata);
            this.Controls.Add(this.btnmeas);
            this.Controls.Add(this.btnget_reference);
            this.Controls.Add(this.btnset);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.txtsaverange);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "STS PDL sample software";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grp_pdlcal.ResumeLayout(false);
            this.grp_pdlcal.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.CheckBox chksavemu;
        internal System.Windows.Forms.CheckBox chk2scan;
        internal System.Windows.Forms.GroupBox grp_pdlcal;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button btnsaveRawdata;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        internal System.Windows.Forms.Button btnsaveref_rawdata;
        internal System.Windows.Forms.Button btnmeas;
        internal System.Windows.Forms.Button btnget_reference;
        internal System.Windows.Forms.Button btnset;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.CheckedListBox chklst_range;
        internal System.Windows.Forms.CheckedListBox chklst_ch;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtpower;
        internal System.Windows.Forms.ComboBox cmbspeed;
        internal System.Windows.Forms.TextBox txtstepwave;
        internal System.Windows.Forms.TextBox txtstartwave;
        internal System.Windows.Forms.TextBox txtsaverange;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtstopwave;
        internal System.Windows.Forms.Button btnsavecalil;
        internal System.Windows.Forms.CheckBox chkeach_ch;
    }
}