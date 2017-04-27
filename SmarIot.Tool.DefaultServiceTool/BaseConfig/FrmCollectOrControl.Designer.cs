namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    partial class FrmCollectOrControl
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
            this.btnCollectOption = new System.Windows.Forms.Button();
            this.btnControlOption = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCollectOption
            // 
            this.btnCollectOption.Location = new System.Drawing.Point(39, 101);
            this.btnCollectOption.Name = "btnCollectOption";
            this.btnCollectOption.Size = new System.Drawing.Size(75, 23);
            this.btnCollectOption.TabIndex = 0;
            this.btnCollectOption.Text = "采集设备";
            this.btnCollectOption.UseVisualStyleBackColor = true;
            // 
            // btnControlOption
            // 
            this.btnControlOption.Location = new System.Drawing.Point(147, 101);
            this.btnControlOption.Name = "btnControlOption";
            this.btnControlOption.Size = new System.Drawing.Size(75, 23);
            this.btnControlOption.TabIndex = 1;
            this.btnControlOption.Text = "控制设备";
            this.btnControlOption.UseVisualStyleBackColor = true;
            // 
            // FrmCollectOrControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 221);
            this.ControlBox = false;
            this.Controls.Add(this.btnControlOption);
            this.Controls.Add(this.btnCollectOption);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCollectOrControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择下一步";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCollectOption;
        private System.Windows.Forms.Button btnControlOption;
    }
}