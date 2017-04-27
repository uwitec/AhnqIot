using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
    public class FacilityCameraRepository
    {
        /// <summary>
        /// 根据编码查找设施摄像机
        /// </summary>
        /// <param name="serialnum">摄像机编码</param>
        /// <returns></returns>
        public FacilityCamera GetBySerialnum(string serialnum)
        {
            if (string.IsNullOrWhiteSpace(serialnum)) throw new ArgumentNullException("serialnum");
            return FacilityCamera.FindBySerialnum(serialnum);
        }
        /// <summary>
        /// 根据设施编码查找设施摄像机
        /// </summary>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        public IEnumerable<FacilityCamera> GetByFacilitySerialnum(string facilitySerialnum)
        {
            if (string.IsNullOrWhiteSpace(facilitySerialnum)) throw new ArgumentNullException("facilitySerialnum");
            return FacilityCamera.FindAllByFacilitySerialnum(facilitySerialnum);
        }
        /// <summary>
        /// 添加设施摄像机
        /// </summary>
        /// <param name="camera">摄像机实体</param>
        /// <returns></returns>
        //public bool AddCamera(FacilityCamera camera)
        //{
        //    var result = false;
        //    try
        //    {
        //        var camDb = FacilityCamera.FindAllWithCache().ToList().FirstOrDefault(c => c.Serialnum.Equals(camera.Serialnum));
        //        if (camDb == null)
        //        {
        //            camDb = new FacilityCamera
        //            {
        //                Serialnum = camera.Serialnum,
        //                Name = camera.Name,
        //                FacilitySerialnum = camera.FacilitySerialnum,
        //                IP = camera.IP,
        //                DataPort = camera.DataPort,
        //                HttpPort = camera.HttpPort,
        //                UserID = camera.UserID,
        //                UserPwd = camera.UserPwd,
        //                Channel = camera.Channel,
        //                RtspPort = camera.RtspPort,
        //                Status = camera.Status
        //            };
        //            camDb.Save();
        //        }
        //        else
        //        {
        //            camDb.Name = camera.Name;
        //            camDb.FacilitySerialnum = camera.FacilitySerialnum;
        //            camDb.IP = camera.IP;
        //            camDb.DataPort = camera.DataPort;
        //            camDb.HttpPort = camera.HttpPort;
        //            camDb.UserID = camera.UserID;
        //            camDb.UserPwd = camera.UserPwd;
        //            camDb.Channel = camera.Channel;
        //            camDb.RtspPort = camera.RtspPort;
        //            camDb.Status = camera.Status;
        //            camDb.Update();
        //        }
        //        result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = false;
        //       // throw;
        //    }
        //    return result;
        //}
    }
}
