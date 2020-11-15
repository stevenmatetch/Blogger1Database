using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogger1Database.Data;
using Blogger1Database.Models;

namespace Blogger1Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookOrdersController : ControllerBase
    {
        private readonly Blogger1DatabaseContext _context;

        public BookOrdersController(Blogger1DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/BookOrders
        [HttpGet]
        public IEnumerable<BookOrder> GetBookOrder()
        {
            return _context.BookOrder;
        }

        // GET: api/BookOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookOrder = await _context.BookOrder.FindAsync(id);

            if (bookOrder == null)
            {
                return NotFound();
            }

            return Ok(bookOrder);
        }

        // PUT: api/BookOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookOrder([FromRoute] int id, [FromBody] BookOrder bookOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookOrder.BookID)
            {
                return BadRequest();
            }

            _context.Entry(bookOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookOrders
        [HttpPost]
        public async Task<IActionResult> PostBookOrder([FromBody] BookOrder bookOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BookOrder.Add(bookOrder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookOrderExists(bookOrder.BookID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookOrder", new { id = bookOrder.BookID }, bookOrder);
        }

        // DELETE: api/BookOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookOrder = await _context.BookOrder.FindAsync(id);
            if (bookOrder == null)
            {
                return NotFound();
            }

            _context.BookOrder.Remove(bookOrder);
            await _context.SaveChangesAsync();

            return Ok(bookOrder);
        }

        private bool BookOrderExists(int id)
        {
            return _context.BookOrder.Any(e => e.BookID == id);
        }
    }
}