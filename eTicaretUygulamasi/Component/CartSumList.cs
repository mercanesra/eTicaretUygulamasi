using eTicaretUygulamasi.Data;
using eTicaretUygulamasi.Dto;
using eTicaretUygulamasi.Models;
using eTicaretUygulamasi.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace eTicaretUygulamasi.Component
{
    public class CartSumList:ViewComponent
    {

        public readonly ApplicationDbContext context;// veritabanına baglama

        public CartSumList(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVm = new()
            {

                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVm);
        }
       



    }
}
