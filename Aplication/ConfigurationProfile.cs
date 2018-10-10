using Aplication.ViewModel;
using AutoMapper;

namespace Aplication
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            Shared.Conversores.Configuracao.Registrar(this);
            this.AllowNullCollections = true;

            AlunoViewModel.Mapping(this);
            DisciplinaViewModel.Mapping(this);
            TurmaViewModel.Mapping(this);
            TurmaAlunoViewModel.Mapping(this);
            TurmaDisciplinaViewModel.Mapping(this);
        }
    }
}
