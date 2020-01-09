using System.Threading.Tasks;

namespace testIdentity
{
    public interface ITokenProvider
    {
        Task<TokenResponse> GetToken(TokenRequest request);
    }
}
