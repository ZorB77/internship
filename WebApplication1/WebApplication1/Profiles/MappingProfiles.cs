using AutoMapper;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Studio, StudioDTO>().ReverseMap();
            CreateMap<Review,ReviewDTO>().ReverseMap().ForMember(dest => dest.MovieId, opt => opt.Ignore()); 
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
