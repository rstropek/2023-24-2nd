# Stack-Based Inventory Management for Online Clothing Store

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

Certainly! Here's a simple example flow of incoming and outgoing boxes for the warehouse exercise:

1. Box of Socks arrives. (Stack: Socks)
2. Box of Trousers arrives. (Stack: Trousers, Socks)
3. Box of Shirts arrives. (Stack: Shirts, Trousers, Socks)
4. Another box of Trousers arrives. (Stack: Trousers, Shirts, Trousers, Socks)
5. Box of Underwear arrives. (Stack: Underwear, Trousers, Shirts, Trousers, Socks)
6. **Request**: A box of Shirts is needed for shipping. Remove Underwear. (Temporary Stack: Underwear | Main Stack: Trousers, Shirts, Trousers, Socks)
7. Remove Trousers. (Temporary Stack: Trousers, Underwear | Main Stack: Shirts, Trousers, Socks)
8. Remove Shirts for shipping. (Temporary Stack: Trousers, Underwear | Main Stack: Trousers, Socks)
9. Put back Trousers. (Stack: Trousers, Trousers, Socks)
10. Put back Underwear. (Stack: Underwear, Trousers, Trousers, Socks)

**Total Movements**: 10

![Operations visualized](./warehouse_stack_operations.svg)

#### Final State of the Stack
- Underwear, Trousers, Trousers, Socks

In this example, students would need to write a program that can simulate these operations, correctly maintaining the order of the boxes and calculating the total number of movements required for each request. The example provides a clear and straightforward scenario for testing their implementation.

### Requirements

- Implement the stack data structure in C#. Do **not** use the built-in stack class or any other built-in collection classes.
- Ensure your program can handle a sequence of incoming and outgoing box requests.
- Calculate and display the total number of box movements for each sequence.

### Validation

The file `operations.txt` contains a sequence of incoming and outgoing box requests. Your program should be able to handle this sequence and produce the following output:

```txt
Total box movements: 100
```

Certainly! Here's a chapter for the homework specification, detailing the advanced requirements for the warehouse management exercise with multiple stacks:

---

## Advanced Warehouse Management with Multiple Stacks

### Introduction

In this advanced exercise, you'll tackle a more complex scenario in FashionForward's warehouse. The warehouse now features five separate stacks for storing boxes of clothing. Your challenge is to manage these stacks efficiently, optimizing the placement and retrieval of boxes under new operational constraints.

### Objective

Develop a C# program that simulates a warehouse with five stacks, numbered 0-4. Your program must efficiently handle incoming and outgoing boxes, following specific rules for placement and shipping.

### Requirements

#### Stack Management

- **Multiple Stacks**: The warehouse has five stacks for box storage.
- **Stack Identification**: Stacks are numbered from 0 to 4.

#### Incoming Boxes

- **Placement Rule**: When a new box arrives, it should be placed on the stack with the lowest height.
- **Tiebreaker**: If multiple stacks have the same height, place the box on the stack with the lowest number.

#### Shipping Boxes

- **Retrieval Rule**: When a specific type of clothing is to be shipped, find the stack where the box is nearest to the top.
- **Tiebreaker for Shipping**: If the required box is at the same depth in multiple stacks, retrieve it from the stack with the lowest number.

#### Moving Boxes

- **No Temporary Stack**: Unlike the basic version, there is no separate temporary stack.
- **Relocation Rule**: If you need to move boxes to reach a specific box, relocate each box to the stack with the lowest height.
- **Tiebreaker for Relocation**: If multiple stacks have the same height, move the box to the stack with the lowest number.
