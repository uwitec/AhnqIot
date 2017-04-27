using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmDeviceTypeConfig : Form
    {
        private string deviceTypeSerialnum = null;

        public FrmDeviceTypeConfig()
        {
            InitializeComponent();
            InitDeviceTypeListView();
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
        /// 初始化设备类型列表
        /// </summary>
        private void InitDeviceTypeListView()
        {
            this.listView1.Items.Clear();
            List<DeviceType> deviceTypeList = DeviceType.FindAll();
            foreach (var deviceType in deviceTypeList)
            {
                var strings = new string[]
                {
                    deviceType.Serialnum, deviceType.Name, deviceType.ParentSerialnum, deviceType.Version.ToString(),
                    deviceType.CreateTime.ToString(), deviceType.UpdateTime.ToString(), deviceType.PhotoUrl,
                    deviceType.Introduce, deviceType.Upload.ToString(), deviceType.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = deviceType;
                this.listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 列表选中选项改变是
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is DeviceType)
                {
                    //this.txtSerialnum.Text = (this.listView1.SelectedItems[0].Tag as DeviceType).Serialnum.ToString();
                    deviceTypeSerialnum = (this.listView1.SelectedItems[0].Tag as DeviceType).Serialnum;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtParentSerialbum.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    //this.txtVersion.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    //this.dtCreateTime.Value =Convert.ToDateTime(this.listView1.SelectedItems[0].SubItems[4].Text);
                    //this.txtUpdateTime.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    //this.pbPhotoUrl.Image = this.listView1.SelectedItems[0].SubItems[6].Text;//绑定图片
                    this.txtIntroduce.Text = this.listView1.SelectedItems[0].SubItems[7].Text;
                    //this.cbUpLoad.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
                    //this.rbtUpLoad.Checked = Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[8].Text);
                    //if (this.rbtUpLoad.Checked == true)
                    //{
                    //    this.rbtUpLoad1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtUpLoad1.Checked = true;
                    //}
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
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

            //if (this.txtParentSerialbum.Text == null)
            //{
            //    MessageBox.Show("上及编码不能为空");
            //    this.txtParentSerialbum.Focus();
            //    return;
            //}

            //if (DeviceType.FindAllByName(this.txtName.Text) != null)
            //{
            //    MessageBox.Show("名称已经存在");
            //    this.txtName.Focus();
            //    return;
            //}

            if (this.deviceTypeSerialnum != null)
            {
                try
                {
                    // 更新
                    var deviceType = new DeviceType
                    {
                        Serialnum = this.deviceTypeSerialnum,
                        //Serialnum = this.txtSerialnum.Text,
                        Name = this.txtName.Text.Trim(),
                        ParentSerialnum = this.txtParentSerialbum.Text,
                        //Version = Convert.ToInt32(this.txtVersion.Text),
                        //CreateTime = this.dtCreateTime.Value,
                        UpdateTime = DateTime.Now,
                        //PhotoUrl = this.pbPhotoUrl.Image.ToString(),
                        Introduce = this.txtIntroduce.Text,
                        //Upload=Convert.ToBoolean(this.cbUpLoad.SelectedValue),
                        //Upload=this.rbtUpLoad.Checked,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    DeviceType.Update(deviceType);
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
                    var deviceType = new DeviceType
                    {
                        Name = this.txtName.Text.Trim(),
                        ParentSerialnum = this.txtParentSerialbum.Text,
                        //Version = Convert.ToInt32(this.txtVersion.Text),
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        //PhotoUrl = this.pbPhotoUrl.Image.ToString(),
                        Introduce = this.txtIntroduce.Text,
                        //Upload = Convert.ToBoolean(this.cbUpLoad.SelectedValue),
                        //Upload = this.rbtUpLoad.Checked,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    DeviceType.Save(deviceType);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitDeviceTypeListView();
        }

        private void btnReset_Click(object sender, EventArgs e)

        {
            //this.txtSerialnum.Clear();
            this.deviceTypeSerialnum = null;
            this.txtName.Clear();
            this.txtParentSerialbum.Clear();
            //this.txtVersion.Clear();
            //this.dtCreateTime.Format = DateTimePickerFormat.Custom;
            //dtCreateTime.CustomFormat = " ";//清空日期控件选中项
            //this.txtUpdateTime.Clear();
            //this.pbPhotoUrl.Image = null;//清空图片内容
            this.txtIntroduce.Clear();
            //this.cbUpLoad.SelectedIndex = -1;
            //this.rbtUpLoad.Checked = false;
            //this.rbtUpLoad1.Checked = true;
            //this.txtRemark.Clear();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该设备类型？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该设备类型吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is DeviceType)
                    {
                        var deviceType = this.listView1.SelectedItems[0].Tag as DeviceType;
                        var serialnum = deviceType.Serialnum;
                        List<ControlDeviceUnit> controlDeviceUnitList =
                            ControlDeviceUnit.FindAllByDeviceTypeSerialnum(serialnum);
                        if (controlDeviceUnitList != null)
                        {
                            MessageBox.Show("该设备类型已经在使用，不能删除");
                            return;
                        }
                        DeviceType.Delete(deviceType);
                        this.InitDeviceTypeListView();
                        this.deviceTypeSerialnum = null;
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

        private void FrmDeviceTypeConfig_Load(object sender, EventArgs e)
        {
        }
    }
}