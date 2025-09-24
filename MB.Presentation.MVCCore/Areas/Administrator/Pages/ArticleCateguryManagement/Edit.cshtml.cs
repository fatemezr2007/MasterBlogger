using MB.Application.Contracts.ArticleCategury;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCateguryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty] public RenameArticleCategury ArticleCategury { get; set; }
        private readonly IArticleCateguryApplication _articleCateguryApplication;
        public EditModel(IArticleCateguryApplication articleCateguryApplication)
        {
            _articleCateguryApplication = articleCateguryApplication;
        }

        public void OnGet(long id)
        {
            ArticleCategury = _articleCateguryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            _articleCateguryApplication.Rename(ArticleCategury);
            return RedirectToPage("./List");
        }
    }
}
