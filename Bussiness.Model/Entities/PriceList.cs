using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.Entities;

public class PriceList
{
    [Key]
    public int Id { get; set; }
    public string Description { get; set; }
        
    public ICollection<PriceEntry> PriceEntries { get; set; }
}