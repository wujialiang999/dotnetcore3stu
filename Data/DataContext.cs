using Microsoft.EntityFrameworkCore;
namespace dotnetcore3stu
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}