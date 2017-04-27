#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： RedisList.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace Smart.Redis
{
    public abstract class RedisList<T>
    {
        private readonly string mDataKey;

        private readonly DataType mDataType;

        public RedisList(string key, DataType dataType)
        {
            mDataType = dataType;
            mDataKey = key;
        }

        #region lst

        public int Count(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.ListLength((string) mDataKey);
        }

        public T Pop(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.LPop<T>((string) mDataKey, mDataType);
        }

        public T Remove(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.RPOP<T>((string) mDataKey, mDataType);
        }

        public void Add(T value, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            db.RPush((string) mDataKey, value, mDataType);
        }

        public void Push(T value, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            db.LPUSH((string) mDataKey, value, mDataType);
        }

        public IList<T> Range(int start, int end, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.ListRange<T>((string) mDataKey, start, end, mDataType);
        }

        public IList<T> Range(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.ListRange<T>((string) mDataKey, mDataType);
        }

        /// <summary>
        ///     返回列表key中，下标为index的元素。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItem(int index, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.GetListItem<T>((string) mDataKey, index, mDataType);
        }

        public void SetItem(int index, object value)
        {
            var db = RedisClient.GetClient(null);
            db.SetListItem((string) mDataKey, index, value, mDataType);
        }

        public void Clear(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            db.Delete(mDataKey);
        }

        #endregion
    }

    public class StringList : RedisList<string>
    {
        public StringList(string key)
            : base(key, DataType.String)
        {
        }

        public static implicit operator StringList(string key)
        {
            return new StringList(key);
        }
    }

    public class JsonList<T> : RedisList<T>
    {
        public JsonList(string key) : base(key, DataType.Json)
        {
        }

        public static implicit operator JsonList<T>(string key)
        {
            return new JsonList<T>(key);
        }
    }

    public class ProtobufList<T> : RedisList<T>
    {
        public ProtobufList(string key)
            : base(key, DataType.Protobuf)
        {
        }

        public static implicit operator ProtobufList<T>(string key)
        {
            return new ProtobufList<T>(key);
        }
    }
}