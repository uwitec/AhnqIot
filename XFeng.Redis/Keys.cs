#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： Keys.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Smart.Redis
{
    /// <summary>
    ///     String类型操作
    /// </summary>
    public abstract class RedisKey
    {
        private readonly bool _mIsSingleKey = true;

        /// <summary>
        ///     构造方法
        /// </summary>
        /// <param name="datakey">单个key</param>
        /// <param name="dtype">数据类型</param>
        public RedisKey(string datakey, DataType dtype)
        {
            DataKey = datakey;
            DataType = dtype;
            _mIsSingleKey = true;
        }

        /// <summary>
        ///     构造方法
        /// </summary>
        /// <param name="datakey">key列表</param>
        /// <param name="dtype">数据类型</param>
        public RedisKey(IEnumerable<string> datakey, DataType dtype)
        {
            DataKey = datakey;
            DataType = dtype;
            _mIsSingleKey = false;
        }

        protected object DataKey { get; set; }

        private string[] GetKeys
        {
            get { return ((IEnumerable<string>) DataKey).ToArray(); }
        }

        protected DataType DataType { get; }

        /// <summary>
        ///     删除一个key
        /// </summary>
        public void Delete(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            if (_mIsSingleKey)
                db.Delete((string) DataKey);
            else
                db.Delete(GetKeys);
        }

        /// <summary>
        ///     设置一个key的过期时间
        /// </summary>
        /// <param name="time">过期时间，以秒为单位</param>
        /// <param name="db"></param>
        public void Expire(long time, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            db.Expire((string) DataKey, time);
        }

        /// <summary>
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int TTL(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.TTL((string) DataKey);
        }

        /// <summary>
        ///     随机获取一个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象</returns>
        public T RandKey<T>(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.RandomKey<T>();
        }

        /// <summary>
        ///     获取所有的key的列表。
        /// </summary>
        /// <returns>返回的是key的列表，注意：键名可以用通配符，比如说：* 匹配数据库中所有 key，具体信息请查看：http://www.redisdoc.com/en/latest/key/keys.html</returns>
        [Obsolete("KEYS的速度非常快，但在一个大的数据库中使用它仍然可能造成性能问题，如果你需要从一个数据集中查找特定的key，你最好还是用集合(Set)。")]
        public IList<string> Keys(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Keys((string) DataKey);
        }

        /// <summary>
        ///     获取当前redis服务器的时间
        /// </summary>
        /// <returns>一个包含两个字符串的列表： 第一个字符串是当前时间(以 UNIX 时间戳格式表示)，而第二个字符串是当前这一秒钟已经逝去的微秒数。</returns>
        public List<string> Time(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Time();
        }

        /// <summary>
        ///     返回key所关联
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象</returns>
        public T Get<T>(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Get<T>((string) DataKey, DataType);
        }

        public T GetSet<T>(object value, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.GetSet<T>((string) DataKey, value, DataType);
        }

        /// <summary>
        ///     设置一个对象
        /// </summary>
        /// <param name="value">对象</param>
        public void Set(object value, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            db.Set((string) DataKey, value, DataType);
        }

        /// <summary>
        ///     检查给定 key 是否存在
        /// </summary>
        /// <returns></returns>
        public bool Exists(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Exists((string) DataKey) > 0;
        }

        /// <summary>
        ///     将 key 改名为 newkey (当 key 和 newkey 相同，或者 key 不存在时，返回一个错误。)
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public bool Rename(object value, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Rename((string) DataKey, value, DataType);
        }


        /// <summary>
        ///     设置一个对象
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="seconds">EX second ：设置键的过期时间为 second 秒。 SET key value EX second 效果等同于 SETEX key second value</param>
        /// <param name="milliseconds">
        ///     PX millisecond ：设置键的过期时间为 millisecond 毫秒。 SET key value PX millisecond 效果等同于 PSETEX key
        ///     millisecond value
        /// </param>
        /// <param name="ExistSet">是否只在键已经存在时，才对键进行设置操作</param>
        public void Set(object value, long? seconds, long? milliseconds, bool? ExistSet, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            db.Set((string) DataKey, value, seconds, milliseconds, ExistSet, DataType);
        }

        /// <summary>
        ///     将key中储存的数字值增一
        /// </summary>
        /// <returns>执行INCR命令之后key的值</returns>
        public int Incr(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Incr((string) DataKey);
        }

        /// <summary>
        ///     将 key 所储存的值加上增量 increment
        /// </summary>
        /// <param name="increment">增量</param>
        /// <returns>执行INCR命令之后key的值</returns>
        public long Incrby(long increment, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Incrby((string) DataKey, increment);
        }

        public void SetValues(params object[] values)
        {
            SetValues(values, null);
        }

        public void SetValues(object[] values, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            var kvs = new List<Field>();
            var keys = GetKeys;
            var count = keys.Length > values.Length ? values.Length : keys.Length;
            for (var i = 0; i < count; i++)
                kvs.Add(new Field {Value = values[i], Name = keys[i]});
            db.MSet(kvs.ToArray(), DataType);
        }

        /// <summary>
        ///     将key中储存的数字值减一
        /// </summary>
        /// <returns>执行DECR命令之后key的值</returns>
        public int Decr(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Decr((string) DataKey);
        }

        /// <summary>
        ///     同时设置一个或多个key-value对
        /// </summary>
        /// <param name="values">value数组</param>
        public void MSetValues(object[] values, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            var kvs = new List<Field>();
            var keys = GetKeys;
            var count = keys.Length > values.Length ? values.Length : keys.Length;
            for (var i = 0; i < count; i++)
                kvs.Add(new Field {Value = values[i], Name = keys[i]});
            db.MSet(kvs.ToArray(), DataType);
        }

        public IList<object> Get(Type[] types, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Get(types, GetKeys, DataType);
        }

        public IList<object> Get<T, T1>(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Get(new Type[] {typeof (T), typeof (T1)}, GetKeys, DataType);
        }

        public IList<object> Get<T, T1, T2>(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Get(new Type[] {typeof (T), typeof (T1), typeof (T2)}, GetKeys, DataType);
        }

        public IList<object> Get<T, T1, T2, T3>(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Get(new Type[] {typeof (T), typeof (T1), typeof (T2), typeof (T3)}, GetKeys, DataType);
        }

        public IList<object> Get<T, T1, T2, T3, T4>(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Get(new Type[] {typeof (T), typeof (T1), typeof (T2), typeof (T3), typeof (T4)}, GetKeys, DataType);
        }
    }

    /// <summary>
    ///     创建一个以key为名称的String类型的键(主要用于普通的string类型数据)
    /// </summary>
    public class StringKey : RedisKey
    {
        public StringKey(string key)
            : base(key, DataType.String)
        {
        }

        public StringKey(params string[] key)
            : base(key, DataType.String)
        {
        }

        public static implicit operator StringKey(string key)
        {
            return new StringKey(key);
        }

        public static implicit operator StringKey(string[] keys)
        {
            return new StringKey(keys);
        }
    }

    /// <summary>
    ///     创建一个以key为名称的String类型的键(主要用于经过Protobuf编码过的对象)
    /// </summary>
    public class ProtobufKey : RedisKey
    {
        public ProtobufKey(string key)
            : base(key, DataType.Protobuf)
        {
        }

        public ProtobufKey(params string[] key)
            : base(key, DataType.Protobuf)
        {
        }

        public static implicit operator ProtobufKey(string key)
        {
            return new ProtobufKey(key);
        }

        public static implicit operator ProtobufKey(string[] keys)
        {
            return new ProtobufKey(keys);
        }
    }

    public class JsonKey : RedisKey
    {
        public JsonKey(string key)
            : base(key, DataType.Json)
        {
        }

        public JsonKey(params string[] key)
            : base(key, DataType.Json)
        {
        }

        public static implicit operator JsonKey(string key)
        {
            return new JsonKey(key);
        }

        public static implicit operator JsonKey(string[] keys)
        {
            return new JsonKey(keys);
        }
    }
}