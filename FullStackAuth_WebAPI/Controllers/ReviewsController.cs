using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FullStackAuth_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Review data)

        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }
                data.UserId = userId;

                _context.Review.Add(data);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(201, data);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                Review data = _context.Review.FirstOrDefault(r => r.Id == id);
                if (data == null)
                {
                    return NotFound();
                }
                var userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId) || data.UserId != userId)
                {
                    return Unauthorized();

                }
                _context.Review.Remove(data);
                _context.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }



        }
    }
}


            
















