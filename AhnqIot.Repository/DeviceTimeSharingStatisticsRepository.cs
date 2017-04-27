using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
   public class DeviceTimeSharingStatisticsRepository
    {
        public IEnumerable<DeviceTimeSharingStatistics> GetByDeviceSerialnumAndTimeAndPeriod(string deviceSerialnum,int period,DateTime? startTime,DateTime? endTime)
        {
            if (String.IsNullOrWhiteSpace(deviceSerialnum)) throw new ArgumentNullException("deviceSerialnum");
            if (!startTime.HasValue) startTime = DateTime.Today;
            if (!endTime.HasValue) endTime = DateTime.Today.AddDays(1);
            return DeviceTimeSharingStatistics.FindAllByArgs(deviceSerialnum, period, startTime, endTime);
        }
     
    }
}
