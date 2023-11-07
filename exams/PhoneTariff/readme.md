# Phone Tariffs

<iframe width="560" height="315" src="https://www.youtube.com/embed/wwPdJnzdIk4?si=xWFfSVhnFSmTIYX8" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>

## Introduction

You work at a phone company. This company offers a lot of different phone tariffs. However, you can group them into three different, fundamental types of tariffs (note that we ignore phone calls in this simplified example and focus on data usage only):

1. _Flat Fee_: A customers pays a fixed amount of money per month. This covers all calls and all data transfer.

2. _Pay as you go_: Customers do not pay any base fee. They only pay per megabyte of data transfer.

3. _Starter_: Customers pay a base fee. It includes a certain amount megabytes data transfer. If the customer uses more, she pays per megabyte for the data transfer exceeding the included amount.

You have to write a program where a user can enter the parameters of her tariff (e.g. which type of tariff, included megabytes, base fee etc.). Next, the program analyzes her phone usage in a month (see [_usage.csv_](./usage.csv)) and calculates the total costs for the month.

## Minimum Requirements

You have to write a program where a user can enter the parameters of her tariff (e.g. which type of tariff, included megabytes, base fee etc.) as well as her monthly data usage. Next, the program calculates the total costs for the month.

1. Create a class library `PhoneTariff.Logic`. It must contain _all_ the classes and calculation logic.

2. Create a console app `PhoneTariff.App`. It contains the code for user interaction.

3. In `PhoneTariff.Logic`, implement the following class hierarchy:

    [![](https://mermaid.ink/img/pako:eNqtk01Lw0AQhv9K2JNC29hE0zZ4EbXioVDQi5LLZHeSLGyyYT-Koea_u0nTD6iHIu5ll5l3n3l3mN0SKhmSmFABWj9xyBWUSeW59Q6KZ5l3_z0ee2toHvSHtC_yPLcUYJaI54kV_0K2C_f0IbndhboFqTYKqPEYUl6C8B5BUOt46IBXTNpUoFdiDmljUF_vLranyKOxE-yetlac4hrVaiAcFXKDSnGGfy88vPqXqitZmUI0h5b8T72-mRdWG3ivFRWWIds_X1_SoXPNhVbJiJSoSuDMTVNvNCGmwBITErsjwwysMAlJqtZJbc0c8ZlxIxWJMxAaRwSskW9NRUlslMW9aBjKg0pIYOgubYlp6m50c66NQ1JZZTzv4lYJFy6MqXXs-116knNT2HRCZelrzgpQptgsIj8KojkEIUazEO7CkNF0uphnwe00Y7ObaQCkbUekhupTyqMB7F2vhn_Tbe0POiUTXA?type=png)](https://mermaid.live/edit#pako:eNqtk01Lw0AQhv9K2JNC29hE0zZ4EbXioVDQi5LLZHeSLGyyYT-Koea_u0nTD6iHIu5ll5l3n3l3mN0SKhmSmFABWj9xyBWUSeW59Q6KZ5l3_z0ee2toHvSHtC_yPLcUYJaI54kV_0K2C_f0IbndhboFqTYKqPEYUl6C8B5BUOt46IBXTNpUoFdiDmljUF_vLranyKOxE-yetlac4hrVaiAcFXKDSnGGfy88vPqXqitZmUI0h5b8T72-mRdWG3ivFRWWIds_X1_SoXPNhVbJiJSoSuDMTVNvNCGmwBITErsjwwysMAlJqtZJbc0c8ZlxIxWJMxAaRwSskW9NRUlslMW9aBjKg0pIYOgubYlp6m50c66NQ1JZZTzv4lYJFy6MqXXs-116knNT2HRCZelrzgpQptgsIj8KojkEIUazEO7CkNF0uphnwe00Y7ObaQCkbUekhupTyqMB7F2vhn_Tbe0POiUTXA)

Sample outputs:

```text
Which tariff? [F]lat fee, [M]ixed, [P]ay as you go: f
Monthly fee: 70
How many MB did you use? 50
You have to pay 70€
```

```text
Which tariff? [F]lat fee, [M]ixed, [P]ay as you go: m
Monthly fee: 45
Included megabytes: 1000
Price per megabyte: 0.02
How many MB did you use? 1450
You have to pay 54.00€
```

```text
Which tariff? [F]lat fee, [M]ixed, [P]ay as you go: p
Price per megabyte: 0.05
How many MB did you use? 750
You have to pay 37.50€
```

## Additional Requirements

### Changed Class Hierarchy

Restructure the class hierarchy as follows:

[![](https://mermaid.ink/img/pako:eNqtk1tLwzAUx79KyZPCLm7VXYov3iY-DAYKovTlNDltA2lTchmW2e9uunZbZYJDzEvCye_888_JyYZQyZAEhArQ-p5DoiALc8-NF1A8jr3rz37fW0F5o9-kfZTHe836lZv0FjQuELtIJ9zQCwHmN2bJP5A1xNZWy22aUD0g0kYBNR5DyjMQ3h0Iap10LXLGpI0EehkmEJUG9XmTWHUlDzfqyO7UVopTXKFatgoHQq5RKc7w7wcf3fmH85cyN6ko93X6JtBWcPOfprYV7xppcp5yKixDtquDPqVUx8yJdkiPZKgy4Mz149ZMSEyKGYYkcEuGMVhhQhLmlUNtwZziA-NGKhLEIDT2CFgjn8ucksAoizuobes9JSQwdEkbYsqibv6Ea-MkqcxjntRxq4QLp8YUOhgO6-1B4l7MRgMqs6HmLAVl0vV8MpyMJzMY-ziZ-nDl-4xGo_ksHl-OYja9GI2BVFWPFJC_S3kwgFvXy_bn1VP1BWUZKrY?type=png)](https://mermaid.live/edit#pako:eNqtk1tLwzAUx79KyZPCLm7VXYov3iY-DAYKovTlNDltA2lTchmW2e9uunZbZYJDzEvCye_888_JyYZQyZAEhArQ-p5DoiALc8-NF1A8jr3rz37fW0F5o9-kfZTHe836lZv0FjQuELtIJ9zQCwHmN2bJP5A1xNZWy22aUD0g0kYBNR5DyjMQ3h0Iap10LXLGpI0EehkmEJUG9XmTWHUlDzfqyO7UVopTXKFatgoHQq5RKc7w7wcf3fmH85cyN6ko93X6JtBWcPOfprYV7xppcp5yKixDtquDPqVUx8yJdkiPZKgy4Mz149ZMSEyKGYYkcEuGMVhhQhLmlUNtwZziA-NGKhLEIDT2CFgjn8ucksAoizuobes9JSQwdEkbYsqibv6Ea-MkqcxjntRxq4QLp8YUOhgO6-1B4l7MRgMqs6HmLAVl0vV8MpyMJzMY-ziZ-nDl-4xGo_ksHl-OYja9GI2BVFWPFJC_S3kwgFvXy_bn1VP1BWUZKrY)

### Import

You got a [usage file](./usage.csv) for a customer. It contains all phone calls and data transfers of a month (Sept. 2023). Here are the first few lines of the file:

```csv
type,timestamp,call_length_minutes,megabytes
data,2023-02-21T06:10:30Z,0,111.714
data,2022-11-24T21:03:00Z,0,99.197
data,2023-04-16T20:40:06Z,0,20.126
data,2022-12-31T08:29:32Z,0,129.445
data,2023-06-05T07:21:09Z,0,120.137
data,2022-11-17T03:21:06Z,0,56.05
phone,2023-02-10T08:12:18Z,12.95,0
data,2023-06-19T20:19:47Z,0,113.878
...
```

Parse it and calculate the total costs for the month. Note that you can ignore phone calls in this simplified example and focus on data usage only.

Parsing must be done in `PhoneTariff.Logic` **in a dedicated class** called `Importer`. It must be **a `static` class**! Create a second, non-static class `Usage` that holds the data of a single usage entry.

[![](https://mermaid.ink/img/pako:eNplUctOwzAQ_JXIJ5CqhiaQtrlSDkiUC-UC4bCxN44lPyJ7g1RV-XecNFAQe_BjZrw7uz4x7gSyknENIewUSA-mskmMCUleA0g8nZExAnllZXI4dngBd0B4UAaTcQkEprtwwvW1xuQetH5CK6n9R-1RQn0kDGdm-F3-0XTOE_o_DoAUPxt7_5gV0-1qNtcojc9g8PonIVswg96AErHVKVfFqEWDFSvjUWADvaaKVXaI0r4TsaEHoch5VjagAy4Y9ORejpazknyP36J5Yj8q7UBgfHRiFCcUi0kVKKbkzjZKjnjvdYRboi6UaTrSS6mo7esldyYNSrTgqf3cFmmRFRvIcizWOdzlueD1artpsttVI9Y3qwzYMCxYB_bNuYsBnFzv508dt-ELSrieFw?type=png)](https://mermaid.live/edit#pako:eNplUctOwzAQ_JXIJ5CqhiaQtrlSDkiUC-UC4bCxN44lPyJ7g1RV-XecNFAQe_BjZrw7uz4x7gSyknENIewUSA-mskmMCUleA0g8nZExAnllZXI4dngBd0B4UAaTcQkEprtwwvW1xuQetH5CK6n9R-1RQn0kDGdm-F3-0XTOE_o_DoAUPxt7_5gV0-1qNtcojc9g8PonIVswg96AErHVKVfFqEWDFSvjUWADvaaKVXaI0r4TsaEHoch5VjagAy4Y9ORejpazknyP36J5Yj8q7UBgfHRiFCcUi0kVKKbkzjZKjnjvdYRboi6UaTrSS6mo7esldyYNSrTgqf3cFmmRFRvIcizWOdzlueD1artpsttVI9Y3qwzYMCxYB_bNuYsBnFzv508dt-ELSrieFw)

Sample outputs:

```text
Which tariff? [F]lat fee, [M]ixed, [P]ay as you go: f
Monthly fee: 45
You have to pay 45.00€
```

```text
Which tariff? [F]lat fee, [M]ixed, [P]ay as you go: m
Monthly fee: 45
Included megabytes: 1000
Price per megabyte: 0.02
You have to pay 143.8914€
```

```text
Which tariff? [F]lat fee, [M]ixed, [P]ay as you go: p
Price per megabyte: 0.05
You have to pay 297.2285€
```
