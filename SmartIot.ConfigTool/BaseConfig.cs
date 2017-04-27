using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SmartIot.Tool.DefaultService.DB;
using DevComponents.DotNetBar.Metro;
namespace SmartIot.ConfigTool
{
    public partial class BaseConfig : MetroForm
    {
         private string ClassName= null;
        public BaseConfig(string className)
        {
            ClassName = className;
            InitializeComponent();
        }

        private void BaseConfig_Load(object sender, EventArgs e)
        {
            if (ClassName.EqualIgnoreCase("CommunicateDeviceType"))
            {
                this.Name = "CommunicateDeviceType";
                var types = CommunicateDeviceType.FindAll();
                this.dataGridViewX1.DataSource = types;
            }
            if (ClassName.EqualIgnoreCase("Sensor"))
            {
                this.Name = "Sensor";
                this.dataGridViewX1.DataSource = Sensor.FindAll();
            }
            if (ClassName.EqualIgnoreCase("RelayType"))
            {
                this.Name = "RelayType";
                this.dataGridViewX1.DataSource = RelayType.FindAll();
            }
            if (ClassName.EqualIgnoreCase("ControlJobType"))
            {
                this.Name = "ControlJobType";
                this.dataGridViewX1.DataSource = ControlJobType.FindAll();
            }
            if (ClassName.EqualIgnoreCase("DeviceType"))
            {
                this.Name = "DeviceType";
                this.dataGridViewX1.DataSource = DeviceType.FindAll();
            }
            if (ClassName.EqualIgnoreCase("FacilityType"))
            {
                this.Name = "FacilityType";
                this.dataGridViewX1.DataSource = FacilityType.FindAll();
            }
            if (ClassName.EqualIgnoreCase("ProtocalType"))
            {
                this.Name = "ProtocalType";
                this.dataGridViewX1.DataSource = ProtocalType.FindAll();
            }
            if (ClassName.EqualIgnoreCase("ShowDeviceType"))
            {
                this.Name = "ShowDeviceType";
                this.dataGridViewX1.DataSource = ShowDeviceType.FindAll();
            }
        }
        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in this.dataGridViewX1.Columns)
            {
                var type = column.Name;
                if (type.Contains("Type") || type.EqualIgnoreCase("ID") || type.EqualIgnoreCase("Serialnum"))
                {
                    column.ReadOnly = true;
                }

            }
        }


    }
}
