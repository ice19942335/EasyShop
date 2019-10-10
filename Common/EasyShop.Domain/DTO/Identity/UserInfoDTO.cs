using EasyShop.Domain.Entities.Identity;

namespace EasyShop.Domain.DTO.Identity
{
    public abstract class UserInfoDTO
    {
        public User User { get; set; }
    }
}
