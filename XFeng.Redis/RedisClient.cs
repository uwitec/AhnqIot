//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Smart.Redis
//  FILENAME   ： RedisClient.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 15:01
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#region using namespace

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Smart.Redis.Config;

#endregion

namespace Smart.Redis
{
    public class RedisClient
    {
        public string ChannelName = string.Empty;

        public bool IsPattern = false;

        public Action<Exception> OnError;

        public Action<object, object> OnMessage;

        public Action<object[]> OnSuccess;

        public Action<object> OnUnSubscribe;

        #region 常用方法

        private void SelectDB(TcpClient client)
        {
            if (client.DB != DB)
            {
                client.DB = DB;
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SELECT);
                    cmd.Add(DB.ToString());
                    using (var result = TcpClient.Send(cmd, client))
                    {
                    }
                }
            }
        }

        #endregion

        /// <summary>
        ///     返回哈希表key中域的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns>哈希表中域的数量 当key不存在时，返回0</returns>
        public int HLen(string key)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HLEN);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     为给定key设置生存时间
        ///     当key过期时，它会被自动删除。
        ///     在Redis中，带有生存时间的key被称作“易失的”(volatile)。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="time"></param>
        /// <returns>
        ///     设置成功返回1。
        ///     当key不存在或者不能为key设置生存时间时(比如在低于2.1.3中你尝试更新key的生存时间)，返回0。
        /// </returns>
        public int Expire(string key, long time)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_EXPIRE);
                    cmd.Add(key);
                    cmd.Add(time.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     返回给定key的剩余生存时间(time to live)(以秒为单位)。
        /// </summary>
        /// <param name="key"></param>
        /// <returns>key的剩余生存时间(以秒为单位)。当key不存在或没有设置生存时间时，返回-1 。</returns>
        public int TTL(string key)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_TTL);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     返回当前服器时间
        /// </summary>
        /// <returns></returns>
        public List<string> Time()
        {
            List<string> r;
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_TIME);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        r = new List<string>(result.ResultDataBlock.Count);
                        foreach (var i in result.ResultDataBlock)
                        {
                            r.Add(i.GetString());
                        }
                    }
                }
            }
            return r;
        }

        /// <summary>
        ///     从当前数据库中随机返回(不删除)一个key。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>当数据库不为空时，返回一个key。当数据库为空时，返回nil。</returns>
        public T RandomKey<T>()
        {
            T t;
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_RANDOMKEY);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        t = (T)FromRedis(result.ResultDataBlock[0], DataType.String, typeof(T));
                    }
                }
            }
            return t;
        }

        public void Delete(IList<string> keys)
        {
            Delete(keys.ToArray());
        }

        /// <summary>
        ///     查找符合给定模式的key。
        /// </summary>
        /// <param name="match"></param>
        /// <returns>符合给定模式的key列表。</returns>
        [Obsolete("KEYS的速度非常快，但在一个大的数据库中使用它仍然可能造成性能问题，如果你需要从一个数据集中查找特定的key，你最好还是用集合(Set)。")]
        public List<string> Keys(string match)
        {
            List<string> r;
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_KEYS);
                    cmd.Add(match);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        r = new List<string>(result.ResultDataBlock.Count);
                        foreach (var i in result.ResultDataBlock)
                        {
                            r.Add(i.GetString());
                        }
                    }
                }
            }
            return r;
        }

        /// <summary>
        ///     返回列表key的长度。
        /// </summary>
        /// <param name="key"></param>
        /// <returns>列表key的长度。</returns>
        public int ListLength(string key)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_LLEN);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     移除并返回列表key的头元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <returns>列表的头元素</returns>
        public T LPop<T>(string key, DataType dtype)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_LPOP);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return (T)FromRedis(result.ResultDataBlock[0], dtype, typeof(T));
                    }
                }
            }
        }

        /// <summary>
        ///     移除并返回列表key的尾元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <returns>列表的尾元素。</returns>
        public T RPOP<T>(string key, DataType dtype)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_RPOP);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return (T)FromRedis(result.ResultDataBlock[0], dtype, typeof(T));
                    }
                }
            }
        }

        /// <summary>
        ///     将一个或多个值value插入到列表key的表头
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dtype"></param>
        /// <returns>执行LPUSH命令后，列表的长度</returns>
        public int LPUSH(string key, object value, DataType dtype)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_LPUSH);
                    cmd.Add(key);
                    ToRedis(value, dtype, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     将列表key下标为index的元素的值设置为value。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="dtype"></param>
        /// <returns>操作成功返回ok，否则返回错误信息。</returns>
        public string SetListItem(string key, int index, object value, DataType dtype)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_LSET);
                    cmd.Add(key);
                    cmd.Add(index.ToString());
                    ToRedis(value, dtype, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return result.ResultData.ToString();
                    }
                }
            }
        }

        /// <summary>
        ///     将一个或多个值value插入到列表key的表尾。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public int RPush(string key, object value, DataType dtype)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_RPUSH);
                    cmd.Add(key);
                    ToRedis(value, dtype, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     返回列表key中指定区间内的元素，区间以偏移量start和stop指定。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public IList<T> ListRange<T>(string key, int start, int end, DataType dtype)
        {
            //string cachekey = $"{key}_list_{start}_{end}";
            using (var c = GetReader())
            {
                IList<T> lst = new List<T>();
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_LRANGE);
                    cmd.Add(key);
                    cmd.Add(start.ToString());
                    cmd.Add(end.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        foreach (var item in result.ResultDataBlock)
                        {
                            lst.Add((T)FromRedis(item, dtype, typeof(T)));
                        }
                    }
                }
                return lst;
            }
        }

        /// <summary>
        ///     返回列表key中指定区间内的元素，区间以偏移量start和stop指定。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public IList<T> ListRange<T>(string key, DataType dtype)
        {
            return ListRange<T>(key, 0, -1, dtype);
        }

        /// <summary>
        ///     返回列表key中，下标为index的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public T GetListItem<T>(string key, int index, DataType dtype)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_LINDEX);
                    cmd.Add(key);
                    cmd.Add(index.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return (T)FromRedis(result.ResultDataBlock[0], dtype, typeof(T));
                    }
                }
            }
        }

        /// <summary>
        ///     返回哈希表key中，一个或多个给定域的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <param name="type"></param>
        /// <returns>一个包含多个给定域的关联值的表，表值的排列顺序和给定域参数的请求顺序一样。</returns>
        public IList<T> HashGetFields<T>(string key, NameType[] fields, DataType type)
        {
            var result = GetResultSpace<T>(fields.Length);
            NameType item;
            using (var c = GetReader())
            {
                var inputs = new List<NameType>();
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HMGET);
                    cmd.Add(key);
                    for (var i = 0; i < fields.Length; i++)
                    {
                        item = fields[i];
                        inputs.Add(item);
                        item.Index = i;
                        cmd.Add(item.Name);
                    }
                    using (var r = TcpClient.Send(cmd, c.Client))
                    {
                        for (var i = 0; i < inputs.Count; i++)
                        {
                            item = inputs[i];
                            result[item.Index] = (T)FromRedis(r.ResultDataBlock[i], type, typeof(T));
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     返回哈希表key中给定域field的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns>给定域的值。</returns>
        public T HashGet<T>(string key, string name, DataType type)
        {
            T t;
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HGET);
                    cmd.Add(key);
                    cmd.Add(name);
                    using (var r = TcpClient.Send(cmd, c.Client))
                    {
                        t = (T)FromRedis(r.ResultDataBlock[0], type, typeof(T));
                    }
                }
            }
            return t;
        }


        /// <summary>
        ///     返回哈希表key中，所有的域和值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns>以列表形式返回哈希表的域和域的值。 若key不存在，返回空列表。</returns>
        public List<Field> HashGetAll<T>(string key, DataType type)
        {
            var result = new List<Field>();
            var k = "";
            using (var c = GetReader())
            {
                //var inputs = new List<NameType>();
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HGETALL);
                    cmd.Add(key);
                    using (var r = TcpClient.Send(cmd, c.Client))
                    {
                        if (r.ResultDataBlock.Count > 0)
                            for (var i = 0; i < r.ResultDataBlock.Count; i++)
                            {
                                if (i % 2 == 0)
                                    k = (string)FromRedis(r.ResultDataBlock[i], DataType.String, Type.GetType(k));
                                else
                                {
                                    var value = FromRedis(r.ResultDataBlock[i], type, typeof(T));
                                    var item = new Field { Name = k, Value = value };
                                    result.Add(item);
                                }
                            }
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     检查给定key是否存在。
        /// </summary>
        /// <param name="key"></param>
        /// <returns>若key存在，返回1，否则返回0。</returns>
        public int Exists(string key)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_EXISTS);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     查看哈希表key中，给定域field是否存在。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="type"></param>
        /// <returns>
        ///     如果哈希表含有给定域，返回1。
        ///     如果哈希表不含有给定域，或key不存在，返回0。
        /// </returns>
        public int HashFieldExists(string key, string field, DataType type)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HEXISTS);
                    cmd.Add(key);
                    cmd.Add(field);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     返回哈希表key中的所有域。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<string> HashGetAllFields(string key, DataType type)
        {
            var result = new List<string>();
            var value = "";
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HKEYS);
                    cmd.Add(key);
                    using (var r = TcpClient.Send(cmd, c.Client))
                    {
                        if (r.ResultDataBlock.Count > 0)
                        {
                            for (var i = 0; i < r.ResultDataBlock.Count; i++)
                            {
                                value = (string)FromRedis(r.ResultDataBlock[i], type, Type.GetType(value));
                                result.Add(value);
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     返回哈希表key中的所有值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<T> HashGetAllValues<T>(string key, DataType type)
        {
            var result = new List<T>();
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HVALS);
                    cmd.Add(key);
                    using (var r = TcpClient.Send(cmd, c.Client))
                    {
                        if (r.ResultDataBlock.Count > 0)
                        {
                            result.AddRange(r.ResultDataBlock.Select(t => (T)FromRedis(t, type, typeof(T))));
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        ///     返回所有(一个或多个)给定key的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="key"></param>
        /// <param name="key1"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<object> Get<T, T1>(string key, string key1, DataType type)
        {
            return Get(new[] { typeof(T), typeof(T1) }, new[] { key, key1 }, type);
        }

        /// <summary>
        ///     返回所有(一个或多个)给定key的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="key"></param>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<object> Get<T, T1, T2>(string key, string key1, string key2, DataType type)
        {
            return Get(new[] { typeof(T), typeof(T1), typeof(T2) }, new[] { key, key1, key2 }, type);
        }

        /// <summary>
        ///     返回所有(一个或多个)给定key的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="key"></param>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="key3"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<object> Get<T, T1, T2, T3>(string key, string key1, string key2, string key3, DataType type)
        {
            return Get(new[] { typeof(T), typeof(T1), typeof(T2), typeof(T3) },
                new[] { key, key1, key2, key3 }, type);
        }

        /// <summary>
        ///     返回所有(一个或多个)给定key的值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="key"></param>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <param name="key3"></param>
        /// <param name="key4"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<object> Get<T, T1, T2, T3, T4>(string key, string key1, string key2, string key3, string key4,
            DataType type)
        {
            return Get(new[] { typeof(T), typeof(T1), typeof(T2), typeof(T3), typeof(T4) },
                new[] { key, key1, key2, key3, key4 }, type);
        }

        /// <summary>
        ///     返回所有(一个或多个)给定key的值。
        /// </summary>
        /// <param name="types"></param>
        /// <param name="keys"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public IList<object> Get(Type[] types, string[] keys, DataType dtype)
        {
            using (var c = GetReader())
            {
                var result = GetResultSpace<object>(keys.Length);
                var _types = new List<NameType>();
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_MGET);
                    for (var i = 0; i < keys.Length; i++)
                    {
                        var key = keys[i];
                        cmd.Add(key);
                        _types.Add(new NameType(keys[i], i));
                    }
                    using (var r = TcpClient.Send(cmd, c.Client))
                    {
                        for (var i = 0; i < _types.Count; i++)
                        {
                            var item = FromRedis(r.ResultDataBlock[i], dtype, null);
                            result[_types[i].Index] = item;
                        }
                    }
                }
                return result;
            }
        }

        private List<T> GetResultSpace<T>(int count)
        {
            var result = new List<T>(count);
            for (var i = 0; i < count; i++)
            {
                result.Add(default(T));
            }
            return result;
        }

        /// <summary>
        ///     返回key所关联的字符串值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return Get<string>(key, DataType.String);
        }

        /// <summary>
        ///     返回key所关联的字符串值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public T Get<T>(string key, DataType type)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_GET);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            var value = (T)FromRedis(result.ResultDataBlock[0], type, typeof(T));
                            return value;
                        }
                    }
                }
                return default(T);
            }
        }

        /// <summary>
        ///     将给定key的值设为value，并返回key的旧值。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetSet(string key, object value)
        {
            return GetSet<string>(key, value, DataType.String);
        }

        /// <summary>
        ///     将给定key的值设为value，并返回key的旧值。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public T GetSet<T>(string key, object value, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_GETSET);
                    cmd.Add(key);

                    ToRedis(value, type, cmd);

                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            var oldvalue = (T)FromRedis(result.ResultDataBlock[0], type, typeof(T));
                            return oldvalue;
                        }
                    }
                }
                return default(T);
            }
        }

        /// <summary>
        ///     同时将多个field - value(域-值)对设置到哈希表key中。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string SetFields(string key, string name, object value, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HMSET);
                    cmd.Add(key);
                    cmd.Add(name);
                    ToRedis(value, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return result.ResultData.ToString();
                    }
                }
            }
        }

        /// <summary>
        ///     将哈希表key中的域field的值设为value。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int HashSetFieldValue(string key, string field, object value, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HSET);
                    cmd.Add(key);
                    cmd.Add(field);
                    ToRedis(value, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     将哈希表key中的域field的值设置为value，当且仅当域field不存在。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        /// <param name="type"></param>
        /// <returns>设置成功，返回1。如果给定域已经存在且没有操作被执行，返回0。</returns>
        public int HashSetFieldValueNx(string key, Field item, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HSETNX);
                    cmd.Add(key);
                    cmd.Add(item.Name);
                    ToRedis(item.Value, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     同时设置一个或多个key-value对。
        /// </summary>
        /// <param name="kValues"></param>
        /// <param name="dtype"></param>
        public void MSet(Field[] kValues, DataType dtype)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_MSET);
                    foreach (var item in kValues)
                    {
                        cmd.Add(item.Name);
                        ToRedis(item.Value, dtype, cmd);
                    }
                    using (TcpClient.Send(cmd, c.Client))
                    {
                    }
                }
            }
        }

        /// <summary>
        ///     将key中储存的数字值增一。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Incr(string key)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_INCR);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     将key所储存的值加上增量increment。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public long Incrby(string key, long increment)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_INCRBY);
                    cmd.Add(key);
                    cmd.Add(increment.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return long.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     将key中储存的数字值减一。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Decr(string key)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_DECR);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     将key所储存的值减去减量decrement。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="decrement"></param>
        /// <returns></returns>
        public long DecrBy(string key, long decrement)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_DECRBY);
                    cmd.Add(key);
                    cmd.Add(decrement.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return long.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     将字符串值value关联到key。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public void Set(string key, object value, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SET);
                    cmd.Add(key);

                    ToRedis(value, type, cmd);
                    using (TcpClient.Send(cmd, c.Client))
                    {
                    }
                }
            }
        }

        /// <summary>
        ///     将字符串值value关联到key。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        /// <param name="existSet"></param>
        /// <param name="type"></param>
        public void Set(string key, object value, long? seconds, long? milliseconds, bool? existSet, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SET);
                    cmd.Add(key);
                    ToRedis(value, type, cmd);
                    if (seconds != null && seconds > 0)
                    {
                        cmd.Add("EX");
                        cmd.Add(seconds.ToString());
                    }
                    if (milliseconds != null && milliseconds > 0)
                    {
                        cmd.Add("PX");
                        cmd.Add(milliseconds.ToString());
                    }
                    if (existSet != null)
                        cmd.Add(Convert.ToBoolean(existSet) ? "XX" : "NX");
                    using (TcpClient.Send(cmd, c.Client))
                    {
                    }
                }
            }
        }

        /// <summary>
        ///     将key改名为newkey。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Rename(string key, object value, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_RENAME);
                    cmd.Add(key);

                    ToRedis(value, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return result.ResultData.ToString().Contains("OK");
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///     将一个或多个member元素及其score值加入到有序集key当中。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sorts"></param>
        /// <param name="dtype"></param>
        /// <returns>被成功添加的新成员的数量，不包括那些被更新的、已经存在的成员。</returns>
        public int Zadd(string key, IEnumerable<SortField> sorts, DataType dtype)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZADD);
                    cmd.Add(key);
                    foreach (var item in sorts)
                    {
                        cmd.Add(item.Name.ToString());
                        ToRedis(item.Value, dtype, cmd);
                    }
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     返回有序集key的基数。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Zcard(string key)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZCARD);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     返回有序集key中，score值在min和max之间(默认包括score值等于min或max)的成员。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int Zcount(string key, int min, int max)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZCOUNT);
                    cmd.Add(key);
                    cmd.Add(min.ToString());
                    cmd.Add(max.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     返回有序集key中，指定区间内的成员。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public HashSet<string> Zrange(string key, int start, int stop, DataType type)
        {
            HashSet<string> sets = null;
            var value = "";
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZRANGE);
                    cmd.Add(key);
                    cmd.Add(start.ToString());
                    cmd.Add(stop.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            sets = new HashSet<string>();
                            foreach (var currentdata in result.ResultDataBlock)
                            {
                                value = (string)FromRedis(currentdata, type, Type.GetType(value));
                                sets.Add(value);
                            }
                        }
                    }
                }
            }
            return sets;
        }

        /// <summary>
        ///     返回有序集key中，所有score值介于min和max之间(包括等于min或max)的成员。有序集成员按score值递增(从小到大)次序排列。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="min"></param>
        /// <param name="isIncludemin"></param>
        /// <param name="max"></param>
        /// <param name="isIncludemax"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public HashSet<T> ZrangeByScore<T>(string key, long min, bool isIncludemin, int max, bool isIncludemax,
            DataType type)
        {
            var hashSet = new HashSet<T>();
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZRANGEBYSCORE);
                    cmd.Add(key);
                    cmd.Add(isIncludemin ? "" : "(" + min);
                    cmd.Add(isIncludemax ? "" : "(" + max);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            foreach (var currentdata in result.ResultDataBlock)
                            {
                                var value = (T)FromRedis(currentdata, type, typeof(T));
                                hashSet.Add(value);
                            }
                        }
                    }
                }
            }
            return hashSet;
        }

        /// <summary>
        ///     返回有序集key中，指定区间内的成员。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public HashSet<string> Zrevrange(string key, int start, int stop, DataType type)
        {
            HashSet<string> sets = null;
            var value = "";
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZREVRANGE);
                    cmd.Add(key);
                    cmd.Add(start.ToString());
                    cmd.Add(stop.ToString());
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            sets = new HashSet<string>();
                            foreach (var currentdata in result.ResultDataBlock)
                            {
                                value = (string)FromRedis(currentdata, type, Type.GetType(value));
                                sets.Add(value);
                            }
                        }
                    }
                }
            }
            return sets;
        }

        /// <summary>
        ///     返回有序集key中成员member的排名。其中有序集成员按score值递增(从小到大)顺序排列。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public int Zrank(string key, string member)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZRANK);
                    cmd.Add(key);
                    cmd.Add(member);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     返回有序集key中成员member的排名。其中有序集成员按score值递减(从大到小)排序。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public int Zrevrank(string key, string member)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZREVRANK);
                    cmd.Add(key);
                    cmd.Add(member);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     移除有序集key中的一个或多个成员，不存在的成员将被忽略。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        public void Zrem(string key, int member)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZREM);
                    cmd.Add(key);
                    cmd.Add(member.ToString());
                    using (TcpClient.Send(cmd, c.Client))
                    {
                    }
                }
            }
        }

        /// <summary>
        ///     返回有序集key中，成员member的score值。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public int Zscore(string key, string member)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_ZSCORE);
                    cmd.Add(key);
                    cmd.Add(member);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            var value = "";
                            value = (string)FromRedis(result.ResultDataBlock[0], DataType.String, Type.GetType(value));
                            return int.Parse(value);
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     将一个或多个member元素加入到集合key当中，已经存在于集合的member元素将被忽略。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="members"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Sadd<T>(string key, List<T> members, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SADD);
                    cmd.Add(key);
                    foreach (var member in members)
                        ToRedis(member, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     将member元素加入到集合key当中，已经存在于集合的member元素将被忽略。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Sadd<T>(string key, T member, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SADD);
                    cmd.Add(key);
                    ToRedis(member, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     返回集合key的基数(集合中元素的数量)。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Scard(string key)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SCARD);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     判断member元素是否是集合key的成员。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Sismember<T>(string key, T member, DataType type)
        {
            var r = 0;
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SISMEMBER);
                    cmd.Add(key);
                    ToRedis(member, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            r = int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return r > 0;
        }

        /// <summary>
        ///     返回集合key中的所有成员。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<T> Smember<T>(string key, DataType type)
        {
            List<T> sets = null;
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SMEMBERS);
                    cmd.Add(key);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            sets = new List<T>();
                            foreach (var currentdata in result.ResultDataBlock)
                            {
                                sets.Add((T)FromRedis(currentdata, type, typeof(T)));
                            }
                        }
                    }
                }
            }
            return sets;
        }

        /// <summary>
        ///     移除集合key中的一个或多个member元素，不存在的member元素会被忽略。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int Srem<T>(string key, T member, DataType type)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SREM);
                    cmd.Add(key);
                    ToRedis(member, type, cmd);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultData != null)
                        {
                            return int.Parse(result.ResultData.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        /// <summary>
        ///     返回或保存给定列表、集合、有序集合key中经过排序的元素。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="bYpattern"></param>
        /// <param name="geTpattern"></param>
        /// <param name="alpha"></param>
        /// <param name="storeDestination"></param>
        /// <param name="orderby"></param>
        /// <param name="type"></param>
        /// <param name="dtype"></param>
        /// <returns></returns>
        public IList<object> Sort(string key, int? offset, int? count, string bYpattern, string geTpattern, bool alpha,
            string storeDestination,
            SortOrderType orderby, Type type, DataType dtype)
        {
            var result = new List<object>();
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_SORT);
                    cmd.Add(key);
                    if (!string.IsNullOrEmpty(bYpattern))
                    {
                        cmd.Add("BY");
                        cmd.Add(bYpattern);
                    }
                    if (!string.IsNullOrEmpty(geTpattern))
                    {
                        cmd.Add("GET");
                        cmd.Add(geTpattern);
                    }
                    if (offset != null)
                    {
                        cmd.Add("LIMIT");
                        cmd.Add(offset.Value.ToString());
                        cmd.Add(count == null ? "1000" : count.Value.ToString());
                    }
                    if (alpha)
                    {
                        cmd.Add("alpha");
                    }
                    cmd.Add(Enum.GetName(typeof(SortOrderType), orderby));
                    if (!string.IsNullOrEmpty(storeDestination))
                    {
                        cmd.Add("STORE");
                        cmd.Add(storeDestination);
                    }
                    using (var rd = TcpClient.Send(cmd, c.Client))
                    {
                        foreach (var item in rd.ResultDataBlock)
                        {
                            result.Add(FromRedis(item, dtype, type));
                        }
                    }
                }
            }
            return result;
        }

        private void ToRedis(object value, DataType type, Command cmd)
        {
            if (type == DataType.String)
            {
                cmd.Add((string)value);
            }
            else
            {
                cmd.AddProtobuf(value);
            }
        }

        private object FromRedis(ArraySegment<byte> data, DataType type, Type otype)
        {
            if (type == DataType.String)
            {
                return data.GetString();
            }
            else
            {
                try
                {
                    return data.GetProtobuf(otype);
                }
                catch (Exception exception)
                {
                    throw new Exception($"{otype} type get error!", exception);
                }
            }
        }

        #region 订阅与发布

        /// <summary>
        /// 发布消息到指定频道
        /// </summary>
        /// <param name="channel">频道</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object Publish(string channel, string message)
        {
            try
            {
                using (var c = GetWriter())
                {
                    using (var cmd = new Command())
                    {
                        cmd.Add(ConstValues.REDIS_COMMAND_PUBLISH);
                        cmd.Add(channel);
                        cmd.Add(message);
                        using (var result = TcpClient.Send(cmd, c.Client))
                        {
                            if (result.ResultData != null)
                            {
                                return result.ResultData.ToString();
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Publish:{0}", ex);
            }
        }

        public void Subscribe(string channelName)
        {
            try
            {
                using (var c = GetWriter())
                {
                    using (var cmd = new Command())
                    {
                        cmd.Add(ConstValues.REDIS_COMMAND_SUBSCRIBE);
                        cmd.Add(channelName);
                        using (TcpClient.Send(cmd, c.Client))
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Subscribe:{0}", ex);
            }
        }

        public void PSubscribe(string channelName)
        {
            Init(channelName);
            IsPattern = true;
            var thread = new Thread(() => CheckSubscribe(IsPattern));
            thread.Start();
        }

        public void UnSubscribe(string channelName)
        {
            UnSubscribe();
        }

        public void UnPSubscribe(string channelName)
        {
            UnSubscribe();
        }

        private void Init(string channelName)
        {
            ChannelName = channelName;
        }

        private void Run(bool isPattern = false)
        {
            Result repy;
            if (isPattern)
            {
                using (var c = GetWriter())
                {
                    using (var cmd = new Command())
                    {
                        cmd.Add(ConstValues.REDIS_COMMAND_PSUBSCRIBE);
                        cmd.Add(ChannelName);
                        repy = TcpClient.Send(cmd, c.Client);
                        while (true)
                        {
                            if (repy.ResultData is object[])
                            {
                                var val = repy.ResultData as object[];
                                if (val[0].ToString().ToLower().Contains("unsubscribe"))
                                {
                                    if (OnUnSubscribe != null)
                                        OnUnSubscribe(val);
                                    break;
                                }
                            }
                            if (OnMessage != null)
                                OnMessage(this, repy);
                        }
                    }
                }
            }
            else
            {
                using (var c = GetWriter())
                {
                    using (var cmd = new Command())
                    {
                        cmd.Add(ConstValues.REDIS_COMMAND_SUBSCRIBE);
                        cmd.Add(ChannelName);
                        repy = TcpClient.Send(cmd, c.Client);
                        while (true)
                        {
                            if (repy.ResultData is object[])
                            {
                                var val = repy.ResultData as object[];
                                if (val[0].ToString().ToLower().Contains("unsubscribe"))
                                {
                                    OnUnSubscribe?.Invoke(val);
                                    break;
                                }
                            }
                            OnMessage?.Invoke(this, repy);
                        }
                    }
                }
            }

            OnSuccess?.Invoke((object[])repy.ResultData);
        }

        private void CheckSubscribe(bool isPattern = false)
        {
            try
            {
                Run(isPattern);
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception exception)
            {
                if (OnError != null)
                    OnError(exception);
            }
        }

        private void UnSubscribe()
        {
            try
            {
                if (IsPattern)
                {
                    using (var c = GetWriter())
                    {
                        using (var cmd = new Command())
                        {
                            cmd.Add(ConstValues.REDIS_COMMAND_PUNSUBSCRIBE);
                            cmd.Add(ChannelName);
                            TcpClient.Send(cmd, c.Client);
                        }
                    }
                }
                else
                {
                    using (var c = GetWriter())
                    {
                        using (var cmd = new Command())
                        {
                            cmd.Add(ConstValues.REDIS_COMMAND_UNSUBSCRIBE);
                            cmd.Add(ChannelName);
                            TcpClient.Send(cmd, c.Client);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.Print("Hredis UnSubscribe:" + exception.Message);
            }
        }

        #endregion

        #region 属性

        private int _readHostIndex;

        private int _writeHostIndex;

        /// <summary>
        ///     Redis 读取服务器组
        /// </summary>
        public IList<RedisHost> ReadHosts { get; } = new List<RedisHost>();

        /// <summary>
        ///     Redis 写入服务器组
        /// </summary>
        public IList<RedisHost> WriteHosts { get; } = new List<RedisHost>();

        /// <summary>
        ///     默认客户端
        /// </summary>
        public static RedisClient DefaultDB { get; }

        public int DB { get; set; }

        #endregion

        #region 取得服务器

        /// <summary>
        ///     取得写入服务器
        /// </summary>
        /// <returns></returns>
        public RedisHost.ClientItem GetWriter()
        {
            RedisHost host;
            RedisHost.ClientItem client;
            for (var i = 0; i < WriteHosts.Count; i++)
            {
                host = WriteHosts[_writeHostIndex % WriteHosts.Count];
                if (host.Available)
                {
                    client = host.Pop();
                    SelectDB(client.Client);
                    return client;
                }
                else
                {
                    host.Detect();
                }
                _writeHostIndex++;
            }

            throw new Exception("write host not Available!");
        }

        /// <summary>
        ///     取得读取服务器
        /// </summary>
        /// <returns></returns>
        public RedisHost.ClientItem GetReader()
        {
            for (var i = 0; i < ReadHosts.Count; i++)
            {
                var host = ReadHosts[_readHostIndex % ReadHosts.Count];
                if (host.Available)
                {
                    var client = host.Pop();
                    SelectDB(client.Client);
                    return client;
                }
                else
                {
                    host.Detect();
                }
                _readHostIndex++;
            }
            throw new Exception("read host not Available!");
        }

        #endregion

        #region 默认构造

        /// <summary>
        ///     默认构造
        /// </summary>
        public RedisClient()
        {
            Init();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        private void Init()
        {
            if (RedisClientSeting.Current.SingleMode)
            {
                foreach (var hostStrings in RedisClientSeting.Current.RedisServer)
                {
                    WriteHosts.Add(new RedisHost(hostStrings.Host, hostStrings.Connections));
                    ReadHosts.Add(new RedisHost(hostStrings.Host, hostStrings.Connections));
                }
            }
            else
            {
                foreach (var hostStrings in RedisClientSeting.Current.Writes)
                {
                    WriteHosts.Add(new RedisHost(hostStrings.Host, hostStrings.Connections));
                }
                foreach (var hostStrings in RedisClientSeting.Current.Reads)
                {
                    ReadHosts.Add(new RedisHost(hostStrings.Host, hostStrings.Connections));
                }
            }

            DB = RedisClientSeting.Current.DbIndex;
        }

        /// <summary>
        ///     静态构造
        /// </summary>
        static RedisClient()
        {
            DefaultDB = new RedisClient();
        }

        /// <summary>
        ///     静态构造
        /// </summary>
        /// <param name="db">客户端</param>
        /// <returns></returns>
        public static RedisClient GetClient(RedisClient db)
        {
            return db ?? DefaultDB;
        }

        #endregion

        #region Delete

        /// <summary>
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public int Delete(params string[] keys)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_DEL);
                    foreach (var key in keys)
                    {
                        cmd.Add(key);
                    }
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        /// <summary>
        ///     删除哈希表key中的一个或多个指定域，不存在的域将被忽略。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns>被成功移除的域的数量，不包括被忽略的域。</returns>
        public int HDelete(string key, string field)
        {
            using (var c = GetWriter())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_HDEL);
                    cmd.Add(key);
                    cmd.Add(field);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        return int.Parse(result.ResultData.ToString());
                    }
                }
            }
        }

        #endregion


        public string Info(string para, DataType dtype)
        {
            using (var c = GetReader())
            {
                using (var cmd = new Command())
                {
                    cmd.Add(ConstValues.REDIS_COMMAND_INFO);
                    cmd.Add(para);
                    using (var result = TcpClient.Send(cmd, c.Client))
                    {
                        if (result.ResultDataBlock.Count > 0)
                        {
                            return FromRedis(result.ResultDataBlock[0], dtype, null).ToString();
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}