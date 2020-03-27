using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sourcing.Domain.RFxCreation
{
    class RFxDetailQuery : IRequest<RFxModel>
    {
        public Guid RFxId { get; set; }
    }

    class RFxDetailQueryHandler : IRequestHandler<RFxDetailQuery, RFxModel>
    {
        public Task<RFxModel> Handle(RFxDetailQuery request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
