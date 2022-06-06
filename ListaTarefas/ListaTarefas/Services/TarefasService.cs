using ListaTarefas.Domain.Entity; 
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
    }
}
