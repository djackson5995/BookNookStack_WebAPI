namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double AverageRating { get; set; }
        public List<ReviewWithUserDto> Reviews { get; set; }
        public bool IsFavorited { get; set; }



    }
}
