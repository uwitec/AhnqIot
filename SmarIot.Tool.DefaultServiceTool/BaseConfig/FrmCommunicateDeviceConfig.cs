using SmartIot.Tool.DefaultService.DB;
using SmartIot.Tool.DefaultServiceTool.Common;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmCommunicateDeviceConfig : Form
    {
        private int communicateDeviceId = 0;

        public FrmCommunicateDeviceConfig()
        {
            InitializeComponent();
            InitCommunicateDeviceListView();
            InitCommunicateDeviceType();
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
        /// 初始化通讯设备类型
        /// </summary>
        private void InitCommunicateDeviceType()
        {
            List<CommunicateDeviceType> communicateDeviceTypeList = CommunicateDeviceType.FindAll();
            //foreach (var communicateDeviceType in communicateDeviceTypeList)
            //{
            //    this.cbCommunicateDeviceType.Items.Add(communicateDeviceType);
            //    this.cbCommunicateDeviceType.DisplayMember = communicateDeviceType.ID.ToString();
            //    this.cbCommunicateDeviceType.ValueMember = communicateDeviceType.Name;
            //}
            if (communicateDeviceTypeList.Count > 0)
            {
                this.cbCommunicateDeviceType.DataSource = communicateDeviceTypeList;
                this.cbCommunicateDeviceType.DisplayMember = "Name";
                this.cbCommunicateDeviceType.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 初始化通讯设备列表
        /// </summary>
        private void InitCommunicateDeviceListView()
        {
            this.listView1.Items.Clear();
            List<CommunicateDevice> communicateDeviceList = CommunicateDevice.FindAll();
            foreach (var communicateDevice in communicateDeviceList)
            {
                var strings = new string[]
                {
                    communicateDevice.ID.ToString(), communicateDevice.Name, communicateDevice.CommunicateDeviceTypeName,
                    communicateDevice.Args1, communicateDevice.Args2, communicateDevice.Args3, communicateDevice.Args4,
                    communicateDevice.Args5, communicateDevice.OnlineStatus.ToString(), communicateDevice.Exception,
                    communicateDevice.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = communicateDevice;
                this.listView1.Items.Add(listViewItem);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该通讯设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该通讯设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is CommunicateDevice)
                    {
                        var communicateDevice = this.listView1.SelectedItems[0].Tag as CommunicateDevice;
                        //int id = communicateDevice.ID;
                        //List<ShowDevice> showDeviceList = ShowDevice.FindAllByCommunicateDeviceID(id);
                        //if (showDeviceList != null)
                        //{
                        //    MessageBox.Show("该设备已经在使用，不能删除");
                        //    return;
                        //}
                        //CommunicateDevice.Delete(communicateDevice);
                        communicateDevice.Delete();
                        this.InitCommunicateDeviceListView();
                        this.communicateDeviceId = 0;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is CommunicateDevice)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as CommunicateDevice).ID.ToString();

                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    communicateDeviceId = (this.listView1.SelectedItems[0].Tag as CommunicateDevice).ID;
                    this.cbCommunicateDeviceType.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.txtArgs1.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtArgs2.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
                    this.txtArgs3.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    this.txtArgs4.Text = this.listView1.SelectedItems[0].SubItems[6].Text;
                    this.txtArgs5.Text = this.listView1.SelectedItems[0].SubItems[7].Text;
                    //this.cbOnlineStatus.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
                    this.rbtOnlineStatus.Checked = Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[8].Text);
                    //if (this.rbtOnlineStatus.Checked == true)
                    //{
                    //    this.rbtOnlineStatus1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtOnlineStatus1.Checked = true;
                    //}
                    this.txtException.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[10].Text;
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
            if (this.communicateDeviceId != 0)
            {
                try
                {
                    // 更新
                    var communicateDevice = new CommunicateDevice
                    {
                        ID = this.communicateDeviceId,
                        Name = this.txtName.Text.Trim(),
                        CommunicateDeviceTypeID = Convert.ToInt32(this.cbCommunicateDeviceType.SelectedValue),
                        Args1 = this.txtArgs1.Text,
                        Args2 = this.txtArgs2.Text,
                        Args3 = this.txtArgs3.Text,
                        Args4 = this.txtArgs4.Text,
                        Args5 = this.txtArgs5.Text,
                        //OnlineStatus = Convert.ToBoolean(this.cbOnlineStatus.SelectedValue),
                        OnlineStatus = this.rbtOnlineStatus.Checked,
                        Exception = this.txtException.Text,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    CommunicateDevice.Update(communicateDevice);
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
                    var communicateDevice = new CommunicateDevice
                    {
                        //ID = Convert.ToInt32(this.txtId.Text),
                        Name = this.txtName.Text.Trim(),
                        CommunicateDeviceTypeID = Convert.ToInt32(this.cbCommunicateDeviceType.SelectedValue),
                        Args1 = this.txtArgs1.Text,
                        Args2 = this.txtArgs2.Text,
                        Args3 = this.txtArgs3.Text,
                        Args4 = this.txtArgs4.Text,
                        Args5 = this.txtArgs5.Text,
                        //OnlineStatus = Convert.ToBoolean(this.cbOnlineStatus.SelectedValue),
                        OnlineStatus = this.rbtOnlineStatus.Checked,
                        Exception = this.txtException.Text,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    CommunicateDevice.Save(communicateDevice);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitCommunicateDeviceListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this.txtId.Clear();
            communicateDeviceId = 0;
            this.txtName.Clear();
            this.cbCommunicateDeviceType.SelectedIndex = -1;
            this.txtArgs1.Clear();
            this.txtArgs2.Clear();
            this.txtArgs3.Clear();
            this.txtArgs4.Clear();
            this.txtArgs5.Clear();
            //this.cbOnlineStatus.SelectedIndex = -1;
            this.rbtOnlineStatus.Checked = false;
            //this.rbtOnlineStatus1.Checked = true;
            this.txtException.Clear();
            //this.txtRemark.Clear();
        }

        private void btnSensorType_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmCommunicateDeviceTypeConfig>();
        }
        /// <summary>
        /// 双击进入配置下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormHelper.CreateForm<FrmModularDeviceConfig>("5");
        }
    }
}