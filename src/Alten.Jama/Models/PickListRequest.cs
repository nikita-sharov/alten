using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    public class PickListRequest
    {
        public const int NameMaxLength = 255;

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
