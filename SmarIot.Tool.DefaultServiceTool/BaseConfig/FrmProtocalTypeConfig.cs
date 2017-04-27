using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmProtocalTypeConfig : Form
    {
        private int protocalTypeId = 0;

        public FrmProtocalTypeConfig()
        {
            InitializeComponent();
            InitProtocalTypeListView();
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
        /// 初始化数据协议类型列表
        /// </summary>
        private void InitProtocalTypeListView()
        {
            this.listView1.Items.Clear();
            List<ProtocalType> protocalTypeList = ProtocalType.FindAll();
            foreach (var protocalType in protocalTypeList)
            {
                var strings = new string[] {protocalType.ID.ToString(), protocalType.Name, protocalType.Remark};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = protocalType;
                this.listView1.Items.Add(listViewItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is ProtocalType)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as ProtocalType).ID.ToString();
                    protocalTypeId = (this.listView1.SelectedItems[0].Tag as ProtocalType).ID;
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该数据协议类型？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该数据协议类型吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is FacilityType)
                    {
                        var protocalType = this.listView1.SelectedItems[0].Tag as ProtocalType;
                        var id = protocalType.ID;
                        List<ModularDevice> modularDeviceList = ModularDevice.FindAllByProtocalTypeID(id);
                        if (modularDeviceList != null)
                        {
                            MessageBox.Show("该协议类型已经在使用，不能删除");
                            return;
                        }
                        ProtocalType.Delete(protocalType);
                        this.InitProtocalTypeListView();
                        this.protocalTypeId = 0;
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

            if (this.protocalTypeId != 0)
            {
                try
                {
                    // 更新
                    var protocalType = new ProtocalType
                    {
                        ID = this.protocalTypeId,
                        //ID =Convert.ToInt32( this.txtId.Text),
                        Name = this.txtName.Text.Trim(),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ProtocalType.Update(protocalType);
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
                    var protocalType = new ProtocalType
                    {
                        //ID = Convert.ToInt32(this.txtId.Text),
                        Name = this.txtName.Text.Trim(),
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ProtocalType.Save(protocalType);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitProtocalTypeListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.protocalTypeId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.txtRemark.Clear();
        }
    }
}