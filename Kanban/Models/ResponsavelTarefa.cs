using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class ResponsavelTarefa
    {
        // Identificador
        public int ID { get; set; }

        [Display(Name = "Responsável")]
        public int UsuarioID { get; set; }
        public int TarefaID { get; set; }
        public int TipoResponsabilidadeID { get; set; }

        // Relacionamento
        public virtual Usuario Usuario { get; set; }
        public virtual Tarefa Tarefa { get; set; }
        public virtual Responsabilidade Responsabilidade { get; set; }
    }
}