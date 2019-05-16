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

        public List<Role> GetRoles()
        {
            return fitnessDatabase.Role.ToList();
        }


    }
}
