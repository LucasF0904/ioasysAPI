using System.Collections.Generic;

namespace ioasysAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }
    }
}