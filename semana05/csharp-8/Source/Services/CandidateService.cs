using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        CodenationContext data;
        public CandidateService(CodenationContext context)
        {
            data = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return data.Candidates.Where(x => x.AccelerationId == accelerationId).ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return data.Candidates.Where(x => x.CompanyId == companyId).ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return data.Candidates.Find(userId, accelerationId, companyId);
        }

        public Candidate Save(Candidate candidate)
        {
            Candidate candidateExists = FindById(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);
            if (candidateExists == null)
            {
                data.Add(candidate);
            }
            else
            {
                data.Entry(candidateExists).State = EntityState.Detached;
                data.Update(candidate);
            }
            data.SaveChanges();
            return candidate;
        }
    }
}
