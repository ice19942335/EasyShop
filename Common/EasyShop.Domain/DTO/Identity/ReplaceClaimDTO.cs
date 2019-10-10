using System.Security.Claims;

namespace EasyShop.Domain.DTO.Identity
{
    public class ReplaceClaimDTO : ClaimInfoDTO
    {
        public Claim OldClaim { get; set; }

        public Claim NewClaim { get; set; }
    }
}