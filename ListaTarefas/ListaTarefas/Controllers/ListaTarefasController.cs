using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ListaTarefas.Domain.Entity;
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
        [HttpGet]
        public IEnumerable<Tarefa> Get()
        {
        
        }

    }
}
