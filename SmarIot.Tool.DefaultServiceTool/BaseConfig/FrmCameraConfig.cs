using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmCameraConfig : Form
    {
        private int cameraId = 0;

        public FrmCameraConfig()
        {
            InitializeComponent();
            InitCameraList();
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
        /// 初始化摄像机列表
        /// </summary>
        private void InitCameraList()
        {
            this.listView1.Items.Clear();
            List<Camera> cameraList = Camera.FindAll();
            foreach (var camera in cameraList)
            {
                var strings = new[]
                {
                    camera.ID.ToString(), camera.Name, camera.UserID, camera.UserPwd, camera.CameraHost,
                    camera.CameraHttpPort.ToString(), camera.CameraDataPort.ToString(), camera.CameraRTSPPort.ToString(),
                    camera.OnlineStatus.ToString(), camera.Exception, camera.Channel.ToString(), camera.StreamMedia,
                    camera.Company, camera.Remark
                };
                var listView = new ListViewItem(strings);
                listView.Tag = camera;
                this.listView1.Items.Add(listView);
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("确定要删除该摄像机？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该摄像机吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (listView1.SelectedItems[0].Tag is Camera)
                    {
                        var camera = listView1.SelectedItems[0].Tag as Camera;
                        //int id = camera.ID;
                        //List<FacilityCamera> facilityCameraList = FacilityCamera.FindAllByCameraID(id);
                        //if (facilityCameraList != null)
                        //{
                        //    MessageBox.Show("该设备已经在使用，不能删除");
                        //    return;
                        //}
                        //Camera.Delete(camera);
                        camera.Delete();
                        InitCameraList();
                        this.cameraId = 0;
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
        /// 选中项事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is Camera)
                {
                    var camera = this.listView1.SelectedItems[0].Tag as Camera;
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as Camera).ID.ToString();
                    this.cameraId = camera.ID; //this.listView1.SelectedItems[0].Tag as Camera).ID;
                    this.txtName.Text = camera.Name; //this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtUser.Text = camera.UserID; //this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.txtPwd.Text = camera.UserPwd; //this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtAddress.Text = camera.CameraHost; // this.listView1.SelectedItems[0].SubItems[4].Text;
                    this.txtWebPort.Text = camera.CameraHttpPort.ToString();
                    //this.listView1.SelectedItems[0].SubItems[5].Text;
                    this.txtDataPort.Text = camera.CameraDataPort.ToString();
                    // this.listView1.SelectedItems[0].SubItems[6].Text;
                    this.txtRTSPort.Text = camera.CameraRTSPPort.ToString();
                    //this.listView1.SelectedItems[0].SubItems[7].Text;
                    //this.cbOnlineStatus.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
                    this.rbtOnlineStatus.Checked = camera.OnlineStatus;
                    // Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[8].Text);//给单选框赋值
                    //if (this.rbtOnlineStatus.Checked==true)
                    //{
                    //    this.rbtOnlineStatus1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtOnlineStatus1.Checked = true;
                    //}
                    this.txtException.Text = camera.Exception; //this.listView1.SelectedItems[0].SubItems[9].Text;
                    this.txtChanel.Text = camera.Channel.ToString();
                    //this.listView1.SelectedItems[0].SubItems[10].Text;
                    //this.txtStreamMedia.Text = this.listView1.SelectedItems[0].SubItems[11].Text;
                    ////this.txtCompany.Text = this.listView1.SelectedItems[0].SubItems[12].Text;
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[13].Text;
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

            if (this.cameraId != 0)
            {
                try
                {
                    // 更新
                    var camera = new Camera
                    {
                        ID = this.cameraId,
                        Name = this.txtName.Text.Trim(),
                        UserID = this.txtUser.Text.Trim(),
                        UserPwd = this.txtPwd.Text.Trim(),
                        CameraHost = this.txtAddress.Text.Trim(),
                        CameraDataPort = Convert.ToInt32(this.txtDataPort.Text.Trim()),
                        CameraHttpPort = Convert.ToInt32(this.txtWebPort.Text.Trim()),
                        CameraRTSPPort = Convert.ToInt32(this.txtRTSPort.Text.Trim()),
                        Channel = Convert.ToInt32(this.txtChanel.Text.Trim()),
                        Exception = this.txtException.Text.Trim(),
                        //Company = this.txtCompany.Text.Trim(),
                        //OnlineStatus=Convert.ToBoolean(this.cbOnlineStatus.DisplayMember),
                        OnlineStatus = this.rbtOnlineStatus.Checked,
                        //StreamMedia=this.txtStreamMedia.Text,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    Camera.Update(camera);
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
                    var camera = new Camera
                    {
                        //ID = Convert.ToInt32(this.txtId.Text),
                        Name = this.txtName.Text.Trim(),
                        UserID = this.txtUser.Text.Trim(),
                        UserPwd = this.txtPwd.Text.Trim(),
                        CameraHost = this.txtAddress.Text.Trim(),
                        CameraDataPort = Convert.ToInt32(this.txtDataPort.Text.Trim()),
                        CameraHttpPort = Convert.ToInt32(this.txtWebPort.Text.Trim()),
                        CameraRTSPPort = Convert.ToInt32(this.txtRTSPort.Text.Trim()),
                        Channel = Convert.ToInt32(this.txtChanel.Text.Trim()),
                        Exception = this.txtException.Text.Trim(),
                        //Company = this.txtCompany.Text.Trim(),
                        //OnlineStatus = Convert.ToBoolean(this.cbOnlineStatus.SelectedValue),
                        OnlineStatus = this.rbtOnlineStatus.Checked,
                        //StreamMedia = this.txtStreamMedia.Text,
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    Camera.Save(camera);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitCameraList();
        }

        /// <summary>
        /// 清空控件内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.cameraId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.txtUser.Clear();
            this.txtPwd.Clear();
            this.txtAddress.Clear();
            this.txtWebPort.Value = 1;
            this.txtDataPort.Value = 1;
            this.txtRTSPort.Value = 1;
            //this.cbOnlineStatus.SelectedIndex = -1;
            this.txtException.Clear();
            this.txtChanel.Value = 1;
            //this.txtStreamMedia.Clear();
            ////this.txtCompany.Clear();
            //this.txtRemark.Clear();
            this.rbtOnlineStatus.Checked = false;
            //this.rbtOnlineStatus1.Checked = true;
        }
    }
}