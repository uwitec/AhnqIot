using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FormShowDeviceTypeConfig : Form
    {
        private int showDeviceTypeId = 0;

        public FormShowDeviceTypeConfig()
        {
            InitializeComponent();
            InitShowDeviceTypeListView();
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
        /// 初始化展示设备类型列表
        /// </summary>
        private void InitShowDeviceTypeListView()
        {
            this.listView1.Items.Clear();
            List<ShowDeviceType> showDeviceTypeList = ShowDeviceType.FindAll();
            foreach (var showDeviceType in showDeviceTypeList)
            {
                var strings = new string[]
                {
                    showDeviceType.ID.ToString(), showDeviceType.Name, showDeviceType.Company, showDeviceType.Version,
                    showDeviceType.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = showDeviceType;
                this.listView1.Items.Add(listViewItem);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该展示设备类型？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该展示设备类型吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is ShowDeviceType)
                    {
                        var showDeviceType = this.listView1.SelectedItems[0].Tag as ShowDeviceType;
                        var id = showDeviceType.ID;
                        List<ShowDevice> showDeviceList = ShowDevice.FindAllByShowDeviceTypeID(id);
                        if (showDeviceList != null)
                        {
                            MessageBox.Show("该设备类型在使用中，不能删除");
                            return;
                        }
                        ShowDeviceType.Delete(showDeviceType);
                        this.InitShowDeviceTypeListView();
                        this.showDeviceTypeId = 0;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is ShowDeviceType)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as ShowDeviceType).ID.ToString();
                    this.showDeviceTypeId = (this.listView1.SelectedItems[0].Tag as ShowDeviceType).ID;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtCompany.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    //this.txtVersion.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
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
            if (this.txtName.Text.Trim().IsNullOrWhiteSpace())
            {
                MessageBox.Show("名称不能为空,请输入");
                this.txtName.Focus();
                return;
            }

            if (this.showDeviceTypeId != 0)
            {
                try
                {
                    // 更新
                    var showDeviceType = new ShowDeviceType
                    {
                        ID = this.showDeviceTypeId,
                        Name = this.txtName.Text.Trim(),
                        Company = this.txtCompany.Text,
                        //Version=this.txtVersion.Text,
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ShowDeviceType.Update(showDeviceType);
                    MessageBox.Show(@"更新成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show(@"更新失败");
                }
            }
            else
            {
                try
                {
                    // 保存
                    var showDeviceType = new ShowDeviceType
                    {
                        //ID = Convert.ToInt32(this.txtId.Text),
                        Name = this.txtName.Text.Trim(),
                        Company = this.txtCompany.Text,
                        //Version = this.txtVersion.Text,
                        Remark = this.txtRemark.Text.Trim()
                    };
                    ShowDeviceType.Save(showDeviceType);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitShowDeviceTypeListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            showDeviceTypeId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.txtCompany.Clear();
            //this.txtVersion.Clear();
            this.txtRemark.Clear();
        }
    }
}