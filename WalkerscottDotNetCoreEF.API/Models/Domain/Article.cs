namespace WalkerscottDotNetCoreEF.API.Models.Domain
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDT { get; set; }
    }
}
