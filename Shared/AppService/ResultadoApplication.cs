using FluentValidation.Results;
using Shared.Interface.Validator;
using Shared.Tools;
using Shared.Validator;
using System;
using System.Linq;

namespace Shared.AppService
{
    public class ResultadoApplication : IResultadoApplication
    {
        public bool Successo { get; private set; }
        public string Mensagem { get; private set; }
        public string UrlRedirect { get; private set; }

        public IResultadoApplication ExecutadoComSuccesso()
        {
            Successo = true;

            return this;
        }

        public IResultadoApplication ExecutadoComErro(Exception excecao)
        {
            Successo = false;

            Mensagem = excecao.TratarExcecao();

            return this;
        }

        public IResultadoApplication ExecutadoComErro(string message = null)
        {
            Successo = false;

            if (!string.IsNullOrEmpty(message))
                Mensagem = message;

            return this;
        }

        public IResultadoApplication ExibirMensagem(string message)
        {
            Mensagem = message;

            return this;
        }

        public IResultadoApplication Resultado(ValidationResult validate)
        {
            Successo = validate.IsValid;
            Mensagem = string.Join("\n", validate.Errors.Select(x => x.ErrorMessage));

            return this;
        }

        public IResultadoApplication RedirecionarPara(string url)
        {
            UrlRedirect = url;

            return this;
        }

        public virtual object Retorno()
        {
            return new
            {
                success = Successo,
                message = Mensagem,
                urlRedirect = UrlRedirect
            };
        }

    }

    public class ResultadoApplication<TData> : ResultadoApplication, IResultadoApplication<TData>
    {
        public TData Data { get; private set; }

        public IResultadoApplication<TData> DefinirData(TData data)
        {
            Data = data;

            return this;
        }

        public override object Retorno()
        {
            return new
            {
                success = Successo,
                message = Mensagem,
                data = Data,
                urlRedirect = UrlRedirect
            };
        }
    }
}
