using MediatR;
using Microsoft.AspNetCore.Http;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Mediatr.Dtos;
using VaccinationCard.Api.Mediatr.Models;

namespace VaccinationCard.Api.Application.Handlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserNotifications>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<UserNotifications> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.Name
            };

            try
            {
                var userAdd = await _userRepository.Add(user);
                await _mediator.Publish(new UserNotifications(request.Name));
                return await Task.FromResult(userAdd);
            }
            catch(Exception ex)
            {
                await _mediator.Publish(new UserNotifications(request.Name));
                await _mediator.Publish(new ErrorNotification
                {
                    StatusCode = StatusCodes.Status501NotImplemented.ToString(),
                    Message = "The user could not be registered",
                    Details = ex.StackTrace.ToString()
                });

                throw new ApplicationException("The user could not be registered", ex);                
            }
        }
    }
}
