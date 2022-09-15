using System;
using AutoMapper;
using Mango.Services.ProductAPI.DBContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ApplicationDBContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper; 
        }

        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDto)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Update(product);
            }
            else
            { 
                _db.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if (product == null)
                {
                    return false;
                }
                _db.products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            Product product = await _db.products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            List<Product> productList = await _db.products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(productList);
        } 
    }
}

