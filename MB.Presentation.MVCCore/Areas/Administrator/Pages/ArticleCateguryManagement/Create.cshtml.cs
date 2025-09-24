using MB.Application.Contracts.ArticleCategury;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCateguryManagement
{
    public class CreateModel : PageModel
    {
        private readonly IArticleCateguryApplication _articleCateguryApplication;
        public CreateModel(IArticleCateguryApplication articleCateguryApplication)
        {
            _articleCateguryApplication = articleCateguryApplication;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateArticleCategury command)
        {
            _articleCateguryApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
