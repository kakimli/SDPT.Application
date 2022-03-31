1. Rooms Matching

Demand.RoomsMin (DRMin) Demand.RoomsMax (DRMax) <br>
Housing.RoomsMin (HRMin) Housing.RoomsMax (HRMax)

| Cases                            |  Match  |
|----------------------------------|:-------:|
| DRMax >= HRMin or HRMax >= DRMin |    +    |
| Otherwise                        |    -    |

2. Time Matching

Demand.TimeEarliest (TE) Demand.TimeLatest (TL) <br>
Housing.AvailableTimeEarliest (ATE) Housing.AvailableTimeLatest (ATL) 

| Cases                            |  Match  |
|----------------------------------|:-------:|
| ATE <= LE and ATL >= TL          |    +    |
| Otherwise                        |    -    |

3. Parking Matching

| Demand.WithParking  | Housing.WithParking  |  Match  |
|:-------------------:|:--------------------:|:-------:|
| True                | True                 |    +    |
| True                | False                |    -    |
| False               | True                 |    +    |
| False               | False                |    +    |

4. Independent Washroom Matching

| Demand.IndependentWashroom  | Housing.IndependentWashroom  |  Match  |
|:---------------------------:|:----------------------------:|:-------:|
| True                        | True                         |    +    |
| True                        | False                        |    -    |
| False                       | True                         |    +    |
| False                       | False                        |    +    |

5. LivingType Matching

DemandLivingType (DLT) HousingLivingType (HLT)

| Cases                    |  Match                            |
|--------------------------|:---------------------------------:|
| DLT is not All           | match if having the same value    |
| DLT is All               | +                                 |

6. AllowPets Matching

| Demand.IndependentWashroom  | Housing.IndependentWashroom  |  Match  |
|:---------------------------:|:----------------------------:|:-------:|
| True                        | True                         |    +    |
| True                        | False                        |    -    |
| False                       | True                         |    +    |
| False                       | False                        |    +    |
