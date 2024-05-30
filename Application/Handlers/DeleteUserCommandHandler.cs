using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using VaccinationCard.Api.Application.Commands;
using VaccinationCard.Api.Application.Notifications;
using VaccinationCard.Api.Contracts;
using VaccinationCard.Api.Mediatr.Dtos;
using VaccinationCard.Api.Mediatr.Models;
using VaccinationCard.Api.Middleware;
using VaccinationCard.Api.Repositories;

namespace VaccinationCard.Api.Application.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, StatusNotification>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<StatusNotification> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _userRepository.Delete(request.Id);
                return await Task.FromResult(new StatusNotification(StatusCodes.Status200OK, "User and his vaccines deleted"));
            }
            catch (Exception ex)
            {
                throw new ErrorNotification(StatusCodes.Status500InternalServerError, "Request could not be processed", ex.Message);
            }            
        }
    }
}
