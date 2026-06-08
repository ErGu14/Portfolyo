using AutoMapper;
using Entity;
using Entity.DTOs;

namespace Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            
            CreateMap<Project, ProjectListDto>().ReverseMap();
            CreateMap<Project, ProjectCreateDto>().ReverseMap();
            CreateMap<Project, ProjectUpdateDto>().ReverseMap();

            CreateMap<Certificate, CertificateListDto>().ReverseMap();
            CreateMap<Certificate, CertificateCreateDto>().ReverseMap();
            CreateMap<Certificate, CertificateUpdateDto>().ReverseMap();

            CreateMap<Message, MessageListDto>().ReverseMap();
            CreateMap<Message, MessageCreateDto>().ReverseMap();

            CreateMap<SiteSettings, SiteSettingsDto>().ReverseMap();
            CreateMap<SiteSettings, SiteSettingsUpdateDto>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaListDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaCreateDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();
        }
    }
}
