using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharactersApi.Models
{
    public class Movie
    {
        // Key
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(30)]
        public string Genre{ get; set; }
        [MaxLength(4)]
        public string Year { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        [MaxLength(255)]
        public string Picture { get; set; }        
        [MaxLength(255)]
        public string Trailer { get; set; }

        /// <summary>
        /// Foreign key property refering to the Franchies
        /// </summary>        
        public int? FranchiseId { get; set; }
        /// <summary>
        /// Navigation property refering to the Franchies
        /// </summary>
        public Franchise Franchise { get; set; }
        /// <summary>
        /// Collection navigation property refering to Character.
        /// This will result in a linking table between Movies 
        /// and and Characters as they have many relation.
        /// </summary>
        public ICollection<Character> Characters { get; set; }
    }
}
