namespace TabControlsDemo
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tb = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox_CRC = new System.Windows.Forms.CheckBox();
            this.metroProgressBar2 = new MetroFramework.Controls.MetroProgressBar();
            this.tb_app_bin_path = new MetroFramework.Controls.MetroTextBox();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.b_vid = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.boot_hid_state = new System.Windows.Forms.TextBox();
            this.b_pid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lablel1 = new System.Windows.Forms.Label();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.lb_dsp_udate_status = new System.Windows.Forms.Label();
            this.hid_state = new System.Windows.Forms.TextBox();
            this.device_n = new System.Windows.Forms.TextBox();
            this.app_pid = new System.Windows.Forms.TextBox();
            this.app_vid = new System.Windows.Forms.TextBox();
            this.app_version = new System.Windows.Forms.TextBox();
            this.dsp_version = new System.Windows.Forms.TextBox();
            this.progressbar_upd_dsp = new MetroFramework.Controls.MetroProgressBar();
            this.tb_dsp_bin_path = new MetroFramework.Controls.MetroTextBox();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.htmlToolTip1 = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.app_version2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tb.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 46);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kensington Test V1.45";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(799, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb
            // 
            this.tb.Controls.Add(this.metroTabPage1);
            this.tb.Controls.Add(this.metroTabPage2);
            this.tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb.Location = new System.Drawing.Point(0, 46);
            this.tb.Name = "tb";
            this.tb.SelectedIndex = 1;
            this.tb.Size = new System.Drawing.Size(869, 427);
            this.tb.TabIndex = 1;
            this.tb.UseSelectable = true;
            this.tb.SelectedIndexChanged += new System.EventHandler(this.metroTabControl1_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.textBox1);
            this.metroTabPage1.Controls.Add(this.label14);
            this.metroTabPage1.Controls.Add(this.app_version2);
            this.metroTabPage1.Controls.Add(this.label10);
            this.metroTabPage1.Controls.Add(this.button6);
            this.metroTabPage1.Controls.Add(this.checkBox_CRC);
            this.metroTabPage1.Controls.Add(this.metroProgressBar2);
            this.metroTabPage1.Controls.Add(this.tb_app_bin_path);
            this.metroTabPage1.Controls.Add(this.metroButton5);
            this.metroTabPage1.Controls.Add(this.metroButton1);
            this.metroTabPage1.Controls.Add(this.button3);
            this.metroTabPage1.Controls.Add(this.button2);
            this.metroTabPage1.Controls.Add(this.textBox5);
            this.metroTabPage1.Controls.Add(this.label2);
            this.metroTabPage1.Controls.Add(this.textBox4);
            this.metroTabPage1.Controls.Add(this.label7);
            this.metroTabPage1.Controls.Add(this.b_vid);
            this.metroTabPage1.Controls.Add(this.textBox7);
            this.metroTabPage1.Controls.Add(this.label6);
            this.metroTabPage1.Controls.Add(this.boot_hid_state);
            this.metroTabPage1.Controls.Add(this.b_pid);
            this.metroTabPage1.Controls.Add(this.label8);
            this.metroTabPage1.Controls.Add(this.label9);
            this.metroTabPage1.Controls.Add(this.lablel1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 9;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(861, 385);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "APP";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            this.metroTabPage1.Click += new System.EventHandler(this.metroTabPage1_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("華康儷細黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button6.Location = new System.Drawing.Point(740, 32);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 23);
            this.button6.TabIndex = 54;
            this.button6.Text = "Enter bootMode";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox_CRC
            // 
            this.checkBox_CRC.AutoSize = true;
            this.checkBox_CRC.Location = new System.Drawing.Point(8, 82);
            this.checkBox_CRC.Name = "checkBox_CRC";
            this.checkBox_CRC.Size = new System.Drawing.Size(154, 16);
            this.checkBox_CRC.TabIndex = 53;
            this.checkBox_CRC.Text = "CRC Verify after download";
            this.checkBox_CRC.UseVisualStyleBackColor = true;
            // 
            // metroProgressBar2
            // 
            this.metroProgressBar2.Location = new System.Drawing.Point(149, 137);
            this.metroProgressBar2.Name = "metroProgressBar2";
            this.metroProgressBar2.Size = new System.Drawing.Size(591, 24);
            this.metroProgressBar2.TabIndex = 52;
            // 
            // tb_app_bin_path
            // 
            // 
            // 
            // 
            this.tb_app_bin_path.CustomButton.Image = null;
            this.tb_app_bin_path.CustomButton.Location = new System.Drawing.Point(565, 1);
            this.tb_app_bin_path.CustomButton.Name = "";
            this.tb_app_bin_path.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.tb_app_bin_path.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_app_bin_path.CustomButton.TabIndex = 1;
            this.tb_app_bin_path.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_app_bin_path.CustomButton.UseSelectable = true;
            this.tb_app_bin_path.CustomButton.Visible = false;
            this.tb_app_bin_path.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_app_bin_path.Lines = new string[0];
            this.tb_app_bin_path.Location = new System.Drawing.Point(149, 104);
            this.tb_app_bin_path.MaxLength = 32767;
            this.tb_app_bin_path.Multiline = true;
            this.tb_app_bin_path.Name = "tb_app_bin_path";
            this.tb_app_bin_path.PasswordChar = '\0';
            this.tb_app_bin_path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_app_bin_path.SelectedText = "";
            this.tb_app_bin_path.SelectionLength = 0;
            this.tb_app_bin_path.SelectionStart = 0;
            this.tb_app_bin_path.ShortcutsEnabled = true;
            this.tb_app_bin_path.Size = new System.Drawing.Size(591, 27);
            this.tb_app_bin_path.TabIndex = 51;
            this.tb_app_bin_path.UseSelectable = true;
            this.tb_app_bin_path.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_app_bin_path.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(8, 137);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(101, 24);
            this.metroButton5.TabIndex = 50;
            this.metroButton5.Text = "UpDate APP";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(8, 104);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(101, 27);
            this.metroButton1.TabIndex = 49;
            this.metroButton1.Text = "Select APP Image";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_2);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("華康儷細黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(740, -2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 22);
            this.button3.TabIndex = 40;
            this.button3.Text = "Re-connect";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("華康儷細黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(740, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 24);
            this.button2.TabIndex = 39;
            this.button2.Text = "ReadFWVersion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(8, 220);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(747, 134);
            this.textBox5.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "Status Log";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(257, 3);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(55, 22);
            this.textBox4.TabIndex = 36;
            this.textBox4.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(156, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 14);
            this.label7.TabIndex = 35;
            this.label7.Text = "Boot Version : ";
            // 
            // b_vid
            // 
            this.b_vid.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_vid.Location = new System.Drawing.Point(95, 36);
            this.b_vid.Name = "b_vid";
            this.b_vid.Size = new System.Drawing.Size(55, 22);
            this.b_vid.TabIndex = 34;
            this.b_vid.Text = "0416";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(582, 61);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(171, 22);
            this.textBox7.TabIndex = 33;
            this.textBox7.Text = "Null";
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(475, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 31;
            this.label6.Text = "Device Name : ";
            // 
            // boot_hid_state
            // 
            this.boot_hid_state.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boot_hid_state.Location = new System.Drawing.Point(434, 28);
            this.boot_hid_state.Name = "boot_hid_state";
            this.boot_hid_state.ReadOnly = true;
            this.boot_hid_state.Size = new System.Drawing.Size(99, 22);
            this.boot_hid_state.TabIndex = 29;
            this.boot_hid_state.Text = "Disconnected";
            // 
            // b_pid
            // 
            this.b_pid.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_pid.Location = new System.Drawing.Point(257, 33);
            this.b_pid.Name = "b_pid";
            this.b_pid.Size = new System.Drawing.Size(55, 22);
            this.b_pid.TabIndex = 28;
            this.b_pid.Text = "140F";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(331, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 14);
            this.label8.TabIndex = 27;
            this.label8.Text = "USB HID State";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Window;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 14);
            this.label9.TabIndex = 26;
            this.label9.Text = "Product ID 0x";
            // 
            // lablel1
            // 
            this.lablel1.AutoSize = true;
            this.lablel1.BackColor = System.Drawing.SystemColors.Window;
            this.lablel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablel1.Location = new System.Drawing.Point(0, 36);
            this.lablel1.Name = "lablel1";
            this.lablel1.Size = new System.Drawing.Size(89, 14);
            this.lablel1.TabIndex = 25;
            this.lablel1.Text = "Vendor ID 0x";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.lb_dsp_udate_status);
            this.metroTabPage2.Controls.Add(this.hid_state);
            this.metroTabPage2.Controls.Add(this.device_n);
            this.metroTabPage2.Controls.Add(this.app_pid);
            this.metroTabPage2.Controls.Add(this.app_vid);
            this.metroTabPage2.Controls.Add(this.app_version);
            this.metroTabPage2.Controls.Add(this.dsp_version);
            this.metroTabPage2.Controls.Add(this.progressbar_upd_dsp);
            this.metroTabPage2.Controls.Add(this.tb_dsp_bin_path);
            this.metroTabPage2.Controls.Add(this.metroButton6);
            this.metroTabPage2.Controls.Add(this.metroButton2);
            this.metroTabPage2.Controls.Add(this.button5);
            this.metroTabPage2.Controls.Add(this.button4);
            this.metroTabPage2.Controls.Add(this.label13);
            this.metroTabPage2.Controls.Add(this.label12);
            this.metroTabPage2.Controls.Add(this.label11);
            this.metroTabPage2.Controls.Add(this.label5);
            this.metroTabPage2.Controls.Add(this.label4);
            this.metroTabPage2.Controls.Add(this.label3);
            this.metroTabPage2.Controls.Add(this.metroTextBox1);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 9;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(861, 385);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "DSP update";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            this.metroTabPage2.Click += new System.EventHandler(this.metroTabPage2_Click);
            // 
            // lb_dsp_udate_status
            // 
            this.lb_dsp_udate_status.AutoSize = true;
            this.lb_dsp_udate_status.Location = new System.Drawing.Point(40, 188);
            this.lb_dsp_udate_status.Name = "lb_dsp_udate_status";
            this.lb_dsp_udate_status.Size = new System.Drawing.Size(39, 12);
            this.lb_dsp_udate_status.TabIndex = 61;
            this.lb_dsp_udate_status.Text = "label14";
            // 
            // hid_state
            // 
            this.hid_state.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hid_state.Location = new System.Drawing.Point(472, 42);
            this.hid_state.Name = "hid_state";
            this.hid_state.ReadOnly = true;
            this.hid_state.Size = new System.Drawing.Size(99, 22);
            this.hid_state.TabIndex = 60;
            this.hid_state.Text = "Disconnected";
            // 
            // device_n
            // 
            this.device_n.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.device_n.Location = new System.Drawing.Point(472, 12);
            this.device_n.Name = "device_n";
            this.device_n.ReadOnly = true;
            this.device_n.Size = new System.Drawing.Size(109, 22);
            this.device_n.TabIndex = 59;
            this.device_n.Text = "Null";
            // 
            // app_pid
            // 
            this.app_pid.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.app_pid.Location = new System.Drawing.Point(266, 37);
            this.app_pid.Name = "app_pid";
            this.app_pid.Size = new System.Drawing.Size(55, 22);
            this.app_pid.TabIndex = 58;
            this.app_pid.Text = "140F";
            this.app_pid.TextChanged += new System.EventHandler(this.pid2_TextChanged);
            // 
            // app_vid
            // 
            this.app_vid.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.app_vid.Location = new System.Drawing.Point(94, 40);
            this.app_vid.Name = "app_vid";
            this.app_vid.Size = new System.Drawing.Size(55, 22);
            this.app_vid.TabIndex = 57;
            this.app_vid.Text = "0416";
            // 
            // app_version
            // 
            this.app_version.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.app_version.Location = new System.Drawing.Point(94, 12);
            this.app_version.Name = "app_version";
            this.app_version.ReadOnly = true;
            this.app_version.Size = new System.Drawing.Size(55, 22);
            this.app_version.TabIndex = 56;
            this.app_version.Text = "0.00";
            // 
            // dsp_version
            // 
            this.dsp_version.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsp_version.Location = new System.Drawing.Point(266, 15);
            this.dsp_version.Name = "dsp_version";
            this.dsp_version.ReadOnly = true;
            this.dsp_version.Size = new System.Drawing.Size(69, 22);
            this.dsp_version.TabIndex = 55;
            // 
            // progressbar_upd_dsp
            // 
            this.progressbar_upd_dsp.Location = new System.Drawing.Point(148, 127);
            this.progressbar_upd_dsp.Name = "progressbar_upd_dsp";
            this.progressbar_upd_dsp.Size = new System.Drawing.Size(591, 24);
            this.progressbar_upd_dsp.TabIndex = 54;
            // 
            // tb_dsp_bin_path
            // 
            // 
            // 
            // 
            this.tb_dsp_bin_path.CustomButton.Image = null;
            this.tb_dsp_bin_path.CustomButton.Location = new System.Drawing.Point(565, 1);
            this.tb_dsp_bin_path.CustomButton.Name = "";
            this.tb_dsp_bin_path.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.tb_dsp_bin_path.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_dsp_bin_path.CustomButton.TabIndex = 1;
            this.tb_dsp_bin_path.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_dsp_bin_path.CustomButton.UseSelectable = true;
            this.tb_dsp_bin_path.CustomButton.Visible = false;
            this.tb_dsp_bin_path.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_dsp_bin_path.Lines = new string[0];
            this.tb_dsp_bin_path.Location = new System.Drawing.Point(148, 84);
            this.tb_dsp_bin_path.MaxLength = 32767;
            this.tb_dsp_bin_path.Multiline = true;
            this.tb_dsp_bin_path.Name = "tb_dsp_bin_path";
            this.tb_dsp_bin_path.PasswordChar = '\0';
            this.tb_dsp_bin_path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_dsp_bin_path.SelectedText = "";
            this.tb_dsp_bin_path.SelectionLength = 0;
            this.tb_dsp_bin_path.SelectionStart = 0;
            this.tb_dsp_bin_path.ShortcutsEnabled = true;
            this.tb_dsp_bin_path.Size = new System.Drawing.Size(591, 27);
            this.tb_dsp_bin_path.TabIndex = 53;
            this.tb_dsp_bin_path.UseSelectable = true;
            this.tb_dsp_bin_path.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_dsp_bin_path.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton6
            // 
            this.metroButton6.Location = new System.Drawing.Point(3, 127);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(101, 24);
            this.metroButton6.TabIndex = 52;
            this.metroButton6.Text = "UpDate DSP";
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(3, 84);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(101, 27);
            this.metroButton2.TabIndex = 51;
            this.metroButton2.Text = "Select DSP Image";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click_1);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(638, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 22);
            this.button5.TabIndex = 50;
            this.button5.Text = "Re-connect";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(638, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 24);
            this.button4.TabIndex = 49;
            this.button4.Text = "ReadFWVersion";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Window;
            this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(365, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 14);
            this.label13.TabIndex = 48;
            this.label13.Text = "USB HID State";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(365, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 14);
            this.label12.TabIndex = 47;
            this.label12.Text = "Device Name : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(173, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 14);
            this.label11.TabIndex = 46;
            this.label11.Text = "DSP Version : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 14);
            this.label5.TabIndex = 45;
            this.label5.Text = "Product ID 0x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "Vendor ID 0x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 43;
            this.label3.Text = "App Version : ";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(578, 2);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(129, 129);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(15, 216);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(710, 134);
            this.metroTextBox1.TabIndex = 42;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(15, 200);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(0, 0);
            this.metroLabel1.TabIndex = 41;
            // 
            // htmlToolTip1
            // 
            this.htmlToolTip1.OwnerDraw = true;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Window;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 14);
            this.label10.TabIndex = 55;
            this.label10.Text = "APP Version : ";
            // 
            // app_version2
            // 
            this.app_version2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.app_version2.Location = new System.Drawing.Point(95, 3);
            this.app_version2.Name = "app_version2";
            this.app_version2.ReadOnly = true;
            this.app_version2.Size = new System.Drawing.Size(55, 22);
            this.app_version2.TabIndex = 56;
            this.app_version2.Text = "0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Window;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(332, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 14);
            this.label14.TabIndex = 57;
            this.label14.Text = "DSP Version : ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(434, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(99, 22);
            this.textBox1.TabIndex = 58;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 473);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tb.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTabControl tb;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Drawing.Html.HtmlToolTip htmlToolTip1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox b_vid;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox boot_hid_state;
        private System.Windows.Forms.TextBox b_pid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lablel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar2;
        private MetroFramework.Controls.MetroTextBox tb_app_bin_path;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.CheckBox checkBox_CRC;
        private System.Windows.Forms.TextBox hid_state;
        private System.Windows.Forms.TextBox device_n;
        private System.Windows.Forms.TextBox app_pid;
        private System.Windows.Forms.TextBox app_vid;
        private System.Windows.Forms.TextBox app_version;
        private System.Windows.Forms.TextBox dsp_version;
        private MetroFramework.Controls.MetroProgressBar progressbar_upd_dsp;
        private MetroFramework.Controls.MetroTextBox tb_dsp_bin_path;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_dsp_udate_status;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox app_version2;
        private System.Windows.Forms.Label label10;
    }
}

