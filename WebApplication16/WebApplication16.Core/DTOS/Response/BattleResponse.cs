using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication16.Core.DTOS.Response
{
    public class BattleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BattleType { get; set; }
        public DateTime BattleDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

    }
}
