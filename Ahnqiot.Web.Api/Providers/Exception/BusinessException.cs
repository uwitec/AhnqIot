//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： BusinessException.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 16:05
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using Ahnqiot.Web.Api.Providers.Results;

namespace Ahnqiot.Web.Api.Providers.Exception
{
    public class BusinessException : System.Exception
    {
        public ExceptionCode Code { get; set; }

        public BusinessException(string message) : base(message)
        {
            
        }
    }
}