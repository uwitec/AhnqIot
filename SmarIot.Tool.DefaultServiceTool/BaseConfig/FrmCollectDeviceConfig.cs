using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SmartIot.Tool.DefaultService.DB;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmCollectDeviceConfig : Form
    {
        private int collectDeviceId = 0;

        public FrmCollectDeviceConfig()
        {
            InitializeComponent();
            InitCollectDeviceListView();
            InitModularDevice();
            InitSensor();
            InitShowDataListView(); //绑定显示数据
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
        /// 初始化显示数据列表
        /// </summary>
        private void InitShowDataListView()
        {
            this.lstShowData.Items.Clear();
            List<ShowData> showDataList = ShowData.FindAll();
            foreach (var showData in showDataList)
            {
                var strings = new string[]
                {showData.SensorDeviceUnitName, showData.ShowDeviceName, showData.Position.ToString()};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = showData;
                this.lstShowData.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化采集设备列表
        /// </summary>
        private void InitCollectDeviceListView()
        {
            this.listView1.Items.Clear();
            List<SensorDeviceUnit> collectDeviceList = SensorDeviceUnit.FindAll();
            foreach (var collectDevice in collectDeviceList)
            {
                var strings = new string[]
                {
                    collectDevice.ID.ToString(), collectDevice.Name, collectDevice.ModularDeviceName.ToString(),
                    collectDevice.SensorName.ToString(), collectDevice.Function.ToString(),
                    collectDevice.OriginalValue.ToString(),
                    collectDevice.ShowValue, collectDevice.ProcessedValue.ToString(),
                    collectDevice.UpdateTime.ToString(),
                    collectDevice.RegisterSize.ToString(), collectDevice.RegisterAddress.ToString(),
                    collectDevice.Location
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = collectDevice;
                this.listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化模块化设备
        /// </summary>
        private void InitModularDevice()
        {
            List<ModularDevice> modularDeviceList = ModularDevice.FindAll();
            //foreach (var modularDevice in modularDeviceList)
            //{
            //    this.cbModularDevice.Items.Add(modularDevice);
            //    this.cbModularDevice.DisplayMember = modularDevice.ID.ToString();
            //    this.cbModularDevice.ValueMember = modularDevice.Name;
            //}
            if (modularDeviceList.Count > 0)
            {
                this.cbModularDevice.DataSource = modularDeviceList;
                this.cbModularDevice.DisplayMember = "Name";
                this.cbModularDevice.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 初始化传感器
        /// </summary>
        private void InitSensor()
        {
            List<Sensor> sensorList = Sensor.FindAll();
            //foreach (var sensor in sensorList)
            //{
            //    this.cbSensor.Items.Add(sensor);
            //    this.cbSensor.DisplayMember = sensor.ID.ToString();
            //    this.cbSensor.ValueMember = sensor.Name;
            //}
            if (sensorList.Count > 0)
            {
                this.cbSensor.DataSource = sensorList;
                this.cbSensor.DisplayMember = "Name";
                this.cbSensor.ValueMember = "ID";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is SensorDeviceUnit)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as SensorDeviceUnit).ID.ToString();

                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    collectDeviceId = (this.listView1.SelectedItems[0].Tag as SensorDeviceUnit).ID;
                    this.cbModularDevice.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.cbSensor.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtFunction.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
                    this.txtOriginalValue.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    this.txtShowValue.Text = this.listView1.SelectedItems[0].SubItems[6].Text;
                    this.txtProccessedValue.Text = this.listView1.SelectedItems[0].SubItems[7].Text;
                    //this.txtUpdateTime.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
                    this.txtRegisterSize.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
                    this.txtRegisterAddress.Text = this.listView1.SelectedItems[0].SubItems[10].Text;
                    this.txtLocation.Text = this.listView1.SelectedItems[0].SubItems[11].Text;
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[11].Text;

                    //显示数据列表的改变事件
                    List<ShowData> showDataLsit =
                        ShowData.FindAllBySensorDeviceUnitID(
                            (this.listView1.SelectedItems[0].Tag as SensorDeviceUnit).ID);

                    if (showDataLsit == null || showDataLsit.Count == 0)
                    {
                        foreach (ListViewItem item in this.lstShowData.Items)
                        {
                            item.Checked = false;
                        }

                        return;
                    }
                    else
                    {
                        foreach (ListViewItem item in this.lstShowData.Items)
                        {
                            var isExists = false;
                            foreach (var showData in showDataLsit)
                            {
                                var sD = item.Tag as ShowData;
                                if (sD != null)
                                {
                                    if (sD.ID == showData.ID)
                                    {
                                        isExists = true;
                                    }
                                }
                            }

                            item.Checked = isExists;
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim().IsNullOrWhiteSpace())
            {
                MessageBox.Show("名称不能为空,请输入");
                this.txtName.Focus();
                return;
            }

            //if (this.cbModularDeviceId.DisplayMember.Equals(""))
            //{
            //    MessageBox.Show("变送器不能为空,请输入");
            //    this.cbModularDeviceId.Focus();
            //    return;
            //}
            //if (this.cbSensorId.DisplayMember.Equals(""))
            //{
            //    MessageBox.Show("传感器不能为空,请输入");
            //    this.cbSensorId.Focus();
            //    return;
            //}

            //if (this.txtFunction.Text == null)
            //{
            //    MessageBox.Show("功能码不能为空");
            //    this.txtFunction.Focus();
            //    return;
            //}

            #region 获取所有选中的显示数据

            //List<ShowData> showDataList = (from item in this.lstShowData.Items.Cast<ListViewItem>() where item.Checked select item.Tag as ShowData).ToList();//显示数据
            var showDataList = new List<ShowData>();
            var showDataList1 = new List<ShowData>();
            foreach (ListViewItem item in this.lstShowData.Items)
            {
                if (item.Checked == false)
                {
                    var showData = item.Tag as ShowData; //未选中的显示数据
                    showDataList1.Add(showData);
                }
                else
                {
                    showDataList =
                        (from i in this.lstShowData.Items.Cast<ListViewItem>() where i.Checked select i.Tag as ShowData)
                            .ToList(); //选中的显示数据
                }
            }

            #endregion 获取所有选中的显示数据

            if (this.collectDeviceId != 0)
            {
                try
                {
                    // 更新
                    var collectDevice = new SensorDeviceUnit
                    {
                        ID = this.collectDeviceId,
                        Name = this.txtName.Text.Trim(),
                        ModularDeviceID = Convert.ToInt32(this.cbModularDevice.SelectedValue),
                        SensorId = Convert.ToInt32(this.cbSensor.SelectedValue),
                        Function = Convert.ToInt32(this.txtFunction.Text.Trim()),
                        OriginalValue = Convert.ToInt32(this.txtOriginalValue.Text.Trim()),
                        ShowValue = this.txtShowValue.Value.ToString(),
                        ProcessedValue = Convert.ToDecimal(this.txtProccessedValue.Text.Trim()),
                        //UpdateTime = DateTime.Now,
                        RegisterSize = Convert.ToInt32(this.txtRegisterSize.Text.Trim()),
                        RegisterAddress = Convert.ToInt32(this.txtRegisterAddress.Text.Trim()),
                        Location = this.txtLocation.Text.Trim()
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    SensorDeviceUnit.Update(collectDevice);

                    //更新显示数据
                    foreach (var item in showDataList)
                    {
                        item.SensorDeviceUnitID = this.collectDeviceId;
                        ShowData.Update(item);
                    }
                    //foreach (var item in showDataList1)
                    //{
                    //    item.SensorDeviceUnitID = this.collectDeviceId;
                    //    ShowData.Delete(item);
                    //}
                    this.InitShowDataListView();
                    MessageBox.Show("更新成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("更新失败");
                }
            }
            else
            {
                try
                {
                    // 保存
                    var collectDevice = new SensorDeviceUnit
                    {
                        //ID = this.collectDeviceId,
                        Name = this.txtName.Text.Trim(),
                        ModularDeviceID = Convert.ToInt32(this.cbModularDevice.SelectedValue),
                        SensorId = Convert.ToInt32(this.cbSensor.SelectedValue),
                        Function = Convert.ToInt32(this.txtFunction.Text.Trim()),
                        OriginalValue = Convert.ToInt32(this.txtOriginalValue.Text.Trim()),
                        ShowValue = this.txtShowValue.Value.ToString(),
                        ProcessedValue = Convert.ToDecimal(this.txtProccessedValue.Text.Trim()),
                        //UpdateTime = DateTime.Now,
                        RegisterSize = Convert.ToInt32(this.txtRegisterSize.Text.Trim()),
                        RegisterAddress = Convert.ToInt32(this.txtRegisterAddress.Text.Trim()),
                        Location = this.txtLocation.Text.Trim()
                        ////Remark = this.txtRemark.Text.Trim()
                    };
                    SensorDeviceUnit.Save(collectDevice);

                    ////保存显示数据
                    //foreach (var item in showDataList)
                    //{
                    //    ShowData.Save(item);
                    //}
                    this.InitShowDataListView();
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitCollectDeviceListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            collectDeviceId = 0;
            this.txtName.Clear();
            //this.txtId.Clear();
            this.cbModularDevice.SelectedIndex = -1;
            this.cbSensor.SelectedIndex = -1;
            this.txtFunction.Clear();
            this.txtShowValue.Value = 0;
            this.txtOriginalValue.Clear();
            this.txtProccessedValue.Clear();
            //this.txtUpdateTime.Clear();
            this.txtRegisterSize.Clear();
            this.txtRegisterAddress.Clear();
            this.txtLocation.Clear();
            //this.txtRemark.Clear();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该采集设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该采集设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is SensorDeviceUnit)
                    {
                        var selectSensorUnit = this.listView1.SelectedItems[0].Tag as SensorDeviceUnit;
                        //int id = selectSensorUnit.ID;
                        //List<ShowData> showDataList = ShowData.FindAllBySensorDeviceUnitID(id);
                        //if (showDataList != null)
                        //{
                        //    MessageBox.Show("该设备已经在使用，不能删除");
                        //    return;
                        //}
                        //SensorDeviceUnit.Delete(selectSensorUnit);
                        selectSensorUnit.Delete();
                        this.collectDeviceId = 0;
                        InitCollectDeviceListView();
                    }
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //鼠标右击才会触发contextMenuStrip控件，并且contextMenuStrip控件只在listview控件中有数据的时候才有效，这样就固定范围
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count == 1)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void btnSensorType_Click(object sender, EventArgs e)
        {
        }

        private void btnSensorType_Click_1(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmModularDeviceConfig>();
        }

        private void btnSensor_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmSensorConfig>();
        }

        #region 验证

        private void txtFunction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }

        private void txtRegisterSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }

        private void txtRegisterAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }

        private void txtProccessedValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }

        private void txtOriginalValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = false;
            }
        }

        #endregion 验证
    }
}