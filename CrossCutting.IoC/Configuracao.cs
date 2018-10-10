using Aplication;
using Aplication.AppService;
using Aplication.Interface;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using Domain.Service;
using Infra.Data;
using Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;

namespace CrossCutting.IoC
{
    public class Configuracao
    {
        public static void InjecaoDependencia(IServiceCollection services)
        {
            services.AddDbContext<AdminContext>(options =>
                  options.UseSqlServer("workstation id=testebanco.mssql.somee.com;packet size=4096;user id=leonardoqueres_SQLLogin_1;pwd=k3ttqtt15e;data source=testebanco.mssql.somee.com;persist security info=False;initial catalog=testebanco"));

            services.AddAutoMapper(typeof(ConfigurationProfile).GetTypeInfo().Assembly,
                typeof(ConfigurationProfile).GetTypeInfo().Assembly);

            #region Aluno
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            #endregion

            #region Disciplina
            services.AddScoped<IDisciplinaAppService, DisciplinaAppService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            #endregion

            #region Turma
            services.AddScoped<ITurmaAppService, TurmaAppService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            #endregion

            #region TurmaAluno
            services.AddScoped<ITurmaAlunoService, TurmaAlunoService>();
            services.AddScoped<ITurmaAlunoRepository, TurmaAlunoRepository>();
            #endregion

            #region TurmaDisciplina
            services.AddScoped<ITurmaDisciplinaService, TurmaDisciplinaService>();
            services.AddScoped<ITurmaDisciplinaRepository, TurmaDisciplinaRepository>();
            #endregion

            #region ValidarCpf
            services.AddScoped<IValidarCpfAppService, ValidarCpfAppService>();
            services.AddScoped<IValidarCpfService, ValidarCpfService>();
            #endregion

            services.AddScoped<AdminContext>();
        }
    }
}
