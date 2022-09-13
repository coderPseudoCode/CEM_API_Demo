using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEM_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OffensesController : ControllerBase
    {
        public OffensesController(OffensesService offensesService)
        {
            OffensesService = offensesService;
        }

        public OffensesService OffensesService { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var defaulters = await OffensesService.Get();

            return defaulters.Any() ? Ok(defaulters) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var defaulter = await OffensesService.Get(id);

            return defaulter != null ? Ok(defaulter) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OffensesDTO dTO)
        {
            var created = await OffensesService.Create(dTO, HttpContext.User.Identity!.Name!);

            return created != null ? Created(String.Empty, created) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OffensesDTO dTO)
        {
            var updated = await OffensesService.Update(id, dTO, HttpContext.User.Identity!.Name!);

            return updated != null ? Ok(updated) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await OffensesService.Delete(id, HttpContext.User.Identity!.Name!);

            return deleted != null ? Ok(deleted) : NotFound();
        }
    }
}
