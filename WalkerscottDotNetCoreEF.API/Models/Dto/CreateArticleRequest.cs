namespace WalkerscottDotNetCoreEF.API.Models.Dto
{
    public class CreateArticleRequest
    {
        public string Title { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDT { get; set; }
    }
}
