using SmartIot.Tool.DefaultService.DB;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.Data
{
    public partial class FrmDeviceControlLog : Form
    {
        public FrmDeviceControlLog()
        {
            InitializeComponent();
            InitDeviceControlLog();
        }

        /// <summary>
        /// 初始化控制记录列表
        /// </summary>
        private void InitDeviceControlLog()
        {
            this.listView1.Items.Clear();
            List<DeviceControlLog> list = DeviceControlLog.FindAll();
            foreach (var log in list)
            {
                var strings = new string[]
                {log.Code1, log.Code2, log.Code3, log.ControlDeviceUnitName, log.ControlResult.ToString()};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = log;
                this.listView1.Items.Add(listViewItem);
            }
        }
    }
}