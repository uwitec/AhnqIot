#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.API
// FILENAME   ： IApiTransport.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 20:29
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Tool.API.Core;
using NewLife;

namespace SmartIot.Tool.API.Transport
{
    public interface IApiTransport : IDisposable2
    {
        void Init(string host, int port);

        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        XResponseMessage Process(dynamic data);
    }
}