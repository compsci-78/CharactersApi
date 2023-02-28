using System.ComponentModel.DataAnnotations;

namespace CharactersApi.Models.Dtos
{
    public class ReadFranchiseDto
    {      
        public int Id { get; set; }        
        public string Name { get; set; }     
        public string Description { get; set; }
        public List<string> Movies { get; set; }
    }
}
