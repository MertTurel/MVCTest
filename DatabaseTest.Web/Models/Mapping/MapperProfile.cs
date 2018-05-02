using AutoMapper;
using DatabaseTest.Web.Models.Domain;
using DatabaseTest.Web.Models.ViewModels;

namespace DatabaseTest.Web.Models.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, Post>()
                .ForMember(p => p.CreatedAt, opt => opt.Ignore())
                .ForMember(p => p.LastModifiedAt, opt => opt.Ignore())
                .ForMember(p => p.IsDeleted, opt => opt.Ignore());
            
            CreateMap<Comment, CommentViewModel>();
            CreateMap<CommentViewModel, Comment>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}