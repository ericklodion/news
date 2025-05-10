using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using news.core.Services.Interfaces;
using news.domain.Entities;

namespace news.Controllers
{
    public class TagsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITagService _service;

        public TagsController(ILogger<HomeController> logger, ITagService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _service.GetAsync();
            return View(tags);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(long id)
        {
            var tag = await _service.GetByIdAsync(id);
            if (tag == null) return NotFound();

            return View(tag);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var tag = await _service.GetByIdAsync(id);
            if (tag == null) return NotFound();

            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tag tag)
        {
            await _service.CreateAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, Tag tag)
        {
            if (id != tag.Id) return BadRequest();

            await _service.UpdateAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tag = await _service.GetByIdAsync(id);
            if (tag == null) return NotFound();

            await _service.DeleteAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAsync());
        }

    }
}
