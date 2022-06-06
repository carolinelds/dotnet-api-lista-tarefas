using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ListaTarefas.Domain.Entity;
using ListaTarefas.Services;
using ListaTarefas.Domain.DTO;
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

        [HttpPost]
        public IActionResult Post([FromBody] TarefaCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = _tarefasService.CadastrarNova(postModel);
                if (retorno.Sucesso == true)
                {
                    return Ok(retorno.ObjetoRetorno);
                }
                else
                {
                    return BadRequest(retorno.Mensagem);
                }
            } 
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("Done/{id}")]
        public IActionResult Put(int id, [FromBody] ConcluidoUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = _tarefasService.EditarConcluido(id, putModel);
                if (retorno.Sucesso != true)
                {
                    return BadRequest(retorno.Mensagem);
                }
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("Priority/{id}")]
        public IActionResult Put(int id, [FromBody] PrioridadeUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = _tarefasService.EditarPrioridade(id, putModel);

                if (retorno.Sucesso != true)
                {
                    return BadRequest(retorno.Mensagem);
                }
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var retorno = _tarefasService.Deletar(id);

            if (retorno.Sucesso != true)
            {
                return BadRequest(retorno.Mensagem);
            }
            return Ok(retorno.ObjetoRetorno);
        }

    }
}
