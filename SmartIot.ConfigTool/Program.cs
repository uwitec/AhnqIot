using SmartIot.ConfigTool.Core;
using SmartIot.ConfigTool.Wizard;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SmartIot.ConfigTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateMap.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());

        }
    }
}
