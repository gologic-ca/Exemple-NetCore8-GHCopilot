using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using static System.DateTime;

namespace Conduit.Features.Tags;

public class ParseDateTimeQuery(string dateString) : IRequest<DateEnvelope>
{
    public string DateString { get; set; } = dateString;
}

public class ParseDateTimeQueryHandler : IRequestHandler<ParseDateTimeQuery, DateEnvelope>
{
    public Task<DateEnvelope> Handle(ParseDateTimeQuery request, CancellationToken cancellationToken)
    {
        var provider = CultureInfo.InvariantCulture;

        if (DateTime.TryParse(request.DateString, provider, DateTimeStyles.None, out var result))
        {
            return Task.FromResult(new DateEnvelope { Date = result });
        }
        else
        {
            throw new ArgumentException("Invalid date format");
        }
    }
}
