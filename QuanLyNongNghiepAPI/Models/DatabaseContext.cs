using Microsoft.EntityFrameworkCore;

namespace QuanLyNongNghiepAPI.Models
{
    public class DatabaseContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:DBContext"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).HasDefaultValueSql("('leanway')");
                entity.HasIndex(e => e.Username).IsUnique();
            });

            ////GroupID có thể null
            //modelBuilder.Entity<User>()
            //.HasOne(t => t.Group)
            //.WithMany()
            //.HasForeignKey(t => t.GroupID)
            //.OnDelete(DeleteBehavior.SetNull);

        }
    }
}
