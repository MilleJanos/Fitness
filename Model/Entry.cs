using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public class Entry
    {

        [Key]
        public int Id { get; set; }

        [NotMapped]
        public User User { get; set; }

        [Required]
        public int UserId { get; set; }

        //[StringLength(maximumLength: 1000, MinimumLength = 3)]
        public string Barcode { get; set; }

        public DateTime Date { get; set; }

        public int ReceptionistId { get; set; }
    }
}
