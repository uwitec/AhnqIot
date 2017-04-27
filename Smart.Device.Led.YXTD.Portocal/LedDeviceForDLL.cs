using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using RzFrame.pub;
using System.Data;
using System.IO;
namespace Smart.Device.Led.YXTD.Portocal
{

    /// <summary>
    /// Ledaccess 的摘要说明。
    /// </summary>
    public class LedDeviceForDLL
    {
        public LedDeviceForDLL()
        {

        }
        // TFileParam
        [StructLayout(LayoutKind.Sequential)]
        private struct TFileParam
        {
            public byte Effect;	//播放方式 0~16（见附注1）
            public byte Level;	//速度级别 0~7 （0最慢/7最快）
            public byte Speed;	//播放速度 0~31（0最快/31最慢）
            public byte Delay;	//停留时间 0~99
            //以下参数仅对文本文件有效，图形文件可为任意值
            public byte Font;		//字体大小 16或24
            public byte ShowTitle;	//是否显示标题 0不显/1显示
            public byte TitleColor;	//标题颜色 0红/1绿/2黄
            public byte WordColor;	//内容颜色 0红/1绿/2黄
        }

        private static int intAddr;
        private static int intCom;
        private static int intBaud;
        private static int intDelay;
        //private static DataTable dtLedBase;
        private static TFileParam stuPara;




        private static string[] strArray = { "发送正常", "对像指针为空", "设备未打开", "发送数据不正确", "回传接收超时", "文件不存在", "发送中止", "接收中止", "运行出错", "生成参数数据出错", "数据表无记录", "接收标志错误", "接收数据错误", "文件已存在", "参数错误", "类型不匹配", "异常出错", "空值不显示", "未知异常" };


        public static void Init(int addr, int com, int baud, int delay)
        {

            intAddr = addr;
            intCom = com;
            intBaud = baud;
            intDelay = delay;
        }

        [DllImport("pArmSendQt.dll")]
        public static extern int SS_Open_Tcp(string sIP, int port, int delay);

        //打开串口
        [DllImport("pArmSendQt.dll")]
        private static extern int SS_Open_Com(int addr, int com, int baud, int delay);

        public static string OpenCom()
        {
            int intOk = SS_Open_Com(intAddr, intCom, intBaud, intDelay);
            return strArray[intOk];
        }

        //关闭串口
        [DllImport("pArmSendQt.dll")]
        public static extern int SS_Close();

        public static string CloseCom()
        {
            int intOk = SS_Close();
            if (intOk > 17)
            {
                intOk = 18;
            }
            return strArray[intOk];
        }

        //校正显示屏的时钟，使之与电脑主机同步。
        [DllImport("pArmSendQt.dll")]
        private static extern int SS_Send_Time();

        public static string SendTime()
        {
            int intOk = SS_Send_Time();
            return strArray[intOk];
        }

        //显示屏复位，等同显示屏断电复位。
        [DllImport("pArmSendQt.dll")]
        private static extern int SS_Send_Reset();

        public static string SendReset()
        {
            int intOk = SS_Send_Reset();
            return strArray[intOk];
        }

        //显示屏播放复位，使之从工程第一页开始播放。
        [DllImport("pArmSendQt.dll")]
        private static extern int SS_Send_Replay();

        public static string SendReplay()
        {
            int intOk = SS_Send_Replay();
            return strArray[intOk];
        }

        //读取显示屏中实时通道名称列表。
        [DllImport("pArmSendQt.dll")]
        private static extern String SS_Get_Window_List();

        public static string GetWindowList()
        {
            string strList = SS_Get_Window_List();
            return strList;
        }

        //发送实时数据
        [DllImport("pArmSendQt.dll")]
        private static extern int SS_Send_File(int W_index, ref TFileParam param, string ListFile, bool IsSave);

        public static string SendInfo(string strListFile, string strType)
        {
            int intWindex;

            if (strType == "week")
            {
                intWindex = 0;
                stuPara.Effect = 16;
                stuPara.Level = 7;
                stuPara.Speed = 0;
                stuPara.Delay = 10;
            }
            else
            {
                intWindex = 1;
                stuPara.Effect = 8;
                stuPara.Level = 1;
                stuPara.Speed = 7;
                stuPara.Delay = 2;
            }

            int intOk = SS_Send_File(intWindex, ref stuPara, strListFile, true);
            return strArray[intOk];
        }

        //发送实时数据
        //		[DllImport("pArmSendQt.dll")]
        //		private static extern int SS_Send_Buffer(int W_index,ref TFileParam param,string Buffer,bool IsSave);
        //		public static string CloseCom()
        //		{
        //			return Infotransfer(SS_Close());
        //		}
        //发送实时数据
        [DllImport("pArmSendQt.dll")]
        public static extern int SS_Send_Buffer_Ex(int W_index, int Effect, int Speed, int Delay, int FontSize, int Color, string Buffer, bool IsSave);


        //删除主控存储器中保存的实时数据文件
        [DllImport("pArmSendQt.dll")]
        private static extern int SS_Delete_File(int W_index);
        public static string DeleteWeekInfo()//通道索引号
        {
            int intOk = SS_Delete_File(0);
            return strArray[intOk];
        }

        public static string DeleteDayInfo()//通道索引号
        {
            int intOk = SS_Delete_File(1);
            return strArray[intOk];
        }



        // 设置通道
        [DllImport("pArmSendQt.dll")]
        public static extern int SS_Set_Value(int AD_tdh, int count);
        //public static string Set_Value(int AD_tdh, int count)//通道索引号
        //{
        //    int intOk = SS_Set_Value(AD_tdh, count);
        //    return strArray[intOk];
        //}
        //释放dll资源


    }
}









