using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kanban.Models
{
    [Table("Registro")]
    public class Registro
    {
        // Identificador
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public int TarefaID { get; set; }

        // Dados
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Data { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? HoraInicial { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? HoraFinal { get; set; }

        // Relacionamentos
        public Usuario Usuario { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}