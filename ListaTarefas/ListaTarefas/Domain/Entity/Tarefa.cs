using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ListaTarefas.Domain.Entity
{
    [Table("Tarefas")]
    public class Tarefa
    {
        [Key]
        public int IdTarefa { get; set; }

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }

        public string Descricao { get; set; }
        public bool Concluido { get; set; }
        public int? Prioridade { get; set; }
    }
}
