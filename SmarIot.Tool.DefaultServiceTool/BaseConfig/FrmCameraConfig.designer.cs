namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    partial class FrmCameraConfig
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
            this.编号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.登录用户名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.登录密码 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.web端口号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.数据端口号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RTS端口号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.状态 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.异常 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.通道 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.流媒体地址 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.厂家 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.备注 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtChanel = new System.Windows.Forms.NumericUpDown();
            this.txtWebPort = new System.Windows.Forms.NumericUpDown();
            this.txtRTSPort = new System.Windows.Forms.NumericUpDown();
            this.txtDataPort = new System.Windows.Forms.NumericUpDown();
            this.rbtOnlineStatus = new System.Windows.Forms.CheckBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtException = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRTSPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 284);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制设备列表";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.编号,
            this.名称,
            this.登录用户名,
            this.登录密码,
            this.地址,
            this.web端口号,
            this.数据端口号,
            this.RTS端口号,
            this.状态,
            this.异常,
            this.通道,
            this.流媒体地址,
            this.厂家,
            this.备注});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(985, 264);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 77;
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
            this.名称.Width = 80;
            // 
            // 登录用户名
            // 
            this.登录用户名.Text = "登录用户名";
            this.登录用户名.Width = 83;
            // 
            // 登录密码
            // 
            this.登录密码.Text = "登录密码";
            this.登录密码.Width = 86;
            // 
            // 地址
            // 
            this.地址.Text = "地址";
            this.地址.Width = 71;
            // 
            // web端口号
            // 
            this.web端口号.Text = "web端口号";
            this.web端口号.Width = 77;
            // 
            // 数据端口号
            // 
            this.数据端口号.Text = "数据端口号";
            this.数据端口号.Width = 82;
            // 
            // RTS端口号
            // 
            this.RTS端口号.Text = "RTS端口号";
            this.RTS端口号.Width = 86;
            // 
            // 状态
            // 
            this.状态.Text = "状态";
            this.状态.Width = 78;
            // 
            // 异常
            // 
            this.异常.Text = "异常";
            // 
            // 通道
            // 
            this.通道.Text = "通道";
            // 
            // 流媒体地址
            // 
            this.流媒体地址.Text = "流媒体地址";
            // 
            // 厂家
            // 
            this.厂家.Text = "厂家";
            // 
            // 备注
            // 
            this.备注.Text = "备注";
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
            this.groupBox1.Controls.Add(this.txtChanel);
            this.groupBox1.Controls.Add(this.txtWebPort);
            this.groupBox1.Controls.Add(this.txtRTSPort);
            this.groupBox1.Controls.Add(this.txtDataPort);
            this.groupBox1.Controls.Add(this.rbtOnlineStatus);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtException);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(991, 193);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // txtChanel
            // 
            this.txtChanel.Location = new System.Drawing.Point(541, 68);
            this.txtChanel.Maximum = new decimal(new int[] {
            65566,
            0,
            0,
            0});
            this.txtChanel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtChanel.Name = "txtChanel";
            this.txtChanel.Size = new System.Drawing.Size(131, 21);
            this.txtChanel.TabIndex = 6;
            this.txtChanel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChanel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtWebPort
            // 
            this.txtWebPort.Location = new System.Drawing.Point(302, 68);
            this.txtWebPort.Maximum = new decimal(new int[] {
            63366,
            0,
            0,
            0});
            this.txtWebPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtWebPort.Name = "txtWebPort";
            this.txtWebPort.Size = new System.Drawing.Size(133, 21);
            this.txtWebPort.TabIndex = 4;
            this.txtWebPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWebPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // txtRTSPort
            // 
            this.txtRTSPort.Location = new System.Drawing.Point(541, 26);
            this.txtRTSPort.Maximum = new decimal(new int[] {
            63365,
            0,
            0,
            0});
            this.txtRTSPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtRTSPort.Name = "txtRTSPort";
            this.txtRTSPort.Size = new System.Drawing.Size(131, 21);
            this.txtRTSPort.TabIndex = 5;
            this.txtRTSPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRTSPort.Value = new decimal(new int[] {
            554,
            0,
            0,
            0});
            // 
            // txtDataPort
            // 
            this.txtDataPort.Location = new System.Drawing.Point(302, 106);
            this.txtDataPort.Maximum = new decimal(new int[] {
            63366,
            0,
            0,
            0});
            this.txtDataPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDataPort.Name = "txtDataPort";
            this.txtDataPort.Size = new System.Drawing.Size(133, 21);
            this.txtDataPort.TabIndex = 3;
            this.txtDataPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataPort.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // rbtOnlineStatus
            // 
            this.rbtOnlineStatus.AutoSize = true;
            this.rbtOnlineStatus.Checked = true;
            this.rbtOnlineStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rbtOnlineStatus.Location = new System.Drawing.Point(541, 110);
            this.rbtOnlineStatus.Name = "rbtOnlineStatus";
            this.rbtOnlineStatus.Size = new System.Drawing.Size(36, 16);
            this.rbtOnlineStatus.TabIndex = 7;
            this.rbtOnlineStatus.Text = "是";
            this.rbtOnlineStatus.UseVisualStyleBackColor = true;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(80, 106);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(133, 21);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.Text = "smt12345";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(80, 66);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(133, 21);
            this.txtUser.TabIndex = 1;
            this.txtUser.Text = "admin";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(33, 152);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 47;
            this.label13.Text = "异常：";
            // 
            // txtException
            // 
            this.txtException.Location = new System.Drawing.Point(80, 149);
            this.txtException.Name = "txtException";
            this.txtException.Size = new System.Drawing.Size(409, 21);
            this.txtException.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(483, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "通道：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "密码：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "用户名：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "数据端口：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "web端口：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(459, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "RTSP端口：";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(597, 149);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 21);
            this.btnReset.TabIndex = 35;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(502, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 21);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "IP：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(302, 25);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(133, 21);
            this.txtAddress.TabIndex = 0;
            // 
            // FrmCameraConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 477);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCameraConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "摄像机管理";
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRTSPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 编号;
        private System.Windows.Forms.ColumnHeader 名称;
        private System.Windows.Forms.ColumnHeader 登录用户名;
        private System.Windows.Forms.ColumnHeader 登录密码;
        private System.Windows.Forms.ColumnHeader 地址;
        private System.Windows.Forms.ColumnHeader web端口号;
        private System.Windows.Forms.ColumnHeader 数据端口号;
        private System.Windows.Forms.ColumnHeader RTS端口号;
        private System.Windows.Forms.ColumnHeader 状态;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.ColumnHeader 异常;
        private System.Windows.Forms.ColumnHeader 通道;
        private System.Windows.Forms.ColumnHeader 流媒体地址;
        private System.Windows.Forms.ColumnHeader 厂家;
        private System.Windows.Forms.ColumnHeader 备注;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.CheckBox rbtOnlineStatus;
        private System.Windows.Forms.NumericUpDown txtWebPort;
        private System.Windows.Forms.NumericUpDown txtRTSPort;
        private System.Windows.Forms.NumericUpDown txtDataPort;
        private System.Windows.Forms.NumericUpDown txtChanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
    }
}