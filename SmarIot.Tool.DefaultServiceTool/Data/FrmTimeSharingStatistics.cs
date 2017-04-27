using SmartIot.Tool.DefaultService.DB;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.Data
{
    public partial class FrmTimeSharingStatistics : Form
    {
        public FrmTimeSharingStatistics()
        {
            InitializeComponent();
            InitExceptionLog();
        }

        /// <summary>
        /// 初始化分时统计列表
        /// </summary>
        private void InitExceptionLog()
        {
            this.listView1.Items.Clear();
            List<TimeSharingStatistics> list = TimeSharingStatistics.FindAll();
            foreach (var log in list)
            {
                var strings = new string[]
                {
                    log.Code1, log.Code2, log.Code3, log.TimeSharing.ToString(), log.SensorDeviceUnitName,
                    log.CreateTime.ToString()
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = log;
                this.listView1.Items.Add(listViewItem);
            }
        }
    }
}