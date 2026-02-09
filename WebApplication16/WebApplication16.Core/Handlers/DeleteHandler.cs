using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Core.Command;
using WebApplication16.Domain.Interfaces;

namespace WebApplication16.Core.Handlers
{
    public class DeleteHandler : IRequestHandler<Deletebattlecommand, bool>
    {
        private readonly IBattleRepository _repo;
        public DeleteHandler(IBattleRepository repo)
        {

            _repo = repo;
        }
        public async Task<bool> Handle(Deletebattlecommand command, CancellationToken token)
        {
            if (command is null)
            {
                return false;
            }
            var battle = await _repo.GetById(command.id);
            if (battle == null)
            {
                return false;
            }
            var delete = _repo.Delete(battle);

            return true;

        }
    }
}