using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<ProductDTO> list = new();
            var response = await _productService.GetAllProductsAsync<ResponseDTO>();
            if (response!= null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid )
            {
                var response = await _productService.CreateProductAsync<ResponseDTO>(productDTO);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(productDTO);
        }

        public async Task<IActionResult> EditProduct(int productId)
        {
            var response = await _productService.GetProductByIDAsync<ResponseDTO>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDTO selectedProduct = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(selectedProduct);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseDTO>(productDTO);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(productDTO);
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var response = await _productService.GetProductByIDAsync<ResponseDTO>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDTO selectedProduct = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(selectedProduct);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductAsync<ResponseDTO>(productDTO.ProductId);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(productDTO);
        }
    }
}

