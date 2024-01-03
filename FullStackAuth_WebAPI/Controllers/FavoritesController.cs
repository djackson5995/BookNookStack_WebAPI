using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FullStackAuth_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("myFavorites"), Authorize]
        public IActionResult GetFavorite()
        {
            try
            {
                string userId = User.FindFirstValue("id");

                var favorites = _context.Favorite.Where(f => f.UserId.Equals(userId));
                return StatusCode(200, favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }
        [HttpPost, Authorize]
        public IActionResult PostFavorite([FromBody] Favorite data)
        {
            try
            {
                string userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }
                data.UserId = userId;
                _context.Favorite.Add(data);
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
                Favorite data = _context.Favorite.FirstOrDefault(f => f.Id == id);
                if (data == null)
                {
                    return NotFound();
                }
                var userId = User.FindFirstValue("id");
                if (string.IsNullOrEmpty(userId) || data.UserId != userId)
                {
                    return Unauthorized();
                }
                _context.Favorite.Remove(data);
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

