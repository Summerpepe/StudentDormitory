using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Student_Hostel.Controllers
{
    public class BaseController1 : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var name = HttpContext.Session.GetString("UserName");
            if (name==null ||name=="")
            {
                context.Result = new RedirectResult("/user/login");
                return;
            }

            base.OnActionExecuting(context);
        }
    

    }
}
