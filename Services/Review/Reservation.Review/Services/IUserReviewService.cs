using Reservation.Review.Dtos;

namespace Reservation.Review.Services
{
    public interface IUserReviewService
    {
        Task<List<ResultUserViewDto>> GetAllUserReviewAsync();
        Task CreateUserReviewAsync(CreateUserViewDto createUserViewDto);
        Task UpdateUserReviewAsync(UpdateUserViewDto updateUserViewDto);
        Task DeleteUserReviewAsync(int id);
        Task<GetByIdUserViewDto> GetByIdUserReviewAsync(int id);
    }
}
