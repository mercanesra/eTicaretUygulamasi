using eTicaretUygulamasi.Data;
using eTicaretUygulamasi.Dto;
using eTicaretUygulamasi.Models;
using eTicaretUygulamasi.Oturum;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace eTicaretUygulamasi.Component
{
    public class CartController : Controller
    {

        private readonly ApplicationDbContext context;

        public CartController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>(); 
            ;
            CartViewModel cartvm = new()
            {
                CartItems = items,
                GrandTotal = items.Sum(x => x.Quantity * x.Price)

            };


            return View(cartvm);
        }


        //sepete ürün ekleme
        public async Task<IActionResult>Add(int id)
        {

         

            Products product = context.Products.Find(id);

            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = items.FirstOrDefault(x => x.ProductId == id);

            if(cartItem== null)
            {

                items.Add(new CartItem(product));
            }

            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", items);
            TempData["Mesaj"] = "Ürün Sepete Eklendi";

            return Redirect(Request.Headers["Referer"].ToString());


        }


        //sepetten ürün azaltma
        public async Task <IActionResult>Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();


            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;

            }


            else
            {
                cart.RemoveAll(c => c.ProductId == id);
            }

            if (cart.Count > 0)
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Mesaj"] = "Ürün Sepetten Silindi";
            return RedirectToAction("Index");

        }


        //Ürünü sepetten silme

        public async Task<IActionResult> Remove(int id)
        {

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");// sepette ne olduğu
            cart.RemoveAll(c => c.ProductId == id);


            if (cart.Count > 0)
            {
                HttpContext.Session.Remove("Cart");
            }

            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Mesaj"] = "Ürün Sepeti Silindi";
            return RedirectToAction("Index");

        }

        //sepeti temizle
        public async Task<IActionResult> Clear()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }





    }
}
