using Newtonsoft.Json;

namespace SmartIot.Api.Protocal.Formatter
{
    public class JsonFormatter : FormatterBase
    {
        private readonly JsonSerializerSettings deSettings;
        private readonly JsonSerializerSettings settings;

        public JsonFormatter()
        {
            settings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                NullValueHandling = NullValueHandling.Ignore
            };
            deSettings = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public override string Serialize<T>(T entity)
        {
            return JsonConvert.SerializeObject(entity,
#if DEBUG
                Formatting.None
#else
                Formatting.None
#endif
                , settings);
        }

        public override T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, deSettings);
        }
    }
}