using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kanban.Models
{
    public class Tarefa
    {
        // Identificador
        public int ID { get; set; }

        [Display(Name = "Solicitante")]
        public int UsuarioID { get; set; }
        public int? StatusTarefaID { get; set; }
        public int? NivelPrioridadeID { get; set; }

        // Dados
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCriacao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataConclusao { get; set; }

        // Relacionamento
        public virtual Usuario Usuario { get; set; }
        public virtual StatusTarefa Status { get; set; }
        public virtual Prioridade Prioridade { get; set; }
        public virtual ICollection<ResponsavelTarefa> Responsaveis { get; set; }
        public virtual ICollection<AreaTarefa> Areas { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Registro> Registros { get; set; }
    }
}
