using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Video> Videos { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MovieEmployee> MovieEmployees { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        public MovieDBContext() : base() { }
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CPI51I3\\MSSQLSERVER01;Initial Catalog=MovieDB;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>().HasOne(x => x.Movie).WithMany(x => x.Videos).HasForeignKey(m => m.IdMovie).IsRequired();//one movie to many video
            modelBuilder.Entity<Comment>().HasOne(x => x.Movie).WithMany(x => x.Comments).HasForeignKey(x => x.IdMovie).IsRequired();//one movie to many comment
            modelBuilder.Entity<Comment>().HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.IdUser).IsRequired();//one user to many comment
            modelBuilder.Entity<Rate>().HasOne(x => x.Movie).WithMany(x => x.Rates).HasForeignKey(x => x.IdMovie).IsRequired();//one movie to many rate
            modelBuilder.Entity<Rate>().HasOne(x => x.User).WithMany(x => x.Rates).HasForeignKey(x => x.IdUser).IsRequired();//one user to many rate
            modelBuilder.Entity<MovieGenre>().HasOne(x => x.Movie).WithMany(x => x.MovieGenres).HasForeignKey(x => x.IdMovie).IsRequired();//one movie to many movieGenre
            modelBuilder.Entity<MovieGenre>().HasOne(x => x.Genre).WithMany(x => x.MovieGenres).HasForeignKey(x => x.IdGenre).IsRequired();//one genre to many movieGenre
            modelBuilder.Entity<MovieEmployee>().HasOne(x => x.Movie).WithMany(x => x.MovieEmployees).HasForeignKey(x => x.IdMovie).IsRequired();//one movie to many movieEmployee
            modelBuilder.Entity<MovieEmployee>().HasOne(x => x.Employee).WithMany(x => x.MovieEmployees).HasForeignKey(x => x.IdEmployee).IsRequired();//one employee to many movieEmployee
        }
    }
}
