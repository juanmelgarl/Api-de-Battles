using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication16.Domain.Entities
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BattleType { get; set; }
         public DateTime BattleDate { get; set; } = DateTime.Now;
           public bool IsActive { get; set; }
       private Battle() { }

        public static Battle battlecreatenew(string name,string description,string battleType,DateTime date,bool isactive)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name error");
            return new Battle
            {
                Name = name,
                Description = description,
                BattleType
                 = battleType,
                BattleDate = date,
                IsActive = isactive
            };
        }
         
    }
}
