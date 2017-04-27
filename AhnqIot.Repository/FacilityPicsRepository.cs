using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
   public class FacilityPicsRepository
    {

        // <summary>
        ///根据摄像机预置点编码、时间段和图片数量获取图片
        /// </summary>
        /// <param name="fcpSerialnum">摄像机预置点编码</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="count">图片数量</param>
        /// <returns></returns>
        public IEnumerable<string> GetByCompanySerialnumAndTimeAndCount(string fcpSerialnum, DateTime startTime, DateTime endTime, int count)
        {
            if (String.IsNullOrWhiteSpace(fcpSerialnum)) throw new ArgumentNullException("fcpSerialnum");
            if (startTime == null) startTime = DateTime.Today;
            if (endTime == null) endTime = DateTime.Today.AddDays(1);
            return FacilityPics.GetPics(fcpSerialnum, startTime, endTime, count);
        }
        /// <summary>
        /// 添加设施图片
        /// </summary>
        /// <param name="cameraPresetPointSerialnum">摄像机预置点编码</param>
        /// <param name="picSerialnum">图片编码</param>
        /// <returns></returns>
        public bool AddFacilityPics(string cameraPresetPointSerialnum,string picSerialnum)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(cameraPresetPointSerialnum)) throw new ArgumentNullException("cameraPresetPointSerialnum");
            if (string.IsNullOrWhiteSpace(picSerialnum)) throw new ArgumentNullException("picSerialnum");
            try
            {
                var fp = new FacilityPics {
                    FacilityCameraPresetSerialnum=cameraPresetPointSerialnum,
                    PicSerialnum=picSerialnum

                };
                fp.Save();
                result = true;
            }
            catch (Exception ex)
            {

                //throw;
            }
            return result;
        }
    }
}
