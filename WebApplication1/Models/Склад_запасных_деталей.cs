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
    public partial class Склад_запасных_деталей
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Склад_запасных_деталей()
        {
            this.Подходящие_запасные_детали = new HashSet<Подходящие_запасные_детали>();
        }

        [Display(Name = "Деталь")]
        public string Код_детали { get; set; }
        public int Количество { get; set; }
        public string Примечания { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Подходящие_запасные_детали> Подходящие_запасные_детали { get; set; }
    }
}
