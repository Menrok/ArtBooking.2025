using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness.Model.Entities;

public class ArtEvent
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }

    [ForeignKey("ArtOrganization")]
    public int ArtOrganizationId { get; set; }
    public ArtOrganization ArtOrganization { get; set; }
    
    public ICollection<Venue> Venues { get; set; }
    public ICollection<ScheduleItem> ScheduleItems { get; set; }
}