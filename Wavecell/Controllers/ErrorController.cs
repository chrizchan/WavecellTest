﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Wavecell.Controllers
{
    [Wavecell.Security.AllowAnonymous]
    [HandleError]
    public class ErrorController : Controller
    {
        public ActionResult InternalServerError()
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View("InternalServerError");
        }

    }
}
