using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Conduit.Features.Tags;

[Route("Dates")]
public class DateController(IMediator mediator) : Controller
{
[HttpGet("{dateString}")]
public Task<DateEnvelope> GetDates(string dateString, CancellationToken cancellationToken) =>
    mediator.Send(new ParseDateTimeQuery(dateString), cancellationToken);}

