using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3Laboratorio.Entidades;

namespace Tarea3Laboratorio.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Roles> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\datosUsuarios.Db");
        }
    }
}
