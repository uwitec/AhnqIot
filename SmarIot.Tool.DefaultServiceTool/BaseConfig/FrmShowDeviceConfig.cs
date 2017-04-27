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
    public partial class FrmShowDeviceConfig : Form
    {
        private int showDeviceId = 0;

        public FrmShowDeviceConfig()
        {
            InitializeComponent();
            InitShowDeviceListView();
            InitShowDeviceType();
            InitCommunicateDevice();
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
        /// 初始化展示设备列表
        /// </summary>
        private void InitShowDeviceListView()
        {
            this.listView1.Items.Clear();
            List<ShowDevice> showDeviceList = ShowDevice.FindAll();
            foreach (var showDevice in showDeviceList)
            {
                var strings = new string[]
                {
                    showDevice.ID.ToString(), showDevice.Name, showDevice.ShowDeviceTypeName,
                    showDevice.CommunicateDeviceName, showDevice.Address, showDevice.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = showDevice;
                this.listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化展示设备类型
        /// </summary>
        private void InitShowDeviceType()
        {
            List<ShowDeviceType> showDeviceTypeList = ShowDeviceType.FindAll();
            //foreach (var showDeviceType in showDeviceTypeList)
            //{
            //    this.cbShowDeviceTypeID.Items.Add(showDeviceType);
            //    this.cbShowDeviceTypeID.DisplayMember = showDeviceType.ID.ToString();
            //    this.cbShowDeviceTypeID.ValueMember = showDeviceType.Name;
            //}
            if (showDeviceTypeList.Count > 0)
            {
                this.cbShowDeviceType.DataSource = showDeviceTypeList;
                this.cbShowDeviceType.DisplayMember = "Name";
                this.cbShowDeviceType.ValueMember = "ID";
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该展示设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该展示设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is ShowDevice)
                    {
                        var showDevice = this.listView1.SelectedItems[0].Tag as ShowDevice;
                        var id = showDevice.ID;
                        List<ShowData> showDataList = ShowData.FindAllByShowDeviceID(id);
                        if (showDataList != null)
                        {
                            MessageBox.Show("该展示设备已经在使用，不能删除");
                            return;
                        }
                        ShowDevice.Delete(showDevice);
                        this.InitShowDeviceListView();
                        this.showDeviceId = 0;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is ShowDevice)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as ShowDevice).ID.ToString();
                    this.showDeviceId = (this.listView1.SelectedItems[0].Tag as ShowDevice).ID;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.cbShowDeviceType.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.cbCommunicateDevice.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtAddress.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
                    this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[5].Text;

                    //显示数据列表的改变事件
                    List<ShowData> showDataLsit =
                        ShowData.FindAllByShowDeviceID((this.listView1.SelectedItems[0].Tag as ShowDevice).ID);
                    foreach (var sd in showDataLsit)
                    {
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
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //鼠标右击才会触发contextMenuStrip控件，并且contextMenuStrip控件只在listview控件中有数据的时候才有效，这样就固定范围
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count == 1)
            {
                contextMenuStrip1.Show(MousePosition);
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

            #region 获取所有选中的显示数据

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
            //List<ShowData> showDataList = (from i in this.lstShowData.Items.Cast<ListViewItem>() where i.Checked select i.Tag as ShowData).ToList();

            #endregion 获取所有选中的显示数据

            if (this.showDeviceId != 0)
            {
                try
                {
                    // 更新
                    var showDevice = new ShowDevice
                    {
                        ID = this.showDeviceId,
                        //ID =Convert.ToInt32( this.txtId.Text),
                        Name = this.txtName.Text.Trim(),
                        ShowDeviceTypeID = Convert.ToInt32(this.cbShowDeviceType.SelectedValue),
                        CommunicateDeviceID = Convert.ToInt32(this.cbCommunicateDevice.SelectedValue),
                        Address = this.txtAddress.Text.Trim(),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ShowDevice.Update(showDevice);

                    //更新显示数据
                    foreach (var item in showDataList)
                    {
                        item.ShowDeviceID = this.showDeviceId;
                        ShowData.Update(item);
                    }
                    foreach (var item in showDataList1)
                    {
                        item.ShowDeviceID = this.showDeviceId;
                        ShowData.Delete(item);
                    }
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
                    var showDevice = new ShowDevice
                    {
                        //ID = Convert.ToInt32(this.txtId.Text),
                        Name = this.txtName.Text.Trim(),
                        ShowDeviceTypeID = Convert.ToInt32(this.cbShowDeviceType.SelectedValue),
                        CommunicateDeviceID = Convert.ToInt32(this.cbCommunicateDevice.SelectedValue),
                        Address = this.txtAddress.Text.Trim(),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ShowDevice.Save(showDevice);

                    ////更新显示数据
                    //foreach (var item in showDataList)
                    //{
                    //    item.ShowDeviceID = this.showDeviceId;
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

            this.InitShowDeviceListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.showDeviceId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.txtRemark.Clear();
            this.txtAddress.Clear();
            this.cbShowDeviceType.SelectedIndex = -1;
            this.cbCommunicateDevice.SelectedIndex = -1;
        }

        private void btnShowDevice_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmShowDeviceConfig>();
        }

        private void btnCommunicationDevice_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmCommunicateDeviceConfig>();
        }
    }
}