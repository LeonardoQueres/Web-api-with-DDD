using AutoMapper;
using Domain.Entidade;
using Shared.Tools;
using Shared.ViewModel;

namespace Aplication.ViewModel
{
    public class AlunoViewModel : BaseViewModel
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<AlunoViewModel, Aluno>()
                .ForMember(dest => dest.Matricula, opt => opt.MapFrom(orig => orig.Matricula))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(orig => orig.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(orig => orig.Cpf.RemoverCaracteres()));


            mapper.CreateMap<Aluno, AlunoViewModel>()
                .ForMember(dest => dest.Matricula, opt => opt.MapFrom(orig => orig.Matricula))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(orig => orig.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(orig => orig.Cpf.FormatarCPF()));
        }
    }
}
