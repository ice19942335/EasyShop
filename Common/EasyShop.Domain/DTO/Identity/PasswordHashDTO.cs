namespace EasyShop.Domain.DTO.Identity
{
    public class PasswordHashDTO : UserInfoDTO
    {
        public string Hash { get; set; }
    }
}