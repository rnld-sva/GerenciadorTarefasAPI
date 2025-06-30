using GerenciadorTarefasAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefasAPI.Models
{
    public class TarefasModel
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataVencimento { get; set; }

        public StatusTarefasEnum Status { get; set; }

    }
}
