using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryDepartementRepository : BaseInMemoryRepository<departement>, IDepartementRepository
    {
        public InMemoryDepartementRepository(
            ILogger<InMemoryDepartementRepository> logger
        ) : base(logger) {}

        public override IQueryable<departement> ModelCollection
        {
            get
            {
                if(_modelCollection == null)
                {
                    _modelCollection = new List<departement>
                    {
                        new departement {Id = 1, Code = 4, Name = "Alpes-de-Haute-Provence" },
                        new departement {Id = 2, Code = 83, Name = "Var"}
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }
    }

    
}