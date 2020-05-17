using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    // See: https://help.jamasoftware.com/ah/en/administration/organization-administrator/manage-users/add-new-user.html    
    public sealed class CreateUserRequest : UserRequest
    {
        [Required]
        public override string Username { get; set; }

        [Required]
        public override string Password { get; set; }

        [Required]
        public override string FirstName { get; set; }

        [Required]
        public override string LastName { get; set; }

        [Required]
        public override string Email { get; set; }
    }
}
