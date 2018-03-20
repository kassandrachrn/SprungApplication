using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprungGermanData.Models
{
    class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Learner> Learners { get; set; }

        public Group() {

            Learners = new HashSet<Learner>();
        }

    }
}
