using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness.Model.Entities;

public class Seat
{
    [Key]
    public int Id { get; set; }
    public string SeatNumber { get; set; }
        
    [ForeignKey("Area")]
    public int AreaId { get; set; }
    public Area Area { get; set; }
}