using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("Prioridade")]
    public class Prioridade
    {
        // Identificador
        public int ID { get; set; }

        // Dado
        public string Nome { get; set; }
    }
}