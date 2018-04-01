using System;

namespace SprungGermanData
{
    public class Word
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int InProgressId { get; set; }
        public string EnglishVersion { get; set; }
        public string GermanVersion { get; set; }
        public int TimesRepeated { get; set; }
        public Boolean Learned { get; set; }


    }
}