using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.Data.Context;
using DesafioLoldesign.API.Domain.Data.Repositories;
using DesafioLoldesign.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioLoldesign.API.Data.Repositories
{
    public class PlansRepository : IPlansRepository
    {
        private readonly ChallengeContext _context;

        public PlansRepository(ChallengeContext context)
        {
            _context = context;
        }

        public async Task<Plans> Add(Plans obj)
        {
            await _context.AddAsync(obj);
            return obj;
        }

        public async Task<List<Plans>> GetAll()
        {
            return await _context.Plans.AsNoTracking().ToListAsync();
        }

        public async Task<Plans> GetById(Guid id)
        {
            return await _context.Plans.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var plan = await GetById(id);
            if(plan is null)
            {
                throw new Exception("Plan not Found");
            }
            _context.Plans.Remove(plan);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Plans> Update(Plans obj)
        {
            
            _context.Update(obj);
            return obj;
        }
    }
}