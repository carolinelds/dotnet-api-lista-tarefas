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
        private static List<Tarefa> listaDeTarefas;
        private static int proximoId = 1;

        public TarefasService()
        {
            if (listaDeTarefas == null)
            {
                listaDeTarefas = new List<Tarefa>();

                listaDeTarefas.Add(new Tarefa()
                {
                    IdTarefa = proximoId++,
                    Titulo = "Beber água",
                    Descricao = "Importante se hidratar",
                    Concluido = false,
                    Prioridade = 2
                });
                listaDeTarefas.Add(new Tarefa()
                {
                    IdTarefa = proximoId++,
                    Titulo = "Estudar DevOps",
                    Descricao = "Fazer cursos de AWS, Azure e Imersão na Alura",
                    Concluido = false,
                    Prioridade = 5
                });
            }
        }

        public List<Tarefa> ListarTodos()
        {
            return listaDeTarefas;
        }

        public ServiceResponse<Tarefa> PesquisarPorId(int id)
        {
            var resultado = listaDeTarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

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
                IdTarefa = proximoId++,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Prioridade = model.Prioridade,
                Concluido = false
            };

            listaDeTarefas.Add(novaTarefa);

            return new ServiceResponse<Tarefa>(novaTarefa);
        }

        public ServiceResponse<Tarefa> EditarConcluido(int id, ConcluidoUpdateRequest model)
        {
            var resultado = listaDeTarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

            if (resultado != null)
            {
                resultado.Concluido = model.Concluido;
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

            var resultado = listaDeTarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

            if (resultado != null)
            {
                resultado.Prioridade = model.Prioridade;
                return new ServiceResponse<Tarefa>(resultado);
            }
            else
            {
                return new ServiceResponse<Tarefa>("Tarefa não encontrada!");
            }
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = listaDeTarefas.Where(tarefa => tarefa.IdTarefa == id).FirstOrDefault();

            if (resultado == null)
            {
                return new ServiceResponse<bool>("Tarefa não encontrada!");
            }
           
            listaDeTarefas.Remove(resultado);
            return new ServiceResponse<bool>(true);
            
        }
    }
}
