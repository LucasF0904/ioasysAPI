using ioasysAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ioasysAPI.ViewModels
{
    public class ReviewViewModel
    {
        public ReviewViewModel()
        {
        }

        public ReviewViewModel(Review review)
        {
            if (review == null)
            {
                return;
            }

            MovieId = review.MovieId;
            Rating = review.Rating;
            Description = review.Description;
        }

        public int MovieId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string NameUser { get; set; }

        public Review ToReview()
        {
            return new Review
            {
                MovieId = MovieId,
                Description = Description,
                Rating = Rating,
            };
        }
    }
}