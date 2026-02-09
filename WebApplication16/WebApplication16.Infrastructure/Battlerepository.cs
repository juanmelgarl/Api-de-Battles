using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebApplication16.Domain.Entities;
using WebApplication16.Domain.Interfaces;
using WebApplication16.Infrastructure.Data;

namespace WebApplication16.Infrastructure
{
    public class Battlerepository : IBattleRepository
    {
        private readonly AppDbContext _dbcontext;
        public Battlerepository(AppDbContext db)
            
        {
             _dbcontext = db;
        }
        public async Task<List<Battle>> GetAll(CancellationToken cancelation = default)
        {
            return await _dbcontext.Battles
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync(cancelation);
        }
        public async Task UpdateType(int id,string name,CancellationToken token = default)
        {
            var battle = await _dbcontext.Battles.FindAsync(id);
            battle.BattleType = name;
            await _dbcontext.SaveChangesAsync(token);
        }
        public async Task UpdateName(int id,string name,CancellationToken token = default)
        {
           var battle = await _dbcontext.Battles.FindAsync( id);
            battle.Name = name;
            await _dbcontext.SaveChangesAsync();
          
           
        }
        public async Task Delete(Battle battle, CancellationToken cancelation = default)
        {
            _dbcontext.Battles.Remove(battle); await _dbcontext.SaveChangesAsync(cancelation);

        }
        public async Task Update(Battle battle, CancellationToken cancelation = default)
        {
            _dbcontext.Battles.Update(battle); 
            
            await _dbcontext.SaveChangesAsync(cancelation);

        }

        public async Task Create(Battle battle, CancellationToken cancelation = default)
        {
            _dbcontext.Battles.Add(battle);
            await _dbcontext.SaveChangesAsync(cancelation);
        }

        public async Task<(List<Battle> Items, int TotalCount)> GetPagedAsync(
             int pageNumber,
             int pageSize,
             string? searchTerm = null,
             bool? isActive = null)
        {
            var query = _dbcontext.Battles.AsNoTracking().AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(b =>
                    b.Name.Contains(searchTerm) ||
                    b.Description.Contains(searchTerm)
                );
            }

            if (isActive.HasValue)
            {
                query = query.Where(b => b.IsActive == isActive.Value);
            }

            
            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(b => b.Id)           
                .Skip((pageNumber - 1) * pageSize)         
                .Take(pageSize)                           
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<Battle?> GetById(int id, CancellationToken cancelation)
        {
            return await _dbcontext.Battles.FirstOrDefaultAsync(c => c.Id == id,cancelation);
        }
    }
}
