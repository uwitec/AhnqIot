using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SmartIot.Api.Protocal.Formatter
{
    public class XmlFormatter : FormatterBase
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override string Serialize<T>(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            var serializer = new XmlSerializer(typeof (T));
            var setting = new XmlWriterSettings
            {
                Encoding = _encoding,
                Indent = true,
                OmitXmlDeclaration = false
            };
            //setting.Encoding = encoding.TrimPreamble();
            // 去掉开头 <?xml version="1.0" encoding="utf-8"?>

            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream, setting))
                {
                    serializer.Serialize(writer, entity);
                    return _encoding.GetString(stream.ReadBytes());
                }
            }
        }

        public override T Deserialize<T>(string xml)
        {
            if (xml.IsNullOrWhiteSpace()) throw new ArgumentNullException("xml");
            var type = typeof (T);
            if (type == null) throw new NullReferenceException("type");

            if (!type.IsPublic) throw new Exception(string.Format("类型{0}不是public，不能进行Xml序列化！", type.FullName));

            var serial = new XmlSerializer(type);
            using (var reader = new StringReader(xml))
            using (var xr = new XmlTextReader(reader))
            {
                // 必须关闭Normalization，否则字符串的\r\n会变为\n
                //xr.Normalization = true;
                var obj = serial.Deserialize(xr);
                return obj as T;
            }
        }
    }
}