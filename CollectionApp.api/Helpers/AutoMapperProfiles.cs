using System.Linq;
using AutoMapper;
using CollectionApp.api.Dtos;
using CollectionApp.api.Models;

namespace CollectionApp.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // User
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<User, UserForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<UserPhoto, PhotoForDetailDto>();

            // Collection Gundam
            CreateMap<CollectionGundam, CollectionGundamForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<CollectionGundam, CollectionGundamForDetailDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url));
            CreateMap<CollectionGundamPhoto, PhotoForDetailDto>();

            CreateMap<UserForUpdateDto, User>();

            CreateMap<PhotoForCreationDto, UserPhoto>();

            CreateMap<Photo, PhotoForReturnDto>();

            CreateMap<MessageForCreationDto, Message>().ReverseMap();

            CreateMap<Message, MessageToReturnDto>().ForMember(m => m.SenderPhotoUrl,
                    opt => opt.MapFrom(u =>
                        u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(m => m.RecipientPhotoUrl,
                    opt => opt.MapFrom(u =>
                        u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url));
        }
    }
}