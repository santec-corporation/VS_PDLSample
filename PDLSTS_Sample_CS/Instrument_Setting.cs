using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDLSTS_Sample
{
    public partial class Instrument_Setting : Form
    {
        public Instrument_Setting()
        {
            InitializeComponent();
        }
        public string[] SPU_Resource;                 // SPU(DAQ) resource
        public string[] USB_Resource;                 // USB resource

        public string TSL_Communicater;               // TSL communication method
        public string MPM_Communicater;               // MPM communication method
        public string PCU_Communicater;               // PCU commnuication method

        public string TSL_Address;                    // TSL Address  (GPIB/IP address/USB resource number)
        public int TSL_Portnumber;                // TSL LAN port number

        public int MPM_Count;                     // MPM number of control count
        public string[] MPM_Address = new string[2];                 // MPM Address(GPIB/IP address/USB resource number)
        public int[] MPM_Portnumber = new int[2];             // MPM LAN Port number

        public string PCU_Address;                    // PCU Address(GPIB/IP address/USB resource number)
        public int PCU_Portnumber;                // PCU LAN Port number

        public string SPU_DeviveID;                   // SPU(DAQ) Device ID 
        public bool PCU_useing_internal_DAQ;       // SPU(DAQ) use inside PCU or not  T:in PCU F: other
        private void btnconnect_Click(object sender, EventArgs e)
        {
            // ----------------------------------------------------------
            // Connect       
            // ----------------------------------------------------------


            // ----TSL Communication diteal

            // GPIB Communcation?
            if (rdotsl_gpib.Checked == true)
            {
                TSL_Communicater = "GPIB";
                TSL_Address = txttsl_gpibadd.Text;
                TSL_Portnumber = 0;
            }

            // TCP/IP Communciation?
            if (rdo_tsltcpip.Checked == true)
            {
                TSL_Communicater = "LAN";
                TSL_Address = txttsl_ipadd.Text;
                TSL_Portnumber = Convert.ToInt32(txttsl_lanport.Text);
            }

            // USB Communcation?
            if (rdo_tslusb.Checked == true)
            {
                TSL_Communicater = "USB";
                TSL_Address = cmbtsl_usb.SelectedIndex.ToString();
                TSL_Portnumber = 0;
            }

            // -----MPM Communcation diteal

            // Multi Device?
            if (chkmulti_dev.Checked == true)
            {
                MPM_Count = 2;

                // GPIB communcation?
                if (rdo_mpmgpib.Checked == true)
                {
                    MPM_Address[0] = txtmpm_gpibadd1.Text;
                    MPM_Address[1] = txtmpm_gpibadd2.Text;
                    MPM_Portnumber[0] = 0;
                    MPM_Portnumber[1] = 0;

                    MPM_Communicater = "GPIB";
                }
                else
                {
                    // TCL/IP communcation?
                    MPM_Address[0] = txtmpm_ipadd1.Text;
                    MPM_Address[1] = txtmpm_ipadd2.Text;
                    MPM_Portnumber[0] = Convert.ToInt32(txtmpm_lanport1.Text);
                    MPM_Portnumber[1] = Convert.ToInt32(txtmpm_lanport2.Text);

                    MPM_Communicater = "LAN";
                }
            }
            else
            {
                MPM_Count = 1;

                // GPIB communcation?
                if (rdo_mpmgpib.Checked == true)
                {
                    MPM_Address[0] = txtmpm_gpibadd1.Text;
                    MPM_Address[1] = "";
                    MPM_Portnumber[0] = 0;
                    MPM_Portnumber[1] = 0;

                    MPM_Communicater = "GPIB";
                }
                else
                {
                    // TCL/IP communcation?
                    MPM_Address[0] = txtmpm_ipadd1.Text;
                    MPM_Address[1] = "";
                    MPM_Portnumber[0] = Convert.ToInt32(txtmpm_lanport1.Text);
                    MPM_Portnumber[1] = 0;

                    MPM_Communicater = "LAN";
                }
            }


            // ----PCU Communication diteal

            // GPIB communcation?
            if (rdopcu_gpib.Checked == true)
            {
                PCU_Communicater = "GPIB";
                PCU_Address = txtpcu_gpibadd.Text;
            }

            // USB communcation?
            if (rdopcu_usb.Checked == true)
            {
                PCU_Communicater = "USB";
                PCU_Address = cmbpcu_usbresource.SelectedIndex.ToString();
            }

            // TCP/IP communication?
            if (rdopcu_lan.Checked == true)
            {
                PCU_Communicater = "LAN";
                PCU_Address = txtpcu_ipadd.Text;
                PCU_Portnumber = Convert.ToInt32(txtpcu_lanport.Text);
            }

            // --------- SPU Resouce
            string spu_id = string.Empty;


            // SPU(DAQ) use inside PCU or not
            // PCU-100 has SPU(DAQ) inside
            // PCU-110 has not SPU(DAQ) inside

            spu_id = cmbpcu_dev.Text;

            if (rdopcu100.Checked == true)
                PCU_useing_internal_DAQ = true;
            else
                PCU_useing_internal_DAQ = false;

            if (spu_id == "")
            {
                MessageBox.Show("Please enter to the SPU device resouce");
                return;
            }

            SPU_DeviveID = spu_id;
            Dispose();
        }

        private void Instrument_Setting_Load(object sender, EventArgs e)
        {
            // ---------------------------------------------------------------
            // Sub Form Load
            // ---------------------------------------------------------------
            int loop1;

            // ---Add in SPU resource to combbox
            for (loop1 = 0; loop1 <= SPU_Resource.GetUpperBound(0); loop1++)
                cmbpcu_dev.Items.Add(SPU_Resource[loop1]);

            // ----Add in USB resource

            for (loop1 = 0; loop1 <= USB_Resource.GetUpperBound(0); loop1++)
            {
                cmbtsl_usb.Items.Add(USB_Resource[loop1]);
                cmbpcu_usbresource.Items.Add(USB_Resource[loop1]);
            }
        }

        private void rdo570_CheckedChanged(object sender, EventArgs e)
        {
            //-----------------------------------------------------
            //       570 Checked
            //----------------------------------------------------

            if (rdo570.Checked == true)
            {
                rdo_tsltcpip.Enabled = true;
                rdo_tslusb.Enabled = true;
            }
            else
            {
                rdo_tslusb.Enabled = false;
                rdo_tsltcpip.Enabled = false;
                rdotsl_gpib.Checked = true;
            }
        }

        private void rdotsl_gpib_CheckedChanged(object sender, EventArgs e)
        {
            // ------------------------------------------------------
            // TSL Control GPIB
            // ------------------------------------------------------

            if (rdotsl_gpib.Checked == true)
            {
                txttsl_gpibadd.Enabled = true;
                txttsl_ipadd.Enabled = false;
                txttsl_lanport.Enabled = false;
                cmbtsl_usb.Enabled = false;
            }
        }

        private void rdo_tsltcpip_CheckedChanged(object sender, EventArgs e)
        {
            // ------------------------------------------------------
            // TSL Control TCP/IP
            // ------------------------------------------------------

            if (rdo_tsltcpip.Checked == true)
            {
                txttsl_gpibadd.Enabled = false;
                txttsl_ipadd.Enabled = true;
                txttsl_lanport.Enabled = true;
                cmbtsl_usb.Enabled = false;
            }
        }

        private void rdo_tslusb_CheckedChanged(object sender, EventArgs e)
        {
            // ------------------------------------------------------
            // TSL Control USB
            // ------------------------------------------------------

            if (rdo_tslusb.Checked == true)
            {
                txttsl_gpibadd.Enabled = false;
                txttsl_ipadd.Enabled = false;
                txttsl_lanport.Enabled = false;
                cmbtsl_usb.Enabled = true;
            }
        }

        private void chkmulti_dev_CheckedChanged(object sender, EventArgs e)
        {
            //------------------------------------------------------------------
            //          Selecet MPM Multi-Device
            //-------------------------------------------------------------------

            grp_mpmdev2.Enabled = chkmulti_dev.Checked;

        }

        private void rdo_mpmgpib_CheckedChanged(object sender, EventArgs e)
        {
            // --------------------------------------------------------------------
            // MPM Control GPIB
            // --------------------------------------------------------------------

            if (rdo_mpmgpib.Checked == true)
            {
                txtmpm_gpibadd1.Enabled = true;
                txtmpm_gpibadd2.Enabled = true;
                txtmpm_ipadd1.Enabled = false;
                txtmpm_ipadd2.Enabled = false;
                txtmpm_lanport1.Enabled = false;
                txtmpm_lanport2.Enabled = false;
            }
            else
            {
                txtmpm_gpibadd1.Enabled = false;
                txtmpm_gpibadd2.Enabled = false;
                txtmpm_ipadd1.Enabled = true;
                txtmpm_ipadd2.Enabled = true;
                txtmpm_lanport1.Enabled = true;
                txtmpm_lanport2.Enabled = true;
            }
        }

        private void rdopcu100_CheckedChanged(object sender, EventArgs e)
        {
            // ------------------------------------------------------------------------
            // PCU-100 checked
            // ------------------------------------------------------------------------

            // PCU-100 checked
            if (rdopcu100.Checked == true)
            {
                rdopcu_gpib.Enabled = true;
                rdopcu_lan.Enabled = false;
                rdopcu_usb.Enabled = false;
                txtpcu_ipadd.Enabled = false;
                txtpcu_lanport.Enabled = false;
                txtpcu_gpibadd.Enabled = true;
                cmbpcu_usbresource.Enabled = false;
            }
            else
            {
                // PCU-110 Checked 
                rdopcu_gpib.Checked = true;
                rdopcu_gpib.Enabled = true;
                rdopcu_lan.Enabled = true;
                rdopcu_usb.Enabled = true;
                txtpcu_ipadd.Enabled = false;
                txtpcu_lanport.Enabled = false;
                txtpcu_gpibadd.Enabled = true;
                cmbpcu_usbresource.Enabled = false;
            }
        }

        private void rdopcu_gpib_CheckedChanged(object sender, EventArgs e)
        {
            // -------------------------------------------------------------------
            // PCU Communcatior GPIB Checked
            // -------------------------------------------------------------------


            if (rdopcu_gpib.Checked == true)
            {
                txtpcu_gpibadd.Enabled = true;
                txtpcu_ipadd.Enabled = false;
                txtpcu_lanport.Enabled = false;
                cmbpcu_usbresource.Enabled = false;
            }
        }

        private void rdopcu_lan_CheckedChanged(object sender, EventArgs e)
        {
            // ----------------------------------------------------------------
            // PCU communcatior TCP/IP Checked
            // ----------------------------------------------------------------

            if (rdopcu_lan.Checked == true)
            {
                txtpcu_gpibadd.Enabled = false;
                txtpcu_ipadd.Enabled = true;
                txtpcu_lanport.Enabled = true;
                cmbpcu_usbresource.Enabled = false;
            }
        }

        private void rdopcu_usb_CheckedChanged(object sender, EventArgs e)
        {
            // ---------------------------------------------------------------
            // PCU Communicator USB checked
            // ---------------------------------------------------------------

            if (rdopcu_usb.Checked == true)
            {
                txtpcu_gpibadd.Enabled = false;
                txtpcu_ipadd.Enabled = false;
                txtpcu_lanport.Enabled = false;
                cmbpcu_usbresource.Enabled = true;
            }
        }
    }
}
