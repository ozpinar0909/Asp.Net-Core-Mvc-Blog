using AutoMapper;
using Blog.Entity.DTOs;
using Blog.Entity.Entities;

namespace Blog.Service.AutoMapper
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto, Article>().ReverseMap();
        }
    }
}
