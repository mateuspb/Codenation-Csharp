using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext data;
        public UserService(CodenationContext context)
        {
            data = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return data.Candidates.Where(x => x.Acceleration.Name == name).Select(x => x.User).ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return data.Users.Where(x => x.Candidates.Any(y => y.CompanyId == companyId)).ToList();
        }

        public User FindById(int id)
        {
            return data.Users.Find(id);
        }

        public User Save(User user)
        {
            if (user.Id.Equals(0))
            {
                data.Add(user);
            }
            else
            {
                data.Update(user);
            }
            data.SaveChanges();
            return user;
        }
    }
}
