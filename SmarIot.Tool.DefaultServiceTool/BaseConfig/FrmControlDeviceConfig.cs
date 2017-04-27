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
    public partial class FrmControlDeviceConfig : Form
    {
        private int controlDeviceId = 0;

        public FrmControlDeviceConfig()
        {
            InitializeComponent();
            InitControlDeviceListView();
            InitModularDevice();
            InitDeviceType();
            InitRelayType();
            InitControlJobType();
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
        /// 初始化控制设备列表
        /// </summary>
        private void InitControlDeviceListView()
        {
            this.listView1.Items.Clear();
            var controlDeviceList = ControlDeviceUnit.FindAll().ToList();
            if (controlDeviceList.Count > 0 && controlDeviceList.Any())
            {
                foreach (var controlDevic in controlDeviceList)
                {
                    var strings = new string[]
                    {
                        controlDevic.Name,
                        controlDevic.ModularDeviceName,
                        controlDevic.DeviceTypeName,
                        controlDevic.RelayTypeRemark,
                        controlDevic.Function.ToString(),
                        controlDevic.RegisterAddress1.ToString(),
                        controlDevic.OriginalValue.ToString(),
                        controlDevic.ProcessedValue + "",
                        controlDevic.GroupNum.ToString(),
                        controlDevic.ControlJobTypeRemark
                    };
                    var listViewItem = new ListViewItem(strings);
                    listViewItem.Tag = controlDevic;
                    this.listView1.Items.Add(listViewItem);
                }
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
            if (modularDeviceList.Count > 0 && modularDeviceList.Any())
            {
                this.cbModularDevice.DataSource = modularDeviceList;
                this.cbModularDevice.DisplayMember = "Name";
                this.cbModularDevice.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 初始化设备类型
        /// </summary>
        private void InitDeviceType()
        {
            var deviceTypeList = DeviceType.FindAll().ToList()
                .Where(dt => dt.Serialnum.StartsWith("control"))
                .ToList();
            //foreach (var deviceType in deviceTypeList)
            //{
            //    this.cbDeviceType.Items.Add(deviceType);
            //    this.cbDeviceType.DisplayMember = deviceType.Serialnum;
            //    this.cbDeviceType.ValueMember = deviceType.Name;
            //}
            if (deviceTypeList.Any() && deviceTypeList.Count > 0)
            {
                this.cbDeviceType.DataSource = deviceTypeList;
                this.cbDeviceType.DisplayMember = "Name";
                this.cbDeviceType.ValueMember = "Serialnum";
            }
        }

        /// <summary>
        /// 初始化继电器类型
        /// </summary>
        private void InitRelayType()
        {
            var relayTypeList = RelayType.FindAll().ToList();
            if (relayTypeList.Any() && relayTypeList.Count > 0)
            {
                this.cbRelay.DataSource = relayTypeList;
                this.cbRelay.DisplayMember = "Remark";
                this.cbRelay.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 初始化控制工作类型
        /// </summary>
        private void InitControlJobType()
        {
            var controlJobTypeList = ControlJobType.FindAll().ToList();
            if (controlJobTypeList.Any() && controlJobTypeList.Count > 0)
            {
                this.cbJob.DataSource = controlJobTypeList;
                this.cbJob.DisplayMember = "Remark";
                this.cbJob.ValueMember = "ID";
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该控制设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该控制设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is Sensor)
                    {
                        var selectControlDeviceUnit = this.listView1.SelectedItems[0].Tag as ControlDeviceUnit;
                        //int id = selectControlDeviceUnit.ID;
                        //List<ShowDevice> showDeviceList = ShowDevice.FindAllByCommunicateDeviceID(id);
                        //if (showDeviceList != null)
                        //{
                        //    MessageBox.Show("该设备已经在使用，不能删除");
                        //    return;
                        //}
                        ControlDeviceUnit.Delete(selectControlDeviceUnit);
                        InitControlDeviceListView();
                        this.controlDeviceId = 0;
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

            //if (this.cbModularDevice.DisplayMember==null)
            //{
            //    MessageBox.Show("模块化设备不能为空,请输入");
            //    this.cbModularDevice.Focus();
            //    return;
            //}
            //if (this.cbDeviceType.DisplayMember == null)
            //{
            //    MessageBox.Show("设备类型不能为空,请输入");
            //    this.cbDeviceType.Focus();
            //    return;
            //}

            //if (this.txtFunction.Text == null)
            //{
            //    MessageBox.Show("功能码不能为空");
            //    this.txtFunction.Focus();
            //    return;
            //}
            if (this.controlDeviceId != 0)
            {
                try
                {
                    // 更新
                    var cntrolDevice = new ControlDeviceUnit
                    {
                        ID = this.controlDeviceId,
                        Name = this.txtName.Text.Trim(),
                        ModularDeviceID = Convert.ToInt32(this.cbModularDevice.SelectedValue),
                        DeviceTypeSerialnum = this.cbDeviceType.SelectedValue.ToString(),
                        RelayTypeId = Convert.ToInt32(this.cbRelay.SelectedValue.ToString()),
                        Function = Convert.ToInt32(this.txtFunction.Text.Trim()),
                        OriginalValue = Convert.ToInt32(this.txtOriginalValue.Text.Trim()),
                        RegisterAddress1 = Convert.ToInt32(txtAddr1.Text.Trim()),
                        ProcessedValue = this.txtProccessedValue.Text.Trim(),
                        UpdateTime = DateTime.Now,
                        GroupNum = Convert.ToInt32(this.txtGroup.Text.Trim()),
                        ControlJobTypeId = Convert.ToInt32(this.cbJob.SelectedValue.ToString())
                    };

                    //if (cntrolDevice.IsComposite)
                    //{
                    //    cntrolDevice.RegisterAddress2 = Convert.ToInt32(txtAddr2.Text.Trim());
                    //    cntrolDevice.RegisterAddress2Name = "结束地址";
                    //}
                    //else
                    //{
                    //    cntrolDevice.RegisterAddress2 = -1;
                    //    cntrolDevice.RegisterAddress2Name = "关";
                    //}

                    ControlDeviceUnit.Update(cntrolDevice);
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
                    var cntrolDevice = new ControlDeviceUnit
                    {
                        //ID = this.collectDeviceId,
                        Name = this.txtName.Text.Trim(),
                        ModularDeviceID = Convert.ToInt32(this.cbModularDevice.SelectedValue),
                        DeviceTypeSerialnum = this.cbDeviceType.SelectedValue.ToString(),
                        RelayTypeId = Convert.ToInt32(this.cbRelay.SelectedValue.ToString()),
                        Function = Convert.ToInt32(this.txtFunction.Text.Trim()),
                        OriginalValue = Convert.ToInt32(this.txtOriginalValue.Text.Trim()),
                        RegisterAddress1 = Convert.ToInt32(txtAddr1.Text.Trim()),
                        ProcessedValue = this.txtProccessedValue.Text.Trim(),
                        UpdateTime = DateTime.Now,
                        GroupNum = Convert.ToInt32(this.txtGroup.Text.Trim()),
                        ControlJobTypeId = Convert.ToInt32(this.cbJob.SelectedValue.ToString())
                    };

                    //if (cntrolDevice.IsComposite)
                    //{
                    //    cntrolDevice.RegisterAddress2 = Convert.ToInt32(txtAddr2.Text.Trim());
                    //    cntrolDevice.RegisterAddress2Name = "结束地址";
                    //}
                    //else
                    //{
                    //    cntrolDevice.RegisterAddress2 = -1;
                    //    cntrolDevice.RegisterAddress2Name = "关";
                    //}
                    ControlDeviceUnit.Save(cntrolDevice);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitControlDeviceListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this.txtId.Clear();
            this.controlDeviceId = 0;
            this.txtName.Clear();
            this.cbDeviceType.SelectedIndex = -1;
            //this.cb.SelectedIndex = -1;
            this.txtOriginalValue.Clear();
            this.txtProccessedValue.Clear();
            //this.rbtIsComposite1.Checked = true;
            this.cbModularDevice.SelectedIndex = -1;
            this.txtOriginalValue.Clear();
            this.txtProccessedValue.Clear();
            this.txtFunction.Clear();
            this.txtGroup.Clear();
            this.cbJob.SelectedIndex = -1;
            this.cbRelay.SelectedIndex = -1;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is ControlDeviceUnit)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as ControlDeviceUnit).ID.ToString();
                    this.controlDeviceId = (this.listView1.SelectedItems[0].Tag as ControlDeviceUnit).ID;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[0].Text;
                    this.cbModularDevice.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.cbDeviceType.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.cbRelay.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtFunction.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
                    this.txtAddr1.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    this.txtOriginalValue.Text = this.listView1.SelectedItems[0].SubItems[6].Text;
                    this.txtProccessedValue.Text = this.listView1.SelectedItems[0].SubItems[7].Text;
                    this.txtGroup.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
                    this.cbJob.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
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

        private void btnModular_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmModularDeviceConfig>();
        }

        private void btnSensor_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmSensorConfig>();
        }

        #region 验证

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFunction_KeyPress_1(object sender, KeyPressEventArgs e)
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