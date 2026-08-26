namespace Movies.API.Request
{
    public class MovieUpdateRequest
    {
        public string Title { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
    }
}
