using System;
using Isen.DotNet.Library.Models.Implementation;
using CsvHelper.Configuration;
using CsvHelper;

namespace Isen.DotNet.Library.Utilities
{
    public sealed class PiMap : ClassMap<pointDinteret>
{
    public PiMap()
    {
        Map( m => m.Id );
        Map( m => m.Name );
        Map(m => m.Categorie.Name).Name("Categorie");
        Map(m => m.Descriptif);
        Map(m => m.Adresse.LigneDeTexte).Name("Adresse");
    }
}
}

