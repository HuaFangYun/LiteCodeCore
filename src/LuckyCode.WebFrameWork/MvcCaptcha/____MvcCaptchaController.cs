using System;
using System.Collections.Generic;
using System.DrawingCore.Imaging;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace LuckyCode.WebFrameWork.MvcCaptcha
{
    public class ____MvcCaptchaController:Controller
    {
        public ____MvcCaptchaController()
        {
            
        }

        public FileResult Index()
        {
            FileStreamResult file;
            string guid = Guid.NewGuid().ToString();
            var options = new MvcCaptchaOptions();
            var ci = new MvcCaptchaImage(options);
            ci.ResetText();
            if (String.IsNullOrEmpty(guid) || ci == null)
            {
                HttpContext.Response.StatusCode = 404;
                return null;
            }
            ci.ResetText();
            using (var b = ci.RenderImage())
            {
                var mem = new MemoryStream();

                b.Save(mem, ImageFormat.Gif);
                var ar = mem.ToArray();
                file = new FileStreamResult(mem, "image/gif");

                HttpContext.Response.Body.WriteAsync(ar, 0, ar.Length);

            }

            return file;
        }
    }
}
