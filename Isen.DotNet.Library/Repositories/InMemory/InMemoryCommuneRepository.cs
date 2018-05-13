using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryCommuneRepository : BaseInMemoryRepository<commune>, ICommuneRepository
    {
        public InMemoryCommuneRepository(
            ILogger<InMemoryCommuneRepository> logger
        ) : base(logger) {}

        public override IQueryable<commune> ModelCollection
        {
            get
            {
                if(_modelCollection == null)
                {
                    _modelCollection = new List<commune>
                    {
                        new commune {Id=1, Name="La Garde", Latitude="43.56", Longitude="44.67", Code = 5},
                        new commune {Id=2, Name="La Valette", Latitude="48.87", Longitude="49.90", Code = 6 }
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }
    }

    
}