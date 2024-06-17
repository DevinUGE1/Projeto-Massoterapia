using Massoterapia.Models;
using Microsoft.EntityFrameworkCore;

namespace Massoterapia.Data
{
    public class BancoDados :DbContext
    {
        string _conexao = @"Server=DEVINU;Database=Massoterapia-Novo;Integrated Security=True;TrustServerCertificate=True;";

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        public DbSet<Avaliacao> Avaliacaos { get; set; }

        public BancoDados()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_conexao);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Massoterapia.Models.RegistroViewModel>? RegistroViewModel { get; set; }
    }
}
