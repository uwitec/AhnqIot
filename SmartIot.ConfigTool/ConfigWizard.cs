using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using SmartIot.Tool.DefaultService.DB;
using System.Collections.Generic;
using DevComponents.DotNetBar;
using XCode;
using System.Data.SQLite;
using SmartIot.Service.Hikvision;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System.Linq;
using DevComponents.DotNetBar.Metro;
using SmartIot.ConfigTool.Model;
using AutoMapper;
namespace SmartIot.ConfigTool.Wizard
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class ConfigWizard : MetroForm
    {
        #region  Properity
        private PropertySettings _AntiAliasPropertySetting = null;
        private IEntity seleObj = null;
        /// <summary>
        ///球机相关信息
        /// </summary>
        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private bool m_bInitSDK = false;
        private bool m_bRecord = false;
        private Int32 m_lRealHandle = -1;
        private string str;
        #endregion
        //private DevComponents.DotNetBar.Controls.ListViewEx listViewEx3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        //private AdvPropertyGrid advPropertyGrid3;
        private ButtonX buttonX4;
        private ButtonX buttonX5;
        private ButtonX buttonX6;
        private StepItem stepItem3;
        //private ProgressSteps progressSteps1;
        private StepItem stepItem2;
        private ProgressSteps progressSteps2;
        private StepItem stepItem1;
        private StepItem stepItem4;
        private StepItem stepItem5;
        private StepItem stepItem6;
        private StepItem stepItem7;
        private StepItem stepItem8;
        private TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx10;
        private ColumnHeader columnHeader28;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private ButtonItem deleteFac;
        private ButtonItem deleteFar;
        private ButtonItem deleteCa;
        private ButtonItem deleteSh;
        private ButtonItem deleteCon;
        private ButtonItem deleteCol;
        private ButtonItem deleteMo;
        private ButtonItem deleteCom;
        private TabItem tabItem2;
        private WizardPage wizardPage3;
        private ContextMenuBar contextMenuBar1;
        private ButtonItem deleteFaclity;
        private ButtonItem deleteFarm;
        private ButtonItem deleteCamera;
        private ButtonItem deleteShow;
        private ButtonItem deleteControl;
        private ButtonItem deleteCollect;
        private ButtonItem deleteModular;
        private ButtonItem deleteCommunication;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx9;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader27;
        private TabItem tabItem1;
        private TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx11;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private ColumnHeader columnHeader33;
        private TabItem tabItem3;
        private AdvPropertyGrid advPropertyGrid7;
        private ButtonX btnAdd7;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx7;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private WizardPage wizardPage4;
        private AdvPropertyGrid advPropertyGrid8;
        private ButtonX btnAdd8;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx8;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private WizardPage wizardPage2;
        private ExpandablePanel expandablePanel1;
        private PictureBox RealPlayWnd;
        private ButtonX btnLogin;
        private DevComponents.DotNetBar.Controls.SwitchButton switchButton1;
        private AdvPropertyGrid advPropertyGrid6;
        private ButtonX btnAdd6;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx6;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx12;
        private ColumnHeader columnHeader34;
        private ColumnHeader columnHeader35;
        private ColumnHeader columnHeader36;
        private TabItem tabItem4;
        private WizardPage wizardPage1;
        private AdvPropertyGrid advPropertyGrid5;
        private ButtonX btnAdd5;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx5;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        internal WizardPage WizardSimpleValidationPage;
        private AdvPropertyGrid advPropertyGrid4;
        private ButtonX btnAdd4;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx4;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        internal WizardPage WizardExePathChoicePage;
        private AdvPropertyGrid advPropertyGrid3;
        private ButtonX btnAdd3;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx3;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        internal WizardPage WizardProcessingPage;
        private ButtonX btnAdd2;
        private ProgressSteps progressSteps3;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private AdvPropertyGrid advPropertyGrid2;
        private WizardPage wizardPage5;
        private ButtonX btnAdd;
        private AdvPropertyGrid advPropertyGrid1;
        private ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private ColumnHeader ID;
        private ColumnHeader 名称;
        private ColumnHeader 备注;
        internal DevComponents.DotNetBar.Wizard Wizard1;
        private ButtonX buttonX1;
        private System.ComponentModel.IContainer components;

        public ConfigWizard()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigWizard));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX5 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX6 = new DevComponents.DotNetBar.ButtonX();
            this.stepItem3 = new DevComponents.DotNetBar.StepItem();
            this.deleteCon = new DevComponents.DotNetBar.ButtonItem();
            this.deleteCol = new DevComponents.DotNetBar.ButtonItem();
            this.deleteMo = new DevComponents.DotNetBar.ButtonItem();
            this.deleteCom = new DevComponents.DotNetBar.ButtonItem();
            this.deleteSh = new DevComponents.DotNetBar.ButtonItem();
            this.deleteCa = new DevComponents.DotNetBar.ButtonItem();
            this.deleteFar = new DevComponents.DotNetBar.ButtonItem();
            this.deleteFac = new DevComponents.DotNetBar.ButtonItem();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewEx10 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.stepItem2 = new DevComponents.DotNetBar.StepItem();
            this.progressSteps2 = new DevComponents.DotNetBar.ProgressSteps();
            this.stepItem1 = new DevComponents.DotNetBar.StepItem();
            this.stepItem4 = new DevComponents.DotNetBar.StepItem();
            this.stepItem5 = new DevComponents.DotNetBar.StepItem();
            this.stepItem6 = new DevComponents.DotNetBar.StepItem();
            this.stepItem7 = new DevComponents.DotNetBar.StepItem();
            this.stepItem8 = new DevComponents.DotNetBar.StepItem();
            this.wizardPage3 = new DevComponents.DotNetBar.WizardPage();
            this.contextMenuBar1 = new DevComponents.DotNetBar.ContextMenuBar();
            this.deleteFaclity = new DevComponents.DotNetBar.ButtonItem();
            this.deleteFarm = new DevComponents.DotNetBar.ButtonItem();
            this.deleteCamera = new DevComponents.DotNetBar.ButtonItem();
            this.deleteShow = new DevComponents.DotNetBar.ButtonItem();
            this.deleteControl = new DevComponents.DotNetBar.ButtonItem();
            this.deleteCollect = new DevComponents.DotNetBar.ButtonItem();
            this.deleteModular = new DevComponents.DotNetBar.ButtonItem();
            this.deleteCommunication = new DevComponents.DotNetBar.ButtonItem();
            this.listViewEx8 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewEx6 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewEx5 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewEx4 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewEx3 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewEx2 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.名称 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.备注 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewEx9 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewEx11 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.advPropertyGrid7 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.btnAdd7 = new DevComponents.DotNetBar.ButtonX();
            this.listViewEx7 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wizardPage4 = new DevComponents.DotNetBar.WizardPage();
            this.advPropertyGrid8 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.btnAdd8 = new DevComponents.DotNetBar.ButtonX();
            this.wizardPage2 = new DevComponents.DotNetBar.WizardPage();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.RealPlayWnd = new System.Windows.Forms.PictureBox();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.switchButton1 = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.advPropertyGrid6 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.btnAdd6 = new DevComponents.DotNetBar.ButtonX();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewEx12 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.wizardPage1 = new DevComponents.DotNetBar.WizardPage();
            this.advPropertyGrid5 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.btnAdd5 = new DevComponents.DotNetBar.ButtonX();
            this.WizardSimpleValidationPage = new DevComponents.DotNetBar.WizardPage();
            this.advPropertyGrid4 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.btnAdd4 = new DevComponents.DotNetBar.ButtonX();
            this.WizardExePathChoicePage = new DevComponents.DotNetBar.WizardPage();
            this.advPropertyGrid3 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.btnAdd3 = new DevComponents.DotNetBar.ButtonX();
            this.WizardProcessingPage = new DevComponents.DotNetBar.WizardPage();
            this.btnAdd2 = new DevComponents.DotNetBar.ButtonX();
            this.progressSteps3 = new DevComponents.DotNetBar.ProgressSteps();
            this.advPropertyGrid2 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.wizardPage5 = new DevComponents.DotNetBar.WizardPage();
            this.advPropertyGrid1 = new DevComponents.DotNetBar.AdvPropertyGrid();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.Wizard1 = new DevComponents.DotNetBar.Wizard();
            this.tabControlPanel2.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid7)).BeginInit();
            this.wizardPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid8)).BeginInit();
            this.wizardPage2.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid5)).BeginInit();
            this.WizardSimpleValidationPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid4)).BeginInit();
            this.WizardExePathChoicePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid3)).BeginInit();
            this.WizardProcessingPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid2)).BeginInit();
            this.wizardPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid1)).BeginInit();
            this.advPropertyGrid1.SuspendLayout();
            this.Wizard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            this.columnHeader4.Width = 32;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 77;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Remark";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Location = new System.Drawing.Point(252, 0);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(75, 23);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 4;
            this.buttonX4.Text = "保 存";
            this.buttonX4.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // buttonX5
            // 
            this.buttonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX5.Location = new System.Drawing.Point(62, 77);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(75, 23);
            this.buttonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX5.TabIndex = 3;
            this.buttonX5.Text = "添加元素";
            this.buttonX5.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX6.Location = new System.Drawing.Point(62, 77);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(75, 23);
            this.buttonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX6.TabIndex = 3;
            this.buttonX6.Text = "添加元素";
            this.buttonX6.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // stepItem3
            // 
            this.stepItem3.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem3.Name = "stepItem3";
            this.stepItem3.Symbol = "";
            this.stepItem3.SymbolSize = 15F;
            this.stepItem3.Text = "采集设备";
            this.stepItem3.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // deleteCon
            // 
            this.deleteCon.Name = "deleteCon";
            this.deleteCon.Text = "删除";
            this.deleteCon.Click += new System.EventHandler(this.deleteCon_Click);
            // 
            // deleteCol
            // 
            this.deleteCol.Name = "deleteCol";
            this.deleteCol.Text = "删除";
            this.deleteCol.Click += new System.EventHandler(this.deleteCol_Click);
            // 
            // deleteMo
            // 
            this.deleteMo.Name = "deleteMo";
            this.deleteMo.Text = "删除";
            this.deleteMo.Click += new System.EventHandler(this.deleteMo_Click);
            // 
            // deleteCom
            // 
            this.deleteCom.Name = "deleteCom";
            this.deleteCom.Text = "删除";
            this.deleteCom.Click += new System.EventHandler(this.deleteCom_Click);
            // 
            // deleteSh
            // 
            this.deleteSh.Name = "deleteSh";
            this.deleteSh.Text = "删除";
            this.deleteSh.Click += new System.EventHandler(this.deleteSh_Click);
            // 
            // deleteCa
            // 
            this.deleteCa.Name = "deleteCa";
            this.deleteCa.Text = "删除";
            this.deleteCa.Click += new System.EventHandler(this.deleteCa_Click);
            // 
            // deleteFar
            // 
            this.deleteFar.Name = "deleteFar";
            this.deleteFar.Text = "删除";
            this.deleteFar.Click += new System.EventHandler(this.deleteFar_Click);
            // 
            // deleteFac
            // 
            this.deleteFac.Name = "deleteFac";
            this.deleteFac.Text = "删除";
            this.deleteFac.Click += new System.EventHandler(this.deleteFac_Click);
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.listViewEx10);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(294, 273);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 5;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // listViewEx10
            // 
            this.listViewEx10.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx10.Border.Class = "ListViewBorder";
            this.listViewEx10.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx10.CheckBoxes = true;
            this.listViewEx10.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30});
            this.listViewEx10.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx10.ForeColor = System.Drawing.Color.Black;
            this.listViewEx10.FullRowSelect = true;
            this.listViewEx10.GridLines = true;
            this.listViewEx10.Location = new System.Drawing.Point(1, 1);
            this.listViewEx10.Name = "listViewEx10";
            this.listViewEx10.Size = new System.Drawing.Size(292, 271);
            this.listViewEx10.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewEx10.TabIndex = 1;
            this.listViewEx10.UseCompatibleStateImageBehavior = false;
            this.listViewEx10.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "编号";
            this.columnHeader28.Width = 47;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "名称";
            this.columnHeader29.Width = 71;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "备注";
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "控制设备";
            // 
            // stepItem2
            // 
            this.stepItem2.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem2.Name = "stepItem2";
            this.stepItem2.Symbol = "";
            this.stepItem2.SymbolSize = 15F;
            this.stepItem2.Text = "模块化设备";
            this.stepItem2.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // progressSteps2
            // 
            this.progressSteps2.AutoSize = true;
            this.progressSteps2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.progressSteps2.BackgroundStyle.Class = "ProgressSteps";
            this.progressSteps2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressSteps2.ContainerControlProcessDialogKey = true;
            this.progressSteps2.ForeColor = System.Drawing.Color.Black;
            this.progressSteps2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stepItem1,
            this.stepItem2,
            this.stepItem3,
            this.stepItem4,
            this.stepItem5,
            this.stepItem6,
            this.stepItem7,
            this.stepItem8});
            this.progressSteps2.Location = new System.Drawing.Point(12, 64);
            this.progressSteps2.Name = "progressSteps2";
            this.progressSteps2.Size = new System.Drawing.Size(866, 20);
            this.progressSteps2.TabIndex = 14;
            // 
            // stepItem1
            // 
            this.stepItem1.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem1.Name = "stepItem1";
            this.stepItem1.Symbol = "";
            this.stepItem1.SymbolSize = 15F;
            this.stepItem1.Text = "通讯设备";
            this.stepItem1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            this.stepItem1.Value = 50;
            this.stepItem1.Click += new System.EventHandler(this.stepItem1_Click);
            // 
            // stepItem4
            // 
            this.stepItem4.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem4.Name = "stepItem4";
            this.stepItem4.Symbol = "";
            this.stepItem4.SymbolSize = 15F;
            this.stepItem4.Text = "控制设备";
            this.stepItem4.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // stepItem5
            // 
            this.stepItem5.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem5.Name = "stepItem5";
            this.stepItem5.Symbol = "";
            this.stepItem5.SymbolSize = 15F;
            this.stepItem5.Text = "展示设备";
            this.stepItem5.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // stepItem6
            // 
            this.stepItem6.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem6.Name = "stepItem6";
            this.stepItem6.Symbol = "";
            this.stepItem6.SymbolSize = 15F;
            this.stepItem6.Text = "视频设备";
            this.stepItem6.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // stepItem7
            // 
            this.stepItem7.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem7.Name = "stepItem7";
            this.stepItem7.Symbol = "";
            this.stepItem7.SymbolSize = 15F;
            this.stepItem7.Text = "基地配置";
            this.stepItem7.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // stepItem8
            // 
            this.stepItem8.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem8.Name = "stepItem8";
            this.stepItem8.Symbol = "";
            this.stepItem8.SymbolSize = 15F;
            this.stepItem8.Text = "设施配置";
            this.stepItem8.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // wizardPage3
            // 
            this.wizardPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage3.AntiAlias = false;
            this.wizardPage3.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage3.Controls.Add(this.contextMenuBar1);
            this.wizardPage3.Controls.Add(this.tabControl1);
            this.wizardPage3.Controls.Add(this.advPropertyGrid7);
            this.wizardPage3.Controls.Add(this.btnAdd7);
            this.wizardPage3.Controls.Add(this.listViewEx7);
            this.wizardPage3.Location = new System.Drawing.Point(7, 77);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.PageDescription = "如温室大棚，鱼塘，大田等";
            this.wizardPage3.PageTitle = "设施";
            this.wizardPage3.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.wizardPage3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage3.TabIndex = 14;
            this.wizardPage3.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.wizardPage3_AfterPageDisplayed);
            // 
            // contextMenuBar1
            // 
            this.contextMenuBar1.AntiAlias = true;
            this.contextMenuBar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F);
            this.contextMenuBar1.IsMaximized = false;
            this.contextMenuBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteFaclity,
            this.deleteFarm,
            this.deleteCamera,
            this.deleteShow,
            this.deleteControl,
            this.deleteCollect,
            this.deleteModular,
            this.deleteCommunication});
            this.contextMenuBar1.Location = new System.Drawing.Point(35, 95);
            this.contextMenuBar1.Name = "contextMenuBar1";
            this.contextMenuBar1.Size = new System.Drawing.Size(75, 219);
            this.contextMenuBar1.Stretch = true;
            this.contextMenuBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextMenuBar1.TabIndex = 26;
            this.contextMenuBar1.TabStop = false;
            this.contextMenuBar1.Text = "contextMenuBar1";
            // 
            // deleteFaclity
            // 
            this.deleteFaclity.AutoExpandOnClick = true;
            this.deleteFaclity.Name = "deleteFaclity";
            this.deleteFaclity.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteFac});
            this.deleteFaclity.Text = "设施";
            // 
            // deleteFarm
            // 
            this.deleteFarm.AutoExpandOnClick = true;
            this.deleteFarm.Name = "deleteFarm";
            this.deleteFarm.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteFar});
            this.deleteFarm.Text = "基地";
            // 
            // deleteCamera
            // 
            this.deleteCamera.AutoExpandOnClick = true;
            this.deleteCamera.Name = "deleteCamera";
            this.deleteCamera.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteCa});
            this.deleteCamera.Text = "视频设备";
            // 
            // deleteShow
            // 
            this.deleteShow.AutoExpandOnClick = true;
            this.deleteShow.Name = "deleteShow";
            this.deleteShow.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteSh});
            this.deleteShow.Text = "展示设备";
            // 
            // deleteControl
            // 
            this.deleteControl.AutoExpandOnClick = true;
            this.deleteControl.Name = "deleteControl";
            this.deleteControl.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteCon});
            this.deleteControl.Text = "控制设备";
            // 
            // deleteCollect
            // 
            this.deleteCollect.AutoExpandOnClick = true;
            this.deleteCollect.Name = "deleteCollect";
            this.deleteCollect.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteCol});
            this.deleteCollect.Text = "采集设备";
            // 
            // deleteModular
            // 
            this.deleteModular.AutoExpandOnClick = true;
            this.deleteModular.Name = "deleteModular";
            this.deleteModular.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteMo});
            this.deleteModular.Text = "模块化设备";
            // 
            // deleteCommunication
            // 
            this.deleteCommunication.AutoExpandOnClick = true;
            this.deleteCommunication.Name = "deleteCommunication";
            this.deleteCommunication.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.deleteCom});
            this.deleteCommunication.Text = "通讯设备";
            // 
            // listViewEx8
            // 
            this.listViewEx8.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx8.Border.Class = "ListViewBorder";
            this.listViewEx8.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx8.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.contextMenuBar1.SetContextMenuEx(this.listViewEx8, this.deleteFarm);
            this.listViewEx8.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx8.ForeColor = System.Drawing.Color.Black;
            this.listViewEx8.FullRowSelect = true;
            this.listViewEx8.GridLines = true;
            this.listViewEx8.Location = new System.Drawing.Point(5, 68);
            this.listViewEx8.Name = "listViewEx8";
            this.listViewEx8.Size = new System.Drawing.Size(294, 302);
            this.listViewEx8.TabIndex = 26;
            this.listViewEx8.UseCompatibleStateImageBehavior = false;
            this.listViewEx8.View = System.Windows.Forms.View.Details;
            this.listViewEx8.SelectedIndexChanged += new System.EventHandler(this.listViewEx8_SelectedIndexChanged);
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "编号";
            this.columnHeader22.Width = 41;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "名称";
            this.columnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader23.Width = 109;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "备注";
            this.columnHeader24.Width = 144;
            // 
            // listViewEx6
            // 
            this.listViewEx6.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx6.Border.Class = "ListViewBorder";
            this.listViewEx6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.contextMenuBar1.SetContextMenuEx(this.listViewEx6, this.deleteCamera);
            this.listViewEx6.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx6.ForeColor = System.Drawing.Color.Black;
            this.listViewEx6.FullRowSelect = true;
            this.listViewEx6.GridLines = true;
            this.listViewEx6.Location = new System.Drawing.Point(5, 68);
            this.listViewEx6.Name = "listViewEx6";
            this.listViewEx6.Size = new System.Drawing.Size(294, 302);
            this.listViewEx6.TabIndex = 20;
            this.listViewEx6.UseCompatibleStateImageBehavior = false;
            this.listViewEx6.View = System.Windows.Forms.View.Details;
            this.listViewEx6.SelectedIndexChanged += new System.EventHandler(this.listViewEx6_SelectedIndexChanged);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "编号";
            this.columnHeader16.Width = 42;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "名称";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 121;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "备注";
            this.columnHeader18.Width = 131;
            // 
            // listViewEx5
            // 
            this.listViewEx5.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx5.Border.Class = "ListViewBorder";
            this.listViewEx5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.contextMenuBar1.SetContextMenuEx(this.listViewEx5, this.deleteShow);
            this.listViewEx5.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx5.ForeColor = System.Drawing.Color.Black;
            this.listViewEx5.FullRowSelect = true;
            this.listViewEx5.GridLines = true;
            this.listViewEx5.Location = new System.Drawing.Point(5, 68);
            this.listViewEx5.Name = "listViewEx5";
            this.listViewEx5.Size = new System.Drawing.Size(294, 302);
            this.listViewEx5.TabIndex = 17;
            this.listViewEx5.UseCompatibleStateImageBehavior = false;
            this.listViewEx5.View = System.Windows.Forms.View.Details;
            this.listViewEx5.SelectedIndexChanged += new System.EventHandler(this.listViewEx5_SelectedIndexChanged);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "编号";
            this.columnHeader13.Width = 42;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "名称";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 144;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "备注";
            this.columnHeader15.Width = 107;
            // 
            // listViewEx4
            // 
            this.listViewEx4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx4.Border.Class = "ListViewBorder";
            this.listViewEx4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.contextMenuBar1.SetContextMenuEx(this.listViewEx4, this.deleteControl);
            this.listViewEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx4.ForeColor = System.Drawing.Color.Black;
            this.listViewEx4.FullRowSelect = true;
            this.listViewEx4.GridLines = true;
            this.listViewEx4.Location = new System.Drawing.Point(5, 68);
            this.listViewEx4.Name = "listViewEx4";
            this.listViewEx4.Size = new System.Drawing.Size(294, 302);
            this.listViewEx4.TabIndex = 14;
            this.listViewEx4.UseCompatibleStateImageBehavior = false;
            this.listViewEx4.View = System.Windows.Forms.View.Details;
            this.listViewEx4.SelectedIndexChanged += new System.EventHandler(this.listViewEx4_SelectedIndexChanged);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "编号";
            this.columnHeader10.Width = 43;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "名称";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 138;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "备注";
            this.columnHeader12.Width = 112;
            // 
            // listViewEx3
            // 
            this.listViewEx3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx3.Border.Class = "ListViewBorder";
            this.listViewEx3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.contextMenuBar1.SetContextMenuEx(this.listViewEx3, this.deleteCollect);
            this.listViewEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx3.ForeColor = System.Drawing.Color.Black;
            this.listViewEx3.FullRowSelect = true;
            this.listViewEx3.GridLines = true;
            this.listViewEx3.Location = new System.Drawing.Point(5, 68);
            this.listViewEx3.Name = "listViewEx3";
            this.listViewEx3.Size = new System.Drawing.Size(294, 302);
            this.listViewEx3.TabIndex = 11;
            this.listViewEx3.UseCompatibleStateImageBehavior = false;
            this.listViewEx3.View = System.Windows.Forms.View.Details;
            this.listViewEx3.SelectedIndexChanged += new System.EventHandler(this.listViewEx3_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "编号";
            this.columnHeader7.Width = 43;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "名称";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 137;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "备注";
            this.columnHeader9.Width = 114;
            // 
            // listViewEx2
            // 
            this.listViewEx2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx2.Border.Class = "ListViewBorder";
            this.listViewEx2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.contextMenuBar1.SetContextMenuEx(this.listViewEx2, this.deleteModular);
            this.listViewEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx2.ForeColor = System.Drawing.Color.Black;
            this.listViewEx2.FullRowSelect = true;
            this.listViewEx2.GridLines = true;
            this.listViewEx2.Location = new System.Drawing.Point(5, 68);
            this.listViewEx2.Name = "listViewEx2";
            this.listViewEx2.Size = new System.Drawing.Size(294, 302);
            this.listViewEx2.TabIndex = 8;
            this.listViewEx2.UseCompatibleStateImageBehavior = false;
            this.listViewEx2.View = System.Windows.Forms.View.Details;
            this.listViewEx2.SelectedIndexChanged += new System.EventHandler(this.listViewEx2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            this.columnHeader1.Width = 54;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "备注";
            this.columnHeader3.Width = 122;
            // 
            // listViewEx1
            // 
            this.listViewEx1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.名称,
            this.备注});
            this.contextMenuBar1.SetContextMenuEx(this.listViewEx1, this.deleteCommunication);
            this.listViewEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx1.ForeColor = System.Drawing.Color.Black;
            this.listViewEx1.FullRowSelect = true;
            this.listViewEx1.GridLines = true;
            this.listViewEx1.Location = new System.Drawing.Point(5, 68);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(294, 302);
            this.listViewEx1.TabIndex = 9;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            this.listViewEx1.SelectedIndexChanged += new System.EventHandler(this.listViewEx1_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "编号";
            this.ID.Width = 50;
            // 
            // 名称
            // 
            this.名称.Text = "名称";
            this.名称.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.名称.Width = 112;
            // 
            // 备注
            // 
            this.备注.Text = "备注";
            this.备注.Width = 131;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(636, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(294, 299);
            this.tabControl1.TabIndex = 25;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.listViewEx9);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(294, 273);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // listViewEx9
            // 
            this.listViewEx9.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx9.Border.Class = "ListViewBorder";
            this.listViewEx9.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx9.CheckBoxes = true;
            this.listViewEx9.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27});
            this.listViewEx9.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx9.ForeColor = System.Drawing.Color.Black;
            this.listViewEx9.FullRowSelect = true;
            this.listViewEx9.GridLines = true;
            this.listViewEx9.Location = new System.Drawing.Point(1, 1);
            this.listViewEx9.Name = "listViewEx9";
            this.listViewEx9.Size = new System.Drawing.Size(292, 271);
            this.listViewEx9.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewEx9.TabIndex = 0;
            this.listViewEx9.UseCompatibleStateImageBehavior = false;
            this.listViewEx9.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "编号";
            this.columnHeader25.Width = 66;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "名称";
            this.columnHeader26.Width = 77;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "备注";
            this.columnHeader27.Width = 148;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "采集设备";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.listViewEx11);
            this.tabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(294, 273);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 9;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // listViewEx11
            // 
            this.listViewEx11.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx11.Border.Class = "ListViewBorder";
            this.listViewEx11.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx11.CheckBoxes = true;
            this.listViewEx11.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33});
            this.listViewEx11.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx11.ForeColor = System.Drawing.Color.Black;
            this.listViewEx11.FullRowSelect = true;
            this.listViewEx11.GridLines = true;
            this.listViewEx11.Location = new System.Drawing.Point(1, 1);
            this.listViewEx11.Name = "listViewEx11";
            this.listViewEx11.Size = new System.Drawing.Size(292, 271);
            this.listViewEx11.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewEx11.TabIndex = 1;
            this.listViewEx11.UseCompatibleStateImageBehavior = false;
            this.listViewEx11.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "编号";
            this.columnHeader31.Width = 47;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "名称";
            this.columnHeader32.Width = 71;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "备注";
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "视频设备";
            // 
            // advPropertyGrid7
            // 
            this.advPropertyGrid7.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid7.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid7.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid7.Location = new System.Drawing.Point(259, 68);
            this.advPropertyGrid7.Name = "advPropertyGrid7";
            this.advPropertyGrid7.Size = new System.Drawing.Size(371, 299);
            this.advPropertyGrid7.TabIndex = 24;
            this.advPropertyGrid7.Text = "advPropertyGrid7";
            this.advPropertyGrid7.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid7_PropertyValueChanging);
            // 
            // btnAdd7
            // 
            this.btnAdd7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd7.Location = new System.Drawing.Point(5, 38);
            this.btnAdd7.Name = "btnAdd7";
            this.btnAdd7.Size = new System.Drawing.Size(75, 23);
            this.btnAdd7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd7.TabIndex = 22;
            this.btnAdd7.Text = "添加元素";
            this.btnAdd7.Click += new System.EventHandler(this.btnAdd7_Click);
            // 
            // listViewEx7
            // 
            this.listViewEx7.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx7.Border.Class = "ListViewBorder";
            this.listViewEx7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx7.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.listViewEx7.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx7.ForeColor = System.Drawing.Color.Black;
            this.listViewEx7.FullRowSelect = true;
            this.listViewEx7.GridLines = true;
            this.listViewEx7.Location = new System.Drawing.Point(5, 68);
            this.listViewEx7.Name = "listViewEx7";
            this.listViewEx7.Size = new System.Drawing.Size(248, 302);
            this.listViewEx7.TabIndex = 23;
            this.listViewEx7.UseCompatibleStateImageBehavior = false;
            this.listViewEx7.View = System.Windows.Forms.View.Details;
            this.listViewEx7.SelectedIndexChanged += new System.EventHandler(this.listViewEx7_SelectedIndexChanged);
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "编号";
            this.columnHeader19.Width = 43;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "名称";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader20.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "备注";
            this.columnHeader21.Width = 105;
            // 
            // wizardPage4
            // 
            this.wizardPage4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage4.AntiAlias = false;
            this.wizardPage4.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage4.Controls.Add(this.advPropertyGrid8);
            this.wizardPage4.Controls.Add(this.btnAdd8);
            this.wizardPage4.Controls.Add(this.listViewEx8);
            this.wizardPage4.Location = new System.Drawing.Point(7, 77);
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.PageDescription = "现场设施所属市县，通常仅一个基地";
            this.wizardPage4.PageTitle = "基地配置";
            this.wizardPage4.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.wizardPage4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage4.TabIndex = 15;
            this.wizardPage4.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.wizardPage4_AfterPageDisplayed);
            // 
            // advPropertyGrid8
            // 
            this.advPropertyGrid8.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid8.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid8.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid8.Location = new System.Drawing.Point(305, 65);
            this.advPropertyGrid8.Name = "advPropertyGrid8";
            this.advPropertyGrid8.Size = new System.Drawing.Size(525, 305);
            this.advPropertyGrid8.TabIndex = 27;
            this.advPropertyGrid8.Text = "advPropertyGrid8";
            this.advPropertyGrid8.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid8_PropertyValueChanging);
            // 
            // btnAdd8
            // 
            this.btnAdd8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd8.Location = new System.Drawing.Point(5, 38);
            this.btnAdd8.Name = "btnAdd8";
            this.btnAdd8.Size = new System.Drawing.Size(75, 23);
            this.btnAdd8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd8.TabIndex = 25;
            this.btnAdd8.Text = "添加元素";
            this.btnAdd8.Click += new System.EventHandler(this.btnAdd8_Click);
            // 
            // wizardPage2
            // 
            this.wizardPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage2.AntiAlias = false;
            this.wizardPage2.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage2.Controls.Add(this.expandablePanel1);
            this.wizardPage2.Controls.Add(this.advPropertyGrid6);
            this.wizardPage2.Controls.Add(this.btnAdd6);
            this.wizardPage2.Controls.Add(this.listViewEx6);
            this.wizardPage2.Controls.Add(this.tabControl2);
            this.wizardPage2.Location = new System.Drawing.Point(7, 77);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.PageDescription = "监控设备，如海康威视";
            this.wizardPage2.PageTitle = "视频设备";
            this.wizardPage2.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.wizardPage2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage2.TabIndex = 13;
            this.wizardPage2.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.wizardPage2_AfterPageDisplayed);
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.RealPlayWnd);
            this.expandablePanel1.Controls.Add(this.btnLogin);
            this.expandablePanel1.Controls.Add(this.switchButton1);
            this.expandablePanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.expandablePanel1.Expanded = false;
            this.expandablePanel1.ExpandedBounds = new System.Drawing.Rectangle(552, 41, 269, 268);
            this.expandablePanel1.HideControlsWhenCollapsed = true;
            this.expandablePanel1.Location = new System.Drawing.Point(656, 38);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(269, 26);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 185;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "视频预览";
            // 
            // RealPlayWnd
            // 
            this.RealPlayWnd.BackColor = System.Drawing.Color.White;
            this.RealPlayWnd.ForeColor = System.Drawing.Color.Black;
            this.RealPlayWnd.Location = new System.Drawing.Point(3, 25);
            this.RealPlayWnd.Name = "RealPlayWnd";
            this.RealPlayWnd.Size = new System.Drawing.Size(263, 209);
            this.RealPlayWnd.TabIndex = 180;
            this.RealPlayWnd.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Location = new System.Drawing.Point(49, 240);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(65, 23);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogin.TabIndex = 181;
            this.btnLogin.Text = "登  录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // switchButton1
            // 
            this.switchButton1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.switchButton1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton1.ForeColor = System.Drawing.Color.Black;
            this.switchButton1.Location = new System.Drawing.Point(153, 240);
            this.switchButton1.Name = "switchButton1";
            this.switchButton1.Size = new System.Drawing.Size(66, 22);
            this.switchButton1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton1.TabIndex = 184;
            this.switchButton1.ValueChanged += new System.EventHandler(this.switchButton1_ValueChanged);
            // 
            // advPropertyGrid6
            // 
            this.advPropertyGrid6.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid6.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid6.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid6.Location = new System.Drawing.Point(305, 68);
            this.advPropertyGrid6.Name = "advPropertyGrid6";
            this.advPropertyGrid6.Size = new System.Drawing.Size(348, 302);
            this.advPropertyGrid6.TabIndex = 21;
            this.advPropertyGrid6.Text = "advPropertyGrid6";
            this.advPropertyGrid6.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid6_PropertyValueChanging);
            // 
            // btnAdd6
            // 
            this.btnAdd6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd6.Location = new System.Drawing.Point(5, 38);
            this.btnAdd6.Name = "btnAdd6";
            this.btnAdd6.Size = new System.Drawing.Size(75, 23);
            this.btnAdd6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd6.TabIndex = 19;
            this.btnAdd6.Text = "添加元素";
            this.btnAdd6.Click += new System.EventHandler(this.btnAdd6_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.Transparent;
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel4);
            this.tabControl2.ForeColor = System.Drawing.Color.Black;
            this.tabControl2.Location = new System.Drawing.Point(659, 68);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(266, 299);
            this.tabControl2.TabIndex = 189;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem4);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.listViewEx12);
            this.tabControlPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(266, 273);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 1;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // listViewEx12
            // 
            this.listViewEx12.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.listViewEx12.Border.Class = "ListViewBorder";
            this.listViewEx12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx12.CheckBoxes = true;
            this.listViewEx12.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36});
            this.listViewEx12.DisabledBackColor = System.Drawing.Color.Empty;
            this.listViewEx12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEx12.ForeColor = System.Drawing.Color.Black;
            this.listViewEx12.FullRowSelect = true;
            this.listViewEx12.GridLines = true;
            this.listViewEx12.Location = new System.Drawing.Point(1, 1);
            this.listViewEx12.Name = "listViewEx12";
            this.listViewEx12.Size = new System.Drawing.Size(264, 271);
            this.listViewEx12.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewEx12.TabIndex = 0;
            this.listViewEx12.UseCompatibleStateImageBehavior = false;
            this.listViewEx12.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "编号";
            this.columnHeader34.Width = 47;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "名称";
            this.columnHeader35.Width = 71;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "备注";
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "预置点";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage1.AntiAlias = false;
            this.wizardPage1.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage1.Controls.Add(this.advPropertyGrid5);
            this.wizardPage1.Controls.Add(this.btnAdd5);
            this.wizardPage1.Controls.Add(this.listViewEx5);
            this.wizardPage1.Location = new System.Drawing.Point(7, 77);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.PageDescription = "用于向现场用户展示环境参数的直接设备，一般为语音播报器和LED显示屏";
            this.wizardPage1.PageTitle = "展示设备";
            this.wizardPage1.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.wizardPage1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage1.TabIndex = 12;
            this.wizardPage1.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.wizardPage1_AfterPageDisplayed);
            // 
            // advPropertyGrid5
            // 
            this.advPropertyGrid5.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid5.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid5.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid5.Location = new System.Drawing.Point(305, 65);
            this.advPropertyGrid5.Name = "advPropertyGrid5";
            this.advPropertyGrid5.Size = new System.Drawing.Size(525, 305);
            this.advPropertyGrid5.TabIndex = 18;
            this.advPropertyGrid5.Text = "advPropertyGrid5";
            this.advPropertyGrid5.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid5_PropertyValueChanging);
            // 
            // btnAdd5
            // 
            this.btnAdd5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd5.Location = new System.Drawing.Point(5, 38);
            this.btnAdd5.Name = "btnAdd5";
            this.btnAdd5.Size = new System.Drawing.Size(75, 23);
            this.btnAdd5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd5.TabIndex = 16;
            this.btnAdd5.Text = "添加元素";
            this.btnAdd5.Click += new System.EventHandler(this.btnAdd5_Click);
            // 
            // WizardSimpleValidationPage
            // 
            this.WizardSimpleValidationPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WizardSimpleValidationPage.AntiAlias = false;
            this.WizardSimpleValidationPage.BackColor = System.Drawing.Color.Transparent;
            this.WizardSimpleValidationPage.Controls.Add(this.advPropertyGrid4);
            this.WizardSimpleValidationPage.Controls.Add(this.btnAdd4);
            this.WizardSimpleValidationPage.Controls.Add(this.listViewEx4);
            this.WizardSimpleValidationPage.Location = new System.Drawing.Point(7, 77);
            this.WizardSimpleValidationPage.Name = "WizardSimpleValidationPage";
            this.WizardSimpleValidationPage.PageDescription = "主要作用于环境，使环境参数在一个合适的范围内，种类：风机、遮阳、天窗等，但是这里并不是单独的一个设备组，而是负责该设备主要状态的逻辑设备，如：风机- 开，只负责打" +
    "开风机";
            this.WizardSimpleValidationPage.PageTitle = "控制设备";
            this.WizardSimpleValidationPage.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.WizardSimpleValidationPage.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WizardSimpleValidationPage.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WizardSimpleValidationPage.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardSimpleValidationPage.TabIndex = 11;
            this.WizardSimpleValidationPage.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WizardSimpleValidationPage_AfterPageDisplayed);
            // 
            // advPropertyGrid4
            // 
            this.advPropertyGrid4.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid4.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid4.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid4.Location = new System.Drawing.Point(305, 65);
            this.advPropertyGrid4.Name = "advPropertyGrid4";
            this.advPropertyGrid4.Size = new System.Drawing.Size(525, 305);
            this.advPropertyGrid4.TabIndex = 15;
            this.advPropertyGrid4.Text = "advPropertyGrid4";
            this.advPropertyGrid4.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid4_PropertyValueChanging);
            // 
            // btnAdd4
            // 
            this.btnAdd4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd4.Location = new System.Drawing.Point(5, 38);
            this.btnAdd4.Name = "btnAdd4";
            this.btnAdd4.Size = new System.Drawing.Size(75, 23);
            this.btnAdd4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd4.TabIndex = 13;
            this.btnAdd4.Text = "添加元素";
            this.btnAdd4.Click += new System.EventHandler(this.btnAdd4_Click);
            // 
            // WizardExePathChoicePage
            // 
            this.WizardExePathChoicePage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WizardExePathChoicePage.AntiAlias = false;
            this.WizardExePathChoicePage.BackColor = System.Drawing.Color.Transparent;
            this.WizardExePathChoicePage.Controls.Add(this.advPropertyGrid3);
            this.WizardExePathChoicePage.Controls.Add(this.btnAdd3);
            this.WizardExePathChoicePage.Controls.Add(this.listViewEx3);
            this.WizardExePathChoicePage.Location = new System.Drawing.Point(7, 77);
            this.WizardExePathChoicePage.Name = "WizardExePathChoicePage";
            this.WizardExePathChoicePage.PageDescription = "获取环境参数的485设备或者4-20mA设备";
            this.WizardExePathChoicePage.PageTitle = "采集设备";
            this.WizardExePathChoicePage.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.WizardExePathChoicePage.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WizardExePathChoicePage.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WizardExePathChoicePage.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardExePathChoicePage.TabIndex = 9;
            this.WizardExePathChoicePage.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WizardExePathChoicePage_AfterPageDisplayed);
            // 
            // advPropertyGrid3
            // 
            this.advPropertyGrid3.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid3.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid3.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid3.Location = new System.Drawing.Point(305, 65);
            this.advPropertyGrid3.Name = "advPropertyGrid3";
            this.advPropertyGrid3.Size = new System.Drawing.Size(525, 305);
            this.advPropertyGrid3.TabIndex = 12;
            this.advPropertyGrid3.Text = "advPropertyGrid3";
            this.advPropertyGrid3.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid3_PropertyValueChanging);
            // 
            // btnAdd3
            // 
            this.btnAdd3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd3.Location = new System.Drawing.Point(5, 38);
            this.btnAdd3.Name = "btnAdd3";
            this.btnAdd3.Size = new System.Drawing.Size(75, 23);
            this.btnAdd3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd3.TabIndex = 10;
            this.btnAdd3.Text = "添加元素";
            this.btnAdd3.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // WizardProcessingPage
            // 
            this.WizardProcessingPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WizardProcessingPage.AntiAlias = false;
            this.WizardProcessingPage.BackColor = System.Drawing.Color.Transparent;
            this.WizardProcessingPage.Controls.Add(this.btnAdd2);
            this.WizardProcessingPage.Controls.Add(this.progressSteps3);
            this.WizardProcessingPage.Controls.Add(this.listViewEx2);
            this.WizardProcessingPage.Controls.Add(this.advPropertyGrid2);
            this.WizardProcessingPage.Location = new System.Drawing.Point(7, 77);
            this.WizardProcessingPage.Name = "WizardProcessingPage";
            this.WizardProcessingPage.PageDescription = "一般为SRC0001(2)或者单独的485设备";
            this.WizardProcessingPage.PageTitle = "模块化设备";
            this.WizardProcessingPage.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.WizardProcessingPage.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WizardProcessingPage.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.WizardProcessingPage.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.WizardProcessingPage.TabIndex = 8;
            this.WizardProcessingPage.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.WizardProcessingPage_AfterPageDisplayed_1);
            // 
            // btnAdd2
            // 
            this.btnAdd2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd2.Location = new System.Drawing.Point(5, 38);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(75, 23);
            this.btnAdd2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd2.TabIndex = 7;
            this.btnAdd2.Text = "添加元素";
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // progressSteps3
            // 
            this.progressSteps3.AutoSize = true;
            // 
            // 
            // 
            this.progressSteps3.BackgroundStyle.Class = "ProgressSteps";
            this.progressSteps3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressSteps3.ContainerControlProcessDialogKey = true;
            this.progressSteps3.ForeColor = System.Drawing.Color.Black;
            this.progressSteps3.Location = new System.Drawing.Point(1, -47);
            this.progressSteps3.Name = "progressSteps3";
            this.progressSteps3.Size = new System.Drawing.Size(387, 22);
            this.progressSteps3.TabIndex = 10;
            // 
            // advPropertyGrid2
            // 
            this.advPropertyGrid2.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid2.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid2.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid2.Location = new System.Drawing.Point(305, 65);
            this.advPropertyGrid2.Name = "advPropertyGrid2";
            this.advPropertyGrid2.Size = new System.Drawing.Size(525, 305);
            this.advPropertyGrid2.TabIndex = 9;
            this.advPropertyGrid2.Text = "advPropertyGrid2";
            this.advPropertyGrid2.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid2_PropertyValueChanging);
            // 
            // wizardPage5
            // 
            this.wizardPage5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardPage5.BackColor = System.Drawing.Color.Transparent;
            this.wizardPage5.Controls.Add(this.listViewEx1);
            this.wizardPage5.Controls.Add(this.advPropertyGrid1);
            this.wizardPage5.Controls.Add(this.btnAdd);
            this.wizardPage5.Location = new System.Drawing.Point(7, 77);
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.PageDescription = "设备通信一般依赖于通讯设备，公司主要的通讯设备为康海时代";
            this.wizardPage5.PageTitle = "通讯设备配置 ";
            this.wizardPage5.Size = new System.Drawing.Size(930, 370);
            // 
            // 
            // 
            this.wizardPage5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.wizardPage5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.wizardPage5.TabIndex = 16;
            this.wizardPage5.AfterPageDisplayed += new DevComponents.DotNetBar.WizardPageChangeEventHandler(this.wizardPage5_AfterPageDisplayed);
            // 
            // advPropertyGrid1
            // 
            this.advPropertyGrid1.BackColor = System.Drawing.Color.White;
            this.advPropertyGrid1.Controls.Add(this.buttonX1);
            this.advPropertyGrid1.Controls.Add(this.btnSave);
            this.advPropertyGrid1.ForeColor = System.Drawing.Color.Black;
            this.advPropertyGrid1.GridLinesColor = System.Drawing.Color.WhiteSmoke;
            this.advPropertyGrid1.Location = new System.Drawing.Point(305, 65);
            this.advPropertyGrid1.Name = "advPropertyGrid1";
            this.advPropertyGrid1.Size = new System.Drawing.Size(525, 305);
            this.advPropertyGrid1.TabIndex = 10;
            this.advPropertyGrid1.Text = "advPropertyGrid1";
            this.advPropertyGrid1.PropertyValueChanging += new DevComponents.DotNetBar.PropertyValueChangingEventHandler(this.advPropertyGrid1_PropertyValueChanging);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(157, 0);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "保 存";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(252, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保 存";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(5, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "添加元素";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Wizard1
            // 
            this.Wizard1.BackButtonWidth = 89;
            this.Wizard1.BackColor = System.Drawing.Color.White;
            this.Wizard1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Wizard1.BackgroundImage")));
            this.Wizard1.ButtonStyle = DevComponents.DotNetBar.eWizardStyle.Office2007;
            this.Wizard1.CancelButtonText = "Cancel";
            this.Wizard1.CancelButtonWidth = 89;
            this.Wizard1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wizard1.FinishButtonTabIndex = 3;
            this.Wizard1.FinishButtonWidth = 89;
            this.Wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wizard1.FooterHeight = 49;
            // 
            // 
            // 
            this.Wizard1.FooterStyle.BackColor = System.Drawing.Color.Transparent;
            this.Wizard1.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Wizard1.ForeColor = System.Drawing.Color.Black;
            this.Wizard1.HeaderCaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wizard1.HeaderDescriptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wizard1.HeaderDescriptionIndent = 16;
            this.Wizard1.HeaderHeight = 65;
            this.Wizard1.HeaderImageSize = new System.Drawing.Size(58, 52);
            // 
            // 
            // 
            this.Wizard1.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(243)))));
            this.Wizard1.HeaderStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Wizard1.HeaderStyle.BackColorGradientAngle = 90;
            this.Wizard1.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Wizard1.HeaderStyle.BorderBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(157)))), ((int)(((byte)(182)))));
            this.Wizard1.HeaderStyle.BorderBottomWidth = 1;
            this.Wizard1.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Wizard1.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.Wizard1.HelpButtonWidth = 89;
            this.Wizard1.Location = new System.Drawing.Point(0, 0);
            this.Wizard1.Name = "Wizard1";
            this.Wizard1.NextButtonWidth = 89;
            this.Wizard1.Size = new System.Drawing.Size(944, 508);
            this.Wizard1.TabIndex = 1;
            this.Wizard1.WizardPages.AddRange(new DevComponents.DotNetBar.WizardPage[] {
            this.wizardPage5,
            this.WizardProcessingPage,
            this.WizardExePathChoicePage,
            this.WizardSimpleValidationPage,
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage4,
            this.wizardPage3});
            this.Wizard1.FinishButtonClick += new System.ComponentModel.CancelEventHandler(this.Wizard1_FinishButtonClick);
            this.Wizard1.CancelButtonClick += new System.ComponentModel.CancelEventHandler(this.Wizard1_CancelButtonClick);
            this.Wizard1.WizardPageChanging += new DevComponents.DotNetBar.WizardCancelPageChangeEventHandler(this.Wizard1_WizardPageChanging);
            // 
            // ConfigWizard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 508);
            this.Controls.Add(this.progressSteps2);
            this.Controls.Add(this.Wizard1);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX5);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置向导";
            this.Load += new System.EventHandler(this.ConfigWizard_Load);
            this.tabControlPanel2.ResumeLayout(false);
            this.wizardPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid7)).EndInit();
            this.wizardPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid8)).EndInit();
            this.wizardPage2.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RealPlayWnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid5)).EndInit();
            this.WizardSimpleValidationPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid4)).EndInit();
            this.WizardExePathChoicePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid3)).EndInit();
            this.WizardProcessingPage.ResumeLayout(false);
            this.WizardProcessingPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid2)).EndInit();
            this.wizardPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advPropertyGrid1)).EndInit();
            this.advPropertyGrid1.ResumeLayout(false);
            this.Wizard1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        ///// <summary>
        ///// The main entry point for the application.
        ///// </summary>
        //[STAThread]
        //static void Main() 
        //{
        //	Application.Run(new Form1());
        //}

        private void Wizard1_CancelButtonClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DevComponents.DotNetBar.MessageBoxEx.Show("确定退出配置向导?请确保数据已保存", "配置向导", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void Wizard1_FinishButtonClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Execute finish code for the wizard... We will just close the form
            this.Close();
        }

        private void Wizard1_WizardPageChanging(object sender, DevComponents.DotNetBar.WizardCancelPageChangeEventArgs e)
        {
           
        }
         
        private void CheckPageSwitch_CheckedChanged(object sender, System.EventArgs e)
        {
            //if (CheckPageSwitch.Checked)
            //    WizardSimpleValidationPage.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.Auto;
            //else
            //    WizardSimpleValidationPage.NextButtonEnabled = DevComponents.DotNetBar.eWizardButtonState.False;
        }

        private void ConfigWizard_Load(object sender, EventArgs e)
        {
 

            #region add properitygrid

            #region common
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
            #endregion

            #region adv1
            // Adds property setting to the grid
            advPropertyGrid1.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;

            // Create save button item
            ButtonItem btnSave = new ButtonItem("btnSave", "保  存");
            btnSave.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave.OptionGroup = "helpPanel"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave.Click += new EventHandler(btnSave_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid1.Toolbar.Items.Add(btnSave);

            // Create new button item
            //ButtonItem button = new ButtonItem("helpPanel", "帮  助");
            //button.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button.OptionGroup = "helpPanel"; // This will automatically manage the Check property so only one button in group is checked
            //button.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid1.Toolbar.Items.Add(button);   


            // Create second button
            ButtonItem button = new ButtonItem("helpTooltip", "通讯设备类型编辑");
            button.ButtonStyle = eButtonStyle.TextOnlyAlways;
            button.OptionGroup = "helpPanel";
            //button.SymbolColor = System.Drawing.SystemColors.;
            button.Checked = true; // This is default value
            //button.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            button.Click += new EventHandler(button_Click);
            advPropertyGrid1.Toolbar.Items.Add(button);
            advPropertyGrid1.HelpType = ePropertyGridHelpType.Panel;
            // Apply layout changes so items become visible
            advPropertyGrid1.Toolbar.RecalcLayout();
            #endregion

            #region adv2
            // Adds property setting to the grid
            advPropertyGrid2.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            // Create new button item
            //ButtonItem button1 = new ButtonItem("helpPanel1", "帮  助");
            //button1.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button1.OptionGroup = "helpPanel1"; // This will automatically manage the Check property so only one button in group is checked
            //button1.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid2.Toolbar.Items.Add(button1);


            // Create save button item
            ButtonItem btnSave1 = new ButtonItem("btnSave1", "保  存");
            btnSave1.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave1.OptionGroup = "helpPanel1"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave1.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave1.Click += new EventHandler(btnSave1_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid2.Toolbar.Items.Add(btnSave1);
            advPropertyGrid2.HelpType = ePropertyGridHelpType.Panel;

            // Create second button
            //button1 = new ButtonItem("helpTooltip1", "SuperTooltip Help1");
            //button1.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button1.OptionGroup = "helpPanel1";
            //button1.Checked = true; // This is default value
            //button1.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //advPropertyGrid2.Toolbar.Items.Add(button1);

            // Apply layout changes so items become visible
            advPropertyGrid2.Toolbar.RecalcLayout();
            #endregion

            #region adv3
            // Adds property setting to the grid
            advPropertyGrid3.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            //// Create new button item
            //ButtonItem button2 = new ButtonItem("helpPanel2", "帮  助");
            //button2.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button2.OptionGroup = "helpPanel2"; // This will automatically manage the Check property so only one button in group is checked
            //button2.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid3.Toolbar.Items.Add(button2);


            // Create save button item
            ButtonItem btnSave2 = new ButtonItem("btnSave2", "保  存");
            btnSave2.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave2.OptionGroup = "helpPanel2"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave2.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave2.Click += new EventHandler(btnSave2_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid3.Toolbar.Items.Add(btnSave2);

            advPropertyGrid3.HelpType = ePropertyGridHelpType.Panel;
            // Create second button
            //ButtonItem button2 = new ButtonItem("helpPanel2", "帮  助");
            ButtonItem button2 = new ButtonItem("helpTooltip2", "传感器编辑");
            button2.ButtonStyle = eButtonStyle.TextOnlyAlways;
            button2.OptionGroup = "helpPanel2";
            button2.Checked = true; // This is default value
            button2.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            advPropertyGrid3.Toolbar.Items.Add(button2);
            button2.Click += new EventHandler(button2_Click);
            // Apply layout changes so items become visible
            advPropertyGrid3.Toolbar.RecalcLayout();
            #endregion

            #region adv4
            // Adds property setting to the grid
            advPropertyGrid4.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            //// Create new button item
            //ButtonItem button3 = new ButtonItem("helpPanel3", "帮  助");
            //button3.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button3.OptionGroup = "helpPanel3"; // This will automatically manage the Check property so only one button in group is checked
            //button3.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid4.Toolbar.Items.Add(button3);


            // Create save button item
            ButtonItem btnSave3 = new ButtonItem("btnSave3", "保  存");
            btnSave3.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave3.OptionGroup = "helpPanel3"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave3.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave3.Click += new EventHandler(btnSave3_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid4.Toolbar.Items.Add(btnSave3);
            advPropertyGrid4.HelpType = ePropertyGridHelpType.Panel;

            // Create second button
            ButtonItem button3 = new ButtonItem("helpTooltip3", "设备类型编辑");
            button3.ButtonStyle = eButtonStyle.TextOnlyAlways;
            button3.OptionGroup = "helpPanel3";
            button3.Checked = true; // This is default value
            button3.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            advPropertyGrid4.Toolbar.Items.Add(button3);
            button3.Click += new EventHandler(button3_Click);
            // Create second button
            button3 = new ButtonItem("helpTooltip13", "继电器类型编辑");
            button3.ButtonStyle = eButtonStyle.TextOnlyAlways;
            button3.OptionGroup = "helpPanel3";
            button3.Checked = true; // This is default value
            button3.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            advPropertyGrid4.Toolbar.Items.Add(button3);
            button3.Click += new EventHandler(button4_Click);
            // Create second button
            button3 = new ButtonItem("helpTooltip23", "控制工作类型编辑");
            button3.ButtonStyle = eButtonStyle.TextOnlyAlways;
            button3.OptionGroup = "helpPanel3";
            button3.Checked = true; // This is default value
            button3.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            advPropertyGrid4.Toolbar.Items.Add(button3);
            button3.Click += new EventHandler(button5_Click);
            // Apply layout changes so items become visible
            advPropertyGrid4.Toolbar.RecalcLayout();
            #endregion

            #region adv5
            // Adds property setting to the grid
            advPropertyGrid5.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            //// Create new button item
            //ButtonItem button4 = new ButtonItem("helpPanel4", "帮  助");
            //button4.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button4.OptionGroup = "helpPanel4"; // This will automatically manage the Check property so only one button in group is checked
            //button4.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid5.Toolbar.Items.Add(button4);


            // Create save button item
            ButtonItem btnSave4 = new ButtonItem("btnSave4", "保  存");
            btnSave4.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave4.OptionGroup = "helpPanel4"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave4.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave4.Click += new EventHandler(btnSave4_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid5.Toolbar.Items.Add(btnSave4);
            advPropertyGrid5.HelpType = ePropertyGridHelpType.Panel;

            // Create second button
            ButtonItem button4 = new ButtonItem("helpTooltip4", "展示设备类型编辑");
            button4.ButtonStyle = eButtonStyle.TextOnlyAlways;
            button4.OptionGroup = "helpPanel4";
            button4.Checked = true; // This is default value
            button4.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            advPropertyGrid5.Toolbar.Items.Add(button4);
             button4.Click += new EventHandler(button6_Click);
            // Apply layout changes so items become visible
            advPropertyGrid5.Toolbar.RecalcLayout();
            #endregion

            #region adv6
            // Adds property setting to the grid
            advPropertyGrid6.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            //// Create new button item
            //ButtonItem button5 = new ButtonItem("helpPanel5", "帮  助");
            //button5.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button5.OptionGroup = "helpPanel5"; // This will automatically manage the Check property so only one button in group is checked
            //button5.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid6.Toolbar.Items.Add(button5);


            // Create save button item
            ButtonItem btnSave5 = new ButtonItem("btnSave5", "保  存");
            btnSave5.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave5.OptionGroup = "helpPanel5"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave5.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave5.Click += new EventHandler(btnSave5_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid6.Toolbar.Items.Add(btnSave5);
            advPropertyGrid6.HelpType = ePropertyGridHelpType.Panel;

            // Create second button
            //button5 = new ButtonItem("helpTooltip5", "SuperTooltip Help5");
            //button5.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button5.OptionGroup = "helpPanel5";
            //button5.Checked = true; // This is default value
            //button5.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //advPropertyGrid6.Toolbar.Items.Add(button5);

            // Apply layout changes so items become visible
            advPropertyGrid6.Toolbar.RecalcLayout();
            #endregion

            #region adv7
            // Adds property setting to the grid
            advPropertyGrid7.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            //// Create new button item
            //ButtonItem button6 = new ButtonItem("helpPanel6", "帮  助");
            //button6.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button6.OptionGroup = "helpPanel6"; // This will automatically manage the Check property so only one button in group is checked
            //button6.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid7.Toolbar.Items.Add(button6);


            // Create save button item
            ButtonItem btnSave6 = new ButtonItem("btnSave6", "保  存");
            btnSave6.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave6.OptionGroup = "helpPanel6"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave6.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave6.Click += new EventHandler(btnSave6_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid7.Toolbar.Items.Add(btnSave6);

            advPropertyGrid7.HelpType = ePropertyGridHelpType.Panel;
            // Create second button
            ButtonItem button6 = new ButtonItem("helpTooltip6", "设施类型编辑");
            button6.ButtonStyle = eButtonStyle.TextOnlyAlways;
            button6.OptionGroup = "helpPanel6";
            button6.Checked = true; // This is default value
            button6.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            advPropertyGrid7.Toolbar.Items.Add(button6);
            button6.Click += new EventHandler(button7_Click);
            // Apply layout changes so items become visible
            advPropertyGrid7.Toolbar.RecalcLayout();
            #endregion

            #region adv8
            // Adds property setting to the grid
            advPropertyGrid8.PropertySettings.Add(_AntiAliasPropertySetting);

            // Set object to display properties for
            //advPropertyGrid1.SelectedObject = buttonItem29;


            //// Create new button item
            //ButtonItem button7 = new ButtonItem("helpPanel7", "帮  助");
            //button7.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button7.OptionGroup = "helpPanel7"; // This will automatically manage the Check property so only one button in group is checked
            //button7.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //// This is how to access the Property Grid toolbar and add new button to it
            //advPropertyGrid8.Toolbar.Items.Add(button7);


            // Create save button item
            ButtonItem btnSave7 = new ButtonItem("btnSave7", "保  存");
            btnSave7.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //btnSave.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.png")));
            btnSave7.OptionGroup = "helpPanel7"; // This will automatically manage the Check property so only one button in group is checked
            //btnSave7.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            btnSave7.Click += new EventHandler(btnSave7_Click);
            // This is how to access the Property Grid toolbar and add new button to it
            advPropertyGrid8.Toolbar.Items.Add(btnSave7);

            advPropertyGrid8.HelpType = ePropertyGridHelpType.Panel;
            // Create second button
            //button7 = new ButtonItem("helpTooltip7", "tool");
            //button7.ButtonStyle = eButtonStyle.TextOnlyAlways;
            //button7.OptionGroup = "helpPanel7";
            //button7.Checked = true; // This is default value
            //button7.OptionGroupChanging += new OptionGroupChangingEventHandler(ButtonOptionGroupChanging);
            //advPropertyGrid8.Toolbar.Items.Add(button7);
            // Apply layout changes so items become visible
            advPropertyGrid8.Toolbar.RecalcLayout();
            #endregion

            #endregion

            InitCommunicationList();

        }

        #region propertygrid效果
        private void ButtonOptionGroupChanging(object sender, OptionGroupChangingEventArgs e)
        {
            if (e.NewChecked.Name == "helpPanel")
                advPropertyGrid1.HelpType = ePropertyGridHelpType.Panel;
            else
                advPropertyGrid1.HelpType = ePropertyGridHelpType.SuperTooltip;
        }
        #endregion

        #region 通讯设备
        private void wizardPage5_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem2.Value = 0;
            this.stepItem3.Value = 0;
            this.stepItem4.Value = 0;
            this.stepItem5.Value = 0;
            this.stepItem6.Value = 0;
            this.stepItem7.Value = 0;
            this.stepItem8.Value = 0;

        }


        private void InitCommunicationList()
        {
            this.listViewEx1.Items.Clear();
            List<CommunicateDevice> communicateDeviceList = CommunicateDevice.FindAll();
            foreach (var communicateDevice in communicateDeviceList)
            {
                var strings = new string[]
               {
                    communicateDevice.ID.ToString(), communicateDevice.Name,communicateDevice.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = communicateDevice;
                this.listViewEx1.Items.Add(listViewItem);
            }
        }

        private void listViewEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx1.SelectedItems.Count > 0)
            {
                if (this.listViewEx1.SelectedItems[0].Tag is CommunicateDevice)
                {
                    var c = this.listViewEx1.SelectedItems[0].Tag as CommunicateDevice;
                    c.CommunicateDeviceTypes = c.CommunicateDeviceTypeName;
                    this.advPropertyGrid1.SelectedObject = Mapper.Map<CommunicateDeviceDto>(c); ;
                    seleObj = c;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (CommunicateDevice.FindByID((seleObj as CommunicateDevice).ID) != null)
            {
                seleObj.Update();
            }
            else
            { 
                seleObj.Save();
            }
            InitCommunicationList();
        }

        private void advPropertyGrid1_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {
            if (e.PropertyName.EqualIgnoreCase("CommunicateDeviceTypes"))
            {
                var CommunicateDeviceTypeId = CommunicateDeviceType.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                seleObj.SetItem("CommunicateDeviceTypeID", CommunicateDeviceTypeId);
            }
            else
            {
                seleObj.SetNoDirtyItem(e.PropertyName, e.NewValue);
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var c = new CommunicateDevice();
            this.advPropertyGrid1.SelectedObject = Mapper.Map<CommunicateDeviceDto>(c);
            seleObj = c;
        }
        #endregion

        #region 模块化设备

        private void btnSave1_Click(object sender, EventArgs e)
        {

            if(seleObj!=null)
            {
                if (ModularDevice.FindByID((seleObj as ModularDevice).ID) != null)
                {
                    seleObj.Update();
                }
                else
                {
                    seleObj.Save();
                }
            }
            InitModularDeviceList();
        }


        private void WizardProcessingPage_AfterPageDisplayed_1(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem1.Value = 100;
            this.stepItem2.Value = 50;
            this.stepItem3.Value = 0;
            this.stepItem4.Value = 0;
            this.stepItem5.Value = 0;


            this.stepItem6.Value = 0;
            this.stepItem7.Value = 0;
            this.stepItem8.Value = 0;
            InitModularDeviceList();

        }

        private void InitModularDeviceList()

        {
            this.listViewEx2.Items.Clear();
            List<ModularDevice> modularDeviceList = ModularDevice.FindAll();
            foreach (var modularDevice in modularDeviceList)
            {
                var strings = new string[]
               {
                    modularDevice.ID.ToString(), modularDevice.Name,modularDevice.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = modularDevice;
                this.listViewEx2.Items.Add(listViewItem);
            }

        }

        private void listViewEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx2.SelectedItems.Count > 0)
            {
                if (this.listViewEx2.SelectedItems[0].Tag is ModularDevice)
                {
                    var c = this.listViewEx2.SelectedItems[0].Tag as ModularDevice;
                    //c.CommunicateDeviceTypes = c.CommunicateDeviceTypeName;
                    c.ProtocalTypes = c.ProtocalTypeName;
                    c.CommunicateDevices = c.CommunicateDeviceName;
                    this.advPropertyGrid2.SelectedObject = Mapper.Map<ModularDeviceDto>(c);
                    seleObj = c;
                }
            }
        }


        private void advPropertyGrid2_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {
            if (e.PropertyName.EqualIgnoreCase("CommunicateDevices"))
            {
                var CommunicateDeviceID = CommunicateDevice.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                seleObj.SetItem("CommunicateDeviceID", CommunicateDeviceID);
            }
            if (e.PropertyName.EqualIgnoreCase("ProtocalTypes"))
            {
                var ProtocalTypeID = ProtocalType.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                seleObj.SetItem("ProtocalTypeID", ProtocalTypeID);
            }
            else
            {
                seleObj.SetNoDirtyItem(e.PropertyName, e.NewValue);
            }

        }
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            var c = new ModularDevice();
            this.advPropertyGrid2.SelectedObject = Mapper.Map<ModularDeviceDto>(c);
            seleObj = c;
        }
        #endregion

        #region 采集设备
        private void WizardExePathChoicePage_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem2.Value = 100;
            this.stepItem3.Value = 50;
            this.stepItem4.Value = 0;
            this.stepItem5.Value = 0;
            this.stepItem6.Value = 0;
            this.stepItem7.Value = 0;
            this.stepItem8.Value = 0;
            //this.progressSteps2.Items.Add(this.stepItem3);
            InitCollectList();
        }
        private void btnSave2_Click(object sender, EventArgs e)
        {

            if (seleObj != null)
            {
                if (SensorDeviceUnit.FindByID((seleObj as SensorDeviceUnit).ID) != null)
                {
                    var d = seleObj as SensorDeviceUnit;
                    d.UpdateTime = DateTime.Now;
                    d.Update();
                }
                else
                {
                    var d = seleObj as SensorDeviceUnit;
                    d.UpdateTime = DateTime.Now;
                    d.Save();
                }
            }

            InitCollectList();
        }
        private void InitCollectList()

        {
            this.listViewEx3.Items.Clear();
            List<SensorDeviceUnit> deviceList = SensorDeviceUnit.FindAll();
            foreach (var device in deviceList)
            {
                var strings = new string[]
               {
                    device.ID.ToString(), device.Name,device.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = device;
                this.listViewEx3.Items.Add(listViewItem);
            }

        }

        private void listViewEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx3.SelectedItems.Count > 0)
            {
                if (this.listViewEx3.SelectedItems[0].Tag is SensorDeviceUnit)
                {
                    var s = this.listViewEx3.SelectedItems[0].Tag as SensorDeviceUnit;
                    s.Sensors = s.SensorName;
                    s.ModularDevices=s.ModularDeviceName;
                    this.advPropertyGrid3.SelectedObject = Mapper.Map<SensorDeviceUnitDto>(s);
                    seleObj = s;
                }
            }
        }


        private void advPropertyGrid3_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {
            if (e.PropertyName.EqualIgnoreCase("ModularDevices"))
            {
                var ModularDeviceID = ModularDevice.FindAllByName(e.NewValue.ToString())[0].ID;
                seleObj.SetItem("ModularDeviceID", ModularDeviceID);
            }
            else if (e.PropertyName.EqualIgnoreCase("Sensors"))
            {
                var SensorId = Sensor.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                seleObj.SetItem("SensorId", SensorId);
            }
            else
            {
                seleObj.SetNoDirtyItem(e.PropertyName, e.NewValue);
            }

        }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            var s = new SensorDeviceUnit();
            this.advPropertyGrid3.SelectedObject = Mapper.Map<SensorDeviceUnitDto>(s);
            seleObj = s;
        }
        #endregion

        #region 控制设备

        private void WizardSimpleValidationPage_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem2.Value = 100;
            this.stepItem3.Value = 100;
            this.stepItem4.Value = 50;
            this.stepItem5.Value = 0;
            this.stepItem6.Value = 0;
            this.stepItem7.Value = 0;
            this.stepItem8.Value = 0;
            InitControlList();
        }
        private void btnSave3_Click(object sender, EventArgs e)
        { 
            if(seleObj!=null)
            {
                if (ControlDeviceUnit.FindByID((seleObj as ControlDeviceUnit).ID) != null)
                {
                    var d = seleObj as ControlDeviceUnit;
                    d.UpdateTime = DateTime.Now;
                    d.Update();
                }
                else
                {
                    var d = seleObj as ControlDeviceUnit;
                    d.UpdateTime = DateTime.Now;
                    d.Save();
                }
                InitControlList();
            }

        }
        private void InitControlList()

        {
            this.listViewEx4.Items.Clear();
            List<ControlDeviceUnit> deviceList = ControlDeviceUnit.FindAll();
            foreach (var device in deviceList)
            {
                var strings = new string[]
               {
                    device.ID.ToString(), device.Name,device.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = device;
                this.listViewEx4.Items.Add(listViewItem);
            }

        }

        private void listViewEx4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx4.SelectedItems.Count > 0)
            {
                if (this.listViewEx4.SelectedItems[0].Tag is ControlDeviceUnit)
                {
                    var c= this.listViewEx4.SelectedItems[0].Tag as ControlDeviceUnit;
                    c.ControlJobTypes = c.ControlJobTypeName;
                    c.RelayTypes = c.RelayTypeName;
                    c.DeviceTypes = c.DeviceTypeName;
                    c.ModularDevices = c.ModularDeviceName;
                    this.advPropertyGrid4.SelectedObject = Mapper.Map<ControlDeviceUnitDto>(c);
                    seleObj = c;
                }
            }
        }


        private void advPropertyGrid4_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {
            if (e.PropertyName.EqualIgnoreCase("ControlJobTypes"))
            {
                var ControlJobTypeId = ControlJobType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Id;
                seleObj.SetItem("ControlJobTypeId", ControlJobTypeId);
            }
            else if (e.PropertyName.EqualIgnoreCase("RelayTypes"))
            {
                var RelayTypeId = RelayType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Id;
                seleObj.SetItem("RelayTypeId", RelayTypeId);
            }
            else if (e.PropertyName.EqualIgnoreCase("DeviceTypes"))
            {
                var DeviceTypeSerialnum = DeviceType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Serialnum;
                seleObj.SetItem("DeviceTypeSerialnum", DeviceTypeSerialnum);
            }
            else
            {
                if (e.PropertyName.EqualIgnoreCase("Name")&&!e.NewValue.ToString().Contains("-"))
                {
                    var newValue = e.NewValue + "-";
                    seleObj.SetNoDirtyItem(e.PropertyName, newValue);
                }
                else
                {
                    seleObj.SetNoDirtyItem(e.PropertyName, e.NewValue);
                } 
            }

        }
        private void btnAdd4_Click(object sender, EventArgs e)
        {
            var c= new ControlDeviceUnit();
            this.advPropertyGrid4.SelectedObject = Mapper.Map<ControlDeviceUnitDto>(c);
            seleObj = c;
        }

        #endregion

        #region 展示设备

        private void wizardPage1_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem2.Value = 100;
            this.stepItem3.Value = 100;
            this.stepItem4.Value = 100;
            this.stepItem5.Value = 50;
            this.stepItem6.Value = 0;
            this.stepItem7.Value = 0;
            this.stepItem8.Value = 0;
            InitShowDeviceList();
        }
        private void btnSave4_Click(object sender, EventArgs e)
        {
            if (seleObj != null)
            {
                if (ShowDevice.FindByID((seleObj as ShowDevice).ID) != null) seleObj.Update();
                else seleObj.Save();
                InitShowDeviceList();
            }

        }
        private void InitShowDeviceList()

        {
            this.listViewEx5.Items.Clear();
            List<ShowDevice> deviceList = ShowDevice.FindAll();
            foreach (var device in deviceList)
            {
                var strings = new string[]
               {
                    device.ID.ToString(), device.Name,device.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = device;
                this.listViewEx5.Items.Add(listViewItem);
            }

        }

        private void listViewEx5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx5.SelectedItems.Count > 0)
            {
                if (this.listViewEx5.SelectedItems[0].Tag is ShowDevice)
                {
                    var s= this.listViewEx5.SelectedItems[0].Tag as ShowDevice;
                    s.ShowDeviceTypes = s.ShowDeviceTypeName;
                    s.CommunicateDevices = s.CommunicateDeviceName;
                    this.advPropertyGrid5.SelectedObject = Mapper.Map<ShowDeviceDto>(s);
                    seleObj = s;
                }
            }
        }


        private void advPropertyGrid5_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {
            if (e.PropertyName.EqualIgnoreCase("ShowDeviceTypes"))
            {
                var ShowDeviceTypeID = ShowDeviceType.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                seleObj.SetItem("ShowDeviceTypeID", ShowDeviceTypeID);
            }
            else if (e.PropertyName.EqualIgnoreCase("CommunicateDevices"))
            {
                var CommunicateDeviceID = CommunicateDevice.FindAllByName("name", e.NewValue, null, 0, 0)[0].ID;
                seleObj.SetItem("CommunicateDeviceID", CommunicateDeviceID);
            }
            else
            {
                seleObj.SetNoDirtyItem(e.PropertyName, e.NewValue);
            }

        }
        private void btnAdd5_Click(object sender, EventArgs e)
        {
            var s = new ShowDevice();
            this.advPropertyGrid5.SelectedObject = Mapper.Map<ShowDeviceDto>(s);
            seleObj = s;
        }

        #endregion

        #region 视频设备


        private void wizardPage2_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem2.Value = 100;
            this.stepItem3.Value = 100;
            this.stepItem4.Value = 100;
            this.stepItem5.Value = 100;
            this.stepItem6.Value = 50;
            this.stepItem7.Value = 0;
            this.stepItem8.Value = 0;
            InitCameraList();
        }
        private void btnSave5_Click(object sender, EventArgs e)
        {
            if (seleObj != null)
            {
                if (Camera.FindByID((seleObj as Camera).ID) != null) seleObj.Update();
                else seleObj.Save();
                InitCameraList();
            }

        }
        private void InitCameraList()

        {
            this.listViewEx6.Items.Clear();
            List<Camera> deviceList = Camera.FindAll();
            foreach (var device in deviceList)
            {
                var strings = new string[]
               {
                    device.ID.ToString(), device.Name,device.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = device;
                this.listViewEx6.Items.Add(listViewItem);
            }

        }

        private void listViewEx6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx6.SelectedItems.Count > 0)
            {
                if (this.listViewEx6.SelectedItems[0].Tag is Camera)
                {
                    var c = this.listViewEx6.SelectedItems[0].Tag as Camera;

                    this.advPropertyGrid6.SelectedObject = Mapper.Map<CameraDto>(c);
                    seleObj = c;
                }
            }
        }


        private void advPropertyGrid6_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {

           seleObj.SetNoDirtyItem(e.PropertyName, e.NewValue);

        }
        private void btnAdd6_Click(object sender, EventArgs e)
        {
            var c = new Camera();
            this.advPropertyGrid6.SelectedObject = Mapper.Map<CameraDto>(c);
            seleObj = c;
        }

        #endregion

        #region 基地
        private void wizardPage4_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem2.Value = 100;
            this.stepItem3.Value = 100;
            this.stepItem4.Value = 100;
            this.stepItem5.Value = 100;
            this.stepItem6.Value = 100;
            this.stepItem7.Value = 50;
            this.stepItem8.Value = 0;
            InitFarmList();
        }
        private void btnSave7_Click(object sender, EventArgs e)
        {
            if (seleObj != null)
            {

                if (Farm.FindByID((seleObj as Farm).ID) != null)
                {
                    seleObj.Update();//防止更新无效
                    var d = seleObj as Farm;
                    d.UpdateTime = DateTime.Now;
                    d.Update();
                }
                else
                {
                    seleObj.Save();//防止更新无效
                    var d = seleObj as Farm;
                    d.UpdateTime = DateTime.Now;
                    d.CreateTime = DateTime.Now;
                    d.Save();
                }
                InitFarmList();
            }

        }
        private void InitFarmList()

        {
            this.listViewEx8.Items.Clear();
            List<Farm> deviceList = Farm.FindAll();
            foreach (var device in deviceList)
            {
                var strings = new string[]
               {
                    device.ID.ToString(), device.Name,device.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = device;
                this.listViewEx8.Items.Add(listViewItem);
            }

        }

        private void listViewEx8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx8.SelectedItems.Count > 0)
            {
                if (this.listViewEx8.SelectedItems[0].Tag is Farm)
                {
                    var f = this.listViewEx8.SelectedItems[0].Tag as Farm;

                    this.advPropertyGrid8.SelectedObject = Mapper.Map<FarmDto>(f);
                    seleObj = f;
                }
            }
        }


        private void advPropertyGrid8_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {        
                seleObj.SetNoDirtyItem(e.PropertyName, e.NewValue);
        }
        private void btnAdd8_Click(object sender, EventArgs e)
        {
            var f = new Farm();
            this.advPropertyGrid8.SelectedObject = Mapper.Map<FarmDto>(f);
            seleObj = f;
        }


        #endregion

        #region 设施
        private void wizardPage3_AfterPageDisplayed(object sender, WizardPageChangeEventArgs e)
        {
            this.stepItem2.Value = 100;
            this.stepItem3.Value = 100;
            this.stepItem4.Value = 100;
            this.stepItem5.Value = 100;
            this.stepItem6.Value = 100;
            this.stepItem7.Value = 100;
            this.stepItem8.Value = 50;
            InitFacilityList();
            InitCollectDeviceListView();
            InitControlDeviceListView();
            InitCameraDeviceListView();
        }

        private void InitFacilityList()
        {
            this.listViewEx7.Items.Clear();
            List<Facility> deviceList = Facility.FindAll();
            foreach (var device in deviceList)
            {
                var strings = new string[]
               {
                    device.ID.ToString(), device.Name,device.Remark
               };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = device;
                this.listViewEx7.Items.Add(listViewItem);
            }

        }
        /// <summary>
        /// 初始化传感器设备列表
        /// </summary>
        private void InitCollectDeviceListView()
        {
            this.listViewEx9.Items.Clear();
            List<SensorDeviceUnit> collectDeviceList = SensorDeviceUnit.FindAll();
            foreach (var collectDevice in collectDeviceList)
            {
                var strings = new string[] { collectDevice.ID.ToString(), collectDevice.Name,collectDevice.Remark };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = collectDevice;
                this.listViewEx9.Items.Add(listViewItem);
  
            }
        }

        /// <summary>
        /// 初始化控制设备列表
        /// </summary>
        private void InitControlDeviceListView()
        {
            this.listViewEx10.Items.Clear();
            List<ControlDeviceUnit> controlDeviceList = ControlDeviceUnit.FindAll();
            foreach (var controlDevice in controlDeviceList)
            {
                var strings = new string[] { controlDevice.ID.ToString(), controlDevice.Name, controlDevice.Remark };
                var listViewItem = new ListViewItem(strings);
                listViewItem.Tag = controlDevice;
                this.listViewEx10.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 初始化摄像机设备列表
        /// </summary>
        private void InitCameraDeviceListView()
        {
            this.listViewEx11.Items.Clear();
            List<Camera> cameraList = Camera.FindAll();
            if (cameraList.Count != 0)
            {
                foreach (var camera in cameraList)
                {
                    var strings = new[] { camera.ID.ToString(), camera.Name, camera.Remark };
                    var listViewItem = new ListViewItem(strings) { Tag = camera };
                    this.listViewEx11.Items.Add(listViewItem);
                }
            }
        }
        private void btnSave6_Click(object sender, EventArgs e)
        {
            if (seleObj != null)
            {
                var facility=Facility.FindByID((seleObj as Facility).ID);
                if (facility != null)
                {
                    seleObj.Update();//防止更新无效
                    facility.UpdateTime = DateTime.Now;
                    facility.Update();
                    #region 获取所有选中的设备

                    //List<SensorDeviceUnit> sensorDeviceUnitList = (from item in this.listView2.Items.Cast<ListViewItem>() where item.Checked select item.Tag as SensorDeviceUnit).ToList();
                    var sensorDeviceUnitListChecked = new List<SensorDeviceUnit>();
                    var sensorDeviceUnitListUncheck = new List<SensorDeviceUnit>();
                    foreach (ListViewItem item in this.listViewEx9.Items)
                    {
                        if (item.Checked == false)
                        {
                            var sensorDeviceUnit = item.Tag as SensorDeviceUnit; //未选中的采集设备
                            sensorDeviceUnitListUncheck.Add(sensorDeviceUnit);
                        }
                        else
                        {
                            sensorDeviceUnitListChecked =
                                (from i in this.listViewEx9.Items.Cast<ListViewItem>()
                                 where i.Checked
                                 select i.Tag as SensorDeviceUnit).ToList(); //选中的采集设备
                        }
                    }

                    //List<FacilityControlDeviceUnit> facilityControlDeviceUnitList = (from item in this.listView3.Items.Cast<ListViewItem>() where item.Checked select item.Tag as FacilityControlDeviceUnit).ToList();//控制设备
                    var controlDeviceUnitListChecked = new List<ControlDeviceUnit>();
                    var controlDeviceUnitListUnchecked = new List<ControlDeviceUnit>();
                    foreach (ListViewItem item in this.listViewEx10.Items)
                    {
                        if (item.Checked == false)
                        {
                            var controlDeviceUnit = item.Tag as ControlDeviceUnit; //未选中的控制设备
                            controlDeviceUnitListUnchecked.Add(controlDeviceUnit);
                        }
                        else
                        {
                            controlDeviceUnitListChecked =
                                (from i in this.listViewEx10.Items.Cast<ListViewItem>()
                                 where i.Checked
                                 select i.Tag as ControlDeviceUnit).ToList(); //选中的控制设备
                        }
                    }

                    //List<FacilityCamera> facilityCameraList = (from item in this.listView4.Items.Cast<ListViewItem>() where item.Checked select item.Tag as FacilityCamera).ToList();//摄像机设备

                    var cameraListChecked = new List<Camera>();
                    var cameraListUnchecked = new List<Camera>();
                    foreach (ListViewItem item in this.listViewEx11.Items)
                    {
                        if (item.Checked == false)
                        {
                            var camera = item.Tag as Camera; //未选中的摄像机设备
                            cameraListUnchecked.Add(camera);
                        }
                        else
                        {
                            cameraListChecked =
                                (from i in this.listViewEx11.Items.Cast<ListViewItem>() where i.Checked select i.Tag as Camera)
                                    .ToList(); //选中的摄像机设备
                        }
                    }

                    #endregion 获取所有选中的设备

                    #region 更新采集设备

                    foreach (var sensorDevice in sensorDeviceUnitListChecked)
                    {
                        var dbList = FacilitySensorDeviceUnit.FindAllByFacilityIdAndCollectDeviceId(facility.ID,
                            sensorDevice.ID);

                        if (dbList == null || dbList.Count == 0)
                        {
                            var fas = new FacilitySensorDeviceUnit()
                            {
                                FacilityID = facility.ID,
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
                        FacilitySensorDeviceUnit.DeleteByFacilityAndSensorDeviceunit(facility.ID, sensorDevice.ID);
                    }
                    this.InitCollectDeviceListView();

                    #endregion 更新采集设备

                    #region 更新控制设备

                    foreach (var controlDevice in controlDeviceUnitListChecked)
                    {
                        var dbList = FacilityControlDeviceUnit.FindAllByFacilityIdAndControlDeviceGroupNum(facility.ID,
                            controlDevice.GroupNum);

                        if (dbList == null || dbList.Count == 0)
                        {
                            var fac = new FacilityControlDeviceUnit()
                            {
                                FacilityID = facility.ID,
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
                        FacilityControlDeviceUnit.DeleteByFacilityAndControlDeviceunGroupNum(facility.ID,
                            controlDevice.GroupNum);
                    }
                    this.InitControlDeviceListView();

                    #endregion 更新控制设备

                    #region 更新摄像机设备

                    foreach (var facilityCamera in cameraListChecked)
                    {
                        var dbList = FacilityCamera.FindAllByFacilityIdAndCameraId(facility.ID, facilityCamera.ID);

                        if (dbList == null || dbList.Count == 0)
                        {
                            var fac = new FacilityCamera()
                            {
                                FacilityID = facility.ID,
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
                        FacilityCamera.DeleteByFacilityAndCamera(facility.ID, camera.ID);
                    }
                    this.InitCameraDeviceListView();

                    #endregion 更新摄像机设备

                }
                else 
                {
                    seleObj.Save();//防止更新无效
                    var fac = seleObj as Facility;
                    if (!(fac.Code1 + "").StartsWith(fac.Farm.Code1 + ""))
                    {
                        fac.Code1 = fac.GetCode1();
                    }
                    fac.CreateTime = DateTime.Now;
                    fac.UpdateTime = DateTime.Now;
                    fac.Save();
                }            


            }


            InitFacilityList();
       }
  

        private void listViewEx7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewEx7.SelectedItems.Count > 0)
            {
                if (this.listViewEx7.SelectedItems[0].Tag is Facility)
                {
                    var f = this.listViewEx7.SelectedItems[0].Tag as Facility;
                    f.Farms = f.FarmName;
                    f.FacilityTypes = f.FacilityTypeName;
                    this.advPropertyGrid7.SelectedObject = Mapper.Map<FacilityDto>(f);
                    seleObj = f;



                    #region 采集设备列表的改变事件

                    List<FacilitySensorDeviceUnit> facilitySensorDeviceUnitList =
                        (this.listViewEx7.SelectedItems[0].Tag as Facility).FacilitySensorDeviceUnits;
                    //获取该设施所拥有的所有采集设备的集合
                    var collectionDeviceList = new List<SensorDeviceUnit>();
                    foreach (var fac in facilitySensorDeviceUnitList)
                    {
                        var collectionDevice = SensorDeviceUnit.FindByID(fac.SensorDeviceUnitID);
                        collectionDeviceList.Add(collectionDevice);
                    }

                    if (collectionDeviceList == null || collectionDeviceList.Count == 0)
                    {
                        foreach (ListViewItem item in this.listViewEx9.Items)
                        {
                            item.Checked = false;
                        }

                        //return;
                    }
                    else
                    {
                        foreach (ListViewItem item in this.listViewEx9.Items)
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
                        (this.listViewEx7.SelectedItems[0].Tag as Facility).FacilityControlDeviceUnits;
                    //获取该设施所拥有的所有控制设备的集合
                    var controlDeviceList = new List<ControlDeviceUnit>();
                    foreach (var fas in facilityControlDeviceUnitList)
                    {
                        var controlDevices = ControlDeviceUnit.FindByGroupNum(fas.ControlDeviceUnitGroupNum);
                        controlDeviceList.AddRange(controlDevices);
                    }
                    if (controlDeviceList == null || controlDeviceList.Count == 0)
                    {
                        foreach (ListViewItem item in this.listViewEx10.Items)
                        {
                            item.Checked = false;
                        }
                    }
                    else
                    {
                        foreach (ListViewItem item in this.listViewEx10.Items)
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
                        (this.listViewEx7.SelectedItems[0].Tag as Facility).FacilityCameras; //获取该设施所拥有的所有摄像机设备的集合
                    var cameraList = new List<Camera>();
                    foreach (var fc in facilityCameraList)
                    {
                        var camera = Camera.FindByID(fc.CameraID);
                        cameraList.Add(camera);
                    }
                    if (cameraList == null || cameraList.Count == 0)
                    {
                        foreach (ListViewItem item in this.listViewEx11.Items)
                        {
                            item.Checked = false;
                        }

                        //return;
                    }

                    foreach (ListViewItem item in this.listViewEx11.Items)
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


        private void advPropertyGrid7_PropertyValueChanging(object sender, PropertyValueChangingEventArgs e)
        {
            if (e.PropertyName.EqualIgnoreCase("Farms"))
            {
                var farm = Farm.FindAllByName("name", e.NewValue, null, 0, 0)[0];
                var FarmID = farm.ID;
                //seleObj.SetItem("Code1")
                seleObj.SetItem("FarmID", FarmID);
            }
            else if (e.PropertyName.EqualIgnoreCase("FacilityTypes"))
            {
                var FacilityTypeSerialnum = FacilityType.FindAllByName("name", e.NewValue, null, 0, 0)[0].Serialnum;
                seleObj.SetItem("FacilityTypeSerialnum", FacilityTypeSerialnum);
            }
            else
            {
                seleObj.SetItem(e.PropertyName, e.NewValue);
            }


        }
        private void btnAdd7_Click(object sender, EventArgs e)
        {
            var f = new Facility();
            this.advPropertyGrid7.SelectedObject = Mapper.Map<FacilityDto>(f);
            seleObj = f;
        }

        #endregion

        #region step

        private void stepItem1_Click(object sender, EventArgs e)
        {
            //this.Wizard1.
        }

        #endregion

        #region 类型编辑
        private void button_Click(object sender,EventArgs e)
        {
            //this.dataGridViewX1.Visible = true;
            BaseConfig config = new BaseConfig("CommunicateDeviceType");
            config.Text = "通讯设备类型";
            config.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //this.dataGridViewX1.Visible = true;
            BaseConfig config = new BaseConfig("Sensor");
            config.Text = "传感器";
            config.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.dataGridViewX1.Visible = true;
            BaseConfig config = new BaseConfig("DeviceType");
            config.Text = "设备类型";
            config.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //this.dataGridViewX1.Visible = true;
            BaseConfig config = new BaseConfig("RelayType");
            config.Text = "继电器类型";
            config.Show();
        }
          private void button5_Click(object sender, EventArgs e)
        {
            //this.dataGridViewX1.Visible = true;
            BaseConfig config = new BaseConfig("ControlJobType");
            config.Text = "控制设备类型";
            config.Show();
        }
        private void button6_Click(object sender, EventArgs e)
          {
              BaseConfig config = new BaseConfig("ShowDeviceType");
              config.Text = "展示设备类型";
              config.Show();
          }

        private void button7_Click(object sender, EventArgs e)
        {
            BaseConfig config = new BaseConfig("FacilityType");
            config.Text = "设施类型";
            config.Show();
        }
        #endregion

        #region 视频预览

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var camera = seleObj as Camera;
            if (camera == null) return;

            #region 海康威视初始化
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                MessageBox.Show(this, "NET_DVR_Init error!", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //保存SDK日志 To save the SDK log
                //CHCNetSDK.NET_DVR_SetLogToFile(3, "C:\\SdkLog\\", true);
            }
            #endregion

            if (camera.CameraHost == null || camera.CameraDataPort == null ||
                camera.UserID== null|| camera.UserPwd== null)
            {
                MessageBox.Show(this, "Please input IP, Port, User name and Password!", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (m_lUserID < 0)
            {
                string DVRIPAddress = camera.CameraHost; //设备IP地址或者域名
                Int16 DVRPortNumber =Convert.ToInt16(camera.CameraDataPort);//设备服务端口号
                string DVRUserName = camera.UserID;//设备登录用户名
                string DVRPassword = camera.UserPwd;//设备登录密码

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号
                    MessageBox.Show(this, str, "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    //登录成功
                    MessageBox.Show(this, "Login Success!", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLogin.Text = "退出";
                }

            }
            else
            {
                //注销登录 Logout the device
                if (m_lRealHandle >= 0)
                {
                    MessageBox.Show(this, "Please stop live view firstly", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(this, str, "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                m_lUserID = -1;
                btnLogin.Text = "登录";
            }
            return;
        }


        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (this.switchButton1.Value == true)
            {
                if (m_lUserID < 0)
                {
                    MessageBox.Show(this, "Please login the device firstly", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (m_lRealHandle < 0)
                {
                    CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                    lpPreviewInfo.hPlayWnd = this.RealPlayWnd.Handle;//预览窗口
                    lpPreviewInfo.lChannel = Int16.Parse("1");//预te览的设备通道
                    lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                    lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                    lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                    lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

                    CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                    IntPtr pUser = new IntPtr();//用户数据

                    //打开预览 Start live view 
                    m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                    if (m_lRealHandle < 0)
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                        MessageBox.Show(this, str, "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        //预览成功
                        //btnPreview.Text = "Stop Live View";
                    }
                }
                else
                {
                    //停止预览 Stop live view 
                    if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                        MessageBox.Show(str);
                        return;
                    }
                    m_lRealHandle = -1;
                    //btnPreview.Text = "Live View";
                    MessageBox.Show(this, "预览失败！", "MessageBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnLogin.Text = "登录";
                }
                return;
            }
            else
            {
                //停止预览 Stop live view 
                if (m_lRealHandle >= 0)
                {
                    CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                    m_lRealHandle = -1;
                }

                //注销登录 Logout the device
                if (m_lUserID >= 0)
                {
                    CHCNetSDK.NET_DVR_Logout(m_lUserID);
                    m_lUserID = -1;
                }

                CHCNetSDK.NET_DVR_Cleanup();
                this.btnLogin.Text = "登录";
            }
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="lRealHandle"></param>
        /// <param name="dwDataType"></param>
        /// <param name="pBuffer"></param>
        /// <param name="dwBufSize"></param>
        /// <param name="pUser"></param>
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }


        #endregion

        #region 删除操作

        private void deleteFac_Click(object sender, EventArgs e)
        {
            if (this.listViewEx7.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该设施？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该设施吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listViewEx7.SelectedItems[0].Tag is Facility)
                    {
                        var facility = this.listViewEx7.SelectedItems[0].Tag as Facility;
                        int id = facility.ID;
                        List<FacilitySensorDeviceUnit> facilitySensorDeviceUnitList = FacilitySensorDeviceUnit.FindAllByFacilityID(id);
                        List<FacilityControlDeviceUnit> facilityControlDeviceUnitList = FacilityControlDeviceUnit.FindAllByFacilityID(id);
                        List<FacilityCamera> facilityCameraList = FacilityCamera.FindAllByFacilityID(id);
                        if (facilitySensorDeviceUnitList.Count>0|| facilityControlDeviceUnitList.Count>0 || facilityCameraList.Count>0)
                        {
                            MessageBox.Show("该设施已经在使用，不能删除");
                            return;
                        }
                        facility.Delete();
                        this.InitFacilityList();
                        //this.facilityId = 0;
                    }
                }
            }
        }

        private void deleteFar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除该基地吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (this.listViewEx8.SelectedItems[0].Tag is Farm)
                {
                    var farm = this.listViewEx8.SelectedItems[0].Tag as Farm;
                    int id = farm.ID;
                    List<Facility> facilityList = Facility.FindAllByFarmID(id);
                    if (facilityList.Count>0)
                    {
                        MessageBox.Show("该基地已经在使用，不能删除");
                        return;
                    }
                    //Farm.Delete(farm);
                    farm.Delete();
                    InitFarmList();
                }
            }
        }

        private void deleteCa_Click(object sender, EventArgs e)
        {
            if (listViewEx6.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确定要删除该摄像机吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (listViewEx6.SelectedItems[0].Tag is Camera)
                    {
                        var camera = listViewEx6.SelectedItems[0].Tag as Camera;
                        int id = camera.ID;
                        List<FacilityCamera> facilityCameraList = FacilityCamera.FindAllByCameraID(id);
                        if (facilityCameraList.Count>0)
                        {
                            MessageBox.Show("该设备已经在使用，不能删除");
                            return;
                        }
                        camera.Delete();
                        InitCameraList();

                    }
                }
            }
        }

        private void deleteSh_Click(object sender, EventArgs e)
        {
            if (this.listViewEx5.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该展示设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该展示设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listViewEx5.SelectedItems[0].Tag is ShowDevice)
                    {
                        var showDevice = this.listViewEx5.SelectedItems[0].Tag as ShowDevice;
                        var id = showDevice.ID;
                        List<ShowData> showDataList = ShowData.FindAllByShowDeviceID(id);
                        if (showDataList.Count>0)
                        {
                            MessageBox.Show("该展示设备已经在使用，不能删除");
                            return;
                        }
                        ShowDevice.Delete(showDevice);
                        InitShowDeviceList();
                    }
                }
            }
        }

        private void deleteCon_Click(object sender, EventArgs e)
        {
            if (this.listViewEx4.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该控制设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该控制设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listViewEx4.SelectedItems[0].Tag is Sensor)
                    {
                        var selectControlDeviceUnit = this.listViewEx4.SelectedItems[0].Tag as ControlDeviceUnit;
                        int id = selectControlDeviceUnit.ID;
                        var facs = FacilityControlDeviceUnit.FindAllByControlDeviceUnitGroupNum(selectControlDeviceUnit.GroupNum);

                        if (facs.Count > 0)
                        {
                            MessageBox.Show("该设备已经在使用，不能删除");
                            return;
                        }
                        ControlDeviceUnit.Delete(selectControlDeviceUnit);
                        InitControlDeviceListView();
                    }
                }
            }
        }

        private void deleteMo_Click(object sender, EventArgs e)
        {
            if (this.listViewEx2.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该模块化设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该模块化设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listViewEx2.SelectedItems[0].Tag is ModularDevice)
                    {
                        var modularDevice = this.listViewEx2.SelectedItems[0].Tag as ModularDevice;
                        int id = modularDevice.ID;
                        List<SensorDeviceUnit> sensorDeviceUnitList = SensorDeviceUnit.FindAllByModularDeviceID(id);
                        List<ControlDeviceUnit> controlDeviceUnitList = ControlDeviceUnit.FindAllByModularDeviceID(id);
                        if (sensorDeviceUnitList.Count>0 || controlDeviceUnitList.Count>0 )
                        {
                            MessageBox.Show("该模块化设备已经在使用，不能删除");
                            return;
                        }
                        //ModularDevice.Delete(mdularDevice);
                        modularDevice.Delete();
                        InitModularDeviceList();
                    }
                }
            }
        }

        private void deleteCol_Click(object sender, EventArgs e)
        {
            if (this.listViewEx3.SelectedItems.Count > 0)
            { 
                if (MessageBox.Show("确定要删除该采集设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listViewEx3.SelectedItems[0].Tag is SensorDeviceUnit)
                    {
                        var selectSensorUnit = this.listViewEx3.SelectedItems[0].Tag as SensorDeviceUnit;
                        int id = selectSensorUnit.ID;
                        List<ShowData> showDataList = ShowData.FindAllBySensorDeviceUnitID(id);
                        var fas = FacilitySensorDeviceUnit.FindAllBySensorDeviceUnitID(id);
                        if (showDataList.Count > 0||fas.Count>0)
                        {
                            MessageBox.Show("该设备已经在使用，不能删除");
                            return;
                        }
                        selectSensorUnit.Delete();
                        InitCollectDeviceListView();
                    }
                }
            }
        }

        private void deleteCom_Click(object sender, EventArgs e)
        {
            if (this.listViewEx1.SelectedItems.Count > 0)
            {
                //if (MessageBox.Show("是否删除该通讯设备？") == DialogResult.OK)
                if (MessageBox.Show("确定要删除该通讯设备吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.listViewEx1.SelectedItems[0].Tag is CommunicateDevice)
                    {
                        var communicateDevice = this.listViewEx1.SelectedItems[0].Tag as CommunicateDevice;
                        int id = communicateDevice.ID;
                        List<ShowDevice> showDeviceList = ShowDevice.FindAllByCommunicateDeviceID(id);
                        var modualrs = ModularDevice.FindAllByCommunicateDeviceID(id);
                        if (showDeviceList.Count > 0 || modualrs.Count > 0)
                        {
                            MessageBox.Show("该设备已经在使用，不能删除");
                            return;
                        }
                        //CommunicateDevice.Delete(communicateDevice);
                        communicateDevice.Delete();
                        InitCommunicationList();
                    }
                }
            }
        }


        #endregion

    }
}
