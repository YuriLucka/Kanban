using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("AreaTarefa")]
    public class AreaTarefa
    {
        // Identificador
        public int ID { get; set; }
        public int AreaID { get; set; }
        public int TarefaID { get; set; }

        // Relacionamentos
        public Area Area { get; set; }
        public Tarefa Tarefa { get; set; }


    }
}