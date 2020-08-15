using Microsoft.IdentityModel.Tokens;

namespace SocNetw.JwtAuth
{
    public interface IJwtSigningEncodingKey
    {
        string SigningAlgorithm { get; }
        SecurityKey GetKey();
    }
}
