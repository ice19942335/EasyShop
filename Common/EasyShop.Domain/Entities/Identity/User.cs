using Microsoft.AspNetCore.Identity;

namespace EasyShop.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public const string AdminUserName = "Administrator@easyshop.com";
        public const string DefaultAdminPassword = "AdminPassword";

        public const string RoleAdmin = "Administrator";
        public const string RoleUser = "User";
    }

}
