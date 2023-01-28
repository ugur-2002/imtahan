using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indigo.Models
{
    public class Post
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        public string? ImageUrl { get; set; }

        [StringLength(maximumLength: 60)]
        public string Title { get; set; }
        [StringLength(maximumLength: 200)]
        public string Desc { get; set; }
        [StringLength(maximumLength: 20)]
        public string Button { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
