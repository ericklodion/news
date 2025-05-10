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
    public class NewService : INewService
    {
        private readonly INewRepository _repository;
        public NewService(INewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<New>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<New> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(New model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(New model)
        {
            var existingModel = await _repository.GetByIdAsync(model.Id);

            existingModel.Text = model.Text;
            existingModel.UserId = model.UserId;
            existingModel.Title = model.Title;
            existingModel.NewTags = model.NewTags;

            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(New tag)
        {
            await _repository.DeleteAsync(tag);
        }
    }
}
