using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public class LanseType
    {
        [Key]
        public int Id { get; set; }

        //[StringLength(maximumLength: 60, MinimumLength = 3)]
        public string Name { get; set; }

        //[StringLength(maximumLength: 100, MinimumLength = 3)]
        public string ActiveDays { get; set; }

        public int ActivePerDay { get; set; }

        //[StringLength(maximumLength: 250, MinimumLength = 3)]
        public int ActiveHoursPerDay { get; set; }

        public int ActiveTimes { get; set; }

        public int Price { get; set; }

        //[StringLength(maximumLength: 250, MinimumLength = 3)]
        public string Description { get; set; }

        public bool Active { get; set; }

    }
}