using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;   // Marshal copy
using System.IO;                        // For File handling
using CyUSB;				            // For Cypress USB HID device

//bincent add
using System.Threading;
using System.Collections;
using System.Globalization;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Xml;

namespace USBBootloaderHost
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Error values
        /// </summary>
        internal const int ERR_SUCCESS = 0;
        internal const int ERR_OPEN = 1;
        internal const int ERR_CLOSE = 2;
        internal const int ERR_READ = 3;
        internal const int ERR_WRITE = 4;

        public CyHidDevice BootloaderHIDDevice;
        public static object lockIniDevice = new object();
        public USBDeviceList usbHIDDevices = null;
        private FileLogger gLogger = FileLogger.Instance;
        private string TAG = "USBBootloaderHost";
        int VID = 0x0416;//bincent mark 0x04B4 ;
        int PID = 0x3f00;//bincent mark 0xB71D;

        // String holding the Cyacd file path/name
        string Chosen_File_Cyacd = "";
        bool Cyacd_found;

        // For checking bootloading progress
        double progressBarProgress;
        double progressBarStepSize;
        Bootloader_Utils.CyBtldr_CommunicationsData comm_data = new Bootloader_Utils.CyBtldr_CommunicationsData();

        static UInt32[] crcTable =
        {
          0x00000000, 0x04c11db7, 0x09823b6e, 0x0d4326d9, 0x130476dc, 0x17c56b6b, 0x1a864db2, 0x1e475005,
          0x2608edb8, 0x22c9f00f, 0x2f8ad6d6, 0x2b4bcb61, 0x350c9b64, 0x31cd86d3, 0x3c8ea00a, 0x384fbdbd,
          0x4c11db70, 0x48d0c6c7, 0x4593e01e, 0x4152fda9, 0x5f15adac, 0x5bd4b01b, 0x569796c2, 0x52568b75,
          0x6a1936c8, 0x6ed82b7f, 0x639b0da6, 0x675a1011, 0x791d4014, 0x7ddc5da3, 0x709f7b7a, 0x745e66cd,
          0x9823b6e0, 0x9ce2ab57, 0x91a18d8e, 0x95609039, 0x8b27c03c, 0x8fe6dd8b, 0x82a5fb52, 0x8664e6e5,
          0xbe2b5b58, 0xbaea46ef, 0xb7a96036, 0xb3687d81, 0xad2f2d84, 0xa9ee3033, 0xa4ad16ea, 0xa06c0b5d,
          0xd4326d90, 0xd0f37027, 0xddb056fe, 0xd9714b49, 0xc7361b4c, 0xc3f706fb, 0xceb42022, 0xca753d95,
          0xf23a8028, 0xf6fb9d9f, 0xfbb8bb46, 0xff79a6f1, 0xe13ef6f4, 0xe5ffeb43, 0xe8bccd9a, 0xec7dd02d,
          0x34867077, 0x30476dc0, 0x3d044b19, 0x39c556ae, 0x278206ab, 0x23431b1c, 0x2e003dc5, 0x2ac12072,
          0x128e9dcf, 0x164f8078, 0x1b0ca6a1, 0x1fcdbb16, 0x018aeb13, 0x054bf6a4, 0x0808d07d, 0x0cc9cdca,
          0x7897ab07, 0x7c56b6b0, 0x71159069, 0x75d48dde, 0x6b93dddb, 0x6f52c06c, 0x6211e6b5, 0x66d0fb02,
          0x5e9f46bf, 0x5a5e5b08, 0x571d7dd1, 0x53dc6066, 0x4d9b3063, 0x495a2dd4, 0x44190b0d, 0x40d816ba,
          0xaca5c697, 0xa864db20, 0xa527fdf9, 0xa1e6e04e, 0xbfa1b04b, 0xbb60adfc, 0xb6238b25, 0xb2e29692,
          0x8aad2b2f, 0x8e6c3698, 0x832f1041, 0x87ee0df6, 0x99a95df3, 0x9d684044, 0x902b669d, 0x94ea7b2a,
          0xe0b41de7, 0xe4750050, 0xe9362689, 0xedf73b3e, 0xf3b06b3b, 0xf771768c, 0xfa325055, 0xfef34de2,
          0xc6bcf05f, 0xc27dede8, 0xcf3ecb31, 0xcbffd686, 0xd5b88683, 0xd1799b34, 0xdc3abded, 0xd8fba05a,
          0x690ce0ee, 0x6dcdfd59, 0x608edb80, 0x644fc637, 0x7a089632, 0x7ec98b85, 0x738aad5c, 0x774bb0eb,
          0x4f040d56, 0x4bc510e1, 0x46863638, 0x42472b8f, 0x5c007b8a, 0x58c1663d, 0x558240e4, 0x51435d53,
          0x251d3b9e, 0x21dc2629, 0x2c9f00f0, 0x285e1d47, 0x36194d42, 0x32d850f5, 0x3f9b762c, 0x3b5a6b9b,
          0x0315d626, 0x07d4cb91, 0x0a97ed48, 0x0e56f0ff, 0x1011a0fa, 0x14d0bd4d, 0x19939b94, 0x1d528623,
          0xf12f560e, 0xf5ee4bb9, 0xf8ad6d60, 0xfc6c70d7, 0xe22b20d2, 0xe6ea3d65, 0xeba91bbc, 0xef68060b,
          0xd727bbb6, 0xd3e6a601, 0xdea580d8, 0xda649d6f, 0xc423cd6a, 0xc0e2d0dd, 0xcda1f604, 0xc960ebb3,
          0xbd3e8d7e, 0xb9ff90c9, 0xb4bcb610, 0xb07daba7, 0xae3afba2, 0xaafbe615, 0xa7b8c0cc, 0xa379dd7b,
          0x9b3660c6, 0x9ff77d71, 0x92b45ba8, 0x9675461f, 0x8832161a, 0x8cf30bad, 0x81b02d74, 0x857130c3,
          0x5d8a9099, 0x594b8d2e, 0x5408abf7, 0x50c9b640, 0x4e8ee645, 0x4a4ffbf2, 0x470cdd2b, 0x43cdc09c,
          0x7b827d21, 0x7f436096, 0x7200464f, 0x76c15bf8, 0x68860bfd, 0x6c47164a, 0x61043093, 0x65c52d24,
          0x119b4be9, 0x155a565e, 0x18197087, 0x1cd86d30, 0x029f3d35, 0x065e2082, 0x0b1d065b, 0x0fdc1bec,
          0x3793a651, 0x3352bbe6, 0x3e119d3f, 0x3ad08088, 0x2497d08d, 0x2056cd3a, 0x2d15ebe3, 0x29d4f654,
          0xc5a92679, 0xc1683bce, 0xcc2b1d17, 0xc8ea00a0, 0xd6ad50a5, 0xd26c4d12, 0xdf2f6bcb, 0xdbee767c,
          0xe3a1cbc1, 0xe760d676, 0xea23f0af, 0xeee2ed18, 0xf0a5bd1d, 0xf464a0aa, 0xf9278673, 0xfde69bc4,
          0x89b8fd09, 0x8d79e0be, 0x803ac667, 0x84fbdbd0, 0x9abc8bd5, 0x9e7d9662, 0x933eb0bb, 0x97ffad0c,
          0xafb010b1, 0xab710d06, 0xa6322bdf, 0xa2f33668, 0xbcb4666d, 0xb8757bda, 0xb5365d03, 0xb1f740b4
        };

        

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
                textBox7.Text = BootloaderHIDDevice.Product;
                ReadFWVersion();
            }

            WriteLog("System started", true);
        }

        //bincent add
        private void InitLogger()
        {
            gLogger.initFileLogger("./Logger/log4net.config", "", true);
            gLogger.d(TAG, "init logger");
        }

        private bool GetFileInfo(
            out uint StartAddr,
            out List<FILEPARTINFO> FIleInfo,
            string filePath)
        {
            StartAddr = 0U;
            FIleInfo = (List<FILEPARTINFO>)null;
            if (filePath == string.Empty)
                return false;
            string str1 = filePath;
            string upper = str1.Substring(str1.LastIndexOf("\\")).ToUpper();
            string str2 = upper;
            if (str2.Substring(str2.Length - 3, 3) == "HEX")
            {
                //FIleInfo = this.AddValueHex(filePath);
                //StartAddr = 0U;
                int num = (int)MessageBox.Show("The download file format error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            else
            {
                string str3 = upper;
                if (str3.Substring(str3.Length - 3, 3) == "BIN")
                {
                    FIleInfo = AddValueBin(filePath);
                    // string text = textBox_AppAddress.Text;
                    string text = 8000.ToString();
                    StartAddr = StringToUInt32(text, 16);
                }
                else
                {
                    int num = (int)MessageBox.Show("The download file format error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
            }
            if (FIleInfo == null)
            {
                int num = (int)MessageBox.Show("The download file info error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            if (FIleInfo.Count != 0)
                return true;
            int num1 = (int)MessageBox.Show("The download file info count error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            return false;
        }

        public List<FILEPARTINFO> AddValueBin(string FilePath)
        {
            if (!File.Exists(FilePath))
                return (List<FILEPARTINFO>)null;
            List<FILEPARTINFO> filepartinfoList1 = new List<FILEPARTINFO>();
            FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
            int length = (int)fileStream.Length;
            if (length == 0)
                return (List<FILEPARTINFO>)null;
            FILEPARTINFO filepartinfo1 = new FILEPARTINFO();
            filepartinfo1.PartStartAddress = 0U;
            int num1 = length % 2048 != 0 ? length / 2048 + 1 : length / 2048;
            filepartinfo1.PartEndAddress = (int) num1 * 2048;//change file size instead of  0
            filepartinfo1.PartSize = 2048;
            filepartinfo1.PartData = new byte[2048];
            for (int index = 0; index < 2048; ++index)
                filepartinfo1.PartData[index] = byte.MaxValue;
            filepartinfoList1.Add(filepartinfo1);
            int index1 = 0;
            for (int index2 = 0; index2 < length; ++index2)
            {
                List<FILEPARTINFO> filepartinfoList2 = filepartinfoList1;
                filepartinfoList2[filepartinfoList2.Count - 1].PartData[index1] = binaryReader.ReadByte();
                ++index1;
                if (index1 == 2048)
                {
                    FILEPARTINFO filepartinfo2 = new FILEPARTINFO();
                    FILEPARTINFO filepartinfo3 = filepartinfo2;
                    List<FILEPARTINFO> filepartinfoList3 = filepartinfoList1;
                    int num = (int)filepartinfoList3[filepartinfoList3.Count - 1].PartStartAddress + 2048;
                    filepartinfo3.PartStartAddress = (uint)num;
                    filepartinfo2.PartData = new byte[2048];
                    for (int index3 = 0; index3 < 2048; ++index3)
                        filepartinfo2.PartData[index3] = byte.MaxValue;
                    filepartinfoList1.Add(filepartinfo2);
                    index1 = 0;
                }
            }
            return filepartinfoList1;
        }

        public static uint StringToUInt32(string value, int fromBase)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            try
            {
                return Convert.ToUInt32(value, fromBase);
            }
            catch
            {
                return 0;
            }
        }

        private void DownloadThreadUSB()
        {
            lock (lockIniDevice)
            {
                List<FILEPARTINFO> FIleInfo = (List<FILEPARTINFO>)null;
                //new Thread(new ThreadStart(this.ShowForm)).Start();
                //this.frm_Progress.SetOprationInfo("Downloading.......");
                //this.frm_Progress.SetProgress(100, 0);
                uint StartAddr = 0;
                if (!GetFileInfo(out StartAddr, out FIleInfo, textBox6.Text))
                {
                    int num = (int)MessageBox.Show("File info parse error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                else
                {
                    bool res = false;
                    byte[] recvbuff = (byte[])null;
                    uint fileAddr = 0;
                    for (int index = 0; index < 5; ++index)
                    {
                        gLogger.d(TAG, "OpenConnection retry...." + index.ToString());
                        if (OpenConnection() != ERR_SUCCESS)
                        {
                            int num = (int)MessageBox.Show("Can't open the usb device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);                         
                            return;
                        }

                        if (!EnterIAPModeUSB())
                        {
                            int num = (int)MessageBox.Show("Can't enter IAP mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            CloseConnection();
                            return;
                        }
                        Thread.Sleep(2000);
                        fileAddr = StartAddr + FIleInfo[0].PartStartAddress;
                        res = GetAppAddrFromIAP(fileAddr, out recvbuff);
                        if (!res)
                            CloseConnection();
                        else
                            break;
                    }
                    if (!IsAppAddrSuccess(res, fileAddr, recvbuff))
                    {                     
                        CloseConnection();
                    }
                    else if (!BeginDownUSB(FIleInfo))
                    {
                        CloseConnection();
                    }
                    else
                    {
                        ProgressUpdateValue(5);
                        if (!DownloadDataToDeviceUSB(StartAddr, FIleInfo))
                        {
                            CloseConnection();
                        }
                        else if (!DownloadEndUSB())
                        {
                            CloseConnection();
                        }
                        else
                        {
                            if (checkBox_CRC.Checked)
                            {                              
                                //textBox5.Text += "CRC Verify....... \r\n";
                                WriteLog("CRC Verify...", false);
                                gLogger.d(TAG, "CRC Verify.......");
                                if (!CRCVerifyUSB(StartAddr, FIleInfo))
                                {
                                    CloseConnection();
                                    return;
                                }
                            }
                            if (!JumpToAppUSB())
                            {
                                CloseConnection();
                            }
                            else
                            {
                                ProgressUpdateValue(100);
                                if (checkBox_CRC.Checked)
                                {
                                    int num1 = (int)MessageBox.Show("Download and CRC Verify succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                }
                                else
                                {
                                    int num2 = (int)MessageBox.Show("Download succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                }
                                CloseConnection();
                            }
                        }
                    }
                }
            }
        }

        private void EnterIAPThreadUSB()
        {
            lock (lockIniDevice)
            {
                for (int index = 0; index < 3; ++index)
                {
                    if (OpenConnection() != ERR_SUCCESS)
                    {
                        int num = (int)MessageBox.Show("Can't open the usb device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return;
                    }

                    if (!JumpToAppUSB())
                    {
                        int num = (int)MessageBox.Show("Can't enter IAP mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        CloseConnection();
                        //return;
                    }
                    else
                    {
                        gLogger.d(TAG, "EnterIAPMode succeed");
                        int num1 = (int)MessageBox.Show("EnterIAPMode succeed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        break;
                    }

                }
                Thread.Sleep(3000);
                CloseConnection();
            }
        }

        private bool JumpToAppUSB()
        {
            byte[] sendBuff = new byte[2];
            byte[] recvBuff = new byte[4];
            sendBuff[0] = (byte)90;//5A
            sendBuff[1] = (byte)166;//A6
            recvBuff[0] = (byte)0;
            recvBuff[1] = (byte)0;
            if (!PortSendUSB(sendBuff))
            {
                int num = (int)MessageBox.Show("USB device send data error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            return true;
#if false
            if (!this.PortCommunicationUSB(sendBuff, recvBuff))
            {
                int num = (int)MessageBox.Show("USB device communication error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            if (recvBuff[0] == (byte)90 && recvBuff[1] == (byte)166 && (recvBuff[2] == byte.MaxValue && recvBuff[3] == (byte)0))
                return true;
            int num1 = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            return false;
#endif
        }

        private bool CRCVerifyUSB(uint StartAddr, List<FILEPARTINFO> FIleInfo)
        {
            for (int index = 0; index < FIleInfo.Count; ++index)//++index  index += 2
            {
                uint num1 = StartAddr + FIleInfo[index].PartStartAddress;
                uint num2 = 2;//21
                byte[] sendBuff = new byte[8];
                byte[] recvBuff = new byte[8];
                sendBuff[0] = (byte)90;
                sendBuff[1] = (byte)165;
                sendBuff[2] = (byte)(num1 >> 24);
                sendBuff[3] = (byte)(num1 >> 16 & (uint)byte.MaxValue);
                sendBuff[4] = (byte)(num1 >> 8 & (uint)byte.MaxValue);
                sendBuff[5] = (byte)(num1 & (uint)byte.MaxValue);
                sendBuff[6] = (byte)(num2 >> 8 & (uint)byte.MaxValue);
                sendBuff[7] = (byte)(num2 & (uint)byte.MaxValue);
                recvBuff[0] = (byte)0;
                recvBuff[1] = (byte)0;
                if (!PortCommunicationUSB(sendBuff, recvBuff))
                {
                    int num3 = (int)MessageBox.Show("USB device communication error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
                if (recvBuff[0] != (byte)90 || recvBuff[1] != (byte)165 || (recvBuff[2] != byte.MaxValue || recvBuff[3] != (byte)0))
                {
                    int num3 = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
                
                //byte[] package = { 255, 13, 45, 56 };
                uint loadFileCrcCode = GetCRC32(FIleInfo[index].PartData);
                if (((int)recvBuff[4] << 24) + ((int)recvBuff[5] << 16) + ((int)recvBuff[6] << 8) + (int)recvBuff[7] != (int)loadFileCrcCode)
                {
                    int num3 = (int)MessageBox.Show("USB device CRC verify failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    //textBox5.Text += "CRC Verify test fail, index=" + index.ToString() + ", PartStartAddress=" + num1.ToString() + ", loadFileCrcCode = " + loadFileCrcCode.ToString() + "\r\n";
                    WriteLog("CRC Verify test fail, index=" + index.ToString() + ", PartStartAddress=" + num1.ToString() + ", loadFileCrcCode = " + loadFileCrcCode.ToString(), false);
                    gLogger.d(TAG, "CRC Verify test fail, index=" + index.ToString() + ", PartStartAddress=" + num1.ToString() + ", loadFileCrcCode = " + loadFileCrcCode.ToString());
                    return false;
                }
                //textBox5.Text += "CRC Verify test pas, index=" + index.ToString() + ", PartStartAddress=" + num1.ToString() + ", loadFileCrcCode = " + loadFileCrcCode.ToString() + "\r\n";
                WriteLog("CRC Verify test pass, index=" + index.ToString() + ", PartStartAddress=" + num1.ToString() + ", loadFileCrcCode = " + loadFileCrcCode.ToString(), false);
                gLogger.d(TAG, "CRC Verify test pass, index=" + index.ToString() + ", PartStartAddress=" + num1.ToString() + ", loadFileCrcCode = " + loadFileCrcCode.ToString());
            }
            return true;
        }

        /*private uint GetLoadFileCRCCode(byte[] pFileAllData, int reallength)
        {
            int num1 = reallength;
            uint num2 = uint.MaxValue;
            for (int index = 0; index < num1; ++index)
                num2 = num2 << 8 ^ crc32table[((int)(num2 >> 24) ^ (int)pFileAllData[index]) & (int)byte.MaxValue];
            return num2;
        }*/

        private uint GetCRC32(byte[] bytes)
        {
            uint iCount = (uint)bytes.Length;
            uint crc = 0xFFFFFFFF;

            for (uint i = 0; i < iCount; i++)
            {
                crc = (crc << 8) ^ crcTable[(crc >> 24) ^ bytes[i]];
            }

            return crc;
        }

        private bool DownloadEndUSB()
        {
            byte[] sendBuff = new byte[2];
            byte[] recvBuff = new byte[4];
            sendBuff[0] = (byte)90;
            sendBuff[1] = (byte)164;
            recvBuff[0] = (byte)0;
            recvBuff[1] = (byte)0;
            if (!PortCommunicationUSB(sendBuff, recvBuff))
            {
                int num = (int)MessageBox.Show("USB device communication error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            if (recvBuff[0] == (byte)90 && recvBuff[1] == (byte)164 && (recvBuff[2] == byte.MaxValue && recvBuff[3] == (byte)0))
                return true;
            int num1 = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            return false;
        }

        private bool DownloadDataToDeviceUSB(uint StartAddr, List<FILEPARTINFO> FIleInfo)
        {
            byte[] numArray = new byte[2];
            byte[] recvBuff = new byte[4];
            string empty = string.Empty;
            byte[] sendBuff1 = new byte[64];
            byte[] sendBuff2 = new byte[6];
            for (int index1 = 0; index1 < FIleInfo.Count; ++index1)
            {
                for (uint index2 = 0; (long)index2 < (long)(FIleInfo[index1].PartData.Length / 1024); ++index2)
                {
                    uint num1 = (uint)((int)StartAddr + (int)FIleInfo[index1].PartStartAddress + (int)index2 * 1024);
                    sendBuff2[0] = (byte)90;
                    sendBuff2[1] = (byte)162;
                    sendBuff2[2] = (byte)(num1 >> 24);
                    sendBuff2[3] = (byte)(num1 >> 16 & (uint)byte.MaxValue);
                    sendBuff2[4] = (byte)(num1 >> 8 & (uint)byte.MaxValue);
                    sendBuff2[5] = (byte)(num1 & (uint)byte.MaxValue);
                    if (!PortCommunicationUSB(sendBuff2, recvBuff))
                    {
                        int num2 = (int)MessageBox.Show("USB device communication error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return false;
                    }
                    if (recvBuff[0] != (byte)90 || recvBuff[1] != (byte)162 || (recvBuff[2] != byte.MaxValue || recvBuff[3] != (byte)0))
                    {
                        int num2 = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return false;
                    }
                    int num3 = (int)(65 - 5);
                    //textBox5.Text += "DUT max size:" + num3.ToString() + "\r\n";
                    int num4 = 1024 % num3 != 0 ? 1024 / num3 + 1 : 1024 / num3;
                    sendBuff1[0] = (byte)90;
                    sendBuff1[1] = (byte)163;
                    for (int index3 = 0; index3 < num4; ++index3)
                    {
                        int num2 = (index3 + 1) * num3 <= 1024 ? num3 : 1024 - index3 * num3;
                        sendBuff1[2] = (byte)(num2 >> 8 & (int)byte.MaxValue);
                        sendBuff1[3] = (byte)(num2 & (int)byte.MaxValue);
                        for (int index4 = 0; index4 < num2; ++index4)
                            sendBuff1[index4 + 4] = FIleInfo[index1].PartData[(long)(index2 * 1024U) + (long)(index3 * num3) + (long)index4];
                        if (!PortSendUSB(sendBuff1))
                        {
                            int num5 = (int)MessageBox.Show("USB device send data error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                            return false;
                        }
                    }
                    //textBox5.Text += "PortReadUSB before:" + "\r\n";
                    if (!PortReadUSB(recvBuff))
                    {
                        int num2 = (int)MessageBox.Show("USB device receive data error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return false;
                    }
                    //textBox5.Text += "PortReadUSB after:" + "\r\n";
                    if (recvBuff[0] != (byte)90 || recvBuff[1] != (byte)163 || (recvBuff[2] != byte.MaxValue || recvBuff[3] != (byte)0))
                    {
                        int num2 = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return false;
                    }
                }
                ProgressUpdateValue((int)(5.0 + (double)(index1 + 1) * 1.0 / (double)FIleInfo.Count * 90.0));
            }
            return true;
        }

        private bool PortReadUSB(byte[] recvBuff)
        {
            if (recvBuff == null)
                return false;
            int num = 0;
label_2:
            try
            {               
                byte[] rbuff = recvBuff;
                int length = rbuff.Length;
                byte[] buf_temp = new byte[length];
                string received_data;

                if (!GetHidDevice())
                    return false;

                if (BootloaderHIDDevice.ReadInput())
                {
                    buf_temp = BootloaderHIDDevice.Inputs.DataBuf;
                    received_data = ByteArrayToString(buf_temp);
                    //textBox5.Text += "Received_data_from single read:" + received_data + "\r\n";
                    WriteLog("Received_data_from single read:" + received_data, false);
                    gLogger.d(TAG, "Received_data_from single read:" + received_data);
                    Array.Copy(buf_temp, 1, rbuff, 0, Math.Min(length, buf_temp.Length));
                    return true;
                }
                Thread.Sleep(10);
                ++num;
                if (num >= 500)
                    return false;
                goto label_2;
            }
            catch
            {
                return false;
            }
        }

        private bool PortSendUSB(byte[] sendBuff)
        {
            if (sendBuff == null)
                return false;
            try
            {
                if (!GetHidDevice())
                    return false;

                BootloaderHIDDevice.Outputs.DataBuf[0] = BootloaderHIDDevice.Outputs.ID;
                //Load 64 bytes of data
                //textBox5.Text = "debug sendBuff.Length:" + sendBuff.Length.ToString() + "\r\n";
                for (int i = 1; i <= sendBuff.Length; i++)
                {
                    BootloaderHIDDevice.Outputs.DataBuf[i] = sendBuff[i - 1];
                }

                //status = BootloaderHIDDevice.WriteOutput();
                if (!BootloaderHIDDevice.WriteOutput())
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool BeginDownUSB(List<FILEPARTINFO> FIleInfo)
        {
            byte[] sendBuff = new byte[6];//original 2
            byte[] recvBuff = new byte[4];
            uint num = (uint)((int)FIleInfo[0].PartEndAddress);
            sendBuff[0] = (byte)90;
            sendBuff[1] = (byte)161;
            sendBuff[2] = (byte)(num >> 24);
            sendBuff[3] = (byte)(num >> 16 & (uint)byte.MaxValue);
            sendBuff[4] = (byte)(num >> 8 & (uint)byte.MaxValue);
            sendBuff[5] = (byte)(num & (uint)byte.MaxValue);
            if (!PortCommunicationUSB(sendBuff, recvBuff))
            {
                int num1 = (int)MessageBox.Show("USB port communication error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            if (recvBuff[0] == (byte)90 && recvBuff[1] == (byte)161 && (recvBuff[2] == byte.MaxValue && recvBuff[3] == (byte)0))
                return true;
            int num2 = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            return false;
        }

        private bool IsAppAddrSuccess(bool res, uint fileAddr, byte[] recvbuff)
        {
            if (!res)
            {
                int num = (int)MessageBox.Show("USB port communication error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            if (recvbuff[0] != (byte)90 || recvbuff[1] != (byte)167 || (recvbuff[2] != byte.MaxValue || recvbuff[3] != (byte)0))
            {
                int num = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            uint num1 = (uint)(((int)recvbuff[4] << 24) + ((int)recvbuff[5] << 16) + ((int)recvbuff[6] << 8)) + (uint)recvbuff[7];
            if ((int)fileAddr == (int)num1)
                return true;
            int num2 = (int)MessageBox.Show("File download address is different from the APP address of IAP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            return false;
        }

        private bool GetAppAddrFromIAP(uint fileAddr, out byte[] recvbuff)
        {
            byte[] sendBuff = new byte[2];
            recvbuff = new byte[8];
            sendBuff[0] = (byte)90;
            sendBuff[1] = (byte)167;
            return PortCommunicationUSB(sendBuff, recvbuff);
        }

        private bool GetFWVerFromIAP(out byte[] recvbuff)
        {
            byte[] sendBuff = new byte[2];
            recvbuff = new byte[7];
            sendBuff[0] = (byte)90;
            sendBuff[1] = (byte)168;
            return PortCommunicationUSB(sendBuff, recvbuff);
        }

        private bool EnterIAPModeUSB()
        {
            byte[] sendBuff = new byte[2];
            byte[] recvBuff = new byte[4];
            sendBuff[0] = (byte)90;
            sendBuff[1] = (byte)160;
            if (!PortCommunicationUSB(sendBuff, recvBuff))
            {
                int num = (int)MessageBox.Show("USB port communication error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }
            if (recvBuff[0] == (byte)90 && recvBuff[1] == (byte)160 && (recvBuff[2] == byte.MaxValue && recvBuff[3] == (byte)0))
                return true;
            int num1 = (int)MessageBox.Show("USB device receive NACK", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            return false;
        }

        private bool PortCommunicationUSB(byte[] sendBuff, byte[] recvBuff)
        {
            if (GetHidDevice())
            {
                if (sendBuff != null)
                {
                    if (recvBuff != null)
                    {
                        try
                        {                           
                            BootloaderHIDDevice.Outputs.DataBuf[0] = BootloaderHIDDevice.Outputs.ID;
                            //Load 64 bytes of data
                            for (int i = 1; i <= sendBuff.Length; i++)
                            {
                                BootloaderHIDDevice.Outputs.DataBuf[i] = sendBuff[i - 1];
                            }

                            if (!BootloaderHIDDevice.WriteOutput())
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

                            if (!GetHidDevice())
                                return false;

                            if (BootloaderHIDDevice.ReadInput())
                            {
                                buf_temp = BootloaderHIDDevice.Inputs.DataBuf;
                                received_data = ByteArrayToString(buf_temp);
                                gLogger.d(TAG, "Received_data:" + received_data);
                                //textBox5.Text += "Received_data:" + received_data + "\r\n";
                                WriteLog("Received_data:" + received_data, false);
                                Array.Copy(buf_temp, 1, rbuff, 0, Math.Min(length, buf_temp.Length));                               
                                return true;
                            }
                            Thread.Sleep(10);
                            ++num;
                            if (num >= 500)
                                return false;
                            goto label_1;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            else
                return false;
        }

        void WriteLog(string message, bool clear)
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

        public void ReadFWVersion()
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
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
                    textBox4.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                }
                else if (recvbuff[6] == 1)
                {
                    textBox8.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                }
            }
        }

        /// <summary>
        /// The GetHidDevice Method checks for the presence of a specific USB HID device and updates the status
        /// </summary>
        /// <returns>bool</returns>
        public bool GetHidDevice()
        {
            bool Status = false;
            try
            {
                // Attempt to assign local HID object to HID in devices list with matching VID and PID
                BootloaderHIDDevice = usbHIDDevices[VID, PID] as CyHidDevice;

                // If we find a valid device, update the GUI with device information
                if (BootloaderHIDDevice != null)
                {
                    Status = true;
                    textBox3.Text = "Connected";
                    textBox3.BackColor = DefaultBackColor;
                    textBox3.ForeColor = Color.Green;
                    textBox3.ReadOnly = true;
                    //gLogger.d(TAG, "Device Connected");
                    textBox1.Text = Convert.ToString(BootloaderHIDDevice.VendorID, 16);// BootloaderHIDDevice.VendorID.ToString();
                    //textBox1.BackColor = Color.Green;//LightBlue
                    textBox2.Text = Convert.ToString(BootloaderHIDDevice.ProductID, 16);//BootloaderHIDDevice.ProductID.ToString(); 

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
                }

                return (Status);
            }

            catch
            {
                MessageBox.Show(" Device not connected");
                return (Status);
            }
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
            BootloaderHIDDevice = null;
            return status;
        }

        /// <summary>
        /// Method that performs Read operation from USB Device
        /// </summary>
        /// <param name="buffer"> Pointer to an array where data read from USB device is copied to </param>
        /// <param name="size"> Size of the Buffer </param>
        /// <returns></returns>
        public int ReadData(IntPtr buffer, int size)
        {
            int status;
            bool local_status = false;
            byte[] data = new byte[size];
            string received_data;//bincent add

            //Check if USB device exists
            if (GetHidDevice())
            {
                local_status = BootloaderHIDDevice.ReadInput();
                data = BootloaderHIDDevice.Inputs.DataBuf;
                received_data = ByteArrayToString(data);
                //textBox5.Text += "Received_data:" + received_data + "\r\n";//bincent add
                Marshal.Copy(data, 1, buffer, Math.Min(size, data.Length));
                status = local_status ? ERR_SUCCESS : ERR_READ;
            }
            else
                status = ERR_READ;

            return status;
        }

        /// <summary>
        /// Method that writes to the USB device
        /// </summary>
        /// <param name="buffer">Pointer to an array where data written to USB device is stored </param>
        /// <param name="size"> Size of the Buffer </param>
        /// <returns></returns>
        public int WriteData(IntPtr buffer, int size)
        {
            byte[] data = new byte[64];
            bool status = true;

            Marshal.Copy(buffer, data, 0, size);

            if (GetHidDevice())
            {
                //First Byte in buffer holds the Report ID
                //BootloaderHIDDevice.Outputs.DataBuf[0] = BootloaderHIDDevice.Outputs.ID;
                BootloaderHIDDevice.Outputs.DataBuf[0] = (byte)174;//bincent add 

                //Load 64 bytes of data
                for (int i = 1; i <= size; i++)
                {
                    BootloaderHIDDevice.Outputs.DataBuf[i] = data[i - 1];
                }

                status = BootloaderHIDDevice.WriteOutput();

                if (status)
                    return ERR_SUCCESS;
                else
                    return ERR_WRITE;
            }
            else
                return ERR_WRITE;

        }

        /// <summary>
        /// Method that returns the maximum transfer size
        /// </summary>
        public uint MaxTransferSize
        {
            get { return (uint)BootloaderHIDDevice.Features.RptByteLen; }
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

        /// <summary>
        ///  This is the event handler for Device Connection event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>           
        void usbHIDDevices_DeviceChecker(object sender, EventArgs e)
        {
            bool res = false;
            byte[] recvbuff = (byte[])null;
            if (GetHidDevice())
            {
                textBox7.Text = BootloaderHIDDevice.Product;
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
                        textBox4.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                    }
                    else if (recvbuff[6] == 1)
                    {
                        textBox8.Text = Convert.ToString(recvbuff[4], 10) + "." + Convert.ToString(recvbuff[5], 10);
                    }
                }
            }
            else
            {
                textBox4.Text = "0.00";
                textBox8.Text = "0.00";
            }
             
        }

        /// <summary>
        /// This method handles the "Load File" Button1 Click event and lets you choose the 
        /// appropriate bin file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //int lines;
            openFileDialog1.Title = "Open Binary File";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Binary File|*.bin|All Files(*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Chosen_File_Cyacd = openFileDialog1.FileName;
                textBox6.Text = Chosen_File_Cyacd;

                //lines = File.ReadAllLines(Chosen_File_Cyacd).Length - 1; //Don't count header
                //progressBarStepSize = 100.0 / lines;
                Cyacd_found = true;
            }
        }

        /// <summary>
        /// This Method handles the "Program" Button2 Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {

            USBDeviceList HidDevices = new USBDeviceList(CyConst.DEVICES_HID);
            CyHidDevice hidDev = HidDevices[0] as CyHidDevice;
            hidDev.ReadInput();

           // ReturnCodes local_status = 0;
            progressBarProgress = 0;
            progressBar1.Value = 0;
            if (Cyacd_found)
            {
                if (GetHidDevice())
                {
                    Control.CheckForIllegalCrossThreadCalls = false;
                    new Thread(new ThreadStart(this.DownloadThreadUSB))
                    {
                        CurrentCulture = Thread.CurrentThread.CurrentCulture,
                        CurrentUICulture = Thread.CurrentThread.CurrentUICulture
                    }.Start();
                }
                else
                {
                    //textBox5.Text += "No Device Connected \r\n";
                    WriteLog("No Device Connected: ", false);
                    gLogger.d(TAG, "No Device Connected");
                    MessageBox.Show("No Device Connected");
                }

            }
            else
            {
                MessageBox.Show("No file chosen");
            }
        }

        /// <summary>
        /// Method that updates the progres bar
        /// </summary>
        /// <param name="arrayID"></param>
        /// <param name="rowNum"></param>
        public void ProgressUpdate(byte arrayID, ushort rowNum)
        {
            progressBarProgress += progressBarStepSize;
            progressBar1.Value = (int)(progressBarProgress);
            this.Refresh();

            return;
        }

        public void ProgressUpdateValue(int current)
        {
            progressBar1.Value = current;
            this.Refresh();

            return;
        }
        //bincent add
        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            for (int i = 0; i < ba.Length; i++)       // <-- Use for loop is faster than foreach   
                hex.Append(ba[i].ToString("X2"));   // <-- ToString is faster than AppendFormat   

            return hex.ToString();
        }

        public class FILEPARTINFO
        {
            public uint PartStartAddress;
            public int PartEndAddress;
            public int PartSize;
            public int PartChecksum;
            public byte[] PartData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GetHidDevice())
            {
                CloseConnection();
                
            }
                Control.CheckForIllegalCrossThreadCalls = false;
                usbHIDDevices = null;

                usbHIDDevices = new USBDeviceList(CyConst.DEVICES_HID);

                //Adding event handlers for device attachment and device removal            
                usbHIDDevices.DeviceAttached += new EventHandler(usbHIDDevices_DeviceChecker);
                usbHIDDevices.DeviceRemoved += new EventHandler(usbHIDDevices_DeviceChecker);

                BootloaderHIDDevice = usbHIDDevices[0x0416, 0x140F, 1, 0] as CyHidDevice;

                new Thread(new ThreadStart(this.EnterIAPThreadUSB))
                {
                    CurrentCulture = Thread.CurrentThread.CurrentCulture,
                    CurrentUICulture = Thread.CurrentThread.CurrentUICulture
                }.Start();
            
            //else
            //{
                
                //WriteLog("No Device Connected: ", false);
                //gLogger.d(TAG, "No Device Connected");
                //MessageBox.Show("No Device Connected");
            //}
        }
    }
}
