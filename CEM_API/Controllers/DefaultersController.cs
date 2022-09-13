using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CEM_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultersController : ControllerBase
    {
        public DefaultersController(DefaultersService defaultersService)
        {
            DefaultersService = defaultersService;
        }

        public DefaultersService DefaultersService { get; }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var defaulters = await DefaultersService.Get();

            return defaulters.Any() ? Ok(defaulters) : NoContent();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var defaulter = await DefaultersService.Get(id);

            return defaulter != null ? Ok(defaulter) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DefaultersDTO dTO)
        {
            var created = await DefaultersService.Create(dTO, HttpContext.User.Identity!.Name!);

            return created != null ? Created(String.Empty, created) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DefaultersDTO dTO)
        {
            var updated = await DefaultersService.Update(id, dTO, HttpContext.User.Identity!.Name!);

            return updated != null ? Ok(updated) : NotFound();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await DefaultersService.Delete(id, HttpContext.User.Identity!.Name!);

            return deleted != null ? Ok(deleted) : NotFound();
        }
    }
}
