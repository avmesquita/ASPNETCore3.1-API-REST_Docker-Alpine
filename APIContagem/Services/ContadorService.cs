using System;
using System.Reflection;
using System.Runtime.Versioning;
using APIContagem.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace APIContagem.Services
{
    public class ContadorService : IContadorService
    {
        private static Contador _CONTADOR = new Contador();
        
        private readonly IConfiguration _configuration;

        public ContadorService(IConfiguration conguration) { 
            this._configuration = conguration;
        }

        public object Get()
        {
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();

                return new
                {
                    _CONTADOR.ValorAtual,
                    Environment.MachineName,
                    Local = "Teste",
                    Sistema = Environment.OSVersion.VersionString,
                    Variavel = this._configuration["TesteAmbiente"],
                    TargetFramework = Assembly
                        .GetEntryAssembly()?
                        .GetCustomAttribute<TargetFrameworkAttribute>()?
                        .FrameworkName
                };
            }
        }
    }
}