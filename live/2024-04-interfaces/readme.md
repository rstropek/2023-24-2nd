# Craftspeople Billing

## Introduction

Your job is to implement a billing system for craftpeople. Your application allows entering the hours worked for a craftsperson. Additionally, the user can enter the skill level (junior, senior, master). Independent of the effort of craftspeople, users can also entere costs for materials as well as travel costs. Finally, users can enter optional discounts (e.g. Austrian _Handwerkerbonus_).

The rules for billing working hours for craftspeople are as follows:

* Every started hours is billed as a full hour.
* The hourly rate depends on the skill level:
  * Junior: 50€
  * Senior: 75€
  * Master: 100€
* If a person works more than 8 hours a day, the additional hours are billed with a 50% surcharge.

Material costs are simple. The user enters the costs and they are added to the bill.

Travel costs are billed with 1€ per kilometer with a minimum of 10€. The user enters the distance and the costs are added to the bill.

The user can enter an optional discount. The discount is entered in percent or as an absolute value.The discount is applied to the total bill (including surcharges).

At the end, 20% VAT is added to the total bill.

## Your Task

### Logic

Create a class library `CraftspeopleBilling` that contains the following classes:

* Create an abstract base class `Billable`.
* Create an abstract class `CraftspersonEffort` that is derived from `BillableEffort` and implements the billing rules for craftspeople.
  * Create a class `JuniorCraftspersonEffort` that is derived from `CraftspersonEffort` and implements the billing rules for junior craftspersons.
  * Create a class `SeniorCraftspersonEffort` that is derived from `CraftspersonEffort` and implements the billing rules for senior craftspersons.
  * Create a class `MasterCraftspersonEffort` that is derived from `CraftspersonEffort` and implements the billing rules for master craftspersons.
* Create a class `MaterialCosts` that is derived from `BillableEffort` and implements the billing rules for material costs.
* Create a class `TravelCosts` that is derived from `BillableEffort` and implements the billing rules for travel costs.
* Create a class `Discount` that is derived from `BillableEffort` and implements the billing rules for discounts.
* Create a class `Bill` that contains a list of `Billable` objects and calculates the total bill.

### UI

Create a console app `CraftspeopleBillingApp` that allows the user to enter the data for a bill and print the bill.

* Create an abstract base class `BillableUI` that contains the following method:
  * `public abstract Billable ReadFromConsole()`
  * `public abstract void PrintToConsole(Billable billable)`
* Create a class `CraftspersonEffortUI` that is derived from `BillableUI` and implements the UI for entering and printing the data for a craftsperson effort.
* Create a class `MaterialCostsUI` that is derived from `BillableUI` and implements the UI for entering and printing the data for material costs.
* Create a class `TravelCostsUI` that is derived from `BillableUI` and implements the UI for entering and printing the data for travel costs.
* Create a class `DiscountUI` that is derived from `BillableUI` and implements the UI for entering and printing the data for discounts.
* Create an abstract base class `BillUI` that contains the following method:
  * `public abstract Bill ReadFromConsole()`
  * `public abstract void PrintToConsole(Bill bill)`

### UI Example

```txt
==================================
      Craftspeople Billing
==================================
What do you want to enter?
1) Craftsperson Effort
2) Material Costs
3) Travel Costs
4) Discount
5) Nothing, you want to print the bill
Your choice: 1

Craftsperson Effort:
Number of hours: 2.25
Skill level (_j_unior, _s_enior, _m_aster): j

What do you want to enter?
1) Craftsperson Effort
2) Material Costs
3) Travel Costs
4) Discount
5) Nothing, you want to print the bill
Your choice: 4

Discount:
In _p_ercent or _a_bsolute: a
Discount: 50

What do you want to enter?
1) Craftsperson Effort
2) Material Costs
3) Travel Costs
4) Discount
5) Nothing, you want to print the bill
Your choice: 1

Craftsperson Effort:
Number of hours: 9.75
Skill level (_j_unior, _s_enior, _m_aster): s

What do you want to enter?
1) Craftsperson Effort
2) Material Costs
3) Travel Costs
4) Discount
5) Nothing, you want to print the bill
Your choice: 2

Material Costs:
Costs: 25

What do you want to enter?
1) Craftsperson Effort
2) Material Costs
3) Travel Costs
4) Discount
5) Nothing, you want to print the bill
Your choice: 3

Travel Costs:
Distance (km): 5

What do you want to enter?
1) Craftsperson Effort
2) Material Costs
3) Travel Costs
4) Discount
5) Nothing, you want to print the bill
Your choice: 4

Discount:
In _p_ercent or _a_bsolute: p
Discount: 10

What do you want to enter?
1) Craftsperson Effort
2) Material Costs
3) Travel Costs
4) Discount
5) Nothing, you want to print the bill
Your choice: 5

===========================================
                    Bill
===========================================

Junior Craftsperson, 3 hours        150.00
Senior Craftsperson, 10 hours       825.00
Material Costs                       25.00
Travel Costs                         10.00
-------------------------------------------
Intermediate Total                 1010.00
Discount                            -50.00
Discount                           -101.00
-------------------------------------------
Net Total                           859.00
VAT 20%                             171.80
-------------------------------------------
Total                              1030.80
===========================================
```
