using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using SQLitePCL;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest //doesn't return anything so there is no return type and this is the fundemantal return type between command and query
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context){
                _context = context;

            }

            public async Task Handle(Command request,CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);  //here it adds the new activity to the context in the MEMORY

                await _context.SaveChangesAsync();

               
            }

        }
    }
}