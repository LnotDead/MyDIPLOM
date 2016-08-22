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
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    public partial class Тренажёры
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Тренажёры()
        {
            this.Ремонт = new HashSet<Ремонт>();
            this.Установленные_детали = new HashSet<Установленные_детали>();
        }

        [Display(Name = "Начало серийного номера")]
        public string Начало_SN { get; set; }

        [Display(Name = "Конец серийного номера")]
        public string Конец_SN { get; set; }

        [Display(Name = "Владелец")]
        public int Код_клиента { get; set; }

        [Display(Name = "Гарантия (мес.)")]
        public int Основная_гарантия { get; set; }
        public string Примечания { get; set; }
        public Nullable<int> ID_установки { get; set; }

        [Display(Name = "Серийный номер")]
        public string SN
        {
            get { return Начало_SN + Конец_SN; }
        }
    
        public virtual Клиенты Клиенты { get; set; }
        public virtual Модели_тренажёров Модели_тренажёров { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ремонт> Ремонт { get; set; }
        public virtual Установка_тренажёров Установка_тренажёров { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Установленные_детали> Установленные_детали { get; set; }

    }   
}
