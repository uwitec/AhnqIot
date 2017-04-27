using SmartIot.Tool.DefaultService.DB;
using SmartIot.Tool.DefaultServiceTool.Common;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmModularDeviceConfig : Form
    {
        private int modularDeviceId = 0;

        public FrmModularDeviceConfig()
        {
            InitializeComponent();
            InitCommunicateDevice();
            InitModularDeviceListView();
            InitProtocalType();
            InitCollectDeviceListView(); //绑定传感器设备列表
            InitControlDeviceListView(); //绑定控制设备列表
        }

        public FrmModularDeviceConfig(string id)
        {
            var n = id;
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
        /// 初始化传感器设备列表
        /// </summary>
        private void InitCollectDeviceListView()
        {
            this.lstCollectDevice.Items.Clear();
            List<SensorDeviceUnit> collectDeviceList = SensorDeviceUnit.FindAll();
            foreach (var collectDevice in collectDeviceList)
            {
                var strings = new string[]
                {collectDevice.Name, collectDevice.ModularDeviceName, collectDevice.SensorName};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = collectDevice;
                this.lstCollectDevice.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化控制设备列表
        /// </summary>
        private void InitControlDeviceListView()
        {
            this.lstControlDevice.Items.Clear();
            List<ControlDeviceUnit> controlDeviceList = ControlDeviceUnit.FindAll();
            foreach (var controlDevice in controlDeviceList)
            {
                var strings = new string[]
                {controlDevice.Name, controlDevice.ModularDeviceName, controlDevice.DeviceTypeName};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = controlDevice;
                this.lstControlDevice.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化通讯设备
        /// </summary>
        private void InitCommunicateDevice()
        {
            List<CommunicateDevice> communicateDeviceList = CommunicateDevice.FindAll();
            //foreach (var communicateDevice in communicateDeviceList)
            //{
            //    this.cbCommunicateDevice.Items.Add(communicateDevice);
            //    this.cbCommunicateDevice.DisplayMember = communicateDevice.ID.ToString();
            //    this.cbCommunicateDevice.ValueMember = communicateDevice.Name;
            //}
            if (communicateDeviceList.Count > 0)
            {
                this.cbCommunicateDevice.DataSource = communicateDeviceList;
                this.cbCommunicateDevice.DisplayMember = "Name";
                this.cbCommunicateDevice.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 初始化模块化设备列表
        /// </summary>
        private void InitModularDeviceListView()
        {
            this.listView1.Items.Clear();
            List<ModularDevice> modularDeviceList = ModularDevice.FindAll();
            foreach (var modularDevice in modularDeviceList)
            {
                var strings = new string[]
                {
                    modularDevice.ID.ToString(), modularDevice.Name, modularDevice.ProtocalTypeName,
                    modularDevice.CommunicateDeviceName, modularDevice.Address, modularDevice.OnlineStatus.ToString(),
                    modularDevice.Exception, modularDevice.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = modularDevice;
                this.listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化数据协议类型
        /// </summary>
        private void InitProtocalType()
        {
            List<ProtocalType> protocalTypeList = ProtocalType.FindAll();
            //foreach (var protocalType in protocalTypeList)
            //{
            //    this.cbProtocalType.Items.Add(protocalType);
            //    this.cbProtocalType.DisplayMember = protocalType.ID.ToString();
            //    this.cbProtocalType.ValueMember = protocalType.Name;
            //}
            if (protocalTypeList.Count > 0)
            {
                this.cbProtocalType.DataSource = protocalTypeList;
                this.cbProtocalType.DisplayMember = "Name";
                this.cbProtocalType.ValueMember = "ID";
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该模块化设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该模块化设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is ModularDevice)
                    {
                        var modularDevice = this.listView1.SelectedItems[0].Tag as ModularDevice;
                        //int id = mdularDevice.ID;
                        //List<SensorDeviceUnit> sensorDeviceUnitList = SensorDeviceUnit.FindAllByModularDeviceID(id);
                        //List<ControlDeviceUnit> controlDeviceUnitList = ControlDeviceUnit.FindAllByModularDeviceID(id);
                        //if (sensorDeviceUnitList != null||controlDeviceUnitList!=null)
                        //{
                        //    MessageBox.Show("该模块化设备已经在使用，不能删除");
                        //    return;
                        //}
                        //ModularDevice.Delete(mdularDevice);
                        modularDevice.Delete();
                        this.InitModularDeviceListView();
                        this.modularDeviceId = 0;
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

            //if (ModularDevice.FindAllByName(this.txtName.Text, Name, Name, 0, 0) != null)
            //{
            //    MessageBox.Show("名称已经存在");
            //    this.txtName.Focus();
            //    return;
            //}

            #region 获取所有选中的设备

            //List<SensorDeviceUnit> sensorDeviceUnitList = (from item in this.lstCollectDevice.Items.Cast<ListViewItem>() where item.Checked select item.Tag as SensorDeviceUnit).ToList();//采集设备
            var sensorDeviceUnitList = new List<SensorDeviceUnit>();
            var sensorDeviceUnitList1 = new List<SensorDeviceUnit>();
            foreach (ListViewItem item in this.lstCollectDevice.Items)
            {
                if (item.Checked == false)
                {
                    var sensorDeviceUnit = item.Tag as SensorDeviceUnit; //未选中的采集设备
                    sensorDeviceUnitList1.Add(sensorDeviceUnit);
                }
                else
                {
                    sensorDeviceUnitList =
                        (from i in this.lstCollectDevice.Items.Cast<ListViewItem>()
                            where i.Checked
                            select i.Tag as SensorDeviceUnit).ToList(); //选中的采集设备
                }
            }

            //List<ControlDeviceUnit> controlDeviceUnitList = (from item in this.lstControlDevice.Items.Cast<ListViewItem>() where item.Checked select item.Tag as ControlDeviceUnit).ToList();//控制设备

            var controlDeviceUnitList = new List<ControlDeviceUnit>();
            var controlDeviceUnitList1 = new List<ControlDeviceUnit>();
            foreach (ListViewItem item in this.lstControlDevice.Items)
            {
                if (item.Checked == false)
                {
                    var controlDeviceUnit = item.Tag as ControlDeviceUnit; //未选中的控制设备
                    controlDeviceUnitList1.Add(controlDeviceUnit);
                }
                else
                {
                    controlDeviceUnitList =
                        (from i in this.lstControlDevice.Items.Cast<ListViewItem>()
                            where i.Checked
                            select i.Tag as ControlDeviceUnit).ToList(); //选中的控制设备
                }
            }

            #endregion 获取所有选中的设备

            if (this.modularDeviceId != 0)
            {
                try
                {
                    // 更新
                    var modularDevice = new ModularDevice
                    {
                        ID = this.modularDeviceId,
                        Name = this.txtName.Text.Trim(),
                        ProtocalTypeID = Convert.ToInt32(this.cbProtocalType.SelectedValue),
                        CommunicateDeviceID = Convert.ToInt32(this.cbCommunicateDevice.SelectedValue),
                        Address = this.txtAddress.Text,
                        //OnlineStatus = Convert.ToBoolean(this.cbOnlineStatus.SelectedValue),
                        OnlineStatus = this.rbtOnlineStatus.Checked,
                        Exception = this.txtException.Text,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    ModularDevice.Update(modularDevice);

                    //更新采集设备
                    foreach (var item in sensorDeviceUnitList)
                    {
                        var sensorUnit = new SensorDeviceUnit();
                        sensorUnit.ID = item.ID;
                        sensorUnit.ModularDeviceID = this.modularDeviceId;
                        sensorUnit.Update();
                    }
                    //foreach (var item in sensorDeviceUnitList1)
                    //{
                    //    item.ModularDeviceID = this.modularDeviceId;
                    //    SensorDeviceUnit.Delete(item);
                    //}
                    this.InitCollectDeviceListView();

                    //更新控制设备
                    foreach (var item in controlDeviceUnitList)
                    {
                        var controlUnit = new ControlDeviceUnit();
                        controlUnit.ID = item.ID;
                        controlUnit.ModularDeviceID = this.modularDeviceId;
                        controlUnit.Update();
                    }
                    //foreach (var item in controlDeviceUnitList1)
                    //{
                    //    item.ModularDeviceID = this.modularDeviceId;
                    //    ControlDeviceUnit.Delete(item);
                    //}
                    this.InitControlDeviceListView();
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
                    var modularDevice = new ModularDevice
                    {
                        Name = this.txtName.Text.Trim(),
                        ProtocalTypeID = Convert.ToInt32(this.cbProtocalType.SelectedValue),
                        CommunicateDeviceID = Convert.ToInt32(this.cbCommunicateDevice.SelectedValue),
                        Address = this.txtAddress.Text,
                        //OnlineStatus = Convert.ToBoolean(this.cbOnlineStatus.SelectedValue),
                        OnlineStatus = this.rbtOnlineStatus.Checked,
                        Exception = this.txtException.Text,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    ModularDevice.Save(modularDevice);

                    ////保存采集设备
                    //foreach (var item in sensorDeviceUnitList)
                    //{
                    //    item.ModularDeviceID = this.modularDeviceId;
                    //    SensorDeviceUnit.Save(item);
                    //}
                    this.InitCollectDeviceListView();

                    ////保存控制设备
                    //foreach (var item in controlDeviceUnitList)
                    //{
                    //    item.ModularDeviceID = this.modularDeviceId;
                    //    ControlDeviceUnit.Save(item);
                    //}
                    this.InitControlDeviceListView();
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitModularDeviceListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.modularDeviceId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.cbProtocalType.SelectedIndex = -1;
            this.cbCommunicateDevice.SelectedIndex = -1;
            this.txtAddress.Clear();
            //this.cbOnlineStatus.SelectedIndex = -1;
            this.rbtOnlineStatus.Checked = false;
            //this.rbtOnlineStatus1.Checked = true;
            this.txtException.Clear();
            //this.txtRemark.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is ModularDevice)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as ModularDevice).ID.ToString();
                    modularDeviceId = (this.listView1.SelectedItems[0].Tag as ModularDevice).ID;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.cbProtocalType.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.cbCommunicateDevice.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtAddress.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
                    //this.cbOnlineStatus.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    this.rbtOnlineStatus.Checked = Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[5].Text);
                    //if (this.rbtOnlineStatus.Checked == true)
                    //{
                    //    this.rbtOnlineStatus1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtOnlineStatus1.Checked = true;
                    //}
                    this.txtException.Text = this.listView1.SelectedItems[0].SubItems[6].Text;
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[7].Text;

                    //采集设备列表的改变事件
                    List<SensorDeviceUnit> collectDeviceLsit =
                        SensorDeviceUnit.FindAllByModularDeviceID(
                            (this.listView1.SelectedItems[0].Tag as ModularDevice).ID);

                    if (collectDeviceLsit == null || collectDeviceLsit.Count == 0)
                    {
                        foreach (ListViewItem item in this.lstCollectDevice.Items)
                        {
                            item.Checked = false;
                        }

                        //return;
                    }
                    else
                    {
                        foreach (ListViewItem item in this.lstCollectDevice.Items)
                        {
                            var isExists = false;
                            foreach (var collectDevice in collectDeviceLsit)
                            {
                                var sD = item.Tag as SensorDeviceUnit;
                                if (sD != null)
                                {
                                    if (sD.ID == collectDevice.ID)
                                    {
                                        isExists = true;
                                    }
                                }
                            }

                            item.Checked = isExists;
                        }
                    }

                    //控制设备列表的改变事件
                    List<ControlDeviceUnit> controlDeviceLsit =
                        ControlDeviceUnit.FindAllByModularDeviceID(
                            (this.listView1.SelectedItems[0].Tag as ModularDevice).ID);

                    if (controlDeviceLsit == null || controlDeviceLsit.Count == 0)
                    {
                        foreach (ListViewItem item in this.lstControlDevice.Items)
                        {
                            item.Checked = false;
                        }

                        //return;
                    }
                    else
                    {
                        foreach (ListViewItem item in this.lstControlDevice.Items)
                        {
                            var isExists = false;
                            var cD = item.Tag as ControlDeviceUnit;
                            foreach (var controlDevice in controlDeviceLsit)
                            {
                                if (cD != null)
                                {
                                    if (cD.ID == controlDevice.ID)
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

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //鼠标右击才会触发contextMenuStrip控件，并且contextMenuStrip控件只在listview控件中有数据的时候才有效，这样就固定范围
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count == 1)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void btnProtocal_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmProtocalTypeConfig>();
        }

        private void btnCommunication_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmCommunicateDeviceConfig>();
        }

        #region 验证

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
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