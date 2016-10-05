using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        List<MenuItem> items = new List<MenuItem>
        {
            new MenuItem {Name = "Статистика",
                          Controller = "Main",
                          Action = "Index",
                          Active = string.Empty,
                          Role = "Technician"},
            new MenuItem {Name = "Тренажёры",
                          Controller = "Тренажёры",
                          Action = "Index",
                          Active = string.Empty,
                          Role = "Technician"},
            new MenuItem {Name = "Клиенты",
                          Controller = "Клиенты",
                          Action = "Index",
                          Active = string.Empty,
                          Role = "Engineer"},
            new MenuItem {Name = "Ремонты",
                          Controller = "Ремонт",
                          Action = "Index",
                          Active = string.Empty,
                          Role = "Technician"},
            new MenuItem {Name = "Склад запасных деталей",
                          Controller = "Склад_запасных_деталей",
                          Action = "Index",
                          Active = string.Empty,
                          Role = "Engineer"},
            new MenuItem {Name = "Модели тренажёров",
                          Controller = "Модели_тренажёров",
                          Action = "Index",
                          Active = string.Empty,
                          Role = "Engineer"},
            new MenuItem {Name = "Администирирование",
                          Controller = "Admin",
                          Action = "Index",
                          Active = string.Empty,
                          Role = "Admin"},
        };





        // GET: MainMenu
        public PartialViewResult Main(string contr = "Тренажёры")
        {
           
            if (items.Exists(m => m.Controller == contr))
                 items.First(m => m.Controller == contr).Active = "active";


            return PartialView(items);
        }





    }
}