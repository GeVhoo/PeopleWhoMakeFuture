using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleWhoMakeFuture.Models
{
    public class Employee
    {
        public int ID { get; set; }
        
        [Required]
        [Display(Name = "Имя")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Фамилия")]
        [MaxLength(50)]
        public string SecondName { get; set; }
        
        [Required]
        [Display(Name = "Возраст")]
        public ushort Age { get; set; }
        
        [Required]
        [Display(Name = "Отдел")]
        public int DepartmentID { get; set; }
        
        [Required]
        [Display(Name = "Язык")]
        public int LanguageID { get; set; }

        public virtual Department Department { get; set; }
        public virtual Language Language { get; set; }
    }
}
