using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhnqIot.Dto
{
  public  class DeviceRunningStatisticsDto : BaseDto
    {
        public int AllCount { get; set; }
        public int DataExceptionCount { get; set; }
        public decimal DataExceptionPercent { get; set; }
        public int Day { get; set; }
        public string DeviceSerialnum { get; set; }
        public int Month { get; set; }
        public int ReceiveCount { get; set; }
        public decimal ReceivePercent { get; set; }
        public int Year { get; set; }
    }
}
