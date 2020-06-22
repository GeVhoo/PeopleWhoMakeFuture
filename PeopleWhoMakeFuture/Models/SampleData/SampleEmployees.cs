using System.Linq;

namespace PeopleWhoMakeFuture.Models.SampleData
{
    public class SampleEmployees
    {
        public static void Initialize(PeopleContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "Иван",
                        SecondName = "Васильевич",
                        Age = 30,
                        DepartmentID = context.Departments.Single(i => i.Name == "Backend").ID,
                        LanguageID = context.Languages.Single(i => i.Name == "Python").ID
                    },
                    new Employee
                    {
                        FirstName = "Софья",
                        SecondName = "Карамазова",
                        Age = 25,
                        DepartmentID = context.Departments.Single(i => i.Name == "Frontend").ID,
                        LanguageID = context.Languages.Single(i => i.Name == "JavaScript").ID
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
