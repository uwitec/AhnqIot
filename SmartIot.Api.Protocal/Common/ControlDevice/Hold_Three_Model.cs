#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： Hold_Three_Parser.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-03-11 9:24
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using System;

namespace SmartIot.Api.Protocal.Common.ControlDevice
{
    /// <summary>
    /// 保持式三态控制模型
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class Hold_Three_Model
    {
        public Hold_Three_Model(bool positive, bool reverse)
        {
            if (positive && reverse) throw new ArgumentException("提供的参数值存在计算错误");
            this.Positive = positive;
            this.Reverse = reverse;
            //if (!(positive && reverse))
            //    Stop = true;
        }

        public Hold_Three_Model(bool stop)
        {
            if (stop)
                this.Positive = this.Reverse = false;
        }

        public Hold_Three_Model(int value)
        {
            var cmdValue = (Hold_Three_ControlCommandEnum) value;
            if (cmdValue == Hold_Three_ControlCommandEnum.Positive)
            {
                this.Positive = true;
                this.Reverse = false;
            }
            if (cmdValue == Hold_Three_ControlCommandEnum.Reverse)
            {
                this.Positive = false;
                this.Reverse = true;
            }
        }

        /// <summary>
        /// 正转继电器
        /// </summary>
        [ControlUnit("正转继电器")]
        public bool Positive { get; set; }

        /// <summary>
        /// 反转继电器
        /// </summary>
        [ControlUnit("反转继电器")]
        public bool Reverse { get; set; }


        /// <summary>
        /// 综合计算值
        /// </summary>
        public int Value { get; set; }

        public int GetValue()
        {
            if (Positive && Reverse)
            {
                throw new ArgumentException("提供的参数值存在计算错误");
            }

            if (Positive) return (int) Hold_Three_ControlCommandEnum.Positive;
            if (Reverse) return (int) Hold_Three_ControlCommandEnum.Reverse;
            return (int) Hold_Three_ControlCommandEnum.Stop;
        }
    }
}