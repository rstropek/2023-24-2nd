# Banking System

## Introduction

You are a programmer at a bank. Your job is to create a simple class library for account management. Here are the business requirements:

- The system must maintain _Accounts_.
    - Each account has an _Account Number_ (e.g. _ABC1234_).
    - Each account has an _Account Holder_ (e.g. _John Doe_).
    - Each account has a _Current Balance_. For a new account, the balance is 0.
- _Transactions_ are applied to accounts.
    - Each transaction refers to an _Account Number_. **Note** that transactions are only allowed if the number of the account matches the account number in the transaction.
    - Each transaction has a _Description_ (e.g. _Salary Payment_).
    - Each transaction has an _Amount_ (e.g. _1,000€_).
    - Each transaction has a _Timestamp_ (e.g. _2020-10-25T09:00:00_).

There are three types of accounts:

- _Checking Account_
    - They are primarily for private customers.
    - The balance of checking accounts must be between -10,000€ and 10,000,000€.
    - The maximum amount for a single transaction is 10,000€.
- _Business Account_
    - They are primarily for business customers.
    - The balance of business accounts must be between -1,000,000€ and 100,000,000€.
    - The maximum amount for a single transaction is 100,000€.
- _Savings Account_
    - The balance of savings accounts must be between 0€ and 100,000,000€.
    - There is no maximum amount for transactions.

## Requirements Level 1

### Class Library

- Implement a _Class Library_ called `Banking.Logic`.
- The class library needs to contain the following classes:
    - `Account` (abstract base class)
    - `CheckingAccount` (derived from `Account`)
    - `BusinessAccount` (derived from `Account`)
    - `SavingsAccount` (derived from `Account`)
    - `Transaction`
- `Account` must declare an _abstract_ method `abstract bool IsAllowed(Transaction)`. The method returns `true` if the transaction is allowed for the account, otherwise `false`.
- `Account` must define a method `bool TryExecute(Transaction)`. The method first checks if the transaction is allowed by calling `IsAllowed`. If the transaction is allowed, the method updates the `CurrentBalance` of the account and returns `true`. Otherwise, the method returns `false`.
- The classes derived from `Account` must implement the two abstract methods.

### Console App

- Implement a _Console App_ called `Banking.App`.
- Ask the user for the following data:
    - Type of account
    - Account number
    - Account holder
    - Current balance
- Based on this data, create an instance of the appropriate account type.
- Ask the user for the following data:
    - Transaction account number
    - Transaction description
    - Transaction amount
    - Transaction timestamp
- Based on this data, create an instance of the `Transaction` class.
- Call the `IsAllowed` method of the account instance to check if the transaction is allowed.
- If the transaction is allowed, call the `TryExecute` method of the account instance to execute the transaction.
- If the transaction was successfully executed, print the following message to the console: `Transaction executed successfully. The new current balance is ...€`.

[![](https://mermaid.ink/img/pako:eNqdU01P6zAQ_CuWTyAVSltegYhLoUhw4F3oCeWysTeJhT8ie817Vcl_xykNpVWFBDk40czsrL2erLhwEnnGhYYQ5goqDya3LD0zIVy0xK7fTk7YE7wqW4UDzG2N4iVxG_CA4iYGZTGEHcW6X69bfWCMBfLJqof_RlOgP8zdOy23nEShDGh2G71HSzegwQrsWShSLQhihXOaPYSZ1u4fyqOFBxsSrpw97rVrycIv7_6jiIQHNO3XA2zmstop_67DTvXe7H7psjffX7p8oX9yHXMMwqumK-uZORAulEHWLYHANPvXNDPbILR8wA16A0qmGK5b55xqNJjzLH1KLCFqynluO2lsZLK_k4qc51kJOuCAQyT3tLSCZ-Qj9qJNmj9V2kGKDM9WnJZNl_lKBUqWwtlSVR0evU5wTdSEbDjs6NNKUR2LU-HMMChZg6f69Wo6nI6nlzCe4PRiAn8mEymK0dVlOT4flfLibDQG3rYD3oB9dm67AVzv-nHzw3Wv9h19piqk?type=png)](https://mermaid.live/edit#pako:eNqdU01P6zAQ_CuWTyAVSltegYhLoUhw4F3oCeWysTeJhT8ie817Vcl_xykNpVWFBDk40czsrL2erLhwEnnGhYYQ5goqDya3LD0zIVy0xK7fTk7YE7wqW4UDzG2N4iVxG_CA4iYGZTGEHcW6X69bfWCMBfLJqof_RlOgP8zdOy23nEShDGh2G71HSzegwQrsWShSLQhihXOaPYSZ1u4fyqOFBxsSrpw97rVrycIv7_6jiIQHNO3XA2zmstop_67DTvXe7H7psjffX7p8oX9yHXMMwqumK-uZORAulEHWLYHANPvXNDPbILR8wA16A0qmGK5b55xqNJjzLH1KLCFqynluO2lsZLK_k4qc51kJOuCAQyT3tLSCZ-Qj9qJNmj9V2kGKDM9WnJZNl_lKBUqWwtlSVR0evU5wTdSEbDjs6NNKUR2LU-HMMChZg6f69Wo6nI6nlzCe4PRiAn8mEymK0dVlOT4flfLibDQG3rYD3oB9dm67AVzv-nHzw3Wv9h19piqk)

Sample input/output:

```txt
Type of account ([c]hecking, [b]usiness, [s]avings): c
Account number: ABC1234
Account holder: John Doe
Current balance: -9900
Transaction account number: ABC1234
Transaction description: Buy new TV
Transaction amount: -1500
Transaction timestamp: 2020-10-25T09:00:00
Transaction not allowed.
```

```txt
Type of account ([c]hecking, [b]usiness, [s]avings): c
Account number: DEF9876
Account holder: John Doe
Current balance: 1000
Transaction account number: ABC1234
Transaction description: Buy new TV
Transaction amount: -500
Transaction timestamp: 2020-10-25T09:00:00
Transaction not allowed.
```

```txt
Type of account ([c]hecking, [b]usiness, [s]avings): c
Account number: ABC1234
Account holder: John Doe
Current balance: 1000
Transaction account number: ABC1234
Transaction description: Buy new TV
Transaction amount: -500
Transaction timestamp: 2020-10-25T09:00:00
Transaction executed successfully. The new current balance is 500€.
```

## Requirements Level 2

- Write a second console app. Call it `Banking.CheckLedger`
- This console app receives two _File Names_ via the command line arguments.
- The first file contains the account data. The second file contains the transaction data.
- The console app reads the account data and creates an instance of the appropriate account type for each account.
- The console app reads the transaction data and creates an instance of the `Transaction` class for each transaction.
- The console app calls the `IsAllowed` method of the account instance to check if the transaction is allowed.
- If the transaction is allowed, the console app calls the `TryExecute` method of the account instance to execute the transaction.
- If the transaction is not allowed, the console app prints the following message to the console: `Transaction with description ... on ... not allowed.`. The first `...` is the transaction description, the second `...` is the transaction timestamp. The program stops after printing the message.

Sample file for accounts:

```txt
Type;AccountNumber;AccountHolder;CurrentBalance
c;ABC1234;John Doe;1000
b;XYZ9876;Jane Doe;100000
s;DEF4567;Max Mustermann;50000
```

Sample file for transactions

```txt
AccountNumber;Description;Amount;Timestamp
ABC1234;Buy new TV;-500;2020-10-25T09:00:00
XYZ9876;Salary Payment;-10000;2020-10-25T09:00:00
DEF4567;Payment;10000;2020-10-25T09:00:00
ABC1234;Buy new car;-50000;2020-10-26T09:00:00
```

Output for samples above:

```txt
Transaction with description "Buy new car" on "2020-10-26T09:00:00" not allowed.
```

## Requirements Level 3

Your bank introduces a new type of account: _Fixed Deposite Account_. Here are the business requirements:

- The balance of fixed deposite accounts must be between 0€ and 10,000,000€.
- A fixed deposite account has an _Opening Date_. Money transfer _to_ a fixed deposite account can _only_ happen on the opening date.
- A fixed deposite account has a _Fixed Until Date_. Money transfer _from_ a fixed deposite account can _only_ happen on or after the _fixed until_ date.

[![](https://mermaid.ink/img/pako:eNqdVMtu2zAQ_BWCpxZw4tpunUToxYlTtIc2hziXQpcVuZKI8iGQyzSG638vpVjxo06AWgc9ZmZnV6tdrbhwEnnGhYYQ5goqDya3LB0zIVy0xD7_OTtj9_CobBWOMDc1il-J24BHFNcxKIshvK74op5QzrFxQRE-8109vWr1jDEWyKdUPfwjmgL9ce6r03LLSRTKgGY30Xu0dA0arMCehSLFgiBWOKfZtzDT2v1G-W7hwYaEK2ff99pOsvDL2ycUkfCIZr37Apu-rfbC38qwF33Q2xNdDvp_osveN3rxmAPhndVLdtegTZW2z_9wXeiDJaVPS71D_88kzDEIr5o2bLekhTLI2lMgMM3hhMzMdkbXfMANegNKpg3pUuecajSY8yzdSiwhasp5bltpbGSyv5WKnOdZCTrggEMkd7-0gmfkI_aizaK9qLSDNK08W3FaNu06VipQshTOlqpq8eh1gmuiJmTDYUufV4rqWJwLZ4ZByRo81Y9X0-F0PL2E8QSnFxP4NJlIUYyuLsvxx1EpLz6MxsDX6wFvwP50blsAdlV_3_wL2sv6LzAWXbg?type=png)](https://mermaid.live/edit#pako:eNqdVMtu2zAQ_BWCpxZw4tpunUToxYlTtIc2hziXQpcVuZKI8iGQyzSG638vpVjxo06AWgc9ZmZnV6tdrbhwEnnGhYYQ5goqDya3LB0zIVy0xD7_OTtj9_CobBWOMDc1il-J24BHFNcxKIshvK74op5QzrFxQRE-8109vWr1jDEWyKdUPfwjmgL9ce6r03LLSRTKgGY30Xu0dA0arMCehSLFgiBWOKfZtzDT2v1G-W7hwYaEK2ff99pOsvDL2ycUkfCIZr37Apu-rfbC38qwF33Q2xNdDvp_osveN3rxmAPhndVLdtegTZW2z_9wXeiDJaVPS71D_88kzDEIr5o2bLekhTLI2lMgMM3hhMzMdkbXfMANegNKpg3pUuecajSY8yzdSiwhasp5bltpbGSyv5WKnOdZCTrggEMkd7-0gmfkI_aizaK9qLSDNK08W3FaNu06VipQshTOlqpq8eh1gmuiJmTDYUufV4rqWJwLZ4ZByRo81Y9X0-F0PL2E8QSnFxP4NJlIUYyuLsvxx1EpLz6MxsDX6wFvwP50blsAdlV_3_wL2sv6LzAWXbg)

Change both console apps to support the new account type.

Example input/output for `Banking.App`:

```txt
Type of account ([c]hecking, [b]usiness, [s]avings, [f]ixed deposite): f
Account number: ABC9876
Account holder: John Doe
Current balance: 1000
Opening date: 2020-10-25
Fixed until date: 2021-10-25
Transaction account number: ABC9876
Transaction description: Buy new TV
Transaction amount: -500
Transaction timestamp: 2020-12-01T09:00:00
Transaction not allowed.
```

Sample file for accounts:

```txt
Type;AccountNumber;AccountHolder;CurrentBalance;OpeningDate;FixedUntil
c;ABC1234;John Doe;1000;;
b;XYZ9876;Jane Doe;100000;;
s;DEF4567;Max Mustermann;50000;;
f;ASD4535;Tom Turbo;0;2020-10-25;2021-10-25
```

Sample file for transactions

```txt
AccountNumber;Description;Amount;Timestamp
ABC1234;Buy new TV;-500;2020-10-25T09:00:00
XYZ9876;Salary Payment;-10000;2020-10-25T09:00:00
DEF4567;Salary Payment;10000;2020-10-25T09:00:00
ASD4535;Initial transfer;10000;2020-10-25T09:00:00
ASD4535;Withdrawal;-5000;2020-12-01T09:00:00
```

Output for samples above:

```txt
Transaction with description "Withdrawal" on "2020-12-01T09:00:00" not allowed.
```

## Requirements Level 4

**Note:** This requirement is quite hard for your current level.

Your bank decides to restructure the type hierarchy:

- `Accounts` get an additional property `decimal InterestRate` (e.g. 0.05 for 5% per year).
- `Accounts` get an additional method `virtual decimal CalculateMonthlyInterests()`. It takes the `CurrentBalance`, multiplies it with the `InterestRate` and divides it by 12. **Note** that this method is a `virtual` method. It contains an implementation, **but** it can be overridden by descendant classes.
- `CheckingAccounts` and `BusinessAccounts` can also have negative balances. Because of this, they get a common base class `BorrowingAccount`. `BorrowingAccount` is derived from `Account`. It has a property `decimal BorrowingRate`. It also overrides the `CalculateMonthlyInterests` method. The new implementation uses the `BorrowingRate` if the `CurrentBalance` is negative, otherwise it calls the base class' implementation that uses `InterestRate`.

[![](https://mermaid.ink/img/pako:eNqdVN9v2jAQ_lciP3USLQM22kZ7gabT9tBVWtnLxMthXxJrjh3ZZ9oo43-fAyFAxCaNPCTWfd999yPnqxk3AlnMuALnEgmZhWKpo_DMODdeU_Tp9_V1NDfWmleps9Z6hvIC64C7HdLn7ygPOfJffZHz1Ll3UqNzf4_3Wb6hSLA0ThLu8G0Re1a9s0WRIxvU9-ZvvlihPY99MUocMIFcFqCiB28tapqDAs2xj37VhBYdfQfqMFgFXeAUrYwJDDdTyryiuFpY0C7YpdHv9twtZWGrxzfknvAsZy0t-RCrywgU9yoEfDKaclXtc3BXrcvmuB_9Btf9EjrCcQ2XxWqHoD6p7l8NOPHuzceFKr3RuVDlZLw6jSQ04lmrKnouUYdMk6OOddjW9YcmqS4LfQT_zxAn6LiVZeN2nNJCFhg1L0dQlP3fOysO12vDBqxAW4AUYSNsQy8Z5VjgksXhKDAFr2jJlrqh-lIE-UchyVgWp6AcDhh4Mi-V5iwm63FPahdLx1IGwkVjcc2oKpv1k0lHQZIbncqssXurgjknKl08HDbwTSYp96sbboqhkyIHS_n6fjqcjqd3MJ7g9HYCHycTwVej-7t0_GGUitv3ozGwzWbAStA_jTkkgNusn9rd13w2fwCepLGh?type=png)](https://mermaid.live/edit#pako:eNqdVN9v2jAQ_lciP3USLQM22kZ7gabT9tBVWtnLxMthXxJrjh3ZZ9oo43-fAyFAxCaNPCTWfd999yPnqxk3AlnMuALnEgmZhWKpo_DMODdeU_Tp9_V1NDfWmleps9Z6hvIC64C7HdLn7ygPOfJffZHz1Ll3UqNzf4_3Wb6hSLA0ThLu8G0Re1a9s0WRIxvU9-ZvvlihPY99MUocMIFcFqCiB28tapqDAs2xj37VhBYdfQfqMFgFXeAUrYwJDDdTyryiuFpY0C7YpdHv9twtZWGrxzfknvAsZy0t-RCrywgU9yoEfDKaclXtc3BXrcvmuB_9Btf9EjrCcQ2XxWqHoD6p7l8NOPHuzceFKr3RuVDlZLw6jSQ04lmrKnouUYdMk6OOddjW9YcmqS4LfQT_zxAn6LiVZeN2nNJCFhg1L0dQlP3fOysO12vDBqxAW4AUYSNsQy8Z5VjgksXhKDAFr2jJlrqh-lIE-UchyVgWp6AcDhh4Mi-V5iwm63FPahdLx1IGwkVjcc2oKpv1k0lHQZIbncqssXurgjknKl08HDbwTSYp96sbboqhkyIHS_n6fjqcjqd3MJ7g9HYCHycTwVej-7t0_GGUitv3ozGwzWbAStA_jTkkgNusn9rd13w2fwCepLGh)

Write another console app called `Banking.InterestCalculator`:

- Ask the user for the following data:
    - Type of account
    - Account number
    - Account holder
    - Current balance
    - Interest rate
    - Borrowing rate (only for borrowing accounts)
- Based on this data, create an instance of the appropriate account type.
- Calculate the monthly interest for the account by calling `CalculateMonthlyInterests`.
- Print the following message to the console: `The monthly interest is ...€.`.

Sample input/output:

```txt
Type of account ([c]hecking, [b]usiness, [s]avings, [f]ixed deposite): c
Account number: ABC1234
Account holder: John Doe
Current balance: 1000
Interest rate: 0.05
The monthly interest is 4.17€.
```

```txt
Type of account ([c]hecking, [b]usiness, [s]avings, [f]ixed deposite): c
Account number: ABC1234
Account holder: John Doe
Current balance: -500
Interest rate: 0.09
The monthly interest is -3,75€.
```
