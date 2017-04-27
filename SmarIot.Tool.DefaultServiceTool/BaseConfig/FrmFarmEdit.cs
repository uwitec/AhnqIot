using SmartIot.Tool.DefaultService.DB;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.BaseConfig
{
    public partial class FrmFarmEdit : Form
    {
        private int farmId;

        public FrmFarmEdit()
        {
            InitializeComponent();
            InitFacilityListView(); //初始化设施列表
            this.farmId = 0;
            InitList();
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
        /// 绑定基地列表
        /// </summary>
        public void InitList()
        {
            this.lstFarm.Items.Clear();
            List<Farm> farmList = Farm.FindAll();
            foreach (var farm in farmList)
            {
                var strings = new[]
                {
                    farm.ID.ToString(), farm.Code1, farm.Code2, farm.Code3, farm.Name, farm.CompanySerialnum,
                    farm.Address, farm.PhotoUrl, farm.Lotitude, farm.Latitude, farm.Area.ToString(), farm.ContactMan,
                    farm.ContactMobile, farm.ContactPhone, farm.Status.ToString(), farm.CreateTime.ToString(),
                    farm.UpdateTime.ToString(), farm.APIKey, farm.Upload.ToString(), farm.Version.ToString(),
                    farm.Introduce, farm.Remark
                };

                var listView = new ListViewItem(strings);
                listView.Tag = farm;
                this.lstFarm.Items.Add(listView);
            }
        }

        /// <summary>
        /// 初始化设施列表
        /// </summary>
        private void InitFacilityListView()
        {
            this.lstFacility.Items.Clear();
            List<Facility> facilityList = Facility.FindAll();
            foreach (var facility in facilityList)
            {
                var strings = new string[] {facility.Name, facility.FarmName, facility.FacilityTypeName};
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = facility;
                this.lstFacility.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // if (this.lstFarm.SelectedItems.Count == 0) return;

            if (this.txtName.Text.Trim().Equals(""))
            {
                MessageBox.Show("名称不能为空,请输入");
                this.txtName.Focus();
                return;
            }

            //if (this.txtCode1.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("编码1不能为空,请输入");
            //    this.txtName.Focus();
            //    return;
            //}
            //if (this.txtCode2.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("编码2不能为空,请输入");
            //    this.txtName.Focus();
            //    return;
            //}
            //if (this.txtCode3.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("编码3不能为空,请输入");
            //    this.txtName.Focus();
            //    return;
            //}
            //if (this.txtCompanySerialNum.Text.Trim().Equals(""))
            //{
            //    MessageBox.Show("公司不能为空,请输入");
            //    this.txtName.Focus();
            //    return;
            //}
            //List<Facility> facilityList = (from item in this.lstFacility.Items.Cast<ListViewItem>() where item.Checked select item.Tag as Facility).ToList();//设施列表

            if (this.farmId != 0)
            {
                try
                {
                    #region 更新基地

                    var farm = Farm.FindByID(this.farmId);
                    if (farm == null)
                    {
                        farm = new Farm();
                        farm.Code1 = this.txtCode1.Text;
                    }

                    farm.Code1 = this.txtCode1.Text.Trim();
                    farm.Code2 = this.txtCode2.Text.Trim();
                    farm.Code3 = this.txtCode3.Text.Trim();
                    farm.Name = this.txtName.Text.Trim();
                    farm.CompanySerialnum = this.txtCompanySerialNum.Text.Trim();
                    farm.Address = this.txtAddress.Text.Trim();
                    //PhotoUrl = this.pbPhotoUrl.Text,
                    farm.Lotitude = this.txtLotitude.Text;
                    farm.Latitude = this.txtLatitude.Text;
                    farm.Area = Convert.ToInt32(this.txtArea.Text.Trim());
                    farm.ContactMan = this.txtContactMan.Text.Trim();
                    farm.ContactPhone = this.txtContactPhone.Text.Trim();
                    farm.ContactMobile = this.txtContactMobile.Text.Trim();
                    //Status = Convert.ToBoolean(this.cbStatus.SelectedValue),
                    farm.Status = this.rbtOnlineStatus.Checked;
                    //CreateTime = this.dtCreateTime.Value,
                    farm.UpdateTime = Convert.ToDateTime(DateTime.Now.ToString("G"));
                    farm.APIKey = this.txtAPIKey.Text;
                    //Upload = Convert.ToBoolean(this.cbUpLoad.SelectedValue),
                    //Upload=this.rbtUpLoad.Checked,
                    //Version = Convert.ToInt32(this.txtVersion.Text),
                    ////Introduce = this.lstIntroduce.Text,
                    farm.Remark = this.txtPwd.Text;

                    farm.Save();
                    this.farmId = farm.ID;

                    #endregion 更新基地

                    //MessageBox.Show("更新成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("更新失败");
                    return;
                }
            }
            else
            {
                try
                {
                    // 保存
                    var farm = new Farm();

                    farm.Code1 = this.txtCode1.Text.Trim();
                    farm.Code2 = this.txtCode2.Text.Trim();
                    farm.Code3 = this.txtCode3.Text.Trim();
                    farm.Name = this.txtName.Text.Trim();
                    farm.CompanySerialnum = this.txtCompanySerialNum.Text.Trim();
                    farm.Address = this.txtAddress.Text.Trim();
                    //PhotoUrl = this.pbPhotoUrl.Text,
                    farm.Lotitude = this.txtLotitude.Text;
                    farm.Latitude = this.txtLatitude.Text;
                    farm.Area = Convert.ToInt32(this.txtArea.Text.Trim());
                    farm.ContactMan = this.txtContactMan.Text.Trim();
                    farm.ContactPhone = this.txtContactPhone.Text.Trim();
                    farm.ContactMobile = this.txtContactMobile.Text.Trim();
                    //Status = Convert.ToBoolean(this.cbStatus.SelectedValue),
                    farm.Status = this.rbtOnlineStatus.Checked;
                    //CreateTime = this.dtCreateTime.Value,
                    farm.UpdateTime = Convert.ToDateTime(DateTime.Now.ToString("G"));
                    farm.APIKey = this.txtAPIKey.Text;
                    //Upload = Convert.ToBoolean(this.cbUpLoad.SelectedValue),
                    //Upload=this.rbtUpLoad.Checked,
                    //Version = Convert.ToInt32(this.txtVersion.Text),
                    ////Introduce = this.lstIntroduce.Text,
                    farm.Remark = this.txtPwd.Text;

                    farm.Save();
                    this.farmId = farm.ID;
                    //this.InitFacilityListView();
                    //MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                    MessageBox.Show("新增失败");
                    return;
                }
            }

            try
            {
                var facilityListChecked = new List<Facility>();
                var facilityListUnchecked = new List<Facility>();
                foreach (ListViewItem item in this.lstFacility.Items)
                {
                    if (item.Checked == false)
                    {
                        var facility = item.Tag as Facility; //设施
                        facilityListUnchecked.Add(facility);
                    }
                    else
                    {
                        //facilityListChecked = (from i in this.lstFacility.Items.Cast<ListViewItem>() where i.Checked select i.Tag as Facility).ToList();//显示数据
                        foreach (ListViewItem lvi in lstFacility.Items)
                        {
                            if (lvi.Checked)
                                facilityListChecked.Add(lvi.Tag as Facility);
                        }
                    }
                }

                var farm = Farm.FindByID(farmId);

                //未选中的设施不能删除，只删除编码
                foreach (var item in facilityListUnchecked)
                {
                    if (item.FarmID == this.farmId)
                    {
                        item.Code1 = "";
                        item.FarmID = 0;
                        item.Update();
                        //删除映射关系
                        item.FacilitySensorDeviceUnits.Delete(true);
                        item.FacilityControlDeviceUnits.Delete(true);
                        item.FacilityCameras.Delete(true);
                    }
                }

                //更新基地设施
                foreach (var item in facilityListChecked)
                {
                    #region 更新设施

                    //Facility fac = new Facility();
                    //fac.ID = item.ID;
                    //fac.FarmID = this.farmId;
                    var fac = Facility.FindByID(item.ID);
                    fac.FarmID = farm.ID;
                    if (this.txtCode1.Text.IsNullOrWhiteSpace())
                    {
                        fac.Code1 = "";
                    }
                    else if (!this.txtCode1.Text.IsNullOrWhiteSpace() && !(fac.Code1 + "").StartsWith(farm.Code1))
                    {
                        fac.Code1 = fac.GetCode1();
                    }
                    fac.Update();

                    #endregion 更新设施

                    #region 设施下的采集设备的更新

                    IEnumerable<FacilitySensorDeviceUnit> facilitySensorDeviceUnits =
                        FacilitySensorDeviceUnit.FindAllByFacilityID(fac.ID).ToList().OrderBy(fas => fas.ID);
                    if (facilitySensorDeviceUnits.Count() > 0)
                    {
                        foreach (var fas in facilitySensorDeviceUnits)
                        {
                            if (fac.Code1.IsNullOrWhiteSpace())
                            {
                                fas.Code1 = "";
                            }
                            else if (!fac.Code1.IsNullOrWhiteSpace() && !(fas.Code1 + "").StartsWith(fac.Code1))
                            {
                                //XTrace.WriteLine("-->" + fas.Code1 + " -- " + fas.GetCode1());
                                fas.Code1 = fas.GetCode1();
                                //XTrace.WriteLine("<--" + fas.Code1);
                            }
                            fas.Save();
                        }
                    }

                    #endregion 设施下的采集设备的更新

                    #region 设施下的控制设备的更新

                    IEnumerable<FacilityControlDeviceUnit> facilityControlDeviceUnits =
                        FacilityControlDeviceUnit.FindAllByFacilityID(fac.ID).ToList().OrderBy(fas => fas.ID);
                    if (facilityControlDeviceUnits.Count() > 0)
                    {
                        foreach (var fas in facilityControlDeviceUnits)
                        {
                            if (fac.Code1.IsNullOrWhiteSpace())
                            {
                                fas.Code1 = "";
                            }
                            else if (!fac.Code1.IsNullOrWhiteSpace() && !(fas.Code1 + "").StartsWith(fac.Code1))
                            {
                                fas.Code1 = fas.GetCode1();
                            }
                            fas.Update();
                        }
                    }

                    #endregion 设施下的控制设备的更新

                    #region 设施下的摄像机设备的更新

                    IEnumerable<FacilityCamera> facilityCameras =
                        FacilityCamera.FindAllByFacilityID(fac.ID).ToList().OrderBy(fas => fas.ID);
                    if (facilityCameras.Count() > 0)
                    {
                        foreach (var fas in facilityCameras)
                        {
                            if (fac.Code1.IsNullOrWhiteSpace())
                            {
                                fas.Code1 = "";
                            }
                            else if (!fac.Code1.IsNullOrWhiteSpace() && !(fas.Code1 + "").StartsWith(fac.Code1))
                            {
                                fas.Code1 = fas.GetCode1();
                            }
                            fas.Update();
                        }
                    }

                    #endregion 设施下的摄像机设备的更新
                }

                this.InitFacilityListView();
                this.InitList();
                MessageBox.Show("操作成功");
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                MessageBox.Show("更新设备编码失败");
                return;
            }
            this.farmId = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.farmId = 0;
            this.txtName.Clear();
            this.txtCode1.Clear();
            this.txtCode2.Clear();
            this.txtCode3.Clear();
            //this.txtID.Clear();
            this.txtCompanySerialNum.Clear();
            this.txtAddress.Clear();
            //this.pbPhotoUrl.Image=null;
            this.txtLotitude.Clear();
            this.txtLatitude.Clear();
            this.txtArea.Clear();
            this.txtContactMan.Clear();
            this.txtContactPhone.Clear();
            this.txtContactMobile.Clear();
            //this.cbStatus.SelectedIndex=-1;
            //this.rbtUpLoad.Checked = false;
            //this.rbtUpLoad1.Checked = true;
            this.txtAPIKey.Clear();
            //this.cbUpLoad.SelectedIndex=-1;
            this.rbtOnlineStatus.Checked = false;
            //this.rbtOnlineStatus1.Checked = true;
            //this.txtVersion.Clear();
            ////this.lstIntroduce.Items.Clear();
            this.txtPwd.Clear();
        }

        private void lstFarm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstFarm.SelectedItems.Count > 0)
            {
                if (this.lstFarm.SelectedItems[0].Tag is Farm)
                {
                    this.farmId = (this.lstFarm.SelectedItems[0].Tag as Farm).ID;
                    //this.txtID.Text = (this.lstFarm.SelectedItems[0].Tag as Farm).ID.ToString();
                    this.txtCode1.Text = this.lstFarm.SelectedItems[0].SubItems[1].Text;
                    this.txtCode2.Text = this.lstFarm.SelectedItems[0].SubItems[2].Text;
                    this.txtCode3.Text = this.lstFarm.SelectedItems[0].SubItems[3].Text;
                    this.txtName.Text = this.lstFarm.SelectedItems[0].SubItems[4].Text;
                    this.txtCompanySerialNum.Text = this.lstFarm.SelectedItems[0].SubItems[5].Text;
                    this.txtAddress.Text = this.lstFarm.SelectedItems[0].SubItems[6].Text;
                    //this.pbPhotoUrl.Text = this.lstFarm.SelectedItems[0].SubItems[7].Text;
                    this.txtLotitude.Text = this.lstFarm.SelectedItems[0].SubItems[8].Text;
                    this.txtLatitude.Text = this.lstFarm.SelectedItems[0].SubItems[9].Text;
                    this.txtArea.Text = this.lstFarm.SelectedItems[0].SubItems[10].Text;
                    this.txtContactMan.Text = this.lstFarm.SelectedItems[0].SubItems[11].Text;
                    this.txtContactPhone.Text = this.lstFarm.SelectedItems[0].SubItems[12].Text;
                    this.txtContactMobile.Text = this.lstFarm.SelectedItems[0].SubItems[13].Text;
                    //this.cbStatus.Text = this.lstFarm.SelectedItems[0].SubItems[14].Text;
                    this.rbtOnlineStatus.Checked = Convert.ToBoolean(this.lstFarm.SelectedItems[0].SubItems[14].Text);
                    //if (this.rbtOnlineStatus.Checked == true)
                    //{
                    //    this.rbtOnlineStatus1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtOnlineStatus1.Checked = true;
                    //}
                    //this.dtCreateTime.Value =Convert.ToDateTime(this.lstFarm.SelectedItems[0].SubItems[15].Text);
                    //this.txtUpdateTime.Text = this.lstFarm.SelectedItems[0].SubItems[16].Text;
                    this.txtAPIKey.Text = this.lstFarm.SelectedItems[0].SubItems[17].Text;
                    //this.cbUpLoad.Text = this.lstFarm.SelectedItems[0].SubItems[18].Text;
                    //this.rbtUpLoad.Checked = Convert.ToBoolean(this.lstFarm.SelectedItems[0].SubItems[18].Text);
                    //if (this.rbtUpLoad.Checked == true)
                    //{
                    //    this.rbtUpLoad1.Checked = false;
                    //}
                    //else
                    //{
                    //    this.rbtUpLoad1.Checked = true;
                    ////}
                    //this.txtVersion.Text = this.lstFarm.SelectedItems[0].SubItems[19].Text;
                    ////this.lstIntroduce.Text = this.lstFarm.SelectedItems[0].SubItems[20].Text;
                    this.txtPwd.Text = this.lstFarm.SelectedItems[0].SubItems[21].Text;

                    //设施列表的改变事件
                    List<Facility> facilityList =
                        Facility.FindAllByFarmID((this.lstFarm.SelectedItems[0].Tag as Farm).ID);
                    //foreach (Facility f in facilityList)
                    //{
                    if (facilityList == null || facilityList.Count == 0)
                    {
                        foreach (ListViewItem item in this.lstFacility.Items)
                        {
                            item.Checked = false;
                        }

                        //return;
                    }
                    else
                    {
                        foreach (ListViewItem item in this.lstFacility.Items)
                        {
                            var isExists = false;
                            foreach (var fac in facilityList)
                            {
                                var facility = item.Tag as Facility;
                                if (facility != null)
                                {
                                    if (facility.ID == fac.ID)
                                    {
                                        isExists = true;
                                    }
                                }
                            }

                            item.Checked = isExists;
                        }
                    }
                    //}
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstFarm.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该基地？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该基地吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.lstFarm.SelectedItems[0].Tag is Farm)
                    {
                        var farm = this.lstFarm.SelectedItems[0].Tag as Farm;
                        //int id = farm.ID;
                        //List<Facility> facilityList = Facility.FindAllByFarmID(id);
                        //if (facilityList != null)
                        //{
                        //    MessageBox.Show("该基地已经在使用，不能删除");
                        //    return;
                        //}
                        //Farm.Delete(farm);
                        farm.Delete();
                        this.InitList();
                        this.farmId = 0;
                    }
                }
            }
        }

        private void lstFarm_MouseClick(object sender, MouseEventArgs e)
        {
            //鼠标右击才会触发contextMenuStrip控件，并且contextMenuStrip控件只在listview控件中有数据的时候才有效，这样就固定范围
            if (e.Button == MouseButtons.Right && lstFarm.SelectedItems.Count == 1)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }
    }
}