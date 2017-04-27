using SmartIot.Tool.DefaultService.DB;
using SmartIot.Tool.DefaultServiceTool.Common;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmShowDataConfig : Form
    {
        private int showDataId = 0;

        public FrmShowDataConfig()
        {
            InitializeComponent();
            InitShowDataListView();
            InitShowDevice();
            InitSensorDeviceUnit();
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
        /// 初始化展示设备
        /// </summary>
        private void InitShowDevice()
        {
            List<ShowDevice> showDeviceList = ShowDevice.FindAll();
            //foreach (var showDevice in showDeviceList)
            //{
            //    this.cbShowDevice.Items.Add(showDevice);
            //    this.cbShowDevice.DisplayMember = showDevice.ID.ToString();
            //    this.cbShowDevice.ValueMember = showDevice.Name;
            //}
            if (showDeviceList.Count > 0)
            {
                this.cbShowDevice.DataSource = showDeviceList;
                this.cbShowDevice.DisplayMember = "Name";
                this.cbShowDevice.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 初始化传感器设备(采集设备)
        /// </summary>
        private void InitSensorDeviceUnit()
        {
            List<SensorDeviceUnit> sensorDeviceUnitList = SensorDeviceUnit.FindAll();
            //foreach (var sensorDeviceUnit in sensorDeviceUnitList)
            //{
            //    this.cbSensorDeviceUnit.Items.Add(sensorDeviceUnit);
            //    this.cbSensorDeviceUnit.DisplayMember = sensorDeviceUnit.ID.ToString();
            //    this.cbSensorDeviceUnit.ValueMember = sensorDeviceUnit.Name;
            //}
            if (sensorDeviceUnitList.Count > 0)
            {
                this.cbSensorDeviceUnit.DataSource = sensorDeviceUnitList;
                this.cbSensorDeviceUnit.DisplayMember = "Name";
                this.cbSensorDeviceUnit.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 初始化数据显示列表
        /// </summary>
        private void InitShowDataListView()
        {
            this.listView1.Items.Clear();
            List<ShowData> showDataList = ShowData.FindAll();
            foreach (var showData in showDataList)
            {
                var strings = new string[]
                {
                    showData.ID.ToString(), showData.Position.ToString(), showData.ShowDeviceName,
                    showData.SensorDeviceUnitName, showData.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = showData;
                this.listView1.Items.Add(listViewItem);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该数据显示？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该数据显示吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is ShowData)
                    {
                        var showData = this.listView1.SelectedItems[0].Tag as ShowData;
                        //int id = showData.ID;
                        //List<ShowDevice> modularDeviceList = ShowDevice.fin(id);
                        //if (modularDeviceList != null)
                        //{
                        //    MessageBox.Show("该协议类型已经在使用，不能删除");
                        //    return;
                        //}
                        ShowData.Delete(showData);
                        this.InitShowDataListView();
                        this.showDataId = 0;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is ShowData)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as ShowData).ID.ToString();
                    this.showDataId = (this.listView1.SelectedItems[0].Tag as ShowData).ID;
                    this.txtPosition.Value = Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[1].Text);
                    this.cbShowDevice.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.cbSensorDeviceUnit.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
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
            //if (this.txtPosition.Text.Trim().IsNullOrWhiteSpace())
            //{
            //    MessageBox.Show("位置不能为空,请输入");
            //    this.txtPosition.Focus();
            //    return;
            //}

            if (this.showDataId != 0)
            {
                try
                {
                    // 更新
                    var ShowData = new ShowData
                    {
                        ID = this.showDataId,
                        //ID =Convert.ToInt32( this.txtId.Text),
                        Position = Convert.ToInt32(this.txtPosition.Text.Trim()),
                        ShowDeviceID = Convert.ToInt32(this.cbShowDevice.SelectedValue),
                        SensorDeviceUnitID = Convert.ToInt32(this.cbSensorDeviceUnit.SelectedValue),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ShowData.Update(ShowData);
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
                    var ShowData = new ShowData
                    {
                        //ID = Convert.ToInt32(this.txtId.Text),
                        Position = Convert.ToInt32(this.txtPosition.Text.Trim()),
                        ShowDeviceID = Convert.ToInt32(this.cbShowDevice.SelectedValue),
                        SensorDeviceUnitID = Convert.ToInt32(this.cbSensorDeviceUnit.SelectedValue),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ShowData.Save(ShowData);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitShowDataListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.showDataId = 0;
            this.txtPosition.Value = 0;
            //this.txtId.Clear();
            this.txtRemark.Clear();
            this.cbSensorDeviceUnit.SelectedIndex = -1;
            this.cbShowDevice.SelectedIndex = -1;
        }

        private void btnShowDevice_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmShowDeviceConfig>();
        }

        private void btnSensorDevice_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmCollectDeviceConfig>();
        }
    }
}