using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_RequestPickList
    public class PickListRequest
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
