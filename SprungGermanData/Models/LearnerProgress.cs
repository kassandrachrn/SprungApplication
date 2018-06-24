using System.Collections.Generic;

namespace SprungGermanData
{
    public class LearnerProgress
    {
        public int Id { get; set; }
        public int CurrentLessonId { get; set; }
        public List<Word> WordsLearned { get; set; }
        public int GoalInMinutes { get; set; }
        public int Streak { get; set; }
        public int DailyPoints { get; set; }
        public int TotalPoints { get; set; }
        public string LearnerId { get; set; }

        public LearnerProgress(Learner learner)
        {
            this.LearnerId = learner.Id;
        }

    }
}