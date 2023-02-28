using System.ComponentModel.DataAnnotations;

namespace CharactersApi.Models.Dtos
{
    public class UpdateFranchiseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string? Description { get; set; }        
    }
}
