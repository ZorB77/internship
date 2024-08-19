using AutoMapper;
using ETMovies.Models;
using MoviesApi.ModelsDTO;

namespace MoviesApi.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() {

            CreateMap<Movie, MovieReadDto>();
            CreateMap<MovieCUDto, Movie>();

            CreateMap<Studio, StudioReadDto>();
            CreateMap<StudioCUDto, Studio>();

            CreateMap<Review, ReviewReadDto>();
            CreateMap<ReviewCUDto, Review>();

            CreateMap<Person, PersonReadDto>();
            CreateMap<PersonCUDto, Person>();

            CreateMap<Role, RoleReadDto>();
            CreateMap<RoleCUDto, Role>();
        }
    }
}
