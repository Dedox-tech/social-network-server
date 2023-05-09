using System.ComponentModel.DataAnnotations;

namespace SocialNetworkServer.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        
    }
}
