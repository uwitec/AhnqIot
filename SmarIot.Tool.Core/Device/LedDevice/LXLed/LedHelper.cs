using System;
using System.Collections.Generic;

namespace SmartIot.Tool.Core.Device.LedDevice.LXLed
{
    /// <summary>
    /// LED屏显示类型
    /// </summary>
    public enum LedColorType
    {
        /// <summary>
        /// 单色
        /// </summary>
        Single = 1,

        /// <summary>
        /// 双基色
        /// </summary>
        Double
    }

    /// <summary>
    /// 颜色
    /// </summary>
    public enum FontColor
    {
        Red = 255,
        Green = 65535,
        Yellow = 65280
    }

    /// <summary>
    /// 灵信LED屏发送助手
    /// </summary>
    public class LedHelper
    {
        private readonly int _ledSessionHandle = 0;

        /// <summary>
        /// Smart节目编号
        /// </summary>
        private readonly int _smartProgramIndex = 1;

        /// <summary>
        /// 时间节目编号
        /// </summary>
        private readonly int _timeProgramIndex = 2;

        /// <summary>
        /// 实时数据节目
        /// </summary>
        /// <remark>
        /// int:1为红色，2为绿色，3为黄色
        /// string:显示内容
        /// </remark>
        public List<Tuple<int, string>> ShowInfoTuples = new List<Tuple<int, string>>();

        public LedHelper()
        {
            LedWidth = 192;
            LedHeight = 32;
            ColorType = LedColorType.Double;

            //启动会话
            _ledSessionHandle = Led2014.StartSend();
            //设置为网络通讯模式
            Led2014.SetTransMode(_ledSessionHandle, 1, 1);
        }

        public int LedWidth { get; set; }
        public int LedHeight { get; set; }

        public LedColorType ColorType { get; set; }

        /// <summary>
        /// 设置LED屏参数
        /// </summary>
        /// <param name="ip"></param>
        public void Start(string ip)
        {
            //设置LED控制卡IP地址
            var rIP = Led2014.SetNetworkPara(_ledSessionHandle, 1, ip);
            if (rIP == 0) throw new Exception("设置LED IP失败：" + ip);
            //设置屏参
            var rPara = Led2014.SendScreenPara(_ledSessionHandle, (int) ColorType, LedWidth, LedHeight);
            if (rPara == 0) throw new Exception("设置屏参失败");
            //添加LED
            var rLed = Led2014.AddControl(_ledSessionHandle, 1, (int) ColorType);
            if (rLed == 0) throw new Exception("添加LED失败");

            AddSmartParagram();
            AddTimerParagram();
        }

        /// <summary>
        /// 添加显示信息节目
        /// </summary>
        private void AddSmartParagram()
        {
            var r1 = Led2014.AddProgram(_ledSessionHandle, _smartProgramIndex, 0);
            if (r1 == 0)
            {
                throw new Exception("添加节目失败");
            }
            var r2 = Led2014.AddQuitText(_ledSessionHandle, _smartProgramIndex, 1, 0, 0, LedWidth, LedHeight,
                (int) FontColor.Green, "宋体",
                24, 0, 0, 0, "物联网");
            if (r2 == 0)
            {
                throw new Exception("时间节目添加玛特节目失败");
            }
        }

        /// <summary>
        /// 添加时间节目
        /// </summary>
        private void AddTimerParagram()
        {
            var r1 = Led2014.AddProgram(_ledSessionHandle, _timeProgramIndex, 0);
            if (r1 == 0)
            {
                throw new Exception("添加时间节目失败");
            }

            var r2 = Led2014.AddDClockArea(_ledSessionHandle, _timeProgramIndex, 1, 8, 0, LedWidth, LedHeight, 2, "宋体",
                24, 0, 0,
                0,
                /*DateTime.Now.Year, (int)DateTime.Now.DayOfWeek, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour,
                DateTime.Now.Minute, DateTime.Now.Second,*/0, 0, 1, 1, 1, 1, 0, 2, 1, 1, 0, 0, 0);
            if (r2 == 0)
            {
                throw new Exception("时间节目添加播放区域失败");
            }
        }

        /// <summary>
        /// 添加实时数据内容
        /// </summary>
        /// <param name="isRed"></param>
        /// <param name="showText"></param>
        public void AddNeimaArea(bool isRed, string showText)
        {
            ShowInfoTuples.Add(new Tuple<int, string>(isRed ? 1 : 2, showText));
        }

        public void Send()
        {
            //添加实时数据节目及内容
            for (var i = 0; i < ShowInfoTuples.Count; i++)
            {
                var pragramNo = _timeProgramIndex + i + 1;
                var r1 = Led2014.AddProgram(_ledSessionHandle, pragramNo, 0);
                if (r1 == 0)
                    throw new Exception("添加内码节目失败");
                var r2 = Led2014.AddNeiMaTxtArea1(_ledSessionHandle, 1, pragramNo, 1, 0, 0, LedWidth, LedHeight,
                    ShowInfoTuples[i].Item2, 32, 0, ShowInfoTuples[i].Item1, 32, 255, 10, 3);
                if (r2 == 0)
                    throw new Exception("内码节目添加播放区域失败");
            }

            ////int pno = _timeProgramIndex + 1;
            ////Led2014.AddProgram(_ledSessionHandle, pno, 5);
            ////Led2014.AddNeiMaTxtArea1(_ledSessionHandle, 1, pno, 1, 0, 0, LedWidth, LedHeight, "物联网一二三四五六七", 32/*点阵*/, 0/*宋体*/, 1/*颜色*/, 32/*连续左移*/, 255, 8, 20);

            //发送
            var r3 = Led2014.SendControl(_ledSessionHandle, 1, IntPtr.Zero);
            if (r3 == 0) throw new Exception("发送LED失败");
            //结束
            var r4 = Led2014.EndSend(_ledSessionHandle);
            if (r4 == 0) throw new Exception("结束LED发送失败");
        }
    }
}