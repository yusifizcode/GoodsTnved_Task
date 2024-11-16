using GoodsApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodsApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoodsTnvedController(IMediator mediator) : ControllerBase
{
    [HttpGet("get-goods-tree")]
    public async Task<IActionResult> GetGoodsTree([FromQuery] string code)
    {
        if (code.Length != 10 || !long.TryParse(code, out _))
        {
            return BadRequest("Code parametri 10 rəqəmli olmalıdır.");
        }

        var result = await mediator.Send(new GetGoodsTreeQuery(code));
        return result != null ? Ok(result) : NotFound();
    }

}
