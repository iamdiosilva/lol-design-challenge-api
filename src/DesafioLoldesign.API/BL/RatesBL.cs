using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.BL.Interfaces;
using DesafioLoldesign.API.Domain.Data.Repositories;
using DesafioLoldesign.API.Domain.Entities;
using DesafioLoldesign.API.ViewModels.Reponses;
using DesafioLoldesign.API.ViewModels.Requests;

namespace DesafioLoldesign.API.BL
{
    public class RatesBL : IRatesBL
    {
        private readonly IRatesRepository _ratesRepository;

        public RatesBL(IRatesRepository ratesRepository)
        {
            _ratesRepository = ratesRepository;
        }

        public async Task<bool> CreateRates(RegisterRatesRequest rates)
        {
            var ratesEntity = new Rates(rates.DddOrigin, rates.DddDestiny, rates.PricePerMinute);
            await _ratesRepository.Add(ratesEntity);
            return await _ratesRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteRates(Guid id)
        {
            await _ratesRepository.Remove(id);
            return await _ratesRepository.SaveChangesAsync();
        }

        public async Task<RatesResponse> GetRateById(Guid id)
        {
            var rates = await _ratesRepository.GetById(id);
            return new RatesResponse
            {
                Id = rates.Id,
                DddOrigin = rates.DddOrigin,
                DddDestiny = rates.DddDestiny,
                PricePerMinute = rates.PricePerMinute
            };
        }

        public async Task<List<RatesResponse>> GetRates()
        {
            var rates = await _ratesRepository.GetAll();
            return rates.Select(x => new RatesResponse
            {
                Id = x.Id,
                DddOrigin = x.DddOrigin,
                DddDestiny = x.DddDestiny,
                PricePerMinute = x.PricePerMinute
            }).ToList();
            
        }

        public async Task<bool> UpdateRates(UpdateRatesRequest rates)
        {
            var ratesEntity = await _ratesRepository.GetById(rates.Id);
            ratesEntity.UpdateDddOrigin(rates.DddOrigin);
            ratesEntity.UpdateDddDestiny(rates.DddDestiny);
            ratesEntity.UpdatePricePerMinute(rates.PricePerMinute);
            await _ratesRepository.Update(ratesEntity);
            return await _ratesRepository.SaveChangesAsync();
        }
    }
}