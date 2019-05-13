using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public class Lanse
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public LanseType Type { get; set; }

        [Required]
        public int TypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public bool Active { get; set; }

        public int Price { get; set; }

        //[StringLength(maximumLength: 20, MinimumLength = 3)]
        //public string SearchIndex { get; set; }

    }
}
