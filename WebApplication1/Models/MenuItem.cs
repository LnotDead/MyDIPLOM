using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MenuItem
    {
        public string Name { get; set; } // Текст надписи
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Active { get; set; }
        public bool Admin { get; set; }
    }
}