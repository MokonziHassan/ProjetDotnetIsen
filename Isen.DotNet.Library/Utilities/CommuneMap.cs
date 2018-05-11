using System;
using Isen.DotNet.Library.Models.Implementation;
using CsvHelper.Configuration;
using CsvHelper;

namespace Isen.DotNet.Library.Utilities
{
    public sealed class CommuneMap : ClassMap<commune>
{
    public CommuneMap()
    {
        Map( m => m.Id );
        Map( m => m.Name );
        Map(m => m.Latitude);
        Map(m => m.Longitude);
        
    }
}
}

