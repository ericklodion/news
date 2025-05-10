using news.core.Repositories.Interfaces;
using news.core.Services.Interfaces;
using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.core.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(Tag tag)
        {
            await _repository.CreateAsync(tag);
        }

        public async Task DeleteAsync(Tag tag)
        {
            await _repository.DeleteAsync(tag);
        }

        public async Task<IEnumerable<Tag>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Tag> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Tag tag)
        {
            await _repository.UpdateAsync(tag);
        }
    }
}
