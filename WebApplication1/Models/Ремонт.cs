//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ремонт
    {
        public int ID_ремонта { get; set; }
        public string Начало_SN { get; set; }
        public string Конец_SN { get; set; }
        public Nullable<int> ID_сотрудника { get; set; }
        public System.DateTime Начало { get; set; }
        public Nullable<System.DateTime> Завершение { get; set; }
        public string Примечания { get; set; }
    
        public virtual Тренажёры Тренажёры { get; set; }
        public virtual Сотрудники Сотрудники { get; set; }
    }
}
