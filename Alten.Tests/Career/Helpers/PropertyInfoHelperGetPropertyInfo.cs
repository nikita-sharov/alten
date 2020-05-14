using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Alten.Career.Helpers
{
    [TestClass]
    public class PropertyInfoHelperGetPropertyInfo
    {
        [TestMethod]
        public void ReturnsPropertyInfo()
        {
            PropertyInfo propertyInfo = PropertyInfoHelper.GetPropertyInfo<string>(s => s.Length);
            Assert.AreEqual(propertyInfo.MemberType, MemberTypes.Property);
        }

        [TestMethod]
        public void ReturnsNullGivenNonPropertyMember()
        {
            PropertyInfo propertyInfo = PropertyInfoHelper.GetPropertyInfo<string>(s => s.Clone());
            Assert.IsNull(propertyInfo);
        }
    }
}
