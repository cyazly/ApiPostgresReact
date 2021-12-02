using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiPostgresReact.Dtos;
using ApiPostgresReact.Models;
using ApiPostgresReact.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPostgresReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.Get(id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetAll();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CreatedDate = DateTime.Now
            };

             await _productRepository.Add(product);
             return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto productDto)
        {
            var product = new Product()
            {
                Id = id,
                Name = productDto.Name,
                Price = productDto.Price,
                CreatedDate = DateTime.Now
            };

            await _productRepository.Update(product);
            return Ok();
        }
    }
}