using System;

namespace FrontHubEk7.Models
{
    public class SecurityAccess
    {
        public Guid Id { get; set; }
        public int RaasId { get; set; }
        public string Sigla { get; set; }
        public string ClientId { get; set; }
        public string Method { get; set; }
        public string EndPoint { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
