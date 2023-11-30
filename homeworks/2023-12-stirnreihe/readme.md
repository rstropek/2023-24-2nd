# World Record "Stirnreihe"

## Introduction

In Austria, we have the word "Stirnreihe" which means a row of people (often students) standing in a line arranged by height.

![Stirnreihe](./stirnreihe.png)

It is a great whish of one of your friends to get into the Guiness Book of World Records so he decides to organize the world's longest "Stirnreihe". He asks you to help him with the organization.

In order to get into the Guiness Book of World Records, every person in the line must be documented. The line will consist of at least 250 people, maybe even many more. It is your job to write a program with which you can document people in the line.

## Basic Requirements

### Data Structure

You have to store the people standing in line using a _linked list_. Each person is represented by a node in the linked list. Each node has a reference to the next one. The last node has a reference to `null`. Additionally, you must store a reference to the first person in the line.

Here is a list of classes that you are going to need:

* `Person`: A person has a first name, a last name, and a height in cm.
* `Node`: A node has a reference to the person it represents and a reference to the next node in the line.
* `LineOfPeople`: A linked list has a reference to the first node (`Node` class) in the line. From there, you can traverse the whole list by following the references to the next nodes.

The `LineOfPeople` class has to have a method `AddToFront(Person person)`. It adds a new person to the beginning of the line. Additionally, `LineOfPeople` must offer a method `Clear()` that removes all people from the line.

The `Person` class must override `ToString`. It returns a string representation of the person in the following format: `lastName, firstName (height cm)` (e.g. `Smith, Jane (178 cm)`).

[![](https://mermaid.ink/img/pako:eNp1kt9PwjAQx_-VpU-QAJNNBy4mxqjEB0QSeDJ7Odbb1mRrl-5GJMv-d7tfCEb70t7nfnzv2lYsVByZz8IUiuJFQKwhC6Rl1hZ1oaT1MJ1aGxPTweb0H1oLiR_RFlWe9q62aF-o6pBl7UgLGVsroQvaQIa_-BqusZBkvaGIExqIOqLWwojuVZczGneu-lK1aeus2c_SbQNsIh6tDX7RH-mXw1TXGW3nA3rifK9WWkkaddXHg-c5RdDn1tiEZagzENxcdlswYJSgmZP55sgxgjKlgAWyCYWS1O4kQ-aTLnHCypwDYf88zI8gLQzNQX4q9WN3Ua9ckNJnmCrgaMyK0SlvXjoWBRmJUMlIxA0vdWpwQpQXvm037lksKCkPs1BldiF4ApqS471ne463BMdFb-HCnevy8DC_X0bO7Tzii5u5A6yuJwxb_ff-WzVb_Q3D2MLS?type=png)](https://mermaid.live/edit#pako:eNp1kt9PwjAQx_-VpU-QAJNNBy4mxqjEB0QSeDJ7Odbb1mRrl-5GJMv-d7tfCEb70t7nfnzv2lYsVByZz8IUiuJFQKwhC6Rl1hZ1oaT1MJ1aGxPTweb0H1oLiR_RFlWe9q62aF-o6pBl7UgLGVsroQvaQIa_-BqusZBkvaGIExqIOqLWwojuVZczGneu-lK1aeus2c_SbQNsIh6tDX7RH-mXw1TXGW3nA3rifK9WWkkaddXHg-c5RdDn1tiEZagzENxcdlswYJSgmZP55sgxgjKlgAWyCYWS1O4kQ-aTLnHCypwDYf88zI8gLQzNQX4q9WN3Ua9ckNJnmCrgaMyK0SlvXjoWBRmJUMlIxA0vdWpwQpQXvm037lksKCkPs1BldiF4ApqS471ne463BMdFb-HCnevy8DC_X0bO7Tzii5u5A6yuJwxb_ff-WzVb_Q3D2MLS)

**Implement these classes in a separate class library**. The name of the class library should be `Stirnreihe.Data`.

### User Interface

Implement a console app `Stirnreihe.App` that allows the user to add people to the line and to print the line to the console.

```text
Welcome to the Stirnreihe World Record App! What do you want to do?
1) Add a person to the line
2) Print the line
3) Clear the line
4) Exit
Your choice: 1

First name: Jane
Last name: Smith
Height in cm: 178

Your choice: 1

First name: John
Last name: Doe
Height in cm: 175

Your choice: 1

First name: Max
Last name: Mustermann
Height in cm: 173

Your choice: 2

Mustermann, Max (173 cm)
Doe, John (175 cm)
Smith, Jane (178 cm)

Your choice: 3

The line has been cleared.

Your choice: 2

The line is empty

Your choice: 4
```

## Advanced Requirements (Level 1)

Add a new method to the `LineOfPeople` class: `AddSorted(Person person)`. It adds a person to the line **in a sorted way**. The line is **sorted by height in ascending order**. The smallest person is at the beginning of the line, the tallest person is at the end of the line. If two people have the same height, the new person is added after the last person with the same height. The method must return the index of the new person in the line (starting with 0).

Make sure to test the following cases:

* A person is added to an empty line.
* A person is added to the beginning of the line.
* A person is added to the end of the line.
* A person is added somewhere in the middle of the line.

```text
Welcome to the Stirnreihe World Record App! What do you want to do?
1) Add a person to the line
1b) Add a person to the line (sorted)
2) Print the line
3) Clear the line
4) Exit
Your choice: 1b

First name: John
Last name: Doe
Height in cm: 175

Your choice: 1b

First name: Max
Last name: Mustermann
Height in cm: 173

Your choice: 1b

First name: Jane
Last name: Smith
Height in cm: 178

Your choice: 2

Mustermann, Max (173 cm)
Doe, John (175 cm)
Smith, Jane (178 cm)

Your choice: 4
```

## Advanced Requirements (Level 2)

Add a new method to the `LineOfPeople` class: `RemovePersonAt(int index)`. It removes the person at the given index from the line. The method must return the person that has been removed.

Make sure to test the following cases:

* The line is empty.
* The index is out of range.
* A person at the beginning of the line is removed.
* A person at the end of the line is removed.
* A person in the middle of the line is removed.

## Advanced Requirements (Level 3)

Add a new method to the `LineOfPeople` class: `Sort()`. It sorts the line by height in ascending order. The smallest person is at the beginning of the line, the tallest person is at the end of the line. Use the _Bubblesort_ algorithm that we discussed last year.
