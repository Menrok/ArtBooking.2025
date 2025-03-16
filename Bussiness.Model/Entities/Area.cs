using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness.Model.Entities;

public class Area
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
        
    [ForeignKey("Venue")]
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
        
    public ICollection<Seat> Seats { get; set; }
}