using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprungGermanData
{
    public class Learner : IdentityUser
    {
        public int LearnerID { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public LearnerProgress LearnerProgress { get; set; }
        public int GroupID { get; set; }

    }

}
