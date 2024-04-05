

using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseAPIController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>>  GetActivities() { //this  return type of action result, List<Activity> list of activity go back inside response body
            return await _context.Activities.ToListAsync();
        } 

        [HttpGet("{id}")]  //api/activities/:id  function parameter name needs to match the from url  
        public async Task<ActionResult<Activity>>  GetACtivity(Guid id) {
            return await _context.Activities.FindAsync(id);
        }
    }
}