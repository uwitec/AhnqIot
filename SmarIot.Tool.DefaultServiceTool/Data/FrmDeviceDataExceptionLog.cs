using SmartIot.Tool.DefaultService.DB;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.Data
{
    public partial class FrmDeviceDataExceptionLog : Form
    {
        public FrmDeviceDataExceptionLog()
        {
            InitializeComponent();
            InitExceptionLog();
        }

        /// <summary>
        /// 初始化异常记录列表
        /// </summary>
        private void InitExceptionLog()
        {
            this.listView1.Items.Clear();
            List<DeviceDataExceptionLog> list = DeviceDataExceptionLog.FindAll();
            foreach (var log in list)
            {
                var strings = new string[]
                {log.Code1, log.Code2, log.Code3, log.SensorDeviceUnitName, log.CreateTime.ToString()};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = log;
                this.listView1.Items.Add(listViewItem);
            }
        }
    }
}