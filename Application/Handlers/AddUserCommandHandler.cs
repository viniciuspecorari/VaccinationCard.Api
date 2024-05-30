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
                await _mediator.Publish(new UserNotifications(userAdd.Id, request.Name));
                return await Task.FromResult(userAdd);
            }
            catch(Exception ex)
            {                
                throw new ErrorNotification(StatusCodes.Status500InternalServerError, "The user could not be registered", ex.Message);                
            }

        }
    }
}
