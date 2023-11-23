# Stack-Based Inventory Management for Online Clothing Store

![Hero image](./hero.png)

## Introduction

Welcome to your internship at _FashionForward_, a dynamic clothing company venturing into the online marketplace. As part of the digital transformation team, you are tasked with developing a key component of the inventory management system. Your challenge is to simulate the management of boxes in our warehouse using the stack data structure in C#.

## Background

FashionForward's warehouse is bustling with an array of clothing items, each packed in individual boxes labeled with the type of clothing (e.g., shirts, socks, underwear, trousers). Due to space constraints, we can only maintain a single stack of these boxes. Your software will play a crucial role in efficiently managing the flow of incoming and outgoing boxes.

## Task Overview

Your primary objective is to write a program in C# that accurately tracks and manages the movement of boxes in the warehouse according to the following rules:

### Rules

1. **Incoming Boxes**: When a new box arrives, it is placed on top of the **main stack**.

2. **Retrieving Boxes**: When a specific type of clothing needs to be shipped out, you'll need to temporarily transfer boxes to a **secondary stack** until you reach the box containing the desired clothing type. Once the box is retrieved, the boxes from the secondary stack should be **returned** to the main stack in their original order.

3. **Movement Tracking**: Your program should efficiently track and calculate the **total number of box movements** required for each operation.

### Example

Here is an example flow of operations:

1. Box of Socks arrives

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Socks 
    ```

2. Box of Trousers arrives

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Trousers
    Socks 
    ```

3. Box of Shirts arrives

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Shirts
    Trousers
    Socks 
    ```

4. Another box of Trousers arrives

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Trousers
    Shirts
    Trousers
    Socks 
    ```

5. Box of Underwear arrives

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Underwear
    Trousers
    Shirts
    Trousers
    Socks 
    ```

6. **A box of Shirts is needed for shipping**. Start moving items to temp. stack.

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Trousers
    Shirts
    Trousers
    Socks               Underwear
    ```

7. Move Trousers

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Shirts
    Trousers            Trousers
    Socks               Underwear
    ```

8. Remove Shirts for shipping

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Trousers            Trousers
    Socks               Underwear
    ```
  
9. Put back Trousers

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Trousers
    Trousers
    Socks               Underwear
    ```

10. Put back Underwear

    ```txt
    MAIN STACK          TEMP. STACK
    --------------------------------------            
    Underwear
    Trousers
    Trousers
    Socks
    ```

**Total Movements**: 10

### Requirements

- Implement the stack data structure in C#. Create a `ClothesStack` class for this. Do **not** use the built-in stack class or any other built-in collection classes.
- Ensure your program can handle a sequence of incoming and outgoing box requests.
- Calculate and display the total number of box movements for each sequence.

The file [`operations_short.txt`](./solution/level1/operations_short.txt) contains the sequence of incoming and outgoing box requests shown above. If you process this file, the output of your program should look like this:

```txt
incoming Socks
Socks
Box movements: 1

incoming Trousers
Trousers, Socks
Box movements: 2

incoming Shirts
Shirts, Trousers, Socks
Box movements: 3

incoming Trousers
Trousers, Shirts, Trousers, Socks
Box movements: 4

incoming Underwear
Underwear, Trousers, Shirts, Trousers, Socks
Box movements: 5

shipping Shirts
Underwear, Trousers, Trousers, Socks
Box movements: 10

Total box movements: 10
```

The file [`operations_long.txt`](./solution/level1/operations_long.txt) contains a much longer sequence of incoming and outgoing box requests. Try it. **It results in 100 box movements.**

## Advanced Warehouse Management with Multiple Stacks

### Introduction

In this advanced exercise, you'll tackle a more complex scenario in FashionForward's warehouse. The warehouse now features five separate stacks for storing boxes of clothing. Your challenge is to manage these stacks efficiently, optimizing the placement and retrieval of boxes under new operational constraints.

Develop a C# program that simulates a warehouse with five stacks, numbered 0-4. Your program must handle incoming and outgoing boxes, following specific rules for placement and shipping. Tip: Create a new class `Warehouse` to encapsulate the five stacks.

### Requirements

- **Placement Rule**: When a new box arrives, it should be placed on the stack with the lowest height.
  - **Tiebreaker for Placement**: If multiple stacks have the same height, place the box on the stack with the lowest number.
- **Retrieval Rule**: When a specific type of clothing is to be shipped, find the stack where the box is nearest to the top.
  - **Tiebreaker for Shipping**: If the required box is at the same depth in multiple stacks, retrieve it from the stack with the lowest number.
- **No Temporary Stack**: Unlike the basic version, there is no separate temporary stack.
- **Relocation Rule**: If you need to move boxes to reach a specific box, relocate each box to the stack with the lowest height.
  - **Tiebreaker for Relocation**: If multiple stacks have the same height, move the box to the stack with the lowest number.

### Example

The file [`operations_short.txt`](./solution/level2/operations_short.txt) contains the sequence of incoming and outgoing box requests shown above. If you process this file, the output of your program should look like this:

```txt
incoming Socks
Stack 0: Socks
Stack 1: 
Stack 2: 
Stack 3: 
Stack 4: 

Box movements: 1

incoming Trousers
Stack 0: Socks
Stack 1: Trousers
Stack 2: 
Stack 3: 
Stack 4: 

Box movements: 2

incoming Shirts
Stack 0: Socks
Stack 1: Trousers
Stack 2: Shirts
Stack 3: 
Stack 4: 

Box movements: 3

incoming Trousers
Stack 0: Socks
Stack 1: Trousers
Stack 2: Shirts
Stack 3: Trousers
Stack 4: 

Box movements: 4

incoming Underwear
Stack 0: Socks
Stack 1: Trousers
Stack 2: Shirts
Stack 3: Trousers
Stack 4: Underwear

Box movements: 5

shipping Shirts
Stack 0: Socks
Stack 1: Trousers
Stack 2: 
Stack 3: Trousers
Stack 4: Underwear

Box movements: 6
Total box movements: 6
```

The file [`operations_long.txt`](./solution/level2/operations_long.txt) contains a much longer sequence of incoming and outgoing box requests. Try it. **It results in 47 box movements.**
