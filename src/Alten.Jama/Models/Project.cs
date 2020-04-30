using System;
using System.Collections.Generic;
using System.Text;

namespace Alten.Jama.Models
{
    public sealed class Project : ProjectRequest
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        /// <summary>
        /// Equals to <see cref="CreatedDate"/> if not modified yet.
        /// </summary>
        public DateTimeOffset ModifiedDate { get; set; }

        /// <summary>
        /// User ID.
        public int CreatedBy { get; set; }

        /// <summary>
        /// User ID, equals to <see cref="CreatedBy"/> if not modified yet.
        /// </summary>
        public int ModifiedBy { get; set; }
    }
}
