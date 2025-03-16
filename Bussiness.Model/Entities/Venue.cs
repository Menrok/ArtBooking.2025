using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.Entities;    

public class Venue
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
        
    public ICollection<Area> Areas { get; set; }
    public ICollection<ArtEvent> ArtEvents { get; set; }
}