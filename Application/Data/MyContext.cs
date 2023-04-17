using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> option): base(option)
        {
            
        }
        public DbSet<Adherent> adherents { get; set; }
        public DbSet<Livre> livre { get; set; }
    }
}
