using Microsoft.EntityFrameworkCore;

namespace WalkerscottDotNetCoreEF.API.Models.Domain
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
    }
    
}
