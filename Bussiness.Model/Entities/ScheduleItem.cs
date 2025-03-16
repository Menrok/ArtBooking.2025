using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness.Model.Entities;

public class ScheduleItem
{
    [Key]
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    [ForeignKey("ArtEvent")]
    public int ArtEventId { get; set; }
    public ArtEvent ArtEvent { get; set; }
}