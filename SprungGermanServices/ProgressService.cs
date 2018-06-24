using SprungGermanData;
using SprungGermanData.Interfaces;

namespace SprungGermanServices
{
    public class ProgressService : IProgress
    {
        private SprungDbContext _context;
        private LearnerProgress learnerProgress;

        public ProgressService(SprungDbContext context)
        {
            _context = context;
        }

        public void LinkUserToProgress(Learner learner)
        {
            learnerProgress = new LearnerProgress(learner);
            _context.Add(learnerProgress);
            _context.SaveChanges();
        }
    }
}
