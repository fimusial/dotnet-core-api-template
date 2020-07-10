using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TodoItems.Commands.DeleteTodoItem
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoItem dbItem = await _context.TodoItems.FindAsync(request.Id);
            if (dbItem == null)
            {
                throw new NotFoundException($"Todo item (id: {request.Id}) does not exist.");
            }

            _context.TodoItems.Remove(dbItem);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}