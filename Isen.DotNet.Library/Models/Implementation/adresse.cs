using System;
using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class adresse : BaseModel
    {
        public string LigneDeTexte {get; set;}
        public string CodePostal {get; set;}
        public List<commune> CommuneCollection {get; set;}

        public int? CommuneId {get; set;}

        public int Code {get; set;}

        public commune Commune {get; set;}

        
        public float Latitude {get; set;}
        public float Longitude {get; set;}

        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.Ligne = LigneDeTexte;
            response.Code = CodePostal;
            response.commune = Commune?.ToDynamic();
            response.Latitude = Latitude;
            response.Longitude = Longitude;
            return response;
        }

      
        
    }
}