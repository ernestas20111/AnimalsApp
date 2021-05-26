using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AnimalsAppBackend.Domain;

namespace AnimalsAppBackend.DataAccess
{
    public class AnimalsAppDbContext : DbContext
    {
        public AnimalsAppDbContext() : base()
        {

        }

        public AnimalsAppDbContext(DbContextOptions<AnimalsAppDbContext> options): base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>().Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Surname)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>().Property(x => x.PasswordHash)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<User>().Property(x => x.PasswordSalt)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
