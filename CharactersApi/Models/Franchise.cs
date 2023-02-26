using System.ComponentModel.DataAnnotations;

namespace CharactersApi.Models
{
    public class Franchise
    {
        // Key
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }        
        [MaxLength(255)]
        public string Description { get; set; }
        /// <summary>
        /// Collection navigation property to Movie since 
        /// many movies can belong to a Franchise
        /// </summary>
        public ICollection<Movie> Movies { get; set; }
    }
}
