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
                        new commune {Id=1, Name="La Garde", Latitude=43.56F, Longitude=44.67F},
                        new commune {Id=2, Name="La Valette", Latitude=48.87F, Longitude=49.90F }
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }
    }

    
}