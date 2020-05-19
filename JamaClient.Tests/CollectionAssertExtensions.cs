using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace JamaClient
{
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Reviewed")]
    public static class CollectionAssertExtensions
    {        
        public static void IsEmpty<T>(this CollectionAssert assert, ICollection<T> collection)
        {
            Assert.IsNotNull(collection);
            Assert.AreEqual(0, collection.Count);
        }

        public static void IsNotEmpty<T>(this CollectionAssert assert, ICollection<T> collection)
        {
            Assert.IsNotNull(collection);
            Assert.IsTrue(collection.Count > 0);
        }
    }
}
