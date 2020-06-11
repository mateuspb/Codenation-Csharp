using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        CodenationContext data;
        public SubmissionService(CodenationContext context)
        {
            data = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            return data.Submissions.Where(x => x.ChallengeId == challengeId && x.User.Candidates.Any(y => y.AccelerationId == accelerationId)).ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return data.Submissions.Where(x => x.ChallengeId == challengeId).Max(x => x.Score);
        }

        public Submission Save(Submission submission)
        {
            Submission submissionExists = data.Submissions.Find(submission.UserId, submission.ChallengeId);
            if (submissionExists == null)
            {
                data.Add(submission);
            }
            else
            {
                data.Entry(submissionExists).State = EntityState.Detached;
                data.Update(submission);
            }
            data.SaveChanges();
            return submission;
        }
    }
}
