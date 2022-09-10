using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.BL.Interfaces;
using DesafioLoldesign.API.Domain.Data.Repositories;
using DesafioLoldesign.API.ViewModels.Reponses;
using DesafioLoldesign.API.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLoldesign.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RatesController : ControllerBase
    {
        private readonly IRatesBL _ratesBL;

        public RatesController(IRatesBL ratesBL)
        {
            _ratesBL = ratesBL;
        }

        [HttpGet]
        public async Task<ActionResult<CommonReponse>> GetAll()
        {
            try
            {
                var rates = await _ratesBL.GetRates();
                return Ok(new CommonReponse
                {
                    Message = "Rates found",
                    Data = rates,
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
                var rates = await _ratesBL.GetRateById(id);
                if (rates is null)
                {
                    return NotFound(new CommonReponse
                    {
                        Message = "Rates not found",
                        StatusCode = 404
                    });
                }
                return Ok(new CommonReponse
                {
                    Message = "Rates found",
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
        public async Task<ActionResult<CommonReponse>> Add([FromBody] RegisterRatesRequest model)
        {
            try
            {

                if (await _ratesBL.CreateRates(model))
                {
                    return Ok(new CommonReponse
                    {
                        Message = "Rates created",
                        Data = model,
                        StatusCode = 200
                    });
                }

                return BadRequest(new CommonReponse
                {
                    Message = "Rates not added",
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
        public async Task<ActionResult<CommonReponse>> Update([FromBody] UpdateRatesRequest model)
        {
            try
            {
                if (await _ratesBL.UpdateRates(model))
                {
                    return Ok(new CommonReponse
                    {
                        Message = "Rates Updated",
                        Data = model,
                        StatusCode = 200
                    });
                }
                return BadRequest(new CommonReponse
                {
                    Message = "Rates not updated",
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

                if (await _ratesBL.DeleteRates(id))
                {
                    return Ok(new CommonReponse
                    {
                        Message = "Rates deleted",
                        StatusCode = 200
                    });
                }
                return BadRequest(new CommonReponse
                {
                    Message = "Rates not deleted",
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
}