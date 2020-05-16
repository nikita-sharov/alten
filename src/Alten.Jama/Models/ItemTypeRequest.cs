using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Alten.Jama.Models
{
    public class ItemTypeRequest : IValidatableObject
    {
        private static IEnumerable<string> RequestableCategories = new HashSet<string>
        {
            ItemTypeCategories.Default,
            ItemTypeCategories.Defect,
            ItemTypeCategories.TestCase
        };

        // TODO: Specify synchronizable (and requestable) widgets. Extract?
        private static IEnumerable<string> RequestableWidgetNames = new HashSet<string>
        {
            ItemTypeWidget.Activities.Name,
            ItemTypeWidget.Attachments.Name,
            ItemTypeWidget.ChangeRequests.Name,
            ItemTypeWidget.Relationships.Name,
            ItemTypeWidget.Risk.Name,
            ItemTypeWidget.SynchronizedItems.Name,
            ItemTypeWidget.Tags.Name,
            ItemTypeWidget.Urls.Name,
            ItemTypeWidget.Versions.Name
        };

        [Required]
        public string TypeKey { get; set; }

        [Required]
        public string Display { get; set; }

        [Required]
        public string DisplayPlural { get; set; }

        public string Description { get; set; }

        public ItemTypeImage Image { get; set; }

        [Display(Name = "Use as")]
        public string Category { get; set; } = ItemTypeCategories.Default;

        public List<ItemTypeWidget> Widgets { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!RequestableCategories.Contains(Category))
            {
                yield return new ValidationResult($"{Category} is not requestable.", new[] { nameof(Category) });
            }

            foreach (ItemTypeWidget widget in Widgets)
            {
                if (!RequestableWidgetNames.Contains(widget.Name))
                {
                    yield return new ValidationResult($"{widget.Name} is not requestable.", new[] { nameof(Widgets) });
                }
            }
        }
    }
}
