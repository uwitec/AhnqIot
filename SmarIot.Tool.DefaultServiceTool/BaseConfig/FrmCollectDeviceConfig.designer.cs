namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    partial class FrmCollectDeviceConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtShowValue = new System.Windows.Forms.NumericUpDown();
            this.txtOriginalValue = new System.Windows.Forms.TextBox();
            this.txtProccessedValue = new System.Windows.Forms.TextBox();
            this.txtRegisterAddress = new System.Windows.Forms.TextBox();
            this.txtRegisterSize = new System.Windows.Forms.TextBox();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.cbSensor = new System.Windows.Forms.ComboBox();
            this.cbModularDevice = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.编号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.变送器编号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.传感器编号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.功能码 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.原始值 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.显示值 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.处理值 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.更新时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.寄存器长度 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.寄存器地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.位置 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstShowData = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShowValue)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtShowValue);
            this.groupBox1.Controls.Add(this.txtOriginalValue);
            this.groupBox1.Controls.Add(this.txtProccessedValue);
            this.groupBox1.Controls.Add(this.txtRegisterAddress);
            this.groupBox1.Controls.Add(this.txtRegisterSize);
            this.groupBox1.Controls.Add(this.txtFunction);
            this.groupBox1.Controls.Add(this.cbSensor);
            this.groupBox1.Controls.Add(this.cbModularDevice);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 175);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtShowValue
            // 
            this.txtShowValue.DecimalPlaces = 2;
            this.txtShowValue.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.txtShowValue.Location = new System.Drawing.Point(494, 16);
            this.txtShowValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtShowValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtShowValue.Name = "txtShowValue";
            this.txtShowValue.Size = new System.Drawing.Size(84, 21);
            this.txtShowValue.TabIndex = 7;
            this.txtShowValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOriginalValue
            // 
            this.txtOriginalValue.Location = new System.Drawing.Point(494, 102);
            this.txtOriginalValue.Name = "txtOriginalValue";
            this.txtOriginalValue.Size = new System.Drawing.Size(85, 21);
            this.txtOriginalValue.TabIndex = 9;
            this.txtOriginalValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOriginalValue_KeyPress);
            // 
            // txtProccessedValue
            // 
            this.txtProccessedValue.Location = new System.Drawing.Point(494, 58);
            this.txtProccessedValue.Name = "txtProccessedValue";
            this.txtProccessedValue.Size = new System.Drawing.Size(84, 21);
            this.txtProccessedValue.TabIndex = 8;
            this.txtProccessedValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProccessedValue_KeyPress);
            // 
            // txtRegisterAddress
            // 
            this.txtRegisterAddress.Location = new System.Drawing.Point(299, 102);
            this.txtRegisterAddress.Name = "txtRegisterAddress";
            this.txtRegisterAddress.Size = new System.Drawing.Size(85, 21);
            this.txtRegisterAddress.TabIndex = 5;
            this.txtRegisterAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegisterAddress_KeyPress);
            // 
            // txtRegisterSize
            // 
            this.txtRegisterSize.Location = new System.Drawing.Point(299, 58);
            this.txtRegisterSize.Name = "txtRegisterSize";
            this.txtRegisterSize.Size = new System.Drawing.Size(85, 21);
            this.txtRegisterSize.TabIndex = 4;
            this.txtRegisterSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegisterSize_KeyPress);
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(298, 15);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(86, 21);
            this.txtFunction.TabIndex = 3;
            this.txtFunction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFunction_KeyPress);
            // 
            // cbSensor
            // 
            this.cbSensor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSensor.FormattingEnabled = true;
            this.cbSensor.ItemHeight = 12;
            this.cbSensor.Location = new System.Drawing.Point(95, 102);
            this.cbSensor.Name = "cbSensor";
            this.cbSensor.Size = new System.Drawing.Size(86, 20);
            this.cbSensor.TabIndex = 2;
            // 
            // cbModularDevice
            // 
            this.cbModularDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModularDevice.FormattingEnabled = true;
            this.cbModularDevice.ItemHeight = 12;
            this.cbModularDevice.Location = new System.Drawing.Point(95, 58);
            this.cbModularDevice.Name = "cbModularDevice";
            this.cbModularDevice.Size = new System.Drawing.Size(86, 20);
            this.cbModularDevice.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "传感器：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(435, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "处理值：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "模块化设备：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(435, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "显示值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "寄存器地址：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "功能码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "原始值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "寄存器长度：";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(534, 144);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 55;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(416, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(95, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(85, 21);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 310);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "采集设备列表";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.编号,
            this.名称,
            this.变送器编号,
            this.传感器编号,
            this.功能码,
            this.原始值,
            this.显示值,
            this.处理值,
            this.更新时间,
            this.寄存器长度,
            this.寄存器地址,
            this.位置});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(628, 290);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 99;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // 编号
            // 
            this.编号.Text = "编号";
            this.编号.Width = 48;
            // 
            // 名称
            // 
            this.名称.Text = "名称";
            this.名称.Width = 55;
            // 
            // 变送器编号
            // 
            this.变送器编号.Text = "模块化设备";
            this.变送器编号.Width = 83;
            // 
            // 传感器编号
            // 
            this.传感器编号.Text = "传感器";
            this.传感器编号.Width = 78;
            // 
            // 功能码
            // 
            this.功能码.Text = "功能码";
            this.功能码.Width = 71;
            // 
            // 原始值
            // 
            this.原始值.Text = "原始值";
            // 
            // 显示值
            // 
            this.显示值.Text = "显示值";
            // 
            // 处理值
            // 
            this.处理值.Text = "处理值";
            this.处理值.Width = 67;
            // 
            // 更新时间
            // 
            this.更新时间.Text = "更新时间";
            this.更新时间.Width = 74;
            // 
            // 寄存器长度
            // 
            this.寄存器长度.Text = "寄存器长度";
            this.寄存器长度.Width = 74;
            // 
            // 寄存器地址
            // 
            this.寄存器地址.Text = "寄存器地址";
            this.寄存器地址.Width = 41;
            // 
            // 位置
            // 
            this.位置.Text = "位置";
            this.位置.Width = 65;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.groupBox3.Controls.Add(this.lstShowData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(634, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 485);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示数据列表";
            // 
            // lstShowData
            // 
            this.lstShowData.CheckBoxes = true;
            this.lstShowData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lstShowData.ContextMenuStrip = this.contextMenuStrip1;
            this.lstShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstShowData.FullRowSelect = true;
            this.lstShowData.GridLines = true;
            this.lstShowData.Location = new System.Drawing.Point(3, 17);
            this.lstShowData.MultiSelect = false;
            this.lstShowData.Name = "lstShowData";
            this.lstShowData.Size = new System.Drawing.Size(222, 465);
            this.lstShowData.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstShowData.TabIndex = 89;
            this.lstShowData.UseCompatibleStateImageBehavior = false;
            this.lstShowData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "所属采集设备";
            this.columnHeader5.Width = 86;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "所属展示设备";
            this.columnHeader6.Width = 85;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "位置";
            this.columnHeader7.Width = 67;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(297, 145);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(85, 21);
            this.txtLocation.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 69;
            this.label1.Text = "位置：";
            // 
            // FrmCollectDeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 485);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FrmCollectDeviceConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采集设备管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShowValue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 编号;
        private System.Windows.Forms.ColumnHeader 名称;
        private System.Windows.Forms.ColumnHeader 功能码;
        private System.Windows.Forms.ColumnHeader 原始值;
        private System.Windows.Forms.ColumnHeader 显示值;
        private System.Windows.Forms.ColumnHeader 更新时间;
        private System.Windows.Forms.ColumnHeader 寄存器长度;
        private System.Windows.Forms.ColumnHeader 处理值;
        private System.Windows.Forms.ColumnHeader 寄存器地址;
        private System.Windows.Forms.ColumnHeader 位置;
        private System.Windows.Forms.ColumnHeader 变送器编号;
        private System.Windows.Forms.ColumnHeader 传感器编号;
        private System.Windows.Forms.ComboBox cbSensor;
        private System.Windows.Forms.ComboBox cbModularDevice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstShowData;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox txtOriginalValue;
        private System.Windows.Forms.TextBox txtProccessedValue;
        private System.Windows.Forms.TextBox txtRegisterAddress;
        private System.Windows.Forms.TextBox txtRegisterSize;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.NumericUpDown txtShowValue;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label1;
    }
}