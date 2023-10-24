using GestorHorasDeServicios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GestorHorasDeServicios.DataAccess
{
    public class GestorDbContext : DbContext
    {   
        //Metodo conectar en memoria
        /*public GestorDbContext(DbContextOptions<GestorDbContext>options) : base(options)
        {
            FillServicio();
            FillProyectos();
            FillTrabajos();
            FillUsuario();
        }*/

        public DbSet<Servicios> Servicio { get; set; }
        public DbSet<Proyectos> Proyectos  { get; set; }
        public DbSet<Trabajos> Trabajos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        public GestorDbContext(DbContextOptions<GestorDbContext> options) : base(options)
        {

        }
        //Metodo PDF
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lean2\\OneDrive\\Documentos\\GestorDb.mdf;Integrated Security=True;Connect Timeout=30");
        }*/


        /*private void FillServicio()
        {
            if (Servicio.Count() == 0)
            {
              Servicio.Add(new Servicios
              {
                CodServicio = 1,
                Descr = "Servicio 1",
                Estado = true,
                ValorHora = 20.10
              });
               Servicio.Add(new Servicios
               {
                 CodServicio = 2,
                 Descr = "Servicio 2",
                 Estado = false,
                 ValorHora = 50.10
               });
                this.SaveChanges();
            }
        }

        private void FillProyectos()
        {
            if (Proyectos.Count() == 0)
            {
                Proyectos.Add(new Proyectos
                {
                    CodProyecto = 1,
                    Nombre = "Proyecto 1",
                    Dirección = "calle 123",
                    Estado = 2
                });
                Proyectos.Add(new Proyectos
                {
                    CodProyecto = 2,
                    Nombre = "Proyecto 2",
                    Dirección = "avenida 123",
                    Estado = 1
                });
                this.SaveChanges();
            }
        }

        private void FillTrabajos()
        {
            if (Trabajos.Count() == 0)
            {
                Trabajos.Add(new Trabajos
                {
                    CodTrabajo = 1,
                    Fecha = new DateTime(2023, 10, 13),
                    CodProyecto = 1,
                    CodServicio = 2,
                    CantHoras = 3,
                    ValorHora = 4,
                    Costo = 5,
                });
                Trabajos.Add(new Trabajos
                {
                    CodTrabajo = 2,
                    Fecha = new DateTime(1994, 09, 17),
                    CodProyecto = 2,
                    CodServicio = 1,
                    CantHoras = 8,
                    ValorHora = 2,
                    Costo = 1,
                });
                this.SaveChanges();
            }
        }

        private void FillUsuario()
        {
            if (Usuario.Count() == 0)
            {
                Usuario.Add(new Usuario
                {
                    CodUsuario = 1,
                    Nombre = "Servicio 1",
                    Dni = 20888999,
                    Tipo = 1,
                    Contraseña = "asado"
                });
                Usuario.Add(new Usuario
                {
                    CodUsuario = 2,
                    Nombre = "Servicio 2",
                    Dni = 12345678,
                    Tipo = 2,
                    Contraseña = "milanesa"
                });
                this.SaveChanges();
            }
        }*/
    }
}
