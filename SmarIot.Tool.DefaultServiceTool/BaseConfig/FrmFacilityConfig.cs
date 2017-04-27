using SmartIot.Tool.DefaultService.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmFacilityConfig : Form
    {
        private int facilityId = 0;

        public FrmFacilityConfig()
        {
            InitializeComponent();
            InitFacilityListView(); //绑定设施列表
            InitCollectDeviceListView(); //绑定传感器设备列表
            InitControlDeviceListView(); //绑定控制设备列表
            InitCameraDeviceListView(); //绑定摄像机设备列表
            InitFacilityType(); //绑定设施类型
            InitFarm();
        }

        /// <summary>
        /// 从键盘上输入按钮触发事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    if (btnSave.Enabled)
                    {
                        btnSave_Click(btnSave, new EventArgs());
                    }
                    return true;
                case Keys.Escape:
                    this.Close();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 初始化设施列表
        /// </summary>
        private void InitFacilityListView()
        {
            this.listView1.Items.Clear();
            List<Facility> facilityList = Facility.FindAll();
            foreach (var fac in facilityList)
            {
                var strings = new[]
                {
                    fac.ID.ToString(), fac.Name, fac.Code1, fac.Code2, fac.Code3, fac.FacilityTypeName, fac.FarmName,
                    fac.ContactPhone, fac.CreateTime.ToString(CultureInfo.InvariantCulture),
                    fac.UpdateTime.ToString(CultureInfo.InvariantCulture), fac.Upload.ToString(),
                    fac.Version.ToString(), fac.Status.ToString(), fac.Address, fac.Introduce, fac.ContactMan,
                    fac.ContactMobile, fac.Remark, fac.PhotoUrl
                };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = fac;
                this.listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化传感器设备列表
        /// </summary>
        private void InitCollectDeviceListView()
        {
            this.listView2.Items.Clear();
            List<SensorDeviceUnit> collectDeviceList = SensorDeviceUnit.FindAll();
            foreach (var collectDevice in collectDeviceList)
            {
                var strings = new string[] {collectDevice.ModularDeviceName, collectDevice.Name};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = collectDevice;
                this.listView2.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化控制设备列表
        /// </summary>
        private void InitControlDeviceListView()
        {
            this.listView3.Items.Clear();
            List<ControlDeviceUnit> controlDeviceList = ControlDeviceUnit.FindAll();
            foreach (var controlDevice in controlDeviceList)
            {
                var strings = new string[] {controlDevice.ModularDeviceName, controlDevice.Name};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = controlDevice;
                this.listView3.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化摄像机设备列表
        /// </summary>
        private void InitCameraDeviceListView()
        {
            this.listView4.Items.Clear();
            List<Camera> cameraList = Camera.FindAll();
            if (cameraList.Count != 0)
            {
                foreach (var camera in cameraList)
                {
                    var strings = new[] {camera.Name, camera.OnlineStatus.ToString()};
                    var listViewItem = new ListViewItem(strings) {Tag = camera};
                    this.listView4.Items.Add(listViewItem);
                }
            }
        }

        /// <summary>
        /// 初始化设施类型
        /// </summary>
        private void InitFacilityType()
        {
            List<FacilityType> facilityTypeList = FacilityType.FindAll();

            if (facilityTypeList.Count > 0)
            {
                this.cbFacilityType.DataSource = facilityTypeList;
                this.cbFacilityType.DisplayMember = "Name";
                this.cbFacilityType.ValueMember = "Serialnum";
            }
        }

        /// <summary>
        /// 初始化基地
        /// </summary>
        private void InitFarm()
        {
            List<Farm> farmList = Farm.FindAll();
            if (farmList.Count > 0)
            {
                this.cbFarm.DataSource = farmList;
                this.cbFarm.DisplayMember = "Name";
                this.cbFarm.ValueMember = "ID";
            }
        }

        /// <summary>
        /// The list view 1 selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                if (this.listView1.SelectedItems[0].Tag is Facility)
                {
                    //this.txtId.Text = (this.listView1.SelectedItems[0].Tag as Facility).ID.ToString();
                    facilityId = (this.listView1.SelectedItems[0].Tag as Facility).ID;
                    this.txtName.Text = this.listView1.SelectedItems[0].SubItems[1].Text;
                    this.txtCode1.Text = this.listView1.SelectedItems[0].SubItems[2].Text;
                    this.txtCode2.Text = this.listView1.SelectedItems[0].SubItems[3].Text;
                    this.txtCode3.Text = this.listView1.SelectedItems[0].SubItems[4].Text;
                    this.cbFacilityType.Text = this.listView1.SelectedItems[0].SubItems[5].Text;
                    this.cbFarm.Text = this.listView1.SelectedItems[0].SubItems[6].Text;
                    this.txtContactPhone.Text = this.listView1.SelectedItems[0].SubItems[7].Text;
                    //this.dtCreateTime.Value = Convert.ToDateTime(this.listView1.SelectedItems[0].SubItems[8].Text);
                    //this.txtUpdateTime.Text = this.listView1.SelectedItems[0].SubItems[9].Text;
                    //this.cbUpLoad.Text = this.listView1.SelectedItems[0].SubItems[10].Text;
                    //this.rbtUpLoad.Checked = Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[10].Text);
                    //if (this.rbtUpLoad.Checked == true)
                    //{
                    //    this.rbtUpLoad1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtUpLoad1.Checked = true;
                    //}
                    //this.txtVersion.Text = this.listView1.SelectedItems[0].SubItems[11].Text;
                    //this.cbStatus.Text = this.listView1.SelectedItems[0].SubItems[12].Text;
                    this.rbtOnlineStatus.Checked = Convert.ToBoolean(this.listView1.SelectedItems[0].SubItems[12].Text);
                    //if (this.rbtOnlineStatus.Checked == true)
                    //{
                    //    this.rbtOnlineStatus1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtOnlineStatus1.Checked = true;
                    //}
                    this.txtAddress.Text = this.listView1.SelectedItems[0].SubItems[13].Text;
                    this.txtIntroduce.Text = this.listView1.SelectedItems[0].SubItems[14].Text;
                    this.txtContactMan.Text = this.listView1.SelectedItems[0].SubItems[15].Text;
                    this.txtContactMobile.Text = this.listView1.SelectedItems[0].SubItems[16].Text;
                    //this.txtRemark.Text = this.listView1.SelectedItems[0].SubItems[17].Text;
                    //this.pbPhotoUrl.Text = this.listView1.SelectedItems[0].SubItems[18].Text;

                    #region 采集设备列表的改变事件

                    List<FacilitySensorDeviceUnit> facilitySensorDeviceUnitList =
                        (this.listView1.SelectedItems[0].Tag as Facility).FacilitySensorDeviceUnits;
                    //获取该设施所拥有的所有采集设备的集合
                    var collectionDeviceList = new List<SensorDeviceUnit>();
                    foreach (var fac in facilitySensorDeviceUnitList)
                    {
                        var collectionDevice = SensorDeviceUnit.FindByID(fac.SensorDeviceUnitID);
                        collectionDeviceList.Add(collectionDevice);
                    }

                    if (collectionDeviceList == null || collectionDeviceList.Count == 0)
                    {
                        foreach (ListViewItem item in this.listView2.Items)
                        {
                            item.Checked = false;
                        }

                        //return;
                    }
                    else
                    {
                        foreach (ListViewItem item in this.listView2.Items)
                        {
                            var isExists = false;
                            foreach (var collectDevice in collectionDeviceList)
                            {
                                var sDevice = item.Tag as SensorDeviceUnit;
                                if (sDevice != null)
                                {
                                    if (sDevice.ID == collectDevice.ID)
                                    {
                                        isExists = true;
                                    }
                                }
                            }

                            item.Checked = isExists;
                        }
                    }

                    #endregion 采集设备列表的改变事件

                    #region 控制设备列表的改变事件

                    List<FacilityControlDeviceUnit> facilityControlDeviceUnitList =
                        (this.listView1.SelectedItems[0].Tag as Facility).FacilityControlDeviceUnits;
                    //获取该设施所拥有的所有控制设备的集合
                    var controlDeviceList = new List<ControlDeviceUnit>();
                    foreach (var fas in facilityControlDeviceUnitList)
                    {
                        var controlDevices = ControlDeviceUnit.FindByGroupNum(fas.ControlDeviceUnitGroupNum);
                        controlDeviceList.AddRange(controlDevices);
                    }
                    if (controlDeviceList == null || controlDeviceList.Count == 0)
                    {
                        foreach (ListViewItem item in this.listView3.Items)
                        {
                            item.Checked = false;
                        }
                    }
                    else
                    {
                        foreach (ListViewItem item in this.listView3.Items)
                        {
                            var isExists = false;
                            foreach (var controlDevice in controlDeviceList)
                            {
                                var cDevice = item.Tag as ControlDeviceUnit;
                                if (cDevice != null)
                                {
                                    if (cDevice.ID == controlDevice.ID)
                                    {
                                        isExists = true;
                                    }
                                }
                            }

                            item.Checked = isExists;
                        }
                    }

                    #endregion 控制设备列表的改变事件

                    #region 摄像机设备列表的改变事件

                    //List<FacilityCamera> facilityCameraList = FacilityCamera.FindAllByFacilityID((this.listView1.SelectedItems[0].Tag as Facility).ID);

                    List<FacilityCamera> facilityCameraList =
                        (this.listView1.SelectedItems[0].Tag as Facility).FacilityCameras; //获取该设施所拥有的所有摄像机设备的集合
                    var cameraList = new List<Camera>();
                    foreach (var fc in facilityCameraList)
                    {
                        var camera = Camera.FindByID(fc.CameraID);
                        cameraList.Add(camera);
                    }
                    if (cameraList == null || cameraList.Count == 0)
                    {
                        foreach (ListViewItem item in this.listView4.Items)
                        {
                            item.Checked = false;
                        }

                        //return;
                    }

                    foreach (ListViewItem item in this.listView4.Items)
                    {
                        var isExists = false;
                        foreach (var facilityCamera in cameraList)
                        {
                            var c = item.Tag as Camera;
                            if (c != null)
                            {
                                if (c.ID == facilityCamera.ID)
                                {
                                    isExists = true;
                                }
                            }
                        }

                        item.Checked = isExists;
                    }

                    #endregion 摄像机设备列表的改变事件
                }
            }
        }

        /// <summary>
        /// 清空控件内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.facilityId = 0;
            //this.txtId.Clear();
            this.txtName.Clear();
            this.txtCode1.Clear();
            this.txtCode2.Clear();
            this.txtCode3.Clear();
            this.cbFacilityType.SelectedIndex = -1;
            this.cbFarm.SelectedIndex = -1;
            this.txtContactPhone.Clear();
            //this.dtCreateTime.Format = DateTimePickerFormat.Custom;
            //this.dtCreateTime.CustomFormat = "   ";
            //this.txtUpdateTime.Clear();
            //this.cbStatus.SelectedIndex = -1;
            this.rbtOnlineStatus.Checked = false;
            //this.rbtOnlineStatus1.Checked = true;
            //this.txtVersion.Clear();
            //this.cbUpLoad.SelectedIndex = -1;
            //this.rbtUpLoad.Checked = false;
            //this.rbtUpLoad1.Checked = true;
            this.txtAddress.Clear();
            this.txtIntroduce.Clear();
            this.txtContactMan.Clear();
            this.txtContactMobile.Clear();
            //this.txtRemark.Clear();
            //this.pbPhotoUrl.Image = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 判断条件

            if (this.txtName.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show("名称不能为空,请输入");
                this.txtName.Focus();
                return;
            }

            #endregion 判断条件

            var facility = new Facility();

            if (this.facilityId != 0)
            {
                #region 更新

                facility = Facility.FindByID(this.facilityId);
                facility.Name = this.txtName.Text;
                facility.FacilityTypeSerialnum = this.cbFacilityType.SelectedValue.ToString();
                facility.FarmID = Convert.ToInt32(this.cbFarm.SelectedValue);
                //facility.Code1 = facility.GetCode1();
                //facility.Code2 = this.txtCode2.Text;
                //facility.Code3 = this.txtCode3.Text;
                facility.ContactPhone = this.txtContactPhone.Text;
                //facility.CreateTime = this.dtCreateTime.Value;
                facility.UpdateTime = DateTime.Now;
                //facility.Upload = this.rbtUpLoad.Checked;
                //facility.Version = Convert.ToInt32(this.txtVersion.Text);
                facility.Status = this.rbtOnlineStatus.Checked;
                facility.Address = this.txtAddress.Text;
                facility.Introduce = this.txtIntroduce.Text;
                facility.ContactMan = this.txtContactMan.Text;
                facility.ContactMobile = this.txtContactMobile.Text;
                //facility.Remark = this.txtRemark.Text;
                //facility.PhotoUrl = this.pbPhotoUrl.Text;
                try
                {
                    // Facility.Update(facility);
                    facility.Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("更新失败" + ex.Message);
                }

                #endregion 更新
            }
            else
            {
                #region 保存设施

                facility.Name = this.txtName.Text;
                facility.FarmID = Convert.ToInt32(this.cbFarm.SelectedValue);
                if (!(facility.Code1 + "").StartsWith(facility.Farm.Code1 + ""))
                {
                    facility.Code1 = facility.GetCode1();
                }
                //if (!facility.Farm.Code2.IsNullOrWhiteSpace())
                //{
                //    //facility.Code2 = facility.Farm.Code2 + "G00" + facility.ID;
                //    facility.Code1 = Facility.GetCode2(facility.Farm.ID);
                //}
                //if (!facility.Farm.Code3.IsNullOrWhiteSpace())
                //{
                //    //facility.Code3 = facility.Farm.Code3 + "G00" + facility.ID;
                //    facility.Code1 = Facility.GetCode3(facility.Farm.ID);
                //}
                facility.FacilityTypeSerialnum = this.cbFacilityType.SelectedValue.ToString();
                facility.FarmID = Convert.ToInt32(this.cbFarm.SelectedValue);
                facility.ContactPhone = this.txtContactPhone.Text;
                facility.CreateTime = DateTime.Now;
                facility.UpdateTime = DateTime.Now;
                //facility.Upload = Convert.ToBoolean(this.cbUpLoad.SelectedValue);
                //facility.Upload = this.rbtUpLoad.Checked;
                //facility.Version = Convert.ToInt32(this.txtVersion.Text);
                //facility.Status = Convert.ToBoolean(this.cbStatus.SelectedValue);
                facility.Status = this.rbtOnlineStatus.Checked;
                facility.Address = this.txtAddress.Text;
                facility.Introduce = this.txtIntroduce.Text;
                facility.ContactMan = this.txtContactMan.Text;
                facility.ContactMobile = this.txtContactMobile.Text;
                //facility.Remark = this.txtRemark.Text;
                //facility.PhotoUrl = this.pbPhotoUrl.Text;

                #endregion 保存设施

                try
                {
                    //Facility.Save(facility);
                    facility.Insert();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("新增失败" + ex);
                }
            }

            #region 获取所有选中的设备

            //List<SensorDeviceUnit> sensorDeviceUnitList = (from item in this.listView2.Items.Cast<ListViewItem>() where item.Checked select item.Tag as SensorDeviceUnit).ToList();
            var sensorDeviceUnitListChecked = new List<SensorDeviceUnit>();
            var sensorDeviceUnitListUncheck = new List<SensorDeviceUnit>();
            foreach (ListViewItem item in this.listView2.Items)
            {
                if (item.Checked == false)
                {
                    var sensorDeviceUnit = item.Tag as SensorDeviceUnit; //未选中的采集设备
                    sensorDeviceUnitListUncheck.Add(sensorDeviceUnit);
                }
                else
                {
                    sensorDeviceUnitListChecked =
                        (from i in this.listView2.Items.Cast<ListViewItem>()
                            where i.Checked
                            select i.Tag as SensorDeviceUnit).ToList(); //选中的采集设备
                }
            }

            //List<FacilityControlDeviceUnit> facilityControlDeviceUnitList = (from item in this.listView3.Items.Cast<ListViewItem>() where item.Checked select item.Tag as FacilityControlDeviceUnit).ToList();//控制设备
            var controlDeviceUnitListChecked = new List<ControlDeviceUnit>();
            var controlDeviceUnitListUnchecked = new List<ControlDeviceUnit>();
            foreach (ListViewItem item in this.listView3.Items)
            {
                if (item.Checked == false)
                {
                    var controlDeviceUnit = item.Tag as ControlDeviceUnit; //未选中的控制设备
                    controlDeviceUnitListUnchecked.Add(controlDeviceUnit);
                }
                else
                {
                    controlDeviceUnitListChecked =
                        (from i in this.listView3.Items.Cast<ListViewItem>()
                            where i.Checked
                            select i.Tag as ControlDeviceUnit).ToList(); //选中的控制设备
                }
            }

            //List<FacilityCamera> facilityCameraList = (from item in this.listView4.Items.Cast<ListViewItem>() where item.Checked select item.Tag as FacilityCamera).ToList();//摄像机设备

            var cameraListChecked = new List<Camera>();
            var cameraListUnchecked = new List<Camera>();
            foreach (ListViewItem item in this.listView4.Items)
            {
                if (item.Checked == false)
                {
                    var camera = item.Tag as Camera; //未选中的摄像机设备
                    cameraListUnchecked.Add(camera);
                }
                else
                {
                    cameraListChecked =
                        (from i in this.listView4.Items.Cast<ListViewItem>() where i.Checked select i.Tag as Camera)
                            .ToList(); //选中的摄像机设备
                }
            }

            #endregion 获取所有选中的设备

            #region 更新采集设备

            foreach (var sensorDevice in sensorDeviceUnitListChecked)
            {
                var dbList = FacilitySensorDeviceUnit.FindAllByFacilityIdAndCollectDeviceId(this.facilityId,
                    sensorDevice.ID);

                if (dbList == null || dbList.Count == 0)
                {
                    var fas = new FacilitySensorDeviceUnit()
                    {
                        FacilityID = this.facilityId,
                        SensorDeviceUnitID = sensorDevice.ID
                    };
                    fas.Code1 = fas.GetCode1();
                    fas.Insert();
                }
                else
                {
                    var fas = dbList[0];
                    if (!(fas.Code1 + "").StartsWith(facility.Code1))
                    {
                        fas.Code1 = fas.GetCode1();
                        fas.Update();
                    }
                }
            }
            foreach (var sensorDevice in sensorDeviceUnitListUncheck)
            {
                FacilitySensorDeviceUnit.DeleteByFacilityAndSensorDeviceunit(this.facilityId, sensorDevice.ID);
            }
            this.InitCollectDeviceListView();

            #endregion 更新采集设备

            #region 更新控制设备

            foreach (var controlDevice in controlDeviceUnitListChecked)
            {
                var dbList = FacilityControlDeviceUnit.FindAllByFacilityIdAndControlDeviceGroupNum(this.facilityId,
                    controlDevice.GroupNum);

                if (dbList == null || dbList.Count == 0)
                {
                    var fac = new FacilityControlDeviceUnit()
                    {
                        FacilityID = this.facilityId,
                        ControlDeviceUnitGroupNum = controlDevice.GroupNum,
                        Name = controlDevice.Name.ToString().Substring(0, controlDevice.Name.ToString().IndexOf("-"))
                    };
                    fac.Code1 = fac.GetCode1();
                    fac.Insert();
                }
                else
                {
                    var fac = dbList[0];
                    if (!(fac.Code1 + "").StartsWith(facility.Code1))
                    {
                        fac.Code1 = fac.GetCode1();
                        fac.Update();
                    }
                }
            }

            foreach (var controlDevice in controlDeviceUnitListUnchecked)
            {
                FacilityControlDeviceUnit.DeleteByFacilityAndControlDeviceunGroupNum(this.facilityId,
                    controlDevice.GroupNum);
            }
            this.InitControlDeviceListView();

            #endregion 更新控制设备

            #region 更新摄像机设备

            foreach (var facilityCamera in cameraListChecked)
            {
                var dbList = FacilityCamera.FindAllByFacilityIdAndCameraId(this.facilityId, facilityCamera.ID);

                if (dbList == null || dbList.Count == 0)
                {
                    var fac = new FacilityCamera()
                    {
                        FacilityID = this.facilityId,
                        CameraID = facilityCamera.ID
                    };
                    fac.Code1 = fac.GetCode1();
                    fac.Save();
                }
                else
                {
                    var fac = dbList[0];
                    if (!(fac.Code1 + "").StartsWith(facility.Code1))
                    {
                        fac.Code1 = fac.GetCode1();
                        fac.Update();
                    }
                }
            }
            foreach (var camera in cameraListUnchecked)
            {
                FacilityCamera.DeleteByFacilityAndCamera(this.facilityId, camera.ID);
            }
            this.InitCameraDeviceListView();

            #endregion 更新摄像机设备

            this.InitFacilityListView();

            MessageBox.Show("更新成功");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == 采集设备列表)
            //{
            //}
        }

        private void btnFacility_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmFacilityTypeConfig>();
        }

        private void btnFarm_Click(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<BaseConfig.FrmFarmEdit>();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该设施？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该设施吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listView1.SelectedItems[0].Tag is Facility)
                    {
                        var facility = this.listView1.SelectedItems[0].Tag as Facility;
                        //int id = facility.ID;
                        //List<FacilitySensorDeviceUnit> facilitySensorDeviceUnitList = FacilitySensorDeviceUnit.FindAllByFacilityID(id);
                        //List<FacilityControlDeviceUnit> facilityControlDeviceUnitList = FacilityControlDeviceUnit.FindAllByFacilityID(id);
                        //List<FacilityCamera> facilityCameraList = FacilityCamera.FindAllByFacilityID(id);
                        //if (facilitySensorDeviceUnitList != null || facilityControlDeviceUnitList != null || facilityCameraList != null)
                        //{
                        //    MessageBox.Show("该设施已经在使用，不能删除");
                        //    return;
                        //}
                        //Facility.Delete(facility);
                        facility.Delete();
                        this.InitFacilityListView();
                        this.facilityId = 0;
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

        /// <summary>
        /// 对设施采集设备编码进行更新
        /// </summary>
        /// <param name="fas">设施采集设备</param>
        /// <param name="strCode1">编码1</param>
        /// <param name="strCode2">编码2</param>
        /// <param name="strCode3">编码3</param>
        private static void AquireCollectCode(FacilitySensorDeviceUnit fas, string strCode1, string strCode2,
            string strCode3)
        {
            var list = FacilitySensorDeviceUnit.FindAllByFacilityIdAndCollectDeviceId(fas.FacilityID,
                fas.SensorDeviceUnitID); //根据设施Id和采集设备Id查找设施采集设备
            if (list.Count > 0)
            {
                if (!list[0].Code1.EqualIgnoreCase())
                {
                    fas.Code1 = list[0].Code1; //编码1不动
                }
                else
                {
                    fas.Code1 = "";
                }
                //if (!list[0].Code2.EqualIgnoreCase())
                //{
                //    fas.Code2 = list[0].Code2;//编码2不动
                //}
                //else
                //{
                //    fas.Code2 = "";
                //}
                //if (!list[0].Code3.EqualIgnoreCase())
                //{
                //    fas.Code3 = list[0].Code3;//编码3不动
                //}
                //else
                //{
                //    fas.Code3 = "";
                //}
            }
            else
            {
                if (!strCode1.IsNullOrWhiteSpace())
                {
                    fas.Code1 = FacilitySensorDeviceUnit.GetCode1(fas.FacilityID);
                }
                if (!strCode2.IsNullOrWhiteSpace())
                {
                    fas.Code2 = FacilitySensorDeviceUnit.GetCode2(fas.FacilityID);
                }
                if (!strCode3.IsNullOrWhiteSpace())
                {
                    fas.Code3 = FacilitySensorDeviceUnit.GetCode3(fas.FacilityID);
                }
            }
        }

        /// <summary>
        /// 对设施控制设备编码进行更新
        /// </summary>
        /// <param name="fac">设施控制设备</param>
        /// <param name="strCode1">编码1</param>
        /// <param name="strCode2">编码2</param>
        /// <param name="strCode3">编码3</param>
        private static void AquireControlCode(FacilityControlDeviceUnit fac, string strCode1, string strCode2,
            string strCode3)
        {
            var list = FacilityControlDeviceUnit.FindAllByFacilityIdAndControlDeviceGroupNum(fac.FacilityID,
                fac.ControlDeviceUnitGroupNum); //根据设施Id和控制设备组号查找设施控制设备
            if (list.Count > 0)
            {
                if (!list[0].Code1.EqualIgnoreCase())
                {
                    fac.Code1 = list[0].Code1; //编码1不动
                }
                else
                {
                    fac.Code1 = "";
                }
                if (!list[0].Code2.EqualIgnoreCase())
                {
                    fac.Code2 = list[0].Code2; //编码2不动
                }
                else
                {
                    fac.Code2 = "";
                }
                if (!list[0].Code3.EqualIgnoreCase())
                {
                    fac.Code3 = list[0].Code3; //编码3不动
                }
                else
                {
                    fac.Code3 = "";
                }
            }
            else
            {
                if (!strCode1.IsNullOrWhiteSpace())
                {
                    fac.Code1 = FacilityControlDeviceUnit.GetCode1(fac.FacilityID);
                }
                if (!strCode2.IsNullOrWhiteSpace())
                {
                    fac.Code2 = FacilityControlDeviceUnit.GetCode2(fac.FacilityID);
                }
                if (!strCode3.IsNullOrWhiteSpace())
                {
                    fac.Code3 = FacilityControlDeviceUnit.GetCode3(fac.FacilityID);
                }
            }
        }

        /// <summary>
        /// 对设施摄像机设备编码进行更新
        /// </summary>
        /// <param name="fc">设施摄像机设备</param>
        /// <param name="strCode1">编码1</param>
        /// <param name="strCode2">编码2</param>
        /// <param name="strCode3">编码3</param>
        private static void AquireCameraCode(FacilityCamera fc, string strCode1, string strCode2, string strCode3)
        {
            var list = FacilityCamera.FindAllByFacilityIdAndCameraId(fc.FacilityID, fc.CameraID);
            //根据设施Id和控制设备Id查找设施摄像机设备
            if (list.Count > 0)
            {
                if (!list[0].Code1.EqualIgnoreCase())
                {
                    fc.Code1 = list[0].Code1; //编码1不动
                }
                else
                {
                    fc.Code1 = "";
                }
                if (!list[0].Code2.EqualIgnoreCase())
                {
                    fc.Code2 = list[0].Code2; //编码2不动
                }
                else
                {
                    fc.Code2 = "";
                }
                if (!list[0].Code3.EqualIgnoreCase())
                {
                    fc.Code3 = list[0].Code3; //编码3不动
                }
                else
                {
                    fc.Code3 = "";
                }
            }
            else
            {
                if (!strCode1.IsNullOrWhiteSpace())
                {
                    fc.Code1 = FacilityCamera.GetCode1(fc.FacilityID);
                }
                if (!strCode2.IsNullOrWhiteSpace())
                {
                    fc.Code2 = FacilityCamera.GetCode2(fc.FacilityID);
                }
                if (!strCode3.IsNullOrWhiteSpace())
                {
                    fc.Code3 = FacilityCamera.GetCode3(fc.FacilityID);
                }
            }
        }
    }
}