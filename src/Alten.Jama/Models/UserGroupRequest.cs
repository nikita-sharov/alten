using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    public sealed class UserGroupRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? Project { get; set; }
    }
}
