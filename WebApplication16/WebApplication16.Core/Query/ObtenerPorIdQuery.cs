using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Core.DTOS.Response;

namespace WebApplication16.Core.Query
{
    public record ObtenerPorIdQuery(int id) : IRequest<BattleResponse>;
    
}
