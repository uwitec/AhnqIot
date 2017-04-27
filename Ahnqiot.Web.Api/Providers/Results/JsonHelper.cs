//  SOLUTION  ： 农业气象物联网V3
//  PROJECT     ： AhnqIot.Web
//  FILENAME   ： JsonHelper.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 14:32
//  COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using Newtonsoft.Json;

namespace Ahnqiot.Web.Api.Providers.Results
{
    public class JsonHelper
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
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
                , Settings);
        }

        public static T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, Settings);
        }
    }
}