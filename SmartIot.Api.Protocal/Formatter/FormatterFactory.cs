using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SmartIot.Api.Protocal.Meta;
using NewLife.Model;
using Newtonsoft.Json;
using NewLife.Log;

namespace SmartIot.Api.Protocal.Formatter
{
    public class FormatterFactory
    {
        private static readonly IObjectContainer Container;

        static FormatterFactory()
        {
            Container = ObjectContainer.Current;
        }

        /// <summary>
        /// 处理协议
        /// </summary>
        /// <returns></returns>
        public static AwEntity ProcessAsync(string data)
        {
            var formatter = GetFormatter(data);
            //return await formatter.DeserializeAsync<AwEntity>(data);
            return formatter.Deserialize<AwEntity>(data);
        }

        /// <summary>
        /// 获取格式化器
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //public async static Task<FormatterBase> GetFormatterAsync(String data)
        public static FormatterBase GetFormatter(string data)
        {
            // var protocal = await GetDataProtocalTypeAsync(data);
            //var protocal = GetDataProtocalType(data);
            const DataProtocalType protocal = DataProtocalType.Json;

            //switch (protocal)
            //{
            //    case DataProtocalType.Json:
            //        formatter = new JsonFormatter();
            //        break;
            //    case DataProtocalType.Xml:
            //        formatter = new XmlFormatter();
            //        break;
            //    default:
            //        formatter = new NotSupportFormatter();
            //        break;
            //}
            var formatter = Container.Resolve<FormatterBase>(protocal.ToString());

            return formatter;
        }

        /// <summary>
        /// 用户数据协议分析
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataProtocalType GetDataProtocalType(String data)
        {
            var dataProtocal = DataProtocalType.NotSupported;

            try
            {
                JsonConvert.DeserializeObject<AwEntity>(data);
                dataProtocal = DataProtocalType.Json;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }

            if (dataProtocal != DataProtocalType.NotSupported)
                return dataProtocal;

            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(data);
                dataProtocal = DataProtocalType.Xml;
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }

            return dataProtocal;
        }

        /// <summary>
        /// 用户数据协议分析
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async static Task<DataProtocalType> GetDataProtocalTypeAsync(String data)
        {
            var dataProtocal = DataProtocalType.NotSupported;
            //var cancelToken = new CancellationToken(false);
            var cts = new CancellationTokenSource();
            var isJson = Task.Factory.StartNew(() =>
            {
                try
                {
                    JsonConvert.DeserializeObject<AwEntity>(data);
                    dataProtocal = DataProtocalType.Json;
                    //cancelToken.ThrowIfCancellationRequested();
                    cts.Cancel();
                }
                catch (Exception)
                {
                    Task.Delay(3000);
                }
            }, cts.Token);
            var isXml = Task.Factory.StartNew(() =>
            {
                try
                {
                    var doc = new XmlDocument();
                    doc.LoadXml(data);
                    dataProtocal = DataProtocalType.Xml;
                    //cancelToken.ThrowIfCancellationRequested();
                    cts.Cancel();
                }
                catch (Exception)
                {
                    Task.Delay(3000);
                }
            }, cts.Token);

            Task.WaitAny(isJson, isXml);
            return await Task.FromResult(dataProtocal);
        }
    }
}