using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness.Model.Entities;

public class PriceEntry
{
    [Key]
    public int Id { get; set; }
    public decimal Price { get; set; }
        
    [ForeignKey("PriceList")]
    public int PriceListId { get; set; }
    public PriceList? PriceList { get; set; }
}