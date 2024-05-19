using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.DTOs.Requests;
using WebApi.Validators;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController: ControllerBase
    {
        IExampleService _exampleService;
        ILogger<ExampleController> _logger;
        ExampleEntityDtoValidator _validator;

        public ExampleController(IExampleService exampleService, ILogger<ExampleController> logger,ExampleEntityDtoValidator validator) {
            _exampleService = exampleService;
            _logger = logger;

            _validator = validator;
        }



        /// <summary>
        /// Retrieves a list of exampleEntities.
        /// </summary>
        /// <returns>The list of exampleEntities.</returns>
        /// 
        [HttpGet]
        [ProducesResponseType(typeof(ExampleEntity[]), 200)]
        public async Task<ExampleEntity[]> GetAsync()
        {

            _logger.LogInformation("Fetching all ExampleEntities");
            return await _exampleService.GetAllExampleEntitiesAsync();   
        }

        /// <summary>
        /// Create new exampleEntity
        /// </summary>
        /// <returns>The created exampleEntity.</returns>
        /// 
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PostAsync(ExampleRequestDto createExampleEntityDto)
        {
            var validationResult = _validator.Check(createExampleEntityDto);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _logger.LogError("{@errors}", errorMessages);
                return BadRequest(new { errors = errorMessages });
            }
            await _exampleService.CreateExampleEntityAsync(createExampleEntityDto.FirstName , createExampleEntityDto.LastName);
            return Ok();
        }

    }
}
