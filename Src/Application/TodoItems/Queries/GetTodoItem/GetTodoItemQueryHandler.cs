using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.TodoItems.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItemResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoItemResponse> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            TodoItem dbItem = await _context.TodoItems.FindAsync(request.Id);
            if (dbItem == null)
            {
                throw new NotFoundException($"Todo item (id: {request.Id}) does not exist.");
            }

            return _mapper.Map<TodoItemResponse>(dbItem);
        }
    }
}