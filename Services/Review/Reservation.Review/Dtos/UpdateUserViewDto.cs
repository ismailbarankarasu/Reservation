﻿namespace Reservation.Review.Dtos
{
    public class UpdateUserViewDto
    {
        public int UserReviewId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Detail { get; set; }
        public int Score { get; set; }
    }
}
