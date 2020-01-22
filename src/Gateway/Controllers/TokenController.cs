using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers {
    [Microsoft.AspNetCore.Mvc.Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase {
        [Microsoft.AspNetCore.Mvc.Route("authorize")]
        [HttpGet]
        public async Task<IActionResult> GenerateToken() {
            HttpClient httpClient = new HttpClient();
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest {
                Address = "http://identity-service:80/connect/token",
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });
            return Ok(tokenResponse.Json);
        }
    }
}