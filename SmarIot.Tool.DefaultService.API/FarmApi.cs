#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ：SmartIot.Tool.DefaultService.API
// FILENAME   ： FarmApio.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 22:22
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Common;
using SmartIot.Api.Protocal.Formatter;
using SmartIot.Api.Protocal.Meta;
using SmartIot.Api.Protocal.Meta.Model;
using SmartIot.Api.Protocal.Meta.Request.DataContent;
using SmartIot.Api.Protocal.Meta.Request.DataContent.QueryDataRequest;
using SmartIot.Tool.API.Common;
using SmartIot.Tool.API.Core;
using SmartIot.Tool.API.Transport;
using NewLife.Configuration;
using NewLife.Log;
using NewLife.Model;
using System;
using System.Collections.Generic;
using SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest;

namespace SmartIot.Tool.DefaultService.API
{
    public class FarmApi : ApiBase, IFarmApi
    {
        /// <summary>
        /// 获取基地下所有设施
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transport"></param>
        /// <returns></returns>
        public IEnumerable<FacilityModel> GetFacilities(AwEntity entity, IApiTransport transport)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            Guard(entity);

            //entity.Description = "获取所有设施类型";
            entity.Description = "获取所有设施";
            entity.DataBlockObject.DataContentRequest.QueryDataBlock = new QueryDataBlock()
            {
                FarmCode = new QueryFacilitys() {Farm = entity.DataBlockObject.Source.FarmCode}
            };

            var response = transport.Process(entity);
            if (response.Success != ErrorType.NoError) return new List<FacilityModel>();
            if (response.Data == null || response.Data.QueryFacilitys == null) return new List<FacilityModel>();
            try
            {
                string str = response.Data.QueryFacilitys.ToString();
                var ie =
                    ObjectContainer.Current.Resolve<FormatterBase>(DataProtocalType.Json.ToString())
                        .Deserialize<IEnumerable<FacilityModel>>(str);
                return ie;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }
            return new List<FacilityModel>();
        }

        public bool UploadFarmStatus(AwEntity entity, IApiTransport transport, FarmStatus fs)
        {
            if (transport == null) throw new ArgumentNullException(nameof(transport));
            Guard(entity);

            entity.Description = "上传基地运行记录";
            entity.DataBlockObject.DataContentRequest.RuntimeDataBlock = new RuntimeDataBlock() {UploadFarmStatus = fs};

            var response = transport.Process(entity);
            return (response.Success == ErrorType.NoError);
        }

        private IApiTransport GetTransport()
        {
            var apiUri = Config.GetConfig("ApiUri", "");
            IApiTransport transport;
            if (apiUri.StartsWith("http"))
            {
                transport = new HttpTransport();
            }
            else // if (apiUri.StartsWith("Tcp"))
            {
                transport = new SocketTransport();
            }

            var arr = apiUri.Split(new char[] {':', '/'}, StringSplitOptions.RemoveEmptyEntries);
            transport.Init(arr[1], Convert.ToInt32(arr[2]));

            return transport;
        }
    }
}