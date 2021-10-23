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
    public class Model : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Model(ApplicationContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<List<Models.Model>> GetModels()
        {
            return await _context.Models.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<Models.Model> GetModel(int id)
        {
            var model = await _context.Models.FindAsync(id);
            return model;
        }
    }
}
