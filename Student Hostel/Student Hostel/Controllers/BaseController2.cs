using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Hostel.Controllers
{
    public class BaseController2 : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var name = HttpContext.Session.GetString("UserName");
            if (name == null || name == "")
            {
                context.Result = new RedirectResult("/user/Stulogin");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
