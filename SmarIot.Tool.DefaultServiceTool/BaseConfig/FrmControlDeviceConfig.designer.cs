namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    partial class FrmControlDeviceConfig
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
            this.cbRelay = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.txtOriginalValue = new System.Windows.Forms.TextBox();
            this.txtProccessedValue = new System.Windows.Forms.TextBox();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.cbDeviceType = new System.Windows.Forms.ComboBox();
            this.cbModularDevice = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.模块化设备 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.设备类型 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.继电器类型 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.功能码 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.原始值 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.处理值 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.组号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.工作内容 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbJob = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 28);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbJob);
            this.groupBox1.Controls.Add(this.cbRelay);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtGroup);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFunction);
            this.groupBox1.Controls.Add(this.txtOriginalValue);
            this.groupBox1.Controls.Add(this.txtProccessedValue);
            this.groupBox1.Controls.Add(this.txtAddr1);
            this.groupBox1.Controls.Add(this.cbDeviceType);
            this.groupBox1.Controls.Add(this.cbModularDevice);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 131);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // cbRelay
            // 
            this.cbRelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelay.FormattingEnabled = true;
            this.cbRelay.ItemHeight = 12;
            this.cbRelay.Location = new System.Drawing.Point(700, 17);
            this.cbRelay.Name = "cbRelay";
            this.cbRelay.Size = new System.Drawing.Size(87, 20);
            this.cbRelay.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(617, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 77;
            this.label9.Text = "继电器类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 75;
            this.label6.Text = "工作：";
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(321, 91);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(85, 21);
            this.txtGroup.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 73;
            this.label3.Text = "组号：";
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(321, 17);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(86, 21);
            this.txtFunction.TabIndex = 3;
            this.txtFunction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFunction_KeyPress_1);
            // 
            // txtOriginalValue
            // 
            this.txtOriginalValue.Location = new System.Drawing.Point(499, 17);
            this.txtOriginalValue.Name = "txtOriginalValue";
            this.txtOriginalValue.Size = new System.Drawing.Size(86, 21);
            this.txtOriginalValue.TabIndex = 6;
            this.txtOriginalValue.Text = "0";
            this.txtOriginalValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtProccessedValue
            // 
            this.txtProccessedValue.Location = new System.Drawing.Point(499, 53);
            this.txtProccessedValue.Name = "txtProccessedValue";
            this.txtProccessedValue.Size = new System.Drawing.Size(86, 21);
            this.txtProccessedValue.TabIndex = 7;
            this.txtProccessedValue.Text = "0";
            this.txtProccessedValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProccessedValue_KeyPress);
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(321, 53);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(86, 21);
            this.txtAddr1.TabIndex = 4;
            // 
            // cbDeviceType
            // 
            this.cbDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceType.FormattingEnabled = true;
            this.cbDeviceType.ItemHeight = 12;
            this.cbDeviceType.Location = new System.Drawing.Point(91, 53);
            this.cbDeviceType.Name = "cbDeviceType";
            this.cbDeviceType.Size = new System.Drawing.Size(133, 20);
            this.cbDeviceType.TabIndex = 1;
            // 
            // cbModularDevice
            // 
            this.cbModularDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModularDevice.FormattingEnabled = true;
            this.cbModularDevice.ItemHeight = 12;
            this.cbModularDevice.Location = new System.Drawing.Point(91, 92);
            this.cbModularDevice.Name = "cbModularDevice";
            this.cbModularDevice.Size = new System.Drawing.Size(133, 20);
            this.cbModularDevice.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "设备类型：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "模块化设备：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "功能码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "原始值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "处理值：";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(712, 90);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 67;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(619, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 21);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(799, 322);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制设备列表";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.名称,
            this.模块化设备,
            this.设备类型,
            this.继电器类型,
            this.功能码,
            this.地址,
            this.原始值,
            this.处理值,
            this.组号,
            this.工作内容});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(793, 302);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 56;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // 名称
            // 
            this.名称.Text = "名称";
            this.名称.Width = 80;
            // 
            // 模块化设备
            // 
            this.模块化设备.Text = "模块化设备";
            this.模块化设备.Width = 83;
            // 
            // 设备类型
            // 
            this.设备类型.Text = "设备类型";
            this.设备类型.Width = 86;
            // 
            // 继电器类型
            // 
            this.继电器类型.Text = "继电器类型";
            this.继电器类型.Width = 85;
            // 
            // 功能码
            // 
            this.功能码.Text = "功能码";
            this.功能码.Width = 69;
            // 
            // 地址
            // 
            this.地址.Text = "地址";
            // 
            // 原始值
            // 
            this.原始值.Text = "原始值";
            this.原始值.Width = 70;
            // 
            // 处理值
            // 
            this.处理值.Text = "处理值";
            this.处理值.Width = 66;
            // 
            // 组号
            // 
            this.组号.Text = "组号";
            this.组号.Width = 51;
            // 
            // 工作内容
            // 
            this.工作内容.Text = "工作内容";
            this.工作内容.Width = 112;
            // 
            // cbJob
            // 
            this.cbJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJob.FormattingEnabled = true;
            this.cbJob.ItemHeight = 12;
            this.cbJob.Location = new System.Drawing.Point(499, 92);
            this.cbJob.Name = "cbJob";
            this.cbJob.Size = new System.Drawing.Size(87, 20);
            this.cbJob.TabIndex = 8;
            // 
            // FrmControlDeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 453);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmControlDeviceConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控制设备管理";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbModularDevice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 名称;
        private System.Windows.Forms.ColumnHeader 模块化设备;
        private System.Windows.Forms.ColumnHeader 设备类型;
        private System.Windows.Forms.ColumnHeader 功能码;
        private System.Windows.Forms.ColumnHeader 原始值;
        private System.Windows.Forms.ColumnHeader 处理值;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddr1;
        private System.Windows.Forms.TextBox txtOriginalValue;
        private System.Windows.Forms.TextBox txtProccessedValue;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.ColumnHeader 组号;
        private System.Windows.Forms.ColumnHeader 工作内容;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader 地址;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbRelay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbDeviceType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ColumnHeader 继电器类型;
        private System.Windows.Forms.ComboBox cbJob;
    }
}