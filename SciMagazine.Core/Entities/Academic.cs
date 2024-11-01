using SciMagazine.Core.Common.Classes;
using SciMagazine.Core.Enums;

namespace SciMagazine.Core.Entities
{

    public class Academic : User
    {
        public List<Paper> AssignedPapers { get; private set; } = new();



        public List<Paper> GetAssignedPapers() => AssignedPapers;

        public void AssignPaper(Paper paper)
        {
            if (AssignedPapers.Any(r => r.Id == paper.Id))
            {
                throw new InvalidOperationException();
            }

            AssignedPapers.Add(paper);
            
        }

        public void SubmitReview(Paper paper, string feedback, ReviewDecision reviewDecision)
        {
            if (!AssignedPapers.Any(r => r.Id == paper.Id))
            {
                throw new InvalidOperationException();
            }

            var review = Review.CreateReview(feedback, reviewDecision, this, paper);
            paper.AddReview(review);
            AssignedPapers.RemoveAll(r => r.Id == paper.Id);
        }
    }
}
