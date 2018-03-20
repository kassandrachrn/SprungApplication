using System;

namespace SprungGermanData
{
    public class Word
    {
        public int WordID { get; set; }
        public int LessonID { get; set; }
        public string EnglishVersion { get; set; }
        public string GermanVersion { get; set; }
        public int TimesRepeated { get; set; }
        public Boolean Learned { get; set; }


    }
}