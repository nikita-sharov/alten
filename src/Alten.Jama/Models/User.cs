namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_User
    public sealed class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public LicenseType LicenseType { get; set; }

        // Always null (also when set via web application)
        public string AvatarUrl { get; set; }

        public bool Active { get; set; }
    }
}
