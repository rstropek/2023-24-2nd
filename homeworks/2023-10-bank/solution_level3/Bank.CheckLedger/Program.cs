using Bank.Logic;

var accountLines = File.ReadAllLines(args[0]);
var transactionLines = File.ReadAllLines(args[1]);

var accounts = new Account[accountLines.Length - 1];
var transactions = new Transaction[transactionLines.Length - 1];

for (int i = 1; i < accountLines.Length; i++)
{
    var accountFields = accountLines[i].Split(';');
    Account account;
    switch (accountFields[0])
    {
        case "c": account = new CheckingAccount(); break;
        case "b": account = new BusinessAccount(); break;
        case "s": account = new Savings(); break;
        case "f": account = new FixedDeposite(); break;
        default: Console.WriteLine("Invalid type"); return;
    }

    account.AccountNumber = accountFields[1];
    account.AccountHolder = accountFields[2];
    account.Balance = decimal.Parse(accountFields[3]);
    if (account is FixedDeposite fd)
    {
        fd.OpeningDate = DateOnly.Parse(accountFields[4]);
        fd.FixedUntil = DateOnly.Parse(accountFields[5]);
    }

    accounts[i - 1] = account;
}

for (int i = 1; i < transactionLines.Length; i++)
{
    var transactionFields = transactionLines[i].Split(';');
    var transaction = new Transaction
    {
        AccountNumber = transactionFields[0],
        Description = transactionFields[1],
        Amount = decimal.Parse(transactionFields[2]),
        Timestamp = DateTime.Parse(transactionFields[3])
    };
    transactions[i - 1] = transaction;
}

foreach(var t in transactions)
{
    foreach (var a in accounts)
    {
        if (a.AccountNumber == t.AccountNumber && !a.TryExecute(t))
        {
            Console.WriteLine($"Transaction with description {t.Description} on {t.Timestamp} not allowed");
            return;
        }
    }
}
