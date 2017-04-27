namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    partial class FrmModularDeviceConfig
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtOnlineStatus = new System.Windows.Forms.CheckBox();
            this.cbCommunicateDevice = new System.Windows.Forms.ComboBox();
            this.cbProtocalType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtException = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.控制设备列表 = new System.Windows.Forms.TabPage();
            this.lstControlDevice = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.采集设备列表 = new System.Windows.Forms.TabPage();
            this.lstCollectDevice = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.摄像机列表 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.编号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.数据协议类型 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.通讯设备 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.设备地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.状态 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.异常 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.备注 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.控制设备列表.SuspendLayout();
            this.采集设备列表.SuspendLayout();
            this.摄像机列表.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.rbtOnlineStatus);
            this.groupBox1.Controls.Add(this.cbCommunicateDevice);
            this.groupBox1.Controls.Add(this.cbProtocalType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtException);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 148);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rbtOnlineStatus
            // 
            this.rbtOnlineStatus.AutoSize = true;
            this.rbtOnlineStatus.Location = new System.Drawing.Point(515, 33);
            this.rbtOnlineStatus.Name = "rbtOnlineStatus";
            this.rbtOnlineStatus.Size = new System.Drawing.Size(36, 16);
            this.rbtOnlineStatus.TabIndex = 4;
            this.rbtOnlineStatus.Text = "是";
            this.rbtOnlineStatus.UseVisualStyleBackColor = true;
            // 
            // cbCommunicateDevice
            // 
            this.cbCommunicateDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommunicateDevice.FormattingEnabled = true;
            this.cbCommunicateDevice.ItemHeight = 12;
            this.cbCommunicateDevice.Location = new System.Drawing.Point(300, 31);
            this.cbCommunicateDevice.Name = "cbCommunicateDevice";
            this.cbCommunicateDevice.Size = new System.Drawing.Size(92, 20);
            this.cbCommunicateDevice.TabIndex = 2;
            // 
            // cbProtocalType
            // 
            this.cbProtocalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProtocalType.FormattingEnabled = true;
            this.cbProtocalType.ItemHeight = 12;
            this.cbProtocalType.Location = new System.Drawing.Point(107, 84);
            this.cbProtocalType.Name = "cbProtocalType";
            this.cbProtocalType.Size = new System.Drawing.Size(92, 20);
            this.cbProtocalType.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "异常：";
            // 
            // txtException
            // 
            this.txtException.Location = new System.Drawing.Point(515, 84);
            this.txtException.Name = "txtException";
            this.txtException.Size = new System.Drawing.Size(92, 21);
            this.txtException.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(229, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "通讯设备：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(468, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "状态：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "数据协议类型：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "设备地址：";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(317, 121);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 75;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(231, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(92, 21);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // 控制设备列表
            // 
            this.控制设备列表.Controls.Add(this.lstControlDevice);
            this.控制设备列表.Location = new System.Drawing.Point(4, 22);
            this.控制设备列表.Name = "控制设备列表";
            this.控制设备列表.Padding = new System.Windows.Forms.Padding(3);
            this.控制设备列表.Size = new System.Drawing.Size(240, 396);
            this.控制设备列表.TabIndex = 1;
            this.控制设备列表.Text = "控制设备列表";
            this.控制设备列表.UseVisualStyleBackColor = true;
            // 
            // lstControlDevice
            // 
            this.lstControlDevice.CheckBoxes = true;
            this.lstControlDevice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lstControlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstControlDevice.FullRowSelect = true;
            this.lstControlDevice.GridLines = true;
            this.lstControlDevice.Location = new System.Drawing.Point(3, 3);
            this.lstControlDevice.Name = "lstControlDevice";
            this.lstControlDevice.Size = new System.Drawing.Size(234, 390);
            this.lstControlDevice.TabIndex = 65;
            this.lstControlDevice.UseCompatibleStateImageBehavior = false;
            this.lstControlDevice.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "名称";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "所属模块化设备";
            this.columnHeader10.Width = 96;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "设备类型";
            this.columnHeader11.Width = 65;
            // 
            // 采集设备列表
            // 
            this.采集设备列表.Controls.Add(this.lstCollectDevice);
            this.采集设备列表.Location = new System.Drawing.Point(4, 22);
            this.采集设备列表.Name = "采集设备列表";
            this.采集设备列表.Padding = new System.Windows.Forms.Padding(3);
            this.采集设备列表.Size = new System.Drawing.Size(240, 396);
            this.采集设备列表.TabIndex = 0;
            this.采集设备列表.Text = "采集设备列表";
            this.采集设备列表.UseVisualStyleBackColor = true;
            // 
            // lstCollectDevice
            // 
            this.lstCollectDevice.CheckBoxes = true;
            this.lstCollectDevice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstCollectDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCollectDevice.FullRowSelect = true;
            this.lstCollectDevice.GridLines = true;
            this.lstCollectDevice.Location = new System.Drawing.Point(3, 3);
            this.lstCollectDevice.Name = "lstCollectDevice";
            this.lstCollectDevice.Size = new System.Drawing.Size(234, 390);
            this.lstCollectDevice.TabIndex = 2;
            this.lstCollectDevice.UseCompatibleStateImageBehavior = false;
            this.lstCollectDevice.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "所属模块化设备";
            this.columnHeader3.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "传感器";
            this.columnHeader4.Width = 51;
            // 
            // 摄像机列表
            // 
            this.摄像机列表.Controls.Add(this.控制设备列表);
            this.摄像机列表.Controls.Add(this.采集设备列表);
            this.摄像机列表.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.摄像机列表.Dock = System.Windows.Forms.DockStyle.Right;
            this.摄像机列表.Location = new System.Drawing.Point(667, 0);
            this.摄像机列表.Name = "摄像机列表";
            this.摄像机列表.SelectedIndex = 0;
            this.摄像机列表.Size = new System.Drawing.Size(248, 422);
            this.摄像机列表.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 422);
            this.panel1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 274);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模块化设备列表";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.编号,
            this.名称,
            this.数据协议类型,
            this.通讯设备,
            this.设备地址,
            this.状态,
            this.异常,
            this.备注});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(661, 254);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 55;
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
            this.名称.Width = 69;
            // 
            // 数据协议类型
            // 
            this.数据协议类型.Text = "数据协议类型";
            this.数据协议类型.Width = 93;
            // 
            // 通讯设备
            // 
            this.通讯设备.Text = "通讯设备";
            this.通讯设备.Width = 87;
            // 
            // 设备地址
            // 
            this.设备地址.Text = "设备地址";
            this.设备地址.Width = 76;
            // 
            // 状态
            // 
            this.状态.Text = "状态";
            this.状态.Width = 69;
            // 
            // 异常
            // 
            this.异常.Text = "异常";
            this.异常.Width = 99;
            // 
            // 备注
            // 
            this.备注.Text = "备注";
            this.备注.Width = 103;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(300, 84);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(92, 21);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // FrmModularDeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.摄像机列表);
            this.Name = "FrmModularDeviceConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块化设备管理";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.控制设备列表.ResumeLayout(false);
            this.采集设备列表.ResumeLayout(false);
            this.摄像机列表.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbProtocalType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCommunicateDevice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.TabPage 控制设备列表;
        private System.Windows.Forms.ListView lstControlDevice;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TabPage 采集设备列表;
        private System.Windows.Forms.ListView lstCollectDevice;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabControl 摄像机列表;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 编号;
        private System.Windows.Forms.ColumnHeader 名称;
        private System.Windows.Forms.ColumnHeader 数据协议类型;
        private System.Windows.Forms.ColumnHeader 通讯设备;
        private System.Windows.Forms.ColumnHeader 设备地址;
        private System.Windows.Forms.ColumnHeader 状态;
        private System.Windows.Forms.ColumnHeader 异常;
        private System.Windows.Forms.ColumnHeader 备注;
        private System.Windows.Forms.CheckBox rbtOnlineStatus;
        private System.Windows.Forms.TextBox txtAddress;
    }
}