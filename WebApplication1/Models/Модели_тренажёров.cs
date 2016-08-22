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
    public partial class Модели_тренажёров
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Модели_тренажёров()
        {
            this.Подходящие_запасные_детали = new HashSet<Подходящие_запасные_детали>();
            this.Тренажёры = new HashSet<Тренажёры>();
            this.Устанавливаемые_тренажёры = new HashSet<Устанавливаемые_тренажёры>();
        }
    
        public string Начало_SN { get; set; }
        [Display(Name = "Тип")]
        public string Тип_тренажёра { get; set; }
        [Display(Name = "Серия")]
        public string Название_линейки { get; set; }
        [Display(Name = "Модель")]
        public string Название_модели { get; set; }
        public string Примечания { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Подходящие_запасные_детали> Подходящие_запасные_детали { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Тренажёры> Тренажёры { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Устанавливаемые_тренажёры> Устанавливаемые_тренажёры { get; set; }
    }
}
