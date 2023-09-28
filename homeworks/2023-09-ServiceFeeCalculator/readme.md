# Service Fee Calculator

## Introduction

You got hired by a local mechanic to build a service fee calculator for his business. She offers different services provided by professionals with different skill levels. Here are the services she offers and the corresponding fees:

* *Basic repair*
    * Done by a *junior mechanic*
    * 15€ per started hour (e.g. 1 hour 15 minutes mean 30€)
    * Must be paid even if repairing was not possible
* *Regular repair*
    * Done by a *senior mechanic*
    * 80€ per started hour
    * Must be paid even if repairing was not possible
* *Complex repair*
    * Done by a *master mechanic*
    * 500€ if repaired within four hours (no rounding to full hours)
    * Flat fee of 800€ if it takes longer
    * Nothing is to pay if repairing was not possible

Every repair job has the following data:

- Description
- Start date and time (`DateTime` data type)
- End date and time (`DateTime` data type); note that the date of start and end are always on the same day.
- Flag indicating whether the repair was successful or not

## Requirements Level 1

### Class Library `ServiceFeeCalculator`

[![](https://mermaid.ink/img/pako:eNp9ksFuwjAMhl8lymmTYAy6Fah2GrDDpF1gp6kXN3HbSGlTJc40xPruS4GBVjF8SfT7c-zY3nFhJPKECw3OLRUUFqq0ZsHW2ICyryZjT9_DIXsGp8RJu4issfAa7HVoYapG41cP2qc_o7uD2pkjq-qCLdEJqxpSpj77lkD4ripkGwJLF_RVLc9qZoxmGy8EOpd7fXC0vSITBllICYKYRKEq0GwBWoR_Eb4g3twe-L_dSK6y_bZcp_v9-Z_mA16hrUDJML99x1JOJVaY8iRcJebgNaU8rduA-kaG0JVUZCxPctAOBxw8mc22Fjwh6_EXOq7BidIGJIagHadt0y1LoRyFJ4Wpc1V0urc6yCVR45LRqHPfFYpKn90JU42ckmWYT_k5j0fxJJ7BJMJ4GsFjFEmRjeezfPIwzuX0fjwB3rYD3kD9Ycy5ANxX_Xbc1O5ofwBI4Oa_?type=png)](https://mermaid.live/edit#pako:eNp9ksFuwjAMhl8lymmTYAy6Fah2GrDDpF1gp6kXN3HbSGlTJc40xPruS4GBVjF8SfT7c-zY3nFhJPKECw3OLRUUFqq0ZsHW2ICyryZjT9_DIXsGp8RJu4issfAa7HVoYapG41cP2qc_o7uD2pkjq-qCLdEJqxpSpj77lkD4ripkGwJLF_RVLc9qZoxmGy8EOpd7fXC0vSITBllICYKYRKEq0GwBWoR_Eb4g3twe-L_dSK6y_bZcp_v9-Z_mA16hrUDJML99x1JOJVaY8iRcJebgNaU8rduA-kaG0JVUZCxPctAOBxw8mc22Fjwh6_EXOq7BidIGJIagHadt0y1LoRyFJ4Wpc1V0urc6yCVR45LRqHPfFYpKn90JU42ckmWYT_k5j0fxJJ7BJMJ4GsFjFEmRjeezfPIwzuX0fjwB3rYD3kD9Ycy5ANxX_Xbc1O5ofwBI4Oa_)

Create a _base class_ called `RepairJob`. It must have the following properties:

- `string Description { get; set; } = "";`
- `DateTime Start { get; set; }`
- `DateTime End { get; set; }`
- `bool Successful { get; set; }`

`RepairJob` must also include an `abstract` method `public abstract decimal CalculateFee();`.

Create derived classes `BasicRepairJob`, `RegularRepairJob` and `ComplexRepairJob` that inherit from `RepairJob`. They must implement the `CalculateFee()` method according to the rules described above.

**Tipp**: Take a look at [this code sample](https://dotnetfiddle.net/UPxCVi) to learn how to calculate the number of hours between two `DateTime` values.

```cs
using System;

var start = DateTime.Parse("2023-09-28T09:00:00");
var end = DateTime.Parse("2023-09-28T11:30:00");

var jobDuration = Math.Ceiling((end - start).TotalHours);

Console.WriteLine($"{jobDuration}");
```

### Console App `ServiceFeeCalculatorApp`

Write a console app for calculating the fee of a job:

* Ask the user for all necessary data (e.g. type of repair job, description, start and end date and time, etc.)
* Create an instance of the appropriate class
* Call `CalculateFee()` and print the result to the console

## Requirements Level 2

[![](https://mermaid.ink/img/pako:eNp9kslOwzAQhl_F8gmkLrSFAhEnKByQAIlyQrlM7EliyUtkjxGo5N1xWuimUl9s_fPN6llw4STyjAsNIcwUVB5Mblk6r9iA8o-uYDff_T67haDEWjuIvGIVNfjj0J0zjcbPPWiZfoMuVmp3AnllKzbDILxqSDm7sc2A8E0ZZHMCTwf0eys3auGcZvMoBIZQRr0ytNv5d3vcKkJZYs_RFOhfyicUNVglwk6AtVfGoEg1gyAmUSgDmt2BFmkwhA-IJ6crfjdVdpTdn-txen_A_9O8xw16A0qmBVh2m3Oq0WDOs_SUWELUlPPctgmNjUyu91KR8zwrQQfscYjk5l9W8Ix8xD_od4_WlHYgMTktOH013bZVKlAKKZwtVdXp0esk10RNyIbDzjyoFNWxGAhnhkHJOn1w_XE9HU7H0ysYT3B6OYGLyUSKYnR9VY7PR6W8PBuNgbdtjzdg353bFIDLqp9-V7272h8Li_u_?type=png)](https://mermaid.live/edit#pako:eNp9kslOwzAQhl_F8gmkLrSFAhEnKByQAIlyQrlM7EliyUtkjxGo5N1xWuimUl9s_fPN6llw4STyjAsNIcwUVB5Mblk6r9iA8o-uYDff_T67haDEWjuIvGIVNfjj0J0zjcbPPWiZfoMuVmp3AnllKzbDILxqSDm7sc2A8E0ZZHMCTwf0eys3auGcZvMoBIZQRr0ytNv5d3vcKkJZYs_RFOhfyicUNVglwk6AtVfGoEg1gyAmUSgDmt2BFmkwhA-IJ6crfjdVdpTdn-txen_A_9O8xw16A0qmBVh2m3Oq0WDOs_SUWELUlPPctgmNjUyu91KR8zwrQQfscYjk5l9W8Ix8xD_od4_WlHYgMTktOH013bZVKlAKKZwtVdXp0esk10RNyIbDzjyoFNWxGAhnhkHJOn1w_XE9HU7H0ysYT3B6OYGLyUSKYnR9VY7PR6W8PBuNgbdtjzdg353bFIDLqp9-V7272h8Li_u_)

It turned out that we missed something. Basic repair jobs are sometimes done by more than one mechanic. The given price has to be paid *per mechanic*. Therefore, you must add a property with the number of mechanics that worked on the job to `BasicRepairJob`.

**Note** that senior and master mechanics always work alone!

Adjust the implementation of `CalculateFee()` accordingly.

## Requirements Level 3

Our mechanic has a price change. For *Junior mechanics*, she now charges 5€ per started quarter of an hour (e.g. 5 minutes mean 5€, 1 hour 5 minutes mean 25€). Adjust the implementation of `CalculateFee()` accordingly.

## Requirements Level 4

**Note**: This is a quite advanced requirement for your current level of knowledge. If you want to try this level, talk to your teacher in case of questions.

We got something wrong again. It turned out that master mechanics also work in teams. Therefore, we need to extend our class hierarchy:

[![](https://mermaid.ink/img/pako:eNqVU01P4zAQ_SuWTyAVSlsoNOJEyx5WYpFoTyiXiT1JLPkjsserRd38d5yWtjSCXdUXW2_eGz_PjNdcOIk840JDCAsFlQeTW5bWCzag_E9XsPu_FxdshWD20JZxBG1ZDxCU-D_tBauowfeIPdLcmUbjnx5pY_RAXW_RbgXyylZsgUF41ZBy9hBbAOFKGWRLAk9f4I9WHtDCOc2WUQgMoYx6G2g_33_0pk8elCX2K5oC_XP5hKIGq0Q40u9VGYMiWQZBTKJQBjSbgxapLoQ_EM_Ov6hedgr1n-mXqVQadxZ3GY7bl52g7Hf0FG2_0d-_kg-4QW9AyTSym7LnnGo0mPMsHSWWEDXlPLdtosZGJumjVOQ8z0rQAQccIrnlmxU8Ix9xR_qY_D1LO5CYRGtOb033PyoVKKUUzpaq6vDodYJroiZkw2EXvqwU1bG4FM4Mg5J1GrT692w6nI6ndzCe4PR2AjeTiRTFaHZXjq9Hpby9Go2Bt-2AN2BfnTsYwI3rp4_P2W3tO0VnOpA?type=png)](https://mermaid.live/edit#pako:eNqVU01P4zAQ_SuWTyAVSlsoNOJEyx5WYpFoTyiXiT1JLPkjsserRd38d5yWtjSCXdUXW2_eGz_PjNdcOIk840JDCAsFlQeTW5bWCzag_E9XsPu_FxdshWD20JZxBG1ZDxCU-D_tBauowfeIPdLcmUbjnx5pY_RAXW_RbgXyylZsgUF41ZBy9hBbAOFKGWRLAk9f4I9WHtDCOc2WUQgMoYx6G2g_33_0pk8elCX2K5oC_XP5hKIGq0Q40u9VGYMiWQZBTKJQBjSbgxapLoQ_EM_Ov6hedgr1n-mXqVQadxZ3GY7bl52g7Hf0FG2_0d-_kg-4QW9AyTSym7LnnGo0mPMsHSWWEDXlPLdtosZGJumjVOQ8z0rQAQccIrnlmxU8Ix9xR_qY_D1LO5CYRGtOb033PyoVKKUUzpaq6vDodYJroiZkw2EXvqwU1bG4FM4Mg5J1GrT692w6nI6ndzCe4PR2AjeTiRTFaHZXjq9Hpby9Go2Bt-2AN2BfnTsYwI3rp4_P2W3tO0VnOpA)

`BasicRepairJob` and `RegularRepairJob` get a new base class: `TeamRepairJob`. In this class, we add a property `int NumberOfMechanics { get; set; }`.

`BasicRepairJob` and `RegularRepairJob` must now implement `CalculateFeeSingleMechanic` which calculates the fee for a single mechanic. `TeamRepairJob.CalculateFee()` calls `CalculateFeeSingleMechanic` and multiplies the result with `NumberOfMechanics`.
