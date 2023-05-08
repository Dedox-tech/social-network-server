using System.ComponentModel.DataAnnotations;

namespace SocialNetworkServer.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

    }
}
