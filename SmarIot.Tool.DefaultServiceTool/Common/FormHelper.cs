#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.DefaultServiceTool
// FILENAME   ： FormHelper.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-02 22:41
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using NewLife.Model;
using NewLife.Reflection;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SmartIot.Tool.Core.Common;

namespace SmartIot.Tool.DefaultServiceTool.Common
{
    public static class FormHelper
    {
        //[DllImport("user32")]
        //public static extern int SetParent(int hWndChild, int hWndNewParent);//子窗体置顶
        internal static Form FrmMain;

        private static Icon _icon;

        static FormHelper()
        {
            FrmMain = new FrmMain {Icon = GetIcon()};
        }

        public static Icon GetIcon()
        {
            try
            {
                if (_icon == null)
                    _icon =
                        new Icon(Assembly.GetExecutingAssembly()
                            .GetManifestResourceStream(typeof (FormHelper), "tool.ico"));
                return _icon;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 设置窗体标题
        /// </summary>
        public static void SetFrmTitle(this Form frm, string title = null)
        {
            if (title.IsNullOrWhiteSpace())
                frm.Text = Setting.Current.SystemName;
            else
            {
                frm.Text = title;
            }
        }

        /// <summary>
        /// 注册所有窗体
        /// </summary>
        public static void RegisterForm()
        {
            typeof (Form).GetAllSubclasses(true).ToList().ForEach(t =>
            {
                if (t.Name == typeof (FrmMain).Name) return;
                var obj = t.CreateInstance();
                var frm = obj as Form;
                if (frm != null)
                {
                    ObjectContainer.Current.Register(typeof (Form), t, frm, t.FullName);
                }
            });
        }

        public static void CreateForm<TForm>() where TForm : Form, new()
        {
           
             //var frm = new TForm {MdiParent = FrmMain, WindowState = FormWindowState.Maximized};
             var frm = ObjectContainer.Current.Resolve<Form>(typeof (TForm).FullName);
            if (!ShowChildrenForm("frm"))
            {
                frm.MdiParent = FrmMain;
                frm.WindowState = FormWindowState.Maximized;
                frm.Icon = GetIcon();
                frm.Show();
            }
            //SetParent((int)frm.Handle, (int)FrmMain.Handle);
        }

        public static void CreateForm<TForm>(string id) where TForm : Form, new()
        {

            //var frm = new TForm {MdiParent = FrmMain, WindowState = FormWindowState.Maximized};
            var frm = ObjectContainer.Current.Resolve<Form>(typeof(TForm).FullName);
            if (!ShowChildrenForm("frm"))
            {
                frm.MdiParent = FrmMain;
                frm.WindowState = FormWindowState.Maximized;
                frm.Icon = GetIcon();
                frm.Show();
            }
            //SetParent((int)frm.Handle, (int)FrmMain.Handle);
        }

        /// <summary>
        /// 防止打开多个窗体
        /// </summary>
        /// <param name="p_ChildrenFormText"></param>
        /// <returns></returns>
        private static bool ShowChildrenForm(string p_ChildrenFormText)
        {
            int i;
            //依次检测当前窗体的子窗体
            for (i = 0; i < FrmMain.MdiChildren.Length; i++)
            {
                //判断当前子窗体的Text属性值是否与传入的字符串值相同
                if (FrmMain.MdiChildren[i].Name == p_ChildrenFormText)
                {
                    //如果值相同则表示此子窗体为想要调用的子窗体，激活此子窗体并返回true值
                    FrmMain.MdiChildren[i].Activate();
                    return true;
                }
                else
                {
                    FrmMain.MdiChildren[i].Close();//关闭其他子窗口
                }
            }
            //如果没有相同的值则表示要调用的子窗体还没有被打开，返回false值
            return false;
        }
    }
}