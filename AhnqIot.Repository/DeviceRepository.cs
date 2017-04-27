using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
    public class DeviceRepository
    {
        /// <summary>
        /// 根据设施编码获取设备
        /// </summary>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        public IEnumerable<Device> GetByFacilitySerialnum(string facilitySerialnum)
        {

            if (string.IsNullOrWhiteSpace(facilitySerialnum)) throw new ArgumentNullException("facilitySerialnum");
            return Device.FindAllByFacilitySerialnum(facilitySerialnum);
        }
        /// <summary>
        /// 根据设施编码获取TTS设备
        /// </summary>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        public IEnumerable<Device> GetTtsDeviceByFacilitySerialnum(string facilitySerialnum)
        {

            if (string.IsNullOrWhiteSpace(facilitySerialnum)) throw new ArgumentNullException("facilitySerialnum");
            try
            {
                var device = Device.FindAllByFacilitySerialnum(facilitySerialnum).ToList().Where(dev => dev.DeviceType.Serialnum.Contains("TTS") || dev.DeviceType.ParentSerialnum.Contains("TTS"));
                return device;
            }
            catch (Exception)
            {
                return null;
                // throw;
            }
        }
        /// <summary>
        /// 根据设施编码获取LED设备
        /// </summary>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        public IEnumerable<Device> GetLedDeviceByFacilitySerialnum(string facilitySerialnum)
        {

            if (string.IsNullOrWhiteSpace(facilitySerialnum)) throw new ArgumentNullException("facilitySerialnum");
            try
            {
                var device = Device.FindAllByFacilitySerialnum(facilitySerialnum).ToList().Where(dev => dev.DeviceType.Serialnum.Contains("LED") || dev.DeviceType.ParentSerialnum.Contains("LED"));
                return device;
            }
            catch (Exception)
            {
                return null;
                // throw;
            }
        }
        /// <summary>
        /// 根据设施编码获取采集设备
        /// </summary>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        public IEnumerable<Device> GetCollectDeviceByFacilitySerialnum(string facilitySerialnum)
        {

            if (string.IsNullOrWhiteSpace(facilitySerialnum)) throw new ArgumentNullException("facilitySerialnum");
            try
            {
                var device = Device.FindAllByFacilitySerialnum(facilitySerialnum).ToList().Where(dev => dev.DeviceType.Serialnum.Contains("collect") || dev.DeviceType.ParentSerialnum.Contains("collect"));
                return device;
            }
            catch (Exception)
            {
                return null;
               // throw;
            }
        }

        /// <summary>
        /// 根据设施编码获取控制设备
        /// </summary>
        /// <param name="facilitySerialnum">设施编码</param>
        /// <returns></returns>
        public IEnumerable<Device> GetControlDeviceByFacilitySerialnum(string facilitySerialnum)
        {

            if (string.IsNullOrWhiteSpace(facilitySerialnum)) throw new ArgumentNullException("facilitySerialnum");
            try
            {
                var device = Device.FindAllByFacilitySerialnum(facilitySerialnum).ToList().Where(dev => dev.DeviceType.Serialnum.Contains("control") || dev.DeviceType.ParentSerialnum.Contains("control"));
                return device;
            }
            catch (Exception)
            {
                return null;
                // throw;
            }
        }
        /// <summary>
        /// 根据设备编码更新设备数据
        /// </summary>
        /// <param name="deviceSerialnum"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateDeviceData(string deviceSerialnum, string value)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(deviceSerialnum)) throw new ArgumentNullException("deviceSerialnum");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value");
            var device = Device.FindBySerialnum(deviceSerialnum);
            if (device == null) result = false;
            try
            {
                device.ShowValue = value;
                device.Update();
                result = true;
            }
            catch (Exception ex)
            {

                //throw;
            }
            return result;
        }
        /// <summary>
        /// 根据设备编码删除采集设备
        /// </summary>
        /// <param name="serialnum">设备编码</param>
        /// <returns></returns>
        public bool DeleteCollectDeviceBySerialnum(string serialnum)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(serialnum)) throw new ArgumentNullException("serialnum");
            var device = Device.FindBySerialnum(serialnum);
            if (device == null) result = false;
            try
            {
                if (device.DeviceType.Serialnum.Contains("collect") || device.DeviceType.ParentSerialnum.Contains("collect"))
                {
                    device.Delete();
                    result = true;
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return result;
        }

        /// <summary>
        /// 根据设备编码删除控制设备
        /// </summary>
        /// <param name="serialnum">设备编码</param>
        /// <returns></returns>
        public bool DeleteControlDeviceBySerialnum(string serialnum)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(serialnum)) throw new ArgumentNullException("serialnum");
            var device = Device.FindBySerialnum(serialnum);
            if (device == null) result = false;
            try
            {
                if (device.DeviceType.Serialnum.Contains("control") || device.DeviceType.ParentSerialnum.Contains("control"))
                {
                    device.Delete();
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
