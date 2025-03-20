using EventPlus_.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Context
{

    public class EventContext : DbContext
    {
        public EventContext() 
        {
        }

        public EventContext(DbContextOptions<EventContext> options) : base(options) 
        {
        }
        public DbSet<ComentarioEvento> ComentariosEventos { get; set; }
        public DbSet<Eventos> Evento { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<TipoEvento> TiposEventos { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = NOTE16-S28\\SQLEXPRESS; Database = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");
            }
        }

    }
}
