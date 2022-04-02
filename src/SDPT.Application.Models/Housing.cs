
using System.ComponentModel.DataAnnotations;

namespace SDPT.Application.Models
{

  public enum HousingLivingType {
    House,
    TownHouse,
    Condo
  }

  public class Housing
  {
    [Key]
    public long Id { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int RoomsMin { get; set; }

    [Required]
    public int RoomsMax { get; set; }

    [Required]
    public long AvailableTimeEarliest { get; set; }

    [Required]
    public long AvailableTimeLatest { get; set; }

    [Required]
    public Boolean WithParking { get; set; } = false;

    [Required]
    public Boolean IndependentWashroom { get; set; }

    [Required]
    public HousingLivingType HousingType { get; set; }
    
    [Required]
    public Boolean AllowPets { get; set; }

    public String? Intro { get; set; } = "";
  }

}