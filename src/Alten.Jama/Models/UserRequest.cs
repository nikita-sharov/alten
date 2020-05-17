using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_RequestUser
    public abstract class UserRequest
    {
        private const string NotEmptyOrWhiteSpace = @"^\S+$";

        /// <summary>
        /// The username must be unique so using an email address is recommended.
        /// </summary>
        [StringLength(200)]
        [RegularExpression(NotEmptyOrWhiteSpace)]
        public virtual string Username { get; set; }

        [StringLength(200, MinimumLength = 6)]
        public virtual string Password { get; set; }

        [StringLength(200)]
        [RegularExpression(NotEmptyOrWhiteSpace)]
        public virtual string FirstName { get; set; }

        [StringLength(200)]
        [RegularExpression(NotEmptyOrWhiteSpace)]
        public virtual string LastName { get; set; }

        [StringLength(132)]
        [EmailAddress]
        public virtual string Email { get; set; }

        [StringLength(64)]
        public string Phone { get; set; }

        [StringLength(64)]
        public string Title { get; set; }

        [StringLength(64)]
        public string Location { get; set; }

        public LicenseType LicenseType { get; set; }
    }
}
