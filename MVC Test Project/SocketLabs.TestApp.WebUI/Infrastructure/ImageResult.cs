using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SocketLabs.TestApp.WebUI.Infrastructure
{
    public class ImageResult : ActionResult
    {
        private string _Path;
        public ImageResult(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            _Path = path;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/image";
            context.HttpContext.Response.TransmitFile(_Path);
        }
    }
}