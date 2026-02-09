using MediatR;
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
    public class UpdateTypeHandler : IRequestHandler<ÚpdateTypeBattleCommand, bool>
    {
        private readonly IBattleRepository _repo;
        private readonly ILogger<UpdateTypeHandler> _logger;
        public UpdateTypeHandler(IBattleRepository repo,ILogger<UpdateTypeHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<bool> Handle(ÚpdateTypeBattleCommand request,CancellationToken token)
        {
            var battle = await _repo.GetById(request.battleid,token);
            if (battle == null)
            {
                _logger.LogError("La batalla es nula o no existe.Error");
                return false;
            }
            battle.BattleType = request.battletype;
            await _repo.UpdateType(request.battleid,request.battletype);
            _logger.LogInformation("Tipo de batalla modificada exitosamente");
            return true;
        }
    }
}
