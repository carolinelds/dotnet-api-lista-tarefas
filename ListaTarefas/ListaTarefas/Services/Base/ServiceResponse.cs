using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTarefas.Services.Base
{
    public class ServiceResponse<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T ObjetoRetorno { get; set; }

        public ServiceResponse(string mensagemDeErro)
        {
            Sucesso = false;
            Mensagem = mensagemDeErro;
            ObjetoRetorno = default;
        }

        public ServiceResponse(T objeto)
        {
            Sucesso = true;
            Mensagem = String.Empty;
            ObjetoRetorno = objeto;
        }
    }
}
