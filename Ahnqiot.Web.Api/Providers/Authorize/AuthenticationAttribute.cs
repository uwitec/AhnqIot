//  SOLUTION  ： 安徽农业气象物联网V3
//  PROJECT     ： Ahnqiot.Web.Api
//  FILENAME   ： AuthenticationAttribute.cs
//  AUTHOR     ： soft-cq
//  CREATE TIME： 16:30
//  COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2016

using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ahnqiot.Web.Api.Providers
{
    /// <summary>
    /// WebAPI防篡改签名验证抽象基类Attribute
    /// </summary>
    public  class AuthenticationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //获取Asp.Net对应的Request
            var request = ((HttpContextWrapper) actionContext.Request.Properties["MS_HttpContext"]).Request;
            var getCollection = request.QueryString; //此签名要求Partner及Sign均通过QueryString传递
            if (getCollection != null && getCollection.Count > 0)
            {
                var partner = getCollection[SecuritySignHelper.Partner];
                var sign = getCollection[SecuritySignHelper.Sign];
                if (!string.IsNullOrWhiteSpace(partner) //必须包含partner
                    && !string.IsNullOrWhiteSpace(sign) //必须包含sign
                    && Regex.IsMatch(sign, "^[0-9A-Za-z]{32}$")) //sign必须为32位Md5摘要
                {
                    //获取partner对应的key
                    //这里暂时只做了合作key校验，不做访问权限校验，如有需要，此处可进行调整，建议RBAC
                    var partnerKey = this.GetPartnerKey(partner);
                    if (!string.IsNullOrWhiteSpace(partnerKey))
                    {
                        NameValueCollection postCollection = null;
                        switch (request.RequestType.ToUpper())
                        {
                            case "GET":
                            case "DELETE":
                                break; //只是为了同时显示restful四种方式才有这部分无意义代码
                            //实际该以哪种方式进行请求应遵循restful标准
                            case "POST":
                            case "PUT":
                                postCollection = request.Form; //post的数据必须通过application/x-www-form-urlencoded方式传递
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        //根据请求数据获取MD5签名
                        var vSign = getCollection.GetSecuritySign(partner, partnerKey, postCollection);
                        if (string.Equals(sign, vSign, StringComparison.OrdinalIgnoreCase))
                        {
//验证通过,执行基类方法
                            base.OnActionExecuting(actionContext);
                            return;
                        }
                    }
                }
            }
            //此处暂时以401返回，可调整为其它返回
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            //actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        /// 获取合作号对应的合作Key,如果未能获取，则返回空字符串或者null
        /// </summary>
        /// <param name="partner"></param>
        /// <returns></returns>
        public string GetPartnerKey(string partner)
        {
            return string.Empty;
        }
    }
}