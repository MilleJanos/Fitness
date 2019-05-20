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

        public Lanse Lanse { get; set; }

        [Required]
        public int LanseId { get; set; }

        public DateTime Date { get; set; }

        public int ReceptionistId { get; set; }
    }
}
