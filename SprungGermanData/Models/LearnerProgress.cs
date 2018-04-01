using System.Collections.Generic;

namespace SprungGermanData
{
    public class LearnerProgress
    {
        public int Id { get; set; }
        public int CurrentLessonId { get; set; }
        public int Streak { get; set; }
        public int DailyPoints { get; set; }
        public int TotalPoints { get; set; }
        public string LearnerId { get; set; }

    }
}