using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("UsuarioArea")]
    public class UsuarioArea
    {
        // Identificador
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int AreaID { get; set; }

        // Relacionamento
        public Usuario Usuario { get; set; }
        public Area Area { get; set; }
    }
}