using Microsoft.AspNetCore.Mvc;
using SampleCQRS.Application.CQRSInfrastructure;
using SampleCQRS.Application.Features.Products.Commands.Create;
using SampleCQRS.Application.Features.Products.Commands.Delete;
using SampleCQRS.Application.Features.Products.Commands.Update;
using SampleCQRS.Application.Features.Products.Queries.GetAllProduct;
using SampleCQRS.Application.Features.Products.Queries.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCQRS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppBus _appBus;

        public ProductController(AppBus appBus)
        {
            _appBus = appBus;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _appBus.SendQueryAsync<GetAllProductQuery, List<GetAllProductQuery>>(null);
            return Ok(productList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productList = await _appBus.SendQueryAsync<GetProductByIdQuery, GetProductByIdQuery>(new GetProductByIdQuery { Id = id });
            return Ok(productList);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand request)
        {
            await _appBus.SendCommandAsyn(request);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(UpdateProductCommand request)
        {
            _appBus.SendCommand(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand request)
        {
            await _appBus.SendCommandAsyn(request);
            return Ok();
        }
    }
}
