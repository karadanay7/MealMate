using LifeCoach.Application;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeCoach.WebApi;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ISender _mediatr;

    public OrdersController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(new OrderGetByIdQuery(id), cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(OrderAddCommand command, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(command, cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(new OrderGetAllQuery(), cancellationToken));
    }

    [AllowAnonymous]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _mediatr.Send(new OrderDeleteCommand(id), cancellationToken));
    }
}
