﻿using GeekShopping.API.Data.ValueObjects;
using GeekShopping.API.Model;
using GeekShopping.API.Repositories;
using GeekShopping.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Index()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> GetById(long id)
        {
            var product = await _productRepository.GetById(id);
            
            if(product.Id <= 0)
            {
                return NotFound();
            }

            return Ok(product);
            
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            await _productRepository.Create(productVO);
            return Ok(productVO);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            await _productRepository.Update(productVO);
            return Ok(productVO);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var product = await _productRepository.Delete(id);

            if (product == null) return BadRequest();

            return Ok(product);
        }
    }
}
