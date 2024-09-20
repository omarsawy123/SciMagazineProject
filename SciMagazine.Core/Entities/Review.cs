using SciMagazine.Core.Enums;

namespace SciMagazine.Core.Entities
{
    public class Review
    {
        public int ReviewId { get; private set; }
        public string Feedback { get; private set; }
        public ReviewDecision Decision { get; private set; }
        public Academic Reviewer { get; private set; }
        public Paper Paper { get; private set; }


        private Review(string feedback, ReviewDecision decision, Academic academic, Paper paper)
        {
            Feedback = feedback;
            Decision = decision;
            Paper = paper;
            Reviewer = academic;
        }

        public static Review CreateReview(string feedback, ReviewDecision decision, Academic academic, Paper paper)
        {
            return new Review(feedback, decision, academic, paper);
        }


    }
}
