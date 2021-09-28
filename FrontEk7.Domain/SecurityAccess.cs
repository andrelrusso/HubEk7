using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEk7.Domain
{
    [Table("TB_SU7_API_SECURITY_ACCESS")]
    public class SecurityAccess
    {
        [Key]
        public Guid? ID { get; set; }
        public int? RaasID { get; set; }
        public string Sigla { get; set; }
        public string STSClientId { get; set; }
        public string Method { get; set; }
        public string Endpoint { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}
