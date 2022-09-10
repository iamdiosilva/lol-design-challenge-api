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
    public class PlansBL : IPlansBL
    {
        private readonly IPlansRepository _plansRepository;

        public PlansBL(IPlansRepository plansRepository)
        {
            _plansRepository = plansRepository;
        }

        public async Task<List<PlanResponse>> GetPlans()
        {   
            var plans = await _plansRepository.GetAll();
            return plans.Select(x => new PlanResponse
            {
                Id = x.Id,
                Name = x.Name,
                Tax = x.Tax,
                Time = x.Time,
            }).ToList();
        }

        public async Task<PlanResponse> GetPlanById(Guid id)
        {
            var plan = await _plansRepository.GetById(id);
            return new PlanResponse
            {
                Id = plan.Id,
                Name = plan.Name,
                Tax = plan.Tax,
                Time = plan.Time,
            };
        }

        public async Task<bool> CreatePlan(RegisterPlanRequest plan)
        {
            var planEntity = new Plans(plan.Name, plan.Tax, plan.Time);
            await _plansRepository.Add(planEntity);
            return await _plansRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdatePlan(UpdatePlanRequest plan)
        {
            var planEntity = await _plansRepository.GetById(plan.Id);
            planEntity.UpdateName(plan.Name);
            planEntity.UpdateTax(plan.Tax);
            planEntity.UpdateTime(plan.Time);
            await _plansRepository.Update(planEntity);
            return await _plansRepository.SaveChangesAsync();
        }

        public async Task<bool> DeletePlan(Guid id)
        {
            await _plansRepository.Remove(id);
            return await _plansRepository.SaveChangesAsync();
        }
    }
}