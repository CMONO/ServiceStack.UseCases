﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomAuthenticationMvc.App_Start;
using ServiceStack.CacheAccess;
using ServiceStack.Common.ServiceClient.Web;
using ServiceStack.ServiceClient.Web;

namespace CustomAuthenticationMvc.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult RunHelloService()
        {
            var client = CreateJsonServiceClient();
            var authResponse = client.Post<HelloResponse>("/Hello", new HelloRequest {Name = User.Identity.Name});
            
            ViewBag.Response = authResponse.Result;
            ViewBag.Counter = ServiceStackSession.Get<int>(HelloService.HelloServiceCounterKey);
            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}