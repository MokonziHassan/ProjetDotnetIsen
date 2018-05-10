using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Reflection.Emit.AssemblyBuilder;

namespace Isen.DotNet.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SeedData> _logger;
        private readonly IPiRepository _piRepository;
        private readonly ICommuneRepository _communeRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IAdresseRepository _adresseRepository;
        public SeedData(
            ApplicationDbContext context,
            ILogger<SeedData> logger,
            IPiRepository piRepository,
            ICategorieRepository categorieRepository,
            IAdresseRepository adresseRepository,
            ICommuneRepository communeRepository)
        {
            _context = context;
            _logger = logger;
            _piRepository = piRepository;
            _categorieRepository = categorieRepository;
            _communeRepository = communeRepository;
            _adresseRepository = adresseRepository;
        }

        public void DropDatabase()
        {
            var deleted = _context.Database.EnsureDeleted();
            var not = deleted ? "" : "not ";
            _logger.LogWarning($"Database was {not}dropped.");
        }

        public void CreateDatabase()
        {
            var created = _context.Database.EnsureCreated();
            var not = created ? "" : "not ";
            _logger.LogWarning($"Database was {not}created.");
        }

      /*  public void AddPi()
        {
            if (_piRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding PI");

            var pi = new List<pointDinteret>
            {
                new pointDinteret {Id = 1, Name = "KFC Toulon Liberté", Descriptif="Place ou on vend de la nourriture", Categorie=_categorieRepository.Single("Restauration") , Adresse = _adresseRepository.Single(1)},
                new pointDinteret {Id=2, Name="Isen Toulon", Descriptif="Référence en terme de formation d'ingénieurs", Categorie=_categorieRepository.Single("Lieu Touristique"), Adresse = _adresseRepository.Single(2)}
            };
            _piRepository.UpdateRange(pi);
            _piRepository.Save();

            _logger.LogWarning("Added PI");
        }

        public void AddCommune()
        {
            if (_communeRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding Commune");

            var commune = new List<commune>
            {
                new commune
                {
                    Name = "John",
                    Latitude = 45,
                    Longitude = 47
                },
                new commune
                {
                    Name = "John",
                    Latitude = 45,
                    Longitude = 47
                },
                new commune
                {
                    Name = "John",
                    Latitude = 45,
                    Longitude = 47
                }
            };
            _communeRepository.UpdateRange(commune);
            _communeRepository.Save();

            _logger.LogWarning("Added commune");
        }

        public void AddCategories()
        {
            if (_categorieRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding Categories");

            var categorie = new List<categorie>
            {
                new categorie 
                {
                    Name = "Hotellerie",
                    Descriptif = "Lieu d'hébergement"
                },
                new categorie
                {
                    Name = "Restauration",
                    Descriptif = "Lieu où on peut se nourrir"
                }
            };
            _categorieRepository.UpdateRange(categorie);
            _categorieRepository.Save();

            _logger.LogWarning("Added categorie");
        }

        public void AddAdresse()
        {
            if (_adresseRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding Adresses");
            var adresse = new List<adresse>
            {
                new adresse
                    {
                    Id=1, 
                    LigneDeTexte="282 Boulevard Léon Bourgois", 
                    CodePostal = 83100
                    
                    
                    },
                    new adresse
                    {
                        Id = 2,
                        LigneDeTexte = "Maison du Numérique et de l'Innovation, Place Georges Pompidou",
                        CodePostal = 83000
                    
                    }
            }; 
            
        }*/

        Assembly assembly = Ass
    }
}