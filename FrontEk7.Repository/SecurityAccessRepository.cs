using FrontEk7.Domain;
using FrontEk7.Domain.Interfaces;

namespace FrontEk7.Repository
{
    public class SecurityAccessRepository : BaseRepository<SecurityAccess>, ISecurityAccessRepository
    {
        public SecurityAccessRepository(EFContexto context) : base(context)
        {
        }
    }
}
