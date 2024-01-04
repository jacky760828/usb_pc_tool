namespace Usart1
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sendButton = new System.Windows.Forms.Button();
            this.bpsSelect = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sendBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowControlSelect = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chickBitSelect = new System.Windows.Forms.ComboBox();
            this.stopBitSelect = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataBitSelect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.usartButton = new System.Windows.Forms.Button();
            this.comSelect = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkHexSend = new System.Windows.Forms.CheckBox();
            this.checkTXNewLine = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.checkTiming = new System.Windows.Forms.CheckBox();
            this.checkGb2312ToUtf8 = new System.Windows.Forms.CheckBox();
            this.checkUtf8ToGb2312 = new System.Windows.Forms.CheckBox();
            this.receiveBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkShowReTime = new System.Windows.Forms.CheckBox();
            this.checkHexShow = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.SystemColors.Window;
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sendButton.Location = new System.Drawing.Point(457, 25);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(87, 58);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "发送数据";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // bpsSelect
            // 
            this.bpsSelect.Cursor = System.Windows.Forms.Cursors.Default;
            this.bpsSelect.DropDownWidth = 120;
            this.bpsSelect.FormattingEnabled = true;
            this.bpsSelect.ItemHeight = 15;
            this.bpsSelect.Items.AddRange(new object[] {
            "Custom",
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.bpsSelect.Location = new System.Drawing.Point(92, 72);
            this.bpsSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bpsSelect.Name = "bpsSelect";
            this.bpsSelect.Size = new System.Drawing.Size(116, 23);
            this.bpsSelect.TabIndex = 1;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 514);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "版本信息：V0.1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 359);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "端口号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "波特率：";
            // 
            // sendBox
            // 
            this.sendBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBox.Location = new System.Drawing.Point(8, 25);
            this.sendBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendBox.Multiline = true;
            this.sendBox.Name = "sendBox";
            this.sendBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sendBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendBox.Size = new System.Drawing.Size(440, 56);
            this.sendBox.TabIndex = 9;
            this.sendBox.TextChanged += new System.EventHandler(this.sendBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowControlSelect);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.chickBitSelect);
            this.groupBox1.Controls.Add(this.stopBitSelect);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dataBitSelect);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.usartButton);
            this.groupBox1.Controls.Add(this.comSelect);
            this.groupBox1.Controls.Add(this.bpsSelect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(19, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(229, 489);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置区";
            // 
            // flowControlSelect
            // 
            this.flowControlSelect.FormattingEnabled = true;
            this.flowControlSelect.Items.AddRange(new object[] {
            "Hardware",
            "Software",
            "None",
            "Custom"});
            this.flowControlSelect.Location = new System.Drawing.Point(92, 208);
            this.flowControlSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowControlSelect.Name = "flowControlSelect";
            this.flowControlSelect.Size = new System.Drawing.Size(116, 23);
            this.flowControlSelect.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 211);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "流控：";
            // 
            // chickBitSelect
            // 
            this.chickBitSelect.FormattingEnabled = true;
            this.chickBitSelect.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.chickBitSelect.Location = new System.Drawing.Point(92, 174);
            this.chickBitSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chickBitSelect.Name = "chickBitSelect";
            this.chickBitSelect.Size = new System.Drawing.Size(116, 23);
            this.chickBitSelect.TabIndex = 22;
            // 
            // stopBitSelect
            // 
            this.stopBitSelect.FormattingEnabled = true;
            this.stopBitSelect.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopBitSelect.Location = new System.Drawing.Point(92, 140);
            this.stopBitSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopBitSelect.Name = "stopBitSelect";
            this.stopBitSelect.Size = new System.Drawing.Size(116, 23);
            this.stopBitSelect.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 178);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "校验位：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "停止位：";
            // 
            // dataBitSelect
            // 
            this.dataBitSelect.FormattingEnabled = true;
            this.dataBitSelect.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.dataBitSelect.Location = new System.Drawing.Point(92, 106);
            this.dataBitSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataBitSelect.Name = "dataBitSelect";
            this.dataBitSelect.Size = new System.Drawing.Size(116, 23);
            this.dataBitSelect.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "数据位：";
            // 
            // usartButton
            // 
            this.usartButton.BackColor = System.Drawing.SystemColors.Window;
            this.usartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usartButton.FlatAppearance.BorderColor = System.Drawing.Color.PowderBlue;
            this.usartButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this.usartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.usartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.usartButton.Location = new System.Drawing.Point(16, 369);
            this.usartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usartButton.Name = "usartButton";
            this.usartButton.Size = new System.Drawing.Size(193, 50);
            this.usartButton.TabIndex = 16;
            this.usartButton.Text = "打开串口";
            this.usartButton.UseVisualStyleBackColor = false;
            this.usartButton.Click += new System.EventHandler(this.usartButton_Click);
            // 
            // comSelect
            // 
            this.comSelect.FormattingEnabled = true;
            this.comSelect.Location = new System.Drawing.Point(92, 39);
            this.comSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comSelect.MaxDropDownItems = 30;
            this.comSelect.Name = "comSelect";
            this.comSelect.Size = new System.Drawing.Size(116, 23);
            this.comSelect.TabIndex = 15;
            this.comSelect.Click += new System.EventHandler(this.comSelect_Click);
            this.comSelect.MouseLeave += new System.EventHandler(this.comSelect_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkHexSend);
            this.groupBox2.Controls.Add(this.checkTXNewLine);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.timeBox);
            this.groupBox2.Controls.Add(this.checkTiming);
            this.groupBox2.Controls.Add(this.checkGb2312ToUtf8);
            this.groupBox2.Controls.Add(this.checkUtf8ToGb2312);
            this.groupBox2.Controls.Add(this.sendButton);
            this.groupBox2.Controls.Add(this.sendBox);
            this.groupBox2.Location = new System.Drawing.Point(277, 352);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(552, 152);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送区";
            // 
            // checkHexSend
            // 
            this.checkHexSend.AutoSize = true;
            this.checkHexSend.Location = new System.Drawing.Point(273, 115);
            this.checkHexSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkHexSend.Name = "checkHexSend";
            this.checkHexSend.Size = new System.Drawing.Size(82, 19);
            this.checkHexSend.TabIndex = 16;
            this.checkHexSend.Text = "Hex发送";
            this.checkHexSend.UseVisualStyleBackColor = true;
            this.checkHexSend.Click += new System.EventHandler(this.checkHexSend_Click);
            // 
            // checkTXNewLine
            // 
            this.checkTXNewLine.AutoSize = true;
            this.checkTXNewLine.Location = new System.Drawing.Point(273, 92);
            this.checkTXNewLine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkTXNewLine.Name = "checkTXNewLine";
            this.checkTXNewLine.Size = new System.Drawing.Size(89, 19);
            this.checkTXNewLine.TabIndex = 15;
            this.checkTXNewLine.Text = "发送新行";
            this.checkTXNewLine.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(203, 92);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 14;
            this.label11.Text = "ms/次";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(99, 88);
            this.timeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(95, 25);
            this.timeBox.TabIndex = 13;
            this.timeBox.Text = "1000";
            // 
            // checkTiming
            // 
            this.checkTiming.AutoSize = true;
            this.checkTiming.Location = new System.Drawing.Point(8, 92);
            this.checkTiming.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkTiming.Name = "checkTiming";
            this.checkTiming.Size = new System.Drawing.Size(89, 19);
            this.checkTiming.TabIndex = 12;
            this.checkTiming.Text = "定时发送";
            this.checkTiming.UseVisualStyleBackColor = true;
            this.checkTiming.CheckStateChanged += new System.EventHandler(this.checkTiming_CheckStateChanged);
            // 
            // checkGb2312ToUtf8
            // 
            this.checkGb2312ToUtf8.AutoSize = true;
            this.checkGb2312ToUtf8.Location = new System.Drawing.Point(401, 92);
            this.checkGb2312ToUtf8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkGb2312ToUtf8.Name = "checkGb2312ToUtf8";
            this.checkGb2312ToUtf8.Size = new System.Drawing.Size(114, 19);
            this.checkGb2312ToUtf8.TabIndex = 11;
            this.checkGb2312ToUtf8.Text = "GB2312/UTF8";
            this.checkGb2312ToUtf8.UseVisualStyleBackColor = true;
            this.checkGb2312ToUtf8.Click += new System.EventHandler(this.checkGb2312ToUtf8_Click);
            // 
            // checkUtf8ToGb2312
            // 
            this.checkUtf8ToGb2312.AutoSize = true;
            this.checkUtf8ToGb2312.Location = new System.Drawing.Point(401, 115);
            this.checkUtf8ToGb2312.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkUtf8ToGb2312.Name = "checkUtf8ToGb2312";
            this.checkUtf8ToGb2312.Size = new System.Drawing.Size(114, 19);
            this.checkUtf8ToGb2312.TabIndex = 10;
            this.checkUtf8ToGb2312.Text = "UTF8/GB2312";
            this.checkUtf8ToGb2312.UseVisualStyleBackColor = true;
            this.checkUtf8ToGb2312.Click += new System.EventHandler(this.checkUtf8ToGb2312_Click);
            // 
            // receiveBox
            // 
            this.receiveBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveBox.Location = new System.Drawing.Point(8, 25);
            this.receiveBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.receiveBox.Multiline = true;
            this.receiveBox.Name = "receiveBox";
            this.receiveBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receiveBox.Size = new System.Drawing.Size(535, 263);
            this.receiveBox.TabIndex = 1;
            this.receiveBox.TextChanged += new System.EventHandler(this.receiveBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkShowReTime);
            this.groupBox3.Controls.Add(this.checkHexShow);
            this.groupBox3.Controls.Add(this.clearButton);
            this.groupBox3.Controls.Add(this.receiveBox);
            this.groupBox3.Location = new System.Drawing.Point(277, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(552, 329);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收区";
            // 
            // checkShowReTime
            // 
            this.checkShowReTime.AutoSize = true;
            this.checkShowReTime.Location = new System.Drawing.Point(205, 298);
            this.checkShowReTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkShowReTime.Name = "checkShowReTime";
            this.checkShowReTime.Size = new System.Drawing.Size(119, 19);
            this.checkShowReTime.TabIndex = 5;
            this.checkShowReTime.Text = "显示接收时间";
            this.checkShowReTime.UseVisualStyleBackColor = true;
            this.checkShowReTime.CheckedChanged += new System.EventHandler(this.checkShowReTime_CheckedChanged);
            // 
            // checkHexShow
            // 
            this.checkHexShow.AutoSize = true;
            this.checkHexShow.Location = new System.Drawing.Point(123, 298);
            this.checkHexShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkHexShow.Name = "checkHexShow";
            this.checkHexShow.Size = new System.Drawing.Size(82, 19);
            this.checkHexShow.TabIndex = 3;
            this.checkHexShow.Text = "Hex显示";
            this.checkHexShow.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clearButton.Location = new System.Drawing.Point(8, 292);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(105, 29);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "清除窗口";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.sendButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(845, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "usart";
            this.MaximumSizeChanged += new System.EventHandler(this.MainForm_MaximumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox bpsSelect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sendBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comSelect;
        private System.Windows.Forms.Button usartButton;
        private System.Windows.Forms.TextBox receiveBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ComboBox chickBitSelect;
        private System.Windows.Forms.ComboBox stopBitSelect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox dataBitSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox flowControlSelect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.CheckBox checkTiming;
        private System.Windows.Forms.CheckBox checkGb2312ToUtf8;
        private System.Windows.Forms.CheckBox checkUtf8ToGb2312;
        private System.Windows.Forms.CheckBox checkHexSend;
        private System.Windows.Forms.CheckBox checkTXNewLine;
        private System.Windows.Forms.CheckBox checkHexShow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkShowReTime;
    }
}

