using System;
using System.Runtime.InteropServices;

namespace SmartIot.Tool.Core.Device.LedDevice.LXLed
{
    public class Led2014
    {
        [DllImport("ListenPlayDll2014.dll", EntryPoint = "SetTransMode2014", CharSet = CharSet.Unicode)]
        public static extern int SetTransMode(int handle, int transMode, int conType);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "StartSend2014", CharSet = CharSet.Unicode)]
        public static extern int StartSend();

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "EndSend2014", CharSet = CharSet.Unicode)]
        public static extern int EndSend(int handle);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "SetNetworkPara2014", CharSet = CharSet.Unicode)]
        public static extern int SetNetworkPara(int handle, int pno, string ip);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "SetSerialPortPara2014", CharSet = CharSet.Unicode)]
        public static extern int SetSerialPortPara(int handle, int pno, int port, int rate);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddControl2014", CharSet = CharSet.Unicode)]
        public static extern int AddControl(int handle, int pno, int dbColor);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddProgram2014", CharSet = CharSet.Unicode)]
        public static extern int AddProgram(int handle, int jno, int playTime);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "SetProgramTimer2014", CharSet = CharSet.Unicode)]
        public static extern int SetProgramTimer(int handle, int pno, int jno, int timingModel, int weekSelect,
            int startSecond, int startMinute,
            int startHour, int startDay, int startMonth, int startWeek, int startYear,
            int endSecond, int endMinute, int endHour, int endDay, int endMonth, int endWeek, int endYear);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddQuitText2014", CharSet = CharSet.Unicode)]
        public static extern int AddQuitText(int handle, int jno, int qno, int left, int top, int width, int height,
            int FontColor, string fontName, int fontSize, int fontBold, int italic, int underline, string text);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddFileArea2014", CharSet = CharSet.Unicode)]
        public static extern int AddFileArea(int handle, int jno, int qno, int left, int top, int width, int height);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddFile2014", CharSet = CharSet.Unicode)]
        public static extern int AddFile(int handle, int jno, int qno, int mno, string fileName, int width, int height,
            int playstyle, int quitStyle, int playspeed, int delay, int midText);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddTimerArea2014", CharSet = CharSet.Unicode)]
        public static extern int AddTimerArea(int handle, int jno, int qno, int left, int top, int width, int height,
            int fontColor, string fontName, int fontSize, int fontBold, int Italic, int Underline,
            int mode, int DayShow, int CulWeek, int CulDay, int CulHour, int CulMin, int CulSec,
            int year, int week, int month, int day, int hour, int minute, int second);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddDClockArea2014", CharSet = CharSet.Unicode)]
        public static extern int AddDClockArea(int handle, int jno, int qno, int left, int top, int width, int height,
            int fontColor, string fontName, int fontSize, int fontBold, int Italic, int Underline,
            int year, int week, int month, int day, int hour, int minute, int second, int TwoOrFourYear,
            int HourShow, int format, int spanMode, int Advacehour, int Advaceminute);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddLnTxtArea2014", CharSet = CharSet.Unicode)]
        public static extern int AddLnTxtArea(int handle, int jno, int qno, int left, int top, int width, int height,
            string LnFileName, int PlayStyle, int Playspeed, int times);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddFileString2014",
            CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public static extern int AddFileString(int pno, int jno, int qno, int mno, string str, string strFont,
            int fontsize, int fontcolor, bool bold, bool italic, bool underline, int Duiqi, int width, int height,
            int playstyle, int QuitStyle, int playspeed, int delay, int MidText);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "SendControl2014", CharSet = CharSet.Unicode)]
        public static extern int SendControl(int handle, int SendType, IntPtr hwnd);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "SendScreenPara2014", CharSet = CharSet.Unicode)]
        public static extern int SendScreenPara(int handle, int dbcolor, int widht, int height);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AdjustTime2014", CharSet = CharSet.Unicode)]
        public static extern int AdjustTime(int handle);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddLnTxtString2014", CharSet = CharSet.Unicode)]
        public static extern int AddLnTxtString(int handle, int jno, int qno, int left, int top, int width, int height,
            string str, string strFont, int fontsize, int fontcolor, bool bold, bool italic, bool underline,
            int PlayStyle, int Playspeed, int times);

        [DllImport("ListenPlayDll2014.dll", EntryPoint = "AddNeiMaTxtArea12014", CharSet = CharSet.Unicode)]
        public static extern int AddNeiMaTxtArea1(int handle, int pno, int jno, int qno, int left, int top, int width,
            int height, string showtext, int ShowStyle, int fontname, int fontcolor, int PlayStyle, int QuitStyle,
            int Playspeed, int times);
    }
}