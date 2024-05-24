using Microsoft.AspNetCore.Identity;

namespace PeruTrekkings.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<String> roles); 
    }
}
