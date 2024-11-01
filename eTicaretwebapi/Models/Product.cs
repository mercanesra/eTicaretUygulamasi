namespace eTicaretwebapi.Models
{
    public class Product
    {


        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? ProductCode { get; set; }

        public string? ProductDescription { get; set; } = string.Empty;

        public string? ProductPicture { get; set; }

        public int? ProductPrice { get; set; }

        public int? CategoryId { get; set; }



    }
}
