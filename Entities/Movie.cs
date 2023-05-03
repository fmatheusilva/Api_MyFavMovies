namespace Api_MyFavMovies.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid IdUser { get; set; }
        public bool IsDeleted {get;set;} 

        public void Update(string title,  string description)
        {
            Title = title;
            Description = description;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}