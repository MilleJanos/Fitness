using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class LanseTypeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ActiveDays { get; set; }

        public int ActivePerDay { get; set; }

        public int ActiveHours { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

    }
}
