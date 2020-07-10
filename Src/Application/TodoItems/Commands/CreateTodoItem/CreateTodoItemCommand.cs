using Application.TodoItems.Responses;
using MediatR;

namespace Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<TodoItemResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}