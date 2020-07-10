using Application.TodoItems.Responses;
using MediatR;

namespace Application.TodoItems.Queries.GetTodoItem
{
    public class GetTodoItemQuery : IRequest<TodoItemResponse>
    {
        public int Id { get; set; }
    }
}