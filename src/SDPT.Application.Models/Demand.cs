using System.ComponentModel.DataAnnotations;

namespace SDPT.Application.Models
{
  public class Demand
  {
    [Key]
    public long Id { get; set; }

    [Required]
    public string Email { get; set; }
    
    public int RoomsMin { get; set; }

    public int RoomsMax { get; set; }
  }

}