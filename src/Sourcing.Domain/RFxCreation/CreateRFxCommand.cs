using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sourcing.Domain.RFxCreation
{
    class CreateRFxCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public DateTime BiddingStartDateInUtc { get; set; }
        public DateTime BiddingEndDateInUtc { get; set; }
    }

    internal class CreateRFxCommandHandler : IRequestHandler<CreateRFxCommand, Unit>
    {
        private readonly IRepository<RFx> repository;
        public CreateRFxCommandHandler(IRepository<RFx> repository) => this.repository = repository;

        public Task<Unit> Handle(CreateRFxCommand command, CancellationToken cancellationToken)
        {
            var rfx = new RFx(command.Name, command.BiddingStartDateInUtc, command.BiddingEndDateInUtc);
            this.repository.Save(rfx, 1);
            return Unit.Task;
        }
    }
}
