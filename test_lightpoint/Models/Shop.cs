using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test_lightpoint.Models
{
    public class Shop
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display (Name="Адрес")]
        public string adres { get; set; }
        [Display(Name = "Название")]
        public string name { get; set; }
        [Display(Name = "Понедельник")]
        public string Mo { get; set; }  // Понедельник
        [Display(Name = "Вторник")]
        public string Tu { get; set; }  // Вторник
        [Display(Name = "Среда")]
        public string We { get; set; }  // Среда
        [Display(Name = "Четверг")]
        public string Th { get; set; }  // Четверг 
        [Display(Name = "Пятница")]
        public string Fr { get; set; }  // Пятница
        [Display(Name = "Суббота")]
        public string Sa { get; set; }  // Суббота
        [Display(Name = "Воскресенье")]
        public string Su { get; set; }  // Воскресенье
    }
}