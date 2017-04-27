#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： RedisSet.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.Collections.Generic;

#endregion

namespace Smart.Redis
{
    public abstract class RedisSet<T>
    {
        private readonly string mDataKey;

        private readonly DataType mDataType;

        public RedisSet(string key, DataType dataType)
        {
            mDataType = dataType;
            mDataKey = key;
        }

        public int Sadd<T>(T member)
        {
            return Sadds<T>(new List<T>() {member});
        }

        public int Sadds<T>(List<T> members, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Sadd<T>((string) mDataKey, members, mDataType);
        }

        public int Scard(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Scard((string) mDataKey);
        }

        public bool Sismember<T>(T member, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Sismember<T>((string) mDataKey, member, mDataType);
        }

        public List<T> Smember<T>(RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Smember<T>((string) mDataKey, mDataType);
        }

        public int Srem<T>(T member, RedisClient db = null)
        {
            db = RedisClient.GetClient(db);
            return db.Srem<T>((string) mDataKey, member, mDataType);
        }
    }

    public class StringSet : RedisSet<string>
    {
        public StringSet(string key)
            : base(key, DataType.String)
        {
        }

        public static implicit operator StringSet(string key)
        {
            return new StringSet(key);
        }
    }

    public class ProtobufSet<T> : RedisSet<T>
    {
        public ProtobufSet(string key)
            : base(key, DataType.Protobuf)
        {
        }

        public static implicit operator ProtobufSet<T>(string key)
        {
            return new ProtobufSet<T>(key);
        }
    }

    public class JsonSet<T> : RedisSet<T>
    {
        public JsonSet(string key)
            : base(key, DataType.Json)
        {
        }

        public static implicit operator JsonSet<T>(string key)
        {
            return new JsonSet<T>(key);
        }
    }
}