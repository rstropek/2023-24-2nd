# Garage

![Hero Image](hero.png)

## Introduction

A friend of yours want to open a new kind of garage. He offers parking in the middle of the city particularly for electrical cars. Customer pay per started half hour. Every parking spot has a charger that can be used by customers. Because your friend installed a huge photovoltaik system on the roof of the garage, he can offer the electricity for free.

You friend asked you to help him with the development of the software for his garage.

## Functional Requirements

The garage has 50 parking spots. They are numbered from 1 to 50.

Whenever a car enters the garage, your friend wants to enter the license plate, parking spot, and the entry date/time into your software. The software should check if the parking spot is free. If not, the entry should be rejected because your friend obviously did a typing mistake. If the parking spot is free, the car should be accepted and the parking spot should be marked as occupied.

When a car leaves the garage, the parking spot and the exit date/time should be entered into your software. The software should check if the parking spot was occupied. If not, another typing mistake happend and the entry is rejected. If the parking spot was occupied, the software has to calculate the parking fee assuming that every started half hour costs 3€ (cars can leave for free within 15 minutes after entry). After that, the parking spot should be marked as free.

At any time, your friend needs to be able to request a list of all parking spots with the vehicles currently parked there. The list should look like this:

```txt
| Spot | License Plate |
| ---- | ------------- |
| 1    | LU-AB 1234    |
| 2    |               |
| 3    |               |
| 4    | WU-145-AB     |
| 5    | XY-98345      |
...
| 49   | VA-083-XQ     |
| 50   |               |
```

## Implementation Tips

### `ParkingSpot`

Create a class or record `ParkingSpot` that represents a parking spot occupation. It should have the following properties:

- `licensePlate` (string)
- `entryDate` (DateTime)

### `Garage`

Create a class `Garage`. It should store the parking spots and contain all logic (=methods) related to parking spot management. Store data about parking spots in an array with 50 elements:

```csharp
public ParkingSpot[] parkingSpots { get; } = new ParkingSpot[50];
```

Note that if you declare the array like that, all elements are `null` initially. If you want to set e.g. parking spot 15 to occupied, use `parkingSpots[14] = new ParkingSpot(...);`. If you want to set this parking spot to free again, use `parkingSpots[14] = null;`.

### Methods in `Garage`

You could create the following methods in `Garage`:

- `bool IsOccupied(int parkingSpotNumber)`: Returns `true` if the parking spot is occupied, `false` otherwise.
- `bool TryOccupy(int parkingSpotNumber, string licensePlate, DateTime entryTime)`: Returns `true` if the parking spot is free, `false` otherwise.
- `bool TryExit(int parkingSpotNumber, DateTime exitTime, out decimal costs)`: Returns `true` if the parking spot was occupied, `false` otherwise. If the parking spot was occupied, `costs` should contain the calculated parking fee.
- `string GenerateReport()`: Returns a string containing the report as shown above.

## Input/Output

```txt
What do you want to do?
1) Enter a car entry
2) Enter a car exit
3) Generate report
4) Exit
Your selection: 1

Enter parking spot number: 1
Enter license plate: LU-AB 1234
Enter entry date/time: 2023-09-02T08:05:00

Your selection: 1

Enter parking spot number: 3
Enter license plate: XY-98345
Enter entry date/time: 2023-09-03T10:05:00

Your selection: 1

Enter parking spot number: 1
Parking spot is occupied

Your selection: 2

Enter parking spot number: 1
Enter exit date/time: 2023-09-02T11:15:00
Costs are 21€

Your selection: 2

Enter parking spot number: 1
Parking spot is not occupied

Your selection: 3

| Spot | License Plate |
| ---- | ------------- |
| 1    |               |
| 2    |               |
| 3    | XY-98345      |
| 4    |               |
...

Your selection: 4
Good bye!
```
