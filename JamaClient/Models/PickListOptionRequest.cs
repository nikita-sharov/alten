using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JamaClient.Models
{
    public class PickListOptionRequest : IValidatableObject
    {
        /// <summary>
        /// The unique sort order within the <see cref="PickList"/>; gets assigned if not set manually.
        /// </summary>
        /// <remarks>Values between 1 and the count of <see cref="PickList"/>'s options."/>.</remarks>
        [DisplayName("Order")]
        public int? SortOrder { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayName("Display")]
        public string Name { get; set; }

        /// <summary>
        /// The internal meaning; to organization administrators only (supposedly).
        /// </summary>
        /// <remarks>
        /// An option with the <see cref="Name"/> "High" could have a description of "over 5000 items",
        /// "625-750 degrees", or "at least 72 miles".
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// The numerical value or weight of the option; useful in creating calculated fields.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// A color code from the <see cref="ColorPalette.HexCodes"/>.
        /// </summary>
        /// <remarks>
        /// For example the test case status field is set to have a passing color of green,
        /// a failing status of red, and a blocked status of orange.
        /// </remarks>
        public string Color { get; set; }

        public bool Default { get; set; }

        /// <summary>
        /// Reserved for the soft deletion, supposedly.
        /// </summary>
        public bool Active { get; set; } = true;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {            
            if (SortOrder.HasValue && (SortOrder <= 0))
            {
                yield return new ValidationResult(
                    "Sort order must be either null or greater than 0.",
                    new[] { nameof(SortOrder) });
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                // Actually, blanks are allowed by the API.
                yield return new ValidationResult(
                    "Name must not be null or empty, and should not consist of white-space characters only.", 
                    new[] { nameof(Name) });
            }            

            if ((Color != null) && !ColorPalette.HexCodes.Contains(Color))
            {
                yield return new ValidationResult(
                    "Color must be either null or one of the color palette hex codes.",
                    new[] { nameof(Color) });
            }

            if (!Active)
            {
                yield return new ValidationResult(
                    "Active should be true to avoid side effects and/or undefined behaviour.",
                    new[] { nameof(Active) });
            }
        }
    }
}
