using MB.Application.Contracts.ArticleCategury;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCateguryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCateguryViewModel> ArticleCateguries { get; set; }

        private readonly IArticleCateguryApplication _articleCateguryApplication;
        public ListModel(IArticleCateguryApplication articleCateguryApplication)
        {
            _articleCateguryApplication = articleCateguryApplication;
        }

        public void OnGet()
        {
            ArticleCateguries = _articleCateguryApplication.List();
        }

        public RedirectToPageResult OnPostRemove(long id)
        {
            _articleCateguryApplication.Remove(id);
            return RedirectToPage("./List");
        }

        public RedirectToPageResult OnPostActivate(long id)
        {
            _articleCateguryApplication.Activate(id);
            return RedirectToPage("./List");
        }
    }
}
