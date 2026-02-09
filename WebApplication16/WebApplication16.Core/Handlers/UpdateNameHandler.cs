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
    public class UpdateNameHandler : IRequestHandler<UpdateNameCommand,bool>
    {
        private readonly IBattleRepository _repo;
        public UpdateNameHandler(IBattleRepository repo)
        {
             _repo = repo;
        }
        public async Task<bool> Handle(UpdateNameCommand request,CancellationToken token)
        {
            if (request is null)
            {
                return false;
            }
            var battle = await _repo.GetById(request.id, token);
            battle.Name = request.name;
            await _repo.UpdateName(request.id,request.name);
            return true;
        }

    }
}
