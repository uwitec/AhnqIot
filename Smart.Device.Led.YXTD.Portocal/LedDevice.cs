using System;
using System.Collections.Generic;
using NewLife.Log;
using Smart.Led.Common;
using Smart.Device.Transport;

namespace Smart.Device.Led.YXTD.Portocal
{
    public class LedDevice: ILedDevice
    {
        private TransportTypeEnum transportType;

        public string Host { get; set; }

        public int Args { get; set; }

        /// <summary>
        ///显示屏名称
        /// </summary>
        public string Name { get; set; }

        public LedDevice()
        {
            Name = "圆心大屏";
        }

        public void Init(string host, int args = 0)
        {
            this.Host = host;
            this.Args = args;

            if (this.Host.StartsWith("COM"))
                transportType = TransportTypeEnum.Rs232;
            else
                transportType = TransportTypeEnum.Tcp;
        }

        public bool Display(string message)
        {
            try
            {
                //var transport = TransportFactory.CreateTransport(transportType, this.Host, this.Args, 5000);
                //var data = new SendRam().GetBytes(message);
                //transport.Send(data);
                //transport.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }

        public bool Display(List<Tuple<int, string>> messageList)
        {
            try
            {
                var transport = TransportFactory.CreateTransport(transportType, this.Host, this.Args, 5000);
                messageList.ForEach(item=> {
                    var data = new LedEntity().GetBytes(item.Item1,item.Item2);//根据实时数据窗口的位置发送实时数据
                    data.ForEach(d=> {
                        transport.Send(d);//分包512字节发送
                    });  
                });
                transport.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 使用DLL发送实时数据窗口
        /// </summary>
        /// <param name="messageList">数据</param>
        /// <returns></returns>
        public bool DisplayByDLL(List<Tuple<int, string>> messageList)
        {
            try
            {
                int result = 0;//返回结果
                LedDeviceForDLL.SS_Open_Tcp(Host, Args, 3000);
                messageList.ForEach(item => {
                    result = LedDeviceForDLL.SS_Send_Buffer_Ex(item.Item1, 16, 0, 1000, 16, 0,item.Item2, false);//默认立即打出，16字体
                });
                LedDeviceForDLL.SS_Close();
                return result == 1 ? true : false;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                return false;
            }
        }
        public static bool Test(string message)
        {
            var data = new LedEntity().GetBytes(0,message);//根据实时数据窗口的位置发送实时数据
            data.ForEach(d => { 
                Console.WriteLine(d.ToString());
            });
            return false;
        }
    }
}
