using Entity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace PortfolioBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteSettingsController : ControllerBase
    {
        private readonly ISiteSettingsService _siteSettingsService;

        public SiteSettingsController(ISiteSettingsService siteSettingsService)
        {
            _siteSettingsService = siteSettingsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _siteSettingsService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _siteSettingsService.GetByIdAsync(id);
            if (value == null) return NotFound();
            return Ok(value);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromForm] SiteSettingsUpdateDto dto)
        {
            var result = await _siteSettingsService.AddAsync(dto);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromForm] SiteSettingsUpdateDto dto)
        {
            var result = await _siteSettingsService.UpdateAsync(dto);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _siteSettingsService.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
