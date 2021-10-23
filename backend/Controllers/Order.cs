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
    public class Order : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Order(ApplicationContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<List<Models.Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<Models.Order> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Models.Order order)
        {
            if (!findDateTimeOrder(order))
            {
                await _context.SaveChangesAsync();
                _context.Orders.Add(order);
                return CreatedAtAction("GetOrder", new { id = order.Id }, order);
            }
            return BadRequest("At this time, there is already a record");

        }

        private bool findDateTimeOrder(Models.Order order)
        {
            var result = _context.Orders.ToList().FirstOrDefault(f => f.TimeOrder == order.TimeOrder);
            return result is null;
        }
        
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
