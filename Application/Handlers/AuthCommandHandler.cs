using MediatR;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Mediatr.Dtos;

namespace VaccinationCard.Api.Application.Handlers
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthNotification>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthCommandHandler(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }        

        public async Task<AuthNotification> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Credential.Equals(_configuration["LoginApi"]))
                {
                    var auth = await _authRepository.Authenticate(request.Credential);                    
                    return await Task.FromResult(auth);
                }
                throw new Exception("Invalid login. Check your credentials in appsettings or in the documentation.");
            }
            catch (Exception ex)
            {
                throw new ErrorNotification(StatusCodes.Status404NotFound, "An error occurred in the application.", ex.Message);
            }
        }
    }
}
