using System;
using System.Linq.Expressions;
using Nancy;
using Nancy.Security;

namespace NancyCsrfDemo
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = p =>
            {
                return View["Index"];
            };

            Post["/"] = p =>
            {
                try
                {
                    this.ValidateCsrfToken();
                }
                catch (CsrfValidationException)
                {
                    return Response.AsText("Csrf Token not valid.").WithStatusCode(403);
                }
                
                ViewBag.Name = Request.Form.Name;
                return View["Index"];
            };

        }
    }
}   