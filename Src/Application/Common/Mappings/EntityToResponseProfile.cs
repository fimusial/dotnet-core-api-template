using Application.TodoItems.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class EntityToResponseProfile : Profile
    {
        public EntityToResponseProfile()
        {
            CreateMap<TodoItem, TodoItemResponse>();
        }
    }
}