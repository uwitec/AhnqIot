namespace SmartIot.Tool.DefaultServiceTool.Data
{
    partial class FrmDeviceControlCommand
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.编码1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.编码2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.编码3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.控制设备 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.执行时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.指令内容 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.状态 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 383);
            this.groupBox2.TabIndex = 81;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制指令列表";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.编码1,
            this.编码2,
            this.编码3,
            this.控制设备,
            this.执行时间,
            this.指令内容,
            this.状态});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(721, 363);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // 编码1
            // 
            this.编码1.Text = "编码1";
            this.编码1.Width = 123;
            // 
            // 编码2
            // 
            this.编码2.Text = "编码2";
            this.编码2.Width = 132;
            // 
            // 编码3
            // 
            this.编码3.Text = "编码3";
            this.编码3.Width = 149;
            // 
            // 控制设备
            // 
            this.控制设备.Text = "控制设备";
            this.控制设备.Width = 75;
            // 
            // 执行时间
            // 
            this.执行时间.Text = "创建时间";
            this.执行时间.Width = 102;
            // 
            // 指令内容
            // 
            this.指令内容.Text = "指令内容";
            this.指令内容.Width = 75;
            // 
            // 状态
            // 
            this.状态.Text = "状态";
            this.状态.Width = 67;
            // 
            // FrmDeviceControlCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 383);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmDeviceControlCommand";
            this.Text = "控制指令";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 编码1;
        private System.Windows.Forms.ColumnHeader 编码2;
        private System.Windows.Forms.ColumnHeader 编码3;
        private System.Windows.Forms.ColumnHeader 控制设备;
        private System.Windows.Forms.ColumnHeader 执行时间;
        private System.Windows.Forms.ColumnHeader 指令内容;
        private System.Windows.Forms.ColumnHeader 状态;
    }
}