using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
                          Active = string.Empty},
            new MenuItem {Name = "Клиенты",
                          Controller = "Клиенты",
                          Action = "Index",
                          Active = string.Empty},
            new MenuItem {Name = "Склад запасных деталей",
                          Controller = "Склад_запасных_деталей",
                          Action = "Index",
                          Active = string.Empty},
        };





        // GET: MainMenu
        public PartialViewResult Main(string contr = "Тренажёры")
        {
            items.First(m => m.Controller == contr).Active = "active";

            return PartialView(items);
        }





    }
}