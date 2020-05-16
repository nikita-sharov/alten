using System;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_Project
    public sealed class Project : ProjectRequest
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Equals to <see cref="CreatedDate"/> if not modified yet.
        /// </summary>
        public DateTimeOffset ModifiedDate { get; set; }

        /// <summary>
        /// The user ID.
        public int CreatedBy { get; set; }

        /// <summary>
        /// The user ID, equals to <see cref="CreatedBy"/> if not modified yet.
        /// </summary>
        public int ModifiedBy { get; set; }
    }
}
