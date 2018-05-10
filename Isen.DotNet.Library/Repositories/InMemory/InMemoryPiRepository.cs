using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Isen.DotNet.Library.Repositories.InMemory
{

    public class InMemoryPiRepository : BaseInMemoryRepository<pointDinteret>, IPiRepository
    {

        private IAdresseRepository _adresseRepository;
        private ICategorieRepository _categorieRepository;
        public InMemoryPiRepository (
            ILogger<InMemoryPiRepository> logger,
            IAdresseRepository adresseRepository,
            ICategorieRepository categorieRepository
        ) : base(logger){ _adresseRepository = adresseRepository; _categorieRepository = categorieRepository;}

        public override IQueryable<pointDinteret> ModelCollection
        {
            get
            {
                if(_modelCollection == null)
                {
                    _modelCollection = new List<pointDinteret>
                    {
                        new pointDinteret {Id = 1, Name = "KFC Toulon Liberté", Descriptif="Place ou on vend de la nourriture", Categorie=_categorieRepository.Single("Restauration") , Adresse = _adresseRepository.Single(1)},
                        new pointDinteret {Id=2, Name="Isen Toulon", Descriptif="Référence en terme de formation d'ingénieurs", Categorie=_categorieRepository.Single("Lieu Touristique"), Adresse = _adresseRepository.Single(2)}
                        
                    };

                    
                }
                return _modelCollection.AsQueryable();
            }
        }
    }
}