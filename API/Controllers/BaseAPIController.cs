
using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??=  HttpContext.RequestServices.GetService<IMediator>(); //??= or  

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if(result == null) return NotFound();
            if(result.IsSucces && result.Value != null) {
                return Ok(result.Value);
            }
            if(result.IsSucces && result.Value == null) {
                return NotFound();
            }
            return BadRequest(result.Error);
        } 
    }
}