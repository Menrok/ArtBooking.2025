using System.ComponentModel.DataAnnotations;

namespace Bussiness.Model.Entities;

public class ArtOrganization
{
    [Key]
    public int ArtOrganizationId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string website { get; set; }
    
    public virtual ICollection<User>? Users { get; set; }
    public ICollection<ArtEvent> ArtEvents { get; set; }
}