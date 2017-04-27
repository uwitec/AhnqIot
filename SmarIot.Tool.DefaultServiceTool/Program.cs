using SmartIot.Tool.DefaultServiceTool.Common;
using NewLife.Log;
using NewLife.Model;
using NewLife.Net;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using SmartIot.Tool.Core.Common;
using SmartIot.Tool.DefaultService.DB;
using Logger = SmartIot.Tool.DefaultServiceTool.Common.Logger;

namespace SmartIot.Tool.DefaultServiceTool
{
    internal class Program
    {
        #region Methods

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //注册日志处理器
            ObjectContainer.Current.Register<Logger>(new Logger());

            var mutex = new Mutex(false, Setting.Current.SystemName);
            if (mutex.WaitOne(0, false))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //注册所有窗体
                FormHelper.RegisterForm();

                //数据库系统初始化
                CommunicateDeviceType.FindAllWithCache();
                Logger.Current.WriteLog("数据库管理系统初始化完成");

                //弹出主窗体
                Application.Run(FormHelper.FrmMain);
            }
            else
            {
                Logger.Current.WriteWarn("程序已启动");
            }
        }

        #region 自动更新

        private static Upgrade _upgrade;

        private static void Update(Boolean isAsync)
        {
            if (!isAsync) XTrace.WriteLine("自动更新！");
            if (Setting.Current.LastUpdateTime.Date < DateTime.Now.Date)
            {
                Setting.Current.LastUpdateTime = DateTime.Now;

                var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var up = new Upgrade
                {
                    Log = XTrace.Log,
                    Name = "SmartIot-Scada.ConfigTool",
                    Server = "http://wlw.smartiot.cc/update/SmartIot-Tool.html"
                };
                up.UpdatePath = root.CombinePath(up.UpdatePath);
                if (up.Check())
                {
                    up.Download();
                    if (!isAsync)
                        up.Update();
                    else
                    // 留到执行完成以后自动更新
                        _upgrade = up;
                }
            }
        }

        #endregion 自动更新

        #endregion Methods
    }
}