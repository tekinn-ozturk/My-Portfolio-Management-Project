using APILayer.Dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace APILayer.Dal.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NVNMQQI; Database=PortfolioCoreAPIDB; Uid=sa; Pwd=123;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
