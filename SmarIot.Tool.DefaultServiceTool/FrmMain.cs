using SmartIot.Tool.Core.Common;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Tool.DefaultServiceTool.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using SmartIot.Tool.DefaultServiceTool.BaseConfig;
using SmartIot.Tool.DefaultServiceTool.Data;

namespace SmartIot.Tool.DefaultServiceTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //InitTreeView();//加载树结构
            //this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2; //消除子窗体在主窗体中系统自动添加的按钮
        }

        /// <summary>
        /// 加载树结构
        /// </summary>
        private void InitTreeView()
        {
            this.treeView1.Nodes.Clear();

            // 获取所有的设施列表
            List<Facility> facilityList = Facility.FindAll();
            if (facilityList.Count > 0 && facilityList.Any())
            {
                var firstNode = new TreeNode(facilityList[0].FarmName) {Tag = "FisrtPag"};
                this.treeView1.Nodes.Add(firstNode);

                foreach (var facility in facilityList)
                {
                    var allnode = new TreeNode(facility.Name) {ImageIndex = 0, Tag = facility};

                    //采集设备
                    var collectnode = new TreeNode("采集设备") {ImageIndex = 1, Tag = "SensorDeviceUnit"};
                    List<FacilitySensorDeviceUnit> sensorDeviceUnitList =
                        FacilitySensorDeviceUnit.FindAllByFacilityID(facility.ID);
                    if (sensorDeviceUnitList == null)
                    {
                        return;
                    }

                    foreach (var sensorDeviceUnit in sensorDeviceUnitList)
                    {
                        var treeNode =
                            new TreeNode(SensorDeviceUnit.FindByID(sensorDeviceUnit.SensorDeviceUnitID).Name.ToString());
                        treeNode.Tag = sensorDeviceUnit;
                        collectnode.Nodes.Add(treeNode);
                    }
                    allnode.Nodes.Add(collectnode);

                    //控制设备
                    var controlnode = new TreeNode("控制设备") {ImageIndex = 1, Tag = "ControlDeviceUnit"};
                    List<FacilityControlDeviceUnit> controlDeviceUnitList =
                        FacilityControlDeviceUnit.FindAllByFacilityID(facility.ID);
                    if (controlDeviceUnitList == null)
                    {
                        return;
                    }
                    foreach (var controlDeviceUnit in controlDeviceUnitList)
                    {
                        var treeNode =
                            new TreeNode(
                                ControlDeviceUnit.FindByGroupNum(controlDeviceUnit.ControlDeviceUnitGroupNum)[0].Name
                                    .ToString());
                        treeNode.Tag = controlDeviceUnit;
                        controlnode.Nodes.Add(treeNode);
                    }
                    allnode.Nodes.Add(controlnode);

                    ////摄像机设备
                    //var cameranode = new TreeNode("摄像机设备") { ImageIndex = 1, Tag = "facilityCamera" };
                    //List<FacilityCamera> cameraList = FacilityCamera.FindAllByFacilityID(facility.ID);
                    //if (cameraList == null)
                    //{
                    //    return;
                    //}

                    //foreach (FacilityCamera facilityCamera in cameraList)
                    //{
                    //    var treeNode = new TreeNode(facilityCamera.CameraName);
                    //    treeNode.Tag = facilityCamera;
                    //    cameranode.Nodes.Add(treeNode);
                    //}
                    //allnode.Nodes.Add(cameranode);

                    ////展示设备
                    //var showDevicenode = new TreeNode("显示设备") { ImageIndex = 1, Tag = "showDevice" };
                    //List<ShowDevice> showDeviceList = ShowDevice.FindAll();
                    //if (showDeviceList == null)
                    //{
                    //    return;
                    //}

                    //foreach (ShowDevice showDevice in showDeviceList)
                    //{
                    //    var treeNode = new TreeNode(showDevice.Name);
                    //    treeNode.Tag = showDevice;
                    //    showDevicenode.Nodes.Add(treeNode);
                    //}
                    //allnode.Nodes.Add(showDevicenode);
                    this.treeView1.Nodes.Add(allnode);
                }

                this.treeView1.ExpandAll();
            }
        }

        /// <summary>
        /// 点击树事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    if (e.Action != TreeViewAction.Unknown)
        //    {
        //        if (e.Node.Tag.ToString() == "communicateDevice")
        //        {
        //            FormHelper.CreateForm<FrmCommunicateDeviceConfig>();
        //        }
        //        else if (e.Node.Tag.ToString() == "sensorDeviceUnit")
        //        {
        //            FormHelper.CreateForm<FrmCollectDeviceConfig>();
        //        }
        //        else if (e.Node.Tag.ToString() == "controlDeviceUnit")
        //        {
        //            FormHelper.CreateForm<FrmControlDeviceConfig>();
        //        }
        //        else if (e.Node.Tag.ToString() == "facilityCamera")
        //        {
        //            FormHelper.CreateForm<FrmCameraConfig>();
        //        }
        //        else if (e.Node.Tag.ToString() == "showDevice")
        //        {
        //            FormHelper.CreateForm<FrmShowDeviceConfig>();
        //        }
        //    }
        //}
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //FormHelper.CreateForm<FrmSystemFunctionMap>();
            this.Text = Setting.Current.SystemName + "管理工具";
            //NewLife.Configuration.Config.GetConfig<String>("SystemName", "物联网监控系统设备管理工具");
            //this.Text = "智慧农业系统软件 V1.0";
            //toolStripStatusLabel3.Text = "铜陵县水产开发总公司";
            InitTreeView(); //加载树结构
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            //this.Text = SystemConfig.SystemName;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="id">
        /// </param>
        private void SearchDataInfo(int id, string tag)
        {
            this.listView1.Items.Clear();

            if (tag.EqualIgnoreCase("SensorDeviceUnit"))
            {
                string data;
                var fs = FacilitySensorDeviceUnit.FindByID(id);
                if (fs.SensorDeviceUnit.Sensor.Code.EqualIgnoreCase("collect-weather-YuXueGanZhi"))
                {
                    data = fs.SensorDeviceUnit.ProcessedValue == 1 ? "有" : "无";
                }
                else
                {
                    data = fs.SensorDeviceUnit.ProcessedValue.ToString();
                }

                var strings = new[]
                {
                    fs.Code1, fs.SensorDeviceUnit.Name, data, fs.SensorDeviceUnit.Sensor.Unit,
                    fs.SensorDeviceUnit.UpdateTime.ToString()
                };
                var listViewItem = new ListViewItem(strings);
                this.listView1.Items.Add(listViewItem);
            }
            else if (tag.EqualIgnoreCase("ControlDeviceUnit"))
            {
                string data;
                var controlList = ControlDeviceUnit.FindByGroupNum(id);
                if (controlList.Count > 0)
                {
                    controlList.ForEach(c =>
                    {
                        data = c.ProcessedValue;
                        var strings = new[]
                        {c.FacilityControlDeviceUnits[0].Code1, c.Name, data, "", c.UpdateTime.ToString()};
                        var listViewItem = new ListViewItem(strings);
                        this.listView1.Items.Add(listViewItem);
                    });
                }
            }

            var fsList = FacilitySensorDeviceUnit.FindAllByFacilityID(id);
            var fcList = FacilityControlDeviceUnit.FindAllByFacilityID(id);
            string data1;
            if (fsList.Count > 0)
            {
                fsList.ForEach(
                    fs =>
                    {
                        if (fs.SensorDeviceUnit.Sensor.Code.EqualIgnoreCase("collect-weather-YuXueGanZhi"))
                        {
                            data1 = fs.SensorDeviceUnit.ProcessedValue == 1 ? "有" : "无";
                        }
                        else
                        {
                            data1 = fs.SensorDeviceUnit.ProcessedValue.ToString();
                        }

                        var strings = new[]
                        {
                            fs.Code1, fs.SensorDeviceUnit.Name, data1, fs.SensorDeviceUnit.Sensor.Unit,
                            fs.SensorDeviceUnit.UpdateTime.ToString()
                        };
                        var listViewItem = new ListViewItem(strings);
                        this.listView1.Items.Add(listViewItem);
                    });
            }
            if (fcList.Count > 0)
            {
                fcList.ForEach(fc =>
                {
                    var controls = ControlDeviceUnit.FindByGroupNum(fc.ControlDeviceUnitGroupNum);
                    controls.ForEach(control =>
                    {
                        data1 = control.ProcessedValue;
                        var strings = new[] {fc.Code1, control.Name, data1, "", control.UpdateTime.ToString()};
                        var listViewItem = new ListViewItem(strings);
                        this.listView1.Items.Add(listViewItem);
                    });
                });
            }
        }

        /// <summary>
        /// 点击树事件
        /// </summary>
        /// <param name="sender">
        /// </param>
        /// <param name="e">
        /// </param>
        private void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Visible = true;
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Tag.ToString() == "FisrtPag")
                {
                    //    this.pFirst.Dock = DockStyle.Fill;
                    //    this.pFirst.Visible = true;
                    //    this.pldata.Visible = false;
                }
                else if (e.Node.Tag is Facility)
                {
                    // 基地 查询数据                   
                    //this.pldata.Visible = true;
                    //this.pldata.Dock = DockStyle.Fill;
                    //this.pFirst.Visible = false;
                    var facility = e.Node.Tag as Facility;
                    this.SearchDataInfo(facility.ID, "facility");
                }
                else if (e.Node.Tag is FacilitySensorDeviceUnit)
                {
                    // 基地 查询数据                   
                    //this.pldata.Visible = true;
                    //this.pldata.Dock = DockStyle.Fill;
                    //this.pFirst.Visible = false;
                    var collect = e.Node.Tag as FacilitySensorDeviceUnit;
                    this.SearchDataInfo(collect.ID, "SensorDeviceUnit");
                }
                else if (e.Node.Tag is FacilityControlDeviceUnit)
                {
                    // 基地 查询数据                   
                    //this.pldata.Visible = true;
                    //this.pldata.Dock = DockStyle.Fill;
                    //this.pFirst.Visible = false;
                    var control = e.Node.Tag as FacilityControlDeviceUnit;
                    this.SearchDataInfo(control.ControlDeviceUnitGroupNum, "ControlDeviceUnit");
                }
            }
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 基地管理toolStripButton1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmFarmEdit>();
            //BaseConfig.FrmFarmEdit frm = new BaseConfig.FrmFarmEdit();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 基地管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmFarmEdit>();
            //BaseConfig.FrmFarmEdit frm = new BaseConfig.FrmFarmEdit();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 设施管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmFacilityConfig>();
            //BaseConfig.FrmFacilityConfig frm = new BaseConfig.FrmFacilityConfig();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 设施类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmFacilityTypeConfig>();

            //BaseConfig.FrmFacilityTypeConfig frm = new BaseConfig.FrmFacilityTypeConfig();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 设备类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmDeviceTypeConfig>();

            //BaseConfig.FrmDeviceTypeConfig frm = new BaseConfig.FrmDeviceTypeConfig();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 数据协议类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmProtocalTypeConfig frm = new BaseConfig.FrmProtocalTypeConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmProtocalTypeConfig>();
        }

        private void 通讯设备类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //    BaseConfig.FrmCommunicateDeviceTypeConfig frm = new BaseConfig.FrmCommunicateDeviceTypeConfig();
            //    frm.MdiParent = this;
            //    frm.Show();
            FormHelper.CreateForm<FrmCommunicateDeviceTypeConfig>();
        }

        private void 展示设备类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FormShowDeviceTypeConfig frm = new BaseConfig.FormShowDeviceTypeConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FormShowDeviceTypeConfig>();
        }

        private void 设施管理toolStripButton6_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmFacilityTypeConfig frm = new BaseConfig.FrmFacilityConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmFacilityConfig>();
        }

        private void 摄像机管理toolStripButton7_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmCameraConfig frm = new BaseConfig.FrmCameraConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmCameraConfig>();
        }

        private void 设备异常数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            var frm = new FrmDeviceDataExceptionLog();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 设备分时数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            var frm = new FrmTimeSharingStatistics();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 设备历史数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            var frm = new FrmDeviceData();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 控制指令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            var frm = new FrmDeviceControlCommand();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 控制记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            var frm = new FrmDeviceControlLog();
            frm.MdiParent = this;
            frm.Show();
        }

        /// <summary>
        /// 打开计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        /// <summary>
        /// 打开记事本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            var frm = new FrmAbout();
            frm.MdiParent = this;
            frm.Show();
        }

        private void 设备运行参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmParmeterConfig>();
        }

        private void 预置点管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmCameraPresetPointConfig frm = new BaseConfig.FrmCameraPresetPointConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmCameraPresetPointConfig>();
        }

        private void 摄像机ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmCameraConfig frm = new BaseConfig.FrmCameraConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmCameraConfig>();
        }

        private void 数据显示配置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmShowDataConfig frm = new BaseConfig.FrmShowDataConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmShowDataConfig>();
        }

        private void 控制设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmControlDeviceConfig frm = new BaseConfig.FrmControlDeviceConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmControlDeviceConfig>();
        }

        private void 展示设备ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmShowDeviceConfig frm = new BaseConfig.FrmShowDeviceConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmShowDeviceConfig>();
        }

        private void 模块化设备ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmModularDeviceConfig frm = new BaseConfig.FrmModularDeviceConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmModularDeviceConfig>();
        }

        private void 通讯设备ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmCommunicateDeviceConfig frm = new BaseConfig.FrmCommunicateDeviceConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmCommunicateDeviceConfig>();
        }

        private void 采集设备ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmCollectDeviceConfig>();
            //BaseConfig.FrmCollectDeviceConfig frm = new BaseConfig.FrmCollectDeviceConfig();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 传感器编辑toolStripButton3_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmSensorConfig>();

            //BaseConfig.FrmSensorConfig frm = new BaseConfig.FrmSensorConfig();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void 采集设备toolStripButton2_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmModularDeviceConfig frm = new BaseConfig.FrmCollectDeviceConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmCollectDeviceConfig>();
        }

        private void 控制设备管理toolStripButton5_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            //BaseConfig.FrmDeviceTypeConfig frm = new BaseConfig.FrmControlDeviceConfig();
            //frm.MdiParent = this;
            //frm.Show();
            FormHelper.CreateForm<FrmControlDeviceConfig>();
        }

        private void 系统参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            FormHelper.CreateForm<FrmSetting>();
        }

        private void 配置向导_Click(object sender, EventArgs e)
        { 
                listView1.Visible = false;
                //BaseConfig.FrmCommunicateDeviceConfig frm = new BaseConfig.FrmCommunicateDeviceConfig();
                //frm.MdiParent = this;
                //frm.Show();
                FormHelper.CreateForm<FrmCommunicateDeviceConfig>();

         

        }



    }
}