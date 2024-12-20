using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kanban.Models
{
    public class Comentario
    {
        // Identificador
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int TarefaID { get; set; }

        // Dados
        public string Texto { get; set; }

        // Relacionamentos
        public Usuario Usuario { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}