using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmParmeterConfig : Form
    {
        private int parmeterConfigId = 0;

        public FrmParmeterConfig()
        {
            InitializeComponent();
            InitParmeterConfigList();
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
        /// 初始化参数配置列表
        /// </summary>
        private void InitParmeterConfigList()
        {
            this.listView1.Items.Clear();
            List<ParmeterConfig> parmeterConfigList = ParmeterConfig.FindAll();
            foreach (var parmeterConfig in parmeterConfigList)
            {
                var strings = new[]
                {
                    parmeterConfig.ID.ToString(), parmeterConfig.Name, parmeterConfig.Type, parmeterConfig.Value,
                    parmeterConfig.Remark
                };
                var listView = new ListViewItem(strings);
                listView.Tag = parmeterConfig;
                this.listView1.Items.Add(listView);
            }
        }

        /// <summary>
        /// 删除列表选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("确定要删除该参数配置？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该参数配置吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (listView1.SelectedItems[0].Tag is ParmeterConfig)
                    {
                        var parmeterConfig = listView1.SelectedItems[0].Tag as ParmeterConfig;
                        ParmeterConfig.Delete(parmeterConfig);
                        InitParmeterConfigList();
                    }
                }
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView1.SelectedItems.Count == 1)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        /// <summary>
        /// 选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is ParmeterConfig)
                {
                    this.parmeterConfigId = (this.listView1.SelectedItems[0].Tag as ParmeterConfig).ID;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtType.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.txtValue.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim().IsNullOrWhiteSpace())
            {
                MessageBox.Show("名称不能为空,请输入");
                this.txtName.Focus();
                return;
            }

            if (this.parmeterConfigId != 0)
            {
                try
                {
                    // 更新
                    var parmeterConfig = new ParmeterConfig
                    {
                        ID = this.parmeterConfigId,
                        Name = this.txtName.Text.Trim(),
                        Type = this.txtType.Text,
                        Value = this.txtValue.Text
                    };
                    ParmeterConfig.Update(parmeterConfig);
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
                    var parmeterConfig = new ParmeterConfig
                    {
                        //ID = this.parmeterConfigId,
                        Name = this.txtName.Text.Trim(),
                        Type = this.txtType.Text,
                        Value = this.txtValue.Text
                    };
                    ParmeterConfig.Save(parmeterConfig);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitParmeterConfigList();
        }

        /// <summary>
        /// 清空控件内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.parmeterConfigId = 0;
            this.txtName.Clear();
            this.txtType.Clear();
            this.txtValue.Clear();
        }
    }
}