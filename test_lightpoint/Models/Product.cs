using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test_lightpoint.Models
{
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "Наименование")]
        public string name { get; set; }
        [Display(Name = "Описание")]
        public string desctiption { get; set; }
        [Display(Name = "Магазин")]
        public virtual Shop shopId { get; set; }
    }
}