using System.ComponentModel.DataAnnotations;

namespace vexpenses.library.Config
{
    public class EmailConfig
    {
        [Required]
        public string Domain { get; set; }

        [Required]
        public int Port { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
