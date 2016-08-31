using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MenuController : Controller
    {




        List<MenuItem> items = new List<MenuItem>
        {
            new MenuItem {Name = "Тренажёры",
                          Controller = "Тренажёры",
                          Action = "Index",
                          Active = string.Empty,
                          Admin = false},
            new MenuItem {Name = "Клиенты",
                          Controller = "Клиенты",
                          Action = "Index",
                          Active = string.Empty,
                          Admin = false},
            new MenuItem {Name = "Склад запасных деталей",
                          Controller = "Склад_запасных_деталей",
                          Action = "Index",
                          Active = string.Empty,
                          Admin = false},
            new MenuItem {Name = "Модели тренажёров",
                          Controller = "Модели_тренажёров",
                          Action = "Index",
                          Active = string.Empty,
                          Admin = false},
            new MenuItem {Name = "Администрирование",
                          Controller = "Admin",
                          Action = "Index",
                          Active = string.Empty,
                          Admin = true},
        };





        // GET: MainMenu
        public PartialViewResult Main(string contr = "Тренажёры")
        {
           
            if (items.Exists(m => m.Controller == contr))
                 items.First(m => m.Controller == contr).Active = "active";


            ViewBag.flag = HttpContext.User.IsInRole("Admin");


            return PartialView(items);
        }





    }
}