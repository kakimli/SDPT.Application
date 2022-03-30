
using System.ComponentModel.DataAnnotations;

namespace SDPT.Application.Models
{
  public class Housing
  {
    [Key]
    public long Id { get; set; }

    [Required]
    public string Email { get; set; }

    
    public int Rooms { get; set; }
  }

}