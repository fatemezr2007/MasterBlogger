using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }
        public List<ArticleViewModel> Articles { get; set; }


        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }
    }
}
