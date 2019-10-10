using System;

namespace EasyShop.Domain.DTO.Identity
{
    public class SetLockoutDTO : UserInfoDTO
    {
        public DateTimeOffset? LockoutStart { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}