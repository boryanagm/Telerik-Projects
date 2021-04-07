using System.ComponentModel.DataAnnotations;

namespace LayeredArchitecture.Models
{
	public class User
    {
        public int Id { get; set; }
       
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; set; }
    }
}
