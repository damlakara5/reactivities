

using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseAPIController
    {
    /*     private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        } */
        [HttpGet] //api/activities
        public async Task<IActionResult>  GetActivities(CancellationToken ct) { //this  return type of action result, List<Activity> list of activity go back inside response body
            return HandleResult( await Mediator.Send(new List.Query(), ct));
        } 

        [HttpGet("{id}")]  //api/activities/:id  function parameter name needs to match the from url  
        public async Task<IActionResult> GetActivity(Guid id) {
            var result = await Mediator.Send(new Details.Query{Id = id});
            return HandleResult(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)    
        {
             return HandleResult(await Mediator.Send(new Create.Command {Activity = activity}));
        }  

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            
            return HandleResult(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            
            return HandleResult(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}