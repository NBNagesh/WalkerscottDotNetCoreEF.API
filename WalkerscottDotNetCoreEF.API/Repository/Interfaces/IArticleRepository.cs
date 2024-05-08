using WalkerscottDotNetCoreEF.API.Models.Domain;

namespace WalkerscottDotNetCoreEF.API.Repository.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> CreateAsync(Article article);

        Task<IEnumerable<Article>> GetAllArticleAsync();

        Task<Article?> GetArticleByIdAsync(Guid id);

        Task<Article?> UpdateArticleAsync(Article article);
        Task<Article?> DeleteArticleAsync(Guid id);
    }
}
