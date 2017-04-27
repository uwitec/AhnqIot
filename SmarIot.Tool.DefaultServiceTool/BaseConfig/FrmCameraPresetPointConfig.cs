using SmartIot.Tool.DefaultService.DB;
using SmartIot.Tool.DefaultServiceTool.Common;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmCameraPresetPointConfig : Form
    {
        private int cameraPreSetPointId = 0;

        public FrmCameraPresetPointConfig()
        {
            InitializeComponent();
            InitFacilityCamera();
            InitCameraPreSetPointListView();
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
        /// 初始化预置点列表
        /// </summary>
        private void InitCameraPreSetPointListView()
        {
            this.listView1.Items.Clear();
            List<CameraPresetPoint> cameraPresetPointList = CameraPresetPoint.FindAll();
            foreach (var cameraPresetPoint in cameraPresetPointList)
            {
                var strings = new[]
                {
                    cameraPresetPoint.ID.ToString(), cameraPresetPoint.Code1, cameraPresetPoint.Code2,
                    cameraPresetPoint.Code3, cameraPresetPoint.Name, cameraPresetPoint.PresetPoint.ToString(),
                    cameraPresetPoint.FacilityCameraID.ToString(), cameraPresetPoint.CreateTime.ToString(),
                    cameraPresetPoint.UpdateTime.ToString(), cameraPresetPoint.Upload.ToString(),
                    cameraPresetPoint.Version.ToString(), cameraPresetPoint.Remark
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = cameraPresetPoint;
                this.listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化设施摄像机
        /// </summary>
        private void InitFacilityCamera()
        {
            List<FacilityCamera> facilityCameraList = FacilityCamera.FindAll();

            //foreach (FacilityCamera facilityCamera in facilityCameraList)
            //{
            //    this.cbFacilityCamera.Items.Add(facilityCamera);
            //    this.cbFacilityCamera.DisplayMember = facilityCamera.CameraID.ToString();
            //    this.cbFacilityCamera.ValueMember = facilityCamera.CameraName;
            //}
            if (facilityCameraList.Count > 0)
            {
                this.cbFacilityCamera.DataSource = facilityCameraList;
                this.cbFacilityCamera.DisplayMember = "Name";
                this.cbFacilityCamera.ValueMember = "ID";
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该预置点？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该预置点吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is CameraPresetPoint)
                    {
                        var cameraPresetPoint = this.listView1.SelectedItems[0].Tag as CameraPresetPoint;
                        //int id = cameraPresetPoint.ID;
                        //List<Camera> cameraList = Camera.find(id);
                        //if (showDeviceList != null)
                        //{
                        //    MessageBox.Show("该设备类型在使用中，不能删除");
                        //    return;
                        //}
                        CameraPresetPoint.Delete(cameraPresetPoint);
                        this.InitCameraPreSetPointListView();
                        this.cameraPreSetPointId = 0;
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is CameraPresetPoint)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as CameraPresetPoint).ID.ToString();
                    cameraPreSetPointId = (this.listView1.SelectedItems[0].Tag as CameraPresetPoint).ID;

                    this.txtCode1.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtCode2.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.txtCode3.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
                    this.txtPresetPoint.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    this.cbFacilityCamera.Text = this.listView1.SelectedItems[0].SubItems[6].Text;
                    //this.dtCreateTime.Value = Convert.ToDateTime(this.listView1.SelectedItems[0].SubItems[7].Text);
                    //this.txtUpdateTime.Text = this.listView1.SelectedItems[0].SubItems[8].Text;
                    //this.cbUpLoad.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
                    //this.rbtUpLoad.Checked = Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[9].Text);//给单选框赋值
                    //if (this.rbtUpLoad.Checked == true)
                    //{
                    //    this.rbtUpLoad1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtUpLoad1.Checked = true;
                    //}
                    //this.txtVersion.Text = this.listView1.SelectedItems[0].SubItems[10].Text;
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[11].Text;
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            //this.txtId.Clear();
            cameraPreSetPointId = 0;
            this.txtCode1.Clear();
            this.txtCode2.Clear();
            this.txtCode3.Clear();
            this.txtName.Clear();
            this.txtPresetPoint.Value = 0;
            this.cbFacilityCamera.SelectedIndex = -1;
            //this.dtCreateTime.Format = DateTimePickerFormat.Custom;
            //this.dtCreateTime.CustomFormat = "";
            //this.txtUpdateTime.Clear();
            //this.cbUpLoad.SelectedIndex = -1;
            //this.rbtUpLoad.Checked = false;
            //this.rbtUpLoad1.Checked = true;
            ////this.txtVersion.Clear();
            ////this.txtRemark.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim().IsNullOrWhiteSpace())
            {
                MessageBox.Show("名称不能为空,请输入");
                this.txtName.Focus();
                return;
            }
            //if (DeviceType.FindAllByName(this.txtName.Text) != null)
            //{
            //    MessageBox.Show("名称已经存在");
            //    this.txtName.Focus();
            //    return;
            //}

            if (this.cameraPreSetPointId != 0)
            {
                try
                {
                    // 更新
                    var cameraPresetPoint = new CameraPresetPoint
                    {
                        ID = this.cameraPreSetPointId,
                        Code1 = this.txtCode1.Text,
                        Code2 = this.txtCode2.Text,
                        Code3 = this.txtCode3.Text,
                        Name = this.txtName.Text.Trim(),
                        PresetPoint = Convert.ToInt32(this.txtPresetPoint.Text),
                        FacilityCameraID = Convert.ToInt32(this.cbFacilityCamera.SelectedValue),
                        //CreateTime = this.dtCreateTime.Value,
                        UpdateTime = DateTime.Now,
                        //Upload = Convert.ToBoolean(this.cbUpLoad.SelectedValue),
                        //Upload=this.rbtUpLoad.Checked,
                        //Version = Convert.ToInt32(this.txtVersion.Text),
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    CameraPresetPoint.Update(cameraPresetPoint);
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
                    var cameraPresetPoint = new CameraPresetPoint
                    {
                        Code1 = this.txtCode1.Text,
                        Code2 = this.txtCode2.Text,
                        Code3 = this.txtCode3.Text,
                        Name = this.txtName.Text.Trim(),
                        PresetPoint = Convert.ToInt32(this.txtPresetPoint.Text),
                        FacilityCameraID = Convert.ToInt32(this.cbFacilityCamera.SelectedValue),
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now,
                        //Upload = Convert.ToBoolean(this.cbUpLoad.SelectedValue),
                        //Upload=this.rbtUpLoad.Checked,
                        //Version = Convert.ToInt32(this.txtVersion.Text),
                        //Remark = this.txtRemark.Text.Trim()
                    };
                    CameraPresetPoint.Save(cameraPresetPoint);
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("保存失败");
                }
            }

            this.InitCameraPreSetPointListView();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSensorType_Click(object sender, EventArgs e)
        {
            FormHelper.CreateForm<FrmCameraConfig>();
        }
    }
}