using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Data;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.DbContext
{
    public class DbContextPiRepository : BaseDbContextRepository<pointDinteret>, IPiRepository
    {
        public DbContextPiRepository(
            ILogger<DbContextPiRepository> logger,
            ApplicationDbContext context
        ) : base(logger, context)
        {}
        public override IQueryable<pointDinteret> Includes(
            IQueryable<pointDinteret> queryable
        ) => queryable.Include(p => p.Adresse).Include(c => c.Categorie);

    }

    

}