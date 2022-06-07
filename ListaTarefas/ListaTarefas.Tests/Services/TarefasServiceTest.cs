using Microsoft.EntityFrameworkCore;
using ListaTarefas.DAL;
using ListaTarefas.Domain.DTO;
using ListaTarefas.Services;
using ListaTarefas.Domain;
using System;
using Xunit;
using ListaTarefas.Domain.Entity;

namespace ListaTarefas.Tests.Services
{
    public partial class TarefasServiceTest : IDisposable
    {
        private readonly AppDbContext _dbContext;
        private readonly TarefasService _service;

        public TarefasServiceTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _dbContext = new AppDbContext(options);
            _service = new TarefasService(_dbContext);
        }

        private List<Tarefa> ListaTarefasStub()
        {
            var lista = new List<Tarefa>()
            {
                new Tarefa()
                {
                    IdTarefa = 1,
                    Titulo = "Tarefa Test 1",
                    Descricao = "Descricao Test 1",
                    Concluido = false,
                    Prioridade = 5
                },
                new Tarefa()
                {
                    IdTarefa = 2,
                    Titulo = "Tarefa Test 2",
                    Descricao = "Descricao Test 2",
                    Concluido = true,
                    Prioridade = 1
                }
            };

            _dbContext.AddRange(lista);
            _dbContext.SaveChanges();

            return lista;
        }
            
        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            GC.SuppressFinalize(this);
        }
    }
}
