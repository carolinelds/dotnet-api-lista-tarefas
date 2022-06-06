using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Domain.DTO
{
    public class TarefaUpdateRequest
    {
        [Required]
        [Range(typeof(bool), "false", "true")]
        public bool Concluido { get; set;}
    }
}
