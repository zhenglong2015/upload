using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upload
{
    /// <summary>
    /// UploadDemo 的摘要说明
    /// </summary>
    public class UploadDemo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
    
            //难道上传的文件
            HttpPostedFile file = context.Request.Files["imgFile"];

            string path = "/upload/"+Guid.NewGuid().ToString()+file.FileName;
            file.SaveAs(context.Request.MapPath(path));
            string str = string.Format("<html><head></head><body><img src='{0}'/></body></html>", path);
            context.Response.Write(str);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}