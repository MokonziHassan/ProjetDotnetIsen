using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;
using Isen.DotNet.Library.Utilities;
using Microsoft.Extensions.Logging;
using System.IO;
using CsvHelper;
using Microsoft.EntityFrameworkCore;

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

        public void AddPi()
        {
            if (_piRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding PI");

            /*  var pi = new List<pointDinteret>
              {
                  new pointDinteret {Id = 1, Name = "KFC Toulon Liberté", Descriptif="Place ou on vend de la nourriture", Categorie=_categorieRepository.Single("Restauration") , Adresse = _adresseRepository.Single(1)},
                  new pointDinteret {Id=2, Name="Isen Toulon", Descriptif="Référence en terme de formation d'ingénieurs", Categorie=_categorieRepository.Single("Lieu Touristique"), Adresse = _adresseRepository.Single(2)}
              };
              _piRepository.UpdateRange(pi);
              _piRepository.Save();

              _logger.LogWarning("Added PI");*/
              string fileName = "PointDInteret.csv";
              string path1 = @"SeedData";
              string path;
              path = Path.GetFullPath(path1)+ "\\" + fileName;
            using (var sr = new StreamReader(path))
            {
                var reader = new CsvReader(sr);
                reader.Configuration.MissingFieldFound = null;
                reader.Configuration.RegisterClassMap<PiMap>();
                reader.Read();
                reader.ReadHeader();
                IEnumerable<pointDinteret> points = reader.GetRecords<pointDinteret>();

                _piRepository.UpdateRange(points);
                _piRepository.Save();
            }
            List<pointDinteret> pi = new List<pointDinteret>();




            _logger.LogWarning("Addeed Point d'Intérêt");




        }
        public void AddCategories()
        {
            if (_categorieRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding Categories");
            string fileName = "Categorie.csv";
            string path1 = @"SeedData";
            string path;
            path = Path.GetFullPath(path1) + "\\" + fileName;
            using (var sr = new StreamReader(path))
            {
                var reader = new CsvReader(sr);
                reader.Configuration.MissingFieldFound = null;
                reader.Configuration.RegisterClassMap<CategorieMap>();
                reader.Read();
                reader.ReadHeader();
                IEnumerable<categorie> categories = reader.GetRecords<categorie>();

                _categorieRepository.UpdateRange(categories);
                _categorieRepository.Save();
            }

            _logger.LogWarning("Added categorie");
        }

        public void AddAdresse()
        {
            if (_adresseRepository.GetAll().Any()) return;
            _logger.LogWarning("Adding Adresses");
            string fileName = "departementCommune.csv";
            string path1 = @"SeedData";
            string path;

            path = Path.GetFullPath(path1) + "\\" + fileName ;
            using (var sr = new StreamReader(path))
            {
                var reader = new CsvReader(sr);
                reader.Configuration.MissingFieldFound = null;
                reader.Configuration.RegisterClassMap<AdresseMap>();
                reader.Read();
                reader.ReadHeader();
                IEnumerable<adresse> adresses = reader.GetRecords<adresse>();

                _adresseRepository.UpdateRange(adresses);
                _adresseRepository.Save();
            }

        }

        public void AddCommune()
        {
            if(_communeRepository.GetAll().Any()) return;
            _logger.LogInformation("Adding Communes");
            string fileName = "Communes.csv";
            string path1 = @"SeedData";
            string path;
            path = Path.GetFullPath(path1) + "\\" + fileName ;
            using (var sr = new StreamReader(path))
            {
                var reader = new CsvReader(sr);
                reader.Configuration.MissingFieldFound = null;
                reader.Configuration.Delimiter = ";";
                reader.Configuration.RegisterClassMap<CommuneMap>();
                reader.Read();
                reader.ReadHeader();
                IEnumerable<commune> communes = reader.GetRecords<commune>();

                
                _communeRepository.UpdateRange(communes);
                try{
                    _communeRepository.Save();
                }catch(DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if(entry.Entity is commune )
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue =  proposedValues[property];
                                var databaseValue = databaseValues[property];
                            }
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else{
                            throw new System.NotSupportedException(
                                "Don't know how to handle concurency conflicts for "
                                + entry.Metadata.Name
                            );
                        }
                    }
                }
                
            }
        }
    }
}