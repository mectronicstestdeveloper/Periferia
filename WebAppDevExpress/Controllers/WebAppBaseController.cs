using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppDevExpress.WebAppCore;

namespace WebAppDevExpress.Controllers
{
    [TypeFilter(typeof(ControlExceptionAttribute))]
    // [Authorize(Roles = "")]
    public class WebAppBaseController : Controller
    {
        public WebAppBaseController()
        {
        }
    }
}