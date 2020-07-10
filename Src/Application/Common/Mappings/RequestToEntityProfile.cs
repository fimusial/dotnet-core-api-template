using Application.TodoItems.Commands.CreateTodoItem;
using Application.TodoItems.Commands.UpdateTodoItem;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class RequestToEntityProfile : Profile
    {
        public RequestToEntityProfile()
        {
            CreateMap<CreateTodoItemCommand, TodoItem>();
            CreateMap<UpdateTodoItemCommand, TodoItem>()
                .ForMember(item => item.Id, options => options.Ignore());
        }
    }
}