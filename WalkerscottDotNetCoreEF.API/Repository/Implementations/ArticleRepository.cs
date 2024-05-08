using Microsoft.EntityFrameworkCore;
using WalkerscottDotNetCoreEF.API.Models.Domain;
using WalkerscottDotNetCoreEF.API.Repository.Interfaces;

namespace WalkerscottDotNetCoreEF.API.Repository.Implementations
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext dbContext;

        public ArticleRepository(ArticleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Article> CreateAsync(Article article)
        {
            await dbContext.Articles.AddAsync(article);
            await dbContext.SaveChangesAsync();
            return article;
        }

        public async Task<Article?> DeleteArticleAsync(Guid id)
        {
           var existingArticle= await dbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (existingArticle is null)
            {
                return null;
            }
            dbContext.Articles.Remove(existingArticle);
            await dbContext.SaveChangesAsync();
            return existingArticle;
        }

        public async Task<IEnumerable<Article>> GetAllArticleAsync()
        {
            //return await dbContext.Articles.ToListAsync();
            return await dbContext.Articles.OrderByDescending(x => x.CreatedDT).ToListAsync();
        }

        public async Task<Article?> GetArticleByIdAsync(Guid id)
        {
           return await dbContext.Articles.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<Article?> UpdateArticleAsync(Article article)
        {
           var existingArticle=  await dbContext.Articles.FirstOrDefaultAsync(x => x.Id == article.Id);
            if (existingArticle != null)
            {
                dbContext.Entry(existingArticle).CurrentValues.SetValues(article);
                await dbContext.SaveChangesAsync();
                return article;
            }
            return null;
        }
    }
}
