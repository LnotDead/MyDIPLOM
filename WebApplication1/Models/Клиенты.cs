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
    public partial class Клиенты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Клиенты()
        {
            this.Тренажёры = new HashSet<Тренажёры>();
            this.Установка_тренажёров = new HashSet<Установка_тренажёров>();
        }

        public int Код_клиента { get; set; }

        //[UIHint("TypeDropDown")]
        public string Тип { get; set; }

        //List<string> typesList = new List<string> { "юр", "физ", "test" };

        [Required(ErrorMessage = "Введите ФИО (физ. лицо) или название клуба (юр. лицо)")]
        [Display(Name = "ФИО или Клуб")]
        public string ФИО_Название_клуба { get; set; }

        [Required(ErrorMessage = "Введите паспортные данные (физ. лицо) или реквизиты (юр. лицо)")]
        [Display(Name = "Паспортные данные или реквизиты")]
        public string Паспортные_данные_Реквизиты { get; set; }
        [Required(ErrorMessage = "Введите город клиента")]
        public string Город { get; set; }
        [Required(ErrorMessage = "Введите адрес клиента")]
        public string Адрес { get; set; }

        [Required(ErrorMessage = "Введите основной контакт клиента")]
        [Display(Name = "Основной контакт")]
        public string Основной_контакт { get; set; }

        [Display(Name = "Доп. контакты")]
        public string Дополнительные_контакты { get; set; }
        public string Примечания { get; set; }

        public static string FIOorREKV(string Тип)
        {
            string fioORrekv;

            switch (Тип)
            {
                case "юр":
                    fioORrekv = "Реквизиты";
                    break;
                case "физ":
                    fioORrekv = "Паспортные данные";
                    break;
                default:
                    fioORrekv = "Ошибка";
                    break;
            }
            return fioORrekv;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Тренажёры> Тренажёры { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Установка_тренажёров> Установка_тренажёров { get; set; }
    }
}