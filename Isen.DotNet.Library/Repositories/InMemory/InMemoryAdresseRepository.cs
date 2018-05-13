using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.InMemory
{

    public class InMemoryAdresseRepository : BaseInMemoryRepository<adresse>, IAdresseRepository
    {
        private List<ICommuneRepository> _communeRepository;
        public InMemoryAdresseRepository (
            ILogger<InMemoryAdresseRepository> logger,
            List<ICommuneRepository> communeRepository
        ) : base(logger) {
            _communeRepository = communeRepository;
        }

        public override IQueryable<adresse> ModelCollection
    {
        get
        {
            if (_modelCollection == null)
            {
                _modelCollection = new List<adresse>
                {
                    new adresse
                    {
                    Id=1, 
                    LigneDeTexte="282 Boulevard Léon Bourgois", 
                    CodePostal = "83100"
                    
                    
                    },
                    new adresse
                    {
                        Id = 2,
                        LigneDeTexte = "Maison du Numérique et de l'Innovation, Place Georges Pompidou",
                        CodePostal = "83000"
                    
                    }
                };

                

            
                
            }
            return _modelCollection.AsQueryable();
        }
    }
    }

    
}