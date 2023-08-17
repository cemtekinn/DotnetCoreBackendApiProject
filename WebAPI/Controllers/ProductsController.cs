using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;

using Microsoft.AspNetCore.Mvc;



namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {   
        //Inversion of control
        IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("delete")]
        public IActionResult Delete(int productId)
        {
            var result = productService.Delete(productId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpGet("getbybarcodenumber")]
        public IActionResult GetByBarcodeNumber(string barcodeNumber)
        {
            var result = productService.GetByBarcodeNumber(barcodeNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.Message);
            }
        }
        [HttpGet("outofstockproducts")]
        public IActionResult OutOfStockProducts()
        {
            var result = productService.OutOfStockProducts();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.Message);
            }
        }
        [HttpPost("add")]
        public IActionResult Add( Product product)
        {
            var result=productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result=productService.Update(product);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
        [HttpGet("getallwithproductdetail")]
        public IActionResult GetProductDetails()
        {
            var result = productService.GetProductDetails();
            if (result.Success)
                return Ok(result);
            else
                return NotFound(result.Message);
        }
        [HttpGet("getaproductdetail")]
        public IActionResult GetSingleProductDetail(int productId)
        {
            var result = productService.GetSingleProductDetail(productId);
            if (result.Success)
                return Ok(result);
            else
                return NotFound(result.Message);
        }
    }
}
