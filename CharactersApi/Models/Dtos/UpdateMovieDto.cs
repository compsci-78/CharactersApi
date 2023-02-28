namespace CharactersApi.Models.Dtos
{
    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
    }
}
