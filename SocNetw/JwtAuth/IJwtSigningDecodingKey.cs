using Microsoft.IdentityModel.Tokens;

namespace SocNetw.JwtAuth
{
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }
}
