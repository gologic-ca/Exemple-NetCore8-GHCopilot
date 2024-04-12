using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Conduit.Features.Tags;

// A query handler that take two integer as input and return a list of primes number between the two integers

public class PrimerNumbersQuery(int start, int end) : IRequest<PrimerNumbersEnvelope>
{
    public int Start { get; set; } = start;
    public int End { get; set; } = end;
}

public class PrimerNumbersEnvelope
{
    public List<int>? PrimerNumbers { get; set; }
}

public class PrimerNumbersQueryHandler : IRequestHandler<PrimerNumbersQuery, PrimerNumbersEnvelope>
{
    public Task<PrimerNumbersEnvelope> Handle(PrimerNumbersQuery request, CancellationToken cancellationToken)
    {
        var result = new List<int>();
        for (var i = request.Start; i <= request.End; i++)
        {
            if (IsPrime(i))
            {
                result.Add(i);
            }
        }

        return Task.FromResult(new PrimerNumbersEnvelope { PrimerNumbers = result });
    }

    private static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (var i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
