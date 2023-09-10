using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice19.Models;

namespace Practice19.Data
{
    public class Practice19Context : DbContext
    {
        public Practice19Context (DbContextOptions<Practice19Context> options)
            : base(options)
        {
        }

        public DbSet<Practice19.Models.PhoneBookEntry> PhoneBookEntry { get; set; } = default!;
    }
}
