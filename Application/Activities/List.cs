using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }//this query will return list of activity

        public class Handler : IRequestHandler<Query, List<Activity>>  //IRequestHandler<TRequest, TResponse>
        {
            //Dependency Injection
            private readonly  DataContext _context;
            public Handler(DataContext context){ //constructor
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync(); 
            }
        }
    }
}