#region Code File Comment
// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： AwEntityProcessor.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-26 9:33
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016
#endregion

using System;
using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Meta;

namespace SmartIot.API.ProcessorV2
{
    public class AwEntityProcessor
    {


        public static XResponseMessage Process(AwEntity entity)
        {
            if(entity== null) throw new ArgumentNullException(nameof(entity));
            return null;
        }
    }
}