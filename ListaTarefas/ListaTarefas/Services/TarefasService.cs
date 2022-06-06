using Microsoft.EntityFrameworkCore;
using ListaTarefas.DAL;
using ListaTarefas.Domain.Entity;
using ListaTarefas.Services.Base;
using ListaTarefas.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ListaTarefas.Services
{
    public class TarefasService
    {

        private readonly AppDbContext _dbContext;
        public TarefasService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Tarefa> ListarTodos()
        {
            return _dbContext.Tarefas.ToList();
        }

        public ServiceResponse<Tarefa> PesquisarPorId(int id)
        {
            var resultado = _dbContext.Tarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

            if (resultado != null)
            {
                return new ServiceResponse<Tarefa>(resultado);
            }
            else
            {
                return new ServiceResponse<Tarefa>("Tarefa não encontrada!");
            }
        }

        public ServiceResponse<Tarefa> CadastrarNova(TarefaCreateRequest model)
        {
            if (!model.Prioridade.HasValue)
            {
                model.Prioridade = 5;
            }

            var novaTarefa = new Tarefa()
            {
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Prioridade = model.Prioridade,
                Concluido = false
            };

            _dbContext.Add(novaTarefa);
            _dbContext.SaveChanges();

            return new ServiceResponse<Tarefa>(novaTarefa);
        }

        public ServiceResponse<Tarefa> EditarConcluido(int id, ConcluidoUpdateRequest model)
        {
            var resultado = _dbContext.Tarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

            if (resultado != null)
            {
                resultado.Concluido = model.Concluido;

                _dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return new ServiceResponse<Tarefa>(resultado);
            }
            else
            {
                return new ServiceResponse<Tarefa>("Tarefa não encontrada!");
            }
        }

        public ServiceResponse<Tarefa> EditarPrioridade(int id, PrioridadeUpdateRequest model)
        {
            if (model.Prioridade == null)
            {
                return new ServiceResponse<Tarefa>("Valor não pode ser null");
            }

            var resultado = _dbContext.Tarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

            if (resultado != null)
            {
                resultado.Prioridade = model.Prioridade;

                _dbContext.Tarefas.Add(resultado).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return new ServiceResponse<Tarefa>(resultado);
            }
            else
            {
                return new ServiceResponse<Tarefa>("Tarefa não encontrada!");
            }
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = _dbContext.Tarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

            if (resultado == null)
            {
                return new ServiceResponse<bool>("Tarefa não encontrada!");
            }

            _dbContext.Tarefas.Remove(resultado);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);

        }
    }
}
