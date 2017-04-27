using SmartIot.Tool.DefaultService.DB;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.Data
{
    public partial class FrmDeviceControlCommand : Form
    {
        public FrmDeviceControlCommand()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化控制指令列表
        /// </summary>
        private void InitDDeviceControlCommand()
        {
            this.listView1.Items.Clear();
            List<DeviceControlCommand> list = DeviceControlCommand.FindAll();
            foreach (var command in list)
            {
                var strings = new string[]
                {
                    command.Code1, command.Code2, command.Code3, command.ControlDeviceUnitName,
                    command.CreateTime.ToString(), command.Command, command.Status.ToString()
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = command;
                this.listView1.Items.Add(listViewItem);
            }
        }
    }
}