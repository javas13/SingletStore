using SingletStore.Core.Models;

namespace SingletStore.Application.Services
{
    public interface ISingletsService
    {
        Task<Guid> CreateSinglet(Singlet singlet);
        Task<Guid> DeleteSinglet(Guid id);
        Task<List<Singlet>> GetAllSinglets();
        Task<Guid> UpdateSinglet(Guid id, string title, string description, decimal price);
    }
}