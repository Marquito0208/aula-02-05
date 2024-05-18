using Microsoft.EntityFrameworkCore;

namespace aula_02_05.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }


        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Jogo> Jogos { get; set;}

        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public DbSet<Comentario > Comentarios { get; set; }
    }
}
