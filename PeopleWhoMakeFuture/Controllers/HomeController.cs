using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeopleWhoMakeFuture.Models;

namespace PeopleWhoMakeFuture.Controllers
{
    public class HomeController : Controller
    {
        PeopleContext db;
        public HomeController(PeopleContext context)
        {
            db = context;
        }

        // Все методы для действий с отделами (добавление, изменение). 
        // Вывод списка всех отделов.
        [Route("departments")]
        public IActionResult Departments()
        {
            return View(db.Departments.ToList());
        }

        // Добавление нового отдела.
        [Route("departments/add")]
        public IActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        [Route("departments/add")]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            db.Departments.Add(department);
            await db.SaveChangesAsync();
            return RedirectToAction("Departments");
        }

        // Изменение данных отдела.
        [Route("departments/edit/{id}")]
        public async Task<IActionResult> EditDepartment(int? id)
        {
            if (id != null)
            {
                Department department = await db.Departments.FirstOrDefaultAsync(d => d.ID == id);
                if (department != null)
                {
                    return View(department);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [Route("departments/edit/{id}")]
        public async Task<IActionResult> EditDepartment(Department department)
        {
            db.Departments.Update(department);
            await db.SaveChangesAsync();
            return RedirectToAction("Departments");
        }

        // Все методы для действий над языками программирования (добавление, изменение).
        // Вывод списка всех языков.
        [Route("languages")]
        public IActionResult Languages()
        {
            return View(db.Languages.ToList());
        }

        // Добавление нового языка программирования.
        [Route("languages/add")]
        public IActionResult CreateLanguage()
        {
            return View();
        }
        [HttpPost]
        [Route("languages/add")]
        public async Task<IActionResult> CreateLanguage(Language language)
        {
            db.Languages.Add(language);
            await db.SaveChangesAsync();
            return RedirectToAction("Languages");
        }

        // Изменение данных отдела.
        [Route("languages/edit/{id}")]
        public async Task<IActionResult> EditLanguage(int? id)
        {
            if (id != null)
            {
                Language language = await db.Languages.FirstOrDefaultAsync(d => d.ID == id);
                if (language != null)
                {
                    return View(language);
                }
            }
            return NotFound();
        }
        [HttpPost]
        [Route("languages/edit/{id}")]
        public async Task<IActionResult> EditLanguage(Language language)
        {
            db.Languages.Update(language);
            await db.SaveChangesAsync();
            return RedirectToAction("Languages");
        }

        // Все методы для действий над сотрудниками (добавление, изменение, удаление).
        // Вывод списка всех сотрудников.
        [Route("")]
        public IActionResult Index()
        {
            var employees = db.Employees
                .Include(d => d.Department)
                .Include(l => l.Language);
            return View(employees.ToList());
        }

        // Добавление нового сотрудника.
        [Route("add")]
        public IActionResult Create()
        {
            var model = new EmployeeViewsModel
            {
                Departments = db.Departments.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }),
                Languages = db.Languages.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }),
            };
            return View(model);
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create(Employee employee)
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Изменение данных сотрудника.
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                //Employee employee = await db.Employees.FirstOrDefaultAsync(e => e.ID == id);
                var model = new EmployeeViewsModel
                {
                    Departments = db.Departments.Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }),
                    Languages = db.Languages.Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    }),
                    Employee = await db.Employees.FirstOrDefaultAsync(e => e.ID == id)
                };
                if (model != null)
                {
                    return View(model);
                }    
            }
            return NotFound();
        }
        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(Employee employee)
        {
            db.Employees.Update(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Удаление сотрудника.
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
