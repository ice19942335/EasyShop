using Microsoft.AspNetCore.Identity;

namespace EasyShop.Domain.DTO.Identity
{
    public class AddLoginDTO : UserInfoDTO
    {
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
