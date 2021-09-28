using FrontEk7.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontHubEk7.Models
{
    public class SecurityAccessModel:BaseModel<SecurityAccess>
    {
        public SecurityAccessModel()
        {
            Filtro = new SecurityAccess {  };
            Detalhe = new SecurityAccess { };

        }
    }
}
