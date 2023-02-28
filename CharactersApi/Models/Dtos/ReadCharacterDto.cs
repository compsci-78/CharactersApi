using System.ComponentModel.DataAnnotations;

namespace CharactersApi.Models.Dtos
{
    public class ReadCharacterDto
    {        
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Alias { get; set; }        
        public string Gender { get; set; }       
        public string Picture { get; set; }        
        public List<string> Movies { get; set; }
    }
}
