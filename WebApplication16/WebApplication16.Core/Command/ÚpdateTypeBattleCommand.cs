using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication16.Core.Command
{
    public record ÚpdateTypeBattleCommand(int battleid, string battletype) : IRequest<bool>;


   }