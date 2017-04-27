#region Code File Comment

// SOLUTION   ： 农业气象物联网V3
// PROJECT    ： AhnqIot.Web
// FILENAME   ： WebConfig.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2016-01-18 20:49
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

#endregion

#region using namespace

using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Ahnqiot.Web.Api.Providers.ConfigInfo
{
    public class WebConfig
    {
        private static readonly object _locker = new object();

        private static WebConfig _current;

        /// <summary>
        ///     文件存储路径
        /// </summary>
        [JsonIgnore]
        private static readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "Config", "WebInfo.xml");

        private WebConfig()
        {
            SystemName = "农业气象物联网综合服务平台";
            Version = "V3";
            CopyRight = "Copyright © 2016 www.smartah.cc All Rights Reserved. ";
            CompanyName = "物联网科技有限公司";
            CompanyHref = "http://www.smartah.cc";
            UrlInfo = new Url();
            SystemError = new SystemError();
        }

        public static WebConfig Current
        {
            get
            {
                if (_current == null)
                    _current = Load();
                return _current;
            }
        }

        public DateTime LastUpdateTime { get; set; }

        public string SystemName { get; set; }

        public string Version { get; set; }

        public string CopyRight { get; set; }

        public string CompanyName { get; set; }

        public string CompanyHref { get; set; }

        public string Keywords { get; set; }

        public Url UrlInfo { get; set; }

        public SystemError SystemError { get; set; }

        public void Save()
        {
            //if (!File.Exists(_filePath))
            //    File.Create(_filePath);
            using (var fs = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                LastUpdateTime = DateTime.Now;
                lock (_locker)
                {
                    fs.SetLength(0);
                    fs.Seek(0, SeekOrigin.Begin);
                    var str = JsonConvert.SerializeObject(this, Formatting.Indented);
                    var data = Encoding.UTF8.GetBytes(str);
                    fs.Write(data, 0, data.Length);
                    fs.Flush(true);
                }
            }
        }

        public static WebConfig Load()
        {
            if (File.Exists(_filePath))
            {
                using (var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var buffer = new Byte[4 * 1024];
                    var size = fs.Read(buffer, 0, buffer.Length);
                    var str = Encoding.UTF8.GetString(buffer, 0, size);
                    var obj = JsonConvert.DeserializeObject<WebConfig>(str);
                    return obj;
                }
            }
            else
            {
                var config = new WebConfig();
                config.Save();
                return config;
            }
        }
    }
}