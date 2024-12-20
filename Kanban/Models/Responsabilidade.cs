using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("Responsabilidade")]
    public class Responsabilidade
    {
        // Identificador
        public int ID { get; set; }

        // Dados
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}