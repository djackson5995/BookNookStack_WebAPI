using FullStackAuth_WebAPI.Data;
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
        [HttpGet("myFavorites"),Authorize]
        public IActionResult GetFavorite()
        {
            try
            {
                string userId = User.FindFirstValue("id");

                var favorites = _context.Favorite.Where(f => f.UserId.Equals(userId));
                return StatusCode(200, favorites);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



            }

            
        }
        

    }

