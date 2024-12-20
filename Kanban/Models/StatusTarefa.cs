using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("StatusTarefa")]
    public class StatusTarefa
    {
        // Identificador
        public int ID { get; set; }

        // Dado
        public string Nome { get; set; }
    }
}