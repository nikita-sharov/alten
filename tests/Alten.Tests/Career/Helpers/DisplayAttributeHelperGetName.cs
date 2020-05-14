using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Alten.Career.Helpers
{
    [TestClass]
    public class DisplayAttributeHelperGetName
    {
        private static IEnumerable<object[]> Data { get; } = new List<object[]>
        {
            new object[] { GetPropertyInfo(model => model.Value), "Value" },
            new object[] { GetPropertyInfo(model => model.NamedValue), "Verbose value" },
            new object[] { GetPropertyInfo(model => model.NullableValue), "Nullable value" },
            new object[] { GetPropertyInfo(model => model.RequiredNullableValue), "Required nullable value*" },
            new object[] { GetPropertyInfo(model => model.Reference), "Reference" },
            new object[] { GetPropertyInfo(model => model.NamedReference), "Verbose reference" },
            new object[] { GetPropertyInfo(model => model.RequiredReference), "Required reference*" }
        };

        private static PropertyInfo GetPropertyInfo(Expression<Func<Dummy, object>> expression)
        {
            return PropertyInfoHelper.GetPropertyInfo(expression);
        }

        [TestMethod]
        [DynamicData(nameof(Data))]
        public void ReturnsHumanizedName(PropertyInfo property, string expectedName)
        {
            string actualName = DisplayAttributeHelper.GetName(property);
            Assert.AreEqual(expectedName, actualName);
        }

        private sealed class Dummy
        {
            public int Value { get; set; }

            [Display(Name = "Verbose value")]
            public int NamedValue { get; set; }

            public int? NullableValue { get; set; }

            [Required]
            public int? RequiredNullableValue { get; set; }

            public object Reference { get; set; }

            [Display(Name = "Verbose reference")]
            public object NamedReference { get; set; }

            [Required]
            public object RequiredReference { get; set; }
        }
    }
}
