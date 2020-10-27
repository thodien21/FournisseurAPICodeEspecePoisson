using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIServiceProposions.Models
{
    public class CodeEspecePoisson
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("nom_commun")]
        public string Nom_Commun { get; set; }
        [JsonProperty("nom_latin")]
        public string Nom_Latin { get; set; }
        [JsonProperty("code_taxon")]
        public int Code_Taxon { get; set; }
        [JsonProperty("uri_taxon")]
        public string Uri_Taxon { get; set; }
        [JsonProperty("statut")]
        public string Statut { get; set; }
    }
}