using AutoMapper;
using Domain.Entidade;
using Shared.ViewModel;

namespace Aplication.ViewModel
{
    public class DisciplinaViewModel : BaseViewModel
    {
        public string Descricao { get; set; }

        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<DisciplinaViewModel, Disciplina>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(orig => orig.Descricao));

            mapper.CreateMap<Disciplina, DisciplinaViewModel>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(orig => orig.Descricao));
        }
    }
}
