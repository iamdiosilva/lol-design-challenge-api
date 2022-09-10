using DesafioLoldesign.API.BL.Interfaces;
using DesafioLoldesign.API.Domain.Data.Repositories;
using DesafioLoldesign.API.Domain.Entities;
using DesafioLoldesign.API.ViewModels.Reponses;
using DesafioLoldesign.API.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLoldesign.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlansController : ControllerBase
{
    private readonly IPlansBL _plansBL;

    public PlansController(IPlansBL plansBL)
    {
        _plansBL = plansBL;
    }

    [HttpGet]
    public async Task<ActionResult<CommonReponse>> GetAll()
    {
        try
        {
            var plans = await _plansBL.GetPlans();
            return Ok(new CommonReponse
            {
                Message = "Plans found",
                Data = plans,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new CommonReponse
            {
                Message = ex.Message,
                StatusCode = 400
            });
        }
    }

    [HttpGet("get-by-id/{id:Guid}")]
    public async Task<ActionResult<CommonReponse>> GetById(Guid id)
    {
        try
        {
            var plan = await _plansBL.GetPlanById(id);
            if (plan is null)
            {
                return NotFound(new CommonReponse
                {
                    Message = "Plan not found",
                    StatusCode = 404
                });
            }
            return Ok(new CommonReponse
            {
                Message = "Plans found",
                Data = plan,
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new CommonReponse
            {
                Message = ex.Message,
                StatusCode = 400
            });
        }
    }

    [HttpPost]
    public async Task<ActionResult<CommonReponse>> Add([FromBody] RegisterPlanRequest model)
    {
        try
        {

            if (await _plansBL.CreatePlan(model))
            {
                return Ok(new CommonReponse
                {
                    Message = "Plan created",
                    Data = model,
                    StatusCode = 200
                });
            }
            
            return BadRequest(new CommonReponse
            {
                Message = "Plan not added",
                StatusCode = 400
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new CommonReponse
            {
                Message = ex.Message,
                StatusCode = 400
            });
        }
    }

    [HttpPut]
    public async Task<ActionResult<CommonReponse>> Update([FromBody] UpdatePlanRequest model)
    {
        try
        {
            if (await _plansBL.UpdatePlan(model))
            {
                return Ok(new CommonReponse
                {
                    Message = "Plan Updated",
                    Data = model,
                    StatusCode = 200
                });
            }
            return BadRequest(new CommonReponse
            {
                Message = "Plan not updated",
                StatusCode = 400
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new CommonReponse
            {
                Message = ex.Message,
                StatusCode = 400
            });
        }
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<CommonReponse>> Delete(Guid id)
    {
        try
        {
            
            if (await _plansBL.DeletePlan(id))
            {
                return Ok(new CommonReponse
                {
                    Message = "Plan deleted",
                    StatusCode = 200
                });
            }
            return BadRequest(new CommonReponse
            {
                Message = "Plan not deleted",
                StatusCode = 400
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new CommonReponse
            {
                Message = ex.Message,
                StatusCode = 400
            });
        }
    }
}
