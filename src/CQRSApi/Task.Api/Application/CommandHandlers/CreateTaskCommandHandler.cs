namespace Task.Api.Application.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Model;

    /// <summary>CreateTask Command Handler</summary>
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        /// <summary>Handles the specified request.</summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
