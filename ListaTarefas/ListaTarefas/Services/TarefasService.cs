﻿using ListaTarefas.Domain.Entity;
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

        public ServiceResponse<Tarefa> CadastrarNova(TarefaCreateRequest tarefa)
        {
            if (!tarefa.Prioridade.HasValue)
            {
                tarefa.Prioridade = 5;
            }

            var novaTarefa = new Tarefa()
            {
                IdTarefa = proximoId++,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Prioridade = tarefa.Prioridade,
                Concluido = false
            };

            listaDeTarefas.Add(novaTarefa);

            return new ServiceResponse<Tarefa>(novaTarefa);
        }
    }
}
