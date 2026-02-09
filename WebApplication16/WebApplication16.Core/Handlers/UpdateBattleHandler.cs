using MediatR;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Core.Command;
using WebApplication16.Domain.Interfaces;

namespace WebApplication16.Core.Handlers
{
    public class UpdateBattleHandler : IRequestHandler<UpdateBattleCommand,bool>
    {
        private readonly IBattleRepository _repo;
        public UpdateBattleHandler(IBattleRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(UpdateBattleCommand command,CancellationToken c)
        {
            var battle = await _repo.GetById(command.battle.Id,c);
            if (battle is null)
            {
                return false;
            }
            battle.BattleDate = command.battle.BattleDate;
            battle.Description = command.battle.Description;
            battle.Name = command.battle.Name;
            battle.BattleType = command.battle.BattleType;
            battle.IsActive = command.battle.IsActive;
            await _repo.Update(battle);
           
            return true;
          
                }
    }
}
