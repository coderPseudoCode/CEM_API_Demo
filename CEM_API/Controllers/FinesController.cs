using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEM_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinesController : ControllerBase
    {
        public FinesController(FinesService finesService)
        {
            FinesService = finesService;
        }

        public FinesService FinesService { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var defaulters = await FinesService.Get();

            return defaulters.Any() ? Ok(defaulters) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var defaulter = await FinesService.Get(id);

            return defaulter != null ? Ok(defaulter) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FinesDTO dTO)
        {
            var created = await FinesService.Create(dTO, HttpContext.User.Identity!.Name!);

            return created != null ? Created(String.Empty, created) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FinesDTO dTO)
        {
            var updated = await FinesService.Update(id, dTO, HttpContext.User.Identity!.Name!);

            return updated != null ? Ok(updated) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await FinesService.Delete(id, HttpContext.User.Identity!.Name!);

            return deleted != null ? Ok(deleted) : NotFound();
        }
    }
}
