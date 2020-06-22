using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleWhoMakeFuture.Models
{
    // Модель для страниц добавления и изменения сотрудника с селект боксами. 
    public class EmployeeViewsModel
    {
        public Employee Employee { get; set; }
        
        public IEnumerable<SelectListItem> Departments { get; set; }

        public IEnumerable<SelectListItem> Languages { get; set; }
    }
}
