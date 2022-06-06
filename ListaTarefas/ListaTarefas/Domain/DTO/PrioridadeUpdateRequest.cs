using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Domain.DTO
{
    public class PrioridadeUpdateRequest
    {
        [Required]
        [Range(1,5)]
        public int? Prioridade { get; set; }
    }
}
