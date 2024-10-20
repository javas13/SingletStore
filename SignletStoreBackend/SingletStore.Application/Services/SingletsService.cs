using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SingletStore.Core.Models;
using SingletStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletStore.Application.Services
{
    public class SingletsService : ISingletsService
    {
        private readonly ISingletsRepository _singletsRepository;
        public SingletsService(ISingletsRepository singletsRepository)
        {
            _singletsRepository = singletsRepository;
        }

        public async Task<List<Singlet>> GetAllSinglets()
        {
            return await _singletsRepository.Get();
        }

        public async Task<Guid> CreateSinglet(Singlet singlet)
        {
            return await _singletsRepository.Create(singlet);
        }

        public async Task<Guid> UpdateSinglet(Guid id, string title, string description, decimal price)
        {
            return await _singletsRepository.Update(id, title, description, price);
        }

        public async Task<Guid> DeleteSinglet(Guid id)
        {
            return await _singletsRepository.Delete(id);
        }
    }
}
