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
    public class RatesRepository : IRatesRepository
    {
        private readonly ChallengeContext _context;

        public RatesRepository(ChallengeContext context)
        {
            _context = context;
        }

        public async Task<Rates> Add(Rates obj)
        {
            await _context.AddAsync(obj);
            return obj;
        }

        public async Task<List<Rates>> GetAll()
        {
            return await _context.Rates.AsNoTracking().ToListAsync();
        }

        public async Task<Rates> GetById(Guid id)
        {
            return await _context.Rates.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var rates = await GetById(id);
            if(rates is null)
            {
                throw new Exception("Rates not Found");
            }
            _context.Rates.Remove(rates);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Rates> Update(Rates obj)
        {
           _context.Update(obj);
            return obj;
        }
    }
}