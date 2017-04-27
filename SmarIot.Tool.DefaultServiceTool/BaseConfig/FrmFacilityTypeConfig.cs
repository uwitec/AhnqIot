using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmFacilityTypeConfig : Form
    {
        private string facilityTypeSerialnum = null;

        public FrmFacilityTypeConfig()
        {
            InitializeComponent();
            InitFacilityTypeListView();
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
        /// 初始化设施类型列表
        /// </summary>
        private void InitFacilityTypeListView()
        {
            this.listView1.Items.Clear();
            List<FacilityType> facilityTypeList = FacilityType.FindAll();
            foreach (var facilityType in facilityTypeList)
            {
                var strings = new string[]
                {
                    facilityType.Serialnum, facilityType.Name, facilityType.ParentSerialnum,
                    facilityType.Version.ToString(), facilityType.CreateTime.ToString(),
                    facilityType.UpdateTime.ToString(), facilityType.PhotoUrl, facilityType.Introduce,
                    facilityType.Upload.ToString(), facilityType.CreateType, facilityType.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = facilityType;
                this.listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 选项改变时，将选中项带入上面的控件内进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is FacilityType)
                {
                    //this.txtSerialnum.Text = (this.listView1.SelectedItems[0].Tag as FacilityType).Serialnum.ToString();
                    facilityTypeSerialnum = (this.listView1.SelectedItems[0].Tag as FacilityType).Serialnum;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtParentSerialbum.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    //this.txtVersion.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    //this.dtCreateTime.Value = Convert.ToDateTime(this.listView1.SelectedItems[0].SubItems[4].Text);
                    //this.txtUpdateTime.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    //this.pbPhotoUrl.Image = this.listView1.SelectedItems[0].SubItems[6].Text;//绑定图片
                    this.txtIntroduce.Text = this.listView1.SelectedItems[0].SubItems[7].Text;
                    //this.cbUpload.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
                    //this.rbtUpLoad.Checked = Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[8].Text);
                    //if (this.rbtUpLoad.Checked == true)
                    //{
                    //    this.rbtUpLoad1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtUpLoad1.Checked = true;
                    //}
                    this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
                    this.txtCreateType.Text = this.listView1.SelectedItems[0].SubItems[10].Text;
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
                //if (MessageBox.Show("是否删除该设施类型？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该设施类型吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is FacilityType)
                    {
                        var facilityType = this.listView1.SelectedItems[0].Tag as FacilityType;
                        var serialnum = facilityType.Serialnum;
                        List<Facility> facilityList = Facility.FindAllByFacilityTypeSerialnum(serialnum);
                        if (facilityList != null)
                        {
                            MessageBox.Show("该设备已经在使用，不能删除");
                            return;
                        }
                        FacilityType.Delete(facilityType);
                        this.InitFacilityTypeListView();
                        this.facilityTypeSerialnum = null;
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

            //if (this.txtParentSerialbum.Text == null)
            //{
            //    MessageBox.Show("上及编码不能为空");
            //    this.txtParentSerialbum.Focus();
            //    return;
            //}

            //if (FacilityType.FindAllByName(this.txtName.Text) != null)
            //{
            //    MessageBox.Show("名称已经存在");
            //    this.txtName.Focus();
            //    return;
            //}

            if (this.facilityTypeSerialnum != null)
            {
                try
                {
                    // 更新
                    var facilityType = new FacilityType
                    {
                        Serialnum = this.facilityTypeSerialnum,
                        //Serialnum = facilityType.AutoSerialnum,
                        Name = this.txtName.Text.Trim(),
                        ParentSerialnum = this.txtParentSerialbum.Text,
                        //Version = Convert.ToInt32(this.txtVersion.Text),
                        //CreateTime = this.dtCreateTime.Value,
                        UpdateTime = DateTime.Now,
                        //PhotoUrl = this.pbPhotoUrl.Image.ToString(),
                        Introduce = this.txtIntroduce.Text,
                        //Upload =Convert.ToBoolean(this.cbUpload.SelectedValue),
                        //Upload=this.rbtUpLoad.Checked,
                        Remark = this.txtRemark.Text.Trim(),
                        CreateType = this.txtCreateType.Text.Trim()
                    };
                    FacilityType.Update(facilityType);
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
                    var facilityType = new FacilityType
                    {
                        //Serialnum = this.txtSerialnum.Text,
                        Name = this.txtName.Text.Trim(),
                        ParentSerialnum = this.txtParentSerialbum.Text,
                        //Version = Convert.ToInt32(this.txtVersion.Text),
                        //CreateTime = this.dtCreateTime.Value,
                        UpdateTime = DateTime.Now,
                        //PhotoUrl = this.pbPhotoUrl.Image.ToString(),
                        Introduce = this.txtIntroduce.Text,
                        //Upload = Convert.ToBoolean(this.cbUpload.SelectedValue),
                        //Upload = this.rbtUpLoad.Checked,
                        Remark = this.txtRemark.Text.Trim(),
                        CreateType = this.txtCreateType.Text.Trim()
                    };
                    FacilityType.Save(facilityType);
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitFacilityTypeListView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this.txtSerialnum.Clear();
            this.facilityTypeSerialnum = null;
            this.txtName.Clear();
            this.txtParentSerialbum.Clear();
            //this.txtVersion.Clear();
            //this.dtCreateTime.Format = DateTimePickerFormat.Custom;
            //dtCreateTime.CustomFormat = " ";//清空日期控件选中项
            //this.txtUpdateTime.Clear();
            //this.pbPhotoUrl.Image = null;//清空图片内容
            this.txtIntroduce.Clear();
            //this.cbUpload.SelectedIndex=-1;
            //this.rbtUpLoad.Checked = false;
            //this.rbtUpLoad1.Checked = true;
            this.txtRemark.Clear();
            this.txtCreateType.Clear();
        }
    }
}