using AutoMapper;
using TaskManagement.Dtos;
using TaskManagement.Models;
using TaskManagement.ViewModels.TaskManagement;

namespace TaskManagement.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Task, TaskDto>();
            Mapper.CreateMap<TaskDto, Task>();
            Mapper.CreateMap<TaskFormViewModel, Task>();
            Mapper.CreateMap<Task, TaskFormViewModel>();
            Mapper.CreateMap<Task, Task>();

            Mapper.CreateMap<Comment, CommentDto>();
            Mapper.CreateMap<CommentDto, CommentDto>();
            Mapper.CreateMap<CommentFormViewModel, Comment>();
            Mapper.CreateMap<Comment, CommentFormViewModel>();
            Mapper.CreateMap<Comment, Comment>();

            Mapper.CreateMap<Developer, DeveloperDto>();
            Mapper.CreateMap<DeveloperDto, Developer>();
            Mapper.CreateMap<Developer, DeveloperFormViewModel>();
            Mapper.CreateMap<DeveloperFormViewModel, Developer>();
            Mapper.CreateMap<Developer, Developer>();
        }
    }
}