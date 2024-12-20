using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("Area")]
    public class Area
    {
        // Identificador
        public int ID { get; set; }

        // Dado
        public string Nome { get; set; }

        // Relacionamento
        public ICollection<UsuarioArea> Usuarios { get; set; }
        public ICollection<ResponsavelTarefa> Tarefas { get; set; }
    }
}

