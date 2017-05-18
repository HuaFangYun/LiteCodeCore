using System;
using System.Collections.Generic;
using System.DrawingCore.Imaging;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCode.WebFrameWork.MvcCaptcha
{
    internal class MvcCaptchaImageResult : ActionResult
    {
        public override void ExecuteResult(ActionContext context)
        {
            string guid = Guid.NewGuid().ToString();
            var ci = MvcCaptchaImage.GetCachedCaptcha(guid);
            if (String.IsNullOrEmpty(guid) || ci == null)
            {
                context.HttpContext.Response.StatusCode = 404;
                return;
            }
            ci.ResetText();
            using (var b = ci.RenderImage())
            {
                using (var mem = new MemoryStream())
                {
                    b.Save(mem, ImageFormat.Gif);
                    var ar = mem.ToArray();
                    context.HttpContext.Response.ContentType = "image/gif";
                    context.HttpContext.Response.StatusCode = 200;
                    context.HttpContext.Response.Body.Write(ar,0,ar.Length);
                }
            }
            
           
            
        }
    }
}
