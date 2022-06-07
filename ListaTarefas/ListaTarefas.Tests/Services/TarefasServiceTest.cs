﻿using Microsoft.EntityFrameworkCore;
using ListaTarefas.DAL;
using ListaTarefas.Domain.DTO;
using ListaTarefas.Services;
using ListaTarefas.Services.Base;
using ListaTarefas.Domain;
using System;
using Xunit;
using ListaTarefas.Domain.Entity;

namespace ListaTarefas.Tests.Services
{
    public class TarefasServiceTest : IDisposable
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

        [Fact]
        public void Quando_ChamadoListarTodos_Deve_RetornarTodos()
        {
            var lista = ListaTarefasStub();

            var retorno = new List<Tarefa>(_service.ListarTodos());

            Assert.Equal(retorno.Count, lista.Count());
        }

        [Fact]
        public void Quando_ChamadoPesquisaPorId_Com_IdExistente_Deve_RetornarTarefa()
        {
            var lista = ListaTarefasStub();

            var retorno = _service.PesquisarPorId(lista[0].IdTarefa);

            Assert.Equal(retorno.ObjetoRetorno.IdTarefa, lista[0].IdTarefa);
            Assert.Equal(retorno.ObjetoRetorno.Titulo, lista[0].Titulo);
            Assert.Equal(retorno.ObjetoRetorno.Descricao, lista[0].Descricao);
            Assert.Equal(retorno.ObjetoRetorno.Concluido, lista[0].Concluido);
            Assert.Equal(retorno.ObjetoRetorno.Prioridade, lista[0].Prioridade);
        }

        [Fact]
        public void Quando_ChamadoPesquisaPorId_Com_IdNaoExistente_Deve_RetornarErro()
        {
            var lista = ListaTarefasStub();

            var mensagemEsperada = "Tarefa não encontrada!";

            var retorno = _service.PesquisarPorId(lista.Count + 1);

            Assert.False(retorno.Sucesso);
            Assert.Equal(retorno.Mensagem, mensagemEsperada);
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
