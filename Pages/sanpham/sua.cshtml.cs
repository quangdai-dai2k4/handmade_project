using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace handmade.Pages.sanpham
{
    [BindProperties]
    public class suaModel : PageModel
    {
        private readonly Connet _db;
        public sanpham_model sanphams { get; set; }
        public suaModel(Connet db)
        {
            _db = db;
        }

        public IActionResult OnGet(string? productid)
        {
            if (productid != null)
            {
                sanphams = _db.products.Find(productid);
                if (sanphams == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
           
                int phamtram =(int) ((sanphams.original_price - sanphams.discounted_price) / sanphams.original_price) * 100;
                sanphams.discount_percentage = phamtram;
                sanphams.updated_at = DateTime.Now;

                _db.products.Update(sanphams);
                _db.SaveChanges();
                return RedirectToPage("Index");
            
           
        }
    }
}