
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Business.Utilities
{
    public class ValidationToken
    {
        public IConfiguration Configuration { get; }
        private static TokenOptions _tokenOptions;
        public ValidationToken(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public static int ValidateToken(string token)
        {
            int userId = 0;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenOptions.SecurityKey);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var userIdClaim = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "userId");
                    if (userIdClaim != null && int.TryParse(userIdClaim.Value, out userId))
                    {
                        return userId;
                    }
                }
            }
            catch
            {
                // Token doğrulama başarısız olursa veya kullanıcı kimliği alınamazsa hata oluşur
            }

            return 0; // Hata durumunda, varsayılan olarak 0 değeri döndürüyoruz. İstediğiniz hata durumuna göre farklı bir değer döndürebilirsiniz.
        }
    }
}
