namespace WalkerscottDotNetCoreEF.API.Models.Dto
{
    public class ArticleResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDT { get; set; } = DateTime.Now;
    }
}
