using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SprungGermanData
{
    public class Word
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string EnglishVersion { get; set; }
        public string GermanVersion { get; set; }
        public int TimesRepeated { get; set; }
        [NotMapped]
        public List<string> Synonyms { get; set; }
        public Boolean Learned { get; set; }
    }
}