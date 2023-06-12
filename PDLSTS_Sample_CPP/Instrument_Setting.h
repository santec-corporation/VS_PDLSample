#pragma once

namespace PDLSTS_Sample_CPP {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class Instrument_Setting : public System::Windows::Forms::Form
	{
	public:
		Instrument_Setting(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}
		cli::array<String^> ^SPU_Resource;                // SPU(DAQ) resource
		cli::array<String^> ^USB_Resource;                 // USB resource
		String^ TSL_Communicater;               // TSL communication method
		String^ MPM_Communicater;               // MPM communication method
		String^ PCU_Communicater;               // PCU commnuication method

		String^ TSL_Address;                    // TSL Address  (GPIB/IP address/USB resource number)
		int TSL_Portnumber;                // TSL LAN port number

		int MPM_Count;                     // MPM number of control count
		cli::array<String^> ^MPM_Address = gcnew  cli::array<String^>(2);                   // MPM Address(GPIB/IP address/USB resource number)
		cli::array<int> ^ MPM_Portnumber = gcnew cli::array<int>(2);            // MPM LAN Port number

		String^ PCU_Address;                    // PCU Address(GPIB/IP address/USB resource number)
		int PCU_Portnumber;                // PCU LAN Port number

		String ^SPU_DeviveID;                   // SPU(DAQ) Device ID 
		bool PCU_useing_internal_DAQ;       // SPU(DAQ) use inside PCU or not  T:in PCU F: other

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Instrument_Setting()
		{
			if (components)
			{
				delete components;
			}
		}
	internal: System::Windows::Forms::TextBox^  txtmpm_gpibadd2;
	protected:
	internal: System::Windows::Forms::Label^  Label5;
	internal: System::Windows::Forms::ComboBox^  cmbtsl_usb;
	internal: System::Windows::Forms::Label^  Label4;
	internal: System::Windows::Forms::TextBox^  txttsl_lanport;
	internal: System::Windows::Forms::Label^  Label3;
	internal: System::Windows::Forms::GroupBox^  GroupBox5;
	internal: System::Windows::Forms::RadioButton^  rdo_tslusb;
	internal: System::Windows::Forms::RadioButton^  rdo_tsltcpip;
	internal: System::Windows::Forms::RadioButton^  rdotsl_gpib;
	internal: System::Windows::Forms::GroupBox^  GroupBox4;
	internal: System::Windows::Forms::RadioButton^  rdo570;
	internal: System::Windows::Forms::RadioButton^  rdo550;
	internal: System::Windows::Forms::Label^  Label2;
	internal: System::Windows::Forms::TextBox^  txttsl_ipadd;
	internal: System::Windows::Forms::TextBox^  txttsl_gpibadd;
	internal: System::Windows::Forms::GroupBox^  GroupBox8;
	internal: System::Windows::Forms::RadioButton^  rdo_mpmtcpip;
	internal: System::Windows::Forms::RadioButton^  rdo_mpmgpib;
	internal: System::Windows::Forms::GroupBox^  GroupBox2;
	internal: System::Windows::Forms::GroupBox^  grp_mpmdev2;
	internal: System::Windows::Forms::Label^  Label9;
	internal: System::Windows::Forms::TextBox^  txtmpm_lanport2;
	internal: System::Windows::Forms::Label^  Label10;
	internal: System::Windows::Forms::TextBox^  txtmpm_ipadd2;
	internal: System::Windows::Forms::Label^  Label11;
	internal: System::Windows::Forms::CheckBox^  chkmulti_dev;
	internal: System::Windows::Forms::GroupBox^  grp_mpmdev1;
	internal: System::Windows::Forms::Label^  Label7;
	internal: System::Windows::Forms::TextBox^  txtmpm_lanport1;
	internal: System::Windows::Forms::Label^  Label8;
	internal: System::Windows::Forms::TextBox^  txtmpm_ipadd1;
	internal: System::Windows::Forms::Label^  Label6;
	internal: System::Windows::Forms::TextBox^  txtmpm_gpibadd1;
	internal: System::Windows::Forms::GroupBox^  GroupBox1;
	internal: System::Windows::Forms::Button^  btnconnect;
	internal: System::Windows::Forms::Label^  Label16;
	internal: System::Windows::Forms::ComboBox^  cmbpcu_usbresource;
	internal: System::Windows::Forms::Label^  Label13;
	internal: System::Windows::Forms::TextBox^  txtpcu_lanport;
	internal: System::Windows::Forms::GroupBox^  GroupBox9;
	internal: System::Windows::Forms::RadioButton^  rdopcu_usb;
	internal: System::Windows::Forms::RadioButton^  rdopcu_lan;
	internal: System::Windows::Forms::RadioButton^  rdopcu_gpib;
	internal: System::Windows::Forms::ComboBox^  cmbpcu_dev;
	internal: System::Windows::Forms::Label^  Label15;
	internal: System::Windows::Forms::TextBox^  txtpcu_ipadd;
	internal: System::Windows::Forms::GroupBox^  GroupBox7;
	internal: System::Windows::Forms::RadioButton^  rdopcu100;
	internal: System::Windows::Forms::RadioButton^  rdopcu110;
	internal: System::Windows::Forms::TextBox^  txtpcu_gpibadd;
	internal: System::Windows::Forms::Label^  Label12;
	internal: System::Windows::Forms::Label^  Label14;
	internal: System::Windows::Forms::GroupBox^  grp_pcu;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Instrument_Setting::typeid));
			this->txtmpm_gpibadd2 = (gcnew System::Windows::Forms::TextBox());
			this->Label5 = (gcnew System::Windows::Forms::Label());
			this->cmbtsl_usb = (gcnew System::Windows::Forms::ComboBox());
			this->Label4 = (gcnew System::Windows::Forms::Label());
			this->txttsl_lanport = (gcnew System::Windows::Forms::TextBox());
			this->Label3 = (gcnew System::Windows::Forms::Label());
			this->GroupBox5 = (gcnew System::Windows::Forms::GroupBox());
			this->rdo_tslusb = (gcnew System::Windows::Forms::RadioButton());
			this->rdo_tsltcpip = (gcnew System::Windows::Forms::RadioButton());
			this->rdotsl_gpib = (gcnew System::Windows::Forms::RadioButton());
			this->GroupBox4 = (gcnew System::Windows::Forms::GroupBox());
			this->rdo570 = (gcnew System::Windows::Forms::RadioButton());
			this->rdo550 = (gcnew System::Windows::Forms::RadioButton());
			this->Label2 = (gcnew System::Windows::Forms::Label());
			this->txttsl_ipadd = (gcnew System::Windows::Forms::TextBox());
			this->txttsl_gpibadd = (gcnew System::Windows::Forms::TextBox());
			this->GroupBox8 = (gcnew System::Windows::Forms::GroupBox());
			this->rdo_mpmtcpip = (gcnew System::Windows::Forms::RadioButton());
			this->rdo_mpmgpib = (gcnew System::Windows::Forms::RadioButton());
			this->GroupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->grp_mpmdev2 = (gcnew System::Windows::Forms::GroupBox());
			this->Label9 = (gcnew System::Windows::Forms::Label());
			this->txtmpm_lanport2 = (gcnew System::Windows::Forms::TextBox());
			this->Label10 = (gcnew System::Windows::Forms::Label());
			this->txtmpm_ipadd2 = (gcnew System::Windows::Forms::TextBox());
			this->Label11 = (gcnew System::Windows::Forms::Label());
			this->chkmulti_dev = (gcnew System::Windows::Forms::CheckBox());
			this->grp_mpmdev1 = (gcnew System::Windows::Forms::GroupBox());
			this->Label7 = (gcnew System::Windows::Forms::Label());
			this->txtmpm_lanport1 = (gcnew System::Windows::Forms::TextBox());
			this->Label8 = (gcnew System::Windows::Forms::Label());
			this->txtmpm_ipadd1 = (gcnew System::Windows::Forms::TextBox());
			this->Label6 = (gcnew System::Windows::Forms::Label());
			this->txtmpm_gpibadd1 = (gcnew System::Windows::Forms::TextBox());
			this->GroupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->btnconnect = (gcnew System::Windows::Forms::Button());
			this->Label16 = (gcnew System::Windows::Forms::Label());
			this->cmbpcu_usbresource = (gcnew System::Windows::Forms::ComboBox());
			this->Label13 = (gcnew System::Windows::Forms::Label());
			this->txtpcu_lanport = (gcnew System::Windows::Forms::TextBox());
			this->GroupBox9 = (gcnew System::Windows::Forms::GroupBox());
			this->rdopcu_usb = (gcnew System::Windows::Forms::RadioButton());
			this->rdopcu_lan = (gcnew System::Windows::Forms::RadioButton());
			this->rdopcu_gpib = (gcnew System::Windows::Forms::RadioButton());
			this->cmbpcu_dev = (gcnew System::Windows::Forms::ComboBox());
			this->Label15 = (gcnew System::Windows::Forms::Label());
			this->txtpcu_ipadd = (gcnew System::Windows::Forms::TextBox());
			this->GroupBox7 = (gcnew System::Windows::Forms::GroupBox());
			this->rdopcu100 = (gcnew System::Windows::Forms::RadioButton());
			this->rdopcu110 = (gcnew System::Windows::Forms::RadioButton());
			this->txtpcu_gpibadd = (gcnew System::Windows::Forms::TextBox());
			this->Label12 = (gcnew System::Windows::Forms::Label());
			this->Label14 = (gcnew System::Windows::Forms::Label());
			this->grp_pcu = (gcnew System::Windows::Forms::GroupBox());
			this->GroupBox5->SuspendLayout();
			this->GroupBox4->SuspendLayout();
			this->GroupBox8->SuspendLayout();
			this->GroupBox2->SuspendLayout();
			this->grp_mpmdev2->SuspendLayout();
			this->grp_mpmdev1->SuspendLayout();
			this->GroupBox1->SuspendLayout();
			this->GroupBox9->SuspendLayout();
			this->GroupBox7->SuspendLayout();
			this->grp_pcu->SuspendLayout();
			this->SuspendLayout();
			// 
			// txtmpm_gpibadd2
			// 
			this->txtmpm_gpibadd2->Location = System::Drawing::Point(17, 40);
			this->txtmpm_gpibadd2->Name = L"txtmpm_gpibadd2";
			this->txtmpm_gpibadd2->Size = System::Drawing::Size(75, 20);
			this->txtmpm_gpibadd2->TabIndex = 5;
			this->txtmpm_gpibadd2->Text = L"15";
			// 
			// Label5
			// 
			this->Label5->AutoSize = true;
			this->Label5->Location = System::Drawing::Point(292, 82);
			this->Label5->Name = L"Label5";
			this->Label5->Size = System::Drawing::Size(78, 13);
			this->Label5->TabIndex = 11;
			this->Label5->Text = L"USB Resource";
			// 
			// cmbtsl_usb
			// 
			this->cmbtsl_usb->Enabled = false;
			this->cmbtsl_usb->FormattingEnabled = true;
			this->cmbtsl_usb->Location = System::Drawing::Point(294, 102);
			this->cmbtsl_usb->Name = L"cmbtsl_usb";
			this->cmbtsl_usb->Size = System::Drawing::Size(172, 21);
			this->cmbtsl_usb->TabIndex = 10;
			// 
			// Label4
			// 
			this->Label4->AutoSize = true;
			this->Label4->Location = System::Drawing::Point(481, 24);
			this->Label4->Name = L"Label4";
			this->Label4->Size = System::Drawing::Size(50, 13);
			this->Label4->TabIndex = 9;
			this->Label4->Text = L"LAN Port";
			// 
			// txttsl_lanport
			// 
			this->txttsl_lanport->Enabled = false;
			this->txttsl_lanport->Location = System::Drawing::Point(483, 40);
			this->txttsl_lanport->Name = L"txttsl_lanport";
			this->txttsl_lanport->Size = System::Drawing::Size(50, 20);
			this->txttsl_lanport->TabIndex = 8;
			this->txttsl_lanport->Text = L"5000";
			// 
			// Label3
			// 
			this->Label3->AutoSize = true;
			this->Label3->Location = System::Drawing::Point(378, 24);
			this->Label3->Name = L"Label3";
			this->Label3->Size = System::Drawing::Size(58, 13);
			this->Label3->TabIndex = 7;
			this->Label3->Text = L"IP Address";
			// 
			// GroupBox5
			// 
			this->GroupBox5->Controls->Add(this->rdo_tslusb);
			this->GroupBox5->Controls->Add(this->rdo_tsltcpip);
			this->GroupBox5->Controls->Add(this->rdotsl_gpib);
			this->GroupBox5->Location = System::Drawing::Point(145, 24);
			this->GroupBox5->Name = L"GroupBox5";
			this->GroupBox5->Size = System::Drawing::Size(132, 115);
			this->GroupBox5->TabIndex = 6;
			this->GroupBox5->TabStop = false;
			this->GroupBox5->Text = L"Communication";
			// 
			// rdo_tslusb
			// 
			this->rdo_tslusb->AutoSize = true;
			this->rdo_tslusb->Location = System::Drawing::Point(17, 82);
			this->rdo_tslusb->Name = L"rdo_tslusb";
			this->rdo_tslusb->Size = System::Drawing::Size(47, 17);
			this->rdo_tslusb->TabIndex = 3;
			this->rdo_tslusb->Text = L"USB";
			this->rdo_tslusb->UseVisualStyleBackColor = true;
			this->rdo_tslusb->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdo_tslusb_CheckedChanged);
			// 
			// rdo_tsltcpip
			// 
			this->rdo_tsltcpip->AutoSize = true;
			this->rdo_tsltcpip->Location = System::Drawing::Point(17, 54);
			this->rdo_tsltcpip->Name = L"rdo_tsltcpip";
			this->rdo_tsltcpip->Size = System::Drawing::Size(61, 17);
			this->rdo_tsltcpip->TabIndex = 2;
			this->rdo_tsltcpip->Text = L"TCP/IP";
			this->rdo_tsltcpip->UseVisualStyleBackColor = true;
			this->rdo_tsltcpip->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdo_tsltcpip_CheckedChanged);
			// 
			// rdotsl_gpib
			// 
			this->rdotsl_gpib->AutoSize = true;
			this->rdotsl_gpib->Checked = true;
			this->rdotsl_gpib->Location = System::Drawing::Point(17, 20);
			this->rdotsl_gpib->Name = L"rdotsl_gpib";
			this->rdotsl_gpib->Size = System::Drawing::Size(50, 17);
			this->rdotsl_gpib->TabIndex = 1;
			this->rdotsl_gpib->TabStop = true;
			this->rdotsl_gpib->Text = L"GPIB";
			this->rdotsl_gpib->UseVisualStyleBackColor = true;
			this->rdotsl_gpib->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdotsl_gpib_CheckedChanged);
			// 
			// GroupBox4
			// 
			this->GroupBox4->Controls->Add(this->rdo570);
			this->GroupBox4->Controls->Add(this->rdo550);
			this->GroupBox4->Location = System::Drawing::Point(16, 24);
			this->GroupBox4->Name = L"GroupBox4";
			this->GroupBox4->Size = System::Drawing::Size(123, 115);
			this->GroupBox4->TabIndex = 5;
			this->GroupBox4->TabStop = false;
			this->GroupBox4->Text = L"Product";
			// 
			// rdo570
			// 
			this->rdo570->AutoSize = true;
			this->rdo570->Checked = true;
			this->rdo570->Location = System::Drawing::Point(15, 33);
			this->rdo570->Name = L"rdo570";
			this->rdo570->Size = System::Drawing::Size(89, 17);
			this->rdo570->TabIndex = 0;
			this->rdo570->TabStop = true;
			this->rdo570->Text = L"TSL-570/770";
			this->rdo570->UseVisualStyleBackColor = true;
			this->rdo570->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdo570_CheckedChanged);
			// 
			// rdo550
			// 
			this->rdo550->AutoSize = true;
			this->rdo550->Location = System::Drawing::Point(15, 67);
			this->rdo550->Name = L"rdo550";
			this->rdo550->Size = System::Drawing::Size(89, 17);
			this->rdo550->TabIndex = 1;
			this->rdo550->Text = L"TSL-550/710";
			this->rdo550->UseVisualStyleBackColor = true;
			// 
			// Label2
			// 
			this->Label2->AutoSize = true;
			this->Label2->Location = System::Drawing::Point(292, 24);
			this->Label2->Name = L"Label2";
			this->Label2->Size = System::Drawing::Size(73, 13);
			this->Label2->TabIndex = 4;
			this->Label2->Text = L"GPIB Address";
			// 
			// txttsl_ipadd
			// 
			this->txttsl_ipadd->Enabled = false;
			this->txttsl_ipadd->Location = System::Drawing::Point(380, 40);
			this->txttsl_ipadd->Name = L"txttsl_ipadd";
			this->txttsl_ipadd->Size = System::Drawing::Size(86, 20);
			this->txttsl_ipadd->TabIndex = 3;
			this->txttsl_ipadd->Text = L"192.168.1.100";
			// 
			// txttsl_gpibadd
			// 
			this->txttsl_gpibadd->Location = System::Drawing::Point(294, 40);
			this->txttsl_gpibadd->Name = L"txttsl_gpibadd";
			this->txttsl_gpibadd->Size = System::Drawing::Size(75, 20);
			this->txttsl_gpibadd->TabIndex = 2;
			this->txttsl_gpibadd->Text = L"1";
			// 
			// GroupBox8
			// 
			this->GroupBox8->Controls->Add(this->rdo_mpmtcpip);
			this->GroupBox8->Controls->Add(this->rdo_mpmgpib);
			this->GroupBox8->Location = System::Drawing::Point(16, 20);
			this->GroupBox8->Name = L"GroupBox8";
			this->GroupBox8->Size = System::Drawing::Size(123, 69);
			this->GroupBox8->TabIndex = 4;
			this->GroupBox8->TabStop = false;
			this->GroupBox8->Text = L"Communication";
			// 
			// rdo_mpmtcpip
			// 
			this->rdo_mpmtcpip->AutoSize = true;
			this->rdo_mpmtcpip->Location = System::Drawing::Point(24, 43);
			this->rdo_mpmtcpip->Name = L"rdo_mpmtcpip";
			this->rdo_mpmtcpip->Size = System::Drawing::Size(61, 17);
			this->rdo_mpmtcpip->TabIndex = 3;
			this->rdo_mpmtcpip->Text = L"TCP/IP";
			this->rdo_mpmtcpip->UseVisualStyleBackColor = true;
			// 
			// rdo_mpmgpib
			// 
			this->rdo_mpmgpib->AutoSize = true;
			this->rdo_mpmgpib->Checked = true;
			this->rdo_mpmgpib->Location = System::Drawing::Point(24, 20);
			this->rdo_mpmgpib->Name = L"rdo_mpmgpib";
			this->rdo_mpmgpib->Size = System::Drawing::Size(50, 17);
			this->rdo_mpmgpib->TabIndex = 2;
			this->rdo_mpmgpib->TabStop = true;
			this->rdo_mpmgpib->Text = L"GPIB";
			this->rdo_mpmgpib->UseVisualStyleBackColor = true;
			this->rdo_mpmgpib->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdo_mpmgpib_CheckedChanged);
			// 
			// GroupBox2
			// 
			this->GroupBox2->Controls->Add(this->grp_mpmdev2);
			this->GroupBox2->Controls->Add(this->chkmulti_dev);
			this->GroupBox2->Controls->Add(this->GroupBox8);
			this->GroupBox2->Controls->Add(this->grp_mpmdev1);
			this->GroupBox2->Location = System::Drawing::Point(25, 190);
			this->GroupBox2->Name = L"GroupBox2";
			this->GroupBox2->Size = System::Drawing::Size(546, 180);
			this->GroupBox2->TabIndex = 10;
			this->GroupBox2->TabStop = false;
			this->GroupBox2->Text = L"MPM";
			// 
			// grp_mpmdev2
			// 
			this->grp_mpmdev2->Controls->Add(this->Label9);
			this->grp_mpmdev2->Controls->Add(this->txtmpm_lanport2);
			this->grp_mpmdev2->Controls->Add(this->Label10);
			this->grp_mpmdev2->Controls->Add(this->txtmpm_ipadd2);
			this->grp_mpmdev2->Controls->Add(this->Label11);
			this->grp_mpmdev2->Controls->Add(this->txtmpm_gpibadd2);
			this->grp_mpmdev2->Enabled = false;
			this->grp_mpmdev2->Location = System::Drawing::Point(335, 20);
			this->grp_mpmdev2->Name = L"grp_mpmdev2";
			this->grp_mpmdev2->Size = System::Drawing::Size(184, 141);
			this->grp_mpmdev2->TabIndex = 6;
			this->grp_mpmdev2->TabStop = false;
			this->grp_mpmdev2->Text = L"Device1";
			// 
			// Label9
			// 
			this->Label9->AutoSize = true;
			this->Label9->Location = System::Drawing::Point(118, 72);
			this->Label9->Name = L"Label9";
			this->Label9->Size = System::Drawing::Size(50, 13);
			this->Label9->TabIndex = 13;
			this->Label9->Text = L"LAN Port";
			// 
			// txtmpm_lanport2
			// 
			this->txtmpm_lanport2->Enabled = false;
			this->txtmpm_lanport2->Location = System::Drawing::Point(120, 88);
			this->txtmpm_lanport2->Name = L"txtmpm_lanport2";
			this->txtmpm_lanport2->Size = System::Drawing::Size(50, 20);
			this->txtmpm_lanport2->TabIndex = 12;
			this->txtmpm_lanport2->Text = L"5000";
			// 
			// Label10
			// 
			this->Label10->AutoSize = true;
			this->Label10->Location = System::Drawing::Point(15, 72);
			this->Label10->Name = L"Label10";
			this->Label10->Size = System::Drawing::Size(58, 13);
			this->Label10->TabIndex = 11;
			this->Label10->Text = L"IP Address";
			// 
			// txtmpm_ipadd2
			// 
			this->txtmpm_ipadd2->Enabled = false;
			this->txtmpm_ipadd2->Location = System::Drawing::Point(17, 88);
			this->txtmpm_ipadd2->Name = L"txtmpm_ipadd2";
			this->txtmpm_ipadd2->Size = System::Drawing::Size(86, 20);
			this->txtmpm_ipadd2->TabIndex = 10;
			this->txtmpm_ipadd2->Text = L"192.168.1.161";
			// 
			// Label11
			// 
			this->Label11->AutoSize = true;
			this->Label11->Location = System::Drawing::Point(15, 24);
			this->Label11->Name = L"Label11";
			this->Label11->Size = System::Drawing::Size(73, 13);
			this->Label11->TabIndex = 6;
			this->Label11->Text = L"GPIB Address";
			// 
			// chkmulti_dev
			// 
			this->chkmulti_dev->AutoSize = true;
			this->chkmulti_dev->Location = System::Drawing::Point(16, 107);
			this->chkmulti_dev->Name = L"chkmulti_dev";
			this->chkmulti_dev->Size = System::Drawing::Size(85, 17);
			this->chkmulti_dev->TabIndex = 5;
			this->chkmulti_dev->Text = L"Multi Device";
			this->chkmulti_dev->UseVisualStyleBackColor = true;
			this->chkmulti_dev->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::chkmulti_dev_CheckedChanged);
			// 
			// grp_mpmdev1
			// 
			this->grp_mpmdev1->Controls->Add(this->Label7);
			this->grp_mpmdev1->Controls->Add(this->txtmpm_lanport1);
			this->grp_mpmdev1->Controls->Add(this->Label8);
			this->grp_mpmdev1->Controls->Add(this->txtmpm_ipadd1);
			this->grp_mpmdev1->Controls->Add(this->Label6);
			this->grp_mpmdev1->Controls->Add(this->txtmpm_gpibadd1);
			this->grp_mpmdev1->Location = System::Drawing::Point(145, 20);
			this->grp_mpmdev1->Name = L"grp_mpmdev1";
			this->grp_mpmdev1->Size = System::Drawing::Size(184, 141);
			this->grp_mpmdev1->TabIndex = 0;
			this->grp_mpmdev1->TabStop = false;
			this->grp_mpmdev1->Text = L"Device1";
			// 
			// Label7
			// 
			this->Label7->AutoSize = true;
			this->Label7->Location = System::Drawing::Point(118, 72);
			this->Label7->Name = L"Label7";
			this->Label7->Size = System::Drawing::Size(50, 13);
			this->Label7->TabIndex = 13;
			this->Label7->Text = L"LAN Port";
			// 
			// txtmpm_lanport1
			// 
			this->txtmpm_lanport1->Enabled = false;
			this->txtmpm_lanport1->Location = System::Drawing::Point(120, 88);
			this->txtmpm_lanport1->Name = L"txtmpm_lanport1";
			this->txtmpm_lanport1->Size = System::Drawing::Size(50, 20);
			this->txtmpm_lanport1->TabIndex = 12;
			this->txtmpm_lanport1->Text = L"5000";
			// 
			// Label8
			// 
			this->Label8->AutoSize = true;
			this->Label8->Location = System::Drawing::Point(15, 72);
			this->Label8->Name = L"Label8";
			this->Label8->Size = System::Drawing::Size(58, 13);
			this->Label8->TabIndex = 11;
			this->Label8->Text = L"IP Address";
			// 
			// txtmpm_ipadd1
			// 
			this->txtmpm_ipadd1->Enabled = false;
			this->txtmpm_ipadd1->Location = System::Drawing::Point(17, 88);
			this->txtmpm_ipadd1->Name = L"txtmpm_ipadd1";
			this->txtmpm_ipadd1->Size = System::Drawing::Size(86, 20);
			this->txtmpm_ipadd1->TabIndex = 10;
			this->txtmpm_ipadd1->Text = L"192.168.1.161";
			// 
			// Label6
			// 
			this->Label6->AutoSize = true;
			this->Label6->Location = System::Drawing::Point(15, 24);
			this->Label6->Name = L"Label6";
			this->Label6->Size = System::Drawing::Size(73, 13);
			this->Label6->TabIndex = 6;
			this->Label6->Text = L"GPIB Address";
			// 
			// txtmpm_gpibadd1
			// 
			this->txtmpm_gpibadd1->Location = System::Drawing::Point(17, 40);
			this->txtmpm_gpibadd1->Name = L"txtmpm_gpibadd1";
			this->txtmpm_gpibadd1->Size = System::Drawing::Size(75, 20);
			this->txtmpm_gpibadd1->TabIndex = 5;
			this->txtmpm_gpibadd1->Text = L"16";
			// 
			// GroupBox1
			// 
			this->GroupBox1->Controls->Add(this->Label5);
			this->GroupBox1->Controls->Add(this->cmbtsl_usb);
			this->GroupBox1->Controls->Add(this->Label4);
			this->GroupBox1->Controls->Add(this->txttsl_lanport);
			this->GroupBox1->Controls->Add(this->Label3);
			this->GroupBox1->Controls->Add(this->GroupBox5);
			this->GroupBox1->Controls->Add(this->GroupBox4);
			this->GroupBox1->Controls->Add(this->Label2);
			this->GroupBox1->Controls->Add(this->txttsl_ipadd);
			this->GroupBox1->Controls->Add(this->txttsl_gpibadd);
			this->GroupBox1->Location = System::Drawing::Point(25, 24);
			this->GroupBox1->Name = L"GroupBox1";
			this->GroupBox1->Size = System::Drawing::Size(546, 159);
			this->GroupBox1->TabIndex = 9;
			this->GroupBox1->TabStop = false;
			this->GroupBox1->Text = L"TSL ";
			// 
			// btnconnect
			// 
			this->btnconnect->Location = System::Drawing::Point(35, 543);
			this->btnconnect->Name = L"btnconnect";
			this->btnconnect->Size = System::Drawing::Size(198, 38);
			this->btnconnect->TabIndex = 11;
			this->btnconnect->Text = L"Connect";
			this->btnconnect->UseVisualStyleBackColor = true;
			this->btnconnect->Click += gcnew System::EventHandler(this, &Instrument_Setting::btnconnect_Click);
			// 
			// Label16
			// 
			this->Label16->AutoSize = true;
			this->Label16->Location = System::Drawing::Point(310, 88);
			this->Label16->Name = L"Label16";
			this->Label16->Size = System::Drawing::Size(78, 13);
			this->Label16->TabIndex = 17;
			this->Label16->Text = L"USB Resource";
			// 
			// cmbpcu_usbresource
			// 
			this->cmbpcu_usbresource->Enabled = false;
			this->cmbpcu_usbresource->FormattingEnabled = true;
			this->cmbpcu_usbresource->Location = System::Drawing::Point(312, 107);
			this->cmbpcu_usbresource->Name = L"cmbpcu_usbresource";
			this->cmbpcu_usbresource->Size = System::Drawing::Size(172, 21);
			this->cmbpcu_usbresource->TabIndex = 16;
			// 
			// Label13
			// 
			this->Label13->AutoSize = true;
			this->Label13->Location = System::Drawing::Point(488, 23);
			this->Label13->Name = L"Label13";
			this->Label13->Size = System::Drawing::Size(50, 13);
			this->Label13->TabIndex = 15;
			this->Label13->Text = L"LAN Port";
			// 
			// txtpcu_lanport
			// 
			this->txtpcu_lanport->Enabled = false;
			this->txtpcu_lanport->Location = System::Drawing::Point(490, 39);
			this->txtpcu_lanport->Name = L"txtpcu_lanport";
			this->txtpcu_lanport->Size = System::Drawing::Size(50, 20);
			this->txtpcu_lanport->TabIndex = 14;
			this->txtpcu_lanport->Text = L"5000";
			// 
			// GroupBox9
			// 
			this->GroupBox9->Controls->Add(this->rdopcu_usb);
			this->GroupBox9->Controls->Add(this->rdopcu_lan);
			this->GroupBox9->Controls->Add(this->rdopcu_gpib);
			this->GroupBox9->Location = System::Drawing::Point(159, 20);
			this->GroupBox9->Name = L"GroupBox9";
			this->GroupBox9->Size = System::Drawing::Size(144, 63);
			this->GroupBox9->TabIndex = 7;
			this->GroupBox9->TabStop = false;
			this->GroupBox9->Text = L"Communication";
			// 
			// rdopcu_usb
			// 
			this->rdopcu_usb->AutoSize = true;
			this->rdopcu_usb->Location = System::Drawing::Point(84, 39);
			this->rdopcu_usb->Name = L"rdopcu_usb";
			this->rdopcu_usb->Size = System::Drawing::Size(47, 17);
			this->rdopcu_usb->TabIndex = 3;
			this->rdopcu_usb->Text = L"USB";
			this->rdopcu_usb->UseVisualStyleBackColor = true;
			this->rdopcu_usb->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdopcu_usb_CheckedChanged);
			// 
			// rdopcu_lan
			// 
			this->rdopcu_lan->AutoSize = true;
			this->rdopcu_lan->Location = System::Drawing::Point(15, 39);
			this->rdopcu_lan->Name = L"rdopcu_lan";
			this->rdopcu_lan->Size = System::Drawing::Size(61, 17);
			this->rdopcu_lan->TabIndex = 2;
			this->rdopcu_lan->Text = L"TCP/IP";
			this->rdopcu_lan->UseVisualStyleBackColor = true;
			this->rdopcu_lan->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdopcu_lan_CheckedChanged);
			// 
			// rdopcu_gpib
			// 
			this->rdopcu_gpib->AutoSize = true;
			this->rdopcu_gpib->Checked = true;
			this->rdopcu_gpib->Location = System::Drawing::Point(15, 16);
			this->rdopcu_gpib->Name = L"rdopcu_gpib";
			this->rdopcu_gpib->Size = System::Drawing::Size(50, 17);
			this->rdopcu_gpib->TabIndex = 1;
			this->rdopcu_gpib->TabStop = true;
			this->rdopcu_gpib->Text = L"GPIB";
			this->rdopcu_gpib->UseVisualStyleBackColor = true;
			this->rdopcu_gpib->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdopcu_gpib_CheckedChanged);
			// 
			// cmbpcu_dev
			// 
			this->cmbpcu_dev->FormattingEnabled = true;
			this->cmbpcu_dev->Location = System::Drawing::Point(31, 107);
			this->cmbpcu_dev->Name = L"cmbpcu_dev";
			this->cmbpcu_dev->Size = System::Drawing::Size(113, 21);
			this->cmbpcu_dev->TabIndex = 0;
			// 
			// Label15
			// 
			this->Label15->AutoSize = true;
			this->Label15->Location = System::Drawing::Point(310, 23);
			this->Label15->Name = L"Label15";
			this->Label15->Size = System::Drawing::Size(73, 13);
			this->Label15->TabIndex = 12;
			this->Label15->Text = L"GPIB Address";
			// 
			// txtpcu_ipadd
			// 
			this->txtpcu_ipadd->Enabled = false;
			this->txtpcu_ipadd->Location = System::Drawing::Point(398, 39);
			this->txtpcu_ipadd->Name = L"txtpcu_ipadd";
			this->txtpcu_ipadd->Size = System::Drawing::Size(86, 20);
			this->txtpcu_ipadd->TabIndex = 11;
			this->txtpcu_ipadd->Text = L"192.168.1.100";
			// 
			// GroupBox7
			// 
			this->GroupBox7->Controls->Add(this->rdopcu100);
			this->GroupBox7->Controls->Add(this->rdopcu110);
			this->GroupBox7->Location = System::Drawing::Point(23, 20);
			this->GroupBox7->Name = L"GroupBox7";
			this->GroupBox7->Size = System::Drawing::Size(130, 63);
			this->GroupBox7->TabIndex = 6;
			this->GroupBox7->TabStop = false;
			this->GroupBox7->Text = L"Product";
			// 
			// rdopcu100
			// 
			this->rdopcu100->AutoSize = true;
			this->rdopcu100->Checked = true;
			this->rdopcu100->Location = System::Drawing::Point(21, 20);
			this->rdopcu100->Name = L"rdopcu100";
			this->rdopcu100->Size = System::Drawing::Size(68, 17);
			this->rdopcu100->TabIndex = 0;
			this->rdopcu100->TabStop = true;
			this->rdopcu100->Text = L"PCU-100";
			this->rdopcu100->UseVisualStyleBackColor = true;
			this->rdopcu100->CheckedChanged += gcnew System::EventHandler(this, &Instrument_Setting::rdopcu100_CheckedChanged);
			// 
			// rdopcu110
			// 
			this->rdopcu110->AutoSize = true;
			this->rdopcu110->Location = System::Drawing::Point(21, 39);
			this->rdopcu110->Name = L"rdopcu110";
			this->rdopcu110->Size = System::Drawing::Size(68, 17);
			this->rdopcu110->TabIndex = 1;
			this->rdopcu110->Text = L"PCU-110";
			this->rdopcu110->UseVisualStyleBackColor = true;
			// 
			// txtpcu_gpibadd
			// 
			this->txtpcu_gpibadd->Location = System::Drawing::Point(312, 39);
			this->txtpcu_gpibadd->Name = L"txtpcu_gpibadd";
			this->txtpcu_gpibadd->Size = System::Drawing::Size(75, 20);
			this->txtpcu_gpibadd->TabIndex = 10;
			this->txtpcu_gpibadd->Text = L"5";
			// 
			// Label12
			// 
			this->Label12->AutoSize = true;
			this->Label12->Location = System::Drawing::Point(29, 91);
			this->Label12->Name = L"Label12";
			this->Label12->Size = System::Drawing::Size(29, 13);
			this->Label12->TabIndex = 1;
			this->Label12->Text = L"SPU";
			// 
			// Label14
			// 
			this->Label14->AutoSize = true;
			this->Label14->Location = System::Drawing::Point(396, 23);
			this->Label14->Name = L"Label14";
			this->Label14->Size = System::Drawing::Size(58, 13);
			this->Label14->TabIndex = 13;
			this->Label14->Text = L"IP Address";
			// 
			// grp_pcu
			// 
			this->grp_pcu->Controls->Add(this->Label16);
			this->grp_pcu->Controls->Add(this->cmbpcu_usbresource);
			this->grp_pcu->Controls->Add(this->Label13);
			this->grp_pcu->Controls->Add(this->txtpcu_lanport);
			this->grp_pcu->Controls->Add(this->Label14);
			this->grp_pcu->Controls->Add(this->Label15);
			this->grp_pcu->Controls->Add(this->txtpcu_ipadd);
			this->grp_pcu->Controls->Add(this->txtpcu_gpibadd);
			this->grp_pcu->Controls->Add(this->GroupBox9);
			this->grp_pcu->Controls->Add(this->GroupBox7);
			this->grp_pcu->Controls->Add(this->Label12);
			this->grp_pcu->Controls->Add(this->cmbpcu_dev);
			this->grp_pcu->Location = System::Drawing::Point(25, 376);
			this->grp_pcu->Name = L"grp_pcu";
			this->grp_pcu->Size = System::Drawing::Size(546, 146);
			this->grp_pcu->TabIndex = 12;
			this->grp_pcu->TabStop = false;
			this->grp_pcu->Text = L"PCU";
			// 
			// Instrument_Setting
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(597, 605);
			this->Controls->Add(this->GroupBox2);
			this->Controls->Add(this->GroupBox1);
			this->Controls->Add(this->btnconnect);
			this->Controls->Add(this->grp_pcu);
			this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
			this->Name = L"Instrument_Setting";
			this->Text = L"Instrument_Setting";
			this->Load += gcnew System::EventHandler(this, &Instrument_Setting::Instrument_Setting_Load);
			this->GroupBox5->ResumeLayout(false);
			this->GroupBox5->PerformLayout();
			this->GroupBox4->ResumeLayout(false);
			this->GroupBox4->PerformLayout();
			this->GroupBox8->ResumeLayout(false);
			this->GroupBox8->PerformLayout();
			this->GroupBox2->ResumeLayout(false);
			this->GroupBox2->PerformLayout();
			this->grp_mpmdev2->ResumeLayout(false);
			this->grp_mpmdev2->PerformLayout();
			this->grp_mpmdev1->ResumeLayout(false);
			this->grp_mpmdev1->PerformLayout();
			this->GroupBox1->ResumeLayout(false);
			this->GroupBox1->PerformLayout();
			this->GroupBox9->ResumeLayout(false);
			this->GroupBox9->PerformLayout();
			this->GroupBox7->ResumeLayout(false);
			this->GroupBox7->PerformLayout();
			this->grp_pcu->ResumeLayout(false);
			this->grp_pcu->PerformLayout();
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void Instrument_Setting_Load(System::Object^  sender, System::EventArgs^  e) {
		// ---------------------------------------------------------------
		// Sub Form Load
		// ---------------------------------------------------------------
		int loop1;

		// ---Add in SPU resource to combbox
		for (loop1 = 0; loop1 <= SPU_Resource->GetUpperBound(0); loop1++)
			cmbpcu_dev->Items->Add(SPU_Resource[loop1]);

		// ----Add in USB resource

		for (loop1 = 0; loop1 <= USB_Resource->GetUpperBound(0); loop1++)
		{
			cmbtsl_usb->Items->Add(USB_Resource[loop1]);
			cmbpcu_usbresource->Items->Add(USB_Resource[loop1]);
		}
	}

	private: System::Void btnconnect_Click(System::Object^  sender, System::EventArgs^  e) {
		// ----------------------------------------------------------
		// Connect       
		// ----------------------------------------------------------


		// ----TSL Communication diteal

		// GPIB Communcation?
		if (rdotsl_gpib->Checked == true)
		{
			TSL_Communicater = "GPIB";
			TSL_Address = txttsl_gpibadd->Text;
			TSL_Portnumber = 0;
		}

		// TCP/IP Communciation?
		if (rdo_tsltcpip->Checked == true)
		{
			TSL_Communicater = "LAN";
			TSL_Address = txttsl_ipadd->Text;
			TSL_Portnumber = Convert::ToInt32(txttsl_lanport->Text);
		}

		// USB Communcation?
		if (rdo_tslusb->Checked == true)
		{
			TSL_Communicater = "USB";
			TSL_Address = cmbtsl_usb->SelectedIndex.ToString();
			TSL_Portnumber = 0;
		}

		// -----MPM Communcation diteal

		// Multi Device?
		if (chkmulti_dev->Checked == true)
		{
			MPM_Count = 2;

			// GPIB communcation?
			if (rdo_mpmgpib->Checked == true)
			{
				MPM_Address[0] = txtmpm_gpibadd1->Text;
				MPM_Address[1] = txtmpm_gpibadd2->Text;
				MPM_Portnumber[0] = 0;
				MPM_Portnumber[1] = 0;

				MPM_Communicater = "GPIB";
			}
			else
			{
				// TCL/IP communcation?
				MPM_Address[0] = txtmpm_ipadd1->Text;
				MPM_Address[1] = txtmpm_ipadd2->Text;
				MPM_Portnumber[0] = Convert::ToInt32(txtmpm_lanport1->Text);
				MPM_Portnumber[1] = Convert::ToInt32(txtmpm_lanport2->Text);

				MPM_Communicater = "LAN";
			}
		}
		else
		{
			MPM_Count = 1;

			// GPIB communcation?
			if (rdo_mpmgpib->Checked == true)
			{
				MPM_Address[0] = txtmpm_gpibadd1->Text;
				MPM_Address[1] = "";
				MPM_Portnumber[0] = 0;
				MPM_Portnumber[1] = 0;

				MPM_Communicater = "GPIB";
			}
			else
			{
				// TCL/IP communcation?
				MPM_Address[0] = txtmpm_ipadd1->Text;
				MPM_Address[1] = "";
				MPM_Portnumber[0] = Convert::ToInt32(txtmpm_lanport1->Text);
				MPM_Portnumber[1] = 0;

				MPM_Communicater = "LAN";
			}
		}


		// ----PCU Communication diteal

		// GPIB communcation?
		if (rdopcu_gpib->Checked == true)
		{
			PCU_Communicater = "GPIB";
			PCU_Address = txtpcu_gpibadd->Text;
		}

		// USB communcation?
		if (rdopcu_usb->Checked == true)
		{
			PCU_Communicater = "USB";
			PCU_Address = cmbpcu_usbresource->SelectedIndex.ToString();
		}

		// TCP/IP communication?
		if (rdopcu_lan->Checked == true)
		{
			PCU_Communicater = "LAN";
			PCU_Address = txtpcu_ipadd->Text;
			PCU_Portnumber = Convert::ToInt32(txtpcu_lanport->Text);
		}

		// --------- SPU Resouce
		String^ spu_id = String::Empty;


		// SPU(DAQ) use inside PCU or not
		// PCU-100 has SPU(DAQ) inside
		// PCU-110 has not SPU(DAQ) inside

		spu_id = cmbpcu_dev->Text;

		if (rdopcu100->Checked == true)
			PCU_useing_internal_DAQ = true;
		else
			PCU_useing_internal_DAQ = false;

		if (spu_id == "")
		{
			MessageBox::Show("Please enter to the SPU device resouce");
			return;
		}

		SPU_DeviveID = spu_id;
		Instrument_Setting::Close();
	}

	private: System::Void rdo570_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		//-----------------------------------------------------
		//       570 Checked
		//----------------------------------------------------

		if (rdo570->Checked == true)
		{
			rdo_tsltcpip->Enabled = true;
			rdo_tslusb->Enabled = true;
		}
		else
		{
			rdo_tslusb->Enabled = false;
			rdo_tsltcpip->Enabled = false;
			rdotsl_gpib->Checked = true;
		}
	}

	private: System::Void rdo_mpmgpib_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// --------------------------------------------------------------------
		// MPM Control GPIB
		// --------------------------------------------------------------------

		if (rdo_mpmgpib->Checked == true)
		{
			txtmpm_gpibadd1->Enabled = true;
			txtmpm_gpibadd2->Enabled = true;
			txtmpm_ipadd1->Enabled = false;
			txtmpm_ipadd2->Enabled = false;
			txtmpm_lanport1->Enabled = false;
			txtmpm_lanport2->Enabled = false;
		}
		else
		{
			txtmpm_gpibadd1->Enabled = false;
			txtmpm_gpibadd2->Enabled = false;
			txtmpm_ipadd1->Enabled = true;
			txtmpm_ipadd2->Enabled = true;
			txtmpm_lanport1->Enabled = true;
			txtmpm_lanport2->Enabled = true;
		}
	}

	private: System::Void rdo_tsltcpip_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// ------------------------------------------------------
		// TSL Control TCP/IP
		// ------------------------------------------------------

		if (rdo_tsltcpip->Checked == true)
		{
			txttsl_gpibadd->Enabled = false;
			txttsl_ipadd->Enabled = true;
			txttsl_lanport->Enabled = true;
			cmbtsl_usb->Enabled = false;
		}
	}

	private: System::Void rdotsl_gpib_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// ------------------------------------------------------
		// TSL Control GPIB
		// ------------------------------------------------------

		if (rdotsl_gpib->Checked == true)
		{
			txttsl_gpibadd->Enabled = true;
			txttsl_ipadd->Enabled = false;
			txttsl_lanport->Enabled = false;
			cmbtsl_usb->Enabled = false;
		}
	}

	private: System::Void rdo_tslusb_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// ------------------------------------------------------
		// TSL Control USB
		// ------------------------------------------------------

		if (rdo_tslusb->Checked == true)
		{
			txttsl_gpibadd->Enabled = false;
			txttsl_ipadd->Enabled = false;
			txttsl_lanport->Enabled = false;
			cmbtsl_usb->Enabled = true;
		}
	}

	private: System::Void chkmulti_dev_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		//------------------------------------------------------------------
		//          Selecet MPM Multi-Device
		//-------------------------------------------------------------------

		grp_mpmdev2->Enabled = chkmulti_dev->Checked;
	}

	private: System::Void rdopcu100_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// ------------------------------------------------------------------------
		// PCU-100 checked
		// ------------------------------------------------------------------------

		// PCU-100 checked
		if (rdopcu100->Checked == true)
		{
			rdopcu_gpib->Enabled = true;
			rdopcu_lan->Enabled = false;
			rdopcu_usb->Enabled = false;
			txtpcu_ipadd->Enabled = false;
			txtpcu_lanport->Enabled = false;
			txtpcu_gpibadd->Enabled = true;
			cmbpcu_usbresource->Enabled = false;
		}
		else
		{
			// PCU-110 Checked 
			rdopcu_gpib->Checked = true;
			rdopcu_gpib->Enabled = true;
			rdopcu_lan->Enabled = true;
			rdopcu_usb->Enabled = true;
			txtpcu_ipadd->Enabled = false;
			txtpcu_lanport->Enabled = false;
			txtpcu_gpibadd->Enabled = true;
			cmbpcu_usbresource->Enabled = false;
		}
	}

	private: System::Void rdopcu_gpib_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// -------------------------------------------------------------------
		// PCU Communcatior GPIB Checked
		// -------------------------------------------------------------------

		if (rdopcu_gpib->Checked == true)
		{
			txtpcu_gpibadd->Enabled = true;
			txtpcu_ipadd->Enabled = false;
			txtpcu_lanport->Enabled = false;
			cmbpcu_usbresource->Enabled = false;
		}
	}

	private: System::Void rdopcu_lan_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// ----------------------------------------------------------------
		// PCU communcatior TCP/IP Checked
		// ----------------------------------------------------------------

		if (rdopcu_lan->Checked == true)
		{
			txtpcu_gpibadd->Enabled = false;
			txtpcu_ipadd->Enabled = true;
			txtpcu_lanport->Enabled = true;
			cmbpcu_usbresource->Enabled = false;
		}
	}

	private: System::Void rdopcu_usb_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
		// ---------------------------------------------------------------
		// PCU Communicator USB checked
		// ---------------------------------------------------------------

		if (rdopcu_usb->Checked == true)
		{
			txtpcu_gpibadd->Enabled = false;
			txtpcu_ipadd->Enabled = false;
			txtpcu_lanport->Enabled = false;
			cmbpcu_usbresource->Enabled = true;
		}
	}

	};
}
