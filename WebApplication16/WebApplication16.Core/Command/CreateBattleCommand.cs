using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Core.DTOS.Response;
using WebApplication16.Domain.Entities;

namespace WebApplication16.Core.Command
{
    public record CreateBattleCommmand(Battle battle) : IRequest<BattleResponse>;
}
