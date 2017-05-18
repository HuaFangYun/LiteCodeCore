using System;
using System.Collections.Generic;
using System.DrawingCore.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LuckyCode.WebFrameWork.MvcCaptcha
{
    public class CaptchaMiddleware
    {
        public string captchadata = "/____Capcha";
        private readonly RequestDelegate _next;

        public CaptchaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value == captchadata)
            {
                string guid = Guid.NewGuid().ToString();
                var options = new MvcCaptchaOptions();
                options.TextLength = 6;
                var ci = new MvcCaptchaImage(options);
                ci.ResetText();
                using (var b = ci.RenderImage())
                {
                    var mem = new MemoryStream();

                    b.Save(mem, ImageFormat.Gif);
                    var ar = mem.ToArray();
                    context.Response.ContentType = "image/gif";
                    await context.Response.Body.WriteAsync(ar, 0, ar.Length);
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
