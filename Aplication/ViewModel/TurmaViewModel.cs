using AutoMapper;
using Domain.Entidade;
using Shared.ViewModel;
using System.Collections.Generic;

namespace Aplication.ViewModel
{
    public class TurmaViewModel : BaseViewModel
    {
        public TurmaViewModel()
        {
            TelaTurmaAluno = new TurmaAlunoTelaViewModel();
            TelaTurmaDisciplina = new TurmaDisciplinaTelaViewModel();
        }

        public string Descricao { get; set; }
        public TurmaAlunoTelaViewModel TelaTurmaAluno { get; set; }
        public TurmaDisciplinaTelaViewModel TelaTurmaDisciplina { get; set; }
        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<TurmaViewModel, Turma>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(orig => orig.Descricao))
                .ForMember(dest => dest.turmaAluno, opt => opt.MapFrom(orig => orig.TelaTurmaAluno.TurmaAlunos))
                .ForMember(dest => dest.turmaDisciplina, opt => opt.MapFrom(orig => orig.TelaTurmaDisciplina.TurmaDisciplinas));

            mapper.CreateMap<Turma, TurmaViewModel>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(orig => orig.Descricao))
                .ForMember(dest => dest.TelaTurmaAluno, opt => opt.MapFrom(orig => new TurmaAlunoTelaViewModel(Mapper.Map<IEnumerable<TurmaAluno>, TurmaAlunoViewModel[]>(orig.turmaAluno))))
                .ForMember(dest => dest.TelaTurmaDisciplina, opt => opt.MapFrom(orig => new TurmaDisciplinaTelaViewModel(Mapper.Map<IEnumerable<TurmaDisciplina>, TurmaDisciplinaViewModel[]>(orig.turmaDisciplina))));
        }
    }
}
