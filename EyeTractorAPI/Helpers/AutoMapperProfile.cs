using AutoMapper;
using EyeTractorAPI.Models;

namespace EyeTractorAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterModel, Users>();
            CreateMap<AuthenticateModel, Users>();
            CreateMap<CreateMessageModel, Messages>();
        }
    }
}
