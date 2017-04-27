using Ahnqiot.Web.Api.Providers.Results;
using AhnqIot.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ahnqiot.Web.Api.Controllers
{
    public class AgrProduceConditionController : ApiController
    {
        public IAgrProduceConditionService AgrProduceConditionService { get; set; }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            return await ResultFactory.Create(ModelState, async arg => await AgrProduceConditionService.GetByIdAsync(arg), id, "success", "请检查请求参数");
        }

        [HttpPost]
        public async Task<IHttpActionResult> Upload()
        {
            return await ResultFactory.Create(ModelState, async arg =>

              await Task.Factory.StartNew(() =>
              {
                  System.Web.UI.WebControls.FileUpload upload = new System.Web.UI.WebControls.FileUpload();
                  string name = upload.FileName;//获取文件名
                                                //string name1 = upload.PostedFile.FileName; //获取完整客户端文件路径
                  string type = upload.PostedFile.ContentType;//上传文件类型
                                                              //string size = upload.PostedFile.ContentLength.ToString();//上传文件大小
                                                              //string type2 = name.Substring(name.LastIndexOf(".") + 1);//上传文件后缀名
                  string ipath = System.Web.HttpContext.Current.Server.MapPath("upload") + "\\" + name; //上传到服务器上后的路径(实际路径),"\\"必须为两个斜杠,在C#中一个斜杠表示转义符.
                  string ipath1 = System.Web.HttpContext.Current.Server.MapPath("upload");//创建文件夹时用
                                                                                          //string wpath = "upload\\" + name; //虚拟路径
                  if (type == "xls" || type == "xlsx" || type == "txt")//根据后缀名来限制上传类型
                  {

                      if (!Directory.Exists(ipath1))//判断文件夹是否已经存在
                      {
                          Directory.CreateDirectory(ipath1);//创建文件夹
                      }
                      upload.SaveAs(ipath);//上传文件到ipath这个路径里

                  }
                  return true;
              }), "success", "未知");

        }
    }
}
