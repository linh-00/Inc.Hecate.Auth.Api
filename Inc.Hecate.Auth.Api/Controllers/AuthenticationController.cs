using Inc.Hecate.Auth.Api.Interfaces;
using Inc.Hecate.Auth.Aplication.DTO.Reponse;
using Inc.Hecate.Auth.Aplication.DTO.Request;
using Inc.Hecate.Auth.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Inc.Hecate.Auth.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[Controller]")]
    public class AuthenticationController
    {
        public readonly IAuthenticateUseCase _AuthenticateUseCase;
        public readonly IActionResultConverter _IActionConverter;

        public AuthenticationController(IAuthenticateUseCase authenticateUseCase, IActionResultConverter actionConverter)
        {
            _AuthenticateUseCase = authenticateUseCase;
            _IActionConverter = actionConverter;
        }

        [ProducesResponseType(typeof(BearerToken), StatusCodes.Status200OK)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _AuthenticateUseCase.Execute(request);
            return _IActionConverter.Convert(response);
        }
    }
}
