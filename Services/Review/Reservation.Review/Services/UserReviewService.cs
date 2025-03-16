using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Reservation.Review.Context;
using Reservation.Review.Dtos;
using Reservation.Review.Entities;
using System.Runtime.CompilerServices;

namespace Reservation.Review.Services
{
    public class UserReviewService : IUserReviewService
    {
        private readonly ReviewContext _context;
        private readonly IMapper _mapper;

        public UserReviewService(ReviewContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateUserReviewAsync(CreateUserViewDto createUserViewDto)
        {
            var value = _mapper.Map<UserReview>(createUserViewDto);
            await _context.UserReviews.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserReviewAsync(int id)
        {
            var value = await _context.UserReviews.FindAsync(id);
            _context.UserReviews.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultUserViewDto>> GetAllUserReviewAsync()
        {
            var values = await _context.UserReviews.ToListAsync();
            return _mapper.Map<List<ResultUserViewDto>>(values);
        }

        public async Task<GetByIdUserViewDto> GetByIdUserReviewAsync(int id)
        {
            var value = await _context.UserReviews.FindAsync(id);
            return _mapper.Map<GetByIdUserViewDto>(value);
        }

        public async Task UpdateUserReviewAsync(UpdateUserViewDto updateUserViewDto)
        {
            var value = _mapper.Map<UserReview>(updateUserViewDto);
            _context.UserReviews.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}
