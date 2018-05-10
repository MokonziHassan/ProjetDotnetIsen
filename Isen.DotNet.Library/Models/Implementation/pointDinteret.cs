using System;
using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;

namespace Isen.DotNet.Library.Models.Implementation
{
    public class pointDinteret : BaseModel
    {
        
        public categorie Categorie {get; set;}
        public int? CategorieId {get; set;}
        public adresse Adresse {get; set;}
        public int? AdresseId {get; set;}
        public string Descriptif {get; set;}

        public override dynamic ToDynamic()
        {
            var response = base.ToDynamic();
            response.cat = Categorie?.ToDynamic();
            response.Adresse = Adresse?.ToDynamic();
            response.Descriptif = Descriptif;
            return response;
        } 
    }
}