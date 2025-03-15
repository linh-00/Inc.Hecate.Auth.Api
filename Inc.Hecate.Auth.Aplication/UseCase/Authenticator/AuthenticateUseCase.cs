using AutoMapper;
using Inc.Hecate.Auth.Aplication.DTO.Reponse;
using Inc.Hecate.Auth.Aplication.DTO.Request;
using Inc.Hecate.Auth.Aplication.Interface;
using Inc.Hecate.Auth.Aplication.Interface.Services;
using Inc.Hecate.Auth.Domain.Interface;
using Inc.Hecate.Auth.Shared.Constants;
using Inc.Hecate.Auth.Shared.Exceptions.Exceptions;
using Inc.Hecate.Auth.Shared.Models;
using Inc.Hecate.Auth.Shared.Utils;
using Inc.Hecate.Auth.Shared.Utils.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inc.Hecate.Auth.Aplication.UseCase.Authenticator
{
    public class AuthenticateUseCase : IAuthenticateUseCase
    {
        public readonly IMapper _MApper;
        public readonly IUserRepository _UserRepository;
        public readonly IAuthTokenService _AuthTokenService;
        public readonly ILogger<AuthenticateUseCase> _Logger;
        public readonly IEncryptor _Encryptor;
        public AuthenticateUseCase(IMapper mapper, IUserRepository userRepository, IAuthTokenService authTokenService, ILogger<AuthenticateUseCase> logger, IEncryptor encryptor)
        {
            _MApper = mapper;
            _UserRepository = userRepository;
            _AuthTokenService = authTokenService;
            _Logger = logger;
            _Encryptor = encryptor;
        }

        public async Task<UseCaseResponse<BearerToken>> Execute(LoginRequest request)
        {
            var result = new UseCaseResponse<BearerToken>();

            try
            {

                var passEncrypt = _Encryptor.Encrypt(request.Password);

                _Logger.LogInformation($"Buscando Usuario e senha");
                var usuario = _UserRepository.GetUserByEmailAndPassword(request.Email, passEncrypt);

                _Logger.LogInformation($"Criando token");
                var tokenResponse = await _AuthTokenService.BuildToken(usuario);

                return result.SetSuccess(tokenResponse);

            }
            catch (AuthorizationException ex)
            {
                _Logger.LogError(ex.Message);
                return result.SetNotAuthorized(ex.Errors.First());
            }

            catch (RepositoryException ex)
            {
                _Logger.LogError(ex.Message);
                return result.SetNotFound(new ErrorMessage(ErrorCodes.NotFoundError, ex.Message));
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex.Message);
                return result.SetInternalServerError(ex.Message);
            }
        }
    }
}
