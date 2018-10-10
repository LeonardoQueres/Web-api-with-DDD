using Domain.Entidade;
using Domain.Interface.Repository;
using FileSys.Shared.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repository
{
    public class AlunoRepository : BaseCrudRepository<Aluno>, IAlunoRepository
    {
        private readonly AdminContext dbContext;
        public AlunoRepository(AdminContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override IDictionary<string, string> RecuperarDropDown()
        {
            return dbContext.Set<Aluno>()
                .AsNoTracking()
                .OrderBy(x => x.Nome)
                .ToDictionary(x => x.Id, x => x.Nome);
        }
    }
}
