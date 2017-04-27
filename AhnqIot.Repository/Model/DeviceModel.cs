using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository.Model
{
 public  class DeviceModel
    {
        /// <summary>编码</summary>
        public String Serialnum { get; set; }

        /// <summary>名称</summary>
        public String Name { get; set; }

        /// <summary>设施编码</summary>
        public String FacilitySerialnum { get; set; }

        /// <summary>设备类型</summary>
        public String DeviceTypeSerialnum { get; set; }

        /// <summary>处理值</summary>
        public Decimal ProcessedValue { get; set; }

        /// <summary>显示值</summary>
        public String ShowValue { get; set; }

        /// <summary>上限</summary>
        public Decimal? Max { get; set; }

        /// <summary>下限</summary>
        public Decimal? Min { get; set; }

        /// <summary>单位</summary>
        public String Unit { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
