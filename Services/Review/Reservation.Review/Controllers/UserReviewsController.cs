using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Review.Dtos;
using Reservation.Review.Services;

namespace Reservation.Review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewsController : ControllerBase
    {
        private readonly IUserReviewService _userReviewService;

        public UserReviewsController(IUserReviewService userReviewService)
        {
            _userReviewService = userReviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserReview()
        {
            var value = await _userReviewService.GetAllUserReviewAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserReview(CreateUserViewDto createUserViewDto)
        {
            await _userReviewService.CreateUserReviewAsync(createUserViewDto);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserReview(UpdateUserViewDto updateUserViewDto)
        {
            await _userReviewService.UpdateUserReviewAsync(updateUserViewDto);
            return Ok("Güncelleme başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteUserReview(int id)
        {
            await _userReviewService.DeleteUserReviewAsync(id);
            return Ok("Silme başarılı");
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetUserRewiew(int id)
        {
            var value = await _userReviewService.GetByIdUserReviewAsync(id);
            return Ok(value);
        }
    }
}
