using System.ComponentModel.DataAnnotations;

namespace Typo.Model.Database
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Student Student { get; set; }
    }
}