using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{

    // Сущность ролей. Переопределяем стандартный ASP.NET
    // Identity класс IdentityRole
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public string Description { get; set; }
    }
}