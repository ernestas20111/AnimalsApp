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

        public virtual DbSet<UserDetails> UserDetails { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<PostImage> PostImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserDetails)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserDetails>(ud => ud.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

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

            modelBuilder.Entity<User>().Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            //UserDetails
            modelBuilder.Entity<UserDetails>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserDetails>().Property(x => x.PasswordHash)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<UserDetails>().Property(x => x.PasswordSalt)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<UserDetails>().Property(x => x.Role)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<UserDetails>().Property(x => x.Verified)
                .HasColumnType("bit")
                .IsRequired();

            //Posts
            modelBuilder.Entity<Post>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.PostImages)
                .WithOne(pi => pi.Post)
                .HasForeignKey(pi => pi.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Post>().Property(x => x.Title)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Post>().Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Post>().Property(x => x.Price)
                .HasColumnType("float")
                .IsRequired();

            modelBuilder.Entity<Post>().Property(x => x.Duration)
                .HasColumnType("datetime2")
                .IsRequired();

            modelBuilder.Entity<Post>().Property(x => x.Category)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Post>().Property(x => x.Purpose)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            //PostImages
            modelBuilder.Entity<PostImage>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PostImage>().Property(x => x.ImageUrl)
                .HasColumnType("varchar")
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
