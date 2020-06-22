using System.Linq;

namespace PeopleWhoMakeFuture.Models.SampleData
{
    public static class SampleDepartmets
    {
        public static void Initialize(PeopleContext context)
        {
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department
                    {
                        Name = "Frontend",
                        Floor = 5
                    },
                    new Department
                    {
                        Name = "Backend",
                        Floor = 6
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
