using AutoMapper;
using Domain.Entidade;
using Shared.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Aplication.ViewModel
{
    public class TurmaAlunoViewModel : BaseViewModel
    {
        public string AlunoId { get; set; }
        public string TurmaId { get; set; }
        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<TurmaAlunoViewModel, TurmaAluno>()
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(orig => orig.AlunoId))
                .ForMember(dest => dest.TurmaId, opt => opt.MapFrom(orig => orig.TurmaId));

            mapper.CreateMap<TurmaAluno, TurmaAlunoViewModel>()
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(orig => orig.AlunoId))
                .ForMember(dest => dest.TurmaId, opt => opt.MapFrom(orig => orig.TurmaId));
        }
    }

    public class TurmaAlunoTelaViewModel
    {
        public TurmaAlunoTelaViewModel()
        {

        }

        public TurmaAlunoTelaViewModel(TurmaAlunoViewModel turmaAluno)
        {
            ApenasUmTurmaAluno = true;
            TurmaAlunos = new TurmaAlunoViewModel[1] { turmaAluno };
        }

        public TurmaAlunoTelaViewModel(IEnumerable<TurmaAlunoViewModel> turmaAluno)
        {
            ApenasUmTurmaAluno = false;
            TurmaAlunos = (turmaAluno.Count() > 0 ? turmaAluno.ToArray() : null);
        }

        public bool ApenasUmTurmaAluno { get; set; }

        public TurmaAlunoViewModel[] TurmaAlunos { get; set; }

        #region Campos da tela

        public IDictionary<string, string> Alunos { get; set; }

        #endregion
    }
}
