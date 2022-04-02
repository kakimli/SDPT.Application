using System.ComponentModel.DataAnnotations;

namespace SDPT.Application.Models
{
  public enum DemandLivingType 
  {
    House,
    TownHouse,
    Condo,
    All
  }

  public class Demand
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
    public long TimeEarliest { get; set; }

    [Required]
    public long TimeLatest { get; set; }

    [Required]
    public Boolean WithParking { get; set; } = false;

    [Required]
    public Boolean IndependentWashroom { get; set; } = false;

    [Required]
    public DemandLivingType HousingType { get; set; } = DemandLivingType.All;
    
    [Required]
    public Boolean AllowPets { get; set; } = false;

    public String Intro { get; set; } = "";

  }

}