using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CrudModalVanillaJs.Models
{
    public partial class PersonaDbContext : DbContext
    {
        public PersonaDbContext()
            : base("name=dbPersonaContext")
        {
            Database.SetInitializer<PersonaDbContext>(new CreateDatabaseIfNotExists<PersonaDbContext>());
        }

        public virtual DbSet<Personas> Personas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
