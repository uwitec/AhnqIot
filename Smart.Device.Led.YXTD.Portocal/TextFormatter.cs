using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace Smart.Device.Led.YXTD.Portocal
{
    /// <summary>
    /// 实时文本格式
    /// </summary>
    [ProtoBuf.ProtoContract]
    public class TextFormatter
    {
        public TextFormatter(int width, int height)
        {
            Type = 0x00;//默认文本格式
            IsTitle = 0x01;//是标题
            FontSize = 0x10;//字体大小16
            Style = (byte)ShowType.立即打出;//播放样式：立即打出
            Speed = 0x00;//播放速度
            StayTime = 0x00;//停留时间
            Color = (uint)LedFontColor.Red;
            Height = height;
            Width = width;
            RowCount = Height / Int32.Parse(FontSize.ToString("X2"), System.Globalization.NumberStyles.HexNumber);//屏高除以字体大小
            ColCount = Width / Int32.Parse(FontSize.ToString("X2"), System.Globalization.NumberStyles.HexNumber);//屏宽除以字体大小
        }
        /// <summary>
        /// 类型 0-文本，1-图片，2-GIF
        /// </summary>
        [ProtoMember(1)]
        public Byte Type { get; set; }
        /// <summary>
        /// 是否带标题 0-否，1-是
        /// </summary>
        [ProtoMember(2)]
        public Byte IsTitle { get; set; }
        /// <summary>
        /// 字体大小 16,24
        /// </summary>
        [ProtoMember(3)]
        public Byte FontSize { get; set; }
        /// <summary>
        /// 播放花样 0-16（附表？）
        /// </summary>
        [ProtoMember(4)]
        public Byte Style { get; set; }
        /// <summary>
        /// 播放速度 高三位0-7粗调 低五位0-31微调
        /// </summary>
        [ProtoMember(5)]
        public Byte Speed { get; set; }
        /// <summary>
        /// 停留时间 0-99
        /// </summary>
        [ProtoMember(6)]
        public Byte StayTime { get; set; }
        /// <summary>
        /// 文本显示行数
        /// </summary>
        [ProtoMember(7)]
        public int RowCount { get; set; }
        /// <summary>
        /// 文本显示列数
        /// </summary>
        [ProtoMember(7)]
        public int ColCount { get; set; }

        /// <summary>
        /// 屏高
        /// </summary>
        [ProtoMember(7)]
        public int Height { get; set; }
        /// <summary>
        /// 屏宽
        /// </summary>
        [ProtoMember(7)]
        public int Width { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [ProtoMember(8)]
        public uint Color { get; set; }
        /// <summary>
        /// 数据内容
        /// </summary>
        /// <param name="text">文字内容</param>
        /// <returns>数据</returns>
        public List<byte[]> GenerateData(string text)
        {
            var data = new List<byte> { Type, IsTitle, FontSize, Style, Speed, StayTime };//6字节头部           
            var color = BitConverter.GetBytes(Color); //4字节颜色

            //数据区整理
            var dataBuff = ASCIIEncoding.GetEncoding("gb2312").GetBytes(text);//将文本信息转换为ASII码
            var max = ColCount * 2;//实施窗口每行所能容纳的最大字符数
            var dataRow = dataBuff.LongLength / max;//需要放几行

            //每行：4字节颜色+2*列数的ASII码字符
            for (int i = 0; i < dataRow + 1; i++)
            {

                int k = 0;
                for (int j = 0; j < dataRow + 1; j++)
                {
                    //if(dataBuff.LongLength>max)
                    //{
                        var buff = new List<byte>[max];//存储新的数据段
                       
                        if (dataBuff.Skip(k).Count()>max)
                        {
                            Array.Copy(dataBuff, k, buff, 0, max);//2*列数的ASII码字符
                            k += max;
                            data.AddRange(color);//4字节的颜色
                                                 //一行文本数据
                            buff.ToList().ForEach(b =>
                            {
                                data.AddRange(b);
                            });
                        }
                        //不足一行
                        else
                        {
                            data.AddRange(color);
                            data.AddRange(dataBuff.Skip(k));
                        }                
                    //}                                   
                }
            }


            var dataList = new List<byte[]>();//以512字节数组为集合元素

            var param = data.Count / 512;//数据区按照512字节分割为几段
            int p = 0;
            for (int i = 0; i < param + 1; i++)
            {
                var dataSection = new byte[512];
                if (dataBuff.Skip(p).Count() > 512)
                {
                    Array.Copy(data.ToArray(), p, dataSection, 0, 512);
                    dataList.Add(dataSection);
                    p += 512;
                }
                //不足512字节
                else
                {
                    dataList.Add(dataBuff.Skip(p).ToArray());
                }
            }
            return dataList;
        }
    }
}
