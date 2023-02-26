using System.ComponentModel.DataAnnotations;

namespace CharactersApi.Models
{
    public class Character
    {
        // Key
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Alias{ get; set; }
        [MaxLength(30)]
        public string Gender{ get; set; }
        [MaxLength(255)]
        public string Picture { get; set; }
        /// <summary>
        /// Collection navigation property refering to Movie.
        /// This will result in a linking tabel between Movies
        /// and Characters as they have many to many relation
        /// </summary>
        public ICollection<Movie> Movies { get; set; }
    }
}
