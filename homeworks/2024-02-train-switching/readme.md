# Train Switching Management

![Hero Image](./hero.png)

## Overview

This exercise focuses on the management of train switching operations within a medium-sized railway station. You have to process a series of switching operations from a text file, manage the placement of different types of wagons and locomotives across 10 tracks, and calculate checksums to validate the final arrangement of wagons on each track.

## Initial Conditions

- **Tracks**: The station has 10 tracks numbered from 1 to 10.
  - **Tracks 1-8** can be accessed from both the East and West sides.
  - **Tracks 9-10** are terminal tracks and can only be accessed from the West.
- **Initial State**: All tracks are empty at the beginning of the exercise.

## Switching Operations

The text file contains a series of operations, each specified in one of the following formats:

1. **At track `<n>`, add Passenger Wagon from `<East|West>`**
2. **At track `<n>`, add Locomotive from `<East|West>`**
3. **At track `<n>`, add Freight Wagon from `<East|West>`**
4. **At track `<n>`, add Car Transport Wagon from `<East|West>`**
5. **At track `<n>`, remove `<m>` wagon(s) from `<East|West>`**
6. **At track `<n>`, train leaves to `<East|West>`** (removes all wagons from the specified track)

Here is a short sample file:

```text
At track 4, add Locomotive from West
At track 3, add Freight Wagon from West
At track 3, remove 1 wagon from East
At track 1, add Freight Wagon from West
At track 3, add Locomotive from East
At track 3, add Freight Wagon from West
At track 3, add Freight Wagon from East
At track 3, remove 2 wagons from West
At track 3, train leaves to East
At track 7, add Car Transport Wagon from West
At track 10, add Car Transport Wagon from East
At track 4, add Car Transport Wagon from West
At track 4, remove 2 wagons from East
At track 1, add Freight Wagon from West
At track 5, add Car Transport Wagon from West
At track 3, add Car Transport Wagon from West
```

### Invalid Operations

Operations that are considered invalid and should be ignored include:

- Removing more wagons than available.
- Adding or removing wagons from a track that is not accessible from the specified side.
- Adding or removing wagons to/from tracks that do not exist.
- A train leaves without a locomotive.
- A train leaves from a track that does not exist.
- A train leaves when there are no wagons on the track.

## Goal

The goal is to read through the text file, execute the valid switching operations, and calculate the final arrangement of wagons on each track. After processing each operation, a checksum must be calculated to validate the arrangement.

* Start by implementing `TrainSwitching.Logic.SwitchingOperationParser.Parse`.
* Next, implement `TrainSwitching.Logic.TrainStation.TryApplyOperation`.
* Finally, implement `TrainSwitching.Logic.TrainStation.CalculateChecksum`.

## Checksum Calculation

The checksum is calculated after each operation as follows:

1. **Value of a Wagon**: Here is a table showing the value of each type of wagon:

    | Wagon Type           | Value (Points) |
    |----------------------|----------------|
    | Passenger Wagon      | 1              |
    | Locomotive           | 10             |
    | Freight Wagon        | 20             |
    | Car Transport Wagon  | 30             |

2. **Track Value Calculation**:
   - Add the values of all wagons on a track.
   - Multiply the sum by the track number (tracks are one-based).

3. **Checksum**:
   - The checksum is the sum of the values from all tracks.

The checksum for the sample file shown above is **550**. The file contains **2** failing operations.

## Expected Outcome

You get a skeleton project with unit tests and methods to implement. If you implement all unit tests correctly, all should be green.

Additionally, you have a test application *TrainSwitching.Importer*. If you run it for the short sample file (*switchings-short.txt*) shown above, you should get the following output:

```text
Number of failing operations: 2 (12.50 %)
Checksum at the end: 550
```

If you run it for a larger file (*switchings.txt*), you should get the following output:

```text
Number of failing operations: 550 (27.50 %)
Checksum at the end: 2968
```

## Advanced Requirements

Find out what **enumerations** (`enum`) are in C# and rewrite the entire program so that it uses meaningful enumerations instead of constants.
