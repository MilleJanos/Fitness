using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Logic
{
    public static class Data
    {

        public static FitnessController FitnessC { get; } // only the constructor can set it

        static Data()
        {
            FitnessC = new FitnessController();
        }


    }
}
