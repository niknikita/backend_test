using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Brand : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Brand(ApplicationContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<List<Models.Brand>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<Models.Brand> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            return brand;
        }
    }
}
