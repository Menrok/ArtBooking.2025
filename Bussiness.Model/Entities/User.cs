using Bussiness.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bussiness.Model.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }
    public string? Email { get; set; }
    public string? LoginName { get; set; }
    public string? PasswordHash { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public UserRole? Role { get; set; }

    [ForeignKey("ArtOrganization")]
    public int? ArtOrganizationId { get; set; }
    public virtual ArtOrganization? ArtOrganization { get; set; }
}