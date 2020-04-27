using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product InvProduct { get; set; }
        public Category InvCategory { get; set; }
    }
}