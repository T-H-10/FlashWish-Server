using AutoMapper;
using FlashWish.API.PostModels;
using FlashWish.Core.DTOs;

namespace FlashWish.API
{
    public class MappingPostProfile:Profile
    {
        public MappingPostProfile()
        {
            CreateMap<UserPostModel, UserDTO>();
            CreateMap<TemplatePostModel, TemplateDTO>();
            CreateMap<GreetingCardPostModel, GreetingCardDTOs>();
            CreateMap<GreetingMessagePostModel, GreetingMessageDTOs>();
            CreateMap<CategoryPostModel, CategoryDTOs>();
        }
    }
}
