using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;

namespace Presentation
{
    // Api Controller
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        // endpoint : Public non-static method


        // sort : nameasc [default]
        // sort : namedesc
        // sort : priceDesc
        // sort : priceAsc
        [HttpGet] // GET: /api/Products
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductSpecificationsParamters specParams)
        {
            var result = await serviceManager.ProductService.GetAllProductsAsync(specParams);
            if (result is null) return BadRequest(); // 400
            return Ok(result); // 200
        }

        [HttpGet("{id}")] // GET: /api/Products/12
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await serviceManager.ProductService.GetProductByIdAsync(id);
            if (result is null) return NotFound(); // 404
            return Ok(result);
        }

        // TODO : Get All Brands
        [HttpGet("brands")]// GET: /api/Products/brands
        public async Task<IActionResult> GetAllBrands()
        {
          var result = await serviceManager.ProductService.GetAllBrandsAsync();
          if (result is null) return BadRequest();  // 400
            return Ok(result);  // 200
        }

        // TODO : Get All Types
        [HttpGet("types")]// GET: /api/Products/types
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await serviceManager.ProductService.GetAllTypesAsync();
            if (result is null) return BadRequest();  // 400
            return Ok(result);  // 200
        }
    }
}
