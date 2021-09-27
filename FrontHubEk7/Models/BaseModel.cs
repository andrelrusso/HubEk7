using FrontHubEk7.Utils;

namespace FrontHubEk7.Models
{
    public class BaseModel<T>
    {
        public PagedList<T> Itens { get; set; }
        public virtual T Filtro { get; set; }
        public T Detalhe { get; set; }

    }
}
