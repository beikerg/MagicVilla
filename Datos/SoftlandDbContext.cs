using MagicVilla.Modelo;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla.Datos
{
    public class SoftlandDbContext: DbContext
    {
       
        public SoftlandDbContext(DbContextOptions<SoftlandDbContext> options) : base(options) 
        
        {

        }



        //public DbSet<Cuentas> cwpctas { get; set; }
        public DbSet<Tienda> Productos { get; set; }

        // Bases de datos 
        public DbSet<SwBDSoftland> SwBDSoftland { get; set; }



       
        public DbSet<Mesess> meses { get; set; }
        public DbSet<Personal> sw_personal { get; set; }

        public DbSet<PlanCuentas> cwpctas { get; set; }


    }
}


