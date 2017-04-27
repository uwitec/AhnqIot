using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
    public class CompanyPicsRepository
    {
        /// <summary>
        ///根据企业编码、时间段和图片数量获取图片
        /// </summary>
        /// <param name="companySerialnum">企业编码</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="count">图片数量</param>
        /// <returns></returns>
        public IEnumerable<string> GetByCompanySerialnumAndTimeAndCount(string companySerialnum, DateTime startTime, DateTime endTime, int count)
        {
            if (String.IsNullOrWhiteSpace(companySerialnum)) throw new ArgumentNullException("companySerialnum");
            if (startTime==null) startTime = DateTime.Today;
            if (endTime == null) endTime = DateTime.Today.AddDays(1);
            return CompanyPics.GetPics(companySerialnum, startTime, endTime, count);
        }
    }
}
