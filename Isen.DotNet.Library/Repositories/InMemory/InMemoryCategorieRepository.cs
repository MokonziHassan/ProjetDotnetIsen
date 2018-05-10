using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryCategorieRepository : BaseInMemoryRepository<categorie>, ICategorieRepository
    {
        public InMemoryCategorieRepository(
            ILogger<InMemoryCategorieRepository> logger 
            
        ) : base(logger) {}

        public override IQueryable<categorie> ModelCollection
        {
            get{
                if (_modelCollection == null)
                {
                    _modelCollection = new List<categorie>
                    {
                        new categorie { Id=1, Name="Restauration", Descriptif="Lieu Familial"},
                        new categorie {Id=2, Name="Lieu Touristique", Descriptif="On s'y baigne et bronze bien"}
                    };
                }
                return _modelCollection.AsQueryable();
            }

        }
    }
}