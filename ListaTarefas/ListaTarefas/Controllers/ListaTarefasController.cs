using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ListaTarefas.Domain.Entity;
using ListaTarefas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaTarefasController : ControllerBase
    {
        private readonly TarefasService _tarefasService;

        public ListaTarefasController(TarefasService tarefasService)
        {
            _tarefasService = tarefasService;
        }

        [HttpGet]
        public IEnumerable<Tarefa> Get()
        {
            return _tarefasService.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = _tarefasService.PesquisarPorId(id);

            if (retorno.Sucesso == true)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

    }
}
