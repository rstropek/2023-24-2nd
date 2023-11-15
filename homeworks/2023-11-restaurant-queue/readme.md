# Restaurant Queue

## Introduction

You work as a software developer in a very popular restaurant. Every day, there is a long queue of people who would like to eat there. The restaurant has a limited number of tables, so not everyone can be seated. The restaurant manager has asked you to write a program that will help him manage the queue. He wants to serve people on a first-come-first-served basis.

## Minimum Requirements

* The restaurant manager can add a new customer to the end of the queue. For each customer, the manager enters the customer's name and a phone number.
* The restaurant manager can ask the program for the next customer to be seated (i.e. the customer in the front of the queue). The program will display the customer's name and phone number. Additionally, the program will remove the customer from the queue.
* The restaurant manager can ask the program to display the entire queue of customers. The program will display the name and phone number of each customer in the queue, starting from the front.

Input/output sample:

```txt
What do you want to do?
1) Add a customer to the queue
2) Seat the next customer
3) Display the queue

Your choice: 1
Enter customer name: John Doe
Enter customer phone number: 555-1234

Your choice: 1
Enter customer name: Jane Smith
Enter customer phone number: 555-9876

Your choice: 1
Enter customer name: Joe Schmoe
Enter customer phone number: 555-5555

Your choice: 3
John Doe (555-1234)
Jane Smith (555-9876)
Joe Schmoe (555-5555)

Your choice: 2
Seating John Doe (555-1234)

Your choice: 3
Jane Smith (555-9876)
Joe Schmoe (555-5555)

Your choice: 2
Seating Jane Smith (555-9876)

Your choice: 2
Seating Joe Schmoe (555-5555)

Your choice: 3
The queue is empty
```

## Implementation Tips

Use the following class to store customers:

```cs
class CustomerInQueue
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public CustomerInQueue? Next { get; set; }
}
```

Note the property `Next`. This is a reference to the next customer in the queue. If this is the last customer in the queue, then `Next` will be `null`.

Store the first customer in the queue in a variable called `firstCustomer`. When the manager asks to seat the next customer, you can remove the first customer from the queue by setting `firstCustomer` to `firstCustomer.Next`. Here is an example of a queue with two customers:

```txt
┌───────────────┐    ┌───────────────┐     ┌───────────────┐
│ firstCustomer ┼───►│ John Doe      │ ┌──►│ Jane Smith    │
└───────────────┘    │ 555-1234      │ │   │ 555-9876      │
                     │ Next ─────────┼─┘   │ Next = null   │
                     └───────────────┘     └───────────────┘
```

You can optionally store the last customer in the queue in a variable called `lastCustomer`. When the manager adds a new customer to the queue, you can add the customer to the end of the queue by setting `lastCustomer.Next` to the new customer. If the queue is empty, then `lastCustomer` will be `null`. Here is an example of a queue with two customers:

```txt
┌───────────────┐    ┌───────────────┐     ┌───────────────┐    ┌───────────────┐
│ firstCustomer ┼───►│ John Doe      │ ┌──►│ Jane Smith    │◄───┼ lastCustomer  │
└───────────────┘    │ 555-1234      │ │   │ 555-9876      │    └───────────────┘
                     │ Next ─────────┼─┘   │ Next = null   │
                     └───────────────┘     └───────────────┘
```

## Extra Requirements

### Saving the Queue

The restaurant manager wants to be able to save queue data to a file and read it from a file. You can choose which file format to use. CSV is a good choice, but you can use something else if you prefer.

```txt
What do you want to do?
1) Add a customer to the queue
2) Seat the next customer
3) Display the queue
4) Save the queue to queue.csv
5) Load the queue from queue.csv

Your choice: 1
Enter customer name: John Doe
Enter customer phone number: 555-1234

Your choice: 1
Enter customer name: Jane Smith
Enter customer phone number: 555-9876

Your choice: 1
Enter customer name: Joe Schmoe
Enter customer phone number: 555-5555

Your choice: 4
Saved 3 customers to queue.csv
```

```txt
What do you want to do?
1) Add a customer to the queue
2) Seat the next customer
3) Display the queue
4) Save the queue to queue.csv
5) Load the queue from queue.csv

Your choice: 5
Loaded 3 customers from queue.csv

Your choice: 3
John Doe (555-1234)
Jane Smith (555-9876)
Joe Schmoe (555-5555)
```

### Leaving the Queue (⚠️ Hard)

Sometimes, customers leave the queue. In that case, the restaurant manager wants to remove the customer from the queue. The program will ask the manager for the customer's name. The program will then remove the customer from the queue.

```txt
What do you want to do?
1) Add a customer to the queue
2) Seat the next customer
3) Display the queue
4) Save the queue to queue.csv
5) Load the queue from queue.csv
6) Remove customer from the queue

Your choice: 1
Enter customer name: John Doe
Enter customer phone number: 555-1234

Your choice: 1
Enter customer name: Jane Smith
Enter customer phone number: 555-9876

Your choice: 1
Enter customer name: Joe Schmoe
Enter customer phone number: 555-5555

Your choice: 3
John Doe (555-1234)
Jane Smith (555-9876)
Joe Schmoe (555-5555)

Your choice: 6
Enter customer name: Jane Smith

Your choice: 3
John Doe (555-1234)
Joe Schmoe (555-5555)
```
