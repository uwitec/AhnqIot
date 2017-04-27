using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode;
using AhnqIot.Dal;

namespace AhnqIot.Repository
{
    public class DeviceControlCommandRepository
    {
        /// <summary>
        /// 根据设备编码获取设备控制指令
        /// </summary>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <returns></returns>
        public IEnumerable<DeviceControlCommand> GetByDeviceSerialnum(string deviceSerialnum)
        {
            if (String.IsNullOrWhiteSpace(deviceSerialnum)) throw new ArgumentNullException("deviceSerialnum");
            return DeviceControlCommand.FindAllByDeviceSerialnum(deviceSerialnum);
        }
        /// <summary>
        /// 添加设备控制指令
        /// </summary>
        /// <param name="deviceSerialnum">设备编码</param>
        /// <param name="command">指令</param>
        /// <returns></returns>
        public bool AddControlCommand(string deviceSerialnum,string command)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(deviceSerialnum)) throw new ArgumentNullException("deviceSerialnum");
            if (string.IsNullOrWhiteSpace(command)) throw new ArgumentNullException("command");
            try
            {
                var cc = new DeviceControlCommand {
                    DeviceSerialnum=deviceSerialnum,
                    CreateTime=DateTime.Now,
                    Command=command
                };
                cc.Save();
                result = true;
            }
            catch (Exception ex)
            {

                //result = false;
               // throw;
            }
            return result;
        }

    }
}
