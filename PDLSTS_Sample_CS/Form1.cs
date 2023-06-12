using Santec;
using Santec.STSProcess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDLSTS_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TSL tsl = new TSL();                                              // tsl Control Class
        private MPM[] mpm;                                                // mpm Control Class
        private SPU spu = new SPU();                                              // spu Control Class
        private PCU pcu = new PCU();                                              // pcu Control Class
        private PDLSTS Cal_STS = new PDLSTS();                                       // STS Calucrate Class   PDLSTS Class -> Sub class of ILSTS   
        private List<STSDataStruct> Data_struct = new List<STSDataStruct>();                   // STS data Struct for Measure
        private List<STSDataStruct> Refdata_struct = new List<STSDataStruct>();                // STS data Struct for Reference
        private List<STSDataStructForMerge> Mergedata_struct = new List<STSDataStructForMerge>();      // Data struct for merge  
        private List<STSDataStruct> Ref_monitordata_struct = new List<STSDataStruct>();        // STS Monitor data Struct for Reference
        private List<STSMonitorStruct> Meas_monitordata_struct = new List<STSMonitorStruct>();       // STS Monitor data struct for Measure
        private List<int> Meas_rang = new List<int>();                           // Measurement Range 
        private bool Flag_213;                                         // Exist 213 flag      T: Exist F: nothing
        private bool Flag_215;                                         // Exist 215 flag      T: Exist F: nothing 

        private void btnset_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------------------------------
            // Set Parameter
            // --------------------------------------------------------------------------
            double startwave;             // Startwavelength(nm)
            double stopwave;              // Stopwavelength(nm)
            double set_pow;               // Power(dBm)
            double wavestep;              // wavelenthg step(nm)
            double speed;                 // Sweep Speed (nm/sec)
            int inst_error;           // instullment error



            startwave = Convert.ToDouble(txtstartwave.Text);
            stopwave = Convert.ToDouble(txtstopwave.Text);
            wavestep = Convert.ToDouble(txtstepwave.Text);
            speed = Convert.ToDouble(cmbspeed.Text);
            set_pow = Convert.ToDouble(txtpower.Text);



            // ---------tsl Setting--------------------------------------------------- 
            double tsl_acctualstep = new double();          // tsl output trigger step(nm)


            // set Power
            inst_error = tsl.Set_APC_Power_dBm(set_pow);
            if (inst_error != 0)
            {
                Show_Inst_Error(inst_error);
                return;
            }

            // set Sweep parameter
            inst_error = tsl.Set_Sweep_Parameter_for_STS(startwave, stopwave, speed, wavestep, ref tsl_acctualstep);
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

            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
            {
                // Sweep parameter setting 
                inst_error = mpm[loop1].Set_Logging_Paremeter_for_STS(startwave, stopwave, wavestep, speed, Santec.MPM.Measurement_Mode.Freerun);
                if (inst_error != 0)
                {
                    Show_Inst_Error(inst_error);
                    return;
                }
            }

            // ---spu setting ----------------------------------------------------------------
            double averaging_time = new double();

            // Get mpm averaging time
            inst_error = mpm[0].Get_Averaging_Time(ref averaging_time);

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
            sts_error = Cal_STS.Set_Rescaling_Setting(RescalingMode.Freerun_SPU, averaging_time, true);

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
            if (chkeach_ch.Checked == true)
            {
                Prepare_dataST_Each();
            }
            else
            {
                Prepare_dataST();
            }

            MessageBox.Show("Completed.");
        }

        private void Prepare_dataST()
        {
            // ----------------------------------------------
            // Prepar STS data struct
            // -----------------------------------------------
            int rangecout;                        // number of range
            int chcount;                          // number of ch 
            int chloop;                            // loop count1
            int rangeloop;                            // loop count2
            int soploop;                       //sop loop
            string text_st = string.Empty;            // text String 
            string[] split_st = null;              // split string array

            // -----Clear List data
            Meas_rang.Clear();
            Data_struct.Clear();
            Refdata_struct.Clear();
            Ref_monitordata_struct.Clear();
            Meas_monitordata_struct.Clear();
            Mergedata_struct.Clear();

            rangecout = chklst_range.CheckedItems.Count;   // number of range
            chcount = chklst_ch.CheckedItems.Count;        // number of channel
            if (Flag_215 == true)
                //If mom215 range must be set 1
                Meas_rang.Add(1);
            else
            {
                if (rangecout == 0 | chcount == 0)
                {
                    MessageBox.Show("Please check measurement parameters.");
                    return;
                }
                // hold  data of range number  
                for (int loop1 = 0; loop1 <= chklst_range.Items.Count - 1; loop1++)
                {
                    if (chklst_range.GetItemChecked(loop1) == true)
                        Meas_rang.Add(loop1 + 1);
                }
            }
            // Add in measurement condition of Data structure 
            int sopcount;
            int device_number;                        // mpm device number
            int slot_number;                           // mpm Slot number
            int ch_number;                            // mpm channel number
            STSDataStruct set_struct = new STSDataStruct();                     // Data struct for STS data hold
            int sweep_count = 1;                         // Sweep counter 


            // for measurement power data
            for (chloop = 0; chloop <= chklst_ch.Items.Count - 1; chloop++)
            {
                if (chklst_ch.GetItemChecked(chloop) == true)
                {

                    // ch parameter
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;
                    slot_number = Convert.ToInt32(split_st[1].Substring(4));
                    ch_number = Convert.ToInt32(split_st[2].Substring(2));

                    set_struct.MPMNumber = device_number;
                    set_struct.SlotNumber = slot_number;
                    set_struct.ChannelNumber = ch_number;

                    for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)
                    {
                        if (chk2scan.Checked == true & rangeloop != 0)
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

            // for reference power data & mergedata 
            STSDataStructForMerge set_merge_struct = new STSDataStructForMerge();
            set_struct = new STSDataStruct();
            sweep_count = 1;
            for (chloop = 0; chloop <= chklst_ch.Items.Count - 1; chloop++)
            {
                if (chklst_ch.GetItemChecked(chloop) == true)
                {


                    // ch parameter
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;
                    slot_number = Convert.ToInt32(split_st[1].Substring(4));
                    ch_number = Convert.ToInt32(split_st[2].Substring(2));
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
            STSMonitorStruct set_monitor_struct = new STSMonitorStruct();
            sweep_count = 1;

            for (chloop = 0; chloop <= chklst_ch.Items.Count - 1; chloop++)
            {
                if (chklst_ch.GetItemChecked(chloop) == true)
                {
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;

                    set_monitor_struct.MPMNumber = device_number;

                    for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)
                    {
                        if (chk2scan.Checked == true & rangeloop != 0)
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
            STSDataStruct set_ref_monitor_struct = new STSDataStruct();
            for (chloop = 0; chloop <= chklst_ch.Items.Count - 1; chloop++)
            {
                if (chklst_ch.GetItemChecked(chloop) == true)
                {
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;
                    slot_number = Convert.ToInt32(split_st[1].Substring(4));
                    ch_number = Convert.ToInt32(split_st[2].Substring(2));

                    set_ref_monitor_struct.MPMNumber = device_number;
                    set_ref_monitor_struct.SlotNumber = slot_number;
                    set_ref_monitor_struct.ChannelNumber = ch_number;
                    set_ref_monitor_struct.RangeNumber = 1       ;
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

        private void Prepare_dataST_Each()
        {
            // ----------------------------------------------
            // Prepar STS data struct
            // -----------------------------------------------
            int rangecout;                        // number of range
            int chcount;                          // number of ch 
            int chloop;                           // channel loop
            int rangeloop;                        // range loop
            int soploop;                          // sop loop
            string text_st = string.Empty;            // text String 
            string[] split_st = null;              // split string array

            // -----Clear List data
            Meas_rang.Clear();
            Data_struct.Clear();
            Refdata_struct.Clear();
            Ref_monitordata_struct.Clear();
            Meas_monitordata_struct.Clear();
            Mergedata_struct.Clear();


            rangecout = this.chklst_range.CheckedItems.Count;   // number of range
            chcount = this.chklst_ch.CheckedItems.Count;        // number of channel
            if (Flag_215 == true)
                // If mom215 range must be set 1
                Meas_rang.Add(1);
            else
            {
                if (rangecout == 0 | chcount == 0)
                {
                    MessageBox.Show("Please check measurement parameters.");
                    return;
                }
                // hold  data of range number  
                for (var loop1 = 0; loop1 <= this.chklst_range.Items.Count - 1; loop1++)
                {
                    if (this.chklst_range.GetItemChecked(loop1) == true)
                        Meas_rang.Add(loop1 + 1);
                }
            }

            // Add in measurement condition of Data structure 
            int sopcount;
            int device_number;
            int slot_number;
            int ch_number;
            STSDataStruct set_struct=new STSDataStruct();
            int sweep_count = 1;

            // for measurement power data
            for (chloop = 0; chloop <= this.chklst_ch.Items.Count - 1; chloop++)
            {
                if (this.chklst_ch.GetItemChecked(chloop) == true)
                {

                    // ch parameter
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;
                    slot_number = Convert.ToInt32(split_st[1].Substring(4));
                    ch_number = Convert.ToInt32(split_st[2].Substring(2));


                    set_struct.MPMNumber = device_number;
                    set_struct.SlotNumber = slot_number;
                    set_struct.ChannelNumber = ch_number;

                    for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)
                    {
                        if (this.chk2scan.Checked == true & rangeloop != 0)
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
            set_struct = new STSDataStruct();
            STSDataStruct set_ref_monitor_struct=new STSDataStruct();
            sweep_count = 1;
            for (chloop = 0; chloop <= this.chklst_ch.Items.Count - 1; chloop++)
            {
                if (this.chklst_ch.GetItemChecked(chloop) == true)
                {


                    // ch parameter
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;
                    slot_number = Convert.ToInt32(split_st[1].Substring(4));
                    ch_number = Convert.ToInt32(split_st[2].Substring(2));

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
            STSDataStructForMerge set_merge_struct=new STSDataStructForMerge();
            sweep_count = 1;
            for (chloop = 0; chloop <= this.chklst_ch.Items.Count - 1; chloop++)
            {
                if (this.chklst_ch.GetItemChecked(chloop) == true)
                {

                    // ch parameter
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;
                    slot_number = Convert.ToInt32(split_st[1].Substring(4));
                    ch_number = Convert.ToInt32(split_st[2].Substring(2));


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
            var set_monitor_struct = new STSMonitorStruct();
            sweep_count = 1;

            for (chloop = 0; chloop <= this.chklst_ch.Items.Count - 1; chloop++)
            {
                if (this.chklst_ch.GetItemChecked(chloop) == true)
                {
                    text_st = chklst_ch.Items[chloop].ToString();
                    split_st = text_st.Split(' ');
                    device_number = Convert.ToInt32(split_st[0].Substring(3)) - 1;

                    set_monitor_struct.MPMNumber = device_number;

                    for (rangeloop = 0; rangeloop <= Meas_rang.Count - 1; rangeloop++)
                    {
                        if (this.chk2scan.Checked == true & rangeloop != 0)
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

        private void Show_Inst_Error(int errordata)
        {
            // ------------------------------------
            // Show error code
            // ------------------------------------
            string[] errorstring = Enum.GetNames(typeof(ExceptionCode));
            int[] errorvale = (int[])Enum.GetValues(typeof(ExceptionCode));
            int loop1;

            for (loop1 = 0; loop1 <= errorvale.GetUpperBound(0); loop1++)
            {
                if (errorvale[loop1] == errordata)
                {
                    MessageBox.Show(errorstring[loop1]);
                    break;
                }
            }
        }

        private void Show_STS_Error(int errordata)
        {
            // ------------------------------------
            // Show error code for STS
            // ------------------------------------
            string[] errorstring = Enum.GetNames(typeof(ErrorCode));
            int[] errorvale = (int[])Enum.GetValues(typeof(ErrorCode));
            int loop1;

            for (loop1 = 0; loop1 <= errorvale.GetUpperBound(0); loop1++)
            {
                if (errorvale[loop1] == errordata)
                {
                    MessageBox.Show(errorstring[loop1]);
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // -------------------------------------------------------------------------
            // Form Load    (MainForm)
            // -------------------------------------------------------------------------
            string[] spudev = null;                        // spu device name
            int errorcode;                                // errorcode 
            string[] usb_resource = null;                  // usb communication resource

            // ----Check Connction of spu deviece
            errorcode = spu.Get_Device_ID(ref spudev);
            if (errorcode != 0)
            {
                Show_Inst_Error(errorcode);
                Environment.Exit(0);
            }


            // ----Check usb resource
            usb_resource = Santec.Communication.MainCommunication.Get_USB_Resouce();


            // ------show Setting Form
            Instrument_Setting set_form = new Instrument_Setting();

            set_form.Owner = this;
            set_form.SPU_Resource = spudev;
            set_form.USB_Resource = usb_resource;

            set_form.ShowDialog();

            // -------Apply to communication parametere from Instrument setting form---
            Santec.Communication.CommunicationMethod tsl_communcation_method;            // communication method for tsl
            Santec.Communication.CommunicationMethod mpm_communcation_method;            // communication method for mpm    
            Santec.Communication.CommunicationMethod pcu_communcation_method;            // communication methode for pcu


            // ----tsl　Communication setting -------------------------------------
            if (set_form.TSL_Communicater == "GPIB")
            {
                // GPIB
                tsl_communcation_method = Santec.Communication.CommunicationMethod.GPIB;
                tsl.Terminator = CommunicationTerminator.CrLf;
                tsl.GPIBAddress = Convert.ToInt32(set_form.TSL_Address);
                tsl.GPIBBoard = 0;
                tsl.GPIBConnectType = Santec.Communication.GPIBConnectType.NI4882;
            }
            else if (set_form.TSL_Communicater == "LAN")
            {
                // LAN
                tsl_communcation_method = Santec.Communication.CommunicationMethod.TCPIP;
                tsl.Terminator = CommunicationTerminator.Cr;
                tsl.IPAddress = set_form.TSL_Address;
                tsl.Port = set_form.TSL_Portnumber;
            }
            else
            {
                // USB 
                tsl_communcation_method = Santec.Communication.CommunicationMethod.USB;
                tsl.DeviceID = Convert.ToUInt32(set_form.TSL_Address);
                tsl.Terminator = CommunicationTerminator.Cr;
            }


            // ---mpm Communication setting --------------------------------------
            int loop1;
            int mpmcount;                     // mpm count


            if (set_form.MPM_Communicater == "GPIB")
                // GPIB
                mpm_communcation_method = Santec.Communication.CommunicationMethod.GPIB;
            else
                // LAN
                mpm_communcation_method = Santec.Communication.CommunicationMethod.TCPIP;

            mpmcount = set_form.MPM_Count;
            mpm = new MPM[mpmcount];
            for (loop1 = 0; loop1 <= mpmcount - 1; loop1++)
            {
                mpm[loop1] = new MPM();

                if (set_form.MPM_Communicater == "GPIB")
                    mpm[loop1].GPIBAddress = Convert.ToInt32(set_form.MPM_Address[loop1]);
                else
                {
                    mpm[loop1].IPAddress = set_form.MPM_Address[loop1];
                    mpm[loop1].Port = set_form.MPM_Portnumber[loop1];
                }

                // muximum logging data reading time = 11s
                mpm[loop1].TimeOut = 11000;
            }


            // -------pcu Communcation setting-------------------------
            if (set_form.PCU_Communicater == "GPIB")
            {
                // GPIB
                pcu_communcation_method = Santec.Communication.CommunicationMethod.GPIB;
                pcu.GPIBAddress = Convert.ToInt32(set_form.PCU_Address);
                pcu.GPIBBoard = 0;
                pcu.Terminator = CommunicationTerminator.CrLf;
            }
            else if (set_form.PCU_Communicater == "LAN"
            )
            {
                // LAN
                pcu_communcation_method = Santec.Communication.CommunicationMethod.TCPIP;
                pcu.IPAddress = set_form.PCU_Address;
                pcu.Port = set_form.PCU_Portnumber;
            }
            else
            {
                // USB
                pcu_communcation_method = Santec.Communication.CommunicationMethod.USB;
                pcu.DeviceID = Convert.ToUInt32(set_form.PCU_Address);
                pcu.Terminator = CommunicationTerminator.Cr;                     // pcu USB Command follow only "Cr"  terminator
            }


            // ----Using pcu inside DAQ or not
            if (set_form.PCU_useing_internal_DAQ == true)
                // inside 
                pcu.DeviceName = set_form.SPU_DeviveID;


            // ------spu Communcation Setting 
            spu.DeviceName = set_form.SPU_DeviveID;


            // -----Connect----------------------------------------------------------- 
            errorcode = tsl.Connect(tsl_communcation_method);                        // tsl

            if (errorcode != 0)
            {
                MessageBox.Show("tsl can't connect.Please check connection.");
                System.Environment.Exit(0);
            }


            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)                                            // mpm
            {
                errorcode = mpm[loop1].Connect(mpm_communcation_method);

                if (errorcode != 0)
                {
                    MessageBox.Show("mpm Can't connect. Please check connection.");
                    Environment.Exit(0);
                }
            }

            string ans = string.Empty;
            errorcode = spu.Connect(ref ans);                                            // spu

            if (errorcode != 0)
            {
                MessageBox.Show("spu Can't connect. Please check connection.");
                Environment.Exit(0);
            }


            errorcode = pcu.Connect(pcu_communcation_method);                        // pcu
            if (errorcode != 0)
            {
                MessageBox.Show("pcu can't connect.Please check connection.");
                Environment.Exit(0);
            }

            // -----Check Module information--------------------------------------
            errorcode = Check_Module_Information();

            if (errorcode != 0)
            {
                MessageBox.Show("System can't use mpm-215 togeter other module");
                Environment.Exit(0);
            }

            // -----------Reflect instrument parameter to Form-------------------
            Referect_EnableCh_for_form();                // mpm Eanble ch
            Referect_EnableRange_for_form();             // mpm selectable range
            Add_TSL_Sweep_Speed();                       // tsl Sweep speed(only tsl-570)
        }
        private int Add_TSL_Sweep_Speed()
        {
            // ---------------------------------------------------------
            // Add in selectable sweep speed to speed combbox
            // this function can use only tsl-570
            // ----------------------------------------------------------
            int inst_error;                       // instullment error
            double[] sweep_table = null;           // table


            // Get Sweep speed tabele
            // Except for tsl-570 "Device Error" occurre when call this function.
            inst_error = tsl.Get_Sweep_Speed_table(ref sweep_table);

            if (inst_error != 0 & inst_error != Convert.ToInt32(ExceptionCode.DeviceError))
                return inst_error;


            // -----Add in combbox when tsl-570
            int loop1;

            if (inst_error != Convert.ToInt32(ExceptionCode.DeviceError))
            {
                for (loop1 = 0; loop1 <= sweep_table.GetUpperBound(0); loop1++)

                    cmbspeed.Items.Add(sweep_table[loop1]);
            }
            return 0;
        }

        private int Check_Module_Information()
        {
            // ------------------------------------------------------------
            // check Module information inside system
            // ------------------------------------------------------------
            int loop1;
            int loop2;
            int counter_215 = new int();                           // 215 counter 

            // mpm device loop
            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
            {
                // Slot loop
                for (loop2 = 0; loop2 <= 4; loop2++)
                {
                    // Enable Slot
                    if (mpm[loop1].Information.ModuleEnable[loop2] == true)
                    {

                        // Check mpm-215 insert;
                        if (mpm[loop1].Information.ModuleType[loop2] == "MPM-215")
                        {
                            Flag_215 = true;
                            counter_215 = counter_215 + 1;
                        }

                        // Check mpm-213 insert
                        if (mpm[loop1].Information.ModuleType[loop2] == "MPM-213")
                            Flag_213 = true;
                    }
                }
            }

            // Check mpm-215 count & Module total count
            // STS system can't use 215 together other module.
            int enable_module_count = new int();                      // enable module count

            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
                enable_module_count = mpm[loop1].Information.NumberofModule + enable_module_count;// total module count

            if (Flag_215 == true)
            {
                if (enable_module_count != counter_215)
                    return -1;
            }

            return 0;
        }

        private void Referect_EnableCh_for_form()
        {
            // ------------------------------------------------
            // Reflect mpm ch 
            // ------------------------------------------------
            int loop1;
            int loop2;
            bool[] enable_slot;
            string slot_type;

            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
            {
                // get insert module count with "mpm Information" class 
                enable_slot = mpm[loop1].Information.ModuleEnable;

                // modeule loop(Maximum 5 slot)
                for (loop2 = 0; loop2 <= 4; loop2++)
                {
                    if (enable_slot[loop2] == true)
                    {
                        // get module type with "mpm Information" class 
                        slot_type = mpm[loop1].Information.ModuleType[loop2];

                        if (slot_type != "MPM-212")
                        {
                            chklst_ch.Items.Add("mpm" + Convert.ToString(loop1 + 1) + " Slot" + Convert.ToString(loop2) + " Ch1");
                            chklst_ch.Items.Add("mpm" + Convert.ToString(loop1 + 1) + " Slot" + Convert.ToString(loop2) + " Ch2");
                            chklst_ch.Items.Add("mpm" + Convert.ToString(loop1 + 1) + " Slot" + Convert.ToString(loop2) + " Ch3");
                            chklst_ch.Items.Add("mpm" + Convert.ToString(loop1 + 1) + " Slot" + Convert.ToString(loop2) + " Ch4");
                        }
                        else
                        {
                            chklst_ch.Items.Add("mpm" + Convert.ToString(loop1 + 1) + " Slot" + Convert.ToString(loop2) + " Ch1");
                            chklst_ch.Items.Add("mpm" + Convert.ToString(loop1 + 1) + " Slot" + Convert.ToString(loop2) + " Ch2");
                        }
                    }
                }
            }
        }

        private void Referect_EnableRange_for_form()
        {
            // -----------------------------------------------------
            // Refelect mpm Range
            // -------------------------------------------------------


            // mpm-213 can use just 1 to 4 range
            if (Flag_213 == true)
            {
                chklst_range.Items.Add("Range1");
                chklst_range.Items.Add("Range2");
                chklst_range.Items.Add("Range3");
                chklst_range.Items.Add("Range4");
            }
            else
            {
                chklst_range.Items.Add("Range1");
                chklst_range.Items.Add("Range2");
                chklst_range.Items.Add("Range3");
                chklst_range.Items.Add("Range4");
                chklst_range.Items.Add("Range5");
            }

            // mpm-215 can't select range
            if (Flag_215 == true)
                chklst_range.Enabled = false;
        }

        private void btnget_reference_Click(object sender, EventArgs e)
        {
            // ------------------------------------------------------------------------------
            // Get Reference
            // ------------------------------------------------------------------------------
            int inst_error;                       // Instullment error
            bool inst_flag=new bool();
            int loop1;

            // MPM setting for selected 1st range
            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
            {
                // set Range for mpm
                inst_error = mpm[loop1].Set_Range(Meas_rang[0]);
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

            if (this.chkeach_ch.Checked)
                // Reference measurement one channel at a time
                inst_error = Each_channel_reference(ref inst_flag);
            else
                inst_error = All_channel_reference(ref inst_flag);

            if (inst_error != 0)
            {
                if (inst_error == -9999)
                    MessageBox.Show("MPM Trigger receive error! Please check trigger cable connection.");
                else if (inst_flag == true)
                    Show_Inst_Error(inst_error);             // Instullment error
                else
                    Show_STS_Error(inst_error);// Processing error
                return;
            }

            inst_error = tsl.Sweep_Stop();
            if (inst_error != 0)
                Show_Inst_Error(inst_error);
            MessageBox.Show("Completed.");
        }
        private int All_channel_reference(ref bool inst_flag)
        {

            // ------------------------------------------------------------------------------
            // Get Reference
            // ------------------------------------------------------------------------------
            int inst_error;                       // Instullment error
            int loop1;
            PCU.SOP_Stauts setting_SOP=new PCU.SOP_Stauts();               // Setting SOP 


            // SOP Loop
            // SOP must to set for V -> H-> 45-> RC
            for (loop1 = 0; loop1 <= 3; loop1++)
            {
                switch (loop1)
                {
                    case 0:
                        {
                            setting_SOP = PCU.SOP_Stauts.LVP;   // LVP(0)
                            break;
                        }

                    case 1:
                        {
                            setting_SOP = PCU.SOP_Stauts.LHP;   // LHP(1)
                            break;
                        }

                    case 2:
                        {
                            setting_SOP = PCU.SOP_Stauts.LP45;  // LP45(2)
                            break;
                        }

                    case 3:
                        {
                            setting_SOP = PCU.SOP_Stauts.RCP;   // RCP(3)
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

                inst_error = Get_reference_samplingdata(ref inst_flag, setting_SOP);

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

        private int Each_channel_reference(ref bool inst_flag)
        {

            // ------------------------------------------------------------------------------
            // Get Reference
            // ------------------------------------------------------------------------------
            int inst_error;                       // Instullment error
            PCU.SOP_Stauts setting_SOP=new PCU.SOP_Stauts();               // Setting SOP 


            foreach (STSDataStruct item in Refdata_struct)
            {

                // SOP must to set for V -> H-> 45-> RC
                switch (item.SOP)
                {
                    case 0:
                        {
                            MessageBox.Show("Connect fiber to MPM" + item.MPMNumber + 1 + "_Slot" + item.SlotNumber + "_Ch" + item.ChannelNumber + ".");
                            setting_SOP = PCU.SOP_Stauts.LVP;   // LVP(0)
                            break;
                        }

                    case 1:
                        {
                            setting_SOP = PCU.SOP_Stauts.LHP;   // LHP(1)
                            break;
                        }

                    case 2:
                        {
                            setting_SOP = PCU.SOP_Stauts.LP45;  // LP45(2)
                            break;
                        }

                    case 3:
                        {
                            setting_SOP = PCU.SOP_Stauts.RCP;   // RCP(3)
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
                inst_error = Get_Each_channel_reference_samplingdata(ref inst_flag, item.MPMNumber, item.SlotNumber, item.ChannelNumber, setting_SOP, item.SweepCount);

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

        private int Get_Each_channel_reference_samplingdata(ref bool inst_flag, int currentMPMNumber, int currentSlotNumber, int currentChannelNumber, PCU.SOP_Stauts currentSOP, int currentSweepCount)
        {
            // ---------------------------------------------------------------
            // Get logging reference data & add in 
            // ---------------------------------------------------------------
            int inst_error;                        // Instullment error
            float[] logg_data = null;              // MPM Logging data
            int cal_error;                         // process error


            // ----Load　Reference MPM data & add  in data for STS Process Class for each channel
            foreach (STSDataStruct item in Refdata_struct)
            {
                if ((item.MPMNumber != currentMPMNumber | item.SlotNumber != currentSlotNumber | item.ChannelNumber != currentChannelNumber | item.SOP != (int)currentSOP))
                    continue;

                // Read corresponded  MPM channel data
                inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber,ref logg_data);

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
            float[] triggerdata = null;
            float[] monitordata = null;

            inst_error = spu.Get_Sampling_Rawdata(ref triggerdata, ref monitordata);

            if (inst_error != 0)
            {
                inst_flag = true;
                return inst_error;
            }

            // -- Add reference monitor data associated with parameters of the same SOP
            foreach (STSDataStruct monitor_item in Ref_monitordata_struct)
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
        private int Get_reference_samplingdata(ref bool inst_flag, PCU.SOP_Stauts currentSOP)
        {
            // ---------------------------------------------------------------
            // Get logging reference data & add in 
            // ---------------------------------------------------------------
            int inst_error;                        // Instullment error
            float[] logg_data = null;              // mpm Logging data
            int cal_error;                         // process error


            // ----Load　Reference mpm data & add  in data for STS Process Class for each channel
            foreach (STSDataStruct item in Refdata_struct)
            {
                if (item.SOP != (int)currentSOP)
                    continue;

                // Read corresponded  mpm channel data
                inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber, ref logg_data);

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
            float[] triggerdata = null;
            float[] monitordata = null;

            inst_error = spu.Get_Sampling_Rawdata(ref triggerdata, ref monitordata);

            if (inst_error != 0)
            {
                inst_flag = true;
                return inst_error;
            }

            // -- Add reference monitor data associated with parameters of the same SOP
            foreach (STSDataStruct monitor_item in Ref_monitordata_struct)
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

        private int Sweep_Process()
        {
            // ------------------------------------------------------------
            // Sweep Process
            // ------------------------------------------------------------
            int inst_error;               // Instullment error
            int loop1;                    // loop count 

            // mpm sampling start 
            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
            {
                inst_error = mpm[loop1].Logging_Start();
                if (inst_error != 0)
                    return inst_error;
            }

            // tsl waiting for start status 
            inst_error = tsl.Waiting_For_Sweep_Status(3000, TSL.Sweep_Status.WaitingforTrigger);

            if (inst_error != 0)
            {
                // ----error handling -> mpm Logging Stop
                for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
                    mpm[loop1].Logging_Stop();

                return inst_error;
            }

            // spu sampling start
            inst_error = spu.Sampling_Start();

            if (inst_error != 0)
            {
                // ----error handling -> mpm Logging Stop
                for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
                    mpm[loop1].Logging_Stop();

                return inst_error;
            }

            // tsl issue software trigger
            inst_error = tsl.Set_Software_Trigger();

            if (inst_error != 0)
            {
                // ----error handling -> mpm Logging Stop
                for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
                    mpm[loop1].Logging_Stop();
                return inst_error;
            }


            // spu waiting for sampling 
            inst_error = spu.Waiting_for_sampling();

            if (inst_error != 0)
            {
                // ----error handling -> mpm Logging Stop
                for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
                    mpm[loop1].Logging_Stop();
                return inst_error;
            }

            int mpm_stauts = new int();
            int mpm_count = new int();
            double timeout = 2000;                  // mpm Logging Status timeout(2000msec) after the spu sampling completed.
            Stopwatch st = new Stopwatch();
            bool mpm_complet_flag = true;
            bool isSweeping = true;

            st.Start();                                    // timer start for mpm logging status timeout.   

            // mpm waiting for sampling 
            do
            {
                for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
                {
                    inst_error = mpm[loop1].Get_Logging_Status(ref mpm_stauts, ref mpm_count);
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
            }
            while (isSweeping);

            // mpm sampling stop
            for (loop1 = 0; loop1 <= mpm.GetUpperBound(0); loop1++)
            {
                inst_error = mpm[loop1].Logging_Stop();
                if (inst_error != 0)
                    return inst_error;
            }

            // tsl Waiting for standby
            inst_error = tsl.Waiting_For_Sweep_Status(5000, TSL.Sweep_Status.Standby);

            if (inst_error != 0)
                return inst_error;
            if (mpm_complet_flag == false)
                return -9999;
            return 0;
        }

        private int Get_measurement_samplingdata(int sweepcount, PCU.SOP_Stauts currentSOP, ref bool inst_flag)
        {
            // ---------------------------------------------------------------
            // Get logging measurement data & add in 
            // ---------------------------------------------------------------
            int inst_error;                        // Instullment error
            float[] logg_data = null;              // mpm Logging data
            int cal_error;                         // process error

            // ----Load　measurement mpm data & add  in data for STS Process Class for each channel
            foreach (STSDataStruct item in Data_struct)
            {
                if ((item.SweepCount != sweepcount) | (item.SOP != (int)currentSOP))
                    continue;

                // Load corresponded mpm channel data
                inst_error = Get_MPM_Loggdata(item.MPMNumber, item.SlotNumber, item.ChannelNumber, ref logg_data);

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
            float[] triggerdata = null;               // trigger timming data
            float[] monitordata = null;               // monitor data
            inst_error = spu.Get_Sampling_Rawdata(ref triggerdata, ref monitordata);

            if (inst_error != 0)
            {
                inst_flag = true;
                return inst_error;
            }

            // -- Add measurement monitor data associated with parameters of the same SOP & sweep count
            foreach (STSMonitorStruct monitor_item in Meas_monitordata_struct)
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

        private int Get_MPM_Loggdata(int deveice, int slot, int ch, ref float[] data)
        {
            // ---------------------------------------------------------------
            // Get mpm Logg data
            // --------------------------------------------------------------
            int inst_error;

            inst_error = mpm[deveice].Get_Each_Channel_Logdata(slot, ch, ref data);
            return inst_error;
        }

        private void btnmeas_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------------------------------
            // Mesurement Process
            // -------------------------------------------------------------------------
                int loop1;                        // loop Count 
                int loop2;                        // loop count2     
                int inst_error;                   // instllment error   
                bool inst_flag = new bool();                    // instrment error flag
                int soploop;                      // SOP loop count 
                PCU.SOP_Stauts setSOP = new PCU.SOP_Stauts();                // setting SOP
                int sweepcounter = new int();                 // Sweep counter 

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
                    for (loop2 = 0; loop2 <= mpm.GetUpperBound(0); loop2++)
                    {
                        inst_error = mpm[loop2].Set_Range(Meas_rang[loop1]);

                        if (inst_error != 0)
                        {
                            Show_Inst_Error(inst_error);
                            return;
                        }
                    }


                    // Lower range & if checked "2SOP for low power range"
                    if (chk2scan.Checked == true & loop1 != 0)
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
                                    setSOP = PCU.SOP_Stauts.LVP;
                                    break;
                                }

                            case 1:
                                {
                                    setSOP = PCU.SOP_Stauts.LHP;
                                    break;
                                }

                            case 2:
                                {
                                    setSOP = PCU.SOP_Stauts.LP45;
                                    break;
                                }

                            case 3:
                                {
                                    setSOP = PCU.SOP_Stauts.RCP;
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
                            MessageBox.Show("mpm Trigger receive error! Please check trigger cable connection.");
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
                        inst_error = Get_measurement_samplingdata(sweepcounter + 1, setSOP, ref inst_flag);

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
                if (Flag_215 == true)
                    merge_type = Module_Type.MPM_215;
                else if (Flag_213 == true)
                    merge_type = Module_Type.MPM_213;
                else
                    merge_type = Module_Type.MPM_211;

                // Process ranges merge
                process_error = Cal_STS.Cal_IL_Merge(merge_type);


                // tsl Sweep Stop
                inst_error = tsl.Sweep_Stop();

                // -----PDL Calcurete process-------------------------------------------
                process_error = PDL_Process_AndSave();
            MessageBox.Show("Completed.");
        }
        private int PDL_Process_AndSave()
        {
            // -----------------------------------------------------
            // STS PDL Process
            // -----------------------------------------------------
            double[] wavetable = null;                  // Target　Wavelength table
            int inst_error;                            // instrument error
            float[,,] correctionSOP = null;            // Correnction SOP data for wavelength  (wavelengthindex,SOP,Sop vector position)
            int cal_error;                             // Process class error



            // ----------------------------------------------------------------------------
            // 1. Get target wavelength table from Process class
            // 2. pass wavelength table & recive calcureted correction SOP array(3D)
            // 3. pass correction SOP array for Prosecc class
            // 4. Get processed IL data from Prosecc class
            // 5. Calculate PDL & IL & ILmax & ILmin from 4.data 
            // --------------------------------------------------------------------------
            // 1
            cal_error = Cal_STS.Get_Target_Wavelength_Table(ref wavetable);
            if (cal_error != 0)
            {
                Show_STS_Error(cal_error);
                return cal_error;
            }

            // 2
            System.Windows.Forms.Application.DoEvents();
            inst_error = pcu.Cal_All_SOP_Parametar(wavetable, ref correctionSOP);

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
            float[] ildata = null;
            STSDataStructForMerge get_struct = new STSDataStructForMerge();
            STSDataStructForMerge befor_struct = new STSDataStructForMerge();
            //STSDataStruct items = new STSDataStruct();

            float[,] SOPIL = null;
            float[] calPDL = null;
            float[] calIL = null;
            float[] calILmax = null;
            float[] calILmin = null;
            string fpath = string.Empty;
            System.IO.StreamWriter writer;
            string writestr = string.Empty;
            SOPIL = new float[4, wavetable.Length];
            foreach (STSDataStructForMerge item in Mergedata_struct)
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

                    cal_error = Cal_STS.Get_IL_Merge_Data(ref ildata, get_struct);

                    if (cal_error != 0)
                    {
                        Show_STS_Error(cal_error);
                        return cal_error;
                    }
                    // 1Ddata ->2D data array
                    for (loop2 = 0; loop2 <= ildata.GetUpperBound(0); loop2++)
                        SOPIL[loop1, loop2] = ildata[loop2];
                }

                befor_struct = get_struct;

                // 5.Calcurate of PDL 
                cal_error = Cal_STS.Cal_PDL(SOPIL, ref calPDL, ref calIL, ref calILmax, ref calILmin);

                if (cal_error != 0)
                {
                    Show_STS_Error(cal_error);
                    return cal_error;
                }

                // '--------Save data for each ch---------------------------------
                SaveFileDialog1.Title = "Device" + System.Convert.ToString(get_struct.MPMNumber+1) + "Slot" + System.Convert.ToString(get_struct.SlotNumber) + "Ch" + System.Convert.ToString(get_struct.ChannelNumber) + "PDL data save path";
                SaveFileDialog1.Filter = "csv file(*.csv)|*.csv";
                SaveFileDialog1.ShowDialog();

                fpath = SaveFileDialog1.FileName;
                writer = new System.IO.StreamWriter(fpath, false, System.Text.Encoding.GetEncoding("UTF-8"));
                // hedder

                writestr = "Wavelength(nm),IL(dB),PDL(dB),ILMax(dB),ILMin(dB)";

                writer.WriteLine(writestr);

                for (loop3 = 0; loop3 <= wavetable.GetUpperBound(0); loop3++)
                {
                    writestr = Convert.ToString(wavetable[loop3]) + "," + Convert.ToString(calIL[loop3]) + "," + Convert.ToString(calPDL[loop3]) + "," + Convert.ToString(calILmax[loop3]) + "," + Convert.ToString(calILmin[loop3]);
                    writer.WriteLine(writestr);
                }

                writer.Close();

                // -----Save Mueller data ??--------------------------------------

                if (chksavemu.Checked == true)
                {
                    double[] m11 = null;
                    double[] m12 = null;
                    double[] m13 = null;
                    double[] m14 = null;


                    // ------------------------------------------
                    // m11 = (H+V)/2
                    // m12 = (H-V)/2
                    // m13 = 45-m11
                    // m14 = RC-m11
                    // -------------------------------------------
                    // Load mueller parameter
                    cal_error = Cal_STS.Get_Mueller_Raw_Data(ref m11, ref m12, ref m13, ref m14);

                    if (cal_error != 0)
                    {
                        Show_STS_Error(cal_error);
                        return cal_error;
                    }

                    // file save
                    SaveFileDialog1.Title = "Device" + System.Convert.ToString(get_struct.MPMNumber) + "Slot" + System.Convert.ToString(get_struct.SlotNumber) + "Ch" + System.Convert.ToString(get_struct.ChannelNumber) + "Mueller data save path";
                    SaveFileDialog1.Filter = "csv file(*.csv)|*.csv";
                    SaveFileDialog1.ShowDialog();

                    fpath = SaveFileDialog1.FileName;

                    writer = new System.IO.StreamWriter(fpath, false, System.Text.Encoding.GetEncoding("UTF-8"));
                    // hedder

                    writestr = "Wavelength(nm),m11(mW),m12(mW),m13(mW),m14(mW)";

                    writer.WriteLine(writestr);

                    for (loop3 = 0; loop3 <= wavetable.GetUpperBound(0); loop3++)
                    {
                        writestr = Convert.ToString(wavetable[loop3]) + "," + Convert.ToString(m11[loop3]) + "," + Convert.ToString(m12[loop3]) + "," + Convert.ToString(m13[loop3]) + "," + Convert.ToString(m14[loop3]);
                        writer.WriteLine(writestr);
                    }

                    writer.Close();
                }
            }
            return 0;
        }

        private void btnsaveref_rawdata_Click(object sender, EventArgs e)
        {
            // ---------------------------------------------------------------------------
            // Save reference Raw data
            // ---------------------------------------------------------------------------
            int loop1;                        // loop count1   
            int loop2;                        // loop count2
            int loop3;                        // loop count3
            int process_error;                // process class error
            double[] wavetable = null;         // wavelength table
            float[] powdata = null;           // powerdata  rescaled    
            float[] monitordata = null;       // monitordata rescaled 
            List<float[]> lstpowdata = new List<float[]>();     // Power data list 
            List<float[]> lstmonitordata = new List<float[]>();     // monitor data list 

            // ---- Get reference Raw data (after the rescaling)

            // Get Target wavelengt table
            process_error = Cal_STS.Get_Target_Wavelength_Table(ref wavetable);

            if (process_error != 0)
            {
                Show_STS_Error(process_error);
                return;
            }

            // -------Load Each SOP data & Save
            string fpath = string.Empty;                  // file path 
            string hedder = string.Empty;                 // file hedder 
            string write_str = string.Empty;              // write string 
            string sop_string = string.Empty;             // SOP String 

            System.IO.StreamWriter writer;

            // Save each SOP reference data files.
            for (loop1 = 0; loop1 <= 3; loop1++)
            {
                hedder = "";
                lstpowdata = new List<float[]>();
                lstmonitordata = new List<float[]>();

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

                SaveFileDialog1.Title = "Reference Raw data" + sop_string;
                SaveFileDialog1.Filter = "csv file(*.csv)|*.csv";
                SaveFileDialog1.ShowDialog();
                fpath = SaveFileDialog1.FileName;

                writer = new System.IO.StreamWriter(fpath, false, System.Text.Encoding.GetEncoding("UTF-8"));

                hedder = "Wavelength(nm)";

                // Load matched SOP raw data form Processing class
                //--for power data & hedder
                foreach (STSDataStruct item in Refdata_struct)
                {
                    if (item.SOP != loop1)
                        continue;
                    // monitor data is 1 data for each sweep. It can be overwrite.
                    process_error = Cal_STS.Get_Ref_Power_Rawdata(item, ref powdata);
                    if (process_error != 0)
                    {
                        Show_STS_Error(process_error);
                        return;
                    }

                    lstpowdata.Add(powdata.ToArray());

                    hedder = hedder + ",MPM" + System.Convert.ToString(item.MPMNumber + 1) + "Slot" + System.Convert.ToString(item.SlotNumber) + "Ch" + System.Convert.ToString(item.ChannelNumber);
                }

                if (this.chkeach_ch.Checked)
                {
                    foreach (STSDataStruct item in Refdata_struct)
                    {
                        if (item.SOP != loop1)
                            continue;
                        hedder = hedder + ",Monitor_MPM" + System.Convert.ToString(item.MPMNumber + 1) + "Slot" + System.Convert.ToString(item.SlotNumber) + "Ch" + System.Convert.ToString(item.ChannelNumber);
                    }
                }
                else
                    hedder = hedder + ",Monitor";

                writer.WriteLine(hedder);
                // --for monitor data

                STSDataStruct get_struct = new STSDataStruct();                 // struct of get
                STSDataStruct befor_struct = new STSDataStruct();           // befor struct

                foreach (STSDataStruct item in Ref_monitordata_struct)
                {
                    if (this.chkeach_ch.Checked)
                    {
                        if ((item.MPMNumber == befor_struct.MPMNumber) & (item.SlotNumber == befor_struct.SlotNumber) & (item.ChannelNumber == befor_struct.ChannelNumber) | item.SOP != loop1)
                            continue;
                    }
                    else if (item.SOP != loop1)
                        continue;

                    process_error = Cal_STS.Get_Ref_Monitor_Rawdata(item, ref monitordata);

                    if (process_error != 0)
                    {
                        Show_STS_Error(process_error);
                        return;
                    }

                    get_struct.MPMNumber = item.MPMNumber;
                    get_struct.SlotNumber = item.SlotNumber;
                    get_struct.ChannelNumber = item.ChannelNumber;
                    get_struct.SOP = item.SOP;

                    lstmonitordata.Add(monitordata.ToArray());
                    befor_struct = get_struct;
                }

                // data write 
                for (loop2 = 0; loop2 <= wavetable.GetUpperBound(0); loop2++)
                {
                    // wavelength data
                    write_str = System.Convert.ToString(wavetable[loop2]);

                    // Power data
                    for (loop3 = 0; loop3 <= lstpowdata.Count - 1; loop3++)
                        write_str = write_str + "," + lstpowdata[loop3][loop2];


                    // monitordata
                    for (var loop4 = 0; loop4 <= lstmonitordata.Count - 1; loop4++)
                        write_str = write_str + "," + lstmonitordata[loop4][loop2];

                    writer.WriteLine(write_str);
                }

                writer.Close();
            }
            MessageBox.Show("Completed.");

        }

        private void btnsaveRawdata_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------------------------------
            // Save measurement raw data for designated Range
            // -------------------------------------------------------------------------
            int loop1;                                        // loop1
            int loop2;                                        // loop2
            int loop3;                                        // loop3
            double[] wavelength_table = null;                  // Wavelength table
            float[] monitordata = null;                       // monitor data array
            float[] powerdata = null;                         // Power data array
            int errorcode;                                    // Errorcode
            List<float[]> lstpower = new List<float[]>();                       // Power list 
            int rangenumber;                                  // save range number

            // -- Get Wavelength table
            errorcode = Cal_STS.Get_Target_Wavelength_Table(ref wavelength_table);

            if (errorcode != 0)
            {
                Show_STS_Error(errorcode);      // designated range
                return;
            }

            // ---check to range number 1st  or not & data exist
            bool first_rangeflag = new bool();
            bool exist_flag = false;

            rangenumber = Convert.ToInt32(txtsaverange.Text);

            foreach (var item in Data_struct)
            {
                if (item.RangeNumber > rangenumber)
                    first_rangeflag = true;
                // exist or not 
                if (item.RangeNumber == rangenumber)
                    exist_flag = true;
            }

            if (exist_flag == false)
            {
                MessageBox.Show("Range data is not exist.");
                return;
            }

            string fpath = string.Empty;              // File　path
            System.IO.StreamWriter writer;            // Writer 
            string write_string = string.Empty;
            string hedder = string.Empty;
            int sopcount;
            string sop_string = string.Empty;
            int sweepcount;                      //sweepcount

            // low range & 2scan 
            if (first_rangeflag == false & chk2scan.Checked == true)
                sopcount = 1;                            // 2Scan data
            else
                sopcount = 3;// 4Scan data

            // ----Save designated range measurement raw data  for each SOP---------------------------
            for (loop1 = 0; loop1 <= sopcount; loop1++)
            {
                hedder = "";
                lstpower = new List<float[]>();

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

                SaveFileDialog1.Title = "Save Range" + Convert.ToString(rangenumber) + "_" + sop_string + " SOP data";
                SaveFileDialog1.Filter = "csv file(*.csv)|*.csv";
                SaveFileDialog1.ShowDialog();

                fpath = SaveFileDialog1.FileName;

                writer = new System.IO.StreamWriter(fpath, false, System.Text.Encoding.GetEncoding("UTF-8"));
                hedder = "Wavelength(nm)";


                // sarch for match  data from "STSDataStruct"---------------------------------
                //-for power data
                foreach (STSDataStruct item in Data_struct)
                {
                    if ((item.SOP != loop1) | (item.RangeNumber != rangenumber))
                        continue;

                    // Load measurement raw data
                    errorcode = Cal_STS.Get_Meas_Power_Rawdata(item, ref powerdata);

                    if (errorcode != 0)
                    {
                        Show_STS_Error(errorcode);
                        return;
                    }

                    lstpower.Add(powerdata.ToArray());

                    hedder = hedder + "," + "mpm" + Convert.ToString(item.MPMNumber+1) + "Slot" + Convert.ToString(item.SlotNumber) + "Ch" + Convert.ToString(item.ChannelNumber);
                }

                hedder = hedder + ",Monitordata";

                writer.WriteLine(hedder);
                // --for monitor data
                foreach (STSMonitorStruct item in Meas_monitordata_struct)
                {
                    if (item.SOP != loop1 || item.SweepCount != sweepcount)
                        continue;

                    errorcode = Cal_STS.Get_Meas_Monitor_Rawdata(item, ref monitordata);

                    if (errorcode != 0)
                    {
                        Show_STS_Error(errorcode);
                        return;
                    }
                }
                // Write data
                for (loop2 = 0; loop2 <= wavelength_table.GetUpperBound(0); loop2++)
                {
                    write_string = Convert.ToString(wavelength_table[loop2]);

                    for (loop3 = 0; loop3 <= lstpower.Count - 1; loop3++)
                        write_string = write_string + "," + lstpower[loop3][loop2];

                    write_string = write_string + "," + monitordata[loop2];

                    writer.WriteLine(write_string);
                }

                writer.Close();
            }

            MessageBox.Show("Completed.");
        }
        private int check_sweepcount(int rangenumber, int sopcount)
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
                                if (chk2scan.Checked == true)
                                    sweepcount = 6 + sopcount + 1;
                                else
                                    sweepcount = 8 + sopcount + 1;
                                return sweepcount;
                            }

                        case 3:
                            {
                                // 4th range
                                if (chk2scan.Checked == true)
                                    sweepcount = 8 + sopcount + 1;
                                else
                                    sweepcount = 12 + sopcount + 1;
                                return sweepcount;
                            }

                        case 4:
                            {
                                // 5th range
                                if (chk2scan.Checked == true)
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


        private void Button1_Click(object sender, EventArgs e)
        {
            // -----------------------------------------------------------------------------
            // Reference Data Read
            // This function must use after "SET" 
            // -----------------------------------------------------------------------------
            string fpath = string.Empty;                  // filepath
            System.IO.StreamReader reader;                // data reader    
            int sop_loop;                             // SOP loop
            string sop_str = string.Empty;                // SOP String 

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

                OpenFileDialog1.Title = sop_str + " Reference Data";
                OpenFileDialog1.ShowDialog();
                fpath = OpenFileDialog1.FileName;

                reader = new System.IO.StreamReader(fpath);

                string read_st = string.Empty;                            // Read String 
                string[] split_st = null;                              // split strin array

                // hedder Read 
                read_st = reader.ReadLine();
                read_st = read_st.Trim();
                split_st = read_st.Split(',');

                int ch_count;                    // file data ch count 
                int loop1;                                            // Loop count1
                string chk_str = string.Empty;                            // check string
                int mpm_number = new int();                                       // mpm number
                int slot_number;                                      // Slot number
                int ch_number;                                        // ch number 
                                                                      //Check data cout 
                if (chkeach_ch.Checked == true)
                {
                    //Reference measurement one channel at a time
                    ch_count = (split_st.Count() - 1) / 2;
                }
                else
                {
                    ch_count = split_st.Count() - 2;
                }

                // Check data cout 
                if (ch_count != chklst_ch.CheckedItems.Count)
                {
                    MessageBox.Show("Reference data mismatch.Please selecet right data.");
                    reader.Close();
                    return;
                }

                // -----Check parameter & make reference data struct 
                STSDataStruct refdata_strunct = new STSDataStruct();                        // Data struct for reference
                List<STSDataStruct> lst_refdata_struct = new List<STSDataStruct>();        // Data struct for reference List    
                bool match_flag = false;                           // match flag

                for (loop1 = 1; loop1 <= ch_count; loop1++)
                {
                    // mpm device number 
                    chk_str = split_st[loop1].Substring(3, 1);
                    mpm_number = Convert.ToInt32(chk_str)-1;

                    // mpm Slot number 
                    chk_str = split_st[loop1].Substring(8, 1);
                    slot_number = Convert.ToInt32(chk_str);

                    // mpm Ch number 
                    chk_str = split_st[loop1].Substring(11, 1);
                    ch_number = Convert.ToInt32(chk_str);


                    // Check exsist data in data struct 
                    foreach (STSDataStruct item in Refdata_struct)
                    {
                        if (item.MPMNumber == mpm_number & item.SlotNumber == slot_number & item.ChannelNumber == ch_number & item.SOP == sop_loop)
                        {
                            match_flag = true;
                            break;
                        }
                    }

                    if (match_flag == false)
                    {
                        MessageBox.Show("Reference data mismatch.Please selecet right data.");
                        reader.Close();
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
                if (this.chkeach_ch.Checked)
                {
                    List<float>[] power;                 // Power data list
                    List<float>[] monitor;               // Monitordata
                    int counter=new int();                         // Counter
                    double wavelength=new double();                       // Read Wavelength 

                    power = new List<float>[ch_count];
                    monitor = new List<float>[ch_count];

                    for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
                    {
                        power[loop1] = new List<float>();
                        monitor[loop1] = new List<float>();
                    }


                    do
                    {
                        read_st = reader.ReadLine();
                        if (read_st == null)
                            break;
                        read_st = read_st.Trim();
                        split_st = read_st.Split(',');

                        // Check Start Wavelength 
                        if (counter == 0)
                        {
                            if (split_st[0] != this.txtstartwave.Text)
                            {
                                MessageBox.Show("Reference data mismatch.Please selecet right data.");
                                reader.Close();
                                return;
                            }
                        }

                        // hold wavelength data
                        wavelength = System.Convert.ToDouble(split_st[0]);
                        for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
                            power[loop1].Add(System.Convert.ToSingle(split_st[loop1 + 1]));
                        for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
                            monitor[loop1].Add(System.Convert.ToSingle(split_st[ch_count + loop1 + 1]));
                        counter = counter + 1;
                    }
                    while (true);

                    reader.Close();

                    // Check Stop wavelength 
                    if (wavelength != System.Convert.ToDouble(this.txtstopwave.Text))
                    {
                        MessageBox.Show("Reference data mismatch.Please selecet right data.");
                        return;
                    }

                    // check number of point 


                    int datapoint;                            // number of data point 

                    datapoint = (int)(Math.Abs(Convert.ToDouble(txtstopwave.Text) - Convert.ToDouble(txtstartwave.Text)) / Convert.ToDouble(txtstepwave.Text)) + 1;

                    if (datapoint != monitor[0].Count)
                    {
                        MessageBox.Show("Reference data mismatch.Please selecet right data.");
                        return;
                    }



                    // -------Add in  data to STS Process class
                    int errorcode;                            // Errorcode
                    counter = 0;

                    foreach (var item in lst_refdata_struct)
                    {
                        // Add in reference data of rescaled.
                        errorcode = Cal_STS.Add_Ref_Rawdata(power[counter].ToArray(), monitor[counter].ToArray(), item);

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
                    List<float>[] power;                 // Power data list 
                    List<float> monitor = new List<float>();             // Monitordata
                    int counter = new int();                         // Counter
                    double wavelength = new double();                       // Read Wavelength 

                    power = new List<float>[ch_count];

                    for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
                        power[loop1] = new List<float>();

                    do
                    {
                        read_st = reader.ReadLine();
                        if (read_st == null)
                            break;
                        read_st = read_st.Trim();
                        split_st = read_st.Split(',');

                        // Check Start Wavelength 
                        if (counter == 0)
                        {
                        if (split_st[0] != this.txtstartwave.Text)
                            {
                                MessageBox.Show("Reference data mismatch.Please selecet right data.");
                                reader.Close();
                                return;
                            }
                        }


                        // hold wavelength data
                        wavelength = System.Convert.ToDouble(split_st[0]);
                        for (loop1 = 0; loop1 <= ch_count - 1; loop1++)
                            power[loop1].Add(System.Convert.ToSingle(split_st[loop1 + 1]));
                        monitor.Add(System.Convert.ToSingle(split_st[ch_count + 1]));
                        counter = counter + 1;
                    }
                    while (true);

                    reader.Close();

                    // Check Stop wavelength 
                    if (wavelength != System.Convert.ToDouble(this.txtstopwave.Text))
                    {
                        MessageBox.Show("Reference data mismatch.Please selecet right data.");
                        return;
                    }

                    // check number of point 


                    int datapoint;                            // number of data point 

                    datapoint = (int)(Math.Abs(Convert.ToDouble(txtstopwave.Text) - Convert.ToDouble(txtstartwave.Text)) / Convert.ToDouble(txtstepwave.Text)) + 1;

                    if (datapoint != monitor.Count)
                    {
                        MessageBox.Show("Reference data mismatch.Please selecet right data.");
                        return;
                    }
                   // -------Add in  data to STS Process class
                    int errorcode;                            // Errorcode
                    counter = 0;

                    foreach (var item in lst_refdata_struct)
                    {
                        // Add in reference data of rescaled.
                        errorcode = Cal_STS.Add_Ref_Rawdata(power[counter].ToArray(), monitor.ToArray(), item);

                        if (errorcode != 0)
                        {
                            Show_Inst_Error(errorcode);
                            return;
                        }
                        counter = counter + 1;
                    }
                }
            }
            MessageBox.Show("Completed.");
        }

        private void btnsavecalil_Click(object sender, EventArgs e)
        {
            // ------------------------------------------------------------------------------
            // Save Calculated IL (Cancel for SOP wavelength dependence)
            // This method must be run after the PDL Calculation
            // ------------------------------------------------------------------------------
            string fpath = string.Empty;
            double[] wavelengthdata = null;
            float[,] cal_IL = null;
            int errorcode;

            // Load Wavelength data 
            errorcode = Cal_STS.Get_Target_Wavelength_Table(ref wavelengthdata);

            if (errorcode != 0)
            {
                Show_STS_Error(errorcode);
                return;
            }

            // Get Calculated IL
            errorcode = Cal_STS.Get_Calibrated_IL(out cal_IL);

            if (errorcode != 0)
            {
                Show_STS_Error(errorcode);
                return;
            }

            // Data save
            SaveFileDialog1.Title = "Save to Calculated IL";
            SaveFileDialog1.Filter = "csv file(*.csv)|*.csv";
            SaveFileDialog1.ShowDialog();

            fpath = SaveFileDialog1.FileName;

            System.IO.StreamWriter writer = new System.IO.StreamWriter(fpath, false, System.Text.Encoding.GetEncoding("UTF-8"));               // writer 
            int loop1;
            int loop2;
            string write_string = string.Empty;


            // hedder
            write_string = "Wavelength(nm),IL_V(dB),IL_H(dB),IL_45(dB),IL_RCP(dB)";

            writer.WriteLine(write_string);


            for (loop1 = 0; loop1 <= wavelengthdata.GetUpperBound(0); loop1++)
            {
                write_string = wavelengthdata[loop1] + ",";

                for (loop2 = 0; loop2 <= 3; loop2++)
                    write_string = write_string + System.Convert.ToString(cal_IL[loop2, loop1]) + ",";

                writer.WriteLine(write_string);
            }
            writer.Close();

            MessageBox.Show("Completed.");
        }
    }
}
