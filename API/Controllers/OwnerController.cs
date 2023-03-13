using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                //var owners = _repository.Owner.GetAllOwners();
                var owners = await _repository.Owner.GetAllOwnersAsync();
                _logger.LogInfo($"Returned all owners from database.");

                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllowners Action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById(Guid id)
        {
            try
            {
                //var owner = _repository.Owner.GetOwnerById(id);
                var owner = await _repository.Owner.GetOwnerByIdAsync(id);

                if (owner is null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
