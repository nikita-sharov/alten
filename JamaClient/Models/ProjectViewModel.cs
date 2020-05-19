using System;

namespace JamaClient.Models
{
    class ProjectViewModel
    {
        public int Id { get; set; }

        public string ProjectKey { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public User CreatedBy { get; set; }

        public User ModifiedBy { get; set; }
    }
}
