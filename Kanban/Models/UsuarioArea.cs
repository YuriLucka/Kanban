namespace Kanban.Models
{
    public class UsuarioArea
    {
        // Identificador
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int DepartamentoID { get; set; }

        // Relacionamento
        public Usuario Usuario { get; set; }
        public Area Departamento { get; set; }
    }
}