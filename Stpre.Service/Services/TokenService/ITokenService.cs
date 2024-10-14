using Store.Data.Entities.IdentityEntities;

namespace Store.Service.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(AppUser appUser);
    }
}
