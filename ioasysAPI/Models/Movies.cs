using System.Collections.Generic;


namespace ioasysAPI.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<Review> Reviews { get; set; }

    }
}