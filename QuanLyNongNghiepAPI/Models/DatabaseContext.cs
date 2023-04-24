using Microsoft.EntityFrameworkCore;

namespace QuanLyNongNghiepAPI.Models
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;


        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration)
    : base(options)
        {
            _configuration = configuration;
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
                //entity.Property(e => e.Role).HasDefaultValueSql(_configuration.GetValue<string>("Role:User"));
                //entity.Property(e => e.Password).HasDefaultValue("leanway");
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
