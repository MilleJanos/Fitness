using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Logic
{
    public class Data
    {
        public static FitnessController Fitness { get; }

        static Data()
        {
            Fitness = new FitnessController();
        }
    }
}
