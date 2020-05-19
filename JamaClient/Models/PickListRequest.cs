using System.ComponentModel.DataAnnotations;

namespace JamaClient.Models
{
    public class PickListRequest
    {
        public const int NameMaxLength = 255;

        [Required(AllowEmptyStrings = false)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
