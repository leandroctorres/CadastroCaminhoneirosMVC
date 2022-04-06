using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCaminhoneirosMVC.Models
{
    public class Context : DbContext
    {
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<EnderecoMotorista> EnderecoMotorista { get; set; }
        public DbSet<CaminhaoMotorista> CaminhaoMotorista { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cadastrocaminhoneirosmvc;Integrated Security=True");
        }

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}