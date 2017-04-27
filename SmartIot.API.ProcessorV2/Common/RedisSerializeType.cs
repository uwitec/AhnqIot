#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： SmartIot.API.ProcessorV2
// FILENAME   ： RedisSerializeType.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-02-27 0:04
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

using Smart.Redis;

namespace SmartIot.API.ProcessorV2.Common
{
    public class RedisSerializeType
    {
        public const DataType DataType = Smart.Redis.DataType.Protobuf;
    }
}