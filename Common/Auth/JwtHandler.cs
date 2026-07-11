using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.Marshalling;
using System.Text;


namespace Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly JwtOptions _jwtOptions;
        private readonly SecurityKey _issuerSigningKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtHandler(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
            _issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
            _tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidIssuer = _jwtOptions.Issuer,
                IssuerSigningKey = _issuerSigningKey,
            };
        }

        public JsonWebToken create(long userId)
        {

            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var exp = DateTimeOffset.UtcNow
                .AddMinutes(_jwtOptions.ExpiryMinutes)
                .ToUnixTimeMilliseconds();

            var payload = new JwtPayload
            {
                { "sub", userId },
                { "iss", _jwtOptions.Issuer },
                { "iat", now },
                { "exp", exp },
                { "unique_code", userId }
            };
            var jwt = new JwtSecurityToken(_jwtHeader, payload);
            var tocken = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JsonWebToken
            {
                Token = tocken,
                Expires = exp
            };
        }

    }
}
