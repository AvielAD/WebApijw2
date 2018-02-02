using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApijw2.Models
{
    public class JWContext:DbContext
    {
        public JWContext():base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Video> Video { get; set; }
        public DbSet<Teatry> Teatrys { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazine { get; set; }
        public DbSet<Brochure> Brochures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<UserVisited> UserVisited { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Congregation> Congregations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<VisitCategory> VisitCategories{ get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Editorial> Editorials{ get; set; }

    }
}