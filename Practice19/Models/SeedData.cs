using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Practice19.Data;
using System;
using System.Linq;

namespace Practice19.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Practice19Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Practice19Context>>()))
            {
                // Look for any movies.
                if (context.PhoneBookEntry.Any())
                {
                    return;   // DB has been seeded
                }
                context.PhoneBookEntry.AddRange(
                    new PhoneBookEntry
                    {
                        LastName = "Иванов",
                        FirstName = "Иван",
                        MiddleName = "Иванович",
                        PhoneNumber = 79871234567,
                        Address = "450000, г. Уфа, ул. Ленина, 1, кв. 1",
                        Description = ""
                    },
                    new PhoneBookEntry
                    {
                        LastName = "Петров",
                        FirstName = "Пётр",
                        MiddleName = "Петрович",
                        PhoneNumber = 79658901234,
                        Address = "450001, г. Уфа, проспект Октября, 2, кв. 2",
                        Description = ""
                    },
                    new PhoneBookEntry
                    {
                        LastName = "Сидоров",
                        FirstName = "Сидр",
                        MiddleName = "Сидорович",
                        PhoneNumber = 79435678901,
                        Address = "450002, г. Уфа, проспект Салавата Юлаева, 3, кв. 3",
                        Description = ""
                    },
                    new PhoneBookEntry
                    {
                        LastName = "Бэггинс",
                        FirstName = "Фродо",
                        MiddleName = "Дрогович",
                        PhoneNumber = 79212345678,
                        Address = "450003, г. Уфа, ул. Бэг Энд, 4",
                        Description = "Выдающийся хоббит из Шира, племянник Бильбо Бэггинса."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
