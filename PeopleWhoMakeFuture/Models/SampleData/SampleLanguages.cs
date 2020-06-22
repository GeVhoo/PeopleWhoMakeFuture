using System.Linq;

namespace PeopleWhoMakeFuture.Models.SampleData
{
    public class SampleLanguages
    {
        public static void Initialize(PeopleContext context)
        {
            if (!context.Languages.Any())
            {
                context.Languages.AddRange(
                    new Language
                    {
                        Name = "C#"
                    },
                    new Language
                    {
                        Name = "C++"
                    },
                    new Language
                    {
                        Name = "Python"
                    },
                    new Language
                    {
                        Name = "JavaScript"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
