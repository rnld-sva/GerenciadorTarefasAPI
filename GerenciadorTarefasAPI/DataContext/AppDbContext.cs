using GerenciadorTarefasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasAPI.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TarefasModel> Tarefas { get; set; }
    }
}
