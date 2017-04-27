//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Smart.Redis
//  FILENAME   ： ConstValues.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 23:14
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

namespace Smart.Redis
{
    public class ConstValues
    {
        /// <summary>
        ///     切换到指定的数据库，数据库索引号用数字值指定，以 0 作为起始索引值。
        /// </summary>
        public const string REDIS_COMMAND_SELECT = "SELECT";

        /// <summary>
        ///     客户端向服务器发送一个 PING ，然后服务器返回客户端一个 PONG 。
        /// </summary>
        public const string REDIS_COMMAND_PING = "PING";

        /// <summary>
        ///     为给定key设置生存时间
        /// </summary>
        public const string REDIS_COMMAND_EXPIRE = "Expire";

        /// <summary>
        ///     检查给定key是否存在。
        /// </summary>
        public const string REDIS_COMMAND_EXISTS = "EXISTS";

        /// <summary>
        ///     返回给定key的剩余生存时间(time to live)(以秒为单位)。
        /// </summary>
        public const string REDIS_COMMAND_TTL = "TTL";

        /// <summary>
        ///     从当前数据库中随机返回(不删除)一个key。
        /// </summary>
        public const string REDIS_COMMAND_RANDOMKEY = "Randomkey";

        /// <summary>
        ///     将key改名为newkey。
        /// </summary>
        public const string REDIS_COMMAND_RENAME = "RENAME";

        /// <summary>
        ///     查看哈希表key中，给定域field是否存在。
        /// </summary>
        public const string REDIS_COMMAND_HEXISTS = "HEXISTS";

        /// <summary>
        ///     返回哈希表key中的所有域。
        /// </summary>
        public const string REDIS_COMMAND_HKEYS = "HKEYS";

        /// <summary>
        ///     返回哈希表key中的所有值
        /// </summary>
        public const string REDIS_COMMAND_HVALS = "HVALS";

        /// <summary>
        ///     返回哈希表key中，所有的域和值。
        /// </summary>
        public const string REDIS_COMMAND_HGETALL = "HGETALL";

        /// <summary>
        ///     返回哈希表key中，一个或多个给定域的值。
        /// </summary>
        public const string REDIS_COMMAND_HMGET = "HMGET";

        /// <summary>
        ///     返回哈希表key中给定域field的值。
        /// </summary>
        public const string REDIS_COMMAND_HGET = "HGET";

        /// <summary>
        ///     删除哈希表key中的一个或多个指定域，不存在的域将被忽略。
        /// </summary>
        public const string REDIS_COMMAND_HDEL = "HDEL";

        /// <summary>
        ///     返回哈希表key中域的数量
        /// </summary>
        public const string REDIS_COMMAND_HLEN = "HLen";

        /// <summary>
        ///     同时将多个field - value(域-值)对设置到哈希表key中。
        /// </summary>
        public const string REDIS_COMMAND_HMSET = "HMSET";

        /// <summary>
        ///     将哈希表key中的域field的值设为value。
        /// </summary>
        public const string REDIS_COMMAND_HSET = "HSET";

        /// <summary>
        ///     将哈希表key中的域field的值设置为value，当且仅当域field不存在。
        /// </summary>
        public const string REDIS_COMMAND_HSETNX = "HSetNx";

        /// <summary>
        ///     返回所有(一个或多个)给定key的值。
        /// </summary>
        public const string REDIS_COMMAND_MGET = "MGET";

        /// <summary>
        ///     返回key所关联的字符串值
        /// </summary>
        public const string REDIS_COMMAND_GET = "GET";

        /// <summary>
        ///     将字符串值value关联到key。
        /// </summary>
        public const string REDIS_COMMAND_SET = "SET";

        /// <summary>
        ///     将给定key的值设为value，并返回key的旧值。
        /// </summary>
        public const string REDIS_COMMAND_GETSET = "GETSET";

        /// <summary>
        ///     将key中储存的数字值增一。
        /// </summary>
        public const string REDIS_COMMAND_INCR = "INCR";

        /// <summary>
        ///     将key所储存的值加上增量increment。
        /// </summary>
        public const string REDIS_COMMAND_INCRBY = "INCRBY";

        /// <summary>
        ///     将key中储存的数字值减一。
        /// </summary>
        public const string REDIS_COMMAND_DECR = "DECR";

        /// <summary>
        ///     将key所储存的值减去减量decrement。
        /// </summary>
        public const string REDIS_COMMAND_DECRBY = "DECRBY";

        /// <summary>
        ///     移除给定的一个或多个key。
        /// </summary>
        public const string REDIS_COMMAND_DEL = "DEL";

        /// <summary>
        ///     移除并返回列表key的头元素
        /// </summary>
        public const string REDIS_COMMAND_LPOP = "LPOP";

        /// <summary>
        ///     移除并返回列表key的尾元素
        /// </summary>
        public const string REDIS_COMMAND_RPOP = "RPOP";

        /// <summary>
        ///     将一个或多个值value插入到列表key的表头
        /// </summary>
        public const string REDIS_COMMAND_LPUSH = "LPUSH";

        /// <summary>
        ///     将列表key下标为index的元素的值甚至为value。
        /// </summary>
        public const string REDIS_COMMAND_LSET = "LSET";

        /// <summary>
        ///     将一个或多个值value插入到列表key的表尾。
        /// </summary>
        public const string REDIS_COMMAND_RPUSH = "RPUSH";

        /// <summary>
        ///     返回列表key中指定区间内的元素，区间以偏移量start和stop指定。
        /// </summary>
        public const string REDIS_COMMAND_LRANGE = "LRANGE";

        /// <summary>
        ///     返回列表key中，下标为index的元素。
        /// </summary>
        public const string REDIS_COMMAND_LINDEX = "LINDEX";

        /// <summary>
        ///     返回列表key的长度。
        /// </summary>
        public const string REDIS_COMMAND_LLEN = "LLEN";

        /// <summary>
        ///     查找符合给定模式的key。
        ///     KEYS* 命中数据库中所有key。
        ///     KEYS h?llo命中hello， hallo and hxllo等。
        ///     KEYS h*llo命中hllo和heeeeello等。
        ///     KEYS h[ae]llo命中hello和hallo，但不命中hillo。
        ///     特殊符号用"\"隔开
        /// </summary>
        public const string REDIS_COMMAND_KEYS = "KEYS";

        /// <summary>
        ///     同时设置一个或多个key-value对。
        /// </summary>
        public const string REDIS_COMMAND_MSET = "MSET";

        /// <summary>
        ///     返回关于 Redis 服务器的各种信息和统计值。
        /// </summary>
        public const string REDIS_COMMAND_INFO = "INFO";

        /// <summary>
        ///     返回或保存给定列表、集合、有序集合key中经过排序的元素。
        /// </summary>
        public const string REDIS_COMMAND_SORT = "SORT";

        /// <summary>
        ///     返回当前服务器时间
        /// </summary>
        public const string REDIS_COMMAND_TIME = "TIME";

        /// <summary>
        ///     将一个或多个member元素及其score值加入到有序集key当中。
        /// </summary>
        public const string REDIS_COMMAND_ZADD = "ZADD";

        /// <summary>
        ///     返回有序集key的基数。
        /// </summary>
        public const string REDIS_COMMAND_ZCARD = "ZCARD";

        /// <summary>
        ///     返回有序集key中，score值在min和max之间(默认包括score值等于min或max)的成员。
        /// </summary>
        public const string REDIS_COMMAND_ZCOUNT = "ZCOUNT";

        /// <summary>
        ///     返回有序集key中，指定区间内的成员。
        /// </summary>
        public const string REDIS_COMMAND_ZRANGE = "ZRANGE";

        /// <summary>
        ///     返回有序集key中，所有score值介于min和max之间(包括等于min或max)的成员。有序集成员按score值递增(从小到大)次序排列。
        /// </summary>
        public const string REDIS_COMMAND_ZRANGEBYSCORE = "ZRANGEBYSCORE";

        /// <summary>
        ///     返回有序集key中，指定区间内的成员。
        /// </summary>
        public const string REDIS_COMMAND_ZREVRANGE = "ZREVRANGE";

        /// <summary>
        ///     返回有序集key中成员member的排名。其中有序集成员按score值递增(从小到大)顺序排列。
        /// </summary>
        public const string REDIS_COMMAND_ZRANK = "ZRANK";

        /// <summary>
        ///     返回有序集key中成员member的排名。其中有序集成员按score值递减(从大到小)排序。
        /// </summary>
        public const string REDIS_COMMAND_ZREVRANK = "ZREVRANK";

        /// <summary>
        ///     移除有序集key中的一个或多个成员，不存在的成员将被忽略。
        /// </summary>
        public const string REDIS_COMMAND_ZREM = "ZREM";

        /// <summary>
        ///     返回有序集key中，成员member的score值。
        /// </summary>
        public const string REDIS_COMMAND_ZSCORE = "ZSCORE";

        /// <summary>
        ///     将一个或多个member元素加入到集合key当中，已经存在于集合的member元素将被忽略。
        /// </summary>
        public const string REDIS_COMMAND_SADD = "SADD";

        /// <summary>
        ///     返回集合key的基数(集合中元素的数量)。
        /// </summary>
        public const string REDIS_COMMAND_SCARD = "SCARD";

        /// <summary>
        ///     判断member元素是否是集合key的成员。
        /// </summary>
        public const string REDIS_COMMAND_SISMEMBER = "SISMEMBER";

        /// <summary>
        ///     返回集合key中的所有成员。
        /// </summary>
        public const string REDIS_COMMAND_SMEMBERS = "SMEMBERS";

        /// <summary>
        ///     移除集合key中的一个或多个member元素，不存在的member元素会被忽略。
        /// </summary>
        public const string REDIS_COMMAND_SREM = "SREM";

        /// <summary>
        /// 将信息 message 发送到指定的频道 channel 。
        /// </summary>
        public const string REDIS_COMMAND_PUBLISH = "PUBLISH";

        /// <summary>
        /// 订阅给定的一个或多个频道的信息
        /// </summary>
        public const string REDIS_COMMAND_SUBSCRIBE = "SUBSCRIBE";

        /// <summary>
        /// 指示客户端退订给定的频道。
        /// </summary>
        public const string REDIS_COMMAND_UNSUBSCRIBE = "UNSUBSCRIBE";

        /// <summary>
        /// 订阅一个或多个符合给定模式的频道
        /// </summary>
        public const string REDIS_COMMAND_PSUBSCRIBE = "PSUBSCRIBE";

        /// <summary>
        /// 指示客户端退订所有给定模式。
        /// </summary>
        public const string REDIS_COMMAND_PUNSUBSCRIBE = " PUNSUBSCRIBE";

        /// <summary>
        /// 查看订阅与发布系统状态的内省命令。
        /// </summary>
        public const string REDIS_COMMAND_PUBSUB = " PUBSUB";
    }
}