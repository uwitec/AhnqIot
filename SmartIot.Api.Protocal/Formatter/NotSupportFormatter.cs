namespace SmartIot.Api.Protocal.Formatter
{
    public class NotSupportFormatter : FormatterBase
    {
        public override string Serialize<T>(T entity)
        {
            return string.Empty;
        }

        public override T Deserialize<T>(string data)
        {
            return default(T);
        }
    }
}