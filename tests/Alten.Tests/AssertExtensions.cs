using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Alten
{
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Reviewed")]
    public static class AssertExtensions
    {
        public static void IsValid(this Assert assert, object instance)
        {
            var context = new ValidationContext(instance);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(instance, context, results, validateAllProperties: true);
            Assert.IsTrue(isValid);
        }
    }
}
