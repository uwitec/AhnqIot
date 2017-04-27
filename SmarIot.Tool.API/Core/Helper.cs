using SmartIot.Api.Protocal.Meta;
using SmartIot.Tool.DefaultService.DB;
using System;

namespace SmartIot.Tool.API.Core
{
    public class AwEntityHelper
    {
        /// <summary>
        /// 构建AwEntity
        /// </summary>
        /// <returns></returns>
        public static AwEntity GetEntity(string farmcode, string description = null)
        {
            var entity = new AwEntity
            {
                Description = description,
                DataBlockObject = new DataBlockObject
                {
                    Source = new Source
                    {
                        FarmCode = farmcode,
                        FarmName = "",
                        FarmKey = Farm.FindByCode1(farmcode).Remark,
                        Lontitude = 106.72M,
                        Latitude = 26.57M
                    },
                    CreateTime = DateTime.Now,
                    DataContentRequest = new DataContentRequest()
                    {
                        //CommonData = new CommonData(),
                        //CollectData = new Api.Protocal.Meta.CollectData(),
                        //ControlData = new ControlData()
                    }
                },
                ValidationBlock = new ValidationBlock()
                {
                    Encrypt = new Encrypt() {Way = EncryptWay._3DES, Content = ""},
                    Verify = new Verify() {Key = "CRC16", Content = ""}
                }
            };

            return entity;
        }
    }
}