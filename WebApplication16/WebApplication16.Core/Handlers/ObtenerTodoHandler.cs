using MediatR;
using Microsoft.Extensions.Logging;
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
    public class ObtenerTodoHandler : IRequestHandler<ObtenerTodoQuery,List<BattleResponse>>

    {
        private readonly IBattleRepository _repo;
        private readonly ILogger<ObtenerTodoHandler> _logger;
        public ObtenerTodoHandler(IBattleRepository repo, ILogger<ObtenerTodoHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public async Task<List<BattleResponse>> Handle(ObtenerTodoQuery query,CancellationToken token)
        {
            var battle = await _repo.GetAll(token);
            return battle.Select(c => new BattleResponse
            {
                BattleDate = c.BattleDate,
                BattleType = c.BattleType,
                Description = c.Description,
                Id = c.Id,
                IsActive = c.IsActive,
                Name = c.Name,
            }).ToList();
        }
    }
}
