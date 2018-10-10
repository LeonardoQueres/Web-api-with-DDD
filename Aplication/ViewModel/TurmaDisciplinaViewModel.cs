using AutoMapper;
using Domain.Entidade;
using Shared.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Aplication.ViewModel
{
    public class TurmaDisciplinaViewModel : BaseViewModel
    {
        public string DisciplinaId { get; set; }
        public string TurmaId { get; set; }
        public static void Mapping(Profile mapper)
        {
            mapper.CreateMap<TurmaDisciplinaViewModel, TurmaDisciplina>()
                .ForMember(dest => dest.DisciplinaId, opt => opt.MapFrom(orig => orig.DisciplinaId))
                .ForMember(dest => dest.TurmaId, opt => opt.MapFrom(orig => orig.TurmaId));

            mapper.CreateMap<TurmaDisciplina, TurmaDisciplinaViewModel>()
                .ForMember(dest => dest.DisciplinaId, opt => opt.MapFrom(orig => orig.DisciplinaId))
                .ForMember(dest => dest.TurmaId, opt => opt.MapFrom(orig => orig.TurmaId));
        }
    }

    public class TurmaDisciplinaTelaViewModel
    {
        public TurmaDisciplinaTelaViewModel()
        {

        }

        public TurmaDisciplinaTelaViewModel(TurmaDisciplinaViewModel turmaDisciplina)
        {
            ApenasUmTurmaDisciplina = true;
            TurmaDisciplinas = new TurmaDisciplinaViewModel[1] { turmaDisciplina };
        }

        public TurmaDisciplinaTelaViewModel(IEnumerable<TurmaDisciplinaViewModel> turmaDisciplina)
        {
            ApenasUmTurmaDisciplina = false;
            TurmaDisciplinas = (turmaDisciplina.Count() > 0 ? turmaDisciplina.ToArray() : null);
        }

        public bool ApenasUmTurmaDisciplina { get; set; }

        public TurmaDisciplinaViewModel[] TurmaDisciplinas { get; set; }

        #region Campos da tela

        public IDictionary<string, string> Disciplinas { get; set; }

        #endregion
    }
}
