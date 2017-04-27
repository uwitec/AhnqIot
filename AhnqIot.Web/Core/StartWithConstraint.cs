using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Routing;

namespace AhnqIot.Web.Core
{
    /// <summary>
    /// 如果请求url如： api/area/controller/x  x有可能是actioin或id
    /// 在url中的x位置出现的是以 get put delete post开头的字符串，则当作action,否则就当作id
    /// 如果action为空，则把请求方法赋给action
    /// </summary>
    public class StartWithConstraint : IHttpRouteConstraint
    {
        public string[] array { get; set; }
        public bool match { get; set; }
        private string _id = "id";

        public StartWithConstraint(string[] startwithArray = null)
        {
            if (startwithArray == null)
                startwithArray = new string[] { "GET", "PUT", "DELETE", "POST", "EDIT", "UPDATE", "AUDIT", "DOWNLOAD" };

            this.array = startwithArray;
        }

        public bool Match(System.Net.Http.HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            if (values == null) // shouldn't ever hit this.                   
                return true;

            if (!values.ContainsKey(parameterName) || !values.ContainsKey(_id)) // make sure the parameter is there.
                return true;

            var action = values[parameterName].ToString().ToLower();
            if (string.IsNullOrEmpty(action)) // if the param key is empty in this case "action" add the method so it doesn't hit other methods like "GetStatus"
            {
                values[parameterName] = request.Method.ToString();
            }
            else if (string.IsNullOrEmpty(values[_id].ToString()))
            {
                var isidstr = true;
                array.ToList().ForEach(x =>
                {
                    if (action.StartsWith(x.ToLower()))
                        isidstr = false;
                });

                if (isidstr)
                {
                    values[_id] = values[parameterName];
                    values[parameterName] = request.Method.ToString();
                }
            }
            return true;
        }
    }


}