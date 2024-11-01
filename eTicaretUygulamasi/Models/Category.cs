using System.ComponentModel.DataAnnotations;

namespace eTicaretUygulamasi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        virtual public List<Products>? Products { get; set; } //Kategori sayfasına birden fazla ürün gelebilir

    }
}
