using System;
using Isen.DotNet.Library.Models.Implementation;
using CsvHelper.Configuration;
using CsvHelper;

namespace Isen.DotNet.Library.Utilities
{
    public sealed class DepartementMap : ClassMap<departement>
{
    public DepartementMap()
    {
        Map( m => m.Id );
        Map( m => m.Name ).Name("Name");
        Map(m => m.Code).Name("Code");
        
    }
}
}

