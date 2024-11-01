using eTicaretUygulamasi.Models;

namespace eTicaretUygulamasi.Dto
{
    public class CartViewModel
    {


        public List<CartItem> CartItems { get; set; }

        public decimal GrandTotal { get; set; }


    }
}
