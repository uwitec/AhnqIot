#region Code File Comment

// SOLUTION   ： 安徽农业气象物联网V3
// PROJECT    ： Smart.Redis
// FILENAME   ： HostItem.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-12-11 9:42
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion

#region using namespace

using System.ComponentModel;

#endregion

namespace Smart.Redis.Config
{
    public class HostItem
    {
        [Description("主机地址")]
        public string Host { get; set; } = "192.168.1.243";

        [Description("链接数")]
        public int Connections { get; set; } = 60;
    }
}