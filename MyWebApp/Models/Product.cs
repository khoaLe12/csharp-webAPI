using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Product
{
    [Required(ErrorMessage = "Product ID is required")]
    [Display(Name = "Product ID")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name is required")]
    [StringLength(50, ErrorMessage = "Product Name must be less than 50 characters")]
    [Display(Name = "Product Name")]
    public string? ProductName { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }
}
