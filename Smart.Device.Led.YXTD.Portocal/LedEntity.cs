using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Smart.Device.Led.YXTD.Portocal
{
    /// <summary>
    /// 数据包格式
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class LedEntity
    {
        private string[] ErrorCmds = new string[]
        {
            "ERROR:cmd len>",
            "ERROR:cmd crc>",
            "ERROR:buf null>",
            "ERROR:unknown>",
            "ERROR:cmd ...>"
        };

        private string[] RightCmds = new string[]
        {
            "OK",
            "send@",
            "done>",
            "Execute OK>"
        };

        [ProtoMember(1)]
        //public Header Header { get; set; }
        Header Header = new Header();//测试用，初始化
        [ProtoMember(2)]
        public Byte[] Data { get; set; }
        [ProtoMember(3)]
        public Byte[] Crc { get; set; }
        [ProtoMember(4)]
        TextFormatter TextFormatter = new TextFormatter(192, 168);//测试用，初始化实时数据窗口大小
        /// <summary>
        /// 设置显示效果
        /// </summary>
        /// <param name="fontSize">字体大小</param>
        /// <param name="style">播放样式</param>
        /// <param name="stayTime">停留时间</param>
        /// <param name="speed">播放速度</param>
        /// <param name="width">屏宽</param>
        /// <param name="height">屏高</param>
        public void SetShowStyle(int style,int stayTime,int speed,int width,int height, int fontSize=16)
        {
            //TextFormatter.Width = width;
            //TextFormatter.Height = height;
        }
        /// <summary>
        /// 生成协议头
        /// </summary>
        /// <param name="address">设备地址</param>
        /// <param name="message">文本消息</param>
        /// <returns>协议头</returns>
        public Byte[] GenerateHeader(byte address,ushort length)
        {
            Header.Address = address;
            Header.Length = length;
            var len = BitConverter.GetBytes(Header.Length);//ushort类型转换为byte[]
            var head=  new List<byte> { Header.Flag1,Header.Address,Header.Flag2,(byte)DataType.DataAndNoCrc, Header.Index};
            head.AddRange(len);
            return head.ToArray();
        }
        /// <summary>
        /// 获取发送的最终数据
        /// </summary>
        /// <param name="position">实时数据窗口的位置</param>
        /// <param name="message">实时数据</param>
        public List<byte[]> GetBytes(int position,string message)
        {
            var send = new List<byte[]>();//发送的总数据包

            var address = 0X01;//地址为1
            var dataList = TextFormatter.GenerateData(message);
            var count = dataList.Count();//数据长度
            //Header.Length = Data.Length + 2;
            var first = new List<byte>();
            first.AddRange(GenerateHeader((byte)address, (ushort)count));//协议头
            first.AddRange(Encoding.ASCII.GetBytes("qtdata┗┛"));
            first.AddRange(Encoding.ASCII.GetBytes(position.ToString()));
            first.AddRange(Encoding.ASCII.GetBytes("┗┛"));
            first.AddRange(Encoding.ASCII.GetBytes(count.ToString()));//数据总长度

            send.Add(first.ToArray());//第一次发送的数据包
            //第二次到第n次发送的数据包
            dataList.ForEach(d=> {
                var next = new List<byte>();//接下来的每次发送的数据包
                var protocolHeader =GenerateHeader((byte)address, (ushort)d.LongLength);//协议头
                next.AddRange(protocolHeader);
                next.AddRange(d);
                send.Add(next.ToArray());
            });
            return send;
        }


     
    }
}
