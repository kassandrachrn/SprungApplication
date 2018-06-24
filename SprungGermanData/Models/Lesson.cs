using System;
using System.Collections.Generic;

namespace SprungGermanData
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean Completed { get; set; }
        public Boolean Locked { get; set; }
        public int PercentageDone { get; set; }

    }
}