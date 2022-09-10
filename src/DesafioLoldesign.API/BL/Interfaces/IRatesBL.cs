using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.ViewModels.Reponses;
using DesafioLoldesign.API.ViewModels.Requests;

namespace DesafioLoldesign.API.BL.Interfaces
{
    public interface IRatesBL
    {
        Task<List<RatesResponse>> GetRates();
        Task<RatesResponse> GetRateById(Guid id);
        Task<bool> CreateRates(RegisterRatesRequest rates);
        Task<bool> UpdateRates(UpdateRatesRequest rates);
        Task<bool> DeleteRates(Guid id);
    }
}