using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness.Model.Entities;

public class Ticket
{
    [Key]
    public int Id { get; set; }
        
    [ForeignKey("ScheduleItem")]
    public int ScheduleItemId { get; set; }
    public ScheduleItem? ScheduleItem { get; set; }
        
    [ForeignKey("Seat")]
    public int SeatId { get; set; }
    public Seat? Seat { get; set; }
}