using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NewLife.Configuration;
using SmartIot.Tool.DefaultServiceTool.BaseConfig;
using SmartIot.Tool.DefaultServiceTool.Data;

namespace SmartIot.Tool.DefaultServiceTool.Common
{
    public partial class FrmSystemFunctionMap : Form
    {
        public FrmSystemFunctionMap()
        {
            InitializeComponent();
        }

        [DllImport("user32")]
        public static extern int SetParent(int hWndChild, int hWndNewParent); //解决主窗体覆盖问题

        private void FrmSystemFunctionMap_Load(object sender, EventArgs e)
        {
            this.Text = Config.GetConfig<String>("SystemName", "物联网监控系统设备管理工具");
        }

        /// <summary>
        /// 从键盘上输入按钮触发事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region 窗体

        private void btnFarmManage_Click(object sender, EventArgs e)
        {
            var frm = new FrmFarmEdit();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnFacilityManage_Click(object sender, EventArgs e)
        {
            var frm = new FrmFacilityConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnFacilityType_Click(object sender, EventArgs e)
        {
            var frm = new FrmFacilityTypeConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
            //FormHelper.CreateForm<BaseConfig.FrmFacilityTypeConfig>();
        }

        private void btnDeviceType_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmDeviceTypeConfig>();

            var frm = new FrmDeviceTypeConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnCommunicationDeviceType_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmCommunicateDeviceTypeConfig>();
            var frm = new FrmCommunicateDeviceTypeConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnProtocalType_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmProtocalTypeConfig>();
            var frm = new FrmProtocalTypeConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnSystemParameter_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmParmeterConfig>();
            var frm = new FrmParmeterConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        /// <summary>
        /// 调度计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 安装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstall_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmFarmEdit>();
        }

        /// <summary>
        /// 卸载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnistall_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            Process.Start("SmartIot.Tool.DefaultServiceTool");
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            var processName = "SmartIot.Tool.DefaultServiceTool".Split(',');
            foreach (var appName in processName)
            {
                var localByNameApp = Process.GetProcessesByName(appName); //获取程序名的所有进程
                if (localByNameApp.Length > 0)
                {
                    foreach (var app in localByNameApp)
                    {
                        if (!app.HasExited)
                        {
                            app.Kill(); //关闭进程
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 接口设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInterfaceSet_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 消息查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMessageSeacher_Click(object sender, EventArgs e)
        {
            var frm = new FrmSMS();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnModularDevice_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmModularDeviceConfig>();
            var frm = new FrmModularDeviceConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnCollectDevice_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmCollectDeviceConfig>();
            var frm = new FrmCollectDeviceConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnSensorDevice_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmSensorConfig>();
            var frm = new FrmSensorConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnControlDevice_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmControlDeviceConfig>();
            var frm = new FrmControlDeviceConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnCommmunicationDevice_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmCommunicateDeviceConfig>();
            var frm = new FrmCommunicateDeviceConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnShowDevice_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmShowDeviceConfig>();
            var frm = new FrmShowDeviceConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        /// <summary>
        /// LED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLED_Click(object sender, EventArgs e)
        {
            var frm = new FormShowDeviceTypeConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
            //FormHelper.CreateForm<BaseConfig.FormShowDeviceTypeConfig>();
        }

        /// <summary>
        /// TTS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTTS_Click(object sender, EventArgs e)
        {
            var frm = new FormShowDeviceTypeConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnCameraDevice_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmCameraConfig>();
            var frm = new FrmCameraConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnPresetManage_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmCameraPresetPointConfig>();
            var frm = new FrmCameraPresetPointConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnDeviceDataExceptionLog_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<Data.FrmDeviceDataExceptionLog>();
            var frm = new FrmDeviceDataExceptionLog();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnTimeSharingStatistics_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<Data.FrmTimeSharingStatistics>();
            var frm = new FrmTimeSharingStatistics();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnDeviceData_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<Data.FrmDeviceData>();
            var frm = new FrmDeviceData();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnControlCommand_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<Data.FrmDeviceControlCommand>();
            var frm = new FrmDeviceControlCommand();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnDeviceControlLog_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<Data.FrmDeviceControlLog>();
            var frm = new FrmDeviceControlLog();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        private void btnDataShowConfig_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmShowDataConfig>();
            var frm = new FrmShowDataConfig();
            frm.MdiParent = this;
            frm.Show();
            SetParent((int) frm.Handle, (int) this.Handle);
        }

        #endregion 窗体
    }
}