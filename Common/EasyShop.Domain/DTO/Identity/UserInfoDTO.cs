using EasyShop.Domain.Entities.Identity;

namespace EasyShop.Domain.DTO.Identity
{
    public abstract class UserInfoDTO
    {
        public ApplicationUser User { get; set; }
    }
}
