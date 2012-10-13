﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
            ViewBag.Tag = 0;
        }

        //
        // GET: /Account/

        public ActionResult Index()
        {
            //accountService.AddUser(new Entity.Membership()
            //{
            //    Users = new Entity.Users() { UserName = "czj" },
            //    Password = "dsasdsa"
            //});
            return View();
        }


        [HttpGet]
        public ActionResult Profile()
        {
            ViewBag.Tag = 4;

            return View();
        }






    }
}
