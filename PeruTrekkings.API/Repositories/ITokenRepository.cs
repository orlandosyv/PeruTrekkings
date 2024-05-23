using Microsoft.AspNetCore.Identity;

namespace PeruTrekkings.API.Repositories
{
    public interface ITokenRepository
    {
        String CreateJwtToken(IdentityUser user, List<String> roles); 
    }
}
