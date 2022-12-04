using Microsoft.EntityFrameworkCore;
using Tpback1.Entities;

namespace Tpback1.Data
{
    public class AgendaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User karen = new User()
            {
                Id = 1,
                Name = "Karen",
                LastName = "Lasot",
                Password = "Pa$$w0rd",
                Email = "karenbailapiola@gmail.com",
                UserName = "karenpiola"
            };
            User luis = new User()
            {
                Id = 2,
                Name = "Luis Gonzalez",
                LastName = "Gonzales",
                Password = "lamismadesiempre",
                Email = "elluismidetotoras@gmail.com",
                UserName = "luismitoto"
            };

            User roman = new User()
            {
                Id= 3,
                Name = "Roman",
                LastName = "ml",
                Password = "123456",
                Email = "mlm",
                UserName = "rom"

            };

            Contacts Rex = new Contacts()
            {
                Id= 4,
                Name = "reex",
                CelularNumber= 341567891,
                Description = "desconocido",
                TelephoneNumber = null,
                UserId = roman.Id,

             
            };

            Contacts jaimitoC = new Contacts()
            {
                Id = 1,
                Name = "Jaimito",
                CelularNumber = 341457896,
                Description = "Plomero",
                TelephoneNumber = null,
                UserId = karen.Id,
            };

            Contacts pepeC = new Contacts()
            {
                Id = 2,
                Name = "Pepe",
                CelularNumber = 34156978,
                Description = "Papa",
                TelephoneNumber = 422568,
                UserId = luis.Id,
            };

            Contacts mariaC = new Contacts()
            {
                Id = 3,
                Name = "Maria",
                CelularNumber = 011425789,
                Description = "Jefa",
                TelephoneNumber = null,
                UserId = karen.Id,
            };



            modelBuilder.Entity<User>().HasData(
                karen, luis, roman);

            modelBuilder.Entity<Contacts>().HasData(
                 jaimitoC, pepeC, mariaC, Rex
                 );

            modelBuilder.Entity<User>()
              .HasMany<Contacts>(u => u.Contacts)
              .WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
