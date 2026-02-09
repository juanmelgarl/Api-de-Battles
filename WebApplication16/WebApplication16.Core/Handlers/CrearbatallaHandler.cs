using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Core.Command;
using WebApplication16.Core.DTOS.Response;
using WebApplication16.Domain.Entities;
using WebApplication16.Domain.Interfaces;

namespace WebApplication16.Core.Handlers
{
    public class CrearbatallaHandler : IRequestHandler<CreateBattleCommmand,BattleResponse>
    {
        private readonly IBattleRepository _repo;
        public CrearbatallaHandler(IBattleRepository repo)
        {
            _repo = repo;
        }
        public async Task<BattleResponse> Handle(CreateBattleCommmand request,CancellationToken c)
        {
            if (request is null)
            {
                return null;
            }
            await _repo.Create(request.battle);
            return new BattleResponse
            {
                BattleDate = request.battle.BattleDate,
                BattleType = request.battle.BattleType,
                Description = request.battle.Description,
                Id = request.battle.Id,
                IsActive = request.battle.IsActive,
                Name = request.battle.Name,
            };
        }
    }
}
