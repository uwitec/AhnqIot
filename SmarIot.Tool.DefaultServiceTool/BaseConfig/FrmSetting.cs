using System;
using System.Diagnostics;
using System.Windows.Forms;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Tool.Core.Common;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmSetting : Form
    {
        //private XAgentSetting xAgentSetting = XAgentSetting.Current;
        /// <summary>
        /// 服务文件名称
        /// </summary>
        private readonly string ServiceFileName = "SmartIot.Tool.Container.exe";

        private readonly Setting setting = Setting.Current;

        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            LoadSystemParams();
            LoadWindowsServiceInfo();
            LoadRunParams();
        }

        private void btnRunParamsReset_Click(object sender, EventArgs e)
        {
            setting.CollectEnable = true;
            setting.CollectInterval = 300;

            setting.ControlEnable = false;
            setting.ControlCollectInterval = 60;
            setting.ControlCommandInterval = 5;

            setting.FarmStatusUploadEnable = true;
            setting.FarmStatusUploadInterval = 15;

            setting.SyncEnable = true;
            setting.SyncInterval = 5;

            setting.UploadDeviceDataEnable = true;
            setting.DeleteDeviceDataEnable = true;
            setting.UploadDeviceDataInterval = 5;

            setting.LedEnable = false;
            setting.LedShowInterval = 10;

            setting.TtsEnable = false;
            setting.TtsShowInterval = 10;

            setting.ExceptionNotifyEnable = false;

            setting.Save();

            LoadRunParams();
        }

        #region 系统参数

        private void LoadSystemParams()
        {
            txtSystemName.Text = setting.SystemName;
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
        }

        private void btnSystemSave_Click(object sender, EventArgs e)
        {
            setting.SystemName = txtSystemName.Text.Trim();
            setting.Save();
        }

        #endregion 系统参数

        #region Windows Service

        private void LoadWindowsServiceInfo()
        {
            var serviceName = setting.ServiceName;
            if (serviceName.IsNullOrWhiteSpace())
                serviceName = "SmartIot.Tool.Service";
            txtServiceName.Text = serviceName;
            txtServiceDescription.Text = setting.DisplayName;
            if (txtServiceDescription.Text.IsNullOrWhiteSpace())
                txtServiceDescription.Text = setting.SystemName + "系统服务";
            //ckbEnableServiceDebug.Checked = xAgentSetting.Debug;
            //nuServiceAutoRestart.Value = xAgentSetting.AutoRestart;
            ckbEnableServiceLog.Checked = setting.EnableViewServiceLog;
        }

        private void btnServiceSave_Click(object sender, EventArgs e)
        {
            setting.ServiceName = txtServiceName.Text;
            setting.DisplayName = txtServiceDescription.Text;
            //setting.Debug = ckbEnableServiceDebug.Checked;
            //setting.AutoRestart = Convert.ToInt32(nuServiceAutoRestart.Value);
            setting.EnableViewServiceLog = ckbEnableServiceLog.Checked;

            setting.Save();
            setting.Save();
        }

        private void ckbEnableServiceLog_CheckedChanged(object sender, EventArgs e)
        {
            txtServiceLog.Enabled = ckbEnableServiceLog.Checked;

            if (ckbEnableServiceLog.Checked)
            {
                //todo 启动udp服务，接收日志
            }
        }

        private void btnServiceInstall_Click(object sender, EventArgs e)
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = ServiceFileName;
            processStartInfo.Arguments = @"-i";

            Process.Start(processStartInfo);
        }

        private void btnServiceUninstall_Click(object sender, EventArgs e)
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = ServiceFileName;
            processStartInfo.Arguments = @"-u";

            Process.Start(processStartInfo);
        }

        private void btnServiceStart_Click(object sender, EventArgs e)
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = ServiceFileName;
            processStartInfo.Arguments = @"-start";

            Process.Start(processStartInfo);
        }

        private void btnServiceStop_Click(object sender, EventArgs e)
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = ServiceFileName;
            processStartInfo.Arguments = @"-stop";

            Process.Start(processStartInfo);
        }

        private void btnServiceRestart_Click(object sender, EventArgs e)
        {
            btnServiceStop_Click(null, null);
            btnServiceStart_Click(null, null);
        }

        private void btnStartByConsole_Click(object sender, EventArgs e)
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = ServiceFileName;
            processStartInfo.Arguments = @"-run";

            Process.Start(processStartInfo);
        }

        #endregion Windows Service

        #region 运行参数

        private void LoadRunParams()
        {
            ckbRunParamEnableCollect.Checked = setting.CollectEnable;
            trackBarRunParamCollectInterval.Value = setting.CollectInterval;

            ckbRunParamEnableControl.Checked = setting.ControlEnable;
            trackBarRunParamControlInterval.Value = setting.ControlCollectInterval;
            trackBarRunParamControlCommandInterval.Value = setting.ControlCommandInterval;

            ckbRunParamEnableUploadFarmStatus.Checked = setting.FarmStatusUploadEnable;
            trackBarRunParamUploadFarmStatusInterval.Value = setting.FarmStatusUploadInterval;

            ckbRunParamEnableUploadData.Checked = setting.SyncEnable;
            trackBarRunParamUploadDataInterval.Value = setting.SyncInterval;

            //ckbRunParamEnableUploadData.Checked = setting.UploadDeviceDataEnable;
            //trackBarRunParamUploadDataInterval.Value = setting.UploadDeviceDataInterval;


            ckbRunParamEnableLed.Checked = setting.LedEnable;
            trackBarRunParamLedUpdateInterval.Value = setting.LedShowInterval;

            ckbRunParamEnableTts.Checked = setting.TtsEnable;
            trackBarRunParamTtsUpdateInterval.Value = setting.TtsShowInterval;

            ckbRunParamEnableNotify.Checked = setting.ExceptionNotifyEnable;
        }

        private void btnRunParamsSave_Click(object sender, EventArgs e)
        {
            setting.CollectEnable = ckbRunParamEnableCollect.Checked;
            setting.CollectInterval = trackBarRunParamCollectInterval.Value;

            setting.ControlEnable = ckbRunParamEnableControl.Checked;
            setting.ControlCollectInterval = trackBarRunParamControlInterval.Value;
            setting.ControlCommandInterval = trackBarRunParamControlCommandInterval.Value;

            setting.FarmStatusUploadEnable = ckbRunParamEnableUploadFarmStatus.Checked;
            setting.FarmStatusUploadInterval = trackBarRunParamUploadFarmStatusInterval.Value;

            setting.SyncEnable = ckbRunParamEnableUploadData.Checked;
            setting.SyncInterval = trackBarRunParamUploadDataInterval.Value;

            setting.LedEnable = ckbRunParamEnableLed.Checked;
            setting.LedShowInterval = trackBarRunParamLedUpdateInterval.Value;

            setting.TtsEnable = ckbRunParamEnableTts.Checked;
            setting.TtsShowInterval = trackBarRunParamTtsUpdateInterval.Value;

            setting.ExceptionNotifyEnable = ckbRunParamEnableNotify.Checked;

            setting.Save();
        }

        #endregion 运行参数
    }
}