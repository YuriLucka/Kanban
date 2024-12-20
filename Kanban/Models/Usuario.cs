using System;
using System.Collections.Generic;

namespace Kanban.Models
{
    public class Usuario
    {
        // Identificador
        public int ID { get; set; }

        // Dados
        public string Nome { get; set; }
        public string FotoPerfil { get; set; }

        // Relacionamento
        public ICollection<UsuarioArea> Areas { get; set; }
        public ICollection<ResponsavelTarefa> TarefasResponsaveis { get; set; }
        public ICollection<Tarefa> TarefaSolicitadas { get; set; }
    }
}
