﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(product);
                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(product);
                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductModel product)
        {

            var response = await _productService.DeleteProductById(product.Id);
            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}
