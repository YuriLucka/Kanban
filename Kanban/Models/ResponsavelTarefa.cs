using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("ResponsavelTarefa")]
    public class ResponsavelTarefa
    {
        // Identificador
        public int ID { get; set; }

        [Display(Name = "Responsável")]
        public int UsuarioID { get; set; }
        public int TarefaID { get; set; }
        public int ResponsabilidadeID { get; set; }

        // Relacionamento
        public virtual Usuario Usuario { get; set; }
        public virtual Tarefa Tarefa { get; set; }
        public virtual Responsabilidade Responsabilidade { get; set; }
    }
}