using System.Collections.Generic;
using System.Security.Claims;

namespace EasyShop.Domain.DTO.Identity
{
    public abstract class ClaimInfoDTO : UserInfoDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }
}