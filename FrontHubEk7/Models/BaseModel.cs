using FrontHubEk7.Utils;
using System.Collections.Generic;

namespace FrontHubEk7.Models
{
    public class BaseModel<T>
    {
        public IEnumerable<T> Itens { get; set; }
        public virtual T Filtro { get; set; }
        public T Detalhe { get; set; }

    }
}
