using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FullStackAuth_WebAPI.Controllers
{
    public class BookDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult GetBookDetails(string bookId)
        {
           try
            {
                var reviews = _context.Review
                   .Where(r => r.BookId == bookId)
                   .Select(r => new ReviewWithUserDto
                   {
                       Id = r.Id,
                       Text = r.Text,
                       Rating = r.Rating,
                       User = new UserForDisplayDto
                       {
                           Id = r.UserId,
                           UserName = r.User.UserName
                          
                       }
                   })
                .ToList();
                double averageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;

                string userId = User.FindFirstValue("id");

                bool isFavorited = _context.Favorite.Any(f => f.UserId == userId && f.BookId == bookId);

                var bookDetailsDto = new BookDetailsDto
                {
                    Reviews = reviews,
                    AverageRating = averageRating,
                    IsFavorited = isFavorited
                };

                return Ok(bookDetailsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
