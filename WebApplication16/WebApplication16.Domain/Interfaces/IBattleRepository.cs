using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Domain.Entities;

namespace WebApplication16.Domain.Interfaces
{
    public interface IBattleRepository
    {
         Task<List<Battle>> GetAll(CancellationToken cancellation = default);
        Task<Battle> GetById(int id,CancellationToken cancelation = default);
        Task Update(Battle battle,CancellationToken cancelation = default);
        Task Delete(Battle battle, CancellationToken cancelation = default);
        Task Create(Battle battle, CancellationToken cancelation = default);
        Task UpdateType(int battleid, string type, CancellationToken token = default);
        Task UpdateName(int id,string name, CancellationToken token = default); 
        Task<(List<Battle> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm = null,
            bool? isActive = null

        );
    }
}
