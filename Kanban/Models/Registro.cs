using System;

namespace Kanban.Models
{
    public class Registro
    {
        // Identificador
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int TarefaID { get; set; }

        // Dados
        public string Descricao { get; set; }
        public DateTime? Data { get; set; }
        public TimeSpan? HoraInicial { get; set; }
        public TimeSpan? HoraFinal { get; set; }

        // Relacionamentos
        public Usuario Usuario { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}