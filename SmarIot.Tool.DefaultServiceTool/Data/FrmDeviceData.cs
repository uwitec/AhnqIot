using SmartIot.Tool.DefaultService.DB;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.Data
{
    public partial class FrmDeviceData : Form
    {
        public FrmDeviceData()
        {
            InitializeComponent();
            InitDeviceData();
        }

        /// <summary>
        /// 初始化历史记录列表
        /// </summary>
        private void InitDeviceData()
        {
            this.listView1.Items.Clear();
            List<DeviceData> list = DeviceData.FindAll();
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