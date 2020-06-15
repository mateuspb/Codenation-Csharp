using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext data;
        public ChallengeService(CodenationContext context)
        {
            data = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return data.Challenges.Where(x => x.Accelerations.Any(y => y.Id == accelerationId) && x.Accelerations.SelectMany(y => y.Candidates).Any(z => z.UserId == userId)).ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id.Equals(0))
            {
                data.Add(challenge);
            }
            else
            {
                data.Update(challenge);
            }
            data.SaveChanges();
            return challenge;
        }
    }
}