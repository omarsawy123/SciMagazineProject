using SciMagazine.Core.Common;
using SciMagazine.Core.Enums;

namespace SciMagazine.Core.Entities
{

    public class Academic : User
    {
        public List<Review> AssignedReviews { get; private set; } = new();



        public void SubmitReview(Paper paper, string feedback, ReviewDecision reviewDecision)
        {
            if (!AssignedReviews.Any(r => r.Paper.Id == paper.Id))
            {
                // throw ex
            }

            var review = new Review(feedback, reviewDecision, this, paper);

            paper.AddReview(review);
            AssignedReviews.RemoveAll(r => r.Paper.Id == paper.Id);
        }
    }
}
