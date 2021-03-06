using System;
using Isen.DotNet.Library.Models.Implementation;
using CsvHelper.Configuration;
using CsvHelper;

namespace Isen.DotNet.Library.Utilities
{
    public sealed class AdresseMap : ClassMap<adresse>
{
    public AdresseMap()
    {
        Map( m => m.Id );
        Map( m => m.LigneDeTexte );
        Map(m => m.Commune.Name).Name("Commune");
        Map(m => m.CodePostal).Name("CodePostal");
        Map(m => m.Latitude);
        Map(m => m.Longitude);
        
        
    }
}
}

