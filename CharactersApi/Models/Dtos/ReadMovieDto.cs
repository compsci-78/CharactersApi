namespace CharactersApi.Models.Dtos
{
    public class ReadMovieDto
    {
        public int Id { get; set; }        
        public string Title { get; set; }        
        public string Genre{ get; set; }       
        public string Year { get; set; }        
        public string Director { get; set; }        
        public string Picture { get; set; }                
        public string Trailer { get; set; }        
        public int FranchiseId { get; set; }        
        public List<string> Characters { get; set; }
    }
}
