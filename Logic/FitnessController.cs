using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fitness.Model.DBContext;
using System.Threading.Tasks;
using Fitness.Model;

namespace Fitness.Logic
{
    public class FitnessController
    {
        private FitnessDB fitnessDatabase;

        public FitnessController()
        {
            this.fitnessDatabase = new FitnessDB();
        }

        // GETs:

        public List<User> GetUsers()
        {
            return fitnessDatabase.User.ToList();
        }

        public User GetUserByUserEmail(string userEmail)
        {
            return fitnessDatabase.User.FirstOrDefault(u => u.Email.Equals(userEmail));
        }

        public List<Role> GetRoles()
        {
            return fitnessDatabase.Role.ToList();
        }

        public List<Lanse> GetLanses()
        {
            return fitnessDatabase.Lanse.ToList();
        }


    }
}
