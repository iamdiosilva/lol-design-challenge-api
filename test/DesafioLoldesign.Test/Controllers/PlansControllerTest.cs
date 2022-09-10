using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioLoldesign.API.BL;
using DesafioLoldesign.API.Controllers;
using DesafioLoldesign.API.Domain.Data.Repositories;
using DesafioLoldesign.API.Domain.Entities;
using DesafioLoldesign.API.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DesafioLoldesign.Test.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlansControllerTest
    {
        private readonly PlansController _controller;
        private readonly Mock<IPlansRepository> _plansRepository;
        private readonly Mock<PlansBL> _plansBL;

        public PlansControllerTest()
        {
            _plansRepository = new Mock<IPlansRepository>();
            _plansBL = new Mock<PlansBL>();
            _controller = new PlansController(_plansBL.Object);
        }

        [Fact]
        public async Task RegisterPlanShouldSuccess()
        {
            var plan = new RegisterPlanRequest()
            {
                Name = "Plano 1",
                Tax = 10,
                Time = 10
            };
            _plansRepository.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true);
            var result = await _controller.Add(plan);

            Assert.Equal(200, result.Value.StatusCode);

        }
    }
}