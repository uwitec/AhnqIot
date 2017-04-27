using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Repository.Model
{
   public class DeviceDataModel
    {
        /// <summary>
        /// 设备编码
        /// </summary>
        public string Serialnum { get; set; }

        /// <summary>
        /// 设备原始值
        /// </summary>
        public Int32 OriginalData { get; set; }
        /// <summary>
        /// 设备处理值
        /// </summary>
        public decimal ProcessedValue { get; set; }
        /// <summary>
        /// 设备显示值
        /// </summary>
        public string ShowValue { get; set; }
        ///// <summary>上限</summary>
        //public Decimal? Max { get; set; }

        ///// <summary>下限</summary>
        //public Decimal? Min { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
