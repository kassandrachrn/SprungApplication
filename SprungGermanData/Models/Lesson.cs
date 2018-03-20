using System;
using System.Collections.Generic;

namespace SprungGermanData
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Word> Words { get; set; }
        public Boolean Completed { get; set; }

        public Lesson() {

            Words = new HashSet<Word>();
        }

    }
}