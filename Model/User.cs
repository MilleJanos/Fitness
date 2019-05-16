using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Model
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        
        [Key]
        public int Id { get; set; }

        //[StringLength(maximumLength:1000,MinimumLength = 5)]
        public string Barcode { get; set; }
    
        //[StringLength(maximumLength: 50, MinimumLength = 3)]
        public string FirstName { get; set; }
    
        //[StringLength(maximumLength: 50, MinimumLength = 3)]
        public string LastName { get; set; }
    
        public DateTime BirthDate { get; set; }

        [Required]
        //[StringLength(maximumLength: 200, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        //[StringLength(maximumLength: 200, MinimumLength = 6)]
        public string Password { get; set; }

        //[StringLength(maximumLength: 20, MinimumLength = 6)]
        public string PhoneNumber { get; set; }
    
        //[StringLength(maximumLength: 500)]
        public string Image { get; set; }

        //[StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Role { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }

    }
}
