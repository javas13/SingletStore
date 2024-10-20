using SingletStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletStore.DataAccess.Repositories
{
    public interface ISingletsRepository
    {
        Task<Guid> Create(Singlet singlet);
        Task<Guid> Delete(Guid id);
        Task<List<Singlet>> Get();
        Task<Guid> Update(Guid id, string title, string description, decimal price);
    }
}
