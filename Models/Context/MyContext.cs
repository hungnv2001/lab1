using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace lab1.Models.Context
{
    public class MyContext : DbContext
    {
        

        public MyContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=Lab1_c5;Integrated Security=True;Trust Server Certificate=True");
        }
        public DbSet<Information> Informations { get; set; }
    }
}
