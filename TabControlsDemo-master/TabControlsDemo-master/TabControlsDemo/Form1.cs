using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using MetroFramework.Controls;
using MetroFramework.Forms;
using CyUSB;
using System.IO;

namespace TabControlsDemo
{
    public partial class Form1 : Form
    {
        internal const int ERR_SUCCESS = 0;
        internal const int ERR_OPEN = 1;
        internal const int ERR_CLOSE = 2;
        internal const int ERR_READ = 3;
        internal const int ERR_WRITE = 4;

        public CyHidDevice HeadsetHIDDevice;
        public static object lockIniDevice = new object();
        public USBDeviceList usbHIDDevices = null;
        private FileLogger gLogger = FileLogger.Instance;
        private string TAG = "TabControlsDemo";
        int VID = 0x0416;//for MTK 0xE8D  0x0416
        int PID = 0x140F;//for MTK 0x809  0x140F

        public byte[] dsp_file_content = null;

        public Form1()
        {
            InitializeComponent();

            usbHIDDevices = new USBDeviceList(CyConst.DEVICES_HID);
            InitLogger();

            //Adding event handlers for device attachment and device removal            
            usbHIDDevices.DeviceAttached += new EventHandler(usbHIDDevices_DeviceChecker);
            usbHIDDevices.DeviceRemoved += new EventHandler(usbHIDDevices_DeviceChecker);
            if (GetHidDevice())
            {
                //textBox7.Text=HeadsetHIDDevice.UsagePage;
                textBox7.Text = HeadsetHIDDevice.Product;
                //ReadFWVersion();
                //if (ReadFWVersion())
                //{
                    //int num = (int)MessageBox.Show("ReadFWVersion succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //}
            }

            //metroTabControl1.TabPages[0].Focus();
            //metroTabControl1.TabPages[0].CausesValidation = true;

            WriteLogHome("System started", true);

            // search and initialize for dsp bin file
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(strWorkPath);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + "IG1100_" + "*.*");
            foreach (FileInfo foundFile in filesInDir)
            {
                tb_dsp_bin_path.Text = foundFile.FullName;
                dsp_file_content = File.ReadAllBytes(foundFile.FullName);
            }


        }


        public static class Constants
        {
            //public const int VID = 0x0416;
            //public const int PID = 0x140E;

            //public const ReadEndpointID RX_ENDP = ReadEndpointID.Ep07;
            //public const WriteEndpointID TX_ENDP = WriteEndpointID.Ep06;

            //public const string LibUsb_Driver_Install_Cmd = "install-filter install --device=USB/Vid_0416.Pid_140E.Rev_0000";
            //public const string LibUsb_Driver_Uninstall_Cmd = "install-filter uninstall --device=USB//Vid_0416.Pid_140E.Rev_0000";

            public const byte Endpoint_Write_Size = 64;
            public const byte Endpoint_Read_Size = 64;
            public const byte DSP_Write_Size = 32;

            public const byte HEADER_READ = 0xFC;
            public const byte HEADER_WRITE = 0xF3;
            public const byte HEADER_RESP_READ = 0xF5;
            public const byte HEADER_RESP_WRITE = 0xF0;

            public const byte CMD_IG_UPD_RESULT = 0x20;
            public const byte CMD_IG_UPD_INIT = 0x21;
            public const byte CMD_IG_UPD_ERASE = 0x22;
            public const byte CMD_IG_UPD_WRITE = 0x23;
            public const byte CMD_IG_UPD_END = 0x24;
            public const byte CMD_TYPE_READ_IG_FIRMWARE_VER_REQ = 0x25;
            public const byte CMD_TYPE_READ_IG_FIRMWARE_VER_RESP = 0x26;
            public const byte CMD_TYPE_SW_RESET = 0x27;
        }

        private void ReadFWVersionThreadUSB()
        {
            lock (lockIniDevice)
            {

                //bool res = false;
                //byte[] recvbuff = (byte[])null;
                //uint fileAddr = 0;
                for (int index = 0; index < 3; ++index)
                {
                    gLogger.d(TAG, "OpenConnection retry...." + index.ToString());
                    if (OpenConnection() != ERR_SUCCESS)
                    {
                        int num = (int)MessageBox.Show("Can't open the usb device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        //return;
                    }
                    else
                    {
                        break;
                    }
                }

                if (ReadFWVersion())
                {
                    int num = (int)MessageBox.Show("ReadFWVersion succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }

                CloseConnection();

            }
        }

        private void SendDSPInitThreadUSB()
        {
            lock (lockIniDevice)
            {

                //bool res = false;
                //byte[] recvbuff = (byte[])null;
                //uint fileAddr = 0;
                for (int index = 0; index < 3; ++index)
                {
                    gLogger.d(TAG, "OpenConnection retry...." + index.ToString());
                    if (OpenConnection() != ERR_SUCCESS)
                    {
                        int num1 = (int)MessageBox.Show("Can't open the usb device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        //return;
                    }
                    else
                    {
                        break;
                    }
                }

                if (SendDSPInit())
                {
                    int num = (int)MessageBox.Show("SendDSPInit succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }

                CloseConnection();

            }
        }


        private void SendDSPEraseThreadUSB()
        {
            lock (lockIniDevice)
            {

                //bool res = false;
                //byte[] recvbuff = (byte[])null;
                //uint fileAddr = 0;
                for (int index = 0; index < 3; ++index)
                {
                    gLogger.d(TAG, "OpenConnection retry...." + index.ToString());
                    if (OpenConnection() != ERR_SUCCESS)
                    {
                        int num = (int)MessageBox.Show("Can't open the usb device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        //return;
                    }
                    else
                    {
                        break;
                    }
                }

                if (SendDSPErase(0, (uint)dsp_file_content.Length))
                {
                    int num = (int)MessageBox.Show("SendDSPErase succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }

                CloseConnection();

            }
        }

        private void SendDSPUpdateThreadUSB()
        {
            lock (lockIniDevice)
            {

                //bool res = false;
                //byte[] recvbuff = (byte[])null;
                //uint fileAddr = 0;
                for (int index = 0; index < 3; ++index)
                {
                    gLogger.d(TAG, "OpenConnection retry...." + index.ToString());
                    if (OpenConnection() != ERR_SUCCESS)
                    {
                        int num = (int)MessageBox.Show("Can't open the usb device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        //return;
                    }
                    else
                    {
                        break;
                    }
                }

                ControlButtonEnableFunc(false);
                dsp_update_status_show(0);
                dsp_progressbar_show((uint)dsp_file_content.Length, 0);

                if (!SendDSPInit())
                {
                    int num = (int)MessageBox.Show("SendDSPInit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    CloseConnection();
                    goto label_2; //return;
                }

                if (!SendDSPErase(0, (uint)dsp_file_content.Length))
                {
                    int num = (int)MessageBox.Show("SendDSPErase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    CloseConnection();
                    goto label_2; //return;
                }

                int COUNT, REMAIN;
                uint Address = 0;
                byte[] dsp_file_buf = new byte[Constants.DSP_Write_Size];

                COUNT = dsp_file_content.Length / Constants.DSP_Write_Size;
                REMAIN = dsp_file_content.Length % Constants.DSP_Write_Size;

                for (uint i = 0; i < COUNT; i++)
                {
                    for (int j = 0; j < 32; j++)
                    {
                        dsp_file_buf[j] = dsp_file_content[i * 32 + j];
                    }
                    if (i == 0)
                    {
                        if (!SendDSPUpdate(dsp_file_buf, Address, 0x40)) // first packet
                        {
                            int num = (int)MessageBox.Show("SendDSPUpdate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            CloseConnection();
                            goto label_2; //return;
                        }

                    }
                    else if ((REMAIN == 0) && ((i + 1) == COUNT))
                    {
                        if (!SendDSPUpdate(dsp_file_buf, Address, 0x80)) // last packet
                        {
                            int num = (int)MessageBox.Show("SendDSPUpdate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            CloseConnection();
                            goto label_2; //return;
                        }
                    }
                    else
                    {
                        if (!SendDSPUpdate(dsp_file_buf, Address, 0x00))
                        {
                            int num = (int)MessageBox.Show("SendDSPUpdate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            CloseConnection();
                            goto label_2; //return;
                        }
                    }

                    Address += Constants.DSP_Write_Size;
                    dsp_progressbar_show((UInt32)dsp_file_content.Length, i * Constants.DSP_Write_Size);

                }

                if ((dsp_file_content.Length - Address) != 0)
                {
                    uint remaining = (uint)dsp_file_content.Length - Address;
                    byte[] dsp_file_rm_buf = new byte[remaining];

                    Array.Copy(dsp_file_content, Address, dsp_file_rm_buf, 0, remaining);

                    if (!SendDSPUpdate(dsp_file_buf, Address, 0x80)) // last packet
                    {
                        int num = (int)MessageBox.Show("SendDSPUpdate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        CloseConnection();
                        goto label_2; //return;
                    }

                    dsp_progressbar_show((UInt32)dsp_file_content.Length, (UInt32)dsp_file_content.Length);
                }

                if (!SendDSPUpdateEnd()) // last packet
                {
                    int num = (int)MessageBox.Show("SendDSPUpdateEnd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    CloseConnection();
                    goto label_2;
                }
                else
                {
                    int num = (int)MessageBox.Show("Update DSP succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    dsp_update_status_show(1);
                    ControlButtonEnableFunc(true);
                    return;
                }

            label_2:
                dsp_update_status_show(-1);
                ControlButtonEnableFunc(true);



            }
        }



        private bool GetFWVerFromIAP(out byte[] recvbuff)
        {
            byte[] sendBuff = new byte[2];
            recvbuff = new byte[11];
            sendBuff[0] = (byte)90;
            sendBuff[1] = (byte)168;
            return PortCommunicationUSB(sendBuff, recvbuff);
        }

        private bool SendDSPInitFromIAP(out byte[] recvbuff)
        {
            byte[] sendBuff = new byte[4];
            recvbuff = new byte[32];
            sendBuff[0] = (byte)Constants.HEADER_WRITE; ;
            sendBuff[1] = (byte)0;
            sendBuff[2] = (byte)0;
            sendBuff[3] = (byte)Constants.CMD_IG_UPD_INIT;
            return PortCommunicationUSB(sendBuff, recvbuff);
        }

        private bool SendDSPEraseFromIAP(uint StartAddr, uint Size, out byte[] recvbuff)
        {
            byte[] sendBuff = new byte[12];
            recvbuff = new byte[32];
            sendBuff[0] = (byte)Constants.HEADER_WRITE; ;
            sendBuff[1] = (byte)0x08;
            sendBuff[2] = (byte)0;
            sendBuff[3] = (byte)Constants.CMD_IG_UPD_ERASE;

            sendBuff[4] = (byte)((StartAddr >> 0) & 0xFF);
            sendBuff[5] = (byte)((StartAddr >> 8) & 0xFF);
            sendBuff[6] = (byte)((StartAddr >> 16) & 0xFF);
            sendBuff[7] = (byte)((StartAddr >> 24) & 0xFF);

            sendBuff[8] = (byte)((Size >> 0) & 0xFF);
            sendBuff[9] = (byte)((Size >> 8) & 0xFF);
            sendBuff[10] = (byte)((Size >> 16) & 0xFF);
            sendBuff[11] = (byte)((Size >> 24) & 0xFF);
            return PortCommunicationUSB(sendBuff, recvbuff);
        }

        private bool SendDSPUpdateFromIAP(byte[] Data, uint Address, byte FrameNumber, out byte[] recvbuff)
        {
            byte[] sendBuff = new byte[64];

            recvbuff = new byte[32];

            if (Data.Length > Constants.DSP_Write_Size)
                return false;

            sendBuff[0] = (byte)Constants.HEADER_WRITE; ;
            sendBuff[1] = (byte)(Data.Length + 4);
            sendBuff[2] = (byte)FrameNumber;
            sendBuff[3] = (byte)Constants.CMD_IG_UPD_WRITE;

            sendBuff[4] = (byte)((Address >> 0) & 0xFF);
            sendBuff[5] = (byte)((Address >> 8) & 0xFF);
            sendBuff[6] = (byte)((Address >> 16) & 0xFF);
            sendBuff[7] = (byte)((Address >> 24) & 0xFF);

            Array.Copy(Data, 0, sendBuff, 8, Data.Length);

            return PortCommunicationUSB(sendBuff, recvbuff);
        }

        private bool SendDSPUpdateEndFromIAP(out byte[] recvbuff)
        {
            byte[] sendBuff = new byte[4];

            recvbuff = new byte[32];

            sendBuff[0] = (byte)Constants.HEADER_WRITE; ;
            sendBuff[1] = 0;
            sendBuff[2] = 0;
            sendBuff[3] = (byte)Constants.CMD_IG_UPD_END;

            return PortCommunicationUSB(sendBuff, recvbuff);
        }

        private void InitLogger()
        {
            gLogger.initFileLogger("./Logger/log4net.config", "", true);
            gLogger.d(TAG, "init logger");
        }

        private bool PortCommunicationUSB(byte[] sendBuff, byte[] recvBuff)
        {
           // if (GetHidDevice())
            //{
                if (sendBuff != null)
                {
                    if (recvBuff != null)
                    {
                        try
                        {
                            HeadsetHIDDevice.Outputs.DataBuf[0] = HeadsetHIDDevice.Outputs.ID;
                            //Load 64 bytes of data
                            for (int i = 1; i <= sendBuff.Length; i++)
                            {
                                HeadsetHIDDevice.Outputs.DataBuf[i] = sendBuff[i - 1];
                            }

                            if (!HeadsetHIDDevice.WriteOutput())
                                return false;
                        }
                        catch
                        {
                            return false;
                        }
                        int num = 0;
                    label_1:
                        try
                        {
                            byte[] rbuff = recvBuff;
                            int length = rbuff.Length;
                            byte[] buf_temp = new byte[length];
                            string received_data;

                            //if (!GetHidDevice())
                            //    return false;

                            if (HeadsetHIDDevice.ReadInput())
                            {
                                buf_temp = HeadsetHIDDevice.Inputs.DataBuf;
                                received_data = ByteArrayToString(buf_temp);
                                gLogger.d(TAG, "Received_data:" + received_data);
                                //textBox5.Text += "Received_data:" + received_data + "\r\n";
                               // WriteLogHome("Received_data:" + received_data, false);
                                Array.Copy(buf_temp, 1, rbuff, 0, Math.Min(length, buf_temp.Length));
                                return true;
                            }
                           // Thread.Sleep(1);//10
                            ++num;
                            if (num >= 3)//500
                                return false;
                            goto label_1;
                        }
                        catch
                        {
                            return false;
                        }
                    }

                return false;
                }


               // return false;
            //}
           else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as MetroTabControl).SelectedIndex)
            {
                case 0:
#if false
                    var formBig = new Form2();
                    //不要顯示Title
                    formBig.FormBorderStyle = FormBorderStyle.None;

                    //非最上層
                    formBig.TopLevel = false;

                    //顯示From，要加上去才會顯示Form
                    formBig.Visible = true;

                    //設定From位置
                    formBig.Top = 0;
                    formBig.Left = 0;

                    //將Form加入tabPage中
                    metroTabPage1.Controls.Add(formBig);

                    //顯示tabPage
                    metroTabPage1.Show();
#endif
                    break;
                case 1:
                    //顯示收藏個股form
                    break;
                case 2:
                    //顯示歷史對帳單form
                    break;
            }
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            VID = Convert.ToInt32(textBox1.Text, 16);
            GetHidDevice();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PID = Convert.ToInt32(textBox2.Text, 16);
            GetHidDevice();
        }

        void usbHIDDevices_DeviceChecker(object sender, EventArgs e)
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
            if (GetHidDevice())
            {
                textBox7.Text = HeadsetHIDDevice.Product;
                res = GetFWVerFromIAP(out recvbuff);
                if (res)
                {
                    if (recvbuff[0] != (byte)90 || recvbuff[1] != (byte)168 || (recvbuff[2] != byte.MaxValue || recvbuff[3] != (byte)0))
                    {
                        int num = (int)MessageBox.Show("Read FW Version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return;
                    }
                    if (recvbuff[6] == 0)
                    {
                        textBox8.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                    }
                    else if (recvbuff[6] == 1)
                    {
                        textBox8.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                    }

                    byte[] buf_temp = new byte[4];
                    Array.Copy(recvbuff, 7, buf_temp, 0, buf_temp.Length);
                    //received_data = ByteArrayToString(buf_temp);

                    textBox4.Text = ByteArrayToString(buf_temp);
                }
            }
            else
            {
                textBox8.Text = "0.00";
                textBox4.Text = "";
            }

        }

        void WriteLog(string message, bool clear)
        {
            // Replace content
            if (clear)
            {
                metroTextBox1.Text = string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
            }
            // Add new line
            else
            {
                metroTextBox1.Text += Environment.NewLine + string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
            }
            // Scroll to bottom
            metroTextBox1.Select(metroTextBox1.Text.Length, 0);
            // call focus 
            metroTextBox1.Focus();
            //metroTextBox1.SelectionStart = metroTextBox1.Text.Length;
            //metroTextBox1.sco
        }

        void WriteLogHome(string message, bool clear)
        {
            // Replace content
            if (clear)
            {
                textBox5.Text = string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
            }
            // Add new line
            else
            {
                textBox5.Text += Environment.NewLine + string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
            }
            // Scroll to bottom
            textBox5.SelectionStart = textBox5.Text.Length;
            textBox5.ScrollToCaret();
        }

        public bool GetHidDevice()
        {
            bool Status = false;
            //byte[] test_data = new byte[64];//bincent add
            //bool test_status = true;
            try
            {
                // Attempt to assign local HID object to HID in devices list with matching VID and PID
                //HeadsetHIDDevice = usbHIDDevices[VID, PID, 65299, 1] as CyHidDevice;
                HeadsetHIDDevice = usbHIDDevices[VID, PID, 1, 0] as CyHidDevice;

                // If we find a valid device, update the GUI with device information
                if (HeadsetHIDDevice != null)
                {
                    Status = true;
                    textBox3.Text = "Connected";
                    textBox3.BackColor = DefaultBackColor;
                    textBox3.ForeColor = Color.Green;
                    textBox3.ReadOnly = true;
                    //gLogger.d(TAG, "Device Connected");
                    textBox1.Text = Convert.ToString(HeadsetHIDDevice.VendorID, 16);// BootloaderHIDDevice.VendorID.ToString();
                    //textBox1.BackColor = Color.Green;//LightBlue
                    textBox2.Text = Convert.ToString(HeadsetHIDDevice.ProductID, 16);//BootloaderHIDDevice.ProductID.ToString(); 
                    //textBox2.BackColor = Color.Green;//LightBlue

                    //bincentadd
                    /*
                    BootloaderHIDDevice.Outputs.DataBuf[0] = (byte)174;
                    BootloaderHIDDevice.Outputs.DataBuf[1] = (byte)15;
                    BootloaderHIDDevice.Outputs.DataBuf[2] = (byte)16;
                    BootloaderHIDDevice.Outputs.DataBuf[3] = (byte)17;

                    BootloaderHIDDevice.Outputs.DataBuf[4] = (byte)18;
                    BootloaderHIDDevice.Outputs.DataBuf[5] = (byte)19;
                    BootloaderHIDDevice.Outputs.DataBuf[6] = (byte)20;
                    BootloaderHIDDevice.Outputs.DataBuf[7] = (byte)21;

                    for (int i = 8; i < 64; i++)
                    {
                        BootloaderHIDDevice.Outputs.DataBuf[i] = (byte)i;
                    }
                    BootloaderHIDDevice.WriteOutput();
                    */

                }

                // If there is no matching device, display Disconnected on GUI
                else
                {
                    Status = false;
                    textBox3.Text = "Disconnected";
                    textBox3.BackColor = DefaultBackColor;
                    textBox3.ForeColor = Color.Red;
                    textBox3.ReadOnly = true;
                    gLogger.d(TAG, "Warning!!!Device Disconnected");
                    //textBox1.BackColor = Color.Red;//LightYellow
                    //textBox2.BackColor = Color.Red;//LightYellow
                }

                return (Status);
            }

            catch
            {
                MessageBox.Show(" Device not connected");
                return (Status);
            }
        }

        public bool ReadFWVersion()
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
            res = GetFWVerFromIAP(out recvbuff);
            if (res)
            {
                if (recvbuff[0] != (byte)90 || recvbuff[1] != (byte)168 || (recvbuff[2] != byte.MaxValue || recvbuff[3] != (byte)0))
                {
                    int num = (int)MessageBox.Show("Read FW Version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
                if (recvbuff[6] == 0)
                {
                    textBox8.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                    //int num = (int)MessageBox.Show("ReadFWVersion succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    //return true;
                }
                else if (recvbuff[6] == 1)
                {
                    textBox8.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                    //int num = (int)MessageBox.Show("ReadFWVersion succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    //return true;
                }

                byte[] buf_temp = new byte[4];
                Array.Copy(recvbuff, 7, buf_temp, 0, buf_temp.Length);
                //received_data = ByteArrayToString(buf_temp);

                textBox4.Text = ByteArrayToString(buf_temp);
                return true;
            }
            return false;
        }

        public bool SendDSPInit()
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
            res = SendDSPInitFromIAP(out recvbuff);
            if (res)
            {
                if (recvbuff[0] != Constants.HEADER_RESP_WRITE || recvbuff[3] != Constants.CMD_IG_UPD_RESULT || recvbuff[4] != Constants.CMD_IG_UPD_INIT)
                {
                    int num = (int)MessageBox.Show("SendDSPInit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }

                uint RspResult = BitConverter.ToUInt32(recvbuff, 5);
                if (RspResult == 0)
                {
                   // gLogger.d(TAG, "init" );

                    return true;
                }

                gLogger.d(TAG, "SendDSPErase ErrorCode=" + RspResult.ToString());
                WriteLog("SendDSPErase ErrorCode=" + RspResult.ToString(), false);
                return false;
            }
            return false;
        }

        public bool SendDSPErase(uint StartAddr, uint Size)
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
            res = SendDSPEraseFromIAP(StartAddr, Size, out recvbuff);
            if (res)
            {
                if (recvbuff[0] != Constants.HEADER_RESP_WRITE || recvbuff[3] != Constants.CMD_IG_UPD_RESULT || recvbuff[4] != Constants.CMD_IG_UPD_ERASE)
                {
                    int num = (int)MessageBox.Show("SendDSPErase", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }

                uint RspResult = BitConverter.ToUInt32(recvbuff, 5);
                if (RspResult == 0)
                {
                    gLogger.d(TAG, "erase");
                    return true;
                }

                gLogger.d(TAG, "SendDSPErase ErrorCode=" + RspResult.ToString());
                WriteLog("SendDSPErase ErrorCode=" + RspResult.ToString(), false);
                return false;
            }
            return false;
        }

        public bool SendDSPUpdate(byte[] Data, uint Address, byte FrameNumber)
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
            res = SendDSPUpdateFromIAP(Data, Address, FrameNumber, out recvbuff);
            if (res)
            {
                if (recvbuff[0] != Constants.HEADER_RESP_WRITE || recvbuff[3] != Constants.CMD_IG_UPD_RESULT || recvbuff[4] != Constants.CMD_IG_UPD_WRITE)
                {
                    int num = (int)MessageBox.Show("SendDSPUpdate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
                            
                    uint RspResult = BitConverter.ToUInt32(recvbuff, 5);
                    uint RspAddr = BitConverter.ToUInt32(recvbuff, 9);
                    if (RspAddr == Address && RspResult == 0)
                    {
                     // gLogger.d(TAG, "write");
                       return true;
                    }
                    gLogger.d(TAG, "SendDSPUpdate ErrorCode=" + RspResult.ToString() + ", Address Mismatch :" + Address.ToString() + "/" + RspAddr.ToString());
                    WriteLog("SendDSPUpdate ErrorCode=" + RspResult.ToString() + ", Address Mismatch :" + Address.ToString() + "/" + RspAddr.ToString(), false);

                    return false;
            }
            return false;
        }

        public bool SendDSPUpdateEnd()
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
            res = SendDSPUpdateEndFromIAP(out recvbuff);
            if (res)
            {
                if (recvbuff[0] != Constants.HEADER_RESP_WRITE || recvbuff[3] != Constants.CMD_IG_UPD_RESULT || recvbuff[4] != Constants.CMD_IG_UPD_END)
                {
                    int num = (int)MessageBox.Show("SendDSPUpdateEnd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    gLogger.d(TAG, "enderror");
                    return false;
                }

                uint RspResult = BitConverter.ToUInt32(recvbuff, 5);
                if (RspResult == 0)
                {
                    return true;
                }

                gLogger.d(TAG, "SendDSPUpdateEnd ErrorCode=" + RspResult.ToString());
                WriteLog("SendDSPUpdateEnd ErrorCode=" + RspResult.ToString(), false);
                return false;
            }
            return false;
        }


        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            for (int i = 0; i < ba.Length; i++)       // <-- Use for loop is faster than foreach   
                hex.Append(ba[i].ToString("X2"));   // <-- ToString is faster than AppendFormat   

            return hex.ToString();
        }

        /// <summary>
        /// Checks if the USB device is connected and opens if it is present
        /// Returns a success or failure
        /// </summary>
        public int OpenConnection()
        {
            int status = 0;
            status = GetHidDevice() ? ERR_SUCCESS : ERR_OPEN;
            return status;
        }

        /// <summary>
        /// Closes the previously opened USB device and returns the status
        /// </summary>
        public int CloseConnection()
        {
            int status = 0;
            HeadsetHIDDevice = null;
            return status;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GetHidDevice())
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                new Thread(new ThreadStart(this.ReadFWVersionThreadUSB))
                {
                    CurrentCulture = Thread.CurrentThread.CurrentCulture,
                    CurrentUICulture = Thread.CurrentThread.CurrentUICulture
                }.Start();
            }
            else
            {
                //textBox5.Text += "No Device Connected \r\n";
                WriteLogHome("No Device Connected", false);
                gLogger.d(TAG, "No Device Connected");
                //MessageBox.Show("No Device Connected");
                int num = (int)MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!GetHidDevice())
            {
                CloseConnection();
                usbHIDDevices = null;

                usbHIDDevices = new USBDeviceList(CyConst.DEVICES_HID);
                //InitLogger();

                //Adding event handlers for device attachment and device removal            
                usbHIDDevices.DeviceAttached += new EventHandler(usbHIDDevices_DeviceChecker);
                usbHIDDevices.DeviceRemoved += new EventHandler(usbHIDDevices_DeviceChecker);
                GetHidDevice();
            }
        }

        private void dsp_progressbar_set(UInt32 length, UInt32 val)
        {
            progressbar_upd_dsp.Maximum = (int)length;
            progressbar_upd_dsp.Value = (int)val;
        }

        private delegate void ProgressBarShow(UInt32 length, UInt32 val);
        private delegate void ShowDSPUpdateStatus(sbyte status);
        private delegate void ControlButtonEnable(bool enable);

        private void dsp_progressbar_show(UInt32 length, UInt32 val)
        {
            ProgressBarShow bar = new ProgressBarShow(dsp_progressbar_set);
            this.BeginInvoke(bar, new Object[] { length, val });
        }

        private void dsp_update_status_set(sbyte status)
        {
            if (status == 0)
            {
                lb_dsp_udate_status.BackColor = Color.White;
                lb_dsp_udate_status.Text = "Going";
                WriteLog("Update status: Going", false);
            }
            else if (status < 0)
            {
                lb_dsp_udate_status.BackColor = Color.Salmon;
                lb_dsp_udate_status.Text = "FAIL";
                WriteLog("Update status: FAIL", false);
            }
            else if (status > 0)
            {
                lb_dsp_udate_status.BackColor = Color.Chartreuse;
                lb_dsp_udate_status.Text = "PASS";
                WriteLog("Update status: PASS", false);
            }
        }

        private void dsp_update_status_show(sbyte status)
        {
            ShowDSPUpdateStatus bar = new ShowDSPUpdateStatus(dsp_update_status_set);
            this.BeginInvoke(bar, new Object[] { status });
        }

        private void ControlButtonEnableStatus(bool enable)
        {
            if (enable)
            {
                btn_upd_dsp.Enabled = true;
                btn_select_dsp_image.Enabled = true;
                btn_send_dsp_erase.Enabled = true;
            }
            else
            {
                btn_upd_dsp.Enabled = false;
                btn_select_dsp_image.Enabled = false;
                btn_send_dsp_erase.Enabled = false;
            }
        }

        private void ControlButtonEnableFunc(bool status)
        {
            ControlButtonEnable bar = new ControlButtonEnable(ControlButtonEnableStatus);
            this.BeginInvoke(bar, new Object[] { status });
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (GetHidDevice())
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                new Thread(new ThreadStart(this.SendDSPInitThreadUSB))
                {
                    CurrentCulture = Thread.CurrentThread.CurrentCulture,
                    CurrentUICulture = Thread.CurrentThread.CurrentUICulture
                }.Start();
            }
            else
            {
                //textBox5.Text += "No Device Connected \r\n";
                WriteLog("No Device Connected", false);
                gLogger.d(TAG, "No Device Connected");
                int num = (int)MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            }
        }

        static public DialogResult Show(string message, string title,MessageBoxButtons buttons)
        {
            // Create a host form that is a TopMost window which will be the 
            // parent of the MessageBox.
            Form topmostForm = new Form();
            // We do not want anyone to see this window so position it off the 
            // visible screen and make it as small as possible
            topmostForm.Size = new System.Drawing.Size(1, 1);
            topmostForm.StartPosition = FormStartPosition.Manual;
            System.Drawing.Rectangle rect = SystemInformation.VirtualScreen;
            topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10,
                rect.Right + 10);
            topmostForm.Show();
            // Make this form the active form and make it TopMost
            topmostForm.Focus();
            topmostForm.BringToFront();
            topmostForm.TopMost = true;
            // Finally show the MessageBox with the form just created as its owner
            DialogResult result = MessageBox.Show(topmostForm, message, title,
                buttons, MessageBoxIcon.Hand);
            topmostForm.Dispose(); // clean it up all the way

            return result;
        }

        private void btn_select_dsp_image_Click(object sender, EventArgs e)//book
        {
            string sourcedir = @"c:\ig_update";
            string msg;
            DirectoryInfo sdinfo = new DirectoryInfo(sourcedir);
            if (!sdinfo.Exists)
            {
               sdinfo.Create();
                MessageBox.Show("目錄建立c:\\ig_update");
            }  
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\ig_update";
            openFileDialog1.Filter = "Database files (*.bin)|*.bin;";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dsp_file_content = null;
                dsp_file_content = File.ReadAllBytes(openFileDialog1.FileName);
                tb_dsp_bin_path.Text = openFileDialog1.FileName;
                //MessageBox.Show("Open DSP bin file success");
                int num = (int)MessageBox.Show("Open DSP Image File success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);//DefaultDesktopOnly  ServiceNotification



            }
            else
            {
                //MessageBox.Show("Open DSP bin file fail");
                int num = (int)MessageBox.Show("Open DSP Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                //int num = (int)Show("Open DSP Image File", "Error", MessageBoxButtons.OK);//, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                tb_dsp_bin_path.Text = "";
                dsp_file_content = null;
            }
        }

        private void btn_send_dsp_erase_Click(object sender, EventArgs e)
        {
            if (dsp_file_content == null)
            {
                int num = (int)MessageBox.Show("Please select image file first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            if (GetHidDevice())
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                new Thread(new ThreadStart(this.SendDSPEraseThreadUSB))
                {
                    CurrentCulture = Thread.CurrentThread.CurrentCulture,
                    CurrentUICulture = Thread.CurrentThread.CurrentUICulture
                }.Start();
            }
            else
            {
                //textBox5.Text += "No Device Connected \r\n";
                WriteLog("No Device Connected", false);
                gLogger.d(TAG, "No Device Connected");
                //MessageBox.Show("No Device Connected");
                int num = (int)MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            }
        }

        private void btn_upd_dsp_Click(object sender, EventArgs e)
        {
            if (dsp_file_content == null)
            {
                int num = (int)MessageBox.Show("Please select image file first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            if (GetHidDevice())
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                new Thread(new ThreadStart(this.SendDSPUpdateThreadUSB))
                {
                    CurrentCulture = Thread.CurrentThread.CurrentCulture,
                    CurrentUICulture = Thread.CurrentThread.CurrentUICulture
                }.Start();
            }
            else
            {
                //textBox5.Text += "No Device Connected \r\n";
                WriteLog("No Device Connected", false);
                gLogger.d(TAG, "No Device Connected");
                //MessageBox.Show("No Device Connected");
                int num = (int)MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            metroTabControl1.SelectedTab = metroTabControl1.TabPages[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (GetHidDevice())
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                new Thread(new ThreadStart(this.SendDSPInitThreadUSB))
                {
                    CurrentCulture = Thread.CurrentThread.CurrentCulture,
                    CurrentUICulture = Thread.CurrentThread.CurrentUICulture
                }.Start();
            }
            else
            {
                //textBox5.Text += "No Device Connected \r\n";
                WriteLog("No Device Connected", false);
                gLogger.d(TAG, "No Device Connected");
                int num = (int)MessageBox.Show("No Device Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            }
  

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progressbar_upd_dsp_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
