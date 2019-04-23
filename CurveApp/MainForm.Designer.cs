namespace CurveApp
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbLogs = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSaveFile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSave1 = new System.Windows.Forms.Button();
            this.chart1 = new ZedGraph.ZedGraphControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btSave2 = new System.Windows.Forms.Button();
            this.chart2 = new ZedGraph.ZedGraphControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btSave3 = new System.Windows.Forms.Button();
            this.chart3 = new ZedGraph.ZedGraphControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btSave4 = new System.Windows.Forms.Button();
            this.chart4 = new ZedGraph.ZedGraphControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btSave5 = new System.Windows.Forms.Button();
            this.chart5 = new ZedGraph.ZedGraphControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btSave6 = new System.Windows.Forms.Button();
            this.chart6 = new ZedGraph.ZedGraphControl();
            this.panel8 = new System.Windows.Forms.Panel();
            this.timerRefreshChart = new System.Windows.Forms.Timer(this.components);
            this.buttonOpenClose = new System.Windows.Forms.Button();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPortName = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbLogs, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbLogs
            // 
            this.tbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogs.Location = new System.Drawing.Point(23, 43);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.tbLogs, 3);
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.Size = new System.Drawing.Size(294, 363);
            this.tbLogs.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSaveFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 24);
            this.panel1.TabIndex = 7;
            // 
            // btSaveFile
            // 
            this.btSaveFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btSaveFile.Location = new System.Drawing.Point(0, 0);
            this.btSaveFile.Name = "btSaveFile";
            this.btSaveFile.Size = new System.Drawing.Size(75, 24);
            this.btSaveFile.TabIndex = 0;
            this.btSaveFile.Text = "保存为文件";
            this.btSaveFile.UseVisualStyleBackColor = true;
            this.btSaveFile.Click += new System.EventHandler(this.btSaveFile_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSave1);
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(323, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 117);
            this.panel2.TabIndex = 8;
            // 
            // btSave1
            // 
            this.btSave1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave1.Location = new System.Drawing.Point(146, 3);
            this.btSave1.Name = "btSave1";
            this.btSave1.Size = new System.Drawing.Size(75, 23);
            this.btSave1.TabIndex = 3;
            this.btSave1.Text = "保存数据";
            this.btSave1.UseVisualStyleBackColor = true;
            this.btSave1.Click += new System.EventHandler(this.btSaveChartData_Click);
            // 
            // chart1
            // 
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.ScrollGrace = 0D;
            this.chart1.ScrollMaxX = 0D;
            this.chart1.ScrollMaxY = 0D;
            this.chart1.ScrollMaxY2 = 0D;
            this.chart1.ScrollMinX = 0D;
            this.chart1.ScrollMinY = 0D;
            this.chart1.ScrollMinY2 = 0D;
            this.chart1.Size = new System.Drawing.Size(224, 117);
            this.chart1.TabIndex = 1;
            this.chart1.UseExtendedPrintDialog = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btSave2);
            this.panel3.Controls.Add(this.chart2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(553, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(224, 117);
            this.panel3.TabIndex = 9;
            // 
            // btSave2
            // 
            this.btSave2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave2.Location = new System.Drawing.Point(146, 3);
            this.btSave2.Name = "btSave2";
            this.btSave2.Size = new System.Drawing.Size(75, 23);
            this.btSave2.TabIndex = 4;
            this.btSave2.Text = "保存数据";
            this.btSave2.UseVisualStyleBackColor = true;
            this.btSave2.Click += new System.EventHandler(this.btSaveChartData_Click);
            // 
            // chart2
            // 
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            this.chart2.ScrollGrace = 0D;
            this.chart2.ScrollMaxX = 0D;
            this.chart2.ScrollMaxY = 0D;
            this.chart2.ScrollMaxY2 = 0D;
            this.chart2.ScrollMinX = 0D;
            this.chart2.ScrollMinY = 0D;
            this.chart2.ScrollMinY2 = 0D;
            this.chart2.Size = new System.Drawing.Size(224, 117);
            this.chart2.TabIndex = 2;
            this.chart2.UseExtendedPrintDialog = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btSave3);
            this.panel4.Controls.Add(this.chart3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(323, 166);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 117);
            this.panel4.TabIndex = 10;
            // 
            // btSave3
            // 
            this.btSave3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave3.Location = new System.Drawing.Point(146, 3);
            this.btSave3.Name = "btSave3";
            this.btSave3.Size = new System.Drawing.Size(75, 23);
            this.btSave3.TabIndex = 4;
            this.btSave3.Text = "保存数据";
            this.btSave3.UseVisualStyleBackColor = true;
            this.btSave3.Click += new System.EventHandler(this.btSaveChartData_Click);
            // 
            // chart3
            // 
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart3.Location = new System.Drawing.Point(0, 0);
            this.chart3.Name = "chart3";
            this.chart3.ScrollGrace = 0D;
            this.chart3.ScrollMaxX = 0D;
            this.chart3.ScrollMaxY = 0D;
            this.chart3.ScrollMaxY2 = 0D;
            this.chart3.ScrollMinX = 0D;
            this.chart3.ScrollMinY = 0D;
            this.chart3.ScrollMinY2 = 0D;
            this.chart3.Size = new System.Drawing.Size(224, 117);
            this.chart3.TabIndex = 3;
            this.chart3.UseExtendedPrintDialog = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btSave4);
            this.panel5.Controls.Add(this.chart4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(553, 166);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(224, 117);
            this.panel5.TabIndex = 11;
            // 
            // btSave4
            // 
            this.btSave4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave4.Location = new System.Drawing.Point(146, 3);
            this.btSave4.Name = "btSave4";
            this.btSave4.Size = new System.Drawing.Size(75, 23);
            this.btSave4.TabIndex = 5;
            this.btSave4.Text = "保存数据";
            this.btSave4.UseVisualStyleBackColor = true;
            this.btSave4.Click += new System.EventHandler(this.btSaveChartData_Click);
            // 
            // chart4
            // 
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart4.Location = new System.Drawing.Point(0, 0);
            this.chart4.Name = "chart4";
            this.chart4.ScrollGrace = 0D;
            this.chart4.ScrollMaxX = 0D;
            this.chart4.ScrollMaxY = 0D;
            this.chart4.ScrollMaxY2 = 0D;
            this.chart4.ScrollMinX = 0D;
            this.chart4.ScrollMinY = 0D;
            this.chart4.ScrollMinY2 = 0D;
            this.chart4.Size = new System.Drawing.Size(224, 117);
            this.chart4.TabIndex = 4;
            this.chart4.UseExtendedPrintDialog = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btSave5);
            this.panel6.Controls.Add(this.chart5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(323, 289);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(224, 117);
            this.panel6.TabIndex = 12;
            // 
            // btSave5
            // 
            this.btSave5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave5.Location = new System.Drawing.Point(146, 3);
            this.btSave5.Name = "btSave5";
            this.btSave5.Size = new System.Drawing.Size(75, 23);
            this.btSave5.TabIndex = 6;
            this.btSave5.Text = "保存数据";
            this.btSave5.UseVisualStyleBackColor = true;
            this.btSave5.Click += new System.EventHandler(this.btSaveChartData_Click);
            // 
            // chart5
            // 
            this.chart5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart5.Location = new System.Drawing.Point(0, 0);
            this.chart5.Name = "chart5";
            this.chart5.ScrollGrace = 0D;
            this.chart5.ScrollMaxX = 0D;
            this.chart5.ScrollMaxY = 0D;
            this.chart5.ScrollMaxY2 = 0D;
            this.chart5.ScrollMinX = 0D;
            this.chart5.ScrollMinY = 0D;
            this.chart5.ScrollMinY2 = 0D;
            this.chart5.Size = new System.Drawing.Size(224, 117);
            this.chart5.TabIndex = 5;
            this.chart5.UseExtendedPrintDialog = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btSave6);
            this.panel7.Controls.Add(this.chart6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(553, 289);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(224, 117);
            this.panel7.TabIndex = 13;
            // 
            // btSave6
            // 
            this.btSave6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave6.Location = new System.Drawing.Point(148, 1);
            this.btSave6.Name = "btSave6";
            this.btSave6.Size = new System.Drawing.Size(75, 23);
            this.btSave6.TabIndex = 7;
            this.btSave6.Text = "保存数据";
            this.btSave6.UseVisualStyleBackColor = true;
            this.btSave6.Click += new System.EventHandler(this.btSaveChartData_Click);
            // 
            // chart6
            // 
            this.chart6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart6.Location = new System.Drawing.Point(0, 0);
            this.chart6.Name = "chart6";
            this.chart6.ScrollGrace = 0D;
            this.chart6.ScrollMaxX = 0D;
            this.chart6.ScrollMaxY = 0D;
            this.chart6.ScrollMaxY2 = 0D;
            this.chart6.ScrollMinX = 0D;
            this.chart6.ScrollMinY = 0D;
            this.chart6.ScrollMinY2 = 0D;
            this.chart6.Size = new System.Drawing.Size(224, 117);
            this.chart6.TabIndex = 6;
            this.chart6.UseExtendedPrintDialog = true;
            // 
            // panel8
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel8, 3);
            this.panel8.Controls.Add(this.buttonOpenClose);
            this.panel8.Controls.Add(this.comboBaudrate);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.comboPortName);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(20, 10);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(760, 30);
            this.panel8.TabIndex = 14;
            // 
            // timerRefreshChart
            // 
            this.timerRefreshChart.Enabled = true;
            this.timerRefreshChart.Interval = 1000;
            this.timerRefreshChart.Tick += new System.EventHandler(this.timerRefreshChart_Tick);
            // 
            // buttonOpenClose
            // 
            this.buttonOpenClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOpenClose.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonOpenClose.ForeColor = System.Drawing.Color.Black;
            this.buttonOpenClose.Location = new System.Drawing.Point(401, 3);
            this.buttonOpenClose.Name = "buttonOpenClose";
            this.buttonOpenClose.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenClose.TabIndex = 6;
            this.buttonOpenClose.Text = "打开";
            this.buttonOpenClose.UseVisualStyleBackColor = true;
            this.buttonOpenClose.Click += new System.EventHandler(this.buttonOpenClose_Click);
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.BackColor = System.Drawing.Color.White;
            this.comboBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBaudrate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBaudrate.Location = new System.Drawing.Point(260, 3);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(121, 20);
            this.comboBaudrate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Baudrate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Port name";
            // 
            // comboPortName
            // 
            this.comboPortName.BackColor = System.Drawing.Color.White;
            this.comboPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPortName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboPortName.FormattingEnabled = true;
            this.comboPortName.Location = new System.Drawing.Point(74, 3);
            this.comboPortName.Name = "comboPortName";
            this.comboPortName.Size = new System.Drawing.Size(121, 20);
            this.comboPortName.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口程序";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbLogs;
        private ZedGraph.ZedGraphControl chart1;
        private ZedGraph.ZedGraphControl chart2;
        private ZedGraph.ZedGraphControl chart3;
        private ZedGraph.ZedGraphControl chart4;
        private ZedGraph.ZedGraphControl chart5;
        private ZedGraph.ZedGraphControl chart6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSaveFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btSave1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btSave2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btSave3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btSave4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btSave5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btSave6;
        private System.Windows.Forms.Timer timerRefreshChart;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button buttonOpenClose;
        private System.Windows.Forms.ComboBox comboBaudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPortName;
    }
}

