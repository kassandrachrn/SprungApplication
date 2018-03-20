using System.Collections.Generic;

namespace SprungGermanData
{
    public class LearnerProgress
    {
        public int ProgressID { get; set; }
        public int LearnerID { get; set; }
        public int Streak { get; set; }
        public int DailyPoints { get; set; }
        public int TotalPoints { get; set; }
        public IEnumerable<Word> WordsLearned { get; set; }
        public Lesson CurrentLesson { get; set; }

        public LearnerProgress() {

            WordsLearned = new HashSet<Word>();
        }

    }
}