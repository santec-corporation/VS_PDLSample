// ������ DLL �ļ���

#include "stdafx.h"

#include "librayForMFCPDL.h"
#include<tchar.h>

void Show_Inst_Error(int errordata)
{
	// ------------------------------------
	// Show error code
	// ------------------------------------
	cli::array<String^>^ errorstring = Enum::GetNames(ExceptionCode::typeid);
	cli::array<int>^ errorvale = static_cast<cli::array<int>^>(Enum::GetValues(ExceptionCode::typeid));
	int loop1;
	for (loop1 = 0; loop1 <= errorvale->Length - 1; loop1++)
	{
		if (errorvale[loop1] == errordata)
		{
			MessageBox(GetForegroundWindow(), (LPCTSTR)(void*)Marshal::StringToHGlobalAnsi(errorstring[loop1]), _T("prompt message"), MB_OK);
			break;
		}
	}
}

void Show_STS_Error(int errordata)
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
			MessageBox(GetForegroundWindow(), (LPCTSTR)(void*)Marshal::StringToHGlobalAnsi(errorstring[loop1]), _T("prompt message"), MB_OK);
			break;
		}
	}
}

extern "C" __declspec(dllexport) char* getDAQList()
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	if (obj->spu == nullptr) {
		obj->spu = gcnew SPU();
	}
	cli::array<String^> ^spudev;
	int errorcode = obj->spu->Get_Device_ID(spudev);

	String^ returnStr = "";
	if (errorcode == 0) {
		for (int i = 0; i < spudev->Length; i++) {

			if (i != 0)
				returnStr = returnStr + "," + spudev->GetValue(i);
			else
				returnStr = returnStr + spudev->GetValue(i);
		}
	}

	char* reval = (char*)(void*)Marshal::StringToHGlobalAnsi(returnStr);
	return reval;
}

extern "C" __declspec(dllexport) char* getUSBList()
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	cli::array<String^> ^usb_resource;
	usb_resource = Santec::Communication::MainCommunication::Get_USB_Resouce();

	String^ returnStr = "";
	for (int i = 0; i < usb_resource->Length; i++) {

		if (i != 0)
			returnStr = returnStr + "," + usb_resource->GetValue(i);
		else
			returnStr = returnStr + usb_resource->GetValue(i);
	}

	char* reval = (char*)(void*)Marshal::StringToHGlobalAnsi(returnStr);
	return reval;
}

extern "C" __declspec(dllexport) int setTSLConnection(char* ip, int port)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	if (obj->tsl == nullptr) {
		obj->tsl = gcnew TSL();
	}

	obj->tsl_communcation_method = CommunicationMethod::TCPIP;
	obj->tsl->Terminator = CommunicationTerminator::Cr;
	obj->tsl->IPAddress = gcnew String(ip);
	obj->tsl->Port = port;

	int errorcode = obj->tsl->Connect(obj->tsl_communcation_method);

	return errorcode;
}

extern "C" __declspec(dllexport) int setTSLGPIBConnection(int addr)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	if (obj->tsl == nullptr) {
		obj->tsl = gcnew TSL();
	}

	obj->tsl_communcation_method = CommunicationMethod::GPIB;
	obj->tsl->Terminator = CommunicationTerminator::CrLf;
	obj->tsl->GPIBAddress = addr;
	obj->tsl->GPIBBoard = 0;
	obj->tsl->GPIBConnectType = GPIBConnectType::NI4882;

	int errorcode = obj->tsl->Connect(obj->tsl_communcation_method);

	return errorcode;
}

extern "C" __declspec(dllexport) int setTSLUSBConnection(int addr)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	if (obj->tsl == nullptr) {
		obj->tsl = gcnew TSL();
	}

	obj->tsl_communcation_method = CommunicationMethod::USB;
	obj->tsl->DeviceID = addr;
	obj->tsl->Terminator = CommunicationTerminator::Cr;

	int errorcode = obj->tsl->Connect(obj->tsl_communcation_method);

	return errorcode;
}

extern "C" __declspec(dllexport) int setPCUConnection(char* ip, int port)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	if (obj->pcu == nullptr) {
		obj->pcu = gcnew PCU();
	}
	obj->pcu_communcation_method = CommunicationMethod::TCPIP;
	obj->pcu->IPAddress = gcnew String(ip);
	obj->pcu->Port = port;

	int errorcode = obj->pcu->Connect(obj->pcu_communcation_method);
	return errorcode;
}

extern "C" __declspec(dllexport) int setPCUGPIBConnection(int addr)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();


	if (obj->pcu == nullptr) {
		obj->pcu = gcnew PCU();
	}

	// GPIB
	obj->pcu_communcation_method = Communication::CommunicationMethod::GPIB;
	obj->pcu->GPIBAddress = addr;
	obj->pcu->GPIBBoard = 0;
	obj->pcu->Terminator = CommunicationTerminator::CrLf;

	int errorcode = obj->pcu->Connect(obj->pcu_communcation_method);

	return errorcode;
}

extern "C" __declspec(dllexport) int setPCUUSBConnection(int addr)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	if (obj->pcu == nullptr) {
		obj->pcu = gcnew PCU();
	}

	// USB
	obj->pcu_communcation_method = CommunicationMethod::USB;
	obj->pcu->DeviceID = addr;
	obj->pcu->Terminator = CommunicationTerminator::Cr;                     // PCU USB Command follow only "Cr"  terminator


	int errorcode = obj->pcu->Connect(obj->pcu_communcation_method);

	return errorcode;
}
extern "C" __declspec(dllexport) int setPCU_DAQ(char* daqResource)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	if (obj->pcu == nullptr) {
		obj->pcu = gcnew PCU();
	}
	obj->pcu->DeviceName = gcnew String(daqResource);
	return 0;
}

extern "C" __declspec(dllexport) int setMPMConnection(char* ip, int port, int index)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	MPM ^mpm = gcnew MPM();
	mpm->IPAddress = gcnew String(ip);
	mpm->Port = port;
	obj->mpm_communcation_method = CommunicationMethod::TCPIP;
	mpm->TimeOut = 11000;
	int errorcode = mpm->Connect(CommunicationMethod::TCPIP);

	obj->mpms->SetValue(mpm, index - 1);
	obj->mpmCnt = index;
	char* d = (char*)(void*)Marshal::StringToHGlobalAnsi(mpm->Information->ProductName);
	return  errorcode;
}

extern "C" __declspec(dllexport) int setMPMGPIBConnection(int addr, int index)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	MPM ^mpm = gcnew MPM();
	mpm->GPIBAddress = addr;

	obj->mpm_communcation_method = CommunicationMethod::GPIB;
	mpm->TimeOut = 11000;
	int errorcode = mpm->Connect(obj->mpm_communcation_method);

	obj->mpms->SetValue(mpm, index - 1);
	obj->mpmCnt = index;
	char* d = (char*)(void*)Marshal::StringToHGlobalAnsi(mpm->Information->ProductName);
	return  errorcode;
}

extern "C" __declspec(dllexport) char* connectMPM(int index)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	MPM ^mpm = (MPM ^)obj->mpms->GetValue(index - 1);

	int errorcode = mpm->Connect(CommunicationMethod::TCPIP);

	char* d = (char*)(void*)Marshal::StringToHGlobalAnsi(mpm->Information->ProductName);
	mpm->DisConnect();
	return  d;
}

extern "C" __declspec(dllexport) int setDAQConnection(char* daqStr)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	if (obj->spu == nullptr) {
		obj->spu = gcnew SPU();
	}

	obj->spu->DeviceName = gcnew String(daqStr);
	String^ ans;
	int errorcode = obj->spu->Connect(ans);

	return errorcode;
}

extern "C" __declspec(dllexport) int Check_Module_Information()
{

	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// ------------------------------------------------------------
	// check Module information inside system
	// ------------------------------------------------------------
	int loop1;
	int loop2;
	int counter_215 = 0;                           // 215 counter 

	// MPM device loop
	for (loop1 = 0; loop1 < obj->mpmCnt; loop1++)
	{
		MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
		// Slot loop
		for (loop2 = 0; loop2 <= 4; loop2++)
		{
			// Enable Slot
			if (mpm->Information->ModuleEnable[loop2])
			{

				// Check MPM-215 insert
				if (mpm->Information->ModuleType[loop2] == "MPM-215")
				{
					obj->Flag_215 = true;
					counter_215 = counter_215 + 1;
				}

				// Check MPM-213 insert
				if (mpm->Information->ModuleType[loop2] == "MPM-213")
					obj->Flag_213 = true;
			}
		}
	}

	// Check MPM-215 count & Module total count
	// STS system can't use 215 together other module.
	int enable_module_count = 0;                      // enable module count

	for (int loop1 = 0; loop1 < obj->mpmCnt; loop1++) {
		MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
		enable_module_count = mpm->Information->NumberofModule + enable_module_count;// total module count
	}

	if (obj->Flag_215 == true)
	{
		if (enable_module_count != counter_215)
			return -1;
		return 1;
	}
	return 0;
}

extern "C" __declspec(dllexport) char* Add_TSL_Sweep_Speed()
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// ---------------------------------------------------------
	// Add in selectable sweep speed to speed combbox
	// this function can use only TSL-570
	// ----------------------------------------------------------
	int inst_error;                       // instullment error
    cli:array<double> ^sweep_table;           // table

	// Get Sweep speed tabele
	// Except for TSL-570 "Device Error" occurre when call this function.
	inst_error = obj->tsl->Get_Sweep_Speed_table(sweep_table);

	if (inst_error != 0 && inst_error != Convert::ToInt32(ExceptionCode::DeviceError))
		//return inst_error;
		return "error";

	// -----Add in combbox when TSL-570
	int loop1;

	String ^reval = "";
	if (inst_error != Convert::ToInt32(ExceptionCode::DeviceError))
	{
		for (loop1 = 0; loop1 < sweep_table->Length; loop1++) {
			char buffer[10];
			sprintf_s(buffer, "%.1f", (double)sweep_table->GetValue(loop1));
			String ^s = gcnew String(buffer);
			if (loop1 != 0)
				reval = reval + "," + s;
			else
				reval = reval + s;
		}
	}

	//char* reVal = "1.0,2.0,5.0,10.0,20.0,50.0,100.0,200.0";

	char* creval = (char*)(void*)Marshal::StringToHGlobalAnsi(reval);

	return creval;
}

void Prepare_dataST(bool Sop2Flag)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	// ----------------------------------------------
	// Prepar STS data struct
	// -----------------------------------------------
	int rangecout;                        // number of range
	int chcount;                          // number of ch 
	int chloop;                            // loop count1
	int rangeloop;                            // loop count2
	int soploop;                          //sop loop
	String^ text_st = "";				  // text String 
	obj->chk2scan = Sop2Flag;

	// List clear 
	obj->Meas_rang = gcnew cli::array<int>(obj->rangeCnt);                                // Measurement Range
	if (Sop2Flag)
	{
		obj->Data_struct = gcnew cli::array<STSDataStruct>(obj->channelCnt * (4 + ((obj->rangeCnt - 1) * 2)));  // DataSturct of STS
		obj->Meas_monitordata_struct = gcnew cli::array<STSMonitorStruct>(4 + (obj->rangeCnt - 1) * 2);
	}
	else
	{
		obj->Data_struct = gcnew cli::array<STSDataStruct>(obj->channelCnt * obj->rangeCnt * 4);  // DataSturct of STS
		obj->Meas_monitordata_struct = gcnew cli::array<STSMonitorStruct>(obj->rangeCnt * 4);
	}
	obj->Mergedata_struct = gcnew cli::array<STSDataStructForMerge>(obj->channelCnt * 4);
	obj->Ref_monitordata_struct = gcnew cli::array<STSDataStruct>(4);
	obj->Refdata_struct = gcnew cli::array<STSDataStruct>(obj->channelCnt * 4);               // Reference data struct

	rangecout = obj->rangeCnt;
	chcount = obj->channelCnt;

	if (obj->Flag_215 == true)
		//If mom215 range must be set 1
		obj->Meas_rang->SetValue(1, 0);
	else
	{
		if (rangecout == 0 || chcount == 0)
		{
			//MessageBox.Show("Please check measurement parameters.", "", MessageBoxButtons.OK);
			return;
		}
		// hold range data 
		for (int loop1 = 0; loop1 < obj->rangeCnt; loop1++)
		{
			//if (this.chklst_range.GetItemChecked(loop1) == true)
			obj->Meas_rang->SetValue((int)obj->rangeList->GetValue(loop1), loop1);
		}
	}

	// Add in measurement condition of Data structure 
	int sopcount;
	int device_number;                        // MPM device number
	int slot_number;                           // MPM Slot number
	int ch_number;                            // MPM channel number                    
	STSDataStruct *set_struct = new STSDataStruct();  // Data struct for STS data hold
	int sweep_count = 1;                         // Sweep counter 
	int loop = 0;
	//for measurement power data
	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);

		// ch parameter
		device_number = channelInfo / 100 - 1;
		slot_number = channelInfo % 100 / 10;
		ch_number = channelInfo % 100 % 10;

		set_struct->MPMNumber = device_number;       // MPM Main frame device count 
		set_struct->SlotNumber = slot_number;         // Slot number 
		set_struct->ChannelNumber = ch_number;       // Channel number

		// --------set struct for "STSdatastruct"---------------- 
		for (rangeloop = 0; rangeloop < obj->rangeCnt; rangeloop++)        // range loop
		{
			// Lower range & if checked "2SOP for low power range"
			if (Sop2Flag && rangeloop != 0)
				sopcount = 2;                         // 2Scan
			else
				sopcount = 4;// 4Scan

			set_struct->RangeNumber = (int)obj->Meas_rang->GetValue(rangeloop); // Setting range      
			for (soploop = 0; soploop <= sopcount - 1; soploop++)
			{
				set_struct->SweepCount = sweep_count;   // Sweep count 
				set_struct->SOP = soploop;                     // SOP number LVP:0 LHP:1 LP45:2 RCP:3
				sweep_count = sweep_count + 1;

				// Add measurement data 
				obj->Data_struct->SetValue(*set_struct, loop);
				loop++;
			}
		}
		sweep_count = 1;
	}
	// for reference power data & mergedata 
	STSDataStructForMerge *set_merge_struct = new STSDataStructForMerge();
	set_struct = new STSDataStruct();
	loop = 0;
	sweep_count = 1;
	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);

		// ch parameter
		device_number = channelInfo / 100 - 1;
		slot_number = channelInfo % 100 / 10;
		ch_number = channelInfo % 100 % 10;
		// for data
		set_struct->MPMNumber = device_number;
		set_struct->SlotNumber = slot_number;
		set_struct->ChannelNumber = ch_number;
		set_struct->RangeNumber = 1;
		// for merge
		set_merge_struct->MPMNumber = device_number;
		set_merge_struct->SlotNumber = slot_number;
		set_merge_struct->ChannelNumber = ch_number;
		sopcount = 4;

		// SOP loop
		for (soploop = 0; soploop <= sopcount - 1; soploop++)
		{
			set_struct->SOP = soploop;
			set_struct->SweepCount = sweep_count;

			set_merge_struct->SOP = soploop;

			sweep_count = sweep_count + 1;
			obj->Refdata_struct->SetValue(*set_struct, loop);                      // Add Data for Reference Struct
			obj->Mergedata_struct->SetValue(*set_merge_struct, loop);              // Add data for Merge Struct
			loop++;
		}
		sweep_count = 1;
	}

	loop = 0;
	// for measurement monitor data
	STSMonitorStruct *set_monitor_struct = new STSMonitorStruct();
	sweep_count = 1;

	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);

		// ch parameter
		device_number = channelInfo / 100 - 1;

		set_monitor_struct->MPMNumber = device_number;

		for (rangeloop = 0; rangeloop < obj->rangeCnt; rangeloop++)
		{
			if (Sop2Flag == true & rangeloop != 0)
				sopcount = 2;
			else
				sopcount = 4;

			for (soploop = 0; soploop <= sopcount - 1; soploop++)
			{
				set_monitor_struct->SOP = soploop;
				set_monitor_struct->SweepCount = sweep_count;
				// Add
				obj->Meas_monitordata_struct->SetValue(*set_monitor_struct, loop);
				sweep_count = sweep_count + 1;
				loop++;
			}
		}
		break;
	}

	// for reference monitor data
	sweep_count = 1;
	loop = 0;
	STSDataStruct *set_ref_monitor_struct = new STSDataStruct();

	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);

		// ch parameter
		device_number = channelInfo / 100 - 1;
		slot_number = channelInfo % 100 / 10;
		ch_number = channelInfo % 100 % 10;
		// for data
		set_ref_monitor_struct->MPMNumber = device_number;
		set_ref_monitor_struct->SlotNumber = slot_number;
		set_ref_monitor_struct->ChannelNumber = ch_number;
		set_ref_monitor_struct->RangeNumber = 1;

		for (soploop = 0; soploop <= 3; soploop++)
		{
			set_ref_monitor_struct->SOP = soploop;
			set_ref_monitor_struct->SweepCount = soploop + 1;

			obj->Ref_monitordata_struct->SetValue(*set_ref_monitor_struct, loop);
			loop++;
		}
		break;
	}
}
void Prepare_dataST_Each(bool Sop2Flag)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	// ----------------------------------------------
	// Prepar STS data struct
	// -----------------------------------------------
	int rangecout;                        // number of range
	int chcount;                          // number of ch 
	int chloop;                            // loop count1
	int rangeloop;                            // loop count2
	int soploop;                          //sop loop
	String^ text_st = "";				  // text String 
	obj->chk2scan = Sop2Flag;

	// List clear 
	obj->Meas_rang = gcnew cli::array<int>(obj->rangeCnt);                                // Measurement Range
	if (Sop2Flag)
	{
		obj->Data_struct = gcnew cli::array<STSDataStruct>(obj->channelCnt * (4 + ((obj->rangeCnt - 1) * 2)));  // DataSturct of STS
		obj->Meas_monitordata_struct = gcnew cli::array<STSMonitorStruct>(4 + (obj->rangeCnt - 1) * 2);
	}
	else
	{
		obj->Data_struct = gcnew cli::array<STSDataStruct>(obj->channelCnt * obj->rangeCnt * 4);  // DataSturct of STS
		obj->Meas_monitordata_struct = gcnew cli::array<STSMonitorStruct>(obj->rangeCnt * 4);
	}
	obj->Mergedata_struct = gcnew cli::array<STSDataStructForMerge>(obj->channelCnt * 4);
	obj->Ref_monitordata_struct = gcnew cli::array<STSDataStruct>(obj->channelCnt * 4);
	obj->Refdata_struct = gcnew cli::array<STSDataStruct>(obj->channelCnt * 4);               // Reference data struct

	rangecout = obj->rangeCnt;
	chcount = obj->channelCnt;

	if (obj->Flag_215 == true)
		//If mom215 range must be set 1
		obj->Meas_rang->SetValue(1, 0);
	else
	{
		if (rangecout == 0 || chcount == 0)
		{
			//MessageBox.Show("Please check measurement parameters.", "", MessageBoxButtons.OK);
			return;
		}
		// hold range data 
		for (int loop1 = 0; loop1 < obj->rangeCnt; loop1++)
		{
			//if (this.chklst_range.GetItemChecked(loop1) == true)
			obj->Meas_rang->SetValue((int)obj->rangeList->GetValue(loop1), loop1);
		}
	}

	// Add in measurement condition of Data structure 
	int sopcount;
	int device_number;                        // MPM device number
	int slot_number;                           // MPM Slot number
	int ch_number;                            // MPM channel number                    
	STSDataStruct *set_struct = new STSDataStruct();  // Data struct for STS data hold
	int sweep_count = 1;                         // Sweep counter 
	int loop = 0;

	//for measurement power data
	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);

		// ch parameter
		device_number = channelInfo / 100 - 1;
		slot_number = channelInfo % 100 / 10;
		ch_number = channelInfo % 100 % 10;

		set_struct->MPMNumber = device_number;       // MPM Main frame device count 
		set_struct->SlotNumber = slot_number;         // Slot number 
		set_struct->ChannelNumber = ch_number;       // Channel number

		// --------set struct for "STSdatastruct"---------------- 
		for (rangeloop = 0; rangeloop < obj->rangeCnt; rangeloop++)        // range loop
		{
			// Lower range & if checked "2SOP for low power range"
			if (Sop2Flag && rangeloop != 0)
				sopcount = 2;                         // 2Scan
			else
				sopcount = 4;// 4Scan

			set_struct->RangeNumber = (int)obj->Meas_rang->GetValue(rangeloop); // Setting range      
			for (soploop = 0; soploop <= sopcount - 1; soploop++)
			{
				set_struct->SweepCount = sweep_count;   // Sweep count 
				set_struct->SOP = soploop;                     // SOP number LVP:0 LHP:1 LP45:2 RCP:3
				sweep_count = sweep_count + 1;

				// Add measurement data 
				obj->Data_struct->SetValue(*set_struct, loop);
				loop++;
			}
		}
		sweep_count = 1;
	}

	// for reference power data & reference monitor data
	STSDataStruct *set_ref_monitor_struct = new  STSDataStruct();
	sweep_count = 1;
	loop = 0;
	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);

		// ch parameter
		device_number = channelInfo / 100 - 1;
		slot_number = channelInfo % 100 / 10;
		ch_number = channelInfo % 100 % 10;

		// for data
		set_struct->MPMNumber = device_number;
		set_struct->SlotNumber = slot_number;
		set_struct->ChannelNumber = ch_number;
		set_struct->RangeNumber = 1;

		// for monitor
		set_ref_monitor_struct->MPMNumber = device_number;
		set_ref_monitor_struct->SlotNumber = slot_number;
		set_ref_monitor_struct->ChannelNumber = ch_number;
		set_ref_monitor_struct->RangeNumber = 1;

		sopcount = 4;

		// SOP loop
		for (soploop = 0; soploop <= sopcount - 1; soploop++)
		{
			set_struct->SOP = soploop;
			set_struct->SweepCount = sweep_count;

			set_ref_monitor_struct->SOP = soploop;
			set_ref_monitor_struct->SweepCount = sweep_count;

			sweep_count = sweep_count + 1;
			obj->Refdata_struct->SetValue(*set_struct, loop);                      // Add Data for Reference Struct
			obj->Ref_monitordata_struct->SetValue(*set_ref_monitor_struct, loop);  // Add monitor data for Reference Struct
			loop++;
		}
	}

	// for mergedata 
	STSDataStructForMerge *set_merge_struct = new STSDataStructForMerge();
	sweep_count = 1;
	loop = 0;
	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);

		// ch parameter
		device_number = channelInfo / 100 - 1;
		slot_number = channelInfo % 100 / 10;
		ch_number = channelInfo % 100 % 10;

		set_merge_struct->MPMNumber = device_number;
		set_merge_struct->SlotNumber = slot_number;
		set_merge_struct->ChannelNumber = ch_number;
		sopcount = 4;

		// SOP loop
		for (soploop = 0; soploop <= sopcount - 1; soploop++)
		{
			set_merge_struct->SOP = soploop;

			sweep_count = sweep_count + 1;
			obj->Mergedata_struct->SetValue(*set_merge_struct, loop);              // Add data for Merge Struct
			loop++;
		}
		sweep_count = 1;
	}

	// for measurement monitor data
	STSMonitorStruct *set_monitor_struct = new STSMonitorStruct();
	sweep_count = 1;
	loop = 0;

	for (chloop = 0; chloop < obj->channelCnt; chloop++)
	{
		int channelInfo = (int)obj->channelList->GetValue(chloop);
		device_number = channelInfo / 100 - 1;

		set_monitor_struct->MPMNumber = device_number;

		for (rangeloop = 0; rangeloop < obj->rangeCnt; rangeloop++)
		{
			if (Sop2Flag == true & rangeloop != 0)
				sopcount = 2;
			else
				sopcount = 4;
			for (soploop = 0; soploop <= sopcount - 1; soploop++)
			{
				set_monitor_struct->SOP = soploop;
				set_monitor_struct->SweepCount = sweep_count;
				// Add
				obj->Meas_monitordata_struct->SetValue(*set_monitor_struct, loop);
				sweep_count = sweep_count + 1;
				loop++;
			}
		}
		break;

	}

}

extern "C" __declspec(dllexport) void setSweepCondition(double startWL, double stopWL, double step, double pSpeed, double power, bool sop2Flag, bool chkeach_ch)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	if (obj->cal_sts == nullptr)
	{
		obj->cal_sts = gcnew PDLSTS();
	}
	// -------------------------------------------------------------------------
	// Set Parameter
	// --------------------------------------------------------------------------
	double startwave;             // Startwavelength(nm)
	double stopwave;              // Stopwavelength(nm)
	double set_pow;               // Power(dBm)
	double wavestep;              // wavelenthg step(nm)
	double speed;                 // Sweep Speed (nm/sec)
	int inst_error;           // instullment error

	startwave = startWL;
	stopwave = stopWL;
	wavestep = step;
	speed = pSpeed;
	set_pow = power;

	obj->startWaveLength = startWL;
	obj->stopWaveLength = stopWL;
	obj->stepWaveLength = step;

	// ------------TSL Setting--------------------------------------------------- 
	// set Power
	inst_error = obj->tsl->Set_APC_Power_dBm(set_pow);
	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}

	// busy check
	inst_error = obj->tsl->TSL_Busy_Check(3000);
	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}

	double tsl_acctualstep;          // TSL output trigger step(nm)

	// set Sweep parameter
	inst_error = obj->tsl->Set_Sweep_Parameter_for_STS(startwave, stopwave, speed, wavestep, tsl_acctualstep);
	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}

	// wavelength -> start wavelength
	inst_error = obj->tsl->Set_Wavelength(startwave);
	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}

	// busy check
	inst_error = obj->tsl->TSL_Busy_Check(3000);
	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}


	// ----------MPM setting ---------------------------------------------------;
	for (int loop1 = 0; loop1 < obj->mpmCnt; loop1++)
	{
		MPM^ mpm = (MPM^)obj->mpms->GetValue(loop1);
		// Sweep parameter setting 
		inst_error = mpm->Set_Logging_Paremeter_for_STS(startwave, stopwave, wavestep, speed, MPM::Measurement_Mode::Freerun);
		if (inst_error != 0)
		{
			Show_Inst_Error(inst_error);
			return;
		}
	}

	// ---------SPU setting------------------------------------------------------ 
	double averaging_time;

	MPM^ mpm = (MPM^)obj->mpms->GetValue(0);
	inst_error = mpm->Get_Averaging_Time(averaging_time);

	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}

	// parameter setting 
	inst_error = obj->spu->Set_Sampling_Parameter(startwave, stopwave, speed, tsl_acctualstep);

	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}

	// mpm averageing time-> spu
	obj->spu->AveragingTime = averaging_time;

	// -----PCU setting --------------------------------------------------------------
	// PCU range adjust must set to be after TSL Power set.
	inst_error = obj->pcu->Range_Adjust();

	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}
	// -------------set STS Process parameter-----------------------------------

	int sts_error;            // sts process class error

	// data Clear 
	sts_error = obj->cal_sts->Clear_Measdata();

	if (sts_error != 0)
	{
		Show_STS_Error(sts_error);
		return;
	}

	sts_error = obj->cal_sts->Clear_Refdata();

	if (sts_error != 0)
	{
		Show_STS_Error(sts_error);
		return;
	}

	// Setting for STS rescaling mode
	sts_error = obj->cal_sts->Set_Rescaling_Setting(RescalingMode::Freerun_SPU, averaging_time, true);

	if (sts_error != 0)
	{
		Show_STS_Error(sts_error);
		return;
	}

	// Make acctual wavelength step table
	sts_error = obj->cal_sts->Make_Sweep_Wavelength_Table(startwave, stopwave, tsl_acctualstep);

	if (sts_error != 0)
	{
		Show_STS_Error(sts_error);
		return;
	}

	// Make rescaling wavelength step table
	sts_error = obj->cal_sts->Make_Target_Wavelength_Table(startwave, stopwave, wavestep);

	if (sts_error != 0)
	{
		Show_STS_Error(sts_error);
		return;
	}


	// ----prepare data struct & hold instrument condition
	if (chkeach_ch == true)
	{
		Prepare_dataST_Each(sop2Flag);
	}
	else
	{
		Prepare_dataST(sop2Flag);
	}
	MessageBox(GetForegroundWindow(), _T("Completed."), _T("prompt message"), MB_OK);

}

extern "C" __declspec(dllexport) bool GetFlag_213()
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	return obj->Flag_213;
}

extern "C" __declspec(dllexport) bool GetFlag_215()
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	return obj->Flag_215;
}

extern "C" __declspec(dllexport) char* GetModuleEnable(int index)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	MPM ^mpm = (MPM ^)obj->mpms->GetValue(index);
	String^ ca;
	for (int i = 0; i < mpm->Information->ModuleEnable->Length; i++)
	{
		ca = ca + mpm->Information->ModuleEnable[i].ToString() + ",";
	}
	return (char*)(void*)Marshal::StringToHGlobalAnsi(ca);
}

extern "C" __declspec(dllexport) char* GetModuleType(int index, int channel)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	MPM ^mpm = (MPM ^)obj->mpms->GetValue(index);

	return (char*)(void*)Marshal::StringToHGlobalAnsi(mpm->Information->ModuleType[channel]);
}

extern "C" __declspec(dllexport) void setRange(int range, int index)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	obj->rangeList->SetValue(range, index - 1);
	obj->rangeCnt = index;

}

extern "C" __declspec(dllexport) void setChannel(int channel, int index)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	obj->channelList->SetValue(channel, index - 1);
	obj->channelCnt = index;
}

int Sweep_Process()
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// ------------------------------------------------------------
	// Sweep Process
	// ------------------------------------------------------------
	int inst_error;               // Instullment error
	int loop1;                    // loop count 


	// MPM sampling start 
	for (loop1 = 0; loop1 < obj->mpmCnt; loop1++)
	{
		MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
		inst_error = mpm->Logging_Start();
		if (inst_error != 0)
			return 11;
	}

	// TSL waiting for start status 
	inst_error = obj->tsl->Waiting_For_Sweep_Status(2000, TSL::Sweep_Status::WaitingforTrigger);

	// ---error handling -> MPM Logging Stop
	if (inst_error != 0)
	{
		for (loop1 = 0; loop1 < obj->mpmCnt; loop1++) {
			MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);

			mpm->Logging_Stop();
		}
		return inst_error;
	}

	// SPU sampling start
	inst_error = obj->spu->Sampling_Start(false);

	if (inst_error != 0)
	{
		// ----error handling -> MPM Logging Stop
		for (loop1 = 0; loop1 <= obj->mpmCnt; loop1++) {
			MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);

			mpm->Logging_Stop();
		}
		return inst_error;
	}

	// TSL issue software trigger
	inst_error = obj->tsl->Set_Software_Trigger();

	// ---error handling -> MPM Logging Stop
	if (inst_error != 0)
	{
		for (loop1 = 0; loop1 < obj->mpmCnt; loop1++) {
			MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
			mpm->Logging_Stop();
		}
		return inst_error;
	}

	// SPU waiting for sampling 
	inst_error = obj->spu->Waiting_for_sampling();

	// ---error handling -> MPM Logging Stop
	if (inst_error != 0)
	{
		for (loop1 = 0; loop1 < obj->mpmCnt; loop1++) {
			MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
			mpm->Logging_Stop();
		}
		return inst_error;
	}

	int mpm_stauts = 0;                   // mpm logging status 0:douring measurement 1:Compleated -1:Stopped
	int mpm_count = 0;                    // mpm number of logging completed point  
	Stopwatch ^st = gcnew Stopwatch();    // stopwatch           
	bool mpm_completed_falg = true;       // mpm logging completed flag  F:not completed T:completed    
	bool isSweeping = true;
	// MPM waiting for sampling 
	st->Start();                          // stopwathc start 
	do
	{
		for (loop1 = 0; loop1 < obj->mpmCnt; loop1++)
		{
			MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
			inst_error = mpm->Get_Logging_Status(mpm_stauts, mpm_count);
			if (inst_error != 0)
				return inst_error;
			if (mpm_stauts == 1)
			{
				isSweeping = false;
				break;
			}
			if (st->ElapsedMilliseconds >= 5000)
			{
				//Logging time out(time out = 2sec after from SPU sampling  completed.)
				mpm_completed_falg = false;
				isSweeping = false;
				break;
			}
		}
	} while (isSweeping);

	st->Stop();

	// MPM sampling stop
	for (loop1 = 0; loop1 < obj->mpmCnt; loop1++)
	{
		MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
		inst_error = mpm->Logging_Stop();
		if (inst_error != 0)
			return inst_error;
	}


	// TSL Waiting for standby
	inst_error = obj->tsl->Waiting_For_Sweep_Status(5000, TSL::Sweep_Status::Standby);

	if (inst_error != 0)
		return inst_error;

	if (mpm_completed_falg == false)
		// mpm logging timeout occurred.
		return -9999;

	return 0;
}

int Get_MPM_Loggdata(int deveice, int slot, int ch)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// ---------------------------------------------------------------
	// Get MPM Logg data
	// --------------------------------------------------------------
	int inst_error;

	MPM ^mpm = (MPM^)obj->mpms->GetValue(deveice);

	inst_error = mpm->Get_Each_Channel_Logdata(slot, ch, obj->logg_data);
	return inst_error;
}

int Get_reference_samplingdata(bool inst_flag, PCU::SOP_Stauts currentSOP)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// ---------------------------------------------------------------
	// Get logging reference data & add in 
	// ---------------------------------------------------------------
	int inst_error;                        // Instullment error
	//cli::array<double> ^logg_data;         // MPM Logging data
	int cal_error;                         // process error

	// ----Load　Reference MPM data & add  in data for STS Process Class for each channel
	for (int i = 0; i < obj->Refdata_struct->Length; i++)
	{
		STSDataStruct item = (STSDataStruct)obj->Refdata_struct->GetValue(i);
		if (item.SOP != (int)currentSOP)
			continue;

		// Read corresponded  MPM channel data
		inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber);

		if (inst_error != 0)
		{
			inst_flag = true;
			return inst_error;
		}

		// Add in to MPM reference data to STS Process Class
		cal_error = obj->cal_sts->Add_Ref_MPMData_CH(obj->logg_data, item);

		if (cal_error != 0)
		{
			inst_flag = false;
			return cal_error;
		}
	}

	// ----Load　Reference Monitor data 
	cli::array<float> ^triggerdata;     // tigger data 
	cli::array<float> ^monitordata;     // monitor data

	inst_error = obj->spu->Get_Sampling_Rawdata(triggerdata, monitordata);

	if (inst_error != 0)
	{
		inst_flag = true;
		return inst_error;
	}

	// -- Add reference monitor data associated with parameters of the same SOP
	for (int i = 0; i < obj->Ref_monitordata_struct->Length; i++)
	{
		STSDataStruct item = (STSDataStruct)obj->Ref_monitordata_struct->GetValue(i);
		if (item.SOP == (int)currentSOP)
		{
			cal_error = obj->cal_sts->Add_Ref_MonitorData(triggerdata, monitordata, item);

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

int Get_Each_channel_reference_samplingdata(bool %inst_flag, int currentMPMNumber, int currentSlotNumber, int currentChannelNumber, PCU::SOP_Stauts currentSOP, int currentSweepCount)
{
	// ---------------------------------------------------------------
	// Get logging reference data & add in 
	// ---------------------------------------------------------------
	int inst_error;                        // Instullment error
	cli::array<float>^ logg_data = nullptr;             // mpm Logging data
	int cal_error;                         // process error
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();


	// ----Load　Reference MPM data & add  in data for STS Process Class for each channel
	for each(STSDataStruct item in obj->Refdata_struct)
	{
		if ((item.MPMNumber != currentMPMNumber | item.SlotNumber != currentSlotNumber | item.ChannelNumber != currentChannelNumber | item.SOP != (int)currentSOP))
			continue;

		// Read corresponded  MPM channel data
		inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber);

		if (inst_error != 0)
		{
			inst_flag = true;
			return inst_error;
		}

		// Add in to MPM reference data to STS Process Class
		cal_error = obj->cal_sts->Add_Ref_MPMData_CH(obj->logg_data, item);

		if (cal_error != 0)
		{
			inst_flag = false;
			return cal_error;
		}
	}

	// ----Load　Reference Monitor data 
	cli::array<float>^ triggerdata = nullptr;
	cli::array<float>^ monitordata = nullptr;

	inst_error = obj->spu->Get_Sampling_Rawdata(triggerdata, monitordata);

	if (inst_error != 0)
	{
		inst_flag = true;
		return inst_error;
	}

	// -- Add reference monitor data associated with parameters of the same SOP
	for each(STSDataStruct monitor_item in obj->Ref_monitordata_struct)
	{
		if ((monitor_item.SlotNumber == currentSlotNumber & monitor_item.ChannelNumber == currentChannelNumber & monitor_item.SOP == (int)currentSOP & monitor_item.SweepCount == currentSweepCount))
		{
			cal_error = obj->cal_sts->Add_Ref_MonitorData(triggerdata, monitordata, monitor_item);

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
int All_channel_reference(bool %inst_flag)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	// ------------------------------------------------------------------------------
	// Get Reference
	// ------------------------------------------------------------------------------
	int inst_error;                       // Instullment error
	int loop1;
	PCU::SOP_Stauts setting_SOP;               // Setting SOP 

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
		inst_error = obj->pcu->Set_SOP_Stauts(setting_SOP);

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
		inst_error = obj->tsl->Sweep_Start();
		if (inst_error != 0)
		{
			inst_flag = true;
			return inst_error;
		}


		// get logging data & add in STSProcess class

		inst_error = Get_reference_samplingdata(inst_flag, setting_SOP);

		if (inst_error != 0)
			return inst_error;
	}


	// ------Reference data rescaling 
	int process_error;
	process_error = obj->cal_sts->Cal_RefData_Rescaling();

	if (process_error != 0)
	{
		inst_flag = false;
		return process_error;
	}

	return 0;
}

int Each_channel_reference(bool %inst_flag)
{

	// ------------------------------------------------------------------------------
	// Get Reference
	// ------------------------------------------------------------------------------
	int inst_error;                       // Instullment error
	PCU::SOP_Stauts setting_SOP;               // Setting SOP 
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();


	for each(STSDataStruct item in obj->Refdata_struct)
	{

		// SOP must to set for V -> H-> 45-> RC
		switch (item.SOP)
		{
		case 0:
		{
			char* str = (char*)(void*)Marshal::StringToHGlobalAnsi("Connect fiber to MPM" + item.MPMNumber + "_Slot" + item.SlotNumber + "_Ch" + item.ChannelNumber + ".");
			MessageBox(GetForegroundWindow(), str, _T("prompt message"), MB_OK);
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
		inst_error = obj->pcu->Set_SOP_Stauts(setting_SOP);

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
		inst_error = obj->tsl->Sweep_Start();
		if (inst_error != 0)
		{
			inst_flag = true;
			return inst_error;
		}


		// get logging data & add in STSProcess class
		inst_error = Get_Each_channel_reference_samplingdata(inst_flag, item.MPMNumber, item.SlotNumber, item.ChannelNumber, setting_SOP, item.SweepCount);

		if (inst_error != 0)
			return inst_error;

		// ------Reference data rescaling 
		int process_error;
		process_error = obj->cal_sts->Cal_RefData_Rescaling();

		if (process_error != 0)
		{
			inst_flag = false;
			return process_error;
		}
	}

	return 0;
}

extern "C" __declspec(dllexport) void reference(bool chkeach_ch)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	// ------------------------------------------------------------------------------
	// Get Reference
	// ------------------------------------------------------------------------------
	int inst_error;                       // Instullment error
	int loop1;
	PCU::SOP_Stauts setting_SOP;               // Setting SOP 
	bool inst_flag;
	// ----- MPM setting for selected 1st range
	for (loop1 = 0; loop1 < obj->mpmCnt; loop1++)
	{
		MPM ^mpm = (MPM ^)obj->mpms->GetValue(loop1);
		// set Range for MPM
		if (obj->Flag_215)
		{
			inst_error = mpm->Set_Range(1);
			//inst_error = mpm->Set_READ_Range_Mode(MPM::READ_Range_Mode::Auto);
		}
		else
		{
			//inst_error = mpm->Set_READ_Range_Mode(MPM::READ_Range_Mode::Manual);
			inst_error = mpm->Set_Range((int)obj->Meas_rang->GetValue(0));
		}

		if ((inst_error != 0))
		{
			Show_Inst_Error(inst_error);
			return;
		}
	}

	// ----Move to start wavelength with Sweep Start method.
	inst_error = obj->tsl->Sweep_Start();
	if (inst_error != 0) {
		Show_Inst_Error(inst_error);
	}
	if (chkeach_ch)
		// Reference measurement one channel at a time
		inst_error = Each_channel_reference(inst_flag);
	else
		inst_error = All_channel_reference(inst_flag);

	if (inst_error != 0)
	{
		if (inst_error == -9999)
			MessageBox(GetForegroundWindow(), _T("MPM Trigger receive error! Please check trigger cable connection."), _T("prompt message"), MB_OK);
		else if (inst_flag == true)
			Show_Inst_Error(inst_error);             // Instullment error
		else
			Show_STS_Error(inst_error);// Processing error
		return;
	}

	inst_error = obj->tsl->Sweep_Stop();
	if (inst_error != 0)
		Show_Inst_Error(inst_error);
	MessageBox(GetForegroundWindow(), _T("Completed."), _T("prompt message"), MB_OK);
}

int Save_Measurement_data()
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// -------------------------------------------------------
	// Save Measurement data
	// -------------------------------------------------------
	cli::array<double> ^wavelength_table;            // Rescaled wavelength table  
	cli::array<cli::array<float>^> ^lstILdata;      // IL data list 
	int process_error;                               // process class error  
	cli::array<float> ^ildata;                      // il data arrray

	// Get Rescaled wavelength tabel 
	process_error = obj->cal_sts->Get_Target_Wavelength_Table(wavelength_table);

	// Get IL data 
	if (obj->Flag_215 == true)
	{
		lstILdata = gcnew cli::array<cli::array<float>^>(obj->Data_struct->Length);
		for (int i = 0; i < obj->Data_struct->Length; i++)
		{
			ildata = gcnew cli::array<float>(1);
			STSDataStruct items = (STSDataStruct)obj->Data_struct->GetValue(i);
			process_error = obj->cal_sts->Get_IL_Data(ildata, items);
			if (process_error != 0)
				return process_error;

			lstILdata->SetValue(ildata, i);
		}
	}
	else {
		lstILdata = gcnew cli::array<cli::array<float>^>(obj->Mergedata_struct->Length);
		for (int i = 0; i < obj->Mergedata_struct->Length; i++)
		{
			ildata = gcnew cli::array<float>(1);
			STSDataStructForMerge items = (STSDataStructForMerge)obj->Mergedata_struct->GetValue(i);
			process_error = obj->cal_sts->Get_IL_Merge_Data(ildata, items);
			if (process_error != 0)
				return process_error;

			lstILdata->SetValue(ildata, i);
		}
	}


	// -----Data Save 
	std::string path = msclr::interop::marshal_as<std::string>(obj->filepath->ToString());

	String^ write_string = "";
	std::ofstream file(path);
	if (file)
	{

		for (int loop1 = 0; loop1 < wavelength_table->Length; loop1++)
		{
			char wlBuffer[150];
			sprintf_s(wlBuffer, "%.7f", (double)wavelength_table->GetValue(loop1));
			String ^wlStr = gcnew String(wlBuffer);
			write_string = wlStr;

			for (int loop2 = 0; loop2 < lstILdata->Length; loop2++) {

				char buffer[150];
				sprintf_s(buffer, "%.7f", (double)((cli::array<double>^)lstILdata->GetValue(loop2))->GetValue(loop1));
				String ^s = gcnew String(buffer);
				write_string = write_string + "," + s;

			}

			char* cContent = (char*)(void*)Marshal::StringToHGlobalAnsi(write_string);
			char strContent[10000];
			sprintf(strContent, "%s", write_string); //%.6lf\n  d=lf
			file << strContent << "\n";
		}
	}
	file.close();
	return 0;
}

int Get_measurement_samplingdata(int sweepcount, PCU::SOP_Stauts currentSOP, bool inst_flag)
{
	// ---------------------------------------------------------------
	// Get logging measurement data & add in 
	// ---------------------------------------------------------------
	int inst_error;                        // Instullment error
	//cli::array<double> ^logg_data;         // MPM Logging data
	int cal_error;                         // process error
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	// ----Load　measurement MPM data & add  in data for STS Process Class for each channel
	for (int i = 0; i < obj->Data_struct->Length; i++)
	{

		STSDataStruct item = (STSDataStruct)obj->Data_struct->GetValue(i);
		if ((item.SweepCount != sweepcount) || (item.SOP != (int)currentSOP))
			continue;

		// Load corresponded MPM channel data
		inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber);

		if (inst_error != 0)
		{
			inst_flag = true;
			return inst_error;
		}

		// Add in to MPM reference data to STS Process Class
		cal_error = obj->cal_sts->Add_Meas_MPMData_CH(obj->logg_data, item);

		if (cal_error != 0)
		{
			inst_flag = false;
			return cal_error;
		}
	}

	// Load monitor data
	cli::array<float> ^triggerdata;               // trigger timming data
	cli::array<float> ^monitordata;               // monitor data
	inst_error = obj->spu->Get_Sampling_Rawdata(triggerdata, monitordata);

	if (inst_error != 0)
	{
		inst_flag = true;
		return inst_error;
	}

	// -- Add measurement monitor data associated with parameters of the same SOP & sweep count
	for (int i = 0; i < obj->Meas_monitordata_struct->Length; i++)
		//foreach(STSDataStruct monitor_item in Meas_monitordata_struct)
	{
		STSMonitorStruct monitor_item = (STSMonitorStruct)obj->Meas_monitordata_struct->GetValue(i);

		if (monitor_item.SweepCount == sweepcount && monitor_item.SOP == (int)currentSOP)
		{
			cal_error = obj->cal_sts->Add_Meas_MonitorData(triggerdata, monitordata, monitor_item);
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

extern "C" __declspec(dllexport) int PDL_Muller_AndSave(char* path)
{
	// -----Save Mueller data ??--------------------------------------
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	int cal_error;
	cli::array<double>^ m11 = nullptr;
	cli::array<double>^ m12 = nullptr;
	cli::array<double>^ m13 = nullptr;
	cli::array<double>^ m14 = nullptr;
	cli::array<double> ^wavetable;                  // Target　Wavelength table

	// ------------------------------------------
	// m11 = (H+V)/2
	// m12 = (H-V)/2
	// m13 = 45-m11
	// m14 = RC-m11
	// -------------------------------------------
	// Load mueller parameter
	cal_error = obj->cal_sts->Get_Target_Wavelength_Table(wavetable);

	cal_error = obj->cal_sts->Get_Mueller_Raw_Data(m11, m12, m13, m14);
	String^ tempPath = gcnew String(path);
	String ^writestr = String::Empty;
	if (cal_error != 0)
	{
		return cal_error;
	}

	// file save

	System::IO::StreamWriter^writer = gcnew System::IO::StreamWriter(tempPath, false, System::Text::Encoding::GetEncoding("UTF-8"));
	// hedder

	writestr = "Wavelength(nm),m11(mW),m12(mW),m13(mW),m14(mW)";

	writer->WriteLine(writestr);

	for (int loop3 = 0; loop3 <= wavetable->GetUpperBound(0); loop3++)
	{
		writestr = Convert::ToString(wavetable[loop3]) + "," + Convert::ToString(m11[loop3]) + "," + Convert::ToString(m12[loop3]) + "," + Convert::ToString(m13[loop3]) + "," + Convert::ToString(m14[loop3]);
		writer->WriteLine(writestr);
	}
	writer->Close();
	return 0;
}

int PDL_Process_AndSave(char* fileName)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// -----------------------------------------------------
	// STS PDL Process
	// -----------------------------------------------------
	cli::array<double> ^wavetable;                  // Target　Wavelength table
	int inst_error;                            // instrument error
	cli::array<float, 3> ^correctionSOP;            // Correnction SOP data for wavelength  (wavelengthindex,SOP,Sop vector position)
	int cal_error;                             // Process class error



	// ----------------------------------------------------------------------------
	// 1. Get target wavelength table from Process class
	// 2. pass wavelength table & recive calcureted correction SOP array(3D)
	// 3. pass correction SOP array for Prosecc class
	// 4. Get processed IL data from Prosecc class
	// 5. Calculate PDL & IL & ILmax & ILmin from 4.data 
	// --------------------------------------------------------------------------
	// 1
	cal_error = obj->cal_sts->Get_Target_Wavelength_Table(wavetable);
	if (cal_error != 0)
	{
		//Show_STS_Error(cal_error);
		return cal_error;
	}

	// 2
	inst_error = obj->pcu->Cal_All_SOP_Parametar(wavetable, correctionSOP);

	if (inst_error != 0)
	{
		//Show_Inst_Error(inst_error);
		return cal_error;
	}


	// 3 
	cal_error = obj->cal_sts->Add_PCU_CalData(correctionSOP);
	if (cal_error != 0)
	{
		//Show_STS_Error(cal_error);
		return cal_error;
	}

	// 4
	int loop1;
	int loop2;
	int loop3;
	cli::array<float> ^ildata;
	STSDataStructForMerge get_struct;
	STSDataStructForMerge befor_struct;
	//STSDataStruct items;             //befor struct

	cli::array<float, 2> ^SOPIL;
	cli::array<float> ^calPDL;
	cli::array<float> ^calIL;
	cli::array<float> ^calILmax;
	cli::array<float> ^calILmin;

	String^ fpath = "";
	//System.IO.StreamWriter writer;
	String^ writestr = "";

	SOPIL = gcnew cli::array<float, 2>(4, wavetable->Length);

	for each (STSDataStructForMerge item in obj->Mergedata_struct)
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

			cal_error = obj->cal_sts->Get_IL_Merge_Data(ildata, get_struct);

			if (cal_error != 0)
			{
				return cal_error;
			}

			// 1Ddata ->2D data array
			for (loop2 = 0; loop2 <= ildata->GetUpperBound(0); loop2++)
				SOPIL[loop1, loop2] = ildata[loop2];
		}

		befor_struct = get_struct;

		// 5.Calcurate of PDL 
		cal_error = obj->cal_sts->Cal_PDL(SOPIL, calPDL, calIL, calILmax, calILmin);

		if (cal_error != 0)
		{
			//Show_STS_Error(cal_error);
			return cal_error;
		}
		String^ tempPath = gcnew String(fileName);
		if (tempPath != "")
		{
			tempPath = tempPath->Insert(tempPath->Length - 4, "_MPM" + (item.MPMNumber+1).ToString()+"_Slot" + item.SlotNumber.ToString() + "_Ch" + item.ChannelNumber.ToString());

			// --File save at same range data 
			// hedder
			System::IO::StreamWriter^writer = gcnew System::IO::StreamWriter(tempPath, false, System::Text::Encoding::GetEncoding("UTF-8"));

			writestr = "Wavelength(nm),IL(dB),PDL(dB),ILMax(dB),ILMin(dB)";

			writer->WriteLine(writestr);

			for (loop3 = 0; loop3 <= wavetable->GetUpperBound(0); loop3++)
			{
				writestr = Convert::ToString(wavetable[loop3]) + "," + Convert::ToString(calIL[loop3]) + "," + Convert::ToString(calPDL[loop3]) + "," + Convert::ToString(calILmax[loop3]) + "," + Convert::ToString(calILmin[loop3]);
				writer->WriteLine(writestr);
			}
			writer->Close();
		}
	}
	return 0;
}


extern "C" __declspec(dllexport) void Measure(bool sop2Flag, char* fileName)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// -------------------------------------------------------------------------
	// Mesurement Process
	// -------------------------------------------------------------------------
	int loop1;                        // loop Count 1
	int loop2;                        // Loop count 2
	int inst_error;                   // instllment error   
	bool inst_flag = new bool();                    // instrment error flag
	int soploop;                      // SOP loop count 
	PCU::SOP_Stauts *setSOP = new PCU::SOP_Stauts();                // setting SOP
	int sweepcounter = 0;                 // Sweep counter 

	// -------Measurement-----------------------------------------------
	obj->cal_sts->Clear_Measdata();

	// Move to start wavelength  with Sweep Start method.
	inst_error = obj->tsl->Sweep_Start();
	if (inst_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}

	// --------Rang Loop
	for (loop1 = 0; loop1 < obj->rangeCnt; loop1++)
	{

		// MPM range Setting 
		for (loop2 = 0; loop2 < obj->mpmCnt; loop2++)
		{
			MPM ^mpm = (MPM^)obj->mpms->GetValue(loop2);
			if (obj->Flag_215) {
				inst_error = mpm->Set_Range(1);
				//inst_error = mpm->Set_READ_Range_Mode(MPM::READ_Range_Mode::Auto);

			}
			else {
				//inst_error = mpm->Set_READ_Range_Mode(MPM::READ_Range_Mode::Manual);
				inst_error = mpm->Set_Range((int)obj->Meas_rang->GetValue(loop1));
			}


			if (inst_error != 0)
			{
				Show_Inst_Error(inst_error);
				return;
			}
		}

		// Lower range & if checked "2SOP for low power range"
		if (sop2Flag && loop1 != 0)
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
				*setSOP = PCU::SOP_Stauts::LVP;
				break;
			}

			case 1:
			{
				*setSOP = PCU::SOP_Stauts::LHP;
				break;
			}

			case 2:
			{
				*setSOP = PCU::SOP_Stauts::LP45;
				break;
			}

			case 3:
			{
				*setSOP = PCU::SOP_Stauts::RCP;
				break;
			}
			}


			// SOP Setting 
			inst_error = obj->pcu->Set_SOP_Stauts(*setSOP);
			if (inst_error != 0)
			{
				Show_Inst_Error(inst_error);
				return;
			}

			// Sweep process
			inst_error = Sweep_Process();
			if (inst_error != 0 && inst_error != -9999)
			{
				Show_Inst_Error(inst_error);
				return;
			}

			if (inst_error == -9999)
			{
				MessageBox(GetForegroundWindow(), _T("MPM Trigger receive error! Please check trigger cable connection."), _T("prompt message"), MB_OK);

				return ;
			}

			// Move to start wavelength  with Sweep Start method for next sweep.
			inst_error = obj->tsl->Sweep_Start();
			if (inst_error != 0)
			{
				Show_Inst_Error(inst_error);
				return;
			}

			// get loggging data & Add in STS Process class
			inst_error = Get_measurement_samplingdata(sweepcounter + 1, *setSOP, inst_flag);

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

	// ----------STS Process-------------------------------------------------

	int process_error;                    // STS　Process error

	// Rescaling
	process_error = obj->cal_sts->Cal_MeasData_Rescaling();

	if (process_error != 0)
	{
		Show_STS_Error(process_error);
		return;
	}

	// merge or IL calculate
	Module_Type merge_type;

	if (obj->Flag_215 == true)
	{
		merge_type = Module_Type::MPM_215;
	}
	else if (obj->Flag_213 == true)
	{
		merge_type = Module_Type::MPM_213;
	}
	else
	{
		merge_type = Module_Type::MPM_211;
	}
	// Process ranges merge
	process_error = obj->cal_sts->Cal_IL_Merge(merge_type);

	// tsl Sweep Stop
	inst_error = obj->tsl->Sweep_Stop();

	// -----PDL Calcurete process-------------------------------------------
	process_error = PDL_Process_AndSave(fileName);
	if (process_error != 0)
	{
		Show_Inst_Error(inst_error);
		return;
	}
	MessageBox(GetForegroundWindow(), _T("Completed."), _T("prompt message"), MB_OK);
}

int check_sweepcount(int rangenumber, int sopcount)
{
	// ---------------------------------------------------------------------------
	// Return Sweep count for range and SOP status
	// ----------------------------------------------------------------------------
	int loop1;
	int sweepcount;
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	for (loop1 = 0; loop1 < obj->rangeCnt; loop1++)
	{
		if (obj->Meas_rang[loop1] == rangenumber)
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
				// 3rd range rangeCnt   Sop2Flag    
				if (obj->chk2scan == true)
					sweepcount = 6 + sopcount + 1;
				else
					sweepcount = 8 + sopcount + 1;
				return sweepcount;
			}

			case 3:
			{
				// 4th range
				if (obj->chk2scan == true)
					sweepcount = 8 + sopcount + 1;
				else
					sweepcount = 12 + sopcount + 1;
				return sweepcount;
			}

			case 4:
			{
				// 5th range
				if (obj->chk2scan == true)
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

extern "C" __declspec(dllexport) void saveRawdata(char* path, int rangenumber, bool sop2Flag)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	// -------------------------------------------------------------------------
	// Save mesurement raw data
	// -------------------------------------------------------------------------
	int loop1;                                        // loop1
	int loop2;                                        // loop2
	int loop3;                                        // loop3
	cli::array<double> ^wavelength_table;                  // Wavelength table
	cli::array<float> ^monitordata;
	cli::array<float> ^ powerdata;                         // Power data array

	int errorcode;                                    // Errorcode
	// -- Get Wavelength table
	errorcode = obj->cal_sts->Get_Target_Wavelength_Table(wavelength_table);

	if (errorcode != 0)
	{
		Show_STS_Error(errorcode);
		return;
	}

	// ---check to range number 1st  or not & data exist
	bool first_rangeflag = new bool();
	bool exist_flag = false;

	for each(auto item in obj->Data_struct)
	{
		if (item.RangeNumber > rangenumber)
			first_rangeflag = true;
		// exist or not 
		if (item.RangeNumber == rangenumber)
			exist_flag = true;
	}

	if (exist_flag == false)
	{
		MessageBox(GetForegroundWindow(), _T("Range data is not exist."), _T("prompt message"), MB_OK);
		return;
	}

	String^ write_string;
	String^ hedder;
	int sopcount;
	String^ sop_string;
	int loopcount = 0;
	int sweepcount;


	// low range & 2scan 
	if (first_rangeflag == false && sop2Flag)
		sopcount = 1;                            // 2Scan data
	else
		sopcount = 3;// 4Scan data

	cli::array<cli::array<float>^> ^lstpower;
	// ----Save designated range measurement raw data  for each SOP---------------------------

	for (loop1 = 0; loop1 <= sopcount; loop1++)
	{
		loopcount = 0;
		lstpower = gcnew cli::array<cli::array<float>^>(obj->channelCnt);
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
			sop_string = "45 Degree Linear";
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
		String ^temp = L"Save Range" + rangenumber + L"_" + sop_string + L"SOP data";
		String^ tempPath = gcnew String(path);
		tempPath = tempPath->Insert(tempPath->Length - 4, temp);
		System::IO::StreamWriter^ writer = gcnew System::IO::StreamWriter(tempPath, false, System::Text::Encoding::GetEncoding("UTF-8"));
		hedder = "Wavelength(nm)";

		// sarch for match  data from "STSDataStruct"---------------------------------
		//-for power data
		loop2 = 0;
		for each(STSDataStruct item in obj->Data_struct)
		{
			if ((item.SOP != loop1) | (item.RangeNumber != rangenumber))
				continue;
			powerdata = gcnew cli::array<float>(0);
			// Load measurement raw data
			errorcode = obj->cal_sts->Get_Meas_Power_Rawdata(item, powerdata);

			if (errorcode != 0)
			{
				Show_STS_Error(errorcode);
				return;
			}

			lstpower->SetValue(powerdata, loop2);
			loop2++;
			hedder = hedder + "," + "mpm" + Convert::ToString(item.MPMNumber + 1) + "Slot" + Convert::ToString(item.SlotNumber) + "Ch" + Convert::ToString(item.ChannelNumber);
		}

		hedder = hedder + ",Monitordata";
		writer->WriteLine(hedder);

		// --for monitor data
		for each(STSMonitorStruct item in obj->Meas_monitordata_struct)
		{
			if (item.SOP != loop1 || item.SweepCount != sweepcount)
				continue;

			errorcode = obj->cal_sts->Get_Meas_Monitor_Rawdata(item, monitordata);

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
	MessageBox(GetForegroundWindow(), _T("Completed."), _T("prompt message"), MB_OK);
}

extern "C" __declspec(dllexport) void savecalil(char* path)
{
	// ------------------------------------------------------------------------------
	// Save Calculated IL (Cancel for SOP wavelength dependence)
	// This method must be run after the PDL Calculation
	// ------------------------------------------------------------------------------
	String ^fpath = String::Empty;// filepath
	int errorcode;
	cli::array<float, 2>^ cal_IL = nullptr;
	cli::array<double>^ wavelengthdata = nullptr;
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();

	// Load Wavelength data 
	errorcode = obj->cal_sts->Get_Target_Wavelength_Table(wavelengthdata);

	if (errorcode != 0)
	{
		Show_STS_Error(errorcode);
		return;
	}

	// Get Calculated IL
	errorcode = obj->cal_sts->Get_Calibrated_IL(cal_IL);

	if (errorcode != 0)
	{
		Show_STS_Error(errorcode);
		return;
	}
	// Data save
	String^ tempPath = gcnew String(path);
	System::IO::StreamWriter^ writer = gcnew System::IO::StreamWriter(tempPath, false, System::Text::Encoding::GetEncoding("UTF-8"));               // writer 
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
	MessageBox(GetForegroundWindow(), _T("Completed."), _T("prompt message"), MB_OK);
}

extern "C" __declspec(dllexport) int disconnectMPM() {

	int retval = 0;
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	for (int i = 0; i < obj->mpmCnt; i++) {
		retval = retval + obj->mpms[i]->DisConnect();
	}
	obj->mpmCnt = 0;
	obj->rangeCnt = 0;
	obj->channelCnt = 0;
	obj->mpms = gcnew cli::array <MPM^>(5);
	obj->rangeList = gcnew cli::array<int>(5);
	obj->channelList = gcnew cli::array<int>(100);
	return retval;
}

extern "C" __declspec(dllexport) int disconnectPCU() {

	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	return obj->pcu->DisConnect();
}

extern "C" __declspec(dllexport) int disconnectTSL() {

	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	return obj->tsl->DisConnect();
}

extern "C" __declspec(dllexport) int disconnectDAQ() {

	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	return obj->spu->DisConnect();
}

extern "C" __declspec(dllexport) void saveReference(char* path, bool chkeach_ch)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
	// ---------------------------------------------------------------------------
	// Save reference Raw data
	// ---------------------------------------------------------------------------
	int loop1;                        // loop count1   
	int loop2;                        // loop count2
	int loop3;                        // loop count3
	int process_error;                // process class error
	cli::array<double> ^wavetable;         // wavelength table

	cli::array<float> ^monitordata;       // monitordata rescaled 
	cli::array< cli::array<float>^> ^lstpowdata;     // Power data list 
	cli::array<cli::array<float>^>^ lstmonitordata;     // monitor data list 

	// ---- Get reference Raw data (after the rescaling)

	// Get Target wavelengt table
	process_error = obj->cal_sts->Get_Target_Wavelength_Table(wavetable);

	if (process_error != 0)
	{
		Show_STS_Error(process_error);
		return;
	}

	// -------Load Each SOP data & Save
	String^ fpath = String::Empty;                  // file path 
	String^ hedder = String::Empty;                 // file hedder 
	String^ write_str = String::Empty;              // write string 
	String^ sop_string = String::Empty;             // SOP String 
	System::IO::StreamWriter ^writer;
	cli::array<float>^ powdata = nullptr;           // powerdata  rescaled    

	// Save each SOP reference data files.
	for (loop1 = 0; loop1 <= 3; loop1++)
	{
		int counter = 0;
		String ^temp = L"_SOP" + (loop1 + 1);
		String^ tempPath = gcnew String(path);
		tempPath = tempPath->Insert(tempPath->Length - 4, temp);
		lstpowdata = gcnew cli::array<cli::array<float>^>(obj->Refdata_struct->Length / 4);
		lstmonitordata = gcnew cli::array<cli::array<float>^>(obj->Ref_monitordata_struct->Length / 4);

		hedder = "";
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
		writer = gcnew System::IO::StreamWriter(tempPath, false, System::Text::Encoding::GetEncoding("UTF-8"));

		hedder = "Wavelength(nm)";
		loop2 = 0;
		// Load matched SOP raw data form Processing class
		//--for power data & hedder
		for each(STSDataStruct item in obj->Refdata_struct)
		{
			if (item.SOP != loop1)
				continue;
			powdata = gcnew cli::array<float>(0);
			// monitor data is 1 data for each sweep. It can be overwrite.
			process_error = obj->cal_sts->Get_Ref_Power_Rawdata(item, powdata);
			if (process_error != 0)
			{
				Show_STS_Error(process_error);
				return;
			}

			lstpowdata->SetValue(powdata, loop2);
			loop2++;
			hedder = hedder + ",MPM" + Convert::ToString(item.MPMNumber + 1) + "Slot" + Convert::ToString(item.SlotNumber) + "Ch" + Convert::ToString(item.ChannelNumber);
		}
		if (chkeach_ch)
		{
			for each(STSDataStruct item in obj->Refdata_struct)
			{
				if (item.SOP != loop1)
					continue;
				hedder = hedder + ",Monitor_MPM" + Convert::ToString(item.MPMNumber + 1) + "Slot" + Convert::ToString(item.SlotNumber) + "Ch" + Convert::ToString(item.ChannelNumber);
			}
		}
		else
			hedder = hedder + ",Monitor";

		writer->WriteLine(hedder);

		STSDataStruct *get_struct = new STSDataStruct();                 // struct of get
		STSDataStruct *befor_struct = new STSDataStruct();          // befor struct
		loop2 = 0;
		// --for monitor data
		for each(STSDataStruct item in obj->Ref_monitordata_struct)
		{
			if (chkeach_ch)
			{
				if ((item.MPMNumber == befor_struct->MPMNumber) & (item.SlotNumber == befor_struct->SlotNumber) & (item.ChannelNumber == befor_struct->ChannelNumber) | item.SOP != loop1)
					continue;
			}

			if (item.SOP != loop1)
				continue;
			monitordata = gcnew cli::array<float>(0);

			process_error = obj->cal_sts->Get_Ref_Monitor_Rawdata(item, monitordata);

			if (process_error != 0)
			{
				Show_STS_Error(process_error);
				return;
			}
			get_struct->MPMNumber = item.MPMNumber;
			get_struct->SlotNumber = item.SlotNumber;
			get_struct->ChannelNumber = item.ChannelNumber;
			get_struct->SOP = item.SOP;
			lstmonitordata->SetValue(monitordata, loop2);
			loop2++;
			befor_struct = get_struct;

		}
		//data write 
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
	MessageBox(GetForegroundWindow(), _T("Completed."), _T("prompt message"), MB_OK);

}

extern "C" __declspec(dllexport) void loadReference(char* path, bool chkeach_ch)
{
	librayForMFCPDL::Class1 ^obj = librayForMFCPDL::Class1::get_instance();
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
		String^ tempPath = gcnew String(path);
		tempPath = tempPath->Remove(tempPath->Length - 5, 1)->Insert(tempPath->Length - 5, (sop_loop + 1).ToString());
		reader = gcnew System::IO::StreamReader(tempPath);
		String ^read_st = String::Empty;                            // Read String 
		cli::array<String^> ^split_st = nullptr;                              // split strin array

		// hedder Read 
		read_st = reader->ReadLine();
		read_st = read_st->Trim();
		split_st = read_st->Split(',');

		int ch_count;                   // file data ch count 
		int loop1;                                            // Loop count1
		String ^chk_str = String::Empty;                            // check string
		int mpm_number;                                       // mpm number
		int slot_number;                                      // Slot number
		int ch_number;                                        // ch number 
		if (chkeach_ch)
		{
			//Reference measurement one channel at a time
			ch_count = (split_st->Length - 1) / 2;
		}
		else
		{
			ch_count = split_st->Length - 2;
		}
		// Check data cout 
		if (ch_count != obj->channelCnt)
		{
			MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
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
			mpm_number = Convert::ToInt32(chk_str) - 1;

			// mpm Slot number 
			chk_str = split_st[loop1]->Substring(8, 1);
			slot_number = Convert::ToInt32(chk_str);

			// mpm Ch number 
			chk_str = split_st[loop1]->Substring(11, 1);
			ch_number = Convert::ToInt32(chk_str);

			// Check exsist data in data struct 
			for each(STSDataStruct item in obj->Refdata_struct)
			{
				if (item.MPMNumber == mpm_number & item.SlotNumber == slot_number & item.ChannelNumber == ch_number & item.SOP == sop_loop)
				{
					match_flag = true;
					break;
				}
			}

			if (match_flag == false)
			{
				MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
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
		if (chkeach_ch)
		{
			cli::array<cli::array<float>^> ^ power;                 // Power data list 
			cli::array<cli::array<float>^> ^ monitor;                 // Power data list 
			int counter = 0;                         // Counter
			double wavelength;                       // Read Wavelength 

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
					if (Convert::ToDouble(split_st[0]) != obj->startWaveLength)
					{
						MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
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
			if (wavelength != obj->stopWaveLength)
			{
				MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
				return;
			}

			// check number of point 


			int datapoint;                            // number of data point 

			datapoint = (int)(Math::Abs(obj->stopWaveLength - obj->startWaveLength) / obj->stepWaveLength) + 1;

			if (datapoint != monitor[0]->Length)
			{
				MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
				return;
			}


			// -------Add in  data to STS Process class
			int errorcode;                            // Errorcode
			counter = 0;

			for each(auto item in lst_refdata_struct)
			{
				// Add in reference data of rescaled.
				errorcode = obj->cal_sts->Add_Ref_Rawdata(power[counter], monitor[counter], item);

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
				if (read_st==nullptr)
					break;
				read_st = read_st->Trim();
				split_st = read_st->Split(',');

				// Check Start Wavelength 
				if (counter == 0)
				{
					if (Convert::ToDouble(split_st[0]) != obj->startWaveLength)
					{
						MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
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
			if (wavelength != obj->stopWaveLength)
			{
				MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
				return;
			}

			// check number of point 

			int datapoint;                            // number of data point 

			datapoint = (int)(Math::Abs(obj->stopWaveLength - obj->startWaveLength) / obj->stepWaveLength) + 1;

			if (datapoint != monitor->Length)
			{
				MessageBox(GetForegroundWindow(), _T("Reference data mismatch.Please selecet right data."), _T("prompt message"), MB_OK);
				return;
			}
			// -------Add in  data to STS Process class
			int errorcode;                            // Errorcode
			counter = 0;

			for each(auto item in lst_refdata_struct)
			{
				// Add in reference data of rescaled.
				errorcode = obj->cal_sts->Add_Ref_Rawdata(power[counter], monitor, item);

				if (errorcode != 0)
				{
					Show_Inst_Error(errorcode);
					return;
				}
				counter = counter + 1;
			}
		}
	}
	MessageBox(GetForegroundWindow(), _T("Completed."), _T("prompt message"), MB_OK);
}



