using System.ComponentModel.DataAnnotations;

namespace tour_of_villains_api.Models
{
    public class Villain
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Hero { get; set; }
        public string Description { get; set; }
    }
}
