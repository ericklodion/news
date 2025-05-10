using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using news.core.Services;
using news.core.Services.Interfaces;
using news.domain.Entities;

namespace news.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewService _service;
        public NewsController(ILogger<NewsController> logger, INewService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _service.GetAsync();
            return View(news);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var _new = await _service.GetByIdAsync(id);
            if (_new == null) return NotFound();

            return View(_new);
        }

        [HttpPost]
        public async Task<IActionResult> Create(New model, List<int> SelectedTags)
        {
            //A ideia aqui seria pegar do usuário logado porém
            //como não temos autenticação eu fixei o id 1 que é
            //criado automaticamente quando roda o projeto a primeira vez.
            model.UserId = 1;

            model.NewTags = SelectedTags.Select(tagId => new NewTag
            {
                TagId = tagId,
                NewId = model.Id
            }).ToList();

            await _service.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(New model, List<int> SelectedTags)
        {
            model.NewTags = SelectedTags.Select(tagId => new NewTag
            {
                TagId = tagId,
                NewId = model.Id
            }).ToList();

            await _service.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tag = await _service.GetByIdAsync(id);
            if (tag == null) return NotFound();

            await _service.DeleteAsync(tag);
            return RedirectToAction(nameof(Index));
        }

    }
}
