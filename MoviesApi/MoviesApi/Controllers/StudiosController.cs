using AutoMapper;
using ETMovies.Models;
using ETMovies.Service;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.ModelsDTO;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudiosController : Controller
    {
        private StudioService service;
        private ILogger<StudiosController> logger;
        private IMapper mapper;
        public StudiosController(StudioService studioService, ILogger<StudiosController> logger, IMapper mapper)
        {
            service = studioService;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StudioReadDto> GetStudios(int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetStudios WAS CALLED");
            logger.LogInformation(" ------ ");
            var studios = service.GetStudios();
            if(studios == null)
            {
                logger.LogInformation("No studios found");
                return null;
            }
            var studiosDto = mapper.Map<List<StudioReadDto>>(studios);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Returning studios");
            logger.LogInformation(" ------ ");
            return studiosDto.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        }

        [HttpGet("{id}")]
        public StudioReadDto GetStudio(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetStudio{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            var studio = service.GetStudio(id);
            if (studio == null)
            {
                logger.LogInformation("No studio found");
                return null;
            }
            var studioDto = mapper.Map<StudioReadDto>(studio);
            logger.LogInformation(" ------ ");
            logger.LogInformation($"Returning studio -> {studio.Title}");
            logger.LogInformation(" ------ ");
            return studioDto;

        }

        [HttpPost]
        public void Post(string title, int year, string location)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Post WAS CALLED");
            logger.LogInformation(" ------ ");
            var studioDto = new StudioCUDto(title, year, location);
            var studio = mapper.Map<Studio>(studioDto);
            service.AddStudio(studio);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Studio added succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpPut]
        public void Put(int id, string title, int year, string location)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Put WAS CALLED");
            logger.LogInformation(" ------ ");
            service.UpdateStudio(id, title, year, location);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Studio updated succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("Delete{id} WAS CALLED");
            logger.LogInformation(" ------ ");
            service.DeleteStudio(id);
            logger.LogInformation(" ------ ");
            logger.LogInformation("Studio deleted succesfully");
            logger.LogInformation(" ------ ");
        }

        [HttpGet]
        public List<string> GetStudiosWithTheirMovies(int page = 1, int pageSize = 10)
        {
            logger.LogInformation(" ------ ");
            logger.LogInformation("GetStudiosWithTheirMovies WAS CALLED");
            logger.LogInformation(" ------ ");
            var studios = service.GetStudiosWithMovies();
            return studios.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
