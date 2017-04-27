using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmCommunicateDeviceTypeConfig : Form
    {
        private int communicateDeviceTypeId = 0;

        public FrmCommunicateDeviceTypeConfig()
        {
            InitializeComponent();
            InitCommunicateDeviceTypeListView();
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
        /// 初始化通讯设备类型列表
        /// </summary>
        private void InitCommunicateDeviceTypeListView()
        {
            this.listView1.Items.Clear();
            List<CommunicateDeviceType> communicateDeviceTypeList = CommunicateDeviceType.FindAll();
            foreach (var communicateDeviceType in communicateDeviceTypeList)
            {
                var strings = new string[]
                {communicateDeviceType.ID.ToString(), communicateDeviceType.Name, communicateDeviceType.Remark};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = communicateDeviceType;
                this.listView1.Items.Add(listViewItem);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该通讯设备类型？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该通讯设备类型吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is CommunicateDeviceType)
                    {
                        var communicateDeviceType = this.listView1.SelectedItems[0].Tag as CommunicateDeviceType;
                        var id = communicateDeviceType.ID;
                        List<CommunicateDevice> communicateDeviceList =
                            CommunicateDevice.FindAllByCommunicateDeviceTypeID(id);
                        if (communicateDeviceList != null)
                        {
                            MessageBox.Show("该设备类型已经在使用，不能删除");
                            return;
                        }
                        CommunicateDeviceType.Delete(communicateDeviceType);
                        this.InitCommunicateDeviceTypeListView();
                        this
                            .communicateDeviceTypeId = 0;
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

            //if (ProtocalType.FindAllByName(this.txtName.Text) != null)
            //{
            //    MessageBox.Show("名称已经存在");
            //    this.txtName.Focus();
            //    return;
            //}
            if (this.communicateDeviceTypeId != 0)
            {
                try
                {
                    // 更新
                    var communicateDeviceType = new CommunicateDeviceType
                    {
                        ID = this.communicateDeviceTypeId,
                        Name = this.txtName.Text.Trim(),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    CommunicateDeviceType.Update(communicateDeviceType);
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
                    var communicateDeviceType = new CommunicateDeviceType
                    {
                        Name = this.txtName.Text.Trim(),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    CommunicateDeviceType.Save(communicateDeviceType);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitCommunicateDeviceTypeListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            communicateDeviceTypeId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.txtRemark.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is CommunicateDeviceType)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as CommunicateDeviceType).ID.ToString();
                    communicateDeviceTypeId = (this.listView1.SelectedItems[0].Tag as CommunicateDeviceType).ID;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
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
    }
}