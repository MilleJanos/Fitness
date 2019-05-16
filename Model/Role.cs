using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string StringId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
