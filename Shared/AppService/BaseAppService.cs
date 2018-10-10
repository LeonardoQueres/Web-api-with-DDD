using AutoMapper;
using Shared.Interface.AppService;
using Shared.Interface.Entity;
using Shared.Interface.Service;
using Shared.Interface.Validator;
using System.Collections.Generic;

namespace Shared.AppService
{
    public class BaseAppService<TViewModel, TEntity, TType> : IBaseAppService<TViewModel, TEntity, TType> where TEntity : class, IEntity<TEntity, TType>
    {
        private readonly IBaseService<TEntity, TType> service;
        private readonly IMapper mapper;

        public BaseAppService(
            IBaseService<TEntity, TType> service,
            IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public virtual IResultadoApplication<ICollection<TViewModel>> RecuperarTodos()
        {
            var result = new ResultadoApplication<ICollection<TViewModel>>();

            try
            {
                result.DefinirData(mapper.Map<ICollection<TViewModel>>(service.RecuperarTodos()));
                result.ExecutadoComSuccesso();
            }
            catch (System.Exception ex)
            {
                result.ExecutadoComErro(ex);
            }

            return result;
        }

        public virtual IResultadoApplication<TViewModel> RecuperarPorId(TType id)
        {
            var result = new ResultadoApplication<TViewModel>();

            try
            {
                var data = service.RecuperarPorId(id);
                result.DefinirData(mapper.Map<TViewModel>(data));
                result.ExecutadoComSuccesso();
            }
            catch (System.Exception ex)
            {
                result.ExecutadoComErro(ex);
            }

            return result;
        }
    }
}
