using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreOverview.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter correct email.")]
        public string Email { get; set; }

    }
}
