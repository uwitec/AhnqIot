using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmartIot.Tool.DefaultService.DB;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmSensorConfig : Form
    {
        private int sensorId = 0;

        public FrmSensorConfig()
        {
            InitializeComponent();
            InitListView();
            this.txtValueComputeString.Text = "x*1";
            InitDeviceType();
        }

        /// <summary>
        /// 从键盘上输入按钮触发事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (btnSave.Enabled)
                {
                    btnSave_Click(btnSave, new EventArgs());
                }
                return true;
            }

            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 初始化ListView
        /// </summary>
        private void InitListView()
        {
            this.listView1.Items.Clear();
            List<Sensor> sensorsList = Sensor.FindAll();
            foreach (var sensor in sensorsList)
            {
                var strings = new[]
                {
                    sensor.ID.ToString(), sensor.Code, sensor.Name, sensor.DeviceTypeName, sensor.MaxValue.ToString(),
                    sensor.MinValue.ToString(), sensor.ExperienceMax.ToString(), sensor.ExperienceMin.ToString(),
                    sensor.Accuracy.ToString(),
                    sensor.Company, sensor.Unit, sensor.ValueComputeString, sensor.ShowComputeString, sensor.Memo
                };

                var listView = new ListViewItem(strings);
                listView.Tag = sensor;
                this.listView1.Items.Add(listView);
            }
        }

        /// <summary>
        /// 初始化设备类型
        /// </summary>
        private void InitDeviceType()
        {
            List<DeviceType> deviceTypeList = DeviceType.FindAll();
            //foreach (var deviceType in deviceTypeList)
            //{
            //    this.cbDeviceType.Items.Add(deviceType);
            //    this.cbDeviceType.DisplayMember = deviceType.Serialnum;
            //    this.cbDeviceType.ValueMember = deviceType.Name;
            //}
            if (deviceTypeList.Count > 0)
            {
                this.cbDeviceType.DataSource = deviceTypeList;
                this.cbDeviceType.DisplayMember = "Name";
                this.cbDeviceType.ValueMember = "Serialnum";
            }
        }

        /// <summary>
        /// 重置所有控件内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.sensorId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.txtCode.Clear();
            //this.txtUnit.Clear();
            //this.txtProductCompany.Clear();
            this.txtMaxValue.Value = 0;
            this.txtMinValue.Value = 0;
            this.txtExperienceMax.Value = 0;
            this.txtExperienceMin.Value = 0;
            this.txtShowComputeString.Clear();
            this.txtValueComputeString.Clear();
            this.txtMemo.Clear();
            this.txtAccuracy.Clear();
            this.cbDeviceType.SelectedIndex = -1;
            this.sensorId = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim().IsNullOrWhiteSpace())
            {
                MessageBox.Show("名称不能为空,请输入");
                this.txtName.Focus();
                return;
            }

            //if (this.txtShowComputeString.Text.Trim().IsNullOrWhiteSpace())
            //{
            //   MessageBox.Show("显示计算公式不能为空,请输入");
            //   this.txtShowComputeString.Focus();
            //    return;
            //}
            //if (this.txtValueComputeString.Text.Trim().IsNullOrWhiteSpace())
            //{
            //    MessageBox.Show("数值计算公式不能为空,请输入");
            //    this.txtValueComputeString.Focus();
            //    return;
            //}

            //if (this.cbDeviceType.Text.Trim().IsNullOrWhiteSpace())
            //{
            //   MessageBox.Show("请选择设备类型");
            //   this.cbDeviceType.Focus();
            //    return;
            //}

            //if (Sensor.FindByID(Convert.ToInt32(this.txtId.Text))!=null)
            //{
            //    MessageBox.Show("属性已经存在");
            //    this.txtCode.Focus();
            //    return;
            //}

            if (this.sensorId != 0)
            {
                try
                {
                    // 更新
                    var sensor = new Sensor
                    {
                        ID = this.sensorId,
                        //Code =this.txtCode.Text,
                        Name = this.txtName.Text.Trim(),
                        Unit = this.txtUnit.Text.Trim(),
                        Company = this.txtProductCompany.Text.Trim(),
                        ShowComputeString = this.txtShowComputeString.Text.Trim(),
                        ValueComputeString = this.txtValueComputeString.Text.Trim(),
                        MaxValue = Convert.ToInt32(this.txtMaxValue.Value),
                        MinValue = Convert.ToInt32(this.txtMinValue.Value),
                        ExperienceMax = Convert.ToInt32(this.txtExperienceMax.Value),
                        ExperienceMin = Convert.ToInt32(this.txtExperienceMin.Value),
                        DeviceTypeSerialnum = this.cbDeviceType.SelectedValue.ToString(),
                        Accuracy = Convert.ToInt32(this.txtAccuracy.Text),
                        Memo = this.txtMemo.Text.Trim()
                    };
                    Sensor.Update(sensor);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }
            else
            {
                try
                {
                    // 保存
                    var sensor = new Sensor
                    {
                        //ID = this.sensorId,
                        //Code = this.txtCode.Text,
                        Name = this.txtName.Text.Trim(),
                        Unit = this.txtUnit.Text.Trim(),
                        Company = this.txtProductCompany.Text.Trim(),
                        ShowComputeString = this.txtShowComputeString.Text.Trim(),
                        ValueComputeString = this.txtValueComputeString.Text.Trim(),
                        MaxValue = Convert.ToInt32(this.txtMaxValue.Value),
                        MinValue = Convert.ToInt32(this.txtMinValue.Value),
                        ExperienceMax = Convert.ToInt32(this.txtExperienceMax.Value),
                        ExperienceMin = Convert.ToInt32(this.txtExperienceMin.Value),
                        DeviceTypeSerialnum = this.cbDeviceType.SelectedValue.ToString(),
                        Accuracy = Convert.ToInt32(this.txtAccuracy.Text),
                        Memo = this.txtMemo.Text.Trim()
                    };
                    Sensor.Save(sensor);
                    MessageBox.Show("保存失败");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is Sensor)
                {
                    var sensor = this.listView1.SelectedItems[0].Tag as Sensor;
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as Sensor).ID.ToString();
                    sensorId = (this.listView1.SelectedItems[0].Tag as Sensor).ID;
                    this.txtCode.Text = sensor.Code; // this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtName.Text = sensor.Name; //this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.cbDeviceType.Text = sensor.DeviceTypeName; //this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtMaxValue.Value = sensor.MaxValue;
                    //Convert.ToDecimal(this.listView1.SelectedItems[0].SubItems[4].Text);
                    this.txtMinValue.Value = sensor.MinValue;
                    //Convert.ToDecimal(this.listView1.SelectedItems[0].SubItems[5].Text);
                    this.txtExperienceMax.Value = sensor.ExperienceMax;
                    //Convert.ToDecimal(this.listView1.SelectedItems[0].SubItems[6].Text);
                    this.txtExperienceMin.Value = sensor.ExperienceMin;
                    // Convert.ToDecimal(this.listView1.SelectedItems[0].SubItems[7].Text);
                    this.txtAccuracy.Text = sensor.Accuracy.ToString();
                    //this.listView1.SelectedItems[0].SubItems[8].Text;
                    this.txtProductCompany.Text = sensor.Company; // this.listView1.SelectedItems[0].SubItems[9].Text;
                    this.txtUnit.Text = sensor.Unit; //this.listView1.SelectedItems[0].SubItems[10].Text;
                    //this.txtValueComputeString.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
                    //this.txtShowComputeString.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.txtValueComputeString.Text = sensor.ValueComputeString; //;
                    this.txtShowComputeString.Text = sensor.ShowComputeString; //;

                    this.txtMemo.Text = sensor.Code; //this.listView1.SelectedItems[0].SubItems[10].Text;
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //鼠标右击才会触发contextMenuStrip控件，并且contextMenuStrip控件只在listview控件中有数据的时候才有效，这样就固定范围
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count == 1)
            {
                context1.Show(MousePosition);
            }
        }

        /// <summary>
        /// 删除选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该传感器？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该传感器吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is Sensor)
                    {
                        var selectSensor = this.listView1.SelectedItems[0].Tag as Sensor;
                        if (selectSensor.Code == "collect-facility-WenDu" ||
                            selectSensor.Code == "collect-facility-ShiDu" ||
                            selectSensor.Code == "collect-facility-GuangZhao")
                        {
                            MessageBox.Show("温湿光设备的传感器不能删除");
                            return;
                        }
                        var id = selectSensor.ID;
                        List<SensorDeviceUnit> sensorDeviceUnitList = SensorDeviceUnit.FindAllBySensorId(id);
                        if (sensorDeviceUnitList != null)
                        {
                            MessageBox.Show("该传感器已经被使用,不能删除");
                            return;
                        }
                        Sensor.Delete(selectSensor);
                        this.InitListView();
                        this.sensorId = 0;
                    }
                }
            }
        }

        private void btnSensorType_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmDeviceTypeConfig>();
            var de = new FrmDeviceTypeConfig();
            //de.MdiParent = false;
            de.Show();
        }

        # region 验证

        private void txtAccuracy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }

        #endregion
    }
}