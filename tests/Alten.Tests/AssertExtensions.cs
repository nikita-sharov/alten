using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Alten
{
    // See: https://github.com/microsoft/testfx-docs/blob/master/RFCs/002-Framework-Extensibility-Custom-Assertions.md
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Predefined")]
    internal static class AssertExtensions
    {
        public static void IsValid(this Assert assert, object instance)
        {
            var context = new ValidationContext(instance);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance, context, results, validateAllProperties: true);            
            Assert.IsTrue(isValid);
        }
    }
}
