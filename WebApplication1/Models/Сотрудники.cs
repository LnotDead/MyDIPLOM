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
    
    public partial class Сотрудники
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Сотрудники()
        {
            this.Ремонт = new HashSet<Ремонт>();
            this.Установка_тренажёров = new HashSet<Установка_тренажёров>();
        }
    
        public int ID_сотрудника { get; set; }
        public string ФИО_сотрудника { get; set; }
        public string Должность { get; set; }
        public string Номер_телефона { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public int ID_состояния { get; set; }
        public string Примечания { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ремонт> Ремонт { get; set; }
        public virtual Состояние_сотрудника Состояние_сотрудника { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Установка_тренажёров> Установка_тренажёров { get; set; }
    }
}
