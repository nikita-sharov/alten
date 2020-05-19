using JamaClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace JamaClient
{
    // See: https://dev.jamasoftware.com/api/#response-codes
    [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Reviewed")]
    public static class AssertExtensions
    {        
        public static void IsOK(this Assert assert, Meta meta)
        {
            Assert.IsNotNull(meta);
            Assert.AreEqual(HttpStatusCode.OK, meta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, meta.Timestamp.Date);
        }

        public static void IsCreated(this Assert assert, Meta meta)
        {
            Assert.IsNotNull(meta);
            Assert.AreEqual(HttpStatusCode.Created, meta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, meta.Timestamp.Date);
            Assert.IsTrue(meta.Id.HasValue && (meta.Id > 0));
        }

        public static void IsNotFound(this Assert assert, Meta meta)
        {
            Assert.IsNotNull(meta);
            Assert.AreEqual(HttpStatusCode.NotFound, meta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, meta.Timestamp.Date);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(meta.Message));
        }

        public static void IsBadRequest(this Assert assert, Meta meta)
        {
            Assert.IsNotNull(meta);
            Assert.AreEqual(HttpStatusCode.BadRequest, meta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, meta.Timestamp.Date);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(meta.Message));
        }
    }
}
