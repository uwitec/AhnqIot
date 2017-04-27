#region Code File Comment
// SOLUTION   ： AWIOT
// PROJECT    ： JSing.Web
// FILENAME   ： JObjectModelBinder.cs
// AUTHOR     ： soft-cq
// CREATE TIME： 2015-08-07 18:45
// COPYRIGHT  ： 版权所有 (C) 安徽斯玛特物联网科技有限公司 http://www.smartah.cc/ 2011~2015
#endregion

using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AhnqIot.Web.Core
{
    public class JObjectModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var stream = controllerContext.RequestContext.HttpContext.Request.InputStream;
            stream.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(stream).ReadToEnd();
            return JsonConvert.DeserializeObject<dynamic>(json);
        }
    }
}