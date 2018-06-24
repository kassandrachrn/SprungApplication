using Microsoft.AspNetCore.Identity;


namespace SprungGermanData
{
    public class Learner : IdentityUser
    { 
        public override string Id { get; set; }
        public override string Email { get; set; }
        public string Password { get; set; }
        public override string UserName { get; set; }
        public int GroupId { get; set; }

    }

}
