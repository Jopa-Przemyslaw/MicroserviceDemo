using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PlatformService.Data;
    using PlatformService.Dtos;
    using PlatformService.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandDataClient _commandDataClient;
        private readonly IMapper _mapper;
        private readonly IPlatformRepo _repository;

        public PlatformsController(
            ICommandDataClient commandDataClient,
            IMapper mapper,
            IPlatformRepo repository)
        {
            _commandDataClient = commandDataClient;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.Write("--> Getting Platforms...");

            var platformItem = _repository.GetPlatforms();

            var platformItemMapped = _mapper.Map<IEnumerable<PlatformReadDto>>(platformItem);

            Console.WriteLine("--> Done.");
            return Ok(platformItemMapped);
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            Console.Write($"--> Getting Platform By Id of {id}...");

            var platformItem = _repository.GetPlatformById(id);
            if (platformItem != null)
            {
                var platformItemMapped = _mapper.Map<PlatformReadDto>(platformItem);
                Console.WriteLine("--> Done.");
                return Ok(platformItemMapped);
            }
            
            Console.WriteLine("--> Not Found.");
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            Console.Write("--> Creating Platform...");

            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _repository.CreatePlatform(platformModel);
            _repository.SaveChanges();
                
            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformReadDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could not send synchronously: {e.Message}");
                throw;
            }

            Console.WriteLine("--> Done.");
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}
