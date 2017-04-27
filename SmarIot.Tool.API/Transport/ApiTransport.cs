#region Code File Comment

// SOLUTION   ： AWIOT
// PROJECT    ： SmartIot.Tool.API
// FILENAME   ： ApiTransport.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-07-31 20:48
// COPYRIGHT  ： 版权所有 (C) 物联网科技有限公司 http://www.smartah.cc/ 2011~2015

#endregion Code File Comment

using SmartIot.Api.Protocal;
using SmartIot.Api.Protocal.Formatter;
using NewLife.Model;
using System;

namespace SmartIot.Tool.API.Transport
{
    public class ApiTransport
    {
        protected FormatterBase Formatter;
        protected string Host;
        protected int Port;
        protected DataProtocalType ProtocalType;

        public ApiTransport()
        {
            Formatter = new NotSupportFormatter();
            Formatter = ObjectContainer.Current.Resolve<FormatterBase>(ProtocalType.ToString());
        }

        protected string Serialize(dynamic obj)
        {
            return Formatter.Serialize(obj);
        }

        protected T Deserialize<T>(string str) where T : class
        {
            return Formatter.Deserialize<T>(str);
        }
    }
}