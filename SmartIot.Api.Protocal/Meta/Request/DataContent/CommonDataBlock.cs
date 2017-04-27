#region Code File Comment

// SOLUTION   ： SmartIot
// PROJECT    ： SmartIot.Api.Protocal
// FILENAME   ： CommonDataBlock.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 11:30
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

using System.Collections.Generic;
using System.Xml.Serialization;
using SmartIot.Api.Protocal.Meta.Request.DataContent.ManageDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.QueryDataRequest;
using SmartIot.Api.Protocal.Meta.Request.DataContent.RuntimeDataRequest;
using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Meta.Request.DataContent
{
    /// <summary>
    /// 基础数据块
    /// </summary>
    [XmlRoot("基础数据块")]
    [JsonObject("基础数据块", IsReference = false)]
    public class CommonDataBlock
    {
    }
}