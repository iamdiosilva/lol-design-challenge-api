using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.ViewModels.Reponses;
using DesafioLoldesign.API.ViewModels.Requests;

namespace DesafioLoldesign.API.BL.Interfaces
{
    public interface IPlansBL
    {
        Task<List<PlanResponse>> GetPlans();
        Task<PlanResponse> GetPlanById(Guid id);
        Task<bool> CreatePlan(RegisterPlanRequest plan);
        Task<bool> UpdatePlan(UpdatePlanRequest plan);
        Task<bool> DeletePlan(Guid id);
    }
}