using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//configuration appsettings.jsondan okuyor
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//app settingsteki tokenoptions adlı kısmı get et,
                                                                                         //ve tokenoptions adlı classa göre maple-ata
                                                                                         //Microsoft.Extensions.Configuration.Binder(.net 5 te get hatasından dolayı yükelemk geeklis   )


        }
        public AccessToken CreateToken(Account account, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, account, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Account account,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(account, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Account account, List<OperationClaim> operationClaims)//system.securtiy.claims ile çöz
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(account.AccountId.ToString());//core extensins ile coz
            claims.AddEmail(account.Email);
            claims.AddName($"{account.Name}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }

    }
}
