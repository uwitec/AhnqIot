//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： JsonHelper.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:32
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using Newtonsoft.Json;

namespace AhnqIot.Web.Areas.apiV1.ApiResult
{
    public class JsonHelper
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static string Serialize<T>(T entity)
        {
            return JsonConvert.SerializeObject(entity,
#if DEBUG
                Formatting.Indented
#else
                Formatting.None
#endif
                , _settings);
        }

        public static T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, _settings);
        }
    }
}