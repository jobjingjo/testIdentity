using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace testIdentity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController
    {
        private readonly ITokenProvider _tokenProvider;

        public TokenController(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        [HttpPost]
        public async Task<ActionResult<TokenResponse>> Post([FromForm] TokenRequest request)
        {
            var response = await _tokenProvider.GetToken(request);

            if (!string.IsNullOrEmpty(response.Error))
            {
                return new BadRequestObjectResult(response);
            }

            return response;
        }
    }
}
