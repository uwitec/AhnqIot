using System;
using System.Text;
using System.Threading.Tasks;
using NewLife.Model;

namespace SmartIot.Api.Protocal.Formatter
{
    public class FormatterBase
    {
        protected readonly Encoding _encoding = Encoding.UTF8;

        static FormatterBase()
        {
            var container = ObjectContainer.Current;
            container.Register<FormatterBase, JsonFormatter>(DataProtocalType.Json.ToString());
            container.Register<FormatterBase, XmlFormatter>(DataProtocalType.Xml.ToString());
            container.Register<FormatterBase, NotSupportFormatter>(DataProtocalType.NotSupported.ToString());
        }

        public FormatterBase()
        {
        }

        public FormatterBase(DataProtocalType protocalType)
        {
            this.ProtocalType = protocalType;
        }

        /// <summary>
        /// 协议类型
        /// </summary>
        public DataProtocalType ProtocalType { get; set; }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual string Serialize<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> SerializeAsync<T>(T entity) where T : class
        {
            return await Task.FromResult(Serialize(entity));
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public virtual T Deserialize<T>(string data) where T : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<T> DeserializeAsync<T>(string data) where T : class
        {
            return await Task.FromResult(Deserialize<T>(data));
        }
    }
}