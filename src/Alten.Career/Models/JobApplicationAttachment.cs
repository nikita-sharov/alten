namespace Alten.Career.Models
{
    public sealed class JobApplicationAttachment
    {
        public int JobApplicationId { get; set; }

        public JobApplication JobApplication { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public string FileName { get; set; }
    }
}
