using Microsoft.AspNetCore.Mvc;
using SingletStore.Api.Contracts;
using SingletStore.Application.Services;
using SingletStore.Core.Models;

namespace SingletStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingletController : ControllerBase
    {
        private readonly ISingletsService _singletsService;
        public SingletController(ISingletsService singletsService)
        {
            _singletsService = singletsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SingletsResponse>>> GetSinglets()
        {
            var singlets = await _singletsService.GetAllSinglets();

            var response = singlets.Select(b => new SingletsResponse(b.Id, b.Title, b.Description, b.Price));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSinglet([FromBody] SingletsRequest request)
        {
            var (singlet, error) = Singlet.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var singletId = await _singletsService.CreateSinglet(singlet);

            return Ok(singletId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSinglet(Guid id, [FromBody] SingletsRequest request)
        {
            var singletId = await _singletsService.UpdateSinglet(id, request.Title, request.Description, request.Price);

            return Ok(singletId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSinglet(Guid id)
        {
            return Ok(await _singletsService.DeleteSinglet(id));
        }
    }
}
