using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mircescu_Ligia_Lab8.Models;

namespace Mircescu_Ligia_Lab8.Data
{
    public class Mircescu_Ligia_Lab8Context : DbContext
    {
        public Mircescu_Ligia_Lab8Context (DbContextOptions<Mircescu_Ligia_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Mircescu_Ligia_Lab8.Models.Book> Book { get; set; }
    }
}
