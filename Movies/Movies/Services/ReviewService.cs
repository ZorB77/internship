using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    internal class ReviewService
    {
        private readonly Repository<Review> _reviewRepository;
        public ReviewService(Repository<Review> reviewRepository) {
            _reviewRepository = reviewRepository;
        }
    }
}
