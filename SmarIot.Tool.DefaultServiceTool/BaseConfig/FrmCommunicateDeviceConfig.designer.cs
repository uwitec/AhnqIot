namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    partial class FrmCommunicateDeviceConfig
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.编码 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.通讯设备类型 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.参数1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.参数2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.参数3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.参数4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.参数5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.状态 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.异常 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.备注 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtOnlineStatus = new System.Windows.Forms.CheckBox();
            this.cbCommunicateDeviceType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtException = new System.Windows.Forms.TextBox();
            this.txtArgs5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArgs4 = new System.Windows.Forms.TextBox();
            this.txtArgs3 = new System.Windows.Forms.TextBox();
            this.txtArgs1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtArgs2 = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 286);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通讯设备列表";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.编码,
            this.名称,
            this.通讯设备类型,
            this.参数1,
            this.参数2,
            this.参数3,
            this.参数4,
            this.参数5,
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
            this.listView1.Size = new System.Drawing.Size(871, 266);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 99;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // 编码
            // 
            this.编码.Text = "编码";
            this.编码.Width = 48;
            // 
            // 名称
            // 
            this.名称.Text = "名称";
            this.名称.Width = 69;
            // 
            // 通讯设备类型
            // 
            this.通讯设备类型.Text = "通讯设备类型";
            this.通讯设备类型.Width = 86;
            // 
            // 参数1
            // 
            this.参数1.Text = "参数1";
            this.参数1.Width = 53;
            // 
            // 参数2
            // 
            this.参数2.Text = "参数2";
            this.参数2.Width = 71;
            // 
            // 参数3
            // 
            this.参数3.Text = "参数3";
            this.参数3.Width = 74;
            // 
            // 参数4
            // 
            this.参数4.Text = "参数4";
            // 
            // 参数5
            // 
            this.参数5.Text = "参数5";
            // 
            // 状态
            // 
            this.状态.Text = "状态";
            this.状态.Width = 67;
            // 
            // 异常
            // 
            this.异常.Text = "异常";
            // 
            // 备注
            // 
            this.备注.Text = "备注";
            this.备注.Width = 65;
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
            this.groupBox1.Controls.Add(this.rbtOnlineStatus);
            this.groupBox1.Controls.Add(this.cbCommunicateDeviceType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtException);
            this.groupBox1.Controls.Add(this.txtArgs5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtArgs4);
            this.groupBox1.Controls.Add(this.txtArgs3);
            this.groupBox1.Controls.Add(this.txtArgs1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtArgs2);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 172);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rbtOnlineStatus
            // 
            this.rbtOnlineStatus.AutoSize = true;
            this.rbtOnlineStatus.Location = new System.Drawing.Point(678, 61);
            this.rbtOnlineStatus.Name = "rbtOnlineStatus";
            this.rbtOnlineStatus.Size = new System.Drawing.Size(36, 16);
            this.rbtOnlineStatus.TabIndex = 8;
            this.rbtOnlineStatus.Text = "是";
            this.rbtOnlineStatus.UseVisualStyleBackColor = true;
            // 
            // cbCommunicateDeviceType
            // 
            this.cbCommunicateDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommunicateDeviceType.FormattingEnabled = true;
            this.cbCommunicateDeviceType.ItemHeight = 12;
            this.cbCommunicateDeviceType.Location = new System.Drawing.Point(122, 59);
            this.cbCommunicateDeviceType.Name = "cbCommunicateDeviceType";
            this.cbCommunicateDeviceType.Size = new System.Drawing.Size(133, 20);
            this.cbCommunicateDeviceType.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(631, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "异常：";
            // 
            // txtException
            // 
            this.txtException.Location = new System.Drawing.Point(678, 104);
            this.txtException.Name = "txtException";
            this.txtException.Size = new System.Drawing.Size(121, 21);
            this.txtException.TabIndex = 8;
            // 
            // txtArgs5
            // 
            this.txtArgs5.Location = new System.Drawing.Point(678, 20);
            this.txtArgs5.Name = "txtArgs5";
            this.txtArgs5.Size = new System.Drawing.Size(133, 21);
            this.txtArgs5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "参数5：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "参数4：";
            // 
            // txtArgs4
            // 
            this.txtArgs4.Location = new System.Drawing.Point(393, 104);
            this.txtArgs4.Name = "txtArgs4";
            this.txtArgs4.Size = new System.Drawing.Size(133, 21);
            this.txtArgs4.TabIndex = 5;
            // 
            // txtArgs3
            // 
            this.txtArgs3.Location = new System.Drawing.Point(393, 59);
            this.txtArgs3.Name = "txtArgs3";
            this.txtArgs3.Size = new System.Drawing.Size(133, 21);
            this.txtArgs3.TabIndex = 4;
            // 
            // txtArgs1
            // 
            this.txtArgs1.Location = new System.Drawing.Point(122, 104);
            this.txtArgs1.Name = "txtArgs1";
            this.txtArgs1.Size = new System.Drawing.Size(133, 21);
            this.txtArgs1.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(340, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "参数3：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(631, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "状态：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "参数2：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "通讯设备类型：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(69, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "参数1：";
            // 
            // txtArgs2
            // 
            this.txtArgs2.Location = new System.Drawing.Point(393, 20);
            this.txtArgs2.Name = "txtArgs2";
            this.txtArgs2.Size = new System.Drawing.Size(133, 21);
            this.txtArgs2.TabIndex = 3;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(451, 145);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 67;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(342, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 66;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 21);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // FrmCommunicateDeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCommunicateDeviceConfig";
            this.Text = "通讯设备管理";
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 编码;
        private System.Windows.Forms.ColumnHeader 名称;
        private System.Windows.Forms.ColumnHeader 通讯设备类型;
        private System.Windows.Forms.ColumnHeader 参数1;
        private System.Windows.Forms.ColumnHeader 参数2;
        private System.Windows.Forms.ColumnHeader 参数3;
        private System.Windows.Forms.ColumnHeader 参数4;
        private System.Windows.Forms.ColumnHeader 参数5;
        private System.Windows.Forms.ColumnHeader 状态;
        private System.Windows.Forms.ColumnHeader 备注;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtArgs3;
        private System.Windows.Forms.TextBox txtArgs1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtArgs2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.TextBox txtArgs5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArgs4;
        private System.Windows.Forms.ComboBox cbCommunicateDeviceType;
        private System.Windows.Forms.ColumnHeader 异常;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.CheckBox rbtOnlineStatus;
    }
}