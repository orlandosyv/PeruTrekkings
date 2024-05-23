using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace PeruTrekkings.API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return "";
        }

        
    }
}
