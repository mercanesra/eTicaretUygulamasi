﻿using eTicaretwebapi.Data;
using eTicaretwebapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicaretwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {

            return await _context.Products.ToListAsync();
            //tüm verileri çekmek için kullanılan method
        }


        [HttpGet("id")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            return await _context.Products.FindAsync(id);


        }

        [HttpDelete("id")]

        public async Task<ActionResult<Product>>DeleteProduct(int id)
        {

            var result = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();

            if (result!=null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();

            }
            return result;

        }

        [HttpPut("id")]
        public async Task<ActionResult<Product>>UpdateProduct(Product product,int id)
        {

            var result = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();

            if (result != null)
            {
                result.ProductName = product.ProductName;
                result.ProductPrice = product.ProductPrice;
                result.ProductCode = product.ProductCode;
                result.ProductPicture = product.ProductPicture;
                await _context.SaveChangesAsync();


            }
            return result;
            //tüm degerleri güncelleme
        }


        [HttpPost]


        public async Task<ActionResult>PostProduct(Product product)
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }




    }

}