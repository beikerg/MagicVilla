using MagicVilla.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Villa> Villas { get; set; } // Esto indicara que se creara en la base de datos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
               new Villa()
               {
                   Id = 1,
                   Nombre = "Villa Real",
                   Detalle = "Detalle de la Villa...",
                   ImagenUrl = "",
                   Ocupantes = 5,
                   MetrosCuadrados = 50,
                   Tarifa = 200,
                   Amenidad = "",
                   FechaCreacion = DateTime.Now,
                   FechaActualizacion = DateTime.Now
               },
               new Villa()
               {
                   Id = 2,
                   Nombre = "Primium Vista a la Psicina",
                   Detalle = "Detalle de la Villa...",
                   ImagenUrl = "",
                   Ocupantes = 4,
                   MetrosCuadrados = 40,
                   Tarifa = 150,
                   Amenidad = "",
                   FechaCreacion = DateTime.Now,
                   FechaActualizacion = DateTime.Now
               }
            );
        }

    }
}
