using CEM_API.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CEM_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        public PaymentsController(PaymentsService paymentsService)
        {
            PaymentsService = paymentsService;
        }

        public PaymentsService PaymentsService { get; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var defaulters = await PaymentsService.Get();

            return defaulters.Any() ? Ok(defaulters) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var defaulter = await PaymentsService.Get(id);

            return defaulter != null ? Ok(defaulter) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaymentsDTO dTO)
        {
            var created = await PaymentsService.Create(dTO, HttpContext.User.Identity!.Name!);

            return created != null ? Created(String.Empty, created) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentsDTO dTO)
        {
            var updated = await PaymentsService.Update(id, dTO, HttpContext.User.Identity!.Name!);

            return updated != null ? Ok(updated) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await PaymentsService.Delete(id, HttpContext.User.Identity!.Name!);

            return deleted != null ? Ok(deleted) : NotFound();
        }
    }
}
