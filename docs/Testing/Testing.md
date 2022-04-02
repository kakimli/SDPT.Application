## Tasks
---

- Design 5-10 Demands and 5-10 Housings to test the api (i.e. Get the expected email list).
- Save the data in json file.

## Post a demand
---

- POST http://localhost:6001/demand
- POST Body:
```json
{
  "Email": "sdpt_demo_demand1@163.com",
  "RoomsMax": 3,
  "RoomsMin": 1,
  "TimeEarliest": 1651363200,
  "TimeLatest": 1661904000,
  "WithParking": false,
  "IndependentWashroom": false,
  "HousingType": 2,
  "AllowPets": false,
  "Intro": "Near SuperMarkets like TNT"
}
```
- Demand Class:
```c#
  public enum DemandLivingType 
  {
    House,
    TownHouse,
    Condo,
    All
  }

  public class Demand
  {
    public long Id 
    public string Email
    public int RoomsMin
    public int RoomsMax
    public long TimeEarliest
    public long TimeLatest
    public bool WithParking
    public bool IndependentWashroom
    public DemandLivingType HousingType
    public bool AllowPets
    public string Intro
  }
```
- Housing Class:

```c#
  public enum HousingLivingType {
    House,
    TownHouse,
    Condo
  }

  public class Housing
  {
    public long Id
    public string Email
    public int RoomsMin
    public int RoomsMax
    public long AvailableTimeEarliest
    public long AvailableTimeLatest
    public bool WithParking
    public bool IndependentWashroom
    public HousingLivingType HousingType
    public bool AllowPets
    public string? Intro
  }
```

- Matching Rules - See ./MatchingRules.md

## Helpers
---

- To use Time Converter to obtain timestamps: <br>
<code>./Start-TimeConverter.bat</code>