using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using SmartIot.Tool.DefaultService.DB;
using SmartIot.Tool.DefaultService.DB.Common;
using XCode;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using SmartIot.ConfigTool.Wizard;
using AutoMapper;
using SmartIot.ConfigTool.Model;

namespace SmartIot.ConfigTool
{
    public partial class MainFrm : MetroForm
    {
        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
        #region  Properity
        private static int _farmId;
        private PropertySettings _AntiAliasPropertySetting = null;
        private Tuple<IEntity> selectObj;//object node selected
        private int dragId = 0;
        private int facId = 0;
        //private IEntity dragObj = null;
        private bool status = false;
        private object parent = null;
        #endregion

        public MainFrm()
        {
            InitializeComponent();

            #region add properitygrid
            // Customize AntiAlias property appearance
            _AntiAliasPropertySetting = new PropertySettings("AntiAlias"); // Specifies that this setting is attached to AntiAlias property
            _AntiAliasPropertySetting.Description = "This is custom description, help text, for the AntiAlias property";
            _AntiAliasPropertySetting.DisplayName = "AntiAliasCustomName"; // Change property name that is displayed in property grid
            // Create new visual style for property
            ElementStyle style = new ElementStyle();
            style.BackColor = Color.WhiteSmoke;
            style.BackColor2 = Color.LightGoldenrodYellow;
            style.BackColorGradientAngle = 90;
            style.TextColor = Color.Brown;
            _AntiAliasPropertySetting.Style = style;

            // Adds property setting to the grid
            advPropertyGrid1.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            // Create new button item
            //ButtonItem button = new ButtonItem("helpPanel", "帮助");
            //button.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button.OptionGroup = "helpPanel"; // This will automatically manage the Check property so only one button in group is checked
            //button.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid1.Toolbar.Items.Add(button);
            advPropertyGrid1.HelpType = ePropertyGridHelpType.Panel;

            // Create save button item
            ButtonItem btnSave = new ButtonItem("btnSave", "保  存");
            btnSave.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave.OptionGroup = "helpPanel"; // This will automatically manage the Check property so only one button in group is checked
            btnSave.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave.Click += new EventHandler(btnSave_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid1.Toolbar.Items.Add(btnSave);


            // Create second button
            //button = new ButtonItem("helpTooltip", "SuperTooltip Help");
            //button.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button.OptionGroup = "helpPanel";
            //button.Checked = true; // This is default value
            //button.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //advPropertyGrid1.Toolbar.Items.Add(button);

            // Apply layout changes so items become visible
            advPropertyGrid1.Toolbar.RecalcLayout();
            #endregion
        }

        #region 服务监控
        /// <summary>
        /// 服务监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonItem28_Click(object sender, EventArgs e)
        {

            RadialMenuContainer menuContainer = null;
            if (buttonItem28.SubItems.Count == 0)
            {
                // RadialMenuContainer is used as host for RadialMenu when its being added to Bar
                menuContainer = new RadialMenuContainer();
                menuContainer.MaxItemPieAngle = 180;
                menuContainer.MaxItemRadialAngle = 0;
                menuContainer.Font = new Font(this.Font.FontFamily, 7);
                menuContainer.SubItems.Add(CreateItem("关闭", "\uf011"));
                menuContainer.SubItems.Add(CreateItem("开启", "\uf0ca"));
                menuContainer.SubItems.Add(CreateItem("停止", "\uf0ef"));
                menuContainer.SubItems.Add(CreateItem("", "")); // Spacer item does not have anything set
                menuContainer.Diameter = 200;
                buttonItem1.SubItems.Add(menuContainer); // Must add it to button to enable menu to be hidden when user clicks-out or app loses focus
                menuContainer.SubItems[0].Click += new EventHandler(ServiceCloseClick);
                menuContainer.SubItems[0].Click += new EventHandler(ServiceStartClick);
                menuContainer.SubItems[0].Click += new EventHandler(ServiceStopClick);
            }
            else
                menuContainer = (RadialMenuContainer)buttonItem28.SubItems[0];
            // Menu will use custom location and it will be centered on mouse cursor
            menuContainer.MenuLocation = new Point(Control.MousePosition.X - menuContainer.Diameter / 2, Control.MousePosition.Y - menuContainer.Diameter / 2);

            // Open the menu
            menuContainer.Expanded = true;
        }
        private BaseItem CreateItem(string text, string symbol)
        {
            RadialMenuItem item = new RadialMenuItem();
            item.Text = text;
            item.Symbol = symbol;
            return item;
        }
        /// <summary>
        /// //关闭服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceCloseClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// //打开服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceStartClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// //停止服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServiceStopClick(object sender, EventArgs e)
        {

        }
        #endregion


        private void MainFrm_Load(object sender, EventArgs e)
        {
            //加载基地
            InitFarm();
            //加载数据
            InitData();


        }

        #region 基地加载
        /// <summary>
        /// 加载基地
        /// </summary>
        public void InitFarm()
        {
            var farms = Farm.FindAll();
            if (farms.Count == 1 && farms != null)
            {
                dockContainerItem7.Text = farms[0].Name;
                _farmId = farms[0].ID;
            }
            else if (farms.Count == 2 && farms != null)
            {
                foreach (var farm in farms)
                {
                    _farmId = farm.ID;
                    CreateDockContainerItem(farm.Name, farm.Name);
                }
            }


        }
        /// <summary>
        /// 创建DockContainerItem(只考虑一个基地的情况)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        private DockContainerItem CreateDockContainerItem(string name, string text)
        {
            var dockItem = new DockContainerItem();
            //dockItem.Control = this.pa;
            dockItem.Name = name;
            dockItem.Text = text;
            this.bar5.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            dockItem});
            return dockItem;
        }
        #endregion

        #region 实时数据
        private void InitData()
        {
            var facs = Facility.FindAllByFarmID(_farmId);
            if (facs != null && facs.Count > 0)
            {
                foreach (var fac in facs)
                {
                    var facnode = new DevComponents.AdvTree.Node("设施")
                    {
                        ImageIndex = 0,
                        Tag = fac,
                        //TagString="Facility",
                        Expanded = true,
                        Name = fac.Name,
                        Text = fac.Name
                    };
                    this.advTreeData.Nodes.AddRange(new DevComponents.AdvTree.Node[] { facnode });

                    var collectnode = new DevComponents.AdvTree.Node("采集设备") { ImageIndex = 1, Tag = "SensorDeviceUnit" };
                    var collects = fac.FacilitySensorDeviceUnits;
                    if (collects != null && collects.Count > 0)
                    {
                        foreach (var c in collects)
                        {
                            var cnode = new DevComponents.AdvTree.Node
                            {
                                Expanded = true,
                                Name = c.SensorDeviceUnit.Name,
                                Text = c.SensorDeviceUnit.Name,
                                Tag = c.SensorDeviceUnit,
                                //TagString = "SensorDeviceUnit"
                            };
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = c.SensorDeviceUnit.ProcessedValue.ToString(), Name = c.SensorDeviceUnit.ProcessedValue.ToString() });
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = c.SensorDeviceUnit.Sensor.Unit, Name = c.SensorDeviceUnit.Sensor.Unit });
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = c.SensorDeviceUnit.UpdateTime.ToString(), Name = c.SensorDeviceUnit.UpdateTime.ToString() });
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = c.Code1, Name = c.Code1 });
                            collectnode.Nodes.Add(cnode);
                        }
                    }
                    facnode.Nodes.Add(collectnode);

                    var controlnode = new DevComponents.AdvTree.Node("控制设备") { ImageIndex = 2, Tag = "ControlDeviceUnit" };
                    var fcontrols = fac.FacilityControlDeviceUnits;
                    if (fcontrols != null && fcontrols.Count > 0)
                    {
                        foreach (var fc in fcontrols)
                        {
                            ControlDeviceUnit.FindByGroupNum(fc.ControlDeviceUnitGroupNum).ForEach(control =>
                            {

                                var cnode = new DevComponents.AdvTree.Node
                                {
                                    Expanded = true,
                                    Name = control.Name,
                                    Text = control.Name,
                                    Tag = control,
                                    //TagString = "ControlDeviceUnit"
                                };
                                cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = control.ProcessedValue.ToString(), Name = control.ProcessedValue.ToString() });
                                cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = " ", Name = " " });
                                cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = control.UpdateTime.ToString(), Name = control.UpdateTime.ToString() });
                                cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = fc.Code1, Name = fc.Code1 });
                                controlnode.Nodes.Add(cnode);
                            });

                        }
                    }
                    facnode.Nodes.Add(controlnode);

                    var cameranode = new DevComponents.AdvTree.Node("视频设备") { ImageIndex = 3, Tag = "Camera" };
                    var cameras = fac.FacilityCameras;
                    if (cameras != null && cameras.Count > 0)
                    {
                        foreach (var c in cameras)
                        {
                            var cnode = new DevComponents.AdvTree.Node
                            {
                                Expanded = true,
                                Name = c.Camera.Name,
                                Text = c.Camera.Name,
                                Tag = c.Camera,
                                //TagString = "Camera"
                            };
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = "正常", Name = "正常" });
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = "", Name = "" });
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = c.UpdateTime.ToString(), Name = c.UpdateTime.ToString() });
                            cnode.Cells.Add(new DevComponents.AdvTree.Cell { Text = c.Code1, Name = c.Code1 });
                            cameranode.Nodes.Add(cnode);
                        }
                    }
                    facnode.Nodes.Add(cameranode);

                    var shownode = new DevComponents.AdvTree.Node("展示设备") { ImageIndex = 4, Tag = "ShowDevice" };
                    var shows = ShowDevice.FindAll();
                    if (shows != null && shows.Count > 0)
                    {
                        foreach (var s in shows)
                        {
                            var cnode = new DevComponents.AdvTree.Node
                            {
                                Expanded = true,
                                Name = s.Name,
                                Text = s.Name,
                                Tag = s,
                                //TagString = "ShowDevice"
                            };
                            shownode.Nodes.Add(cnode);
                        }
                    }
                    facnode.Nodes.Add(shownode);
                }
            }
        }
        #endregion

        #region 获取节点数据
        private void advTreeData_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (!status)
            {
                if (e.Node.Tag is SensorDeviceUnit)
                {
                    var collect = e.Node.Tag as SensorDeviceUnit;
                    this.GetProperity(collect.ID, "SensorDeviceUnit");
                }
                else if (e.Node.Tag is ControlDeviceUnit)
                {
                    var control = e.Node.Tag as ControlDeviceUnit;
                    this.GetProperity(control.ID, "ControlDeviceUnit");
                }
                else if (e.Node.Tag is Camera)
                {
                    var cam = e.Node.Tag as Camera;
                    this.GetProperity(cam.ID, "Camera");
                }
                else if (e.Node.Tag is ShowDevice)
                {
                    var sd = e.Node.Tag as ShowDevice;
                    this.GetProperity(sd.ID, "ShowDevice");
                }
                else if (e.Node.Tag is Facility)
                {
                    var f = e.Node.Tag as Facility;
                    this.GetProperity(f.ID, "Facility");
                }
            }
        }
        /// <summary>
        /// 获取节点属性
        /// </summary>
        /// <param name="id">
        /// </param>
        private void GetProperity(int id, string tag)
        {
            //this.advPropertyGrid1.SelectedObject = null;

            if (tag.Equals("SensorDeviceUnit"))
            {
                var s = SensorDeviceUnit.FindByID(id);
                s.ModularDevices = s.ModularDeviceName;
                s.Sensors = s.SensorName;

                this.advPropertyGrid1.SelectedObject = Mapper.Map<SensorDeviceUnitDto>(s);
                selectObj = new Tuple<IEntity>(s);
                //var sensor = Sensor.FindByID(s.SensorId);
                //PropertyHandle.SetPropertyReadOnly(s,"Remark", true);
            }
            else if (tag.Equals("ControlDeviceUnit"))
            {
                var c = ControlDeviceUnit.FindByID(id);
                c.ModularDevices = c.ModularDeviceName;
                c.DeviceTypes = c.DeviceTypeName;
                c.ControlJobTypes = c.ControlJobTypeName;
                c.RelayTypes = c.RelayTypeName;
                this.advPropertyGrid1.SelectedObject = Mapper.Map<ControlDeviceUnitDto>(c); 
                selectObj = new Tuple<IEntity>(c);
            }
            else if (tag.Equals("Camera"))
            {
                var c = Camera.FindByID(id);
                this.advPropertyGrid1.SelectedObject = Mapper.Map<CameraDto>(c);
                selectObj = new Tuple<IEntity>(c);
            }
            else if (tag.Equals("ShowDevice"))
            {
                var sd = ShowDevice.FindByID(id);
                sd.ShowDeviceTypes = sd.ShowDeviceTypeName;
                sd.CommunicateDevices = sd.CommunicateDeviceName;
                this.advPropertyGrid1.SelectedObject = Mapper.Map<ShowDeviceDto>(sd); ;
                selectObj = new Tuple<IEntity>(sd);
            }

            else if (tag.Equals("Facility"))
            {
                var fac = Facility.FindByID(id);
                fac.Farms = fac.FarmName;
                fac.FacilityTypes = fac.FacilityTypeName;
                this.advPropertyGrid1.SelectedObject = Mapper.Map<FacilityDto>(fac); ;
                selectObj = new Tuple<IEntity>(fac);
            }





        }
        #endregion

        #region propertygrid效果
        private void ButtonOptionGroupChanging(object sender, OptionGroupChangingEventArgs e)
        {
            if (e.NewChecked.Name == "helpPanel")
                advPropertyGrid1.HelpType = ePropertyGridHelpType.Panel;
            else
                advPropertyGrid1.HelpType = ePropertyGridHelpType.SuperTooltip;
        }
        #endregion

        #region update

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectObj.Item1.Update();
            //advPropertyGrid1.Refresh();
        }
        private void advPropertyGrid1_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {
            //var item = GetObjAndField(e.PropertyPath);
            //var obj= item.Item1;
            //var propertyName = item.Item2;
            if (e.PropertyName.EqualIgnoreCase("ModularDevices"))
            {
                var ModularDeviceID = ModularDevice.FindAllByName(e.NewValue.ToString())[0].ID;
                selectObj.Item1.SetItem("ModularDeviceID", ModularDeviceID);
            }
            else if (e.PropertyName.EqualIgnoreCase("Sensors"))
            {
                var SensorId = Sensor.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                selectObj.Item1.SetItem("SensorId", SensorId);
            }
            else if (e.PropertyName.EqualIgnoreCase("ControlJobTypes"))
            {
                var ControlJobTypeId = ControlJobType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Id;
                selectObj.Item1.SetItem("ControlJobTypeId", ControlJobTypeId);
            }
            else if (e.PropertyName.EqualIgnoreCase("RelayTypes"))
            {
                var RelayTypeId = RelayType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Id;
                selectObj.Item1.SetItem("RelayTypeId", RelayTypeId);
            }
            else if (e.PropertyName.EqualIgnoreCase("DeviceTypes"))
            {
                var DeviceTypeSerialnum = DeviceType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Serialnum;
                selectObj.Item1.SetItem("DeviceTypeSerialnum", DeviceTypeSerialnum);
            }

            else if (e.PropertyName.EqualIgnoreCase("ShowDeviceTypes"))
            {
                var ShowDeviceTypeID = ShowDeviceType.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                selectObj.Item1.SetItem("ShowDeviceTypeID", ShowDeviceTypeID);
            }
            else if (e.PropertyName.EqualIgnoreCase("CommunicateDevices"))
            {
                var CommunicateDeviceID = CommunicateDevice.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                selectObj.Item1.SetItem("CommunicateDeviceID", CommunicateDeviceID);
            }
            else if (e.PropertyName.EqualIgnoreCase("Farms"))
            {
                var FarmID = Farm.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                selectObj.Item1.SetItem("FarmID", FarmID);
            }
            else if (e.PropertyName.EqualIgnoreCase("FacilityTypes"))
            {
                var FacilityTypeSerialnum = FacilityType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Serialnum;
                selectObj.Item1.SetItem("FacilityTypeSerialnum", FacilityTypeSerialnum);
            }
            else
            {
                selectObj.Item1.SetItem(e.PropertyName, e.NewValue);
            }


        }

        public Tuple<object, string> GetObjAndField(string propertyPath)
        {
            var property = propertyPath.Split('.');
            if (property.Length > 1)
            {
                var systemFolder = Application.StartupPath;
                var strTempAssmbPath = System.IO.Path.Combine(systemFolder, "SmartIot.Tool.DefaultService.DB.dll");
                var obj = CreateObject(strTempAssmbPath, property[property.Length - 2]);
                return new Tuple<object, string>(obj, property[property.Length - 1]);
            }
            return null;
        }

        /// <summary>
        /// 创建对象(外部程序集)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="typeName">类型名</param>
        /// <returns>创建的对象，失败返回 null</returns>
        public static object CreateObject(string path, string typeName)
        {
            object obj = null;
            try
            {
                //Type objType = Type.GetType(typeName, true);
                //obj = Activator.CreateInstance(objType);
                obj = Assembly.LoadFile(path).CreateInstance(string.Format("SmartIot.Tool.DefaultService.DB.{0}", typeName));
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            return obj;
        }
        #endregion

        #region 进入配置向导

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            ConfigWizard wizard = new ConfigWizard();
            wizard.Show();
        }
        #endregion

        #region 拖拽

        private void advTreeData_DragLeave(object sender, EventArgs e)
        {

        }

        private void advTreeData_DragDrop(object sender, DragEventArgs e)
        {
            //var item = e.Data.GetData(e.Data.GetFormats()[0]);
            if(status)
            {
                var location = this.advTreeData.PointToClient(new Point(e.X, e.Y));
                var node = this.advTreeData.GetNodeAt(location.X, location.Y);

                if (node != null && node.Tag.Equals(parent))
                {
                    #region 采集设备
                    if (parent.Equals("SensorDeviceUnit"))
                    {
                        var device = SensorDeviceUnit.FindByID(dragId);
                        var faciliy = node.Parent.Tag as Facility;
                        if (MessageBox.Show("确定要将该设备移动到该设施下吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            var dbList = FacilitySensorDeviceUnit.FindAllByFacilityIdAndCollectDeviceId(faciliy.ID,
                               device.ID);

                            if (dbList == null || dbList.Count == 0)
                            {
                                var fas = new FacilitySensorDeviceUnit()
                                {
                                    FacilityID = faciliy.ID,
                                    SensorDeviceUnitID = device.ID
                                };
                                fas.Code1 = fas.GetCode1();
                                int i = fas.Insert();
                                if (i != 0)
                                {
                                    FacilitySensorDeviceUnit.DeleteByFacilityAndSensorDeviceunit(facId, device.ID);//删除原有关系
                                }

                            }
                            else
                            {
                                var fas = dbList[0];
                                if (!(fas.Code1 + "").StartsWith(faciliy.Code1))
                                {
                                    fas.Code1 = fas.GetCode1();
                                    fas.Update();
                                }
                            }
                        }
                    }
                    #endregion

                    #region 控制设备
                    if (parent.Equals("ControlDeviceUnit"))
                    {
                        var device = ControlDeviceUnit.FindByID(dragId);
                        var faciliy = node.Parent.Tag as Facility;
                        if (MessageBox.Show("确定要将该设备移动到该设施下吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            var dbList = FacilityControlDeviceUnit.FindAllByFacilityIdAndControlDeviceGroupNum(faciliy.ID,
                               device.GroupNum);

                            if (dbList == null || dbList.Count == 0)
                            {
                                var fas = new FacilityControlDeviceUnit()
                                {
                                    FacilityID = faciliy.ID,
                                    ControlDeviceUnitGroupNum = device.GroupNum
                                };
                                fas.Code1 = fas.GetCode1();
                                int i = fas.Insert();
                                if (i != 0)
                                {
                                    FacilityControlDeviceUnit.DeleteByFacilityAndControlDeviceunGroupNum(facId, device.GroupNum);//删除原有关系
                                }

                            }
                            else
                            {
                                var fas = dbList[0];
                                if (!(fas.Code1 + "").StartsWith(faciliy.Code1))
                                {
                                    fas.Code1 = fas.GetCode1();
                                    fas.Update();
                                }
                            }
                            InitData();
                        }
                    }
                    #endregion

                    #region 视频设备
                    if (parent.Equals("Camera"))
                    {
                        var device = Camera.FindByID(dragId);
                        var faciliy = node.Parent.Tag as Facility;
                        if (MessageBox.Show("确定要将该设备移动到该设施下吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            var dbList = FacilityCamera.FindAllByFacilityIdAndCameraId(faciliy.ID,
                               device.ID);

                            if (dbList == null || dbList.Count == 0)
                            {
                                var fas = new FacilityCamera()
                                {
                                    FacilityID = faciliy.ID,
                                    CameraID = device.ID
                                };
                                fas.Code1 = fas.GetCode1();
                                int i = fas.Insert();
                                if (i != 0)
                                {
                                    FacilityCamera.GetDeviceByFacilityIdAndCameraId(facId, device.ID);//删除原有关系
                                }

                            }
                            else
                            {
                                var fas = dbList[0];
                                if (!(fas.Code1 + "").StartsWith(faciliy.Code1))
                                {
                                    fas.Code1 = fas.GetCode1();
                                    fas.Update();
                                }
                            }
                            InitData();
                        }
                    }
                    #endregion
                }

            }
            else
            {
                return;
            }
            InitData();
        }

        private void advTreeData_DragEnter(object sender, DragEventArgs e)
        {

            var location = this.advTreeData.PointToClient(new Point(e.X, e.Y));
            var node = this.advTreeData.GetNodeAt(location);
            if (node == null)
            {
                status = false;
                return; 
            }
            //this.advTreeData.AllowDrop = true;
            parent = node.Parent.Tag;
            if (parent.Equals("SensorDeviceUnit"))
            {
                var dragObj = node.Tag as SensorDeviceUnit;
                dragId = dragObj.ID;
                facId = dragObj.FacilitySensorDeviceUnits[0].FacilityID;
            }
            if (parent.Equals("ControlDeviceUnit"))
            {
                var dragObj = node.Tag as ControlDeviceUnit;
                dragId = dragObj.ID;
                facId = dragObj.FacilityControlDeviceUnits[0].FacilityID;
            }
            if (parent.Equals("Camera"))
            {
                var dragObj = node.Tag as Camera;
                dragId = dragObj.ID;
                facId = dragObj.FacilityCameras[0].FacilityID;
            }
            status = true;
        }

        private void advTreeData_DragOver(object sender, DragEventArgs e)
        {



        }
        #endregion

        #region 工具
        private void buttonItem24_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }

        #endregion

        #region 基础参数
        private void bISersor_Click(object sender, EventArgs e)
        {
            BaseConfig config = new BaseConfig("Sensor");
            config.Text = "传感器";
            config.Show();
        }

        private void bIDeviceType_Click(object sender, EventArgs e)
        {

            BaseConfig config = new BaseConfig("DeviceType");
            config.Text = "设备类型";
            config.Show();
        }

        private void bIFacType_Click(object sender, EventArgs e)
        {
            BaseConfig config = new BaseConfig("FacilityType");
            config.Text = "设施类型";
            config.Show();
        }
        #endregion

        #region 系统
        private void bISysSet_Click(object sender, EventArgs e)
        {
            //to do
        }

        private void bIDataBack_Click(object sender, EventArgs e)
        {
            //to do
        }

        private void bIExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void bIUpdate_Click(object sender, EventArgs e)
        {
            //to do
        }
        #endregion


    }




}
