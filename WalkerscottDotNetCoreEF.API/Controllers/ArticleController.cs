using Microsoft.AspNetCore.Mvc;
using WalkerscottDotNetCoreEF.API.Models.Domain;
using WalkerscottDotNetCoreEF.API.Models.Dto;
using WalkerscottDotNetCoreEF.API.Repository.Interfaces;

namespace WalkerscottDotNetCoreEF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleRequest request)
        {
            // map DTO to domain module
            var article = new Article
            {
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
                CreatedDT = request.CreatedDT
            };

            await articleRepository.CreateAsync(article);

            var response = new ArticleResponse
            {
                Id=article.Id,
                Title = article.Title,
                Description = article.Description,
                Category = article.Category,
                CreatedDT = article.CreatedDT
            };

            return Ok(response);
        }

        // GET : api/GetallArticles
        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await articleRepository.GetAllArticleAsync();
            var response = new List<ArticleResponse>();
            foreach (var article in articles)
            {
                response.Add(new ArticleResponse
                {
                    Id = article.Id,
                    Title = article.Title,
                    Description = article.Description,
                    Category = article.Category,
                    CreatedDT = article.CreatedDT
                });
            }
            return Ok(response);

        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetArticleById([FromRoute] Guid id)
        {
            var existingArticle=await articleRepository.GetArticleByIdAsync(id);
            if (existingArticle is null)
            { 
                return NotFound();
            }
            var response = new ArticleResponse
            {
                Title = existingArticle.Title,
                Description = existingArticle.Description,
                Category = existingArticle.Category,
                CreatedDT = existingArticle.CreatedDT
            };         
            return Ok(response);

        }

        //http://localhost:5273/api/Article/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] Guid id, UpdateArticleRequest request)
        {
            // convert dto to domain
            var article = new Article
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
                CreatedDT = request.CreatedDT
            };

            article=await articleRepository.UpdateArticleAsync(article);
            if (article is null)
            {
                return NotFound();
            }

            var response = new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                Category = article.Category,
                CreatedDT = article.CreatedDT
            };
            return Ok(response);

        }



        //http://localhost:5273/api/Article/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] Guid id)
        {
           var article= await articleRepository.DeleteArticleAsync(id);
            if (article is null)
            {
                return NotFound();
            }
            //convert domain to dto
            var response = new ArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                Category = article.Category,
                CreatedDT = article.CreatedDT
            };
            return Ok(response);
        }
    }
}
