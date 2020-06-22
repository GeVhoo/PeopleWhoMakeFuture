using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleWhoMakeFuture.Models
{
    public class Language
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Название")]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

