using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API.Controllers;

public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}