﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Models.DTOs;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDTO();
        }

        // GET: api/values
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDTO> productDTOs = await _productRepository.GetProducts();
                _response.Result = productDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()};
            }

            return _response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDTO productDTOs = await _productRepository.GetProductById(id);
                _response.Result = productDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        // POST api/values
        [HttpPost]
        public async Task<object> Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO productDTOs = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = productDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<object> Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                ProductDTO productDTOs = await _productRepository.CreateUpdateProduct(productDTO);
                _response.Result = productDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccessful = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccessful;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}

