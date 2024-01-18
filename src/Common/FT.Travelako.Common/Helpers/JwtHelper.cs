using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT.Travelako.Common.Helpers
{
    public static class JwtHelper
    {
        public static string GetClaimValue(string accessToken, string key)
        {
            if (!string.IsNullOrWhiteSpace(accessToken) && !string.IsNullOrWhiteSpace(key))
            {
                var jwt = new JwtSecurityToken(accessToken);
                if (jwt is not null)
                {
                    return jwt.Claims.FirstOrDefault(c => c.Type == key)?.Value ?? string.Empty;
                }
            }

            return string.Empty;
        }
    }
}
