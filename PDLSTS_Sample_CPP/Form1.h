#pragma once
#include "Instrument_Setting.h"
namespace PDLSTS_Sample_CPP {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace Santec;
	using namespace STSProcess;
	/// <summary>
	/// Form1 摘要
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO:  在此处添加构造函数代码
			//
		}
		TSL tsl;                                               // TSL Control Class
		cli::array<MPM^>^ mpm = gcnew cli::array<MPM^>(2);                                               // MPM Control Class
		SPU spu;                                                // SPU Control Class
		PCU pcu;                                              // PCU Control Class
		PDLSTS Cal_STS;                                       // STS Calucrate Class   PDLSTS Class -> Sub class of ILSTS   
		System::Collections::Generic::List<STSDataStruct> Data_struct;                  // STS data Struct for Measure
		System::Collections::Generic::List<STSDataStruct>   Refdata_struct;                // STS data Struct for Reference
		System::Collections::Generic::List<STSDataStructForMerge>   Mergedata_struct;      // Data struct for merge  
		System::Collections::Generic::List<STSDataStruct>  Ref_monitordata_struct;        // STS Monitor data Struct for Reference
		System::Collections::Generic::List<STSMonitorStruct>   Meas_monitordata_struct;       // STS Monitor data struct for Measure
		System::Collections::Generic::List<int> Meas_rang;                           // Measurement Range 
		bool Flag_213;                                         // Exist 213 flag      T: Exist F: nothing
	internal: System::Windows::Forms::Button^  btnsavecalil;
	internal: System::Windows::Forms::CheckBox^  chkeach_ch;
	public:
		bool Flag_215;                                         // Exist 215 flag      T: Exist F: nothing 

	protected:
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	internal: System::Windows::Forms::TextBox^  txtstopwave;
	protected:
	internal: System::Windows::Forms::TextBox^  txtsaverange;
	internal: System::Windows::Forms::Label^  Label5;
	internal: System::Windows::Forms::Label^  Label4;
	internal: System::Windows::Forms::Label^  Label3;
	internal: System::Windows::Forms::Label^  Label2;
	internal: System::Windows::Forms::Label^  Label1;
	internal: System::Windows::Forms::TextBox^  txtpower;
	internal: System::Windows::Forms::ComboBox^  cmbspeed;
	internal: System::Windows::Forms::TextBox^  txtstepwave;
	internal: System::Windows::Forms::TextBox^  txtstartwave;
	internal: System::Windows::Forms::GroupBox^  GroupBox2;
	internal: System::Windows::Forms::Label^  Label7;
	internal: System::Windows::Forms::Label^  Label6;
	internal: System::Windows::Forms::CheckedListBox^  chklst_range;
	internal: System::Windows::Forms::CheckedListBox^  chklst_ch;
	internal: System::Windows::Forms::Button^  btnsaveref_rawdata;
	internal: System::Windows::Forms::Button^  btnmeas;
	internal: System::Windows::Forms::Button^  btnget_reference;
	internal: System::Windows::Forms::Button^  btnset;
	internal: System::Windows::Forms::SaveFileDialog^  SaveFileDialog1;
	internal: System::Windows::Forms::Button^  Button1;
	internal: System::Windows::Forms::Button^  btnsaveRawdata;
	internal: System::Windows::Forms::OpenFileDialog^  OpenFileDialog1;
	internal: System::Windows::Forms::GroupBox^  grp_pdlcal;
	internal: System::Windows::Forms::CheckBox^  chksavemu;
	internal: System::Windows::Forms::CheckBox^  chk2scan;
	internal: System::Windows::Forms::Label^  Label8;
	internal: System::Windows::Forms::GroupBox^  GroupBox1;

	private:
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->txtstopwave = (gcnew System::Windows::Forms::TextBox());
			this->txtsaverange = (gcnew System::Windows::Forms::TextBox());
			this->Label5 = (gcnew System::Windows::Forms::Label());
			this->Label4 = (gcnew System::Windows::Forms::Label());
			this->Label3 = (gcnew System::Windows::Forms::Label());
			this->Label2 = (gcnew System::Windows::Forms::Label());
			this->Label1 = (gcnew System::Windows::Forms::Label());
			this->txtpower = (gcnew System::Windows::Forms::TextBox());
			this->cmbspeed = (gcnew System::Windows::Forms::ComboBox());
			this->txtstepwave = (gcnew System::Windows::Forms::TextBox());
			this->txtstartwave = (gcnew System::Windows::Forms::TextBox());
			this->GroupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->Label7 = (gcnew System::Windows::Forms::Label());
			this->Label6 = (gcnew System::Windows::Forms::Label());
			this->chklst_range = (gcnew System::Windows::Forms::CheckedListBox());
			this->chklst_ch = (gcnew System::Windows::Forms::CheckedListBox());
			this->btnsaveref_rawdata = (gcnew System::Windows::Forms::Button());
			this->btnmeas = (gcnew System::Windows::Forms::Button());
			this->btnget_reference = (gcnew System::Windows::Forms::Button());
			this->btnset = (gcnew System::Windows::Forms::Button());
			this->SaveFileDialog1 = (gcnew System::Windows::Forms::SaveFileDialog());
			this->Button1 = (gcnew System::Windows::Forms::Button());
			this->btnsaveRawdata = (gcnew System::Windows::Forms::Button());
			this->OpenFileDialog1 = (gcnew System::Windows::Forms::OpenFileDialog());
			this->grp_pdlcal = (gcnew System::Windows::Forms::GroupBox());
			this->chksavemu = (gcnew System::Windows::Forms::CheckBox());
			this->chk2scan = (gcnew System::Windows::Forms::CheckBox());
			this->Label8 = (gcnew System::Windows::Forms::Label());
			this->GroupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->btnsavecalil = (gcnew System::Windows::Forms::Button());
			this->chkeach_ch = (gcnew System::Windows::Forms::CheckBox());
			this->GroupBox2->SuspendLayout();
			this->grp_pdlcal->SuspendLayout();
			this->GroupBox1->SuspendLayout();
			this->SuspendLayout();
			// 
			// txtstopwave
			// 
			this->txtstopwave->Location = System::Drawing::Point(178, 54);
			this->txtstopwave->Name = L"txtstopwave";
			this->txtstopwave->Size = System::Drawing::Size(117, 20);
			this->txtstopwave->TabIndex = 1;
			this->txtstopwave->Text = L"1600";
			// 
			// txtsaverange
			// 
			this->txtsaverange->Location = System::Drawing::Point(297, 277);
			this->txtsaverange->Name = L"txtsaverange";
			this->txtsaverange->Size = System::Drawing::Size(57, 20);
			this->txtsaverange->TabIndex = 31;
			this->txtsaverange->Text = L"1";
			// 
			// Label5
			// 
			this->Label5->AutoSize = true;
			this->Label5->Location = System::Drawing::Point(560, 37);
			this->Label5->Name = L"Label5";
			this->Label5->Size = System::Drawing::Size(87, 13);
			this->Label5->TabIndex = 9;
			this->Label5->Text = L"TSL Power(dBm)";
			// 
			// Label4
			// 
			this->Label4->AutoSize = true;
			this->Label4->Location = System::Drawing::Point(435, 37);
			this->Label4->Name = L"Label4";
			this->Label4->Size = System::Drawing::Size(113, 13);
			this->Label4->TabIndex = 8;
			this->Label4->Text = L"SweepSpeed(nm/sec)";
			// 
			// Label3
			// 
			this->Label3->AutoSize = true;
			this->Label3->Location = System::Drawing::Point(312, 38);
			this->Label3->Name = L"Label3";
			this->Label3->Size = System::Drawing::Size(107, 13);
			this->Label3->TabIndex = 7;
			this->Label3->Text = L"WavelengthStep(nm)";
			// 
			// Label2
			// 
			this->Label2->AutoSize = true;
			this->Label2->Location = System::Drawing::Point(176, 38);
			this->Label2->Name = L"Label2";
			this->Label2->Size = System::Drawing::Size(107, 13);
			this->Label2->TabIndex = 6;
			this->Label2->Text = L"StopWavelength(nm)";
			// 
			// Label1
			// 
			this->Label1->AutoSize = true;
			this->Label1->Location = System::Drawing::Point(25, 37);
			this->Label1->Name = L"Label1";
			this->Label1->Size = System::Drawing::Size(107, 13);
			this->Label1->TabIndex = 5;
			this->Label1->Text = L"StartWavelength(nm)";
			// 
			// txtpower
			// 
			this->txtpower->Location = System::Drawing::Point(562, 53);
			this->txtpower->Name = L"txtpower";
			this->txtpower->Size = System::Drawing::Size(117, 20);
			this->txtpower->TabIndex = 4;
			this->txtpower->Text = L"10";
			// 
			// cmbspeed
			// 
			this->cmbspeed->FormattingEnabled = true;
			this->cmbspeed->Location = System::Drawing::Point(437, 53);
			this->cmbspeed->Name = L"cmbspeed";
			this->cmbspeed->Size = System::Drawing::Size(102, 21);
			this->cmbspeed->TabIndex = 3;
			// 
			// txtstepwave
			// 
			this->txtstepwave->Location = System::Drawing::Point(314, 54);
			this->txtstepwave->Name = L"txtstepwave";
			this->txtstepwave->Size = System::Drawing::Size(100, 20);
			this->txtstepwave->TabIndex = 2;
			this->txtstepwave->Text = L"0.01";
			// 
			// txtstartwave
			// 
			this->txtstartwave->Location = System::Drawing::Point(27, 54);
			this->txtstartwave->Name = L"txtstartwave";
			this->txtstartwave->Size = System::Drawing::Size(117, 20);
			this->txtstartwave->TabIndex = 0;
			this->txtstartwave->Text = L"1500";
			// 
			// GroupBox2
			// 
			this->GroupBox2->Controls->Add(this->Label7);
			this->GroupBox2->Controls->Add(this->Label6);
			this->GroupBox2->Controls->Add(this->chklst_range);
			this->GroupBox2->Controls->Add(this->chklst_ch);
			this->GroupBox2->Location = System::Drawing::Point(47, 142);
			this->GroupBox2->Name = L"GroupBox2";
			this->GroupBox2->Size = System::Drawing::Size(332, 89);
			this->GroupBox2->TabIndex = 23;
			this->GroupBox2->TabStop = false;
			this->GroupBox2->Text = L"Measurement ch And Range";
			// 
			// Label7
			// 
			this->Label7->AutoSize = true;
			this->Label7->Location = System::Drawing::Point(176, 21);
			this->Label7->Name = L"Label7";
			this->Label7->Size = System::Drawing::Size(106, 13);
			this->Label7->TabIndex = 3;
			this->Label7->Text = L"Measurement Range";
			// 
			// Label6
			// 
			this->Label6->AutoSize = true;
			this->Label6->Location = System::Drawing::Point(10, 21);
			this->Label6->Name = L"Label6";
			this->Label6->Size = System::Drawing::Size(86, 13);
			this->Label6->TabIndex = 2;
			this->Label6->Text = L"Measurement ch";
			// 
			// chklst_range
			// 
			this->chklst_range->FormattingEnabled = true;
			this->chklst_range->Location = System::Drawing::Point(177, 37);
			this->chklst_range->Name = L"chklst_range";
			this->chklst_range->Size = System::Drawing::Size(118, 34);
			this->chklst_range->TabIndex = 1;
			// 
			// chklst_ch
			// 
			this->chklst_ch->FormattingEnabled = true;
			this->chklst_ch->Location = System::Drawing::Point(12, 37);
			this->chklst_ch->Name = L"chklst_ch";
			this->chklst_ch->Size = System::Drawing::Size(135, 34);
			this->chklst_ch->TabIndex = 0;
			// 
			// btnsaveref_rawdata
			// 
			this->btnsaveref_rawdata->Location = System::Drawing::Point(47, 263);
			this->btnsaveref_rawdata->Name = L"btnsaveref_rawdata";
			this->btnsaveref_rawdata->Size = System::Drawing::Size(125, 35);
			this->btnsaveref_rawdata->TabIndex = 27;
			this->btnsaveref_rawdata->Text = L"Save Reference Rawdata";
			this->btnsaveref_rawdata->UseVisualStyleBackColor = true;
			this->btnsaveref_rawdata->Click += gcnew System::EventHandler(this, &Form1::btnsaveref_rawdata_Click);
			// 
			// btnmeas
			// 
			this->btnmeas->Location = System::Drawing::Point(639, 263);
			this->btnmeas->Name = L"btnmeas";
			this->btnmeas->Size = System::Drawing::Size(106, 35);
			this->btnmeas->TabIndex = 26;
			this->btnmeas->Text = L"Measurement";
			this->btnmeas->UseVisualStyleBackColor = true;
			this->btnmeas->Click += gcnew System::EventHandler(this, &Form1::btnmeas_Click);
			// 
			// btnget_reference
			// 
			this->btnget_reference->Location = System::Drawing::Point(519, 263);
			this->btnget_reference->Name = L"btnget_reference";
			this->btnget_reference->Size = System::Drawing::Size(102, 35);
			this->btnget_reference->TabIndex = 25;
			this->btnget_reference->Text = L"Reference";
			this->btnget_reference->UseVisualStyleBackColor = true;
			this->btnget_reference->Click += gcnew System::EventHandler(this, &Form1::btnget_reference_Click);
			// 
			// btnset
			// 
			this->btnset->Location = System::Drawing::Point(414, 263);
			this->btnset->Name = L"btnset";
			this->btnset->Size = System::Drawing::Size(83, 35);
			this->btnset->TabIndex = 24;
			this->btnset->Text = L"SET";
			this->btnset->UseVisualStyleBackColor = true;
			this->btnset->Click += gcnew System::EventHandler(this, &Form1::btnset_Click);
			// 
			// Button1
			// 
			this->Button1->Location = System::Drawing::Point(47, 308);
			this->Button1->Name = L"Button1";
			this->Button1->Size = System::Drawing::Size(125, 35);
			this->Button1->TabIndex = 29;
			this->Button1->Text = L"Read Reference Data";
			this->Button1->UseVisualStyleBackColor = true;
			this->Button1->Click += gcnew System::EventHandler(this, &Form1::Button1_Click);
			// 
			// btnsaveRawdata
			// 
			this->btnsaveRawdata->Location = System::Drawing::Point(187, 263);
			this->btnsaveRawdata->Name = L"btnsaveRawdata";
			this->btnsaveRawdata->Size = System::Drawing::Size(104, 35);
			this->btnsaveRawdata->TabIndex = 28;
			this->btnsaveRawdata->Text = L"Save Rawdata";
			this->btnsaveRawdata->UseVisualStyleBackColor = true;
			this->btnsaveRawdata->Click += gcnew System::EventHandler(this, &Form1::btnsaveRawdata_Click);
			// 
			// OpenFileDialog1
			// 
			this->OpenFileDialog1->FileName = L"OpenFileDialog1";
			// 
			// grp_pdlcal
			// 
			this->grp_pdlcal->Controls->Add(this->chksavemu);
			this->grp_pdlcal->Controls->Add(this->chk2scan);
			this->grp_pdlcal->Location = System::Drawing::Point(412, 142);
			this->grp_pdlcal->Name = L"grp_pdlcal";
			this->grp_pdlcal->Size = System::Drawing::Size(343, 88);
			this->grp_pdlcal->TabIndex = 30;
			this->grp_pdlcal->TabStop = false;
			this->grp_pdlcal->Text = L"PDL Calcurate";
			// 
			// chksavemu
			// 
			this->chksavemu->AutoSize = true;
			this->chksavemu->Location = System::Drawing::Point(18, 54);
			this->chksavemu->Name = L"chksavemu";
			this->chksavemu->Size = System::Drawing::Size(155, 17);
			this->chksavemu->TabIndex = 1;
			this->chksavemu->Text = L"Save of mulluer parametere";
			this->chksavemu->UseVisualStyleBackColor = true;
			// 
			// chk2scan
			// 
			this->chk2scan->AutoSize = true;
			this->chk2scan->Location = System::Drawing::Point(18, 21);
			this->chk2scan->Name = L"chk2scan";
			this->chk2scan->Size = System::Drawing::Size(150, 17);
			this->chk2scan->TabIndex = 0;
			this->chk2scan->Text = L"2SOP for low power range";
			this->chk2scan->UseVisualStyleBackColor = true;
			// 
			// Label8
			// 
			this->Label8->AutoSize = true;
			this->Label8->Location = System::Drawing::Point(295, 261);
			this->Label8->Name = L"Label8";
			this->Label8->Size = System::Drawing::Size(39, 13);
			this->Label8->TabIndex = 32;
			this->Label8->Text = L"Range";
			// 
			// GroupBox1
			// 
			this->GroupBox1->Controls->Add(this->Label5);
			this->GroupBox1->Controls->Add(this->Label4);
			this->GroupBox1->Controls->Add(this->Label3);
			this->GroupBox1->Controls->Add(this->Label2);
			this->GroupBox1->Controls->Add(this->Label1);
			this->GroupBox1->Controls->Add(this->txtpower);
			this->GroupBox1->Controls->Add(this->cmbspeed);
			this->GroupBox1->Controls->Add(this->txtstepwave);
			this->GroupBox1->Controls->Add(this->txtstopwave);
			this->GroupBox1->Controls->Add(this->txtstartwave);
			this->GroupBox1->Location = System::Drawing::Point(47, 24);
			this->GroupBox1->Name = L"GroupBox1";
			this->GroupBox1->Size = System::Drawing::Size(709, 101);
			this->GroupBox1->TabIndex = 22;
			this->GroupBox1->TabStop = false;
			this->GroupBox1->Text = L"Sweep Setting";
			// 
			// btnsavecalil
			// 
			this->btnsavecalil->Location = System::Drawing::Point(187, 308);
			this->btnsavecalil->Name = L"btnsavecalil";
			this->btnsavecalil->Size = System::Drawing::Size(106, 35);
			this->btnsavecalil->TabIndex = 33;
			this->btnsavecalil->Text = L"Save Calucrated IL";
			this->btnsavecalil->UseVisualStyleBackColor = true;
			this->btnsavecalil->Click += gcnew System::EventHandler(this, &Form1::btnsavecalil_Click);
			// 
			// chkeach_ch
			// 
			this->chkeach_ch->AutoSize = true;
			this->chkeach_ch->Location = System::Drawing::Point(414, 308);
			this->chkeach_ch->Name = L"chkeach_ch";
			this->chkeach_ch->Size = System::Drawing::Size(145, 17);
			this->chkeach_ch->TabIndex = 34;
			this->chkeach_ch->Text = L"each channel individually";
			this->chkeach_ch->UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(802, 366);
			this->Controls->Add(this->chkeach_ch);
			this->Controls->Add(this->btnsavecalil);
			this->Controls->Add(this->txtsaverange);
			this->Controls->Add(this->GroupBox2);
			this->Controls->Add(this->btnsaveref_rawdata);
			this->Controls->Add(this->btnmeas);
			this->Controls->Add(this->btnget_reference);
			this->Controls->Add(this->btnset);
			this->Controls->Add(this->Button1);
			this->Controls->Add(this->btnsaveRawdata);
			this->Controls->Add(this->grp_pdlcal);
			this->Controls->Add(this->Label8);
			this->Controls->Add(this->GroupBox1);
			this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
			this->Name = L"Form1";
			this->Text = L"STS PDL sample software";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->GroupBox2->ResumeLayout(false);
			this->GroupBox2->PerformLayout();
			this->grp_pdlcal->ResumeLayout(false);
			this->grp_pdlcal->PerformLayout();
			this->GroupBox1->ResumeLayout(false);
			this->GroupBox1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
		// -------------------------------------------------------------------------
		// Form Load    (MainForm)
		// -------------------------------------------------------------------------
		cli::array<String^> ^spudev;                        // spu device name
		int errorcode;                                // errorcode 
		cli::array<String^> ^usb_resource;                     // usb communication resource

		// ----Check Connction of spu deviece
		errorcode = spu.Get_Device_ID(spudev);
		if (errorcode != 0)
		{
			Show_Inst_Error(errorcode);
			Environment::Exit(0);
		}


		// ----Check usb resource
		usb_resource = Santec::Communication::MainCommunication::Get_USB_Resouce();


		// ------show Setting Form
		Instrument_Setting^ set_form = gcnew Instrument_Setting();

		set_form->Owner = this;
		set_form->SPU_Resource = spudev;
		set_form->USB_Resource = usb_resource;

		set_form->ShowDialog();

		// -------Apply to communication parametere from Instrument setting form---
		Santec::Communication::CommunicationMethod tsl_communcation_method;            // communication method for tsl
		Santec::Communication::CommunicationMethod mpm_communcation_method;            // communication method for mpm    
		Santec::Communication::CommunicationMethod pcu_communcation_method;            // communication methode for pcu


		 // ----tsl　Communication setting -------------------------------------
		if (set_form->TSL_Communicater == "GPIB")
		{
			// GPIB
			tsl_communcation_method = Santec::Communication::CommunicationMethod::GPIB;
			tsl.Terminator = CommunicationTerminator::CrLf;
			tsl.GPIBAddress = Convert::ToInt32(set_form->TSL_Address);
			tsl.GPIBBoard = 0;
			tsl.GPIBConnectType = Santec::Communication::GPIBConnectType::NI4882;
		}
		else if (set_form->TSL_Communicater == "LAN")
		{
			// LAN
			tsl_communcation_method = Santec::Communication::CommunicationMethod::TCPIP;
			tsl.Terminator = CommunicationTerminator::Cr;
			tsl.IPAddress = set_form->TSL_Address;
			tsl.Port = set_form->TSL_Portnumber;
		}
		else
		{
			// USB 
			tsl_communcation_method = Santec::Communication::CommunicationMethod::USB;
			tsl.DeviceID = Convert::ToUInt32(set_form->TSL_Address);
			tsl.Terminator = CommunicationTerminator::Cr;
		}


		// ---mpm Communication setting --------------------------------------
		int loop1;
		int mpmcount;                     // mpm count


		if (set_form->MPM_Communicater == "GPIB")
			// GPIB
			mpm_communcation_method = Santec::Communication::CommunicationMethod::GPIB;
		else
			// LAN
			mpm_communcation_method = Santec::Communication::CommunicationMethod::TCPIP;

		mpmcount = set_form->MPM_Count;
		mpm = gcnew cli::array<MPM^>(mpmcount);
		for (loop1 = 0; loop1 <= mpmcount - 1; loop1++)
		{
			mpm[loop1] = gcnew MPM();

			if (set_form->MPM_Communicater == "GPIB")
				mpm[loop1]->GPIBAddress = Convert::ToInt32(set_form->MPM_Address[loop1]);
			else
			{
				mpm[loop1]->IPAddress = set_form->MPM_Address[loop1];
				mpm[loop1]->Port = set_form->MPM_Portnumber[loop1];
			}

			// muximum logging data reading time = 11s
			mpm[loop1]->TimeOut = 11000;
		}


		// -------pcu Communcation setting-------------------------
		if (set_form->PCU_Communicater == "GPIB")
		{
			// GPIB
			pcu_communcation_method = Santec::Communication::CommunicationMethod::GPIB;
			pcu.GPIBAddress = Convert::ToInt32(set_form->PCU_Address);
			pcu.GPIBBoard = 0;
			pcu.Terminator = CommunicationTerminator::CrLf;
		}
		else if (set_form->PCU_Communicater == "LAN"
			)
		{
			// LAN
			pcu_communcation_method = Santec::Communication::CommunicationMethod::TCPIP;
			pcu.IPAddress = set_form->PCU_Address;
			pcu.Port = set_form->PCU_Portnumber;
		}
		else
		{
			// USB
			pcu_communcation_method = Santec::Communication::CommunicationMethod::USB;
			pcu.DeviceID = Convert::ToUInt32(set_form->PCU_Address);
			pcu.Terminator = CommunicationTerminator::Cr;                     // pcu USB Command follow only "Cr"  terminator
		}


		// ----Using pcu inside DAQ or not
		if (set_form->PCU_useing_internal_DAQ == true)
			// inside 
			pcu.DeviceName = set_form->SPU_DeviveID;


		// ------spu Communcation Setting 
		spu.DeviceName = set_form->SPU_DeviveID;


		// -----Connect----------------------------------------------------------- 
		errorcode = tsl.Connect(tsl_communcation_method);                        // tsl

		if (errorcode != 0)
		{
			MessageBox::Show("tsl can't connect.Please check connection.");
			System::Environment::Exit(0);
		}


		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)                                            // mpm
		{
			errorcode = mpm[loop1]->Connect(mpm_communcation_method);

			if (errorcode != 0)
			{
				MessageBox::Show("mpm Can't connect. Please check connection.");
				Environment::Exit(0);
			}
		}

		String ^ans = String::Empty;
		errorcode = spu.Connect(ans);

		if (errorcode != 0)
		{
			MessageBox::Show("spu Can't connect. Please check connection.");
			Environment::Exit(0);
		}


		errorcode = pcu.Connect(pcu_communcation_method);                        // pcu
		if (errorcode != 0)
		{
			MessageBox::Show("pcu can't connect.Please check connection.");
			Environment::Exit(0);
		}

		// -----Check Module information--------------------------------------
		errorcode = Check_Module_Information();

		if (errorcode != 0)
		{
			MessageBox::Show("System can't use mpm-215 togeter other module");
			Environment::Exit(0);
		}

		// -----------Reflect instrument parameter to Form-------------------
		Referect_EnableCh_for_form();                // mpm Eanble ch
		Referect_EnableRange_for_form();             // mpm selectable range
		Add_TSL_Sweep_Speed();                       // tsl Sweep speed(only tsl-570)

	}

	private: void Referect_EnableCh_for_form()
	{
		// ------------------------------------------------
		// Reflect mpm ch 
		// ------------------------------------------------
		int loop1;
		int loop2;
		cli::array<bool>^enable_slot;
		String^ slot_type;

		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
		{
			// get insert module count with "mpm Information" class 
			enable_slot = mpm[loop1]->Information->ModuleEnable;

			// modeule loop(Maximum 5 slot)
			for (loop2 = 0; loop2 <= 4; loop2++)
			{
				if (enable_slot[loop2] == true)
				{
					// get module type with "mpm Information" class 
					slot_type = mpm[loop1]->Information->ModuleType[loop2];

					if (slot_type != "MPM-212")
					{
						chklst_ch->Items->Add("mpm" + System::Convert::ToString(loop1 + 1) + " Slot" + System::Convert::ToString(loop2) + " Ch1");
						chklst_ch->Items->Add("mpm" + System::Convert::ToString(loop1 + 1) + " Slot" + System::Convert::ToString(loop2) + " Ch2");
						chklst_ch->Items->Add("mpm" + System::Convert::ToString(loop1 + 1) + " Slot" + System::Convert::ToString(loop2) + " Ch3");
						chklst_ch->Items->Add("mpm" + System::Convert::ToString(loop1 + 1) + " Slot" + System::Convert::ToString(loop2) + " Ch4");
					}
					else
					{
						chklst_ch->Items->Add("mpm" + System::Convert::ToString(loop1 + 1) + " Slot" + System::Convert::ToString(loop2) + " Ch1");
						chklst_ch->Items->Add("mpm" + System::Convert::ToString(loop1 + 1) + " Slot" + System::Convert::ToString(loop2) + " Ch2");
					}
				}
			}
		}
	}

	private: int Add_TSL_Sweep_Speed()
	{
		// ---------------------------------------------------------
		// Add in selectable sweep speed to speed combbox
		// this function can use only tsl-570
		// ----------------------------------------------------------
		int inst_error;                       // instullment error
		cli::array<double>^sweep_table;          // table


												 // Get Sweep speed tabele
												 // Except for tsl-570 "Device Error" occurre when call this function.
		inst_error = tsl.Get_Sweep_Speed_table(sweep_table);

		if (inst_error != 0 & inst_error != System::Convert::ToInt32(ExceptionCode::DeviceError))
			return inst_error;


		// -----Add in combbox when tsl-570
		int loop1;

		if (inst_error != Convert::ToInt32(ExceptionCode::DeviceError))
		{
			for (loop1 = 0; loop1 <= sweep_table->GetUpperBound(0); loop1++)

				cmbspeed->Items->Add(sweep_table[loop1]);
		}
		return 0;
	}

	private:void Referect_EnableRange_for_form()
	{
		// -----------------------------------------------------
		// Refelect mpm Range
		// -------------------------------------------------------


		// mpm-213 can use just 1 to 4 range
		if (Flag_213 == true)
		{
			chklst_range->Items->Add("Range1");
			chklst_range->Items->Add("Range2");
			chklst_range->Items->Add("Range3");
			chklst_range->Items->Add("Range4");
		}
		else
		{
			chklst_range->Items->Add("Range1");
			chklst_range->Items->Add("Range2");
			chklst_range->Items->Add("Range3");
			chklst_range->Items->Add("Range4");
			chklst_range->Items->Add("Range5");
		}

		// mpm-215 can't select range
		if (Flag_215 == true)
			chklst_range->Enabled = false;
	}

	private:int Check_Module_Information()
	{
		// ------------------------------------------------------------
		// check Module information inside system
		// ------------------------------------------------------------
		int loop1;
		int loop2;
		int counter_215;                           // 215 counter 

												   // mpm device loop
		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
		{
			// Slot loop
			for (loop2 = 0; loop2 <= 4; loop2++)
			{
				// Enable Slot
				if (mpm[loop1]->Information->ModuleEnable[loop2] == true)
				{

					// Check mpm-215 insert
					if (mpm[loop1]->Information->ModuleType[loop2] == "MPM-215")
					{
						Flag_215 = true;
						counter_215 = counter_215 + 1;
					}

					// Check mpm-213 insert
					if (mpm[loop1]->Information->ModuleType[loop2] == "MPM-213")
						Flag_213 = true;
				}
			}
		}
		// Check mpm-215 count & Module total count
		// STS system can't use 215 together other module.
		int enable_module_count;                      // enable module count

		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
			enable_module_count = mpm[loop1]->Information->NumberofModule + enable_module_count;// total module count

		if (Flag_215 == true)
		{
			if (enable_module_count != counter_215)
				return -1;
		}
		return 0;
	}

	private: void Show_Inst_Error(int errordata)
	{
		// ------------------------------------
		// Show error code
		// 显示错误编号
		// ------------------------------------

		cli::array<String^>^ errorstring = Enum::GetNames(ExceptionCode::typeid);
		cli::array<int>^ errorvale = static_cast<cli::array<int>^>(Enum::GetValues(ExceptionCode::typeid));
		int loop1;
		for (loop1 = 0; loop1 <= errorvale->Length - 1; loop1++)
		{
			if (errorvale[loop1] == errordata)
			{
				MessageBox::Show(errorstring[loop1]);
				break;
			}
		}
	}

	private:void Show_STS_Error(int errordata)
	{
		// ------------------------------------
		// Show error code for STS
		// ------------------------------------
		cli::array<String^>^ errorstring = Enum::GetNames(ErrorCode::typeid);
		cli::array<int>^ errorvale = static_cast<cli::array<int>^>(Enum::GetValues(ErrorCode::typeid));
		int loop1;
		for (loop1 = 0; loop1 <= errorvale->Length - 1; loop1++)
		{
			if (errorvale[loop1] == errordata)
			{
				MessageBox::Show(errorstring[loop1]);
				break;
			}
		}
	}

	private: System::Void btnset_Click(System::Object^  sender, System::EventArgs^  e) {
		// -------------------------------------------------------------------------
		// Set Parameter
		// --------------------------------------------------------------------------
		double startwave;             // Startwavelength(nm)
		double stopwave;              // Stopwavelength(nm)
		double set_pow;               // Power(dBm)
		double wavestep;              // wavelenthg step(nm)
		double speed;                 // Sweep Speed (nm/sec)
		int inst_error;           // instullment error



		startwave = double::Parse(txtstartwave->Text);
		stopwave = double::Parse(txtstopwave->Text);
		wavestep = double::Parse(txtstepwave->Text);
		speed = double::Parse(cmbspeed->Text);
		set_pow = double::Parse(txtpower->Text);



		// ---------tsl Setting--------------------------------------------------- 
		double tsl_acctualstep;          // tsl output trigger step(nm)


														// set Power
		inst_error = tsl.Set_APC_Power_dBm(set_pow);
		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}

		// set Sweep parameter
		inst_error = tsl.Set_Sweep_Parameter_for_STS(startwave, stopwave, speed, wavestep, tsl_acctualstep);
		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}

		// wavelength -> start wavelength
		inst_error = tsl.Set_Wavelength(startwave);
		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}

		// busy check
		inst_error = tsl.TSL_Busy_Check(3000);
		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}

		// ------mpm setting ------------------------------------------------------------
		int loop1;

		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
		{
			// Sweep parameter setting 
			inst_error = mpm[loop1]->Set_Logging_Paremeter_for_STS(startwave, stopwave, wavestep, speed, Santec::MPM::Measurement_Mode::Freerun);
			if (inst_error != 0)
			{
				Show_Inst_Error(inst_error);
				return;
			}
		}

		// ---spu setting ----------------------------------------------------------------
		double averaging_time;

		// Get mpm averaging time
		inst_error = mpm[0]->Get_Averaging_Time(averaging_time);

		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}

		// parameter setting 
		inst_error = spu.Set_Sampling_Parameter(startwave, stopwave, speed, tsl_acctualstep);

		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}

		// mpm averageing time-> spu
		spu.AveragingTime = averaging_time;

		// -----pcu setting --------------------------------------------------------------
		// pcu range adjust must set to be after tsl Power set.
		inst_error = pcu.Range_Adjust();

		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}

		// -------------set STS Process parameter-----------------------------------------
		int sts_error;            // sts process class error

								  // Data Clear 
		sts_error = Cal_STS.Clear_Measdata();

		if (sts_error != 0)
		{
			Show_STS_Error(sts_error);
			return;
		}

		sts_error = Cal_STS.Clear_Refdata();

		if (sts_error != 0)
		{
			Show_STS_Error(sts_error);
			return;
		}

		// Setting for STS rescaling mode
		sts_error = Cal_STS.Set_Rescaling_Setting(RescalingMode::Freerun_SPU, averaging_time, true);

		if (sts_error != 0)
		{
			Show_STS_Error(sts_error);
			return;
		}

		// Make acctual wavelength step table
		sts_error = Cal_STS.Make_Sweep_Wavelength_Table(startwave, stopwave, tsl_acctualstep);

		if (sts_error != 0)
		{
			Show_STS_Error(sts_error);
			return;
		}

		// Make rescaling wavelength step table
		sts_error = Cal_STS.Make_Target_Wavelength_Table(startwave, stopwave, wavestep);

		if (sts_error != 0)
		{
			Show_STS_Error(sts_error);
			return;
		}

		// --------prepare data struct & hold instrument condition-------------------------
		if (chkeach_ch->Checked == true)
		{
			Prepare_dataST_Each();
		}
		else
		{
			Prepare_dataST();
		}

		MessageBox::Show("Completed.");
	}

	private:void Prepare_dataST()
	{
		// ----------------------------------------------
		// Prepar STS data struct
		// -----------------------------------------------
		// -----------------------------------------------
		int rangecout;                        // number of range
		int chcount;                          // number of ch 
		int chloop;                            // loop count1
		int rangeloop;                            // loop count2
		int soploop;                       //sop loop
		String ^text_st = String::Empty;            // text String 
		cli::array<String^>^split_st;            // split string array

											   // -----Clear List data
		Meas_rang.Clear();
		Data_struct.Clear();
		Refdata_struct.Clear();
		Ref_monitordata_struct.Clear();
		Meas_monitordata_struct.Clear();
		Mergedata_struct.Clear();

		rangecout = chklst_range->CheckedItems->Count;   // number of range
		chcount = chklst_ch->CheckedItems->Count;        // number of channel
		if (Flag_215 == true)
			//If mom215 range must be set 1
			Meas_rang.Add(1);
		else 
		{
			if (rangecout == 0 | chcount == 0)
			{
				MessageBox::Show("Please check measurement parameters.");
				return;
			}

			// hold  data of range number  
			for (int loop1 = 0; loop1 <= chklst_range->Items->Count - 1; loop1++)
			{
				if (chklst_range->GetItemChecked(loop1) == true)
					Meas_rang.Add(loop1 + 1);
			}
		}

		// Add in measurement condition of Data structure 
		int device_number;                        // mpm device number
		int slot_number;                           // mpm Slot number
		int ch_number;                            // mpm channel number
		STSDataStruct set_struct;                     // Data struct for STS data hold
		int sweep_count = 1;                         // Sweep counter 
		int sopcount;

		// for measurement power data
		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{
				// ch parameter
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;
				slot_number = Convert::ToInt32(split_st[1]->Substring(4));
				ch_number = Convert::ToInt32(split_st[2]->Substring(2));

				set_struct.MPMNumber = device_number;
				set_struct.SlotNumber = slot_number;
				set_struct.ChannelNumber = ch_number;

				// --------set struct for "STSdatastruct"---------------- 
				for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)        // range loop
				{

					// Lower range & if checked "2SOP for low power range"
					if (chk2scan->Checked == true & rangeloop != 0)
						sopcount = 2;                                 // 2Scan
					else
						sopcount = 4;// 4Scan

					set_struct.RangeNumber = Meas_rang[rangeloop];

					for (soploop = 0; soploop <= sopcount - 1; soploop++)
					{
						set_struct.SOP = soploop;
						set_struct.SweepCount = sweep_count;
						sweep_count = sweep_count + 1;

						Data_struct.Add(set_struct);
					}
				}
				sweep_count = 1;
			}
		}
		// for reference power data & mergedata 
		STSDataStructForMerge set_merge_struct;
		sweep_count = 1;
		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{
				// ch parameter
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;
				slot_number = Convert::ToInt32(split_st[1]->Substring(4));
				ch_number = Convert::ToInt32(split_st[2]->Substring(2));
				// for data
				set_struct.MPMNumber = device_number;
				set_struct.SlotNumber = slot_number;
				set_struct.ChannelNumber = ch_number;
				set_struct.RangeNumber = 1;
				// for merge
				set_merge_struct.MPMNumber = device_number;
				set_merge_struct.SlotNumber = slot_number;
				set_merge_struct.ChannelNumber = ch_number;
				sopcount = 4;

				// SOP loop
				for (soploop = 0; soploop <= sopcount - 1; soploop++)
				{
					set_struct.SOP = soploop;
					set_struct.SweepCount = sweep_count;

					set_merge_struct.SOP = soploop;

					sweep_count = sweep_count + 1;
					Refdata_struct.Add(set_struct);                      // Add Data for Reference Struct
					Mergedata_struct.Add(set_merge_struct);              // Add data for Merge Struct
				}
				sweep_count = 1;
			}
		}

		// for measurement monitor data
		STSMonitorStruct set_monitor_struct;
		sweep_count = 1;

		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{
				// ch parameter
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;

				set_monitor_struct.MPMNumber = device_number;

				for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)
				{
					if (chk2scan->Checked == true & rangeloop != 0)
						sopcount = 2;
					else
						sopcount = 4;

					for (soploop = 0; soploop <= sopcount - 1; soploop++)
					{
						set_monitor_struct.SOP = soploop;
						set_monitor_struct.SweepCount = sweep_count;
						// Add
						Meas_monitordata_struct.Add(set_monitor_struct);
						sweep_count = sweep_count + 1;
					}
				}
				break;
			}
		}

		// for reference monitor data
		sweep_count = 1;
		STSDataStruct set_ref_monitor_struct;

		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;
				slot_number = Convert::ToInt32(split_st[1]->Substring(4));
				ch_number = Convert::ToInt32(split_st[2]->Substring(2));

				set_ref_monitor_struct.MPMNumber = device_number;
				set_ref_monitor_struct.SlotNumber = slot_number;
				set_ref_monitor_struct.ChannelNumber = ch_number;
				set_ref_monitor_struct.RangeNumber = 1;

				for (soploop = 0; soploop <= 3; soploop++)
				{
					set_ref_monitor_struct.SOP = soploop;
					set_ref_monitor_struct.SweepCount = soploop + 1;

					Ref_monitordata_struct.Add(set_ref_monitor_struct);
				}
				break;
			}
		}
	}

	private :void Prepare_dataST_Each()
	{
		// ----------------------------------------------
		// Prepar STS data struct
		// -----------------------------------------------
		int rangecout;                        // number of range
		int chcount;                          // number of ch 
		int chloop;                           // channel loop
		int rangeloop;                        // range loop
		int soploop;                          // sop loop
		String ^text_st = String::Empty;            // text String 
		cli::array<String^>^split_st;            // split string array

											   // -----Clear List data
		Meas_rang.Clear();
		Data_struct.Clear();
		Refdata_struct.Clear();
		Ref_monitordata_struct.Clear();
		Meas_monitordata_struct.Clear();
		Mergedata_struct.Clear();


		rangecout = chklst_range->CheckedItems->Count;   // number of range
		chcount = chklst_ch->CheckedItems->Count;        // number of channel
		if (Flag_215 == true)
			// If mom215 range must be set 1
			Meas_rang.Add(1);
		else
		{
			if (rangecout == 0 | chcount == 0)
			{
				MessageBox::Show("Please check measurement parameters.");
				return;
			}
			// hold  data of range number  
			for (int loop1 = 0; loop1 <= chklst_range->Items->Count - 1; loop1++)
			{
				if (chklst_range->GetItemChecked(loop1) == true)
					Meas_rang.Add(loop1 + 1);
			}
		}

		// Add in measurement condition of Data structure 
		int sopcount;
		int device_number;
		int slot_number;
		int ch_number;
		STSDataStruct set_struct;
		int sweep_count = 1;

		// for measurement power data
		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{

				// ch parameter
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;
				slot_number = Convert::ToInt32(split_st[1]->Substring(4));
				ch_number = Convert::ToInt32(split_st[2]->Substring(2));


				set_struct.MPMNumber = device_number;
				set_struct.SlotNumber = slot_number;
				set_struct.ChannelNumber = ch_number;

				for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)
				{
					if (chk2scan->Checked == true & rangeloop != 0)
						sopcount = 2;
					else
						sopcount = 4;

					set_struct.RangeNumber = Meas_rang[rangeloop];

					for (soploop = 0; soploop <= sopcount - 1; soploop++)
					{
						set_struct.SOP = soploop;
						set_struct.SweepCount = sweep_count;
						sweep_count = sweep_count + 1;

						Data_struct.Add(set_struct);
					}
				}
				sweep_count = 1;
			}
		}

		// for reference power data & reference monitor data
		STSDataStruct set_ref_monitor_struct ;
		sweep_count = 1;
		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{
				// ch parameter
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;
				slot_number = Convert::ToInt32(split_st[1]->Substring(4));
				ch_number = Convert::ToInt32(split_st[2]->Substring(2));

				// for data
				set_struct.MPMNumber = device_number;
				set_struct.SlotNumber = slot_number;
				set_struct.ChannelNumber = ch_number;
				set_struct.RangeNumber = 1;

				// for monitor
				set_ref_monitor_struct.MPMNumber = device_number;
				set_ref_monitor_struct.SlotNumber = slot_number;
				set_ref_monitor_struct.ChannelNumber = ch_number;
				set_ref_monitor_struct.RangeNumber = 1;

				sopcount = 4;

				// SOP loop
				for (soploop = 0; soploop <= sopcount - 1; soploop++)
				{
					set_struct.SOP = soploop;
					set_struct.SweepCount = sweep_count;

					set_ref_monitor_struct.SOP = soploop;
					set_ref_monitor_struct.SweepCount = sweep_count;

					sweep_count = sweep_count + 1;
					Refdata_struct.Add(set_struct);                      // Add Data for Reference Struct
					Ref_monitordata_struct.Add(set_ref_monitor_struct);  // Add monitor data for Reference Struct
				}
			}
		}

		// for mergedata 
		STSDataStructForMerge set_merge_struct ;
		sweep_count = 1;
		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{

				// ch parameter
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;
				slot_number = Convert::ToInt32(split_st[1]->Substring(4));
				ch_number = Convert::ToInt32(split_st[2]->Substring(2));

				set_merge_struct.MPMNumber = device_number;
				set_merge_struct.SlotNumber = slot_number;
				set_merge_struct.ChannelNumber = ch_number;
				sopcount = 4;

				// SOP loop
				for (soploop = 0; soploop <= sopcount - 1; soploop++)
				{
					set_merge_struct.SOP = soploop;

					sweep_count = sweep_count + 1;
					Mergedata_struct.Add(set_merge_struct);              // Add data for Merge Struct
				}
				sweep_count = 1;
			}
		}

		// for measurement monitor data
		STSMonitorStruct set_monitor_struct;
		sweep_count = 1;

		for (chloop = 0; chloop <= chklst_ch->Items->Count - 1; chloop++)
		{
			if (chklst_ch->GetItemChecked(chloop) == true)
			{
				text_st = chklst_ch->Items[chloop]->ToString();
				split_st = text_st->Split(' ');
				device_number = Convert::ToInt32(split_st[0]->Substring(3)) - 1;

				set_monitor_struct.MPMNumber = device_number;

				for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)
				{
					if (chk2scan->Checked == true & rangeloop != 0)
						sopcount = 2;
					else
						sopcount = 4;

					for (soploop = 0; soploop <= sopcount - 1; soploop++)
					{
						set_monitor_struct.SOP = soploop;
						set_monitor_struct.SweepCount = sweep_count;
						// Add
						Meas_monitordata_struct.Add(set_monitor_struct);
						sweep_count = sweep_count + 1;
					}
				}
				break;
			}
		}
	}

	private: System::Void btnget_reference_Click(System::Object^  sender, System::EventArgs^  e) {
		// ------------------------------------------------------------------------------
		// Get Reference
		// ------------------------------------------------------------------------------
		int inst_error;                       // Instullment error
		bool inst_flag = new bool();
		int loop1;

		// MPM setting for selected 1st range
		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
		{
			// set Range for mpm
			inst_error = mpm[loop1]->Set_Range(Meas_rang[0]);
			if ((inst_error != 0))
			{
				Show_Inst_Error(inst_error);
				return;
			}
		}
		// Move to start wavelength  with Sweep Start method.
		inst_error = tsl.Sweep_Start();
		if (inst_error != 0)
			Show_Inst_Error(inst_error);

		if (chkeach_ch->Checked)
			// Reference measurement one channel at a time
			inst_error = Each_channel_reference(inst_flag);
		else
			inst_error = All_channel_reference( inst_flag);

		if (inst_error != 0)
		{
			if (inst_error == -9999)
				MessageBox::Show("MPM Trigger receive error! Please check trigger cable connection.");
			else if (inst_flag == true)
				Show_Inst_Error(inst_error);             // Instullment error
			else
				Show_STS_Error(inst_error);// Processing error
			return;
		}

		inst_error = tsl.Sweep_Stop();
		if (inst_error != 0)
			Show_Inst_Error(inst_error);
		MessageBox::Show("Completed.");
	}
			 private :int All_channel_reference( bool %inst_flag)
			 {

				 // ------------------------------------------------------------------------------
				 // Get Reference
				 // ------------------------------------------------------------------------------
				 int inst_error;                       // Instullment error
				 int loop1;
				 PCU::SOP_Stauts setting_SOP ;               // Setting SOP 

				 // SOP Loop
				 // SOP must to set for V -> H-> 45-> RC
				 for (loop1 = 0; loop1 <= 3; loop1++)
				 {
					 switch (loop1)
					 {
					 case 0:
					 {
						 setting_SOP = PCU::SOP_Stauts::LVP;   // LVP(0)
						 break;
					 }

					 case 1:
					 {
						 setting_SOP = PCU::SOP_Stauts::LHP;   // LHP(1)
						 break;
					 }

					 case 2:
					 {
						 setting_SOP = PCU::SOP_Stauts::LP45;  // LP45(2)
						 break;
					 }

					 case 3:
					 {
						 setting_SOP = PCU::SOP_Stauts::RCP;   // RCP(3)
						 break;
					 }
					 }

					 // Setting SOP 
					 inst_error = pcu.Set_SOP_Stauts(setting_SOP);

					 if ((inst_error != 0))
					 {
						 inst_flag = true;
						 return inst_error;
					 }

					 // Sweep 
					 inst_error = Sweep_Process();

					 if (inst_error != 0)
					 {
						 inst_flag = true;
						 return inst_error;
					 }

					 // Move to start wavelength  with Sweep Start method.
					 inst_error = tsl.Sweep_Start();
					 if (inst_error != 0)
					 {
						 inst_flag = true;
						 return inst_error;
					 }


					 // get logging data & add in STSProcess class

					 inst_error = Get_reference_samplingdata( inst_flag, setting_SOP);

					 if (inst_error != 0)
						 return inst_error;
				 }


				 // ------Reference data rescaling 
				 int process_error;
				 process_error = Cal_STS.Cal_RefData_Rescaling();

				 if (process_error != 0)
				 {
					 inst_flag = false;
					 return process_error;
				 }

				 return 0;
			 }

			 private :int Each_channel_reference( bool %inst_flag)
			 {

				 // ------------------------------------------------------------------------------
				 // Get Reference
				 // ------------------------------------------------------------------------------
				 int inst_error;                       // Instullment error
				 PCU::SOP_Stauts setting_SOP ;               // Setting SOP 


				 for each(STSDataStruct item in Refdata_struct)
				 {

					 // SOP must to set for V -> H-> 45-> RC
					 switch (item.SOP)
					 {
					 case 0:
					 {
						 MessageBox::Show("Connect fiber to MPM" + item.MPMNumber + 1 + "_Slot" + item.SlotNumber + "_Ch" + item.ChannelNumber + ".");
						 setting_SOP = PCU::SOP_Stauts::LVP;   // LVP(0)
						 break;
					 }

					 case 1:
					 {
						 setting_SOP = PCU::SOP_Stauts::LHP;   // LHP(1)
						 break;
					 }

					 case 2:
					 {
						 setting_SOP = PCU::SOP_Stauts::LP45;  // LP45(2)
						 break;
					 }

					 case 3:
					 {
						 setting_SOP = PCU::SOP_Stauts::RCP;   // RCP(3)
						 break;
					 }
					 }

					 // Setting SOP 
					 inst_error = pcu.Set_SOP_Stauts(setting_SOP);

					 if ((inst_error != 0))
					 {
						 inst_flag = true;
						 return inst_error;
					 }

					 // Sweep 
					 inst_error = Sweep_Process();

					 if (inst_error != 0)
					 {
						 inst_flag = true;
						 return inst_error;
					 }


					 // Move to start wavelength  with Sweep Start method.
					 inst_error = tsl.Sweep_Start();
					 if (inst_error != 0)
					 {
						 inst_flag = true;
						 return inst_error;
					 }


					 // get logging data & add in STSProcess class
					 inst_error = Get_Each_channel_reference_samplingdata( inst_flag, item.MPMNumber, item.SlotNumber, item.ChannelNumber, setting_SOP, item.SweepCount);

					 if (inst_error != 0)
						 return inst_error;

					 // ------Reference data rescaling 
					 int process_error;
					 process_error = Cal_STS.Cal_RefData_Rescaling();

					 if (process_error != 0)
					 {
						 inst_flag = false;
						 return process_error;
					 }
				 }

				 return 0;
			 }

			 private :int Get_Each_channel_reference_samplingdata( bool %inst_flag, int currentMPMNumber, int currentSlotNumber, int currentChannelNumber, PCU::SOP_Stauts currentSOP, int currentSweepCount)
			 {
				 // ---------------------------------------------------------------
				 // Get logging reference data & add in 
				 // ---------------------------------------------------------------
				 int inst_error;                        // Instullment error
				 cli::array<float>^ logg_data = nullptr;             // mpm Logging data
				 int cal_error;                         // process error


														// ----Load　Reference MPM data & add  in data for STS Process Class for each channel
				 for each(STSDataStruct item in Refdata_struct)
				 {
					 if ((item.MPMNumber != currentMPMNumber | item.SlotNumber != currentSlotNumber | item.ChannelNumber != currentChannelNumber | item.SOP != (int)currentSOP))
						 continue;

					 // Read corresponded  MPM channel data
					 inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber,  logg_data);

					 if (inst_error != 0)
					 {
						 inst_flag = true;
						 return inst_error;
					 }

					 // Add in to MPM reference data to STS Process Class
					 cal_error = Cal_STS.Add_Ref_MPMData_CH(logg_data, item);

					 if (cal_error != 0)
					 {
						 inst_flag = false;
						 return cal_error;
					 }
				 }

				 // ----Load　Reference Monitor data 
				 cli::array<float>^ triggerdata = nullptr;
				 cli::array<float>^ monitordata = nullptr;

				 inst_error = spu.Get_Sampling_Rawdata(triggerdata,  monitordata);

				 if (inst_error != 0)
				 {
					 inst_flag = true;
					 return inst_error;
				 }

				 // -- Add reference monitor data associated with parameters of the same SOP
				 for each(STSDataStruct monitor_item in Ref_monitordata_struct)
				 {
					 if ((monitor_item.SlotNumber == currentSlotNumber & monitor_item.ChannelNumber == currentChannelNumber & monitor_item.SOP == (int)currentSOP & monitor_item.SweepCount == currentSweepCount))
					 {
						 cal_error = Cal_STS.Add_Ref_MonitorData(triggerdata, monitordata, monitor_item);

						 if (cal_error != 0)
						 {
							 inst_flag = false;
							 return cal_error;
						 }

						 break;
					 }
				 }


				 return 0;
			 }

	private: int Get_reference_samplingdata(bool inst_flag, PCU::SOP_Stauts currentSOP)
	{
		// ---------------------------------------------------------------
		// Get logging reference data & add in 
		// ---------------------------------------------------------------
		int inst_error;                        // Instullment error
		cli::array<float>^ logg_data = nullptr;             // mpm Logging data
		int cal_error;                         // process error


											   // ----Load　Reference mpm data & add  in data for STS Process Class for each channel
		for each(STSDataStruct item in Refdata_struct)
		{
			if (item.SOP != (int)currentSOP)
				continue;

			// Read corresponded  mpm channel data
			inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber, logg_data);

			if (inst_error != 0)
			{
				inst_flag = true;
				return inst_error;
			}

			// Add in to mpm reference data to STS Process Class
			cal_error = Cal_STS.Add_Ref_MPMData_CH(logg_data, item);

			if (cal_error != 0)
			{
				inst_flag = false;
				return cal_error;
			}
		}

		// ----Load　Reference Monitor data 
		cli::array<float>^ triggerdata = nullptr;
		cli::array<float>^ monitordata = nullptr;

		inst_error = spu.Get_Sampling_Rawdata(triggerdata, monitordata);

		if (inst_error != 0)
		{
			inst_flag = true;
			return inst_error;
		}

		// -- Add reference monitor data associated with parameters of the same SOP
		for each(STSDataStruct monitor_item in Ref_monitordata_struct)
		{
			if (monitor_item.SOP == (int)currentSOP)
			{
				cal_error = Cal_STS.Add_Ref_MonitorData(triggerdata, monitordata, monitor_item);

				if (cal_error != 0)
				{
					inst_flag = false;
					return cal_error;
				}

				break;
			}
		}

		return 0;
	}

	private:int Get_MPM_Loggdata(int deveice, int slot, int ch, cli::array<float>^ %data)
	{
		// ---------------------------------------------------------------
		// Get mpm Logg data
		// --------------------------------------------------------------
		int inst_error;

		inst_error = mpm[deveice]->Get_Each_Channel_Logdata(slot, ch, data);
		return inst_error;
	}

	private: int Sweep_Process()
	{
		// ------------------------------------------------------------
		// Sweep Process
		// ------------------------------------------------------------
		int inst_error;               // Instullment error
		int loop1;                    // loop count 

		// mpm sampling start 
		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
		{
			inst_error = mpm[loop1]->Logging_Start();
			if (inst_error != 0)
				return inst_error;
		}


		// tsl waiting for start status 
		inst_error = tsl.Waiting_For_Sweep_Status(5000, TSL::Sweep_Status::WaitingforTrigger);

		if (inst_error != 0)
		{
			// ----error handling -> mpm Logging Stop
			for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
				mpm[loop1]->Logging_Stop();

			return inst_error;
		}


		// spu sampling start
		inst_error = spu.Sampling_Start(false);
		if (inst_error != 0)
		{
			// ----error handling -> mpm Logging Stop
			for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
				mpm[loop1]->Logging_Stop();

			return inst_error;
		}

		// tsl issue software trigger
		inst_error = tsl.Set_Software_Trigger();

		if (inst_error != 0)
		{
			// ----error handling -> mpm Logging Stop
			for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
				mpm[loop1]->Logging_Stop();
			return inst_error;
		}


		// spu waiting for sampling 
		inst_error = spu.Waiting_for_sampling();

		if (inst_error != 0)
		{
			// ----error handling -> mpm Logging Stop
			for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
				mpm[loop1]->Logging_Stop();
			return inst_error;
		}


		int mpm_stauts;
		int mpm_count;
		double timeout = 2000;                  // mpm Logging Status timeout(2000msec) after the spu sampling completed.
		System::Diagnostics::Stopwatch st;
		bool mpm_complet_flag = true;
		bool isSweeping = true;

		st.Start();                                    // timer start for mpm logging status timeout.   

													   // mpm waiting for sampling 
		do
		{
			for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
			{
				inst_error = mpm[loop1]->Get_Logging_Status(mpm_stauts, mpm_count);
				if (inst_error != 0)
					return inst_error;
				if (mpm_stauts == 1)
				{
					isSweeping = false;
					break;
				}
				if (st.ElapsedMilliseconds >= 2000)
				{
					//Logging time out(time out = 2sec after from spu sampling  completed.)
					mpm_complet_flag = false;
					isSweeping = false;
					break;
				}
			}
		} while (isSweeping);


		// mpm sampling stop
		for (loop1 = 0; loop1 <= mpm->GetUpperBound(0); loop1++)
		{
			inst_error = mpm[loop1]->Logging_Stop();
			if (inst_error != 0)
				return inst_error;
		}

		// tsl Waiting for standby
		inst_error = tsl.Waiting_For_Sweep_Status(5000, TSL::Sweep_Status::Standby);

		if (inst_error != 0)
			return inst_error;


		if (mpm_complet_flag == false)
			return -9999;


		return 0;
	}

	private: System::Void btnmeas_Click(System::Object^  sender, System::EventArgs^  e) {
		// -------------------------------------------------------------------------
		// Mesurement Process
		// -------------------------------------------------------------------------
		int loop1;                        // loop Count 
		int loop2;                        // loop count2     
		int inst_error;                   // instllment error   
		bool inst_flag = new bool();                    // instrment error flag
		int soploop;                      // SOP loop count 
		PCU::SOP_Stauts setSOP;                // setting SOP
		int sweepcounter;                 // Sweep counter 

		Cal_STS.Clear_Measdata();

		// Move to start wavelength  with Sweep Start method.
		inst_error = tsl.Sweep_Start();

		if (inst_error != 0)
			Show_Inst_Error(inst_error);

		// ---------Measurement-------------------------------------
		// Rang Loop
		for (loop1 = 0; loop1 <= Meas_rang.Count - 1; loop1++)
		{
			// mpm range Setting 
			for (loop2 = 0; loop2 <= mpm->GetUpperBound(0); loop2++)
			{
				inst_error = mpm[loop2]->Set_Range(Meas_rang[loop1]);

				if (inst_error != 0)
				{
					Show_Inst_Error(inst_error);
					return;
				}
			}

			// Lower range & if checked "2SOP for low power range"
			if (chk2scan->Checked == true & loop1 != 0)
				soploop = 2;
			else
				soploop = 4;

			// SOP loop
			for (loop2 = 0; loop2 <= soploop - 1; loop2++)
			{
				switch (loop2)
				{
				case 0:
				{
					setSOP = PCU::SOP_Stauts::LVP;
					break;
				}

				case 1:
				{
					setSOP = PCU::SOP_Stauts::LHP;
					break;
				}

				case 2:
				{
					setSOP = PCU::SOP_Stauts::LP45;
					break;
				}

				case 3:
				{
					setSOP = PCU::SOP_Stauts::RCP;
					break;
				}
				}

				// SOP Setting 
				inst_error = pcu.Set_SOP_Stauts(setSOP);
				if (inst_error != 0)
				{
					Show_Inst_Error(inst_error);
					return;
				}

				// Sweep process
				inst_error = Sweep_Process();
				if (inst_error != 0 & inst_error != -9999)
				{
					Show_Inst_Error(inst_error);
					return;
				}

				if (inst_error == -9999)
				{
					MessageBox::Show("mpm Trigger receive error! Please check trigger cable connection.");
					return;
				}

				// tsl Next　SweepStart
				inst_error = tsl.Sweep_Start();

				if (inst_error != 0)
				{
					Show_Inst_Error(inst_error);
					return;
				}

				// get loggging data & Add in STS Process class
				inst_error = Get_measurement_samplingdata(sweepcounter + 1, setSOP, inst_flag);

				if (inst_error != 0)
				{
					if (inst_flag == true)
						Show_Inst_Error(inst_error);
					else
						Show_STS_Error(inst_error);

					return;
				}
				sweepcounter = sweepcounter + 1;
			}
		}

		// ---STS data Processing--------------------------------------------- 

		int process_error;                        // STS　Process error

		// Rescaling
		process_error = Cal_STS.Cal_MeasData_Rescaling();

		if (process_error != 0)
		{
			Show_STS_Error(process_error);
			return;
		}


		Module_Type merge_type;
		if (Flag_215 == false)
			merge_type = Module_Type::MPM_215;
		else if (Flag_213 == true)
			merge_type = Module_Type::MPM_213;
		else
			merge_type = Module_Type::MPM_211;

		// Process ranges merge
		process_error = Cal_STS.Cal_IL_Merge(merge_type);


		// tsl Sweep Stop
		inst_error = tsl.Sweep_Stop();

		// -----PDL Calcurete process-------------------------------------------
		process_error = PDL_Process_AndSave();

		MessageBox::Show("Completed.");
	}

	private: int Get_measurement_samplingdata(int sweepcount, PCU::SOP_Stauts currentSOP, bool inst_flag)
	{
		// ---------------------------------------------------------------
		// Get logging measurement data & add in 
		// ---------------------------------------------------------------
		int inst_error;                        // Instullment error
		cli::array<float>^logg_data = nullptr;              // mpm Logging data
		int cal_error;                         // process error

		// ----Load　measurement mpm data & add  in data for STS Process Class for each channel
		for each(STSDataStruct item in Data_struct)
		{
			if ((item.SweepCount != sweepcount) | (item.SOP != (int)currentSOP))
				continue;

			// Load corresponded mpm channel data
			inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber, logg_data);

			if (inst_error != 0)
			{
				inst_flag = true;
				return inst_error;
			}

			// Add in to mpm reference data to STS Process Class
			cal_error = Cal_STS.Add_Meas_MPMData_CH(logg_data, item);

			if (cal_error != 0)
			{
				inst_flag = false;
				return cal_error;
			}
		}

		// Load monitor data
		cli::array<float>^ triggerdata = nullptr; // trigger timming data
		cli::array<float>^ monitordata = nullptr;// monitor data

		inst_error = spu.Get_Sampling_Rawdata(triggerdata, monitordata);

		if (inst_error != 0)
		{
			inst_flag = true;
			return inst_error;
		}

		// -- Add measurement monitor data associated with parameters of the same SOP & sweep count
		for each(STSMonitorStruct monitor_item in Meas_monitordata_struct)
		{
			if ((monitor_item.SweepCount == sweepcount) & (monitor_item.SOP == (int)currentSOP))
			{
				cal_error = Cal_STS.Add_Meas_MonitorData(triggerdata, monitordata, monitor_item);

				if (cal_error != 0)
				{
					inst_flag = false;
					return cal_error;
				}
				break;
			}
		}

		return 0;
	}

	private:int PDL_Process_AndSave()
	{
		// -----------------------------------------------------
		// STS PDL Process
		// -----------------------------------------------------
		cli::array<double>^ wavetable = nullptr;                  // Target　Wavelength table
		int inst_error;                            // instrument error
		cli::array<float, 3>^ correctionSOP;        // Correnction SOP data for wavelength  (wavelengthindex,SOP,Sop vector position)
		int cal_error;                             // Process class error

		// ----------------------------------------------------------------------------
		// 1. Get target wavelength table from Process class
		// 2. pass wavelength table & recive calcureted correction SOP array(3D)
		// 3. pass correction SOP array for Prosecc class
		// 4. Get processed IL data from Prosecc class
		// 5. Calculate PDL & IL & ILmax & ILmin from 4.data 
		// --------------------------------------------------------------------------
		// 1
		cal_error = Cal_STS.Get_Target_Wavelength_Table(wavetable);
		if (cal_error != 0)
		{
			Show_STS_Error(cal_error);
			return cal_error;
		}

		// 2
		System::Windows::Forms::Application::DoEvents();
		inst_error = pcu.Cal_All_SOP_Parametar(wavetable, correctionSOP);

		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return cal_error;
		}


		// 3 
		cal_error = Cal_STS.Add_PCU_CalData(correctionSOP);
		if (cal_error != 0)
		{
			Show_STS_Error(cal_error);
			return cal_error;
		}

		// 4           
		int loop1;
		int loop2;
		int loop3;
		cli::array<float>^ ildata = nullptr;
		STSDataStructForMerge get_struct;
		STSDataStructForMerge befor_struct;
		//STSDataStruct items;
		cli::array<float, 2>^ SOPIL = nullptr;
		cli::array<float>^ calPDL = nullptr;
		cli::array<float>^ calIL = nullptr;
		cli::array<float>^ calILmax = nullptr;
		cli::array<float>^ calILmin = nullptr;
		String^ fpath = String::Empty;
		System::IO::StreamWriter^ writer;
		String^ writestr = String::Empty;
		SOPIL = gcnew cli::array<float, 2>(4, wavetable->Length);

		for each(STSDataStructForMerge item in Mergedata_struct)
		{
			if ((item.MPMNumber == befor_struct.MPMNumber) & (item.SlotNumber == befor_struct.SlotNumber) & (item.ChannelNumber == befor_struct.ChannelNumber))
				continue;
			// SOP　loop
			for (loop1 = 0; loop1 <= 3; loop1++)
			{
				get_struct.MPMNumber = item.MPMNumber;
				get_struct.SlotNumber = item.SlotNumber;
				get_struct.ChannelNumber = item.ChannelNumber;
				get_struct.SOP = loop1;

				cal_error = Cal_STS.Get_IL_Merge_Data(ildata, get_struct);

				if (cal_error != 0)
				{
					Show_STS_Error(cal_error);
					return cal_error;
				}

				// 1Ddata ->2D data array
				for (loop2 = 0; loop2 <= ildata->GetUpperBound(0); loop2++)
					SOPIL[loop1, loop2] = ildata[loop2];
			}

			befor_struct = get_struct;
			// 5.Calcurate of PDL 
			cal_error = Cal_STS.Cal_PDL(SOPIL, calPDL, calIL, calILmax, calILmin);

			if (cal_error != 0)
			{
				Show_STS_Error(cal_error);
				return cal_error;
			}

			// '--------Save data for each ch---------------------------------
			SaveFileDialog1->Title = "Device" + System::Convert::ToString(get_struct.MPMNumber+1) + "Slot" + System::Convert::ToString(get_struct.SlotNumber) + "Ch" + System::Convert::ToString(get_struct.ChannelNumber) + "PDL data save path";
			SaveFileDialog1->Filter = "csv file(*.csv)|*.csv";
			SaveFileDialog1->ShowDialog();

			fpath = SaveFileDialog1->FileName;
			writer = gcnew System::IO::StreamWriter(fpath, false, System::Text::Encoding::GetEncoding("UTF-8"));
			// hedder

			writestr = "Wavelength(nm),IL(dB),PDL(dB),ILMax(dB),ILMin(dB)";

			writer->WriteLine(writestr);

			for (loop3 = 0; loop3 <= wavetable->GetUpperBound(0); loop3++)
			{
				writestr = Convert::ToString(wavetable[loop3]) + "," + Convert::ToString(calIL[loop3]) + "," + Convert::ToString(calPDL[loop3]) + "," + Convert::ToString(calILmax[loop3]) + "," + Convert::ToString(calILmin[loop3]);
				writer->WriteLine(writestr);
			}

			writer->Close();

			// -----Save Mueller data ??--------------------------------------

			if (chksavemu->Checked == true)
			{
				cli::array<double>^ m11 = nullptr;
				cli::array<double>^ m12 = nullptr;
				cli::array<double>^ m13 = nullptr;
				cli::array<double>^ m14 = nullptr;


				// ------------------------------------------
				// m11 = (H+V)/2
				// m12 = (H-V)/2
				// m13 = 45-m11
				// m14 = RC-m11
				// -------------------------------------------
				// Load mueller parameter
				cal_error = Cal_STS.Get_Mueller_Raw_Data(m11, m12, m13, m14);

				if (cal_error != 0)
				{
					Show_STS_Error(cal_error);
					return cal_error;
				}

				// file save
				SaveFileDialog1->Title = "Device" + System::Convert::ToString(get_struct.MPMNumber) + "Slot" + System::Convert::ToString(get_struct.SlotNumber) + "Ch" + System::Convert::ToString(get_struct.ChannelNumber) + "Mueller data save path";
				SaveFileDialog1->Filter = "csv file(*.csv)|*.csv";
				SaveFileDialog1->ShowDialog();

				fpath = SaveFileDialog1->FileName;

				writer = gcnew System::IO::StreamWriter(fpath, false, System::Text::Encoding::GetEncoding("UTF-8"));
				// hedder

				writestr = "Wavelength(nm),m11(mW),m12(mW),m13(mW),m14(mW)";

				writer->WriteLine(writestr);

				for (loop3 = 0; loop3 <= wavetable->GetUpperBound(0); loop3++)
				{
					writestr = Convert::ToString(wavetable[loop3]) + "," + Convert::ToString(m11[loop3]) + "," + Convert::ToString(m12[loop3]) + "," + Convert::ToString(m13[loop3]) + "," + Convert::ToString(m14[loop3]);
					writer->WriteLine(writestr);
				}
				writer->Close();
			}
		}
		return 0;
	}

	private: System::Void btnsaveref_rawdata_Click(System::Object^  sender, System::EventArgs^  e) {
		// ---------------------------------------------------------------------------
		// Save reference Raw data
		// ---------------------------------------------------------------------------
		int loop1;                        // loop count1   
		int loop2;                        // loop count2
		int loop3;                        // loop count3
		int process_error;                // process class error
		cli::array<double>^ wavetable = nullptr;         // wavelength table
		cli::array<float>^ powdata = nullptr;           // powerdata  rescaled    
		cli::array<float>^ monitordata = nullptr;       // monitordata rescaled 
		cli::array<cli::array<float>^>^ lstpowdata;     // Power data list 
		cli::array<cli::array<float>^>^ lstmonitordata;     // monitor data list 

		// ---- Get reference Raw data (after the rescaling)

		// Get Target wavelengt table
		process_error = Cal_STS.Get_Target_Wavelength_Table(wavetable);

		if (process_error != 0)
		{
			Show_STS_Error(process_error);
			return;
		}

		// -------Load Each SOP data & Save
		String ^fpath = String::Empty;                  // file path 
		String ^hedder = String::Empty;                 // file hedder 
		String ^write_str = String::Empty;              // write string 
		String ^sop_string = String::Empty;             // SOP String 

		System::IO::StreamWriter ^writer;

		// Save each SOP reference data files.
		for (loop1 = 0; loop1 <= 3; loop1++)
		{
			hedder = "";
			lstpowdata = gcnew cli::array<cli::array<float>^>(Refdata_struct.Count/4);
			lstmonitordata = gcnew cli::array<cli::array<float>^>(Ref_monitordata_struct.Count/4);

			switch (loop1)
			{
			case 0:
			{
				sop_string = "Vartical";
				break;
			}

			case 1:
			{
				sop_string = "Horizontal";
				break;
			}

			case 2:
			{
				sop_string = "45°Linear";
				break;
			}

			case 3:
			{
				sop_string = "Right-handed circle";
				break;
			}
			}

			SaveFileDialog1->Title = "Reference Raw data" + sop_string;
			SaveFileDialog1->Filter = "csv file(*.csv)|*.csv";
			SaveFileDialog1->ShowDialog();
			fpath = SaveFileDialog1->FileName;

			writer = gcnew System::IO::StreamWriter(fpath, false, System::Text::Encoding::GetEncoding("UTF-8"));

			hedder = "Wavelength(nm)";
			loop2 = 0;
			// Load matched SOP raw data form Processing class
			//--for power data & hedder
			for each(STSDataStruct item in Refdata_struct)
			{
				if (item.SOP != loop1)
					continue;
				powdata = gcnew cli::array<float>(0);
				// monitor data is 1 data for each sweep. It can be overwrite.
				process_error = Cal_STS.Get_Ref_Power_Rawdata(item, powdata);
				if (process_error != 0)
				{
					Show_STS_Error(process_error);
					return;
				}

				lstpowdata->SetValue(powdata, loop2);
				loop2++;
				hedder = hedder + ",MPM" + Convert::ToString(item.MPMNumber+1) + "Slot" + Convert::ToString(item.SlotNumber) + "Ch" + Convert::ToString(item.ChannelNumber);
			}               
			if (chkeach_ch->Checked)
			{
				for each(STSDataStruct item in Refdata_struct)
				{
					if (item.SOP != loop1)
						continue;
					hedder = hedder + ",Monitor_MPM" + Convert::ToString(item.MPMNumber + 1) + "Slot" + Convert::ToString(item.SlotNumber) + "Ch" + Convert::ToString(item.ChannelNumber);
				}
			}
			else
				hedder = hedder + ",Monitor";

			writer->WriteLine(hedder);
			// --for monitor data

			STSDataStruct get_struct ;                 // struct of get
			STSDataStruct befor_struct;           // befor struct
			loop2 = 0;

			for each(STSDataStruct item in Ref_monitordata_struct)
			{
				if (chkeach_ch->Checked)
				{
					if ((item.MPMNumber == befor_struct.MPMNumber) & (item.SlotNumber == befor_struct.SlotNumber) & (item.ChannelNumber == befor_struct.ChannelNumber) | item.SOP != loop1)
						continue;
				}
				else if (item.SOP != loop1)
					continue;
				monitordata = gcnew cli::array<float>(0);

				process_error = Cal_STS.Get_Ref_Monitor_Rawdata(item,  monitordata);

				if (process_error != 0)
				{
					Show_STS_Error(process_error);
					return;
				}

				get_struct.MPMNumber = item.MPMNumber;
				get_struct.SlotNumber = item.SlotNumber;
				get_struct.ChannelNumber = item.ChannelNumber;
				get_struct.SOP = item.SOP;

				lstmonitordata->SetValue(monitordata, loop2);
				loop2++;
				befor_struct = get_struct;
			}

			// data write 
			for (loop2 = 0; loop2 <= wavetable->GetUpperBound(0); loop2++)
			{
				// wavelength data
				write_str = Convert::ToString(wavetable[loop2]);

				// Power data
				for (loop3 = 0; loop3 <= lstpowdata->Length - 1; loop3++)
					write_str = write_str + "," + lstpowdata[loop3][loop2];


				// monitordata
				for (int loop4 = 0; loop4 <= lstmonitordata->Length - 1; loop4++)
					write_str = write_str + "," + lstmonitordata[loop4][loop2];

				writer->WriteLine(write_str);
			}

			writer->Close();
		}
		MessageBox::Show("Completed.");
	}

	private: System::Void btnsaveRawdata_Click(System::Object^  sender, System::EventArgs^  e) {
		// -------------------------------------------------------------------------
		// Save measurement raw data for designated Range
		// -------------------------------------------------------------------------
		int loop1;                                        // loop1
		int loop2;                                        // loop2
		int loop3;                                        // loop3
		cli::array<double> ^wavelength_table = nullptr;                  // Wavelength table
		cli::array<float> ^monitordata = nullptr;                       // monitor data array
		cli::array<float> ^powerdata = nullptr;                         // Power data array
		int errorcode;                                    // Errorcode
		cli::array<cli::array<float>^>^ lstpower;                       // Power list 
		int rangenumber;                                  // save range number

		// -- Get Wavelength table
		errorcode = Cal_STS.Get_Target_Wavelength_Table(wavelength_table);

		if (errorcode != 0)
		{
			Show_STS_Error(errorcode);      // designated range
			return;
		}

		// ---check to range number 1st  or not & data exist
		bool first_rangeflag = new bool();
		bool exist_flag = false;

		rangenumber = Convert::ToInt32(txtsaverange->Text);

		for each(auto item in Data_struct)
		{
			if (item.RangeNumber > rangenumber)
				first_rangeflag = true;
			// exist or not 
			if (item.RangeNumber == rangenumber)
				exist_flag = true;
		}

		if (exist_flag == false)
		{
			MessageBox::Show("Range data is not exist.");
			return;
		}

		String ^fpath = String::Empty;              // File　path
		System::IO::StreamWriter^ writer;            // Writer 
		String ^write_string = String::Empty;
		String ^hedder = String::Empty;
		int sopcount;
		String ^sop_string = String::Empty;
		int sweepcount;                      //sweepcount

		// low range & 2scan 
		if (first_rangeflag == false & chk2scan->Checked == true)
			sopcount = 1;                            // 2Scan data
		else
			sopcount = 3;// 4Scan data

						 // ----Save designated range measurement raw data  for each SOP---------------------------
		for (loop1 = 0; loop1 <= sopcount; loop1++)
		{
			hedder = "";
			lstpower = gcnew cli::array<cli::array<float>^>(chklst_ch->CheckedItems->Count);

			switch (loop1)
			{
			case 0:
			{
				sop_string = "Vartical";
				break;
			}

			case 1:
			{
				sop_string = "Horizontal";
				break;
			}

			case 2:
			{
				sop_string = "45°Linear";
				break;
			}

			case 3:
			{
				sop_string = "Right-handed circle";
				break;
			}
			}
			//check sweep count　→長いから関数化する
			sweepcount = check_sweepcount(rangenumber, loop1);

			SaveFileDialog1->Title = "Save Range" + Convert::ToString(rangenumber) + "_" + sop_string + " SOP data";
			SaveFileDialog1->Filter = "csv file(*.csv)|*.csv";
			SaveFileDialog1->ShowDialog();

			fpath = SaveFileDialog1->FileName;

			writer = gcnew System::IO::StreamWriter(fpath, false, System::Text::Encoding::GetEncoding("UTF-8"));
			hedder = "Wavelength(nm)";
			loop2 = 0;

			// sarch for match  data from "STSDataStruct"---------------------------------
			//-for power data
			for each(STSDataStruct item in Data_struct)
			{
				if ((item.SOP != loop1) | (item.RangeNumber != rangenumber))
					continue;
				powerdata = gcnew cli::array<float>(0);
				// Load measurement raw data
				errorcode = Cal_STS.Get_Meas_Power_Rawdata(item, powerdata);

				if (errorcode != 0)
				{
					Show_STS_Error(errorcode);
					return;
				}

				lstpower->SetValue(powerdata, loop2);
				loop2++;
				hedder = hedder + "," + "mpm" + Convert::ToString(item.MPMNumber+1) + "Slot" + Convert::ToString(item.SlotNumber) + "Ch" + Convert::ToString(item.ChannelNumber);
			}

			hedder = hedder + ",Monitordata";
			writer->WriteLine(hedder);

			// --for monitor data
			for each(STSMonitorStruct item in Meas_monitordata_struct)
			{
				if (item.SOP != loop1 || item.SweepCount != sweepcount)
					continue;

				errorcode = Cal_STS.Get_Meas_Monitor_Rawdata(item, monitordata);

				if (errorcode != 0)
				{
					Show_STS_Error(errorcode);
					return;
				}
			}
			// Write data
			for (loop2 = 0; loop2 <= wavelength_table->GetUpperBound(0); loop2++)
			{
				write_string = Convert::ToString(wavelength_table[loop2]);

				for (loop3 = 0; loop3 <= lstpower->Length - 1; loop3++)
					write_string = write_string + "," + lstpower[loop3][loop2];

				write_string = write_string + "," + monitordata[loop2];

				writer->WriteLine(write_string);
			}
			writer->Close();
		}

		MessageBox::Show("Completed.");
	}

	private: int check_sweepcount(int rangenumber, int sopcount)
	{
		// ---------------------------------------------------------------------------
		// Return Sweep count for range and SOP status
		// ----------------------------------------------------------------------------
		int loop1;
		int sweepcount;

		for (loop1 = 0; loop1 <= Meas_rang.Count - 1; loop1++)
		{
			if (Meas_rang[loop1] == rangenumber)
			{
				switch (loop1)
				{
				case 0:
				{
					// 1st range
					sweepcount = sopcount + 1;
					return sweepcount;
				}

				case 1:
				{
					// 2nd rangge
					sweepcount = 4 + sopcount + 1;
					return sweepcount;
				}

				case 2:
				{
					// 3rd range
					if (chk2scan->Checked == true)
						sweepcount = 6 + sopcount + 1;
					else
						sweepcount = 8 + sopcount + 1;
					return sweepcount;
				}

				case 3:
				{
					// 4th range
					if (chk2scan->Checked == true)
						sweepcount = 8 + sopcount + 1;
					else
						sweepcount = 12 + sopcount + 1;
					return sweepcount;
				}

				case 4:
				{
					// 5th range
					if (chk2scan->Checked == true)
						sweepcount = 10 + sopcount + 1;
					else
						sweepcount = 16 + sopcount + 1;

					return sopcount;
				}
				}
			}
		}
		// falut
		return 0;
	}

	private: System::Void Button1_Click(System::Object^  sender, System::EventArgs^  e) {
		// -----------------------------------------------------------------------------
		// Reference Data Read
		// This function must use after "SET" 
		// -----------------------------------------------------------------------------
		String ^fpath = String::Empty;// filepath
		System::IO::StreamReader ^reader;// data reader 

		int sop_loop;                             // SOP loop
		String ^sop_str = String::Empty;                // SOP String 

													  // -------Reference file　Read 
		for (sop_loop = 0; sop_loop <= 3; sop_loop++)
		{
			switch (sop_loop)
			{
			case 0:
			{
				sop_str = "Vartical";
				break;
			}

			case 1:
			{
				sop_str = "Horizontal";
				break;
			}

			case 2:
			{
				sop_str = "45°Linear";
				break;
			}

			case 3:
			{
				sop_str = "Right-handed circle";
				break;
			}
			}

			OpenFileDialog1->Title = sop_str + " Reference Data";
			OpenFileDialog1->ShowDialog();
			fpath = OpenFileDialog1->FileName;

			reader = gcnew System::IO::StreamReader(fpath);

			String ^read_st = String::Empty;                            // Read String 
			cli::array<String^> ^split_st = nullptr;                              // split strin array

																   // hedder Read 
			read_st = reader->ReadLine();
			read_st = read_st->Trim();
			split_st = read_st->Split(',');


			int ch_count ;                    // file data ch count 
			int loop1;                                            // Loop count1
			String ^chk_str = String::Empty;                            // check string
			int mpm_number;                                       // mpm number
			int slot_number;                                      // Slot number
			int ch_number;                                        // ch number 

			if (chkeach_ch->Checked)
			{
				//Reference measurement one channel at a time
				ch_count = (split_st->Length - 1) / 2;
			}
			else
			{
				ch_count = split_st->Length- 2;
			}

			 // Check data cout 
			if (ch_count != chklst_ch->CheckedItems->Count)
			{
				MessageBox::Show("Reference data mismatch.Please selecet right data.");
				reader->Close();
				return;
			}

			// -----Check parameter & make reference data struct 
			STSDataStruct refdata_strunct;                        // Data struct for reference
			System::Collections::Generic::List<STSDataStruct> lst_refdata_struct;        // Data struct for reference List    
			bool match_flag = false;                           // match flag


			for (loop1 = 1; loop1 <= ch_count; loop1++)
			{
				// mpm device number 
				chk_str = split_st[loop1]->Substring(3, 1);
				mpm_number = Convert::ToInt32(chk_str)-1;

				// mpm Slot number 
				chk_str = split_st[loop1]->Substring(8, 1);
				slot_number = Convert::ToInt32(chk_str);

				// mpm Ch number 
				chk_str = split_st[loop1]->Substring(11, 1);
				ch_number = Convert::ToInt32(chk_str);


				// Check exsist data in data struct 
				for each(STSDataStruct item in Refdata_struct)
				{
					if (item.MPMNumber == mpm_number & item.SlotNumber == slot_number & item.ChannelNumber == ch_number & item.SOP == sop_loop)
					{
						match_flag = true;
						break;
					}
				}

				if (match_flag == false)
				{
					MessageBox::Show("Reference data mismatch.Please selecet right data.");
					reader->Close();
					return;
				}

				// Add reference data struct 
				refdata_strunct.MPMNumber = mpm_number;
				refdata_strunct.SlotNumber = slot_number;
				refdata_strunct.ChannelNumber = ch_number;
				refdata_strunct.RangeNumber = 1;
				refdata_strunct.SweepCount = sop_loop + 1;
				refdata_strunct.SOP = sop_loop;

				lst_refdata_struct.Add(refdata_strunct);
			}

			// -------Read Reference data form .csv file                
			if (chkeach_ch->Checked)
			{
				cli::array<cli::array<float>^> ^ power;                 // Power data list 
				cli::array<cli::array<float>^> ^ monitor;                 // Power data list 
				int counter = 0;                         // Counter
				double wavelength ;                       // Read Wavelength 

				power = gcnew cli::array<cli::array<float>^>(ch_count);
				monitor = gcnew cli::array<cli::array<float>^>(ch_count);

				for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
				{
					power[loop1] = gcnew cli::array<float>(10000000);
					monitor[loop1] = gcnew cli::array<float>(10000000);
				}

				do
				{
					read_st = reader->ReadLine();
					if (read_st == nullptr)
						break;
					read_st = read_st->Trim();
					split_st = read_st->Split(',');
					// Check Start Wavelength 
					if (counter == 0)
					{
						if (Convert::ToDouble(split_st[0]) != Convert::ToDouble(txtstartwave->Text))
						{
							MessageBox::Show("Reference data mismatch.Please selecet right data.");
							reader->Close();
							return;
						}
					}

					// hold wavelength data
					wavelength = Convert::ToDouble(split_st[0]);
					for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
						power[loop1]->SetValue(System::Convert::ToSingle(split_st[loop1 + 1]), counter);
					for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
						monitor[loop1]->SetValue(System::Convert::ToSingle(split_st[ch_count + loop1 + 1]), counter);
					counter = counter + 1;
				} while (true);

				for (loop1 = 0; loop1 <= ch_count - 1; loop1++) {
					power[loop1]->Resize(power[loop1], counter);
					monitor[loop1]->Resize(monitor[loop1], counter);
				}

				reader->Close();

				// Check Stop wavelength 
				if (wavelength != Convert::ToDouble(txtstopwave->Text))
				{
					MessageBox::Show("Reference data mismatch.Please selecet right data.");
					return;
				}

				// check number of point 


				int datapoint;                            // number of data point 

				datapoint = (int)(Math::Abs(Convert::ToDouble(txtstopwave->Text) - Convert::ToDouble(txtstartwave->Text)) / Convert::ToDouble(txtstepwave->Text)) + 1;

				if (datapoint != monitor[0]->Length)
				{
					MessageBox::Show("Reference data mismatch.Please selecet right data.");
					return;
				}


				// -------Add in  data to STS Process class
				int errorcode;                            // Errorcode
				counter = 0;

				for each(auto item in lst_refdata_struct)
				{
					// Add in reference data of rescaled.
					errorcode = Cal_STS.Add_Ref_Rawdata(power[counter], monitor[counter], item);

					if (errorcode != 0)
					{
						Show_Inst_Error(errorcode);
						return;
					}
					counter = counter + 1;
				}
			}
			else
			{
				cli::array<cli::array<float>^> ^ power;                 // Power data list 
				cli::array<float> ^monitor = gcnew cli::array<float>(10000000);           // Monitordata
				int counter = 0;                         // Counter
				double wavelength;                       // Read Wavelength 

				power = gcnew cli::array<cli::array<float>^>(ch_count);

				for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
					power[loop1] = gcnew cli::array<float>(10000000);

				do
				{
					read_st = reader->ReadLine();
					if (read_st == nullptr)
						break;
						read_st = read_st->Trim();
						split_st = read_st->Split(',');

					// Check Start Wavelength 
						if (counter == 0)
						{
							if (Convert::ToDouble(split_st[0]) != Convert::ToDouble(txtstartwave->Text))
							{
								MessageBox::Show("Reference data mismatch.Please selecet right data.");
								reader->Close();
								return;
							}
						}



					// hold wavelength data
						wavelength = Convert::ToDouble(split_st[0]);
						for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
							power[loop1]->SetValue(System::Convert::ToSingle(split_st[loop1 + 1]), counter);
						monitor->SetValue(System::Convert::ToSingle(split_st[ch_count + 1]), counter);
						counter = counter + 1;
				} while (true);

				for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
					power[loop1]->Resize(power[loop1], counter);

				monitor->Resize(monitor, counter);
				reader->Close();

				// Check Stop wavelength 
				if (wavelength != Convert::ToDouble(txtstopwave->Text))
				{
					MessageBox::Show("Reference data mismatch.Please selecet right data.");
					return;
				}

				// check number of point 


				int datapoint;                            // number of data point 

				datapoint = (int)(Math::Abs(Convert::ToDouble(txtstopwave->Text) - Convert::ToDouble(txtstartwave->Text)) / Convert::ToDouble(txtstepwave->Text)) + 1;

				if (datapoint != monitor->Length)
				{
					MessageBox::Show("Reference data mismatch.Please selecet right data.");
					return;
				}
				// -------Add in  data to STS Process class
				int errorcode;                            // Errorcode
				counter = 0;

				for each(auto item in lst_refdata_struct)
				{
					// Add in reference data of rescaled.
					errorcode = Cal_STS.Add_Ref_Rawdata(power[counter], monitor, item);

					if (errorcode != 0)
					{
						Show_Inst_Error(errorcode);
						return;
					}
					counter = counter + 1;
				}
			}
			}

		MessageBox::Show("Completed.");
	}

	private: System::Void btnsavecalil_Click(System::Object^  sender, System::EventArgs^  e) {
		// ------------------------------------------------------------------------------
		// Save Calculated IL (Cancel for SOP wavelength dependence)
		// This method must be run after the PDL Calculation
		// ------------------------------------------------------------------------------
		String ^fpath = String::Empty;// filepath
		int errorcode;
		cli::array<float, 2>^ cal_IL = nullptr;
		cli::array<double>^ wavelengthdata = nullptr;

		// Load Wavelength data 
		errorcode = Cal_STS.Get_Target_Wavelength_Table(wavelengthdata);

		if (errorcode != 0)
		{
			Show_STS_Error(errorcode);
			return;
		}

		// Get Calculated IL
		errorcode = Cal_STS.Get_Calibrated_IL(cal_IL);

		if (errorcode != 0)
		{
			Show_STS_Error(errorcode);
			return;
		}

		// Data save
		SaveFileDialog1->Title = "Save to Calculated IL";
		SaveFileDialog1->Filter = "csv file(*.csv)|*.csv";
		SaveFileDialog1->ShowDialog();

		fpath = SaveFileDialog1->FileName;

		System::IO::StreamWriter^ writer = gcnew System::IO::StreamWriter(fpath, false, System::Text::Encoding::GetEncoding("UTF-8"));               // writer 
		int loop1;
		int loop2;
		String ^write_string = String::Empty;

		// hedder
		write_string = "Wavelength(nm),IL_V(dB),IL_H(dB),IL_45(dB),IL_RCP(dB)";

		writer->WriteLine(write_string);


		for (loop1 = 0; loop1 <= wavelengthdata->GetUpperBound(0); loop1++)
		{
			write_string = wavelengthdata[loop1] + ",";

			for (loop2 = 0; loop2 <= 3; loop2++)
				write_string = write_string + System::Convert::ToString(cal_IL[loop2, loop1]) + ",";

			writer->WriteLine(write_string);
		}
		writer->Close();

		MessageBox::Show("Completed.");
	}

	};
}
