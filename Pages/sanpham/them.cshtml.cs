using handmade.data;
using handmade.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace handmade.Pages.sanpham
{
    [BindProperties]
    public class themModel : PageModel
    {

        private readonly Connet _db;

        public sanpham_model sanphams { get; set; }

        public themModel(Connet db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Random random = new Random();
            string id = random.Next(1000).ToString();
            int phamtram = (int)((sanphams.discounted_price / sanphams.original_price) * 100);
            sanphams.productid = id;
            sanphams.discount_percentage = 100- phamtram;
            sanphams.created_at = DateTime.Now;
            sanphams.updated_at = DateTime.Now;
            _db.products.Add(sanphams);
            _db.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}


