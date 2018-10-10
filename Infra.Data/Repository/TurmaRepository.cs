using Domain.Entidade;
using Domain.Interface.Repository;
using FileSys.Shared.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class TurmaRepository : BaseCrudRepository<Turma>, ITurmaRepository
    {
        private readonly AdminContext dbContext;

        public TurmaRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IDictionary<string, string> RecuperarDropDown()
        {
            return dbContext.Set<Turma>()
                .AsNoTracking()
                .OrderBy(x => x.Descricao)
                .ToDictionary(x => x.Id, x => x.Descricao);
        }
    }
}
