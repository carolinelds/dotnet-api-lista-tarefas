using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Domain.DTO
{
    public class TarefaCreateRequest
    {
        [Required(ErrorMessage = "Título é obrigatório")]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        [Range(1,5)]
        public int? Prioridade { get; set; }
    }
}
