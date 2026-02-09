using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Core.DTOS.Response;
using WebApplication16.Core.Query;
using WebApplication16.Domain.Interfaces;

namespace WebApplication16.Core.Handlers
{
    public class ObtenerporIdHandler : IRequestHandler<ObtenerPorIdQuery,BattleResponse>
    {
        private readonly IBattleRepository _repo;
        public ObtenerporIdHandler(IBattleRepository repo)
        {
             _repo = repo;
        }
        public async Task<BattleResponse> Handle(ObtenerPorIdQuery query, CancellationToken token)
        {
            var battle = await _repo.GetById(query.id, token);
            if (battle is null)
            {
                return null;
            }
            return new BattleResponse
            {
                BattleDate = battle.BattleDate,
                 BattleType = battle.BattleType, 
                  Description = battle.Description,
                   Id = battle.Id,
                    IsActive = battle.IsActive,
                     Name    = battle.Name,
            };
        }
    }
}
