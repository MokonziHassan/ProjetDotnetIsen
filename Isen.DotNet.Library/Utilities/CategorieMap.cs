using System;
using Isen.DotNet.Library.Models.Implementation;
using CsvHelper.Configuration;
using CsvHelper;

namespace Isen.DotNet.Library.Utilities
{
    public sealed class CategorieMap : ClassMap<categorie>
{
    public CategorieMap()
    {
        Map( m => m.Id );
        Map( m => m.Name ).Name("Name");
        Map(m => m.Descriptif).Name("Descriptif");
        
    }
}
}

