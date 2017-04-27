//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： Smart.Redis
//  FILENAME   ： RedisClientSeting.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:59
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#region using namespace

using System.Collections.Generic;
using System.ComponentModel;
using NewLife.Xml;

#endregion

namespace Smart.Redis.Config
{
    /// <summary>Redis</summary>
    [DisplayName("Redis")]
    [XmlConfigFile(@"Config\Redis.config", 15000)]
    public class RedisClientSeting : XmlConfig<RedisClientSeting>
    {
        public RedisClientSeting()
        {
            RedisServer = new List<HostItem>();
            Writes = new List<HostItem>();
            Reads = new List<HostItem>();

            SingleMode = true;
        }

        private bool _singleMode;
        /// <summary>
        ///     单一服务器模式，如果为False 将启用读取分离模式
        /// </summary>
        [Description("单一服务器模式，如果为False 将启用读取分离模式")]
        public bool SingleMode
        {
            get { return _singleMode; }
            set
            {
                _singleMode = value;
                if (_singleMode)
                {
                    RedisServer = new List<HostItem> { new HostItem() };
                    Writes.Clear();
                    Reads.Clear();
                }
                else
                {
                    Writes = new List<HostItem> { new HostItem() };
                    Reads = new List<HostItem> { new HostItem() };
                    RedisServer.Clear();
                }
            }
        }

        /// <summary>
        /// 第几个数据库
        /// </summary>
        public int DbIndex { get; set; } = 1;

        /// <summary>
        /// 单一服务器下配置
        /// </summary>
        public List<HostItem> RedisServer { get; set; }

        /// <summary>
        /// 读写分离模式下：写服务器
        /// </summary>
        public List<HostItem> Writes { get; set; }

        /// <summary>
        /// 读写分离模式下：读服务器
        /// </summary>
        public List<HostItem> Reads { get; set; }
    }
}