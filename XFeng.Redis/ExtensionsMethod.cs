#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： ExtensionsMethod.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Smart.Redis
{
    public static class BeetleRedisExtensionsMethod
    {
        public static string GetString(this ArraySegment<byte> data)
        {
            return Utils.GetString(data);
        }

        public static T GetProtobuf<T>(this ArraySegment<byte> data)
        {
            return (T) Utils.GetProtobuf(data, typeof (T));
        }

        public static object GetProtobuf(this ArraySegment<byte> data, Type type)
        {
            return Utils.GetProtobuf(data, type);
        }

        public static IList<object> FieldValueToList(this IEnumerable<Field> items)
        {
            var result = new List<object>();
            foreach (var item in items)
            {
                result.Add(item.Value);
            }
            return result;
        }
    }

    public static class BeetleRedisGetExtensionsMethod
    {
        public static RedisKey RedisString(this IEnumerable<string> key)
        {
            return new StringKey(key.ToArray());
        }

        public static RedisKey RedisProtobuf(this IEnumerable<string> key)
        {
            return new ProtobufKey(key.ToArray());
        }

        public static RedisKey RedisString(this string key)
        {
            return new StringKey(key);
        }

        public static RedisKey RedisProtobuf(this string key)
        {
            return new ProtobufKey(key);
        }
    }
}